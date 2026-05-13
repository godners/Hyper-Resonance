#pragma warning disable IDE1006 // ÃüÃûÑùÊ½
using System.Text.Json;

namespace HyRsn
{
    internal partial class WinHR : Form
    {
        private static readonly System.Text.Encoding UTF8 = System.Text.Encoding.UTF8;
        private const MessageBoxButtons MBBO = MessageBoxButtons.OK;
        private const MessageBoxIcon MBII = MessageBoxIcon.Information, MBIE = MessageBoxIcon.Error;
        private static readonly String Desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        internal WinHR()
        {
            InitializeComponent();
            Static.MakeCssCode(Font);
            TFocus = TInput;
            InitializeMDView();
        }
        private async void InitializeMDView()
        {
            await MDView.EnsureCoreWebView2Async();
            UpdateView(String.Empty);
        }
        private RichTextBox TFocus;



        private void UpdateView(String MDCode)
        {
            if (MDView.CoreWebView2 == null) return;
            MDView.CoreWebView2.NavigateToString(Static.ViewCode(MDCode));
        }



        private void BInputLint_Click(Object O, EventArgs E)
        {
            TInput.Text = Static.MDLint(TInput.Text);



        }

        private void T_Enter(Object O, EventArgs E)
        {
            TFocus = (RichTextBox)O;
            LViewSource.Text = $"VIEW: {TFocus.Tag}";
            UpdateView(TFocus.Text);
        }
        private void TInput_TextChanged(Object O, EventArgs E)
        {
            LInputCount.Text = Static.CountInput(TInput);
            T_TextChanged(O, E);
        }
        private void T_TextChanged(Object O, EventArgs E)
        {
            UpdateView(TFocus.Text);
        }


        private async void BSaveView_Click(Object O, EventArgs E)
        {
            using SaveFileDialog SFD = new() {
                InitialDirectory = Desktop, DefaultExt = "html",
                Filter = "HTML Files (*.html)|*.html|All Files (*.*)|*.*",
                Title = $"Save {TFocus.Tag} As HTML"
            };
            if (SFD.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    String RawHtml = await MDView.CoreWebView2.
                        ExecuteScriptAsync("document.documentElement.outerHTML");
                    String LintHtml = JsonSerializer.Deserialize<String>(RawHtml) ?? String.Empty;
                    await File.WriteAllTextAsync(SFD.FileName, LintHtml, UTF8);
                    MessageBox.Show($"Saved {TFocus.Tag} successfully!\r\n" +
                        $"{SFD.FileName}", "Save Successful", MBBO, MBII);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error Saving {TFocus.Tag}:\r\n" +
                        $"{SFD.FileName} {ex.Message}", "Save Error", MBBO, MBIE);
                }
            }
        }
    }
}
