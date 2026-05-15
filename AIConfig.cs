#pragma warning disable IDE1006 // 命名样式
using System.Text.Json;

namespace HyRsn
{
    internal class AIConfig
    {
        internal String Provider { get; init; } = V.SEP;
        internal String ApiKey { get; init; } = V.SEP;
        internal String EndPoint { get; init; } = V.SEP;
        internal String Model { get; init; } = V.SEP;
        internal String Proxy { get; init; } = V.SEP;
        internal List<AIMessage> History { get; init; } = [];
        private AIStyle Style { get; init; } = new AIStyle();
        internal String Name => Style.Name;
        internal Color Fore => Style.Fore;
        internal Color Back => Style.Back;
        internal Boolean Enabled => Name != "NO Config";
        internal AIConfig() { }
        private static String JsonGetString(JsonElement Parent, String Name) =>
            Parent.TryGetProperty(Name, out JsonElement JE) ? JE.GetString() ?? V.SEP : V.SEP;
        internal AIConfig(String Path)
        {
            String J = File.ReadAllText(Path);
            try
            {
                using JsonDocument JD = JsonDocument.Parse(J);
                JsonElement JERoot = JD.RootElement;

                Provider = JsonGetString(JERoot, "Provider");
                ApiKey = JsonGetString(JERoot, "ApiKey");
                EndPoint = JsonGetString(JERoot, "EndPoint");
                Model = JsonGetString(JERoot, "Model");
                Proxy = JsonGetString(JERoot, "Proxy");
                History = [];

                if (JERoot.TryGetProperty(nameof(Style), out JsonElement JEStyle))
                {
                    String Name = JsonGetString(JEStyle, "Name");
                    if (V.SNS(Name)) Name = "Customer AI";
                    String Fore = JsonGetString(JEStyle, "Fore");
                    if (V.SNS(Fore)) Fore = "#000000";
                    String Back = JsonGetString(JEStyle, "Back");
                    if (V.SNS(Back)) Back = "#B0C4DE";
                    Style = new AIStyle(Name, Fore, Back);
                }
            }
            catch (Exception EX)
            { MessageBox.Show($"{EX.Message}\r\n{EX.StackTrace}", "[AIConfig] Error!", V.MBBO, V.MBIE); }
        }
    }
    internal record AIMessage(String role, String content);
    internal class AIStyle
    {
        internal String Name { get; init; } = "NO Config";
        internal Color Fore { get; init; } = Color.Black;
        internal Color Back { get; init; } = Color.LightSteelBlue;
        private static Color FromHex(String Hex) => ColorTranslator.FromHtml(Hex);
        internal AIStyle() { }
        internal AIStyle(String Name, String Fore, String Back)
        { this.Name = Name; this.Fore = FromHex(Fore); this.Back = FromHex(Back); }
    }
}