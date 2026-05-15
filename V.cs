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
    }
}
