using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WWStock.Data;

namespace WWStock.App
{
    public partial class FloatingBar : Form
    {
        private Point mouseLocation;
        private List<string> stockList = new List<string>();
        private string stockBarContent = string.Empty;

        public FloatingBar()
        {
            InitializeComponent();
        }

        private void FloatingBar_Load(object sender, EventArgs e)
        {
            InitStockList();

            lblStock.Text = Settings.Default.Stock;
            //lblStock.Text = "423/1.26 | 24.36/9.37 | 6.30/-4.36";

            this.Left = Settings.Default.PositionX;
            this.Top = Settings.Default.PositionY;
            this.Width = Settings.Default.Width;
            //this.Left = (Screen.PrimaryScreen.WorkingArea.Width - this.Width)/2;
            //this.Top = Screen.PrimaryScreen.WorkingArea.Height - this.Height + 10;

            bgwStockLabel.RunWorkerAsync();
        }

        private void FloatingBar_DoubleClick(object sender, EventArgs e)
        {
            SaveSettings();

            this.Close();
        }

        private void SaveSettings()
        {
            Settings.Default.PositionX = this.Left;
            Settings.Default.PositionY = this.Top;
            Settings.Default.Width = this.Width;
            Settings.Default.Save();
        }

        private void FloatingBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseLocation = e.Location;
            }
        }

        private void FloatingBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left = Cursor.Position.X - mouseLocation.X;
                this.Top = Cursor.Position.Y - mouseLocation.Y;
            }
        }

        private void LoadStockList()
        {
            stockList.Clear();
            string str = Settings.Default.Stock;
            string[] stocks = str.Split(';');
            for (int i = 0; i < stocks.GetLength(0); i++ )
            {
                stockList.Add(stocks[i]);
            }
        }

        private void InitStockList()
        {
            try
            {
                stockList.Clear();

                using (StreamReader reader = new StreamReader(Application.StartupPath + "\\floatingbar.txt"))
                {
                    string line = string.Empty;
                    while ((line = reader.ReadLine()) != null)
                    {
						if (line.Length > 0)
						{
							stockList.Add(line);
						}
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void bgwStockLabel_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }

        private void bgwStockLabel_DoWork(object sender, CancelEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            if (worker == null) return;

            try
            {
                List<StockInfoShort> infos = new List<StockInfoShort>(stockList.Count);
                HTTPDataProvider dataProvider = new HTTPDataProvider();
                if (dataProvider.Connect(null))
                {
                    List<string> codes = new List<string>(stockList.Count);
                    foreach (string item in stockList)
                    {
						if ((item.Substring(0, 1) == "0" && item != "000001") || item.Substring(0, 1) == "3" || item.Substring(0, 1) == "1")
                            codes.Add("1" + item);
                        else
                            codes.Add("0" + item);
                    }

                    while (true)
                    {
                        if (worker.CancellationPending)
                        {
                            e.Cancel = true;
                            break;
                        }

                        bool firstTime = true;
                        if (HTTPDataProvider.CheckDateTime(DateTime.Now) || firstTime)
                        {
                            infos.Clear();
                            if (dataProvider.GetStockInfoList(codes, infos))
                            {
                                StringBuilder builder = new StringBuilder();
                                foreach (StockInfoShort item in infos)
                                {

									if (item.price == "0.00")
									{
										builder.Append(item.price + @"/" + item.updown + @" ^ ");
									}
									else
									{
                                        double ratio = Convert.ToDouble(item.percent);
                                        ratio = ratio * 100;
										double price = Convert.ToDouble(item.price);
										if (price > 1000)
										{
                                            double amount = Convert.ToDouble(item.turnover);
                                            amount = amount / 100000000;
											//int posDot = item.turnover.IndexOf('.');
											//if (posDot > 0)
											//{
											//	amount = item.turnover.Substring(0, posDot);
											//}
											builder.Append(item.price + @"/" + ratio.ToString("f2") + @"/" + amount.ToString("f0") + @" ^ ");
										}
										else
										{
											builder.Append(item.price + @"/" + ratio.ToString("f2") + @" ^ ");
										}
									}
                                }

                                stockBarContent = builder.ToString();
                                if (stockBarContent.Length > 3)
                                    stockBarContent = stockBarContent.Substring(0, stockBarContent.Length - 3);

                                worker.ReportProgress(1);
                            }

                            firstTime = false;
                        }

                        Thread.Sleep((int)Settings.Default.Interval);
                    }

                    dataProvider.Disconnect();
                }

            }
            catch (Exception eX)
            {
                //MessageBox.Show(eX.Message);
            }
        }

        private void bgwStockLabel_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblStock.Text = stockBarContent;
        }

        private void FloatingBar_FormClosing(object sender, FormClosingEventArgs e)
        {
            bgwStockLabel.CancelAsync();
        }

        private void FloatingBar_MouseClick(object sender, MouseEventArgs e)
        {
        }

		private void FloatingBar_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.X)
			{
				SaveSettings();
				this.Close();
			}
		}
    }
}