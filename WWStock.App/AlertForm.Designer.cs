namespace WWStock.App
{
    partial class AlertForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lvAlert = new WWStock.App.DoubleBufferListView();
            this.code = new System.Windows.Forms.ColumnHeader();
            this.stockName = new System.Windows.Forms.ColumnHeader();
            this.changeRate = new System.Windows.Forms.ColumnHeader();
            this.price = new System.Windows.Forms.ColumnHeader();
            this.ceiling = new System.Windows.Forms.ColumnHeader();
            this.floor = new System.Windows.Forms.ColumnHeader();
            this.target = new System.Windows.Forms.ColumnHeader();
            this.gap = new System.Windows.Forms.ColumnHeader();
            this.gapRate = new System.Windows.Forms.ColumnHeader();
            this.trend = new System.Windows.Forms.ColumnHeader();
            this.level = new System.Windows.Forms.ColumnHeader();
            this.comments = new System.Windows.Forms.ColumnHeader();
            this.alert = new System.Windows.Forms.ColumnHeader();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.bgwListView = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.Controls.Add(this.lvAlert, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(952, 950);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lvAlert
            // 
            this.lvAlert.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.code,
            this.stockName,
            this.changeRate,
            this.price,
            this.ceiling,
            this.floor,
            this.target,
            this.gap,
            this.gapRate,
            this.trend,
            this.level,
            this.comments,
            this.alert});
            this.lvAlert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvAlert.Font = new System.Drawing.Font("Bitstream Vera Sans Mono", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvAlert.FullRowSelect = true;
            this.lvAlert.HideSelection = false;
            this.lvAlert.Location = new System.Drawing.Point(13, 13);
            this.lvAlert.MultiSelect = false;
            this.lvAlert.Name = "lvAlert";
            this.lvAlert.Size = new System.Drawing.Size(846, 924);
            this.lvAlert.TabIndex = 0;
            this.lvAlert.UseCompatibleStateImageBehavior = false;
            this.lvAlert.View = System.Windows.Forms.View.Details;
            // 
            // code
            // 
            this.code.Text = "代码";
            this.code.Width = 70;
            // 
            // stockName
            // 
            this.stockName.Text = "名称";
            this.stockName.Width = 70;
            // 
            // changeRate
            // 
            this.changeRate.Text = "涨跌幅";
            this.changeRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // price
            // 
            this.price.Text = "价格";
            this.price.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ceiling
            // 
            this.ceiling.Text = "涨停";
            this.ceiling.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // floor
            // 
            this.floor.Text = "跌停";
            this.floor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // target
            // 
            this.target.Text = "目标价";
            this.target.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // gap
            // 
            this.gap.Text = "距离";
            this.gap.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // gapRate
            // 
            this.gapRate.Text = "距离率";
            this.gapRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.gapRate.Width = 80;
            // 
            // trend
            // 
            this.trend.Text = "趋势";
            // 
            // level
            // 
            this.level.Text = "等级";
            // 
            // comments
            // 
            this.comments.Text = "注释";
            // 
            // alert
            // 
            this.alert.Text = "警报";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.btnClose, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.btnStart, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnStop, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(865, 13);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(74, 924);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(3, 897);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(68, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStart.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(3, 8);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(68, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "启动";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStop.Enabled = false;
            this.btnStop.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.Location = new System.Drawing.Point(3, 48);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(68, 23);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // bgwListView
            // 
            this.bgwListView.WorkerReportsProgress = true;
            this.bgwListView.WorkerSupportsCancellation = true;
            this.bgwListView.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwListView_DoWork);
            this.bgwListView.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwListView_RunWorkerCompleted);
            this.bgwListView.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwListView_ProgressChanged);
            // 
            // AlertForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 950);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "AlertForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AlertForm";
            this.Load += new System.EventHandler(this.AlertForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AlertForm_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DoubleBufferListView lvAlert;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ColumnHeader code;
        private System.Windows.Forms.ColumnHeader stockName;
        private System.Windows.Forms.ColumnHeader price;
        private System.Windows.Forms.ColumnHeader changeRate;
        private System.Windows.Forms.ColumnHeader target;
        private System.Windows.Forms.ColumnHeader gap;
        private System.Windows.Forms.ColumnHeader trend;
        private System.Windows.Forms.ColumnHeader level;
        private System.Windows.Forms.ColumnHeader comments;
        private System.Windows.Forms.ColumnHeader alert;
        private System.Windows.Forms.ColumnHeader ceiling;
        private System.Windows.Forms.ColumnHeader floor;
        private System.Windows.Forms.ColumnHeader gapRate;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.ComponentModel.BackgroundWorker bgwListView;
    }
}