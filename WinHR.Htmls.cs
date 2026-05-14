using System.Text.Json;
using Markdig;
using Microsoft.Web.WebView2.WinForms;

namespace HyRsn
{
    internal partial class WinHR
    {
        internal static class Htmls
        {
            private const String CssTemplate = @"
<style>
    body {
        font-family: __FNAME__, -apple-system, sans-serif; font-size: __FSIZE__pt; 
        line-height: 1.5; color: #24292e; padding: 10px;  margin: 0; word-wrap: break-word;
    }
    ul, ol { padding-left: 1.5em; margin-left: 0; }
    p, h1, h2, h3, h4 { margin-top: 0; margin-bottom: 10px; }
    code, pre { font-family: Consolas, monospace; background-color: #f6f8fa; border-radius: 3px; }
</style>";
            private static String CssCode = V.SEP;
            internal static void MakeCss(Font F)
            {
                String FName = F.FontFamily.Name; String FSize = F.Size.ToString();
                if (FName.Contains(' ')) FName = $"'{FName}'";
                CssCode = CssTemplate.Replace("__FNAME__", FName).Replace("__FSIZE__", FSize);
            }
            private const String HtmlTemplate = @"
<!DOCTYPE html><html><head><meta charset='UTF-8'>
__CssCode__</head><body>__HtmlCode__</body></html>";
            internal static String Code(String MDCode) =>
                HtmlTemplate.Replace("__CssCode__", CssCode).Replace("__HtmlCode__", Markdown.ToHtml(MDCode, V.MDPL));
            internal static async Task<String> ToHtml(WebView2 V)
            {
                String RawHtml = await V.CoreWebView2.ExecuteScriptAsync("document.documentElement.outerHTML");
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
}
