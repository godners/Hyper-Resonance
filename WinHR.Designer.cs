namespace HyRsn
{
    internal partial class WinHR : Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WinHR));
            TlpMain = new TableLayoutPanel();
            TlpR0 = new TableLayoutPanel();
            TInput = new RichTextBox();
            TlpR0C1 = new TableLayoutPanel();
            LInputCount = new Label();
            LInputInfo = new Label();
            BInputLint = new Button();
            PicLogo = new PictureBox();
            TlpR2 = new TableLayoutPanel();
            TOutput2 = new RichTextBox();
            TOutput1 = new RichTextBox();
            MDView = new Microsoft.Web.WebView2.WinForms.WebView2();
            TOutput0 = new RichTextBox();
            TlpMain.SuspendLayout();
            TlpR0.SuspendLayout();
            TlpR0C1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PicLogo).BeginInit();
            TlpR2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)MDView).BeginInit();
            SuspendLayout();
            // 
            // TlpMain
            // 
            TlpMain.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            TlpMain.ColumnCount = 1;
            TlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            TlpMain.Controls.Add(TlpR0, 0, 0);
            TlpMain.Controls.Add(TlpR2, 0, 2);
            TlpMain.Dock = DockStyle.Fill;
            TlpMain.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            TlpMain.Location = new Point(0, 0);
            TlpMain.Margin = new Padding(0);
            TlpMain.Name = "TlpMain";
            TlpMain.RowCount = 3;
            TlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            TlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            TlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));
            TlpMain.Size = new Size(1584, 861);
            TlpMain.TabIndex = 0;
            // 
            // TlpR0
            // 
            TlpR0.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            TlpR0.ColumnCount = 3;
            TlpR0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            TlpR0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            TlpR0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            TlpR0.Controls.Add(TInput, 1, 0);
            TlpR0.Controls.Add(TlpR0C1, 2, 0);
            TlpR0.Controls.Add(PicLogo, 0, 0);
            TlpR0.Dock = DockStyle.Fill;
            TlpR0.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            TlpR0.Location = new Point(1, 1);
            TlpR0.Margin = new Padding(0);
            TlpR0.Name = "TlpR0";
            TlpR0.RowCount = 1;
            TlpR0.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            TlpR0.Size = new Size(1582, 214);
            TlpR0.TabIndex = 0;
            // 
            // TInput
            // 
            TInput.AcceptsTab = true;
            TInput.BorderStyle = BorderStyle.FixedSingle;
            TInput.BulletIndent = 4;
            TInput.DetectUrls = false;
            TInput.Dock = DockStyle.Fill;
            TInput.Location = new Point(400, 5);
            TInput.Margin = new Padding(4);
            TInput.Name = "TInput";
            TInput.ScrollBars = RichTextBoxScrollBars.ForcedVertical;
            TInput.Size = new Size(938, 204);
            TInput.TabIndex = 0;
            TInput.Text = "";
            TInput.TextChanged += TInput_TextChanged;
            TInput.Enter += T_Enter;
            // 
            // TlpR0C1
            // 
            TlpR0C1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            TlpR0C1.ColumnCount = 2;
            TlpR0C1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            TlpR0C1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            TlpR0C1.Controls.Add(LInputCount, 0, 1);
            TlpR0C1.Controls.Add(LInputInfo, 0, 0);
            TlpR0C1.Controls.Add(BInputLint, 1, 1);
            TlpR0C1.Dock = DockStyle.Fill;
            TlpR0C1.Location = new Point(1343, 1);
            TlpR0C1.Margin = new Padding(0);
            TlpR0C1.Name = "TlpR0C1";
            TlpR0C1.RowCount = 6;
            TlpR0C1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            TlpR0C1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            TlpR0C1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            TlpR0C1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            TlpR0C1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            TlpR0C1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            TlpR0C1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            TlpR0C1.Size = new Size(238, 212);
            TlpR0C1.TabIndex = 1;
            // 
            // LInputCount
            // 
            LInputCount.Dock = DockStyle.Fill;
            LInputCount.Location = new Point(1, 22);
            LInputCount.Margin = new Padding(0);
            LInputCount.Name = "LInputCount";
            LInputCount.Size = new Size(117, 41);
            LInputCount.TabIndex = 2;
            LInputCount.Text = "Lines: 0\r\nChars: 0";
            LInputCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LInputInfo
            // 
            TlpR0C1.SetColumnSpan(LInputInfo, 2);
            LInputInfo.Dock = DockStyle.Fill;
            LInputInfo.Location = new Point(1, 1);
            LInputInfo.Margin = new Padding(0);
            LInputInfo.Name = "LInputInfo";
            LInputInfo.Size = new Size(236, 20);
            LInputInfo.TabIndex = 1;
            LInputInfo.Text = "Input Information:";
            LInputInfo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // BInputLint
            // 
            BInputLint.Dock = DockStyle.Fill;
            BInputLint.Location = new Point(123, 26);
            BInputLint.Margin = new Padding(4);
            BInputLint.Name = "BInputLint";
            BInputLint.Size = new Size(110, 33);
            BInputLint.TabIndex = 3;
            BInputLint.Text = "Lint Inputs";
            BInputLint.UseVisualStyleBackColor = true;
            BInputLint.Click += BInputLint_Click;
            // 
            // PicLogo
            // 
            PicLogo.Dock = DockStyle.Fill;
            PicLogo.Image = Properties.Resources.Hyper_Resonance;
            PicLogo.Location = new Point(5, 5);
            PicLogo.Margin = new Padding(4);
            PicLogo.Name = "PicLogo";
            PicLogo.Size = new Size(386, 204);
            PicLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            PicLogo.TabIndex = 2;
            PicLogo.TabStop = false;
            // 
            // TlpR2
            // 
            TlpR2.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            TlpR2.ColumnCount = 4;
            TlpR2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            TlpR2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            TlpR2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            TlpR2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            TlpR2.Controls.Add(TOutput2, 2, 0);
            TlpR2.Controls.Add(TOutput1, 1, 0);
            TlpR2.Controls.Add(MDView, 3, 0);
            TlpR2.Controls.Add(TOutput0, 0, 0);
            TlpR2.Dock = DockStyle.Fill;
            TlpR2.Location = new Point(1, 259);
            TlpR2.Margin = new Padding(0);
            TlpR2.Name = "TlpR2";
            TlpR2.RowCount = 1;
            TlpR2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            TlpR2.Size = new Size(1582, 601);
            TlpR2.TabIndex = 1;
            // 
            // TOutput2
            // 
            TOutput2.AcceptsTab = true;
            TOutput2.BorderStyle = BorderStyle.FixedSingle;
            TOutput2.BulletIndent = 4;
            TOutput2.DetectUrls = false;
            TOutput2.Dock = DockStyle.Fill;
            TOutput2.Location = new Point(637, 5);
            TOutput2.Margin = new Padding(4);
            TOutput2.Name = "TOutput2";
            TOutput2.ScrollBars = RichTextBoxScrollBars.ForcedVertical;
            TOutput2.Size = new Size(307, 591);
            TOutput2.TabIndex = 3;
            TOutput2.Text = "";
            TOutput2.TextChanged += T_TextChanged;
            TOutput2.Enter += T_Enter;
            // 
            // TOutput1
            // 
            TOutput1.AcceptsTab = true;
            TOutput1.BorderStyle = BorderStyle.FixedSingle;
            TOutput1.BulletIndent = 4;
            TOutput1.DetectUrls = false;
            TOutput1.Dock = DockStyle.Fill;
            TOutput1.Location = new Point(321, 5);
            TOutput1.Margin = new Padding(4);
            TOutput1.Name = "TOutput1";
            TOutput1.ScrollBars = RichTextBoxScrollBars.ForcedVertical;
            TOutput1.Size = new Size(307, 591);
            TOutput1.TabIndex = 2;
            TOutput1.Text = "";
            TOutput1.TextChanged += T_TextChanged;
            TOutput1.Enter += T_Enter;
            // 
            // MDView
            // 
            MDView.AllowExternalDrop = true;
            MDView.CreationProperties = null;
            MDView.DefaultBackgroundColor = Color.White;
            MDView.Dock = DockStyle.Fill;
            MDView.Location = new Point(949, 1);
            MDView.Margin = new Padding(0);
            MDView.Name = "MDView";
            MDView.Size = new Size(632, 599);
            MDView.TabIndex = 0;
            MDView.ZoomFactor = 1D;
            // 
            // TOutput0
            // 
            TOutput0.AcceptsTab = true;
            TOutput0.BorderStyle = BorderStyle.FixedSingle;
            TOutput0.BulletIndent = 4;
            TOutput0.DetectUrls = false;
            TOutput0.Dock = DockStyle.Fill;
            TOutput0.Location = new Point(5, 5);
            TOutput0.Margin = new Padding(4);
            TOutput0.Name = "TOutput0";
            TOutput0.ScrollBars = RichTextBoxScrollBars.ForcedVertical;
            TOutput0.Size = new Size(307, 591);
            TOutput0.TabIndex = 1;
            TOutput0.Text = "";
            TOutput0.TextChanged += T_TextChanged;
            TOutput0.Enter += T_Enter;
            // 
            // WinHR
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoValidate = AutoValidate.Disable;
            CausesValidation = false;
            ClientSize = new Size(1584, 861);
            Controls.Add(TlpMain);
            DoubleBuffered = true;
            Font = new Font("仿宋", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "WinHR";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hyper-Resonance";
            TlpMain.ResumeLayout(false);
            TlpR0.ResumeLayout(false);
            TlpR0C1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PicLogo).EndInit();
            TlpR2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)MDView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel TlpMain;
        private TableLayoutPanel TlpR0;
        private TableLayoutPanel TlpR2;
        private RichTextBox TInput;
        private Label LInputInfo;
        private TableLayoutPanel TlpR0C1;
        private Label LInputCount;
        private PictureBox PicLogo;
        private Button BInputLint;
        private Microsoft.Web.WebView2.WinForms.WebView2 MDView;
        private RichTextBox TOutput2;
        private RichTextBox TOutput1;
        private RichTextBox TOutput0;
    }
}
