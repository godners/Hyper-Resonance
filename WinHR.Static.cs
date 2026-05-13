using System.Text.Json;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Markdig;
using Markdig.Renderers.Normalize;
using Markdig.Syntax;
using Microsoft.Web.WebView2.WinForms;

namespace HyRsn
{
    internal partial class WinHR
    {
        internal static class Static
        {
            private static readonly String ENL = Environment.NewLine, SEP = String.Empty;
            private const MessageBoxButtons MBBO = MessageBoxButtons.OK;
            private const MessageBoxIcon MBII = MessageBoxIcon.Information, MBIE = MessageBoxIcon.Error;
            private static Boolean NullBox(RichTextBox T) => String.IsNullOrEmpty(T.Text);
            internal static void CountInput1(RichTextBox T, Label L) => L.Text =
                $"Lines: {(NullBox(T) ? 0 : T.Lines.Length)}\r\n" +
                $"Chars: {T.Text.Length}";
            internal static String CountInput(RichTextBox T) =>
                $"Lines: {(NullBox(T) ? 0 : T.Lines.Length)}\r\n" +
                $"Chars: {T.Text.Length}";

            private static readonly MarkdownPipeline MDPL = new MarkdownPipelineBuilder()
                    .UseAdvancedExtensions().UsePreciseSourceLocation().Build();
            private static readonly Tuple<String, String, RegexOptions>[] MDDict =
                [
                new (@"^(#+)([^#\s])", "$1 $2", RegexOptions.Multiline),   // MD018
                new (@"(\r?\n){3,}", $"{ENL}{ENL}",  RegexOptions.None),   // MD012
                new(@"^(\s*>\s+)\s+", "$1", RegexOptions.Multiline),       // MD027
                new(@"(\[\]:\s*)+$", SEP,  RegexOptions.None)     // MD047
                ];
            internal static String MDLint(String Input)
            {
                if (String.IsNullOrWhiteSpace(Input)) return SEP;
                MarkdownDocument MD = Markdown.Parse(Input, MDPL);
                using StringWriter SW = new();
                NormalizeOptions NO = new() {
                    ListItemCharacter = '-', SpaceAfterQuoteBlock = true, EmptyLineAfterThematicBreak = true,
                    EmptyLineAfterCodeBlock = true, EmptyLineAfterHeading = true, ExpandAutoLinks = true
                };
                NormalizeRenderer NR = new(SW, NO);
                NR.Render(MD);
                String Output = SW.ToString();

                foreach (Tuple<String, String, RegexOptions> T in MDDict)
                    Output = Regex.Replace(Output, T.Item1, T.Item2, T.Item3);
                return Output.TrimEnd() + ENL; 
            }

            internal static void MakeCssCode(Font F)
            {
                String FName = F.FontFamily.Name; Single FSize = F.Size;
                if (FName.Contains(' ')) FName = $"'{FName}'";
                CssCode = $@"
<style>
    body {{
        font-family: {FName}, -apple-system, sans-serif; font-size: {FSize}pt; 
        line-height: 1.5; color: #24292e; padding: 10px;  margin: 0; word-wrap: break-word;
    }}
    ul, ol {{ padding-left: 1.5em; margin-left: 0; }}
    p, h1, h2, h3, h4 {{ margin-top: 0; margin-bottom: 10px; }}
    code, pre {{ font-family: Consolas, monospace; background-color: #f6f8fa; border-radius: 3px; }}
</style>";
            }
            private static String CssCode = String.Empty;
            internal static String ViewCode(String MDCode) => $@"
<!DOCTYPE html><html><head><meta charset='UTF-8'>
{CssCode}</head><body>{Markdown.ToHtml(MDCode, MDPL)}</body></html>";                


            internal async static Task<String> ToHtml(WebView2 V)
            {
                String RawHtml = await V.CoreWebView2.ExecuteScriptAsync("document.documentElement.outerHTML");
                return JsonSerializer.Deserialize<String>(RawHtml) ?? String.Empty;                
            }
            internal static void SaveMsg(String FileName, RichTextBox T, String Ex = "Null") =>
                MessageBox.Show(
                    Ex == "Null" ?
                    $"Saved {T.Tag} successfully!\r\n{FileName}" :
                    $"Error Saving {T.Tag} Error!\r\n{FileName}\r\n{Ex}",
                    Ex == "Null" ? "Save Successful" : "Save Error", MBBO,
                    Ex == "Null" ? MBII : MBIE
                    );
            


        }
    }

}
