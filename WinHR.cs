#pragma warning disable IDE1006 // ÃüÃûÑùÊ½
using System.Diagnostics;
using System.Text.Json;

namespace HyRsn
{
    internal partial class WinHR : Form
    {

        //private static readonly String Desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        internal WinHR()
        {
            InitializeComponent();
            Htmls.MakeCss(Font);
            TFocus = TInput;
            InitializeMDView();
            InitializeConfigs();
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
            MDView.CoreWebView2.NavigateToString(Htmls.Code(MDCode));
        }



        private void BInputLint_Click(Object O, EventArgs E)
        {
            TInput.Text = Marks.Lint(TInput.Text);



        }

        private void T_Enter(Object O, EventArgs E)
        {
            TFocus = (RichTextBox)O;
            LViewSource.Text = $"VIEW: {TFocus.Tag}";
            UpdateView(TFocus.Text);
        }
        private void TInput_TextChanged(Object O, EventArgs E)
        {
            LInputCount.Text = Inputs.Count(TInput);
            T_TextChanged(O, E);
        }
        private void T_TextChanged(Object O, EventArgs E)
        {
            UpdateView(TFocus.Text);
        }


        private async void BSaveView_Click(Object O, EventArgs E)
        {
            using SaveFileDialog SFD = new() {
                InitialDirectory = V.Desktop, DefaultExt = "html",
                Filter = "HTML Files (*.html)|*.html|All Files (*.*)|*.*",
                Title = $"Save {TFocus.Tag} As HTML"
            };
            if (SFD.ShowDialog() == V.DROK)
            {
                try
                {
                    String HtmlCode = await Htmls.ToHtml(MDView);
                    await File.WriteAllTextAsync(SFD.FileName, HtmlCode, V.UTF8);
                    Htmls.SaveMsg(SFD.FileName, TFocus);
                }
                catch (Exception EX) { Htmls.SaveMsg(SFD.FileName, TFocus, EX.Message); }
            }

        }
        
        private Dictionary<String, AIConfig> AIConfigs = [];
        private void InitializeConfigs() => AIConfigs = new()
        { { "0", new AIConfig() }, { "1", new AIConfig() }, { "2", new AIConfig() } };
        private static String ControlID(Object O) => ((Control)O).Name[^1..];

        private void BSelect_Click(Object O, EventArgs E)
        {
            using OpenFileDialog OFD = new () {
                InitialDirectory = V.Desktop, DefaultExt = "json",
                Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*",
                Title = $"Select Model Configure to [{((Control)O).Tag}] As JSON"
            };
            if (OFD.ShowDialog() == V.DROK)
            {
                try
                {
                    String ID = ControlID(O); Button B = (Button)O;
                    AIConfigs[ID] = new AIConfig(OFD.FileName);
                    B.Text = AIConfigs[ID].Style.Name;
                    B.ForeColor = AIConfigs[ID].Style.Fore;
                    B.BackColor = AIConfigs[ID].Style.Back;
                }
                catch (Exception EX)
                { MessageBox.Show($"{EX.Message}\r\n{EX.StackTrace}", "[AIConfig] Error!", V.MBBO, V.MBIE); }
            }

        }
    }
}
