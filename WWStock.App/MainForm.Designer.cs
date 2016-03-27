namespace WWStock.App
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lsvStockList = new WWStock.App.DoubleBufferListView();
            this.Code = new System.Windows.Forms.ColumnHeader();
            this.StockName = new System.Windows.Forms.ColumnHeader();
            this.ChangeRate = new System.Windows.Forms.ColumnHeader();
            this.Price = new System.Windows.Forms.ColumnHeader();
            this.Last = new System.Windows.Forms.ColumnHeader();
            this.Open = new System.Windows.Forms.ColumnHeader();
            this.High = new System.Windows.Forms.ColumnHeader();
            this.Low = new System.Windows.Forms.ColumnHeader();
            this.Amount = new System.Windows.Forms.ColumnHeader();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.wChartUS1 = new WWStock.UI.WChartUS();
            this.wChartUS2 = new WWStock.UI.WChartUS();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnStopRecieve = new System.Windows.Forms.Button();
            this.btnAutoRecieve = new System.Windows.Forms.Button();
            this.btnStockSH = new System.Windows.Forms.Button();
            this.btnStockSZ = new System.Windows.Forms.Button();
            this.btnSetup = new System.Windows.Forms.Button();
            this.btnWChart = new System.Windows.Forms.Button();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssListView = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssSHIndexLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssSHIndex = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssSZIndexLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssSZIndex = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssDateTimelabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssDateTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.btnStockUser = new System.Windows.Forms.Button();
            this.btnAlert = new System.Windows.Forms.Button();
            this.bgwListView = new System.ComponentModel.BackgroundWorker();
            this.bgwAutoRefresh = new System.ComponentModel.BackgroundWorker();
            this.tmrStatusBar = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.menuStripMain.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 580F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1266, 831);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.lsvStockList, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 825F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(680, 825);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // lsvStockList
            // 
            this.lsvStockList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvStockList.BackColor = System.Drawing.Color.Black;
            this.lsvStockList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Code,
            this.StockName,
            this.ChangeRate,
            this.Price,
            this.Last,
            this.Open,
            this.High,
            this.Low,
            this.Amount});
            this.lsvStockList.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsvStockList.FullRowSelect = true;
            this.lsvStockList.Location = new System.Drawing.Point(3, 3);
            this.lsvStockList.Name = "lsvStockList";
            this.lsvStockList.Size = new System.Drawing.Size(674, 819);
            this.lsvStockList.TabIndex = 1;
            this.lsvStockList.UseCompatibleStateImageBehavior = false;
            this.lsvStockList.View = System.Windows.Forms.View.Details;
            this.lsvStockList.DoubleClick += new System.EventHandler(this.lsvStockList_DoubleClick);
            // 
            // Code
            // 
            this.Code.Text = "代码";
            this.Code.Width = 70;
            // 
            // StockName
            // 
            this.StockName.Text = "名称";
            this.StockName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.StockName.Width = 65;
            // 
            // ChangeRate
            // 
            this.ChangeRate.Text = "涨跌幅";
            this.ChangeRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Price
            // 
            this.Price.Text = "当前";
            this.Price.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Price.Width = 70;
            // 
            // Last
            // 
            this.Last.Text = "昨收";
            this.Last.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Last.Width = 70;
            // 
            // Open
            // 
            this.Open.Text = "今开";
            this.Open.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Open.Width = 70;
            // 
            // High
            // 
            this.High.Text = "最高";
            this.High.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.High.Width = 70;
            // 
            // Low
            // 
            this.Low.Text = "最低";
            this.Low.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Low.Width = 70;
            // 
            // Amount
            // 
            this.Amount.Text = "成交额（元）";
            this.Amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Amount.Width = 100;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.wChartUS1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.wChartUS2, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(689, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(574, 825);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // wChartUS1
            // 
            this.wChartUS1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.wChartUS1.BackColor = System.Drawing.Color.Black;
            this.wChartUS1.Location = new System.Drawing.Point(4, 3);
            this.wChartUS1.Name = "wChartUS1";
            this.wChartUS1.Size = new System.Drawing.Size(565, 405);
            this.wChartUS1.TabIndex = 0;
            // 
            // wChartUS2
            // 
            this.wChartUS2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.wChartUS2.BackColor = System.Drawing.Color.Black;
            this.wChartUS2.Location = new System.Drawing.Point(4, 416);
            this.wChartUS2.Name = "wChartUS2";
            this.wChartUS2.Size = new System.Drawing.Size(565, 405);
            this.wChartUS2.TabIndex = 1;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnExit.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(1187, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(68, 23);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMoveDown.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveDown.Location = new System.Drawing.Point(731, 3);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(68, 23);
            this.btnMoveDown.TabIndex = 7;
            this.btnMoveDown.Text = "下移";
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMoveUp.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveUp.Location = new System.Drawing.Point(641, 3);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(68, 23);
            this.btnMoveUp.TabIndex = 6;
            this.btnMoveUp.Text = "上移";
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRemove.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.Location = new System.Drawing.Point(551, 3);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(68, 23);
            this.btnRemove.TabIndex = 5;
            this.btnRemove.Text = "删除";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(461, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(68, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnStopRecieve
            // 
            this.btnStopRecieve.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStopRecieve.Enabled = false;
            this.btnStopRecieve.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStopRecieve.Location = new System.Drawing.Point(371, 3);
            this.btnStopRecieve.Name = "btnStopRecieve";
            this.btnStopRecieve.Size = new System.Drawing.Size(68, 23);
            this.btnStopRecieve.TabIndex = 3;
            this.btnStopRecieve.Text = "停止接收";
            this.btnStopRecieve.UseVisualStyleBackColor = true;
            this.btnStopRecieve.Click += new System.EventHandler(this.btnStopRecieve_Click);
            // 
            // btnAutoRecieve
            // 
            this.btnAutoRecieve.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAutoRecieve.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutoRecieve.Location = new System.Drawing.Point(281, 3);
            this.btnAutoRecieve.Name = "btnAutoRecieve";
            this.btnAutoRecieve.Size = new System.Drawing.Size(68, 23);
            this.btnAutoRecieve.TabIndex = 2;
            this.btnAutoRecieve.Text = "自动接收";
            this.btnAutoRecieve.UseVisualStyleBackColor = true;
            this.btnAutoRecieve.Click += new System.EventHandler(this.btnAutoRecieve_Click);
            // 
            // btnStockSH
            // 
            this.btnStockSH.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStockSH.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStockSH.Location = new System.Drawing.Point(101, 3);
            this.btnStockSH.Name = "btnStockSH";
            this.btnStockSH.Size = new System.Drawing.Size(68, 23);
            this.btnStockSH.TabIndex = 10;
            this.btnStockSH.Text = "上证股票";
            this.btnStockSH.UseVisualStyleBackColor = true;
            this.btnStockSH.Click += new System.EventHandler(this.btnStockSH_Click);
            // 
            // btnStockSZ
            // 
            this.btnStockSZ.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStockSZ.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStockSZ.Location = new System.Drawing.Point(191, 3);
            this.btnStockSZ.Name = "btnStockSZ";
            this.btnStockSZ.Size = new System.Drawing.Size(68, 23);
            this.btnStockSZ.TabIndex = 11;
            this.btnStockSZ.Text = "深证股票";
            this.btnStockSZ.UseVisualStyleBackColor = true;
            this.btnStockSZ.Click += new System.EventHandler(this.btnStockSZ_Click);
            // 
            // btnSetup
            // 
            this.btnSetup.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSetup.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetup.Location = new System.Drawing.Point(911, 3);
            this.btnSetup.Name = "btnSetup";
            this.btnSetup.Size = new System.Drawing.Size(68, 23);
            this.btnSetup.TabIndex = 8;
            this.btnSetup.Text = "设置...";
            this.btnSetup.UseVisualStyleBackColor = true;
            this.btnSetup.Click += new System.EventHandler(this.btnSetup_Click);
            // 
            // btnWChart
            // 
            this.btnWChart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnWChart.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWChart.Location = new System.Drawing.Point(821, 3);
            this.btnWChart.Name = "btnWChart";
            this.btnWChart.Size = new System.Drawing.Size(68, 23);
            this.btnWChart.TabIndex = 9;
            this.btnWChart.Text = "分时图...";
            this.btnWChart.UseVisualStyleBackColor = true;
            this.btnWChart.Click += new System.EventHandler(this.btnWChart_Click);
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(1272, 25);
            this.menuStripMain.TabIndex = 1;
            this.menuStripMain.Text = "File";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 21);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.statusStrip1, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel5, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1272, 897);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssListView,
            this.tssSHIndexLabel,
            this.tssSHIndex,
            this.tssSZIndexLabel,
            this.tssSZIndex,
            this.tssDateTimelabel,
            this.tssDateTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 875);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1272, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssListView
            // 
            this.tssListView.AutoSize = false;
            this.tssListView.Name = "tssListView";
            this.tssListView.Size = new System.Drawing.Size(120, 17);
            this.tssListView.Text = "Ready";
            this.tssListView.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tssSHIndexLabel
            // 
            this.tssSHIndexLabel.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tssSHIndexLabel.Name = "tssSHIndexLabel";
            this.tssSHIndexLabel.Size = new System.Drawing.Size(68, 17);
            this.tssSHIndexLabel.Text = "上证指数：";
            this.tssSHIndexLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tssSHIndex
            // 
            this.tssSHIndex.AutoSize = false;
            this.tssSHIndex.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tssSHIndex.Name = "tssSHIndex";
            this.tssSHIndex.Size = new System.Drawing.Size(380, 17);
            this.tssSHIndex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tssSZIndexLabel
            // 
            this.tssSZIndexLabel.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tssSZIndexLabel.Name = "tssSZIndexLabel";
            this.tssSZIndexLabel.Size = new System.Drawing.Size(68, 17);
            this.tssSZIndexLabel.Text = "深证指数：";
            this.tssSZIndexLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tssSZIndex
            // 
            this.tssSZIndex.AutoSize = false;
            this.tssSZIndex.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tssSZIndex.Name = "tssSZIndex";
            this.tssSZIndex.Size = new System.Drawing.Size(380, 17);
            this.tssSZIndex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tssDateTimelabel
            // 
            this.tssDateTimelabel.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tssDateTimelabel.Name = "tssDateTimelabel";
            this.tssDateTimelabel.Size = new System.Drawing.Size(68, 17);
            this.tssDateTimelabel.Text = "日期时间：";
            this.tssDateTimelabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tssDateTime
            // 
            this.tssDateTime.AutoSize = false;
            this.tssDateTime.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tssDateTime.Name = "tssDateTime";
            this.tssDateTime.Size = new System.Drawing.Size(150, 17);
            this.tssDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 14;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel5.Controls.Add(this.btnExit, 13, 0);
            this.tableLayoutPanel5.Controls.Add(this.btnSetup, 10, 0);
            this.tableLayoutPanel5.Controls.Add(this.btnMoveDown, 8, 0);
            this.tableLayoutPanel5.Controls.Add(this.btnWChart, 9, 0);
            this.tableLayoutPanel5.Controls.Add(this.btnStockSH, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.btnMoveUp, 7, 0);
            this.tableLayoutPanel5.Controls.Add(this.btnStockSZ, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.btnRemove, 6, 0);
            this.tableLayoutPanel5.Controls.Add(this.btnAutoRecieve, 3, 0);
            this.tableLayoutPanel5.Controls.Add(this.btnAdd, 5, 0);
            this.tableLayoutPanel5.Controls.Add(this.btnStopRecieve, 4, 0);
            this.tableLayoutPanel5.Controls.Add(this.btnStockUser, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.btnAlert, 11, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 840);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(1266, 29);
            this.tableLayoutPanel5.TabIndex = 2;
            // 
            // btnStockUser
            // 
            this.btnStockUser.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStockUser.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStockUser.Location = new System.Drawing.Point(7, 3);
            this.btnStockUser.Name = "btnStockUser";
            this.btnStockUser.Size = new System.Drawing.Size(75, 23);
            this.btnStockUser.TabIndex = 12;
            this.btnStockUser.Text = "自选股票";
            this.btnStockUser.UseVisualStyleBackColor = true;
            this.btnStockUser.Click += new System.EventHandler(this.btnStockUser_Click);
            // 
            // btnAlert
            // 
            this.btnAlert.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAlert.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlert.Location = new System.Drawing.Point(997, 3);
            this.btnAlert.Name = "btnAlert";
            this.btnAlert.Size = new System.Drawing.Size(75, 23);
            this.btnAlert.TabIndex = 13;
            this.btnAlert.Text = "预警...";
            this.btnAlert.UseVisualStyleBackColor = true;
            this.btnAlert.Click += new System.EventHandler(this.btnAlert_Click);
            // 
            // bgwListView
            // 
            this.bgwListView.WorkerReportsProgress = true;
            this.bgwListView.WorkerSupportsCancellation = true;
            this.bgwListView.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwListView_DoWork);
            this.bgwListView.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwListView_RunWorkerCompleted);
            this.bgwListView.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwListView_ProgressChanged);
            // 
            // bgwAutoRefresh
            // 
            this.bgwAutoRefresh.WorkerReportsProgress = true;
            this.bgwAutoRefresh.WorkerSupportsCancellation = true;
            this.bgwAutoRefresh.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwAutoRefresh_DoWork);
            this.bgwAutoRefresh.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwAutoRefresh_RunWorkerCompleted);
            this.bgwAutoRefresh.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwAutoRefresh_ProgressChanged);
            // 
            // tmrStatusBar
            // 
            this.tmrStatusBar.Enabled = true;
            this.tmrStatusBar.Interval = 200;
            this.tmrStatusBar.Tick += new System.EventHandler(this.tmrStatusBar_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1272, 922);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.menuStripMain);
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WWStock";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ColumnHeader Code;
        private System.Windows.Forms.ColumnHeader StockName;
        private System.Windows.Forms.ColumnHeader ChangeRate;
        private System.Windows.Forms.ColumnHeader Price;
        private System.Windows.Forms.ColumnHeader Last;
        private System.Windows.Forms.ColumnHeader Open;
        private System.Windows.Forms.ColumnHeader High;
        private System.Windows.Forms.ColumnHeader Low;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnAutoRecieve;
        private System.Windows.Forms.Button btnStopRecieve;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Button btnSetup;
        private System.Windows.Forms.Button btnWChart;
        private System.Windows.Forms.ColumnHeader Amount;
        private System.Windows.Forms.Button btnStockSH;
        private System.Windows.Forms.Button btnStockSZ;
        private System.Windows.Forms.ToolStripStatusLabel tssListView;
        private System.ComponentModel.BackgroundWorker bgwListView;
        private System.ComponentModel.BackgroundWorker bgwAutoRefresh;
        private DoubleBufferListView lsvStockList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private WWStock.UI.WChartUS wChartUS1;
        private WWStock.UI.WChartUS wChartUS2;
        private System.Windows.Forms.Button btnStockUser;
        private System.Windows.Forms.ToolStripStatusLabel tssSHIndexLabel;
        private System.Windows.Forms.ToolStripStatusLabel tssSHIndex;
        private System.Windows.Forms.ToolStripStatusLabel tssSZIndexLabel;
        private System.Windows.Forms.ToolStripStatusLabel tssSZIndex;
        private System.Windows.Forms.ToolStripStatusLabel tssDateTimelabel;
        private System.Windows.Forms.ToolStripStatusLabel tssDateTime;
        private System.Windows.Forms.Timer tmrStatusBar;
        private System.Windows.Forms.Button btnAlert;
    }
}