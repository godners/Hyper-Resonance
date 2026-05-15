using System.Net;
using System.Text;
using System.Text.Json;

namespace HyRsn
{
    internal static class Completion
    {
        private static void PrepareHistory(AIConfig AI, String Input)
        {
            if (AI.History.Count == 0) AI.History.Add(RoleMessage);
            AI.History.Add(new AIMessage("user", Input));
        }
        private static HttpClient NewHC(AIConfig AI)
        {
            HttpClientHandler HCH = new();
            if (!V.SNS(AI.Proxy)) HCH.Proxy = new WebProxy(AI.Proxy);
            return new HttpClient(HCH);
        }
        private static String AIKey(AIConfig AI) => $"Bearer {AI.ApiKey}".Trim();
        private static StringContent ReqString(AIConfig AI) => new(JsonSerializer.Serialize(
            new { model = AI.Model, messages = AI.History, stream = true }), V.UTF8, V.HAJ);
        private static HttpRequestMessage NewHReqM(AIConfig AI)
        {
            String URL = AI.EndPoint.TrimEnd('/') + "/chat/completions";
            HttpRequestMessage HRM = new(V.HMP, URL);
            HRM.Headers.Add(V.ACP, V.HAJ);
            HRM.Headers.Add(V.AUTH, AIKey(AI));
            HRM.Content = ReqString(AI);
            return HRM;
        }
        private static async Task<String> MatchStream(HttpResponseMessage HRM, RichTextBox T)
        {
            using Stream S = await HRM.Content.ReadAsStreamAsync();
            using StreamReader SR = new(S); StringBuilder SB = new();

            while (!SR.EndOfStream)
            {
                String? Line = await SR.ReadLineAsync();
                if (V.SNS(Line!) || !Line!.StartsWith("data: ")) continue;
                String Data = Line[6..].Trim();
                if (Data == "[DONE]") break;
                using JsonDocument JD = JsonDocument.Parse(Data);
                if (JD.RootElement.TryGetProperty("choices", out JsonElement JEC) &&
                    JEC[0].TryGetProperty("delta", out JsonElement JED) &&
                    JED.TryGetProperty("content", out JsonElement Content))
                {
                    String Text = Content.GetString() ?? V.SEP;
                    SB.Append(Text); T.AppendText(Text); T.ScrollToCaret();
                }
            }
            return SB.ToString();
        }
        internal static async Task Execute(AIConfig AI, RichTextBox T, String Input, AIMessage Cache)
        {
            PrepareHistory(AI, Input); T.Clear();
            try
            {
                using HttpClient HC = NewHC(AI);
                using HttpRequestMessage HReqM = NewHReqM(AI);
                using HttpResponseMessage HRspM = await HC.SendAsync(HReqM, V.HCORHR);
                HRspM.EnsureSuccessStatusCode();
                String FullResp = await MatchStream(HRspM, T);
                Cache = new("assistant", FullResp);
            }
            catch (Exception EX) { T.AppendText($"\r\n[ERROR] ${EX.Message}"); }
        }

        internal static async Task Empty() => await Task.Delay(0);
        private static AIMessage RoleMessage = new("system", V.SEP);
        internal static String Role
        { get => RoleMessage.content; set => RoleMessage = new("system", Marks.Lint(value)); }

    }
}
