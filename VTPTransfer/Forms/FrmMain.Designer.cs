namespace VTPTransfer.Forms
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            TopPanel = new Krypton.Toolkit.KryptonPanel();
            kryptonTableLayoutPanel1 = new Krypton.Toolkit.KryptonTableLayoutPanel();
            StartBtn = new Krypton.Toolkit.KryptonButton();
            DisconnectBtn = new Krypton.Toolkit.KryptonButton();
            ConnectBtn = new Krypton.Toolkit.KryptonButton();
            ResetBtn = new Krypton.Toolkit.KryptonButton();
            kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            AmountInput = new Krypton.Toolkit.KryptonNumericUpDown();
            ReceiverTextBox = new Krypton.Toolkit.KryptonTextBox();
            MaxCheckBox = new Krypton.Toolkit.KryptonCheckBox();
            MaxNotEnoughCheckBox = new Krypton.Toolkit.KryptonCheckBox();
            kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            PasswordTextBox = new Krypton.Toolkit.KryptonTextBox();
            TransferBtn = new Krypton.Toolkit.KryptonButton();
            ProxyInputBtn = new Krypton.Toolkit.KryptonButton();
            StopBtn = new Krypton.Toolkit.KryptonButton();
            ProxyCountTextBox = new Krypton.Toolkit.KryptonTextBox();
            kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            ThreadInput = new Krypton.Toolkit.KryptonNumericUpDown();
            BotPanel = new Krypton.Toolkit.KryptonPanel();
            GSMGridView = new Krypton.Toolkit.KryptonDataGridView();
            ComName = new Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            PhoneNumber = new Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            SimType = new Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            AccountNumber = new Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            AccountOwner = new Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            AccountBalance = new Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            PortStatus = new Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            ((System.ComponentModel.ISupportInitialize)TopPanel).BeginInit();
            TopPanel.SuspendLayout();
            kryptonTableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)BotPanel).BeginInit();
            BotPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)GSMGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)kryptonPanel1).BeginInit();
            kryptonPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // TopPanel
            // 
            TopPanel.Controls.Add(kryptonTableLayoutPanel1);
            TopPanel.Dock = DockStyle.Top;
            TopPanel.Location = new Point(0, 0);
            TopPanel.Margin = new Padding(0);
            TopPanel.Name = "TopPanel";
            TopPanel.Size = new Size(1132, 56);
            TopPanel.TabIndex = 0;
            // 
            // kryptonTableLayoutPanel1
            // 
            kryptonTableLayoutPanel1.BackgroundImage = (Image)resources.GetObject("kryptonTableLayoutPanel1.BackgroundImage");
            kryptonTableLayoutPanel1.BackgroundImageLayout = ImageLayout.None;
            kryptonTableLayoutPanel1.ColumnCount = 11;
            kryptonTableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            kryptonTableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            kryptonTableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            kryptonTableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            kryptonTableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            kryptonTableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            kryptonTableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            kryptonTableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            kryptonTableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            kryptonTableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            kryptonTableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            kryptonTableLayoutPanel1.Controls.Add(StartBtn, 0, 0);
            kryptonTableLayoutPanel1.Controls.Add(DisconnectBtn, 2, 1);
            kryptonTableLayoutPanel1.Controls.Add(ConnectBtn, 0, 1);
            kryptonTableLayoutPanel1.Controls.Add(ResetBtn, 1, 1);
            kryptonTableLayoutPanel1.Controls.Add(kryptonLabel2, 5, 1);
            kryptonTableLayoutPanel1.Controls.Add(kryptonLabel3, 5, 0);
            kryptonTableLayoutPanel1.Controls.Add(AmountInput, 6, 1);
            kryptonTableLayoutPanel1.Controls.Add(ReceiverTextBox, 6, 0);
            kryptonTableLayoutPanel1.Controls.Add(MaxCheckBox, 7, 0);
            kryptonTableLayoutPanel1.Controls.Add(MaxNotEnoughCheckBox, 7, 1);
            kryptonTableLayoutPanel1.Controls.Add(kryptonLabel4, 8, 0);
            kryptonTableLayoutPanel1.Controls.Add(PasswordTextBox, 9, 0);
            kryptonTableLayoutPanel1.Controls.Add(TransferBtn, 1, 0);
            kryptonTableLayoutPanel1.Controls.Add(ProxyInputBtn, 3, 0);
            kryptonTableLayoutPanel1.Controls.Add(StopBtn, 2, 0);
            kryptonTableLayoutPanel1.Controls.Add(ProxyCountTextBox, 4, 0);
            kryptonTableLayoutPanel1.Controls.Add(kryptonLabel1, 3, 1);
            kryptonTableLayoutPanel1.Controls.Add(ThreadInput, 4, 1);
            kryptonTableLayoutPanel1.Dock = DockStyle.Fill;
            kryptonTableLayoutPanel1.Location = new Point(0, 0);
            kryptonTableLayoutPanel1.Margin = new Padding(0);
            kryptonTableLayoutPanel1.Name = "kryptonTableLayoutPanel1";
            kryptonTableLayoutPanel1.RowCount = 2;
            kryptonTableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            kryptonTableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            kryptonTableLayoutPanel1.Size = new Size(1132, 56);
            kryptonTableLayoutPanel1.StateCommon.Color1 = Color.FromArgb(30, 30, 30);
            kryptonTableLayoutPanel1.StateCommon.Color2 = Color.FromArgb(30, 30, 30);
            kryptonTableLayoutPanel1.TabIndex = 2;
            // 
            // StartBtn
            // 
            StartBtn.CornerRoundingRadius = -1F;
            StartBtn.Dock = DockStyle.Fill;
            StartBtn.Location = new Point(1, 1);
            StartBtn.Margin = new Padding(1);
            StartBtn.Name = "StartBtn";
            StartBtn.Size = new Size(98, 26);
            StartBtn.StateCommon.Back.Color1 = Color.FromArgb(0, 60, 0);
            StartBtn.StateCommon.Back.Color2 = Color.FromArgb(0, 60, 0);
            StartBtn.StateCommon.Content.ShortText.Color1 = Color.FromArgb(224, 224, 224);
            StartBtn.StateCommon.Content.ShortText.Color2 = Color.FromArgb(224, 224, 224);
            StartBtn.StateCommon.Content.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            StartBtn.TabIndex = 0;
            StartBtn.Values.Text = "Đăng nhập";
            StartBtn.MouseUp += StartBtn_MouseUp;
            // 
            // DisconnectBtn
            // 
            DisconnectBtn.CornerRoundingRadius = -1F;
            DisconnectBtn.Dock = DockStyle.Fill;
            DisconnectBtn.Location = new Point(201, 29);
            DisconnectBtn.Margin = new Padding(1);
            DisconnectBtn.Name = "DisconnectBtn";
            DisconnectBtn.Size = new Size(98, 26);
            DisconnectBtn.StateCommon.Back.Color1 = Color.Maroon;
            DisconnectBtn.StateCommon.Back.Color2 = Color.Maroon;
            DisconnectBtn.StateCommon.Content.ShortText.Color1 = Color.FromArgb(224, 224, 224);
            DisconnectBtn.StateCommon.Content.ShortText.Color2 = Color.FromArgb(224, 224, 224);
            DisconnectBtn.StateCommon.Content.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            DisconnectBtn.TabIndex = 3;
            DisconnectBtn.Values.Text = "Ngắt kết nối";
            DisconnectBtn.MouseUp += DisconnectBtn_MouseUp;
            // 
            // ConnectBtn
            // 
            ConnectBtn.CornerRoundingRadius = -1F;
            ConnectBtn.Dock = DockStyle.Fill;
            ConnectBtn.Location = new Point(1, 29);
            ConnectBtn.Margin = new Padding(1);
            ConnectBtn.Name = "ConnectBtn";
            ConnectBtn.Size = new Size(98, 26);
            ConnectBtn.StateCommon.Back.Color1 = Color.FromArgb(0, 60, 0);
            ConnectBtn.StateCommon.Back.Color2 = Color.FromArgb(0, 60, 0);
            ConnectBtn.StateCommon.Content.ShortText.Color1 = Color.FromArgb(224, 224, 224);
            ConnectBtn.StateCommon.Content.ShortText.Color2 = Color.FromArgb(224, 224, 224);
            ConnectBtn.StateCommon.Content.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            ConnectBtn.TabIndex = 5;
            ConnectBtn.Values.Text = "Kết nối";
            ConnectBtn.MouseUp += ConnectBtn_MouseUp;
            // 
            // ResetBtn
            // 
            ResetBtn.CornerRoundingRadius = -1F;
            ResetBtn.Dock = DockStyle.Fill;
            ResetBtn.Location = new Point(101, 29);
            ResetBtn.Margin = new Padding(1);
            ResetBtn.Name = "ResetBtn";
            ResetBtn.Size = new Size(98, 26);
            ResetBtn.StateCommon.Back.Color1 = Color.FromArgb(10, 50, 50);
            ResetBtn.StateCommon.Back.Color2 = Color.FromArgb(10, 50, 50);
            ResetBtn.StateCommon.Content.ShortText.Color1 = Color.FromArgb(224, 224, 224);
            ResetBtn.StateCommon.Content.ShortText.Color2 = Color.FromArgb(224, 224, 224);
            ResetBtn.StateCommon.Content.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            ResetBtn.TabIndex = 4;
            ResetBtn.Values.Text = "Reset cổng";
            ResetBtn.MouseUp += ResetBtn_MouseUp;
            // 
            // kryptonLabel2
            // 
            kryptonLabel2.Dock = DockStyle.Fill;
            kryptonLabel2.Location = new Point(503, 31);
            kryptonLabel2.Name = "kryptonLabel2";
            kryptonLabel2.Size = new Size(94, 22);
            kryptonLabel2.StateCommon.ShortText.Color1 = Color.FromArgb(224, 224, 224);
            kryptonLabel2.StateCommon.ShortText.Color2 = Color.FromArgb(224, 224, 224);
            kryptonLabel2.StateCommon.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            kryptonLabel2.TabIndex = 14;
            kryptonLabel2.Values.Text = "Số tiền:";
            // 
            // kryptonLabel3
            // 
            kryptonLabel3.Dock = DockStyle.Fill;
            kryptonLabel3.Location = new Point(503, 3);
            kryptonLabel3.Name = "kryptonLabel3";
            kryptonLabel3.Size = new Size(94, 22);
            kryptonLabel3.StateCommon.ShortText.Color1 = Color.FromArgb(224, 224, 224);
            kryptonLabel3.StateCommon.ShortText.Color2 = Color.FromArgb(224, 224, 224);
            kryptonLabel3.StateCommon.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            kryptonLabel3.TabIndex = 15;
            kryptonLabel3.Values.Text = "TK nhận:";
            // 
            // AmountInput
            // 
            AmountInput.Dock = DockStyle.Fill;
            AmountInput.Location = new Point(603, 31);
            AmountInput.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            AmountInput.Minimum = new decimal(new int[] { 1000, 0, 0, 0 });
            AmountInput.Name = "AmountInput";
            AmountInput.Size = new Size(144, 22);
            AmountInput.StateCommon.Back.Color1 = Color.Green;
            AmountInput.StateCommon.Content.Color1 = Color.White;
            AmountInput.StateCommon.Content.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            AmountInput.StateDisabled.Back.Color1 = Color.White;
            AmountInput.TabIndex = 16;
            AmountInput.ThousandsSeparator = true;
            AmountInput.Value = new decimal(new int[] { 1000, 0, 0, 0 });
            // 
            // ReceiverTextBox
            // 
            ReceiverTextBox.Dock = DockStyle.Fill;
            ReceiverTextBox.Location = new Point(603, 3);
            ReceiverTextBox.Name = "ReceiverTextBox";
            ReceiverTextBox.Size = new Size(144, 23);
            ReceiverTextBox.StateCommon.Back.Color1 = Color.Green;
            ReceiverTextBox.StateCommon.Content.Color1 = Color.White;
            ReceiverTextBox.StateCommon.Content.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            ReceiverTextBox.TabIndex = 17;
            // 
            // MaxCheckBox
            // 
            MaxCheckBox.Checked = true;
            MaxCheckBox.CheckState = CheckState.Checked;
            MaxCheckBox.Dock = DockStyle.Fill;
            MaxCheckBox.Location = new Point(753, 3);
            MaxCheckBox.Name = "MaxCheckBox";
            MaxCheckBox.Size = new Size(144, 22);
            MaxCheckBox.StateCommon.ShortText.Color1 = Color.FromArgb(224, 224, 224);
            MaxCheckBox.StateCommon.ShortText.Color2 = Color.FromArgb(224, 224, 224);
            MaxCheckBox.StateCommon.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            MaxCheckBox.TabIndex = 19;
            MaxCheckBox.Values.Text = "Chuyển tối đa";
            MaxCheckBox.CheckedChanged += TransferOption_CheckedChanged;
            // 
            // MaxNotEnoughCheckBox
            // 
            MaxNotEnoughCheckBox.Checked = true;
            MaxNotEnoughCheckBox.CheckState = CheckState.Checked;
            MaxNotEnoughCheckBox.Dock = DockStyle.Fill;
            MaxNotEnoughCheckBox.Location = new Point(753, 31);
            MaxNotEnoughCheckBox.Name = "MaxNotEnoughCheckBox";
            MaxNotEnoughCheckBox.Size = new Size(144, 22);
            MaxNotEnoughCheckBox.StateCommon.ShortText.Color1 = Color.FromArgb(224, 224, 224);
            MaxNotEnoughCheckBox.StateCommon.ShortText.Color2 = Color.FromArgb(224, 224, 224);
            MaxNotEnoughCheckBox.StateCommon.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            MaxNotEnoughCheckBox.TabIndex = 20;
            MaxNotEnoughCheckBox.Values.Text = "Tối đa nếu không đủ";
            MaxNotEnoughCheckBox.CheckedChanged += TransferOption_CheckedChanged;
            // 
            // kryptonLabel4
            // 
            kryptonLabel4.Dock = DockStyle.Fill;
            kryptonLabel4.Location = new Point(903, 3);
            kryptonLabel4.Name = "kryptonLabel4";
            kryptonLabel4.Size = new Size(74, 22);
            kryptonLabel4.StateCommon.ShortText.Color1 = Color.FromArgb(224, 224, 224);
            kryptonLabel4.StateCommon.ShortText.Color2 = Color.FromArgb(224, 224, 224);
            kryptonLabel4.StateCommon.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            kryptonLabel4.TabIndex = 21;
            kryptonLabel4.Values.Text = "Mật khẩu:";
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Dock = DockStyle.Fill;
            PasswordTextBox.Location = new Point(983, 3);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.Size = new Size(144, 23);
            PasswordTextBox.StateCommon.Back.Color1 = Color.Green;
            PasswordTextBox.StateCommon.Content.Color1 = Color.White;
            PasswordTextBox.StateCommon.Content.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            PasswordTextBox.TabIndex = 22;
            // 
            // TransferBtn
            // 
            TransferBtn.CornerRoundingRadius = -1F;
            TransferBtn.Dock = DockStyle.Fill;
            TransferBtn.Location = new Point(101, 1);
            TransferBtn.Margin = new Padding(1);
            TransferBtn.Name = "TransferBtn";
            TransferBtn.Size = new Size(98, 26);
            TransferBtn.StateCommon.Back.Color1 = Color.FromArgb(10, 50, 50);
            TransferBtn.StateCommon.Back.Color2 = Color.FromArgb(10, 50, 50);
            TransferBtn.StateCommon.Content.ShortText.Color1 = Color.FromArgb(224, 224, 224);
            TransferBtn.StateCommon.Content.ShortText.Color2 = Color.FromArgb(224, 224, 224);
            TransferBtn.StateCommon.Content.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            TransferBtn.TabIndex = 23;
            TransferBtn.Values.Text = "Chuyển tiền";
            TransferBtn.Click += TransferBtn_Click;
            // 
            // ProxyInputBtn
            // 
            ProxyInputBtn.CornerRoundingRadius = -1F;
            ProxyInputBtn.Dock = DockStyle.Fill;
            ProxyInputBtn.Location = new Point(301, 1);
            ProxyInputBtn.Margin = new Padding(1);
            ProxyInputBtn.Name = "ProxyInputBtn";
            ProxyInputBtn.Size = new Size(98, 26);
            ProxyInputBtn.StateCommon.Back.Color1 = Color.FromArgb(0, 0, 120);
            ProxyInputBtn.StateCommon.Back.Color2 = Color.FromArgb(0, 0, 120);
            ProxyInputBtn.StateCommon.Content.ShortText.Color1 = Color.FromArgb(224, 224, 224);
            ProxyInputBtn.StateCommon.Content.ShortText.Color2 = Color.FromArgb(224, 224, 224);
            ProxyInputBtn.StateCommon.Content.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            ProxyInputBtn.TabIndex = 2;
            ProxyInputBtn.Values.Text = "Nhập proxy";
            ProxyInputBtn.MouseUp += ProxyInputBtn_MouseUp;
            // 
            // StopBtn
            // 
            StopBtn.CornerRoundingRadius = -1F;
            StopBtn.Dock = DockStyle.Fill;
            StopBtn.Enabled = false;
            StopBtn.Location = new Point(201, 1);
            StopBtn.Margin = new Padding(1);
            StopBtn.Name = "StopBtn";
            StopBtn.Size = new Size(98, 26);
            StopBtn.StateCommon.Back.Color1 = Color.Maroon;
            StopBtn.StateCommon.Back.Color2 = Color.Maroon;
            StopBtn.StateCommon.Content.ShortText.Color1 = Color.FromArgb(224, 224, 224);
            StopBtn.StateCommon.Content.ShortText.Color2 = Color.FromArgb(224, 224, 224);
            StopBtn.StateCommon.Content.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            StopBtn.TabIndex = 1;
            StopBtn.Values.Text = "Dừng lại";
            StopBtn.MouseUp += StopBtn_MouseUp;
            // 
            // ProxyCountTextBox
            // 
            ProxyCountTextBox.Dock = DockStyle.Fill;
            ProxyCountTextBox.Location = new Point(403, 3);
            ProxyCountTextBox.Name = "ProxyCountTextBox";
            ProxyCountTextBox.ReadOnly = true;
            ProxyCountTextBox.Size = new Size(94, 23);
            ProxyCountTextBox.StateCommon.Back.Color1 = Color.Green;
            ProxyCountTextBox.StateCommon.Content.Color1 = Color.White;
            ProxyCountTextBox.StateCommon.Content.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            ProxyCountTextBox.TabIndex = 18;
            ProxyCountTextBox.Text = "0";
            ProxyCountTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // kryptonLabel1
            // 
            kryptonLabel1.Dock = DockStyle.Fill;
            kryptonLabel1.Location = new Point(303, 31);
            kryptonLabel1.Name = "kryptonLabel1";
            kryptonLabel1.Size = new Size(94, 22);
            kryptonLabel1.StateCommon.ShortText.Color1 = Color.FromArgb(224, 224, 224);
            kryptonLabel1.StateCommon.ShortText.Color2 = Color.FromArgb(224, 224, 224);
            kryptonLabel1.StateCommon.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            kryptonLabel1.TabIndex = 8;
            kryptonLabel1.Values.Text = "Số luồng:";
            // 
            // ThreadInput
            // 
            ThreadInput.Dock = DockStyle.Fill;
            ThreadInput.Location = new Point(403, 31);
            ThreadInput.Maximum = new decimal(new int[] { 32, 0, 0, 0 });
            ThreadInput.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            ThreadInput.Name = "ThreadInput";
            ThreadInput.Size = new Size(94, 22);
            ThreadInput.StateCommon.Back.Color1 = Color.Green;
            ThreadInput.StateCommon.Content.Color1 = Color.White;
            ThreadInput.StateCommon.Content.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            ThreadInput.StateDisabled.Back.Color1 = Color.White;
            ThreadInput.TabIndex = 9;
            ThreadInput.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // BotPanel
            // 
            BotPanel.Controls.Add(GSMGridView);
            BotPanel.Dock = DockStyle.Fill;
            BotPanel.Location = new Point(0, 56);
            BotPanel.Margin = new Padding(0);
            BotPanel.Name = "BotPanel";
            BotPanel.Size = new Size(1132, 565);
            BotPanel.TabIndex = 1;
            // 
            // GSMGridView
            // 
            GSMGridView.AllowUserToAddRows = false;
            GSMGridView.AllowUserToDeleteRows = false;
            GSMGridView.AllowUserToOrderColumns = true;
            GSMGridView.AllowUserToResizeRows = false;
            GSMGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            GSMGridView.ColumnHeadersHeight = 40;
            GSMGridView.Columns.AddRange(new DataGridViewColumn[] { ComName, PhoneNumber, SimType, AccountNumber, AccountOwner, AccountBalance, PortStatus });
            GSMGridView.Dock = DockStyle.Fill;
            GSMGridView.Location = new Point(0, 0);
            GSMGridView.Name = "GSMGridView";
            GSMGridView.RowHeadersVisible = false;
            GSMGridView.RowTemplate.Height = 25;
            GSMGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
            GSMGridView.Size = new Size(1132, 565);
            GSMGridView.StateCommon.Background.Color1 = Color.FromArgb(50, 50, 50);
            GSMGridView.StateCommon.BackStyle = Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            GSMGridView.StateCommon.HeaderColumn.Back.Color1 = Color.FromArgb(0, 0, 30);
            GSMGridView.StateCommon.HeaderColumn.Back.Color2 = Color.FromArgb(0, 0, 30);
            GSMGridView.StateCommon.HeaderColumn.Content.Color1 = Color.FromArgb(224, 224, 224);
            GSMGridView.StateCommon.HeaderColumn.Content.Color2 = Color.FromArgb(224, 224, 224);
            GSMGridView.StateCommon.HeaderColumn.Content.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            GSMGridView.TabIndex = 0;
            // 
            // ComName
            // 
            ComName.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            ComName.DataPropertyName = "Name";
            ComName.DefaultCellStyle = dataGridViewCellStyle1;
            ComName.HeaderText = "STT";
            ComName.MinimumWidth = 50;
            ComName.Name = "ComName";
            ComName.ReadOnly = true;
            ComName.Width = 50;
            // 
            // PhoneNumber
            // 
            PhoneNumber.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            PhoneNumber.DataPropertyName = "PhoneNumber";
            PhoneNumber.DefaultCellStyle = dataGridViewCellStyle2;
            PhoneNumber.HeaderText = "Số điện thoại";
            PhoneNumber.MinimumWidth = 100;
            PhoneNumber.Name = "PhoneNumber";
            PhoneNumber.ReadOnly = true;
            PhoneNumber.Width = 100;
            // 
            // SimType
            // 
            SimType.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            SimType.DataPropertyName = "SIMType";
            SimType.DefaultCellStyle = dataGridViewCellStyle3;
            SimType.HeaderText = "Nhà mạng";
            SimType.MinimumWidth = 80;
            SimType.Name = "SimType";
            SimType.ReadOnly = true;
            SimType.Width = 80;
            // 
            // AccountNumber
            // 
            AccountNumber.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            AccountNumber.DataPropertyName = "AccountNumber";
            AccountNumber.DefaultCellStyle = dataGridViewCellStyle4;
            AccountNumber.HeaderText = "Số TK";
            AccountNumber.MinimumWidth = 150;
            AccountNumber.Name = "AccountNumber";
            AccountNumber.ReadOnly = true;
            AccountNumber.Width = 150;
            // 
            // AccountOwner
            // 
            AccountOwner.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            AccountOwner.DataPropertyName = "AccountOwner";
            AccountOwner.DefaultCellStyle = dataGridViewCellStyle5;
            AccountOwner.HeaderText = "Chủ TK";
            AccountOwner.MinimumWidth = 150;
            AccountOwner.Name = "AccountOwner";
            AccountOwner.ReadOnly = true;
            AccountOwner.Width = 150;
            // 
            // AccountBalance
            // 
            AccountBalance.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            AccountBalance.DataPropertyName = "AccountBalance";
            AccountBalance.DefaultCellStyle = dataGridViewCellStyle6;
            AccountBalance.HeaderText = "Số dư";
            AccountBalance.MinimumWidth = 100;
            AccountBalance.Name = "AccountBalance";
            AccountBalance.ReadOnly = true;
            AccountBalance.Width = 100;
            // 
            // PortStatus
            // 
            PortStatus.DataPropertyName = "PortStatus";
            PortStatus.DefaultCellStyle = dataGridViewCellStyle7;
            PortStatus.HeaderText = "Trạng thái";
            PortStatus.Name = "PortStatus";
            PortStatus.ReadOnly = true;
            PortStatus.Width = 501;
            // 
            // kryptonPanel1
            // 
            kryptonPanel1.Controls.Add(BotPanel);
            kryptonPanel1.Controls.Add(TopPanel);
            kryptonPanel1.Dock = DockStyle.Fill;
            kryptonPanel1.Location = new Point(0, 0);
            kryptonPanel1.Name = "kryptonPanel1";
            kryptonPanel1.Size = new Size(1132, 621);
            kryptonPanel1.TabIndex = 3;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(1132, 621);
            Controls.Add(kryptonPanel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(985, 660);
            Name = "FrmMain";
            Text = "Viettel Money Transfer - Tele: @lukaxsx";
            ((System.ComponentModel.ISupportInitialize)TopPanel).EndInit();
            TopPanel.ResumeLayout(false);
            kryptonTableLayoutPanel1.ResumeLayout(false);
            kryptonTableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)BotPanel).EndInit();
            BotPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)GSMGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)kryptonPanel1).EndInit();
            kryptonPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Krypton.Toolkit.KryptonPanel TopPanel;
        private Krypton.Toolkit.KryptonPanel BotPanel;
        private Krypton.Toolkit.KryptonTableLayoutPanel kryptonTableLayoutPanel1;
        private Krypton.Toolkit.KryptonButton ResetBtn;
        private Krypton.Toolkit.KryptonButton DisconnectBtn;
        private Krypton.Toolkit.KryptonButton StopBtn;
        private Krypton.Toolkit.KryptonButton ProxyInputBtn;
        private Krypton.Toolkit.KryptonButton StartBtn;
        private Krypton.Toolkit.KryptonButton ConnectBtn;
        private Krypton.Toolkit.KryptonDataGridView GSMGridView;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.KryptonNumericUpDown ThreadInput;
        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private Krypton.Toolkit.KryptonNumericUpDown AmountInput;
        private Krypton.Toolkit.KryptonTextBox ReceiverTextBox;
        private Krypton.Toolkit.KryptonTextBox ProxyCountTextBox;
        private Krypton.Toolkit.KryptonCheckBox MaxCheckBox;
        private Krypton.Toolkit.KryptonCheckBox MaxNotEnoughCheckBox;
        private Krypton.Toolkit.KryptonDataGridViewTextBoxColumn ComName;
        private Krypton.Toolkit.KryptonDataGridViewTextBoxColumn PhoneNumber;
        private Krypton.Toolkit.KryptonDataGridViewTextBoxColumn SimType;
        private Krypton.Toolkit.KryptonDataGridViewTextBoxColumn AccountNumber;
        private Krypton.Toolkit.KryptonDataGridViewTextBoxColumn AccountOwner;
        private Krypton.Toolkit.KryptonDataGridViewTextBoxColumn AccountBalance;
        private Krypton.Toolkit.KryptonDataGridViewTextBoxColumn PortStatus;
        private Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private Krypton.Toolkit.KryptonTextBox PasswordTextBox;
        private Krypton.Toolkit.KryptonButton TransferBtn;
    }
}