#pragma warning disable IDE1006 // ÃüÃûÑùÊ½
using System.Diagnostics;
using Markdig.Extensions.TaskLists;

namespace HyRsn
{
    internal partial class WinHR : Form
    {
        internal  WinHR()
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

        private void TInput_TextChanged(Object O, EventArgs E)
        {
            LInputCount.Text = Static.CountInput(TInput);
            T_TextChanged(O, E);
        }

        private void BInputLint_Click(Object O, EventArgs E)
        {
            TInput.Text = Static.MDLint(TInput.Text);



        }

        private void T_Enter(Object O, EventArgs E)
        {
            TFocus = (RichTextBox)O; UpdateView(TFocus.Text);
        }

        private void T_TextChanged(Object O, EventArgs E)
        {
            UpdateView(TFocus.Text);
        }
    }
}
