namespace WWStock.App
{
    partial class FloatingBar
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
            this.lblStock = new System.Windows.Forms.Label();
            this.bgwStockLabel = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStock.Location = new System.Drawing.Point(0, 0);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(41, 12);
            this.lblStock.TabIndex = 0;
            this.lblStock.Text = "label1";
            // 
            // bgwStockLabel
            // 
            this.bgwStockLabel.WorkerReportsProgress = true;
            this.bgwStockLabel.WorkerSupportsCancellation = true;
            this.bgwStockLabel.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwStockLabel_DoWork);
            this.bgwStockLabel.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwStockLabel_ProgressChanged);
            this.bgwStockLabel.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwStockLabel_RunWorkerCompleted);
            // 
            // FloatingBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(184, 22);
            this.ControlBox = false;
            this.Controls.Add(this.lblStock);
            this.MaximumSize = new System.Drawing.Size(1900, 38);
            this.MinimumSize = new System.Drawing.Size(200, 38);
            this.Name = "FloatingBar";
            this.Opacity = 0.6D;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FloatingBar_FormClosing);
            this.Load += new System.EventHandler(this.FloatingBar_Load);
            this.DoubleClick += new System.EventHandler(this.FloatingBar_DoubleClick);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FloatingBar_KeyDown);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FloatingBar_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FloatingBar_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FloatingBar_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStock;
        private System.ComponentModel.BackgroundWorker bgwStockLabel;
    }
}