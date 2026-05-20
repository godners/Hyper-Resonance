#pragma warning disable IDE1006 // ÃüÃûÑùÊ½
namespace HyRsn
{
    internal partial class WinHR : Form
    {


        internal WinHR()
        {
            InitializeComponent();
            Htmls.MakeCss(Font);
            TFocus = TInput;
            InitializeMDView();
            InitializeConfigs();
            InitializePOutputs();
            InitializeTOutputs();
            InitializeBContents();
            InitializeTasks();
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
            if (V.SNS(MDCode) && !V.SNS(TInput.Text)) return;
            MDView.CoreWebView2.NavigateToString(Htmls.Code(MDCode));
        }



        private void BInputLint_Click(Object O, EventArgs E)
        {
            TInput.Text = Marks.Lint(TInput.Text);



        }
        private String ViewSource()
        {
            if (TFocus.Name == "TInput") return TFocus.Tag?.ToString() ?? V.SEP;
            else return AIConfigs[ControlID(TFocus)].Name;
        }
        private void T_Focus(Object O, EventArgs E)
        {
            TFocus = (RichTextBox)O;
            LViewSource.Text = $"VIEW: {ViewSource()}";
            UpdateView(TFocus.Text);
        }
        private void TInput_TextChanged(Object O, EventArgs E)
        {
            LInputCount.Text = Inputs.Count(TInput);
            UpdateView(TFocus.Text);
        }
        private void TOutput_TextChanged(Object O, EventArgs E)
        {
            if (((RichTextBox)O).Focused) UpdateView(TFocus.Text);
        }


        private async void BSaveView_Click(Object O, EventArgs E)
        {
            using SaveFileDialog SFD = new() {
                InitialDirectory = V.Desktop, DefaultExt = "html",
                Filter = V.SFilter, Title = $"Save {TFocus.Tag} As HTML"
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
                InitialDirectory = V.Desktop, DefaultExt = "json", Filter = V.OFilter,
                Title = $"Select Model Configure to [{((Control)O).Tag}] As JSON"
            };
            OFD.InitialDirectory = @"D:\MyRepo\Hyper-Resonance\Configs";
            if (OFD.ShowDialog() == V.DROK)
            {
                try
                {
                    String ID = ControlID(O); Button B = (Button)O;
                    AIConfigs[ID] = new AIConfig(OFD.FileName);
                    B.Text = AIConfigs[ID].Name;
                    B.ForeColor = AIConfigs[ID].Enabled ? Color.Red : Color.Black;
                    B.BackColor = AIConfigs[ID].Enabled ? Color.Yellow : Color.LightSteelBlue;
                }
                catch (Exception EX)
                { MessageBox.Show($"{EX.Message}\r\n{EX.StackTrace}", "[AIConfig] Error!", V.MBBO, V.MBIE); }
            }
        }
        private Dictionary<String, RichTextBox> TOutputs = [];
        private void InitializeTOutputs() => TOutputs = new()
        { { "0", TOutput0 },{ "1", TOutput1 }, { "2", TOutput2 } };

        private Dictionary<String, Task> Tasks = [];
        private void InitializeTasks() => Tasks = new()
        {{ "0", Completion.Empty() }, {"1", Completion.Empty() }, { "2", Completion.Empty() }};

        private Dictionary<String, ProgressBar> POutputs = [];
        private void InitializePOutputs() => POutputs = new()
        { { "0", POutput0 },{ "1", POutput1 }, { "2", POutput2 } };

        private Dictionary<String, Button> BContents = [];
        private void InitializeBContents() => BContents = new()
        { { "0", BContent0 },{ "1", BContent1 }, { "2", BContent2 } };

        private Boolean CompareOutput()
        {
            String T0 = TOutput0.Text.Trim();
            String T1 = TOutput1.Text.Trim();
            String T2 = TOutput2.Text.Trim();
            return T0 != T1 && T1 != T2 && T2 != T0;
        }
        private async void BCompletion_Click(Object O, EventArgs E)
        {
            if (CompareOutput())
            {
                MessageBox.Show("Contents via Output Box is Difference!", "Contents Error!", V.MBBO, V.MBIE);
                return;
            }

            String Inputs = TInput.Text.Trim();
            if (V.SNS(Inputs)) return;
            ((Button)O).Enabled = false;

            foreach (KeyValuePair<String, AIConfig> AI in AIConfigs)
            {
                POutputs[AI.Key].Visible = AI.Value.Enabled;
                if (!AI.Value.Enabled) Tasks[AI.Key] = Completion.Empty();
                else Tasks[AI.Key] = Completion.Execute(AI.Value, TOutputs[AI.Key], Inputs, POutputs[AI.Key]);
            }
            await Task.WhenAll(Tasks.Values!);
            if (TFocus != null && TFocus.Name.StartsWith("TOutput")) UpdateView(TFocus.Text);
            ((Button)O).Enabled = true;
        }
        private Boolean ShowRole = false;
        private String CacheInput = V.SEP;
        private void BInputRole_Click(Object O, EventArgs E)
        {
            if (ShowRole)
            {
                Completion.Role = TInput.Text;
                MessageBox.Show(Completion.Role, "Role Configured!", V.MBBO, V.MBII);
                TInput.Text = CacheInput;
                ((Button)O).BackColor = Color.Ivory;
            }
            else
            {
                CacheInput = TInput.Text;
                TInput.Text = Completion.Role;
                ((Button)O).BackColor = Color.Red;
            }

            ShowRole = !ShowRole;
        }

        private void BContent_Click(Object O, EventArgs E)
        {
            String ID = ControlID(O);
            foreach (KeyValuePair<String, Button> B in BContents)
            {
                if (B.Key == ID) continue;
                else TOutputs[B.Key].Text = TOutputs[ID].Text;
            }
        }
    }
}


