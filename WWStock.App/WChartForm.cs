using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.XPath;
using WWStock.UI;

namespace WWStock.App
{
    public partial class WChartForm : Form
    {

        public WChartForm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void WChartForm_Paint(object sender, PaintEventArgs e)
        {
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics dc = e.Graphics;
            Pen bluePen = new Pen(Color.Blue, 3);
            dc.DrawRectangle(bluePen, 20, 20, 120, 80);
            Pen redPen = new Pen(Color.Red, 2);
            dc.DrawEllipse(redPen, 0, 50, 80, 60);
        }

        public void ChartSetup(string code, string name, float last, DateTime dt, List<WaveChartDataItem> list)
        {
            wChartUS1.ChartSetup(code, name, last, dt, list);
        }

        public void ChartSetup(XPathNavigator nav)
        {
            wChartUS1.ChartSetup(nav);
        }
    }
}