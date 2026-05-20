using System.Text.Json;
using Markdig;
using Microsoft.Web.WebView2.WinForms;

namespace HyRsn
{
    internal static class Htmls
    {
        private static String CssCode = V.SEP;
        internal static void MakeCss(Font F)
        {
            String FName = F.FontFamily.Name; String FSize = F.Size.ToString();
            if (FName.Contains(' ')) FName = $"'{FName}'";
            CssCode = V.StyleFrame.Replace("__FNAME__", FName).Replace("__FSIZE__", FSize);
        }
        internal static String Code(String MDCode) =>
            V.ViewFrame.Replace("__CssCode__", CssCode).Replace("__HtmlCode__", Markdown.ToHtml(MDCode, V.MDPL));
        internal static async Task<String> ToHtml(WebView2 W)
        {
            String RawHtml = await W.CoreWebView2.ExecuteScriptAsync(V.JsAllHtml);
            return JsonSerializer.Deserialize<String>(RawHtml) ?? String.Empty;
        }
        internal static void SaveMsg(String FileName, RichTextBox T, String Ex = "Null") =>
            MessageBox.Show(
                Ex == "Null" ?
                $"Saved {T.Tag} successfully!\r\n{FileName}" :
                $"Error Saving {T.Tag} Error!\r\n{FileName}\r\n{Ex}",
                Ex == "Null" ? "Save Successful" : "Save Error", V.MBBO,
                Ex == "Null" ? V.MBII : V.MBIE
                );
    }
}
