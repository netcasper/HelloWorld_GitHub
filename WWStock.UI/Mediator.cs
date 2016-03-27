using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WWStock.UI
{
    class Mediator
    {
        private TextBox _tbx;
        private ListBox _lbx;
        private List<string> _contents;
        public Mediator(TextBox tbx, ListBox lbx, List<string> contents)
        {
            this._tbx = tbx;
            this._lbx = lbx;
            this._contents = contents;

            UpdateListBox();

            this._tbx.TextChanged += tbx_TextChanged;
        }

        private void tbx_TextChanged(object sender, EventArgs e)
        {
            _tbx.Text = _tbx.Text.ToUpper();
            _tbx.SelectionStart = _tbx.TextLength;

            UpdateListBox();
        }

        private void UpdateListBox()
        {
            // show the first matched string in the list
            _lbx.Items.Clear();
            _lbx.Items.AddRange(_contents.FindAll(StartsWithString).ToArray());

            // select the first item in the list
            if (_lbx.Items.Count > 0) _lbx.SetSelected(0, true);
        }

        private bool StartsWithString(string str)
        {
            string strText = _tbx.Text.Trim();
            if (strText.Length > 0)
            {
                if (str.Length >= _tbx.Text.Length)
                {
                    if (str.Substring(0, _tbx.Text.Length) == _tbx.Text)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
