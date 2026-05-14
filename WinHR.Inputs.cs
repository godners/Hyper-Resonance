namespace HyRsn
{
    internal partial class WinHR
    {
        internal static class Inputs
        {
            private static Boolean NullBox(RichTextBox T) => String.IsNullOrEmpty(T.Text);
            internal static String Count(RichTextBox T) =>
                $"Lines: {(NullBox(T) ? 0 : T.Lines.Length)}\r\n" + $"Chars: {T.Text.Length}";
        }
    }
}
