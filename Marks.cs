using System.Text.RegularExpressions;
using Markdig;
using Markdig.Renderers.Normalize;
using Markdig.Syntax;

namespace HyRsn
{
    //internal partial class WinHR
    //{
        internal static class Marks
        {
            private static readonly Tuple<String, String, RegexOptions>[] MDDict =
                [
                new (@"^(#+)([^#\s])", "$1 $2", V.ROM),   // MD018
                new (@"(\r?\n){3,}", $"{V.ENL}{V.ENL}", V.RON),   // MD012
                new(@"^(\s*>\s+)\s+", "$1", V.ROM),       // MD027
                new(@"(\[\]:\s*)+$", V.SEP, V.RON)     // MD047
                ];
            internal static String Lint(String Input)
            {
                if (V.SNS(Input)) return V.SEP;
                MarkdownDocument MD = Markdown.Parse(Input, V.MDPL);
                using StringWriter SW = new();
                NormalizeOptions NO = new() {
                    ListItemCharacter = '-', SpaceAfterQuoteBlock = true, EmptyLineAfterThematicBreak = true,
                    EmptyLineAfterCodeBlock = true, EmptyLineAfterHeading = true, ExpandAutoLinks = true
                };
                NormalizeRenderer NR = new(SW, NO); NR.Render(MD);
                String Output = SW.ToString();
                foreach (Tuple<String, String, RegexOptions> T in MDDict)
                    Output = Regex.Replace(Output, T.Item1, T.Item2, T.Item3);
                return Output.TrimEnd() + V.ENL;
            }
        }
    //}
}