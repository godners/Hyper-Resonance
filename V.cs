using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using Markdig;
using System.Reflection;
using System.Diagnostics;
using System.Linq;

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
        internal static readonly String StyleFrame = UTF8.GetString(Properties.Resources.Style);
        internal static readonly String ViewFrame = UTF8.GetString(Properties.Resources.View);
        internal const String JsAllHtml = "document.documentElement.outerHTML";
        internal static String RepoUrl => Assembly.GetExecutingAssembly()
            .GetCustomAttributes<AssemblyMetadataAttribute>()
            .FirstOrDefault(V => V.Key == "RepositoryUrl")?.Value ?? SEP;
        internal const String ClientName = "Hyper-Resonance Client";
        internal const String SFilter = "HTML Files (*.html)|*.html|All Files (*.*)|*.*";
        internal const String OFilter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";
    }
}
