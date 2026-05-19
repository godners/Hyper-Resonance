using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using Markdig;

namespace HyRsn
{
    internal static class V
    {
        internal static readonly String ENL = Environment.NewLine, SEP = String.Empty;
        internal const String HAJ = "application/json", AUTH = "Authorization", ACP = "Accept";
        internal static readonly HttpMethod HMP = HttpMethod.Post;
        internal const HttpCompletionOption HCORHR = HttpCompletionOption.ResponseHeadersRead;
        internal static Boolean SNS(String S) => String.IsNullOrWhiteSpace(S);
        internal const MessageBoxButtons MBBO = MessageBoxButtons.OK;
        internal const MessageBoxIcon MBII = MessageBoxIcon.Information, MBIE = MessageBoxIcon.Error;
        internal const RegexOptions ROM = RegexOptions.Multiline, RON = RegexOptions.None;
        internal static readonly MarkdownPipeline MDPL = new MarkdownPipelineBuilder()
            .UseAdvancedExtensions().UsePreciseSourceLocation().Build();
        internal static readonly Encoding UTF8 = Encoding.UTF8;
        internal static readonly String Desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        internal const DialogResult DROK = DialogResult.OK;
        internal const JsonValueKind JVKA = JsonValueKind.Array;
        internal const String CssTemplate = @"
<style>
    body {
        font-family: __FNAME__, -apple-system, sans-serif; font-size: __FSIZE__pt; 
        line-height: 1.5; color: #24292e; padding: 10px;  margin: 0; word-wrap: break-word;
    }
    ul, ol { padding-left: 1.5em; margin-left: 0; }
    p, h1, h2, h3, h4 { margin-top: 0; margin-bottom: 10px; }
    code, pre { font-family: Consolas, monospace; background-color: #f6f8fa; border-radius: 3px; }
    table { border-collapse: collapse; width: 100%; margin-bottom: 16px; }
    th, td { border: 1px solid #d0d7de; padding: 6px 13px; }
    tr:nth-child(even) { background-color: #f6f8fa; }
</style>";
        internal const String HtmlTemplate = @"
<!DOCTYPE html><html><head><meta charset='UTF-8'>
__CssCode__</head><body>__HtmlCode__</body></html>";
    }
}
