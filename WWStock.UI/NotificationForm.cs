using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WWStock.UI
{
    public partial class NotificationForm : Form
    {
        private List<string> messages = new List<string>();

        public NotificationForm()
        {
            InitializeComponent();
        }

        public NotificationForm(List<string> list, int timeout)
        {
            InitializeComponent();

            messages.AddRange(list);
            if (timeout > 0 && timeout <= 60000)
            {
                tmrClose.Interval = timeout;
            }
        }

        private void NotificationForm_Load(object sender, EventArgs e)
        {
            PopulateListView();

            this.Left = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
            this.Top = Screen.PrimaryScreen.WorkingArea.Height;

            tmrLoading.Start();
        }

        private void tmrClose_Tick(object sender, EventArgs e)
        {
            tmrClose.Stop();
            tmrClosing.Start();
        }

        private void PopulateListView()
        {
            lvMessage.Items.Clear();

            int i = 0;
            foreach (string str in messages)
            {
                lvMessage.Items.Add(new ListViewItem(str));
                lvMessage.Items[i++].ForeColor = GetMessageItemColor(str);
            }
        }

        private Color GetMessageItemColor(string str)
        {
            string[] strings = str.Split(' ');
            if (strings.Length > 0)
            {
                float gapRate = float.Parse(strings[strings.Length - 1].TrimEnd('%'));
                if (gapRate <= 0) return Color.Red;
                if (gapRate < 2) return Color.Tomato;
                if (gapRate < 5) return Color.Orange;
            }

            return Color.White;
        }

        private void tmrClosing_Tick(object sender, EventArgs e)
        {
            if (this.Opacity <= 0)
            {
                tmrClosing.Stop();
                this.Close();
            }
            else
            {
                this.Opacity -= 0.1;
            }
        }

        private void tmrLoading_Tick(object sender, EventArgs e)
        {
            if (this.Top > Screen.PrimaryScreen.WorkingArea.Height - this.Height + 4)
            {
                this.Top -= 4;
            }
            else
            {
                tmrLoading.Stop();
                tmrClose.Start();
            }
        }
    }
}