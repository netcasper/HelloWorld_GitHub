namespace WWStock.UI
{
    partial class KeyCasperForm
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
            this.tbxKeyString = new WWStock.UI.UDTextBox();
            this.lbxFunction = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tbxKeyString, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbxFunction, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(206, 122);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tbxKeyString
            // 
            this.tbxKeyString.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxKeyString.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxKeyString.Location = new System.Drawing.Point(3, 3);
            this.tbxKeyString.MaxLength = 10;
            this.tbxKeyString.Name = "tbxKeyString";
            this.tbxKeyString.Size = new System.Drawing.Size(200, 23);
            this.tbxKeyString.TabIndex = 0;
            // 
            // lbxFunction
            // 
            this.lbxFunction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbxFunction.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxFunction.FormattingEnabled = true;
            this.lbxFunction.ItemHeight = 17;
            this.lbxFunction.Location = new System.Drawing.Point(3, 28);
            this.lbxFunction.Name = "lbxFunction";
            this.lbxFunction.Size = new System.Drawing.Size(200, 89);
            this.lbxFunction.TabIndex = 1;
            // 
            // KeyCasperForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(206, 122);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "KeyCasperForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.KeyCasperForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private UDTextBox tbxKeyString;
        private System.Windows.Forms.ListBox lbxFunction;
    }
}