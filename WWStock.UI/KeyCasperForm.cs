using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WWStock.UI
{
    public partial class KeyCasperForm : Form
    {
        private int _right;
        private int _bottom;
        private Keys _key;

        private Mediator _mediator;
        public string KeyString;

        public KeyCasperForm(int right, int bottom, List<string> contents, Keys key)
        {
            _right = right;
            _bottom = bottom;
            _key = key;

            InitializeComponent();

            tbxKeyString.Text = GetKeyString(_key);
            tbxKeyString.SelectionStart = tbxKeyString.TextLength;

            _mediator = new Mediator(tbxKeyString, lbxFunction, contents);
        }

        private void KeyCasperForm_Load(object sender, EventArgs e)
        {
            this.Left = _right - this.Width;
            this.Top = _bottom - this.Height;
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData & Keys.KeyCode)
            {
                case Keys.Escape:
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
            	    return true;
                case Keys.Enter:
                    this.DialogResult = DialogResult.OK;
                    if (lbxFunction.Items.Count > 0)
                    {
                        string[] strs = lbxFunction.Items[lbxFunction.SelectedIndex].ToString().Split(' ');
                        if (strs.Length > 1)
                        {
                            tbxKeyString.Text = strs[0].Trim();
                        }
                    }
                    this.KeyString = tbxKeyString.Text.Trim();
                    this.Close();
                    return true;
                case Keys.Up:
                    if (lbxFunction.Items.Count > 0)
                    {
                        lbxFunction.SelectedIndex = lbxFunction.SelectedIndex == 0 ? 0 : lbxFunction.SelectedIndex - 1;
                    }
                    return true;
                case Keys.Down:
                    if (lbxFunction.Items.Count > 0)
                    {
                        lbxFunction.SelectedIndex = lbxFunction.SelectedIndex == lbxFunction.Items.Count - 1
                                                        ? lbxFunction.Items.Count - 1
                                                        : lbxFunction.SelectedIndex + 1;
                    }
                    return true;
            }

            return base.ProcessDialogKey(keyData);
        }

        private string GetKeyString(Keys key)
        {
            switch (key & Keys.KeyCode)
            {
                case Keys.Decimal:
                    return ".";
                case Keys.NumPad0:
                    return "0";
                case Keys.NumPad1:
                    return "1";
                case Keys.NumPad2:
                    return "2";
                case Keys.NumPad3:
                    return "3";
                case Keys.NumPad4:
                    return "4";
                case Keys.NumPad5:
                    return "5";
                case Keys.NumPad6:
                    return "6";
                case Keys.NumPad7:
                    return "7";
                case Keys.NumPad8:
                    return "8";
                case Keys.NumPad9:
                    return "9";
                case Keys.Multiply:
                    return "*";
            }

            return key.ToString().ToUpper();
        }
    }
}