using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;
using WWStock.Data;
using WWStock.UI;

namespace WWStock.App
{
    public partial class MainForm : Form
    {
        private struct StockIndex
        {
            public string price;
            public string changeRate;
            public string changePrice;
            public string amount;
        }

        private struct StockItem
        {
            public string code;
            public string name;
            public float changeRate;
            public float price;
            public float last;
            public float open;
            public float high;
            public float low;
            public double volume;
            public double amount;
        }

        private readonly Object lvLocker = new Object();

        private readonly Object listLocker = new Object();
        private List<StockItem> stockList = new List<StockItem>();

        private readonly Object stockIndexLocker = new Object();
        private StockIndex[] stockIndex = new StockIndex[2];

        private bool stopUpdate;
        private List<WaveChartDataItem> waveChartData = new List<WaveChartDataItem>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            stopUpdate = true;
            bgwAutoRefresh.CancelAsync();
            bgwListView.CancelAsync();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            DataController.Instance.LoadData();
            wChartUS1.ChartSetup("", "", 10, DateTime.Now, null);
            wChartUS2.ChartSetup("", "", 10, DateTime.Now, null);

            stopUpdate = false;
            Thread thread = new Thread(ThreadUpdateStatusBar);
            thread.Start();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ShowStock(Dictionary<string, string> dict)
        {
            tssListView.Text = String.Empty;

            UpdateButtons(true);

            lsvStockList.Items.Clear();
            DataController.Instance.CurrentData = dict;
            bgwListView.RunWorkerAsync(DataController.Instance.CurrentData);
        }

        private void ShowStockAuto()
        {
            tssListView.Text = "Auto Refreshing";

            UpdateButtons(true);

            if (DataController.Instance.CurrentData.Count == 0)
            {
                DataController.Instance.CurrentData = DataController.Instance.StockUser;
            }
            bgwAutoRefresh.RunWorkerAsync(DataController.Instance.CurrentData);
        }

        private void ShowStockStop()
        {
            bgwAutoRefresh.CancelAsync();
            bgwListView.CancelAsync();
            btnStopRecieve.Enabled = false;
        }

        private void btnStockUser_Click(object sender, EventArgs e)
        {
            ShowStock(DataController.Instance.StockUser);
        }

        private void btnStockSH_Click(object sender, EventArgs e)
        {
            ShowStock(DataController.Instance.StockSH);
        }

        private void btnStockSZ_Click(object sender, EventArgs e)
        {
            ShowStock(DataController.Instance.StockSZ);
        }

        private void btnAutoRecieve_Click(object sender, EventArgs e)
        {
            ShowStockAuto();
        }

        private void btnStopRecieve_Click(object sender, EventArgs e)
        {
            ShowStockStop();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            LoadWaveChartFile();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            list.Add("sh600000 浦发银行 6.82% 12.87 12.80 1.50%");
            list.Add("sh600001 浦发银行 6.82% 12.87 12.80 0.0%");
            list.Add("sh600002 浦发银行 6.82% 12.87 12.80 3.50%");
            list.Add("sh600003 浦发银行 6.82% 12.87 12.80 5.50%");
            list.Add("sh600004 浦发银行 6.82% 12.87 12.80 9.50%");
            list.Add("sh600005 浦发银行 6.82% 12.87 12.80 1.50%");
            list.Add("sh600006 浦发银行 6.82% 12.87 12.80 1.50%");
            list.Add("sh600007 浦发银行 6.82% 12.87 12.80 1.50%");
            list.Add("sh600008 浦发银行 6.82% 12.87 12.80 1.50%");
            list.Add("sh600009 浦发银行 6.82% 12.87 12.80 1.50%");
            NotificationForm notify = new NotificationForm(list, 10000);
            notify.Show();
        }

        private void btnWChart_Click(object sender, EventArgs e)
        {
            if (lsvStockList.SelectedItems.Count < 1)
            {
                return;
            }

            WChartForm form = new WChartForm();
            form.ChartSetup(lsvStockList.SelectedItems[0].SubItems[0].Text,
                lsvStockList.SelectedItems[0].SubItems[1].Text,
                float.Parse(lsvStockList.SelectedItems[0].SubItems[4].Text),
                DateTime.Now,
                null);
            form.ShowDialog();
        }

        private void btnSetup_Click(object sender, EventArgs e)
        {
            SetupForm setup = new SetupForm();
            if (setup.ShowDialog() == DialogResult.OK)
            {
                DataController.Instance.LoadData();
            }
        }

        private void lsvStockList_DoubleClick(object sender, EventArgs e)
        {
            if (lsvStockList.SelectedItems.Count < 1)
            {
                return;
            }

            WChartForm form = new WChartForm();
            form.ChartSetup(lsvStockList.SelectedItems[0].SubItems[0].Text,
                lsvStockList.SelectedItems[0].SubItems[1].Text,
                float.Parse(lsvStockList.SelectedItems[0].SubItems[4].Text),
                DateTime.Now,
                null);
            form.ShowDialog();
        }

        private void ThreadUpdateStatusBar()
        {
            HTTPDataProvider dataProvider = new HTTPDataProvider();
            if (dataProvider.Connect(null))
            {
                List<string> codes = new List<string>(2);
                codes.Add("s_sh000001");
                codes.Add("s_sz399001");

                List<StockInfoShort> infos = new List<StockInfoShort>(2);
                if (dataProvider.GetStockInfoList(codes, infos))
                {
                    UpdateStockIndex(infos, stockIndex);
                }

                for (; ; )
                {
                    Thread.Sleep(500);

                    if (stopUpdate) break;

                    if (HTTPDataProvider.CheckDateTime(DateTime.Now))
                    {
                        infos.Clear();
                        if (dataProvider.GetStockInfoList(codes, infos))
                        {
                            UpdateStockIndex(infos, stockIndex);
                        }
                    }
                }

                dataProvider.Disconnect();
            }
        }

        private void UpdateStockIndex(List<StockInfoShort> infos, StockIndex[] stockIndex)
        {
            lock(stockIndexLocker)
            {
                int i = 0;
                foreach (StockInfoShort item in infos)
                {
                    stockIndex[i].price = item.price;
                    stockIndex[i].changePrice = item.updown; // 126
                    stockIndex[i].changeRate = item.percent; // 126
                    stockIndex[i].amount = item.turnover;
                    i++;
                }
            }
        }

        private void UpdateStatusBarIndex(ToolStripStatusLabel tss, StockIndex index)
        {

            if (String.IsNullOrEmpty(index.changePrice) == false)
            {
                tss.Text = index.price + "    " + index.changeRate + "%    " + index.changePrice + "    " + index.amount;

                float price = float.Parse(index.price);
                float changePrice = float.Parse(index.changePrice);
                if (price == 0)
                {
                    tss.ForeColor = Color.Blue;
                }
                else
                {
                    tss.ForeColor = (changePrice > float.Epsilon) ? Color.Red : Color.DarkGreen;
                }
            }
        }

        private void WriterStockCodeNameToFile()
        {
            string strFileName = Application.StartupPath + "\\StockSHIndex.xml";
            XmlTextWriter w = new XmlTextWriter(strFileName, Encoding.UTF8);
            w.Formatting = Formatting.Indented;
            w.WriteStartDocument();
            w.WriteStartElement("settings");
            for (int i = 0; i < lsvStockList.Items.Count; i++)
            {
                w.WriteStartElement("stock");
                w.WriteElementString("code", lsvStockList.Items[i].SubItems[0].Text);
                w.WriteElementString("name", lsvStockList.Items[i].SubItems[1].Text);
                w.WriteEndElement();
            }
            w.WriteEndElement();
            w.WriteEndDocument();
            w.Close();
        }

        private void tmrStatusBar_Tick(object sender, EventArgs e)
        {
            tssDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd(ddd) hh:mm:ss");

            UpdateStatusBarIndex(tssSHIndex, stockIndex[0]);
            UpdateStatusBarIndex(tssSZIndex, stockIndex[1]);
        }

        private void bgwListView_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            if (worker == null) return;

            e.Result = RetrieveStockInfo(DataController.Instance.CurrentData, worker, e);
        }

        private void bgwListView_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            UpdateLV(lsvStockList.Items.Count, e.ProgressPercentage - lsvStockList.Items.Count);
            tssListView.Text = String.Format("{0:d}%", e.ProgressPercentage * 100 / DataController.Instance.CurrentData.Count);
        }

        private void bgwListView_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            } 
            else if (e.Cancelled)
            {
                tssListView.Text = "Canceled";
            }
            else
            {
                tssListView.Text = (bool)e.Result ? "Succeeded" : "Failed";
            }

            UpdateButtons(false);
        }

        private void bgwAutoRefresh_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            if (worker == null) return;

            RetrieveStockInfoAutoRefresh(DataController.Instance.CurrentData, worker, e);
        }

        private void bgwAutoRefresh_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            UpdateLV(0, lsvStockList.Items.Count);
        }

        private void bgwAutoRefresh_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            } 
            else if (e.Cancelled)
            {
                tssListView.Text = "Canceled";
            }

            UpdateButtons(false);
        }

        private bool RetrieveStockInfo(Dictionary<string, string> dict, BackgroundWorker worker, DoWorkEventArgs e)
        {
            //items.Clear();
            if (dict == null) return false;
            if (dict.Count < 1) return true;

            HTTPDataProvider dataProvider = new HTTPDataProvider();
            if (dataProvider.Connect(null))
            {
                List<string> codes = new List<string>(dict.Count);
                foreach (KeyValuePair<string, string> pair in dict)
                {
                    codes.Add(pair.Key);
                }

                int i = 0;
                int nMaxStockItems = HTTPDataProvider.MAXSTOCKITEMS;
                do
                {
                    if (worker.CancellationPending)
                    {
                        e.Cancel = true;
                        break;
                    }

                    int nCount = (i < codes.Count / nMaxStockItems) ? (nMaxStockItems) : (codes.Count % nMaxStockItems);
                    if (nCount == 0) continue;
                    List<StockInfoShort> infos = new List<StockInfoShort>(nCount);
                    if (dataProvider.GetStockInfoListBlock(codes.GetRange(i * nMaxStockItems, nCount), infos))
                    {
                        UpdateStockItemList(i*nMaxStockItems, nCount, codes.GetRange(i*nMaxStockItems, nCount), infos);

                        worker.ReportProgress(i * nMaxStockItems + nCount);
                    }
                    else
                    {
                        dataProvider.Disconnect();
                        return false;
                    }
                } while (++i < codes.Count / nMaxStockItems + 1);

                dataProvider.Disconnect();
            }
            else
            {
                return false;
            }

            return true;
        }

        private void RetrieveStockInfoAutoRefresh(Dictionary<string, string> dict, BackgroundWorker worker, DoWorkEventArgs e)
        {
            if (dict == null) return;
            if (dict.Count < 1) return;

            HTTPDataProvider dataProvider = new HTTPDataProvider();
            if (dataProvider.Connect(null))
            {
                List<string> codes = new List<string>(dict.Count);
                foreach (KeyValuePair<string, string> pair in dict)
                {
                    codes.Add(pair.Key);
                }

                while (true)
                {
                    if (worker.CancellationPending)
                    {
                        e.Cancel = true;
                        break;
                    }

                    int i = 0;
                    int nMaxStockItems = HTTPDataProvider.MAXSTOCKITEMS;
                    do
                    {
                        if (worker.CancellationPending)
                        {
                            e.Cancel = true;
                            break;
                        }

                        int nCount = (i < codes.Count / nMaxStockItems) ? (nMaxStockItems) : (codes.Count % nMaxStockItems);
                        if (nCount == 0) continue;
                        List<StockInfoShort> infos = new List<StockInfoShort>(nCount);
                        if (dataProvider.GetStockInfoListBlock(codes.GetRange(i * nMaxStockItems, nCount), infos))
                        {
                            UpdateStockItemList(i * nMaxStockItems, nCount, codes.GetRange(i * nMaxStockItems, nCount), infos);
                        }
                        else
                        {
                            dataProvider.Disconnect();
                            return;
                        }
                    } while (++i < codes.Count / nMaxStockItems + 1);

                    worker.ReportProgress(1);
                    Thread.Sleep(100);
                }

                dataProvider.Disconnect();
            }
        }

        private void UpdateButtons(bool running)
        {
            btnStockUser.Enabled = !running;
            btnStockSH.Enabled = !running;
            btnStockSZ.Enabled = !running;
            btnAutoRecieve.Enabled = !running;
            btnStopRecieve.Enabled = running;
        }

        private void LoadWaveChartData()
        {
            try
            {
                XPathDocument doc = new XPathDocument(Application.StartupPath + "\\SZZS200702.xml");
                XPathNavigator nav = ((IXPathNavigable) doc).CreateNavigator();

                XPathNodeIterator iter = nav.Select("/stock/stockItem[@code='sh000001']/data/dayData[@date='2007-2-6']/minuteData");

                int i = 0;
                while (iter.MoveNext())
                {
                    WaveChartDataItem item = new WaveChartDataItem();
                    item.index = ++i;
                    XPathNodeIterator newIter = iter.Current.SelectChildren(XPathNodeType.Element);

                    newIter.MoveNext();
                    newIter.MoveNext();
                    item.open = float.Parse(newIter.Current.InnerXml);
                    newIter.MoveNext();
                    item.low = float.Parse(newIter.Current.InnerXml);
                    newIter.MoveNext();
                    item.high = float.Parse(newIter.Current.InnerXml);
                    newIter.MoveNext();
                    item.close = float.Parse(newIter.Current.InnerXml);
                    newIter.MoveNext();
                    item.volume = double.Parse(newIter.Current.InnerXml);

                    waveChartData.Add(item);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return;
            }

            wChartUS1.ChartSetup("sh000001", "上证指数", 2612.537f, DateTime.Parse("2007-2-6"), waveChartData);
        }

        private void LoadWaveChartFile()
        {
            try
            {
                XPathDocument doc = new XPathDocument(Application.StartupPath + "\\SHIndex2007a.xml");
                wChartUS1.ChartSetup(doc.CreateNavigator());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void btnAlert_Click(object sender, EventArgs e)
        {
            AlertForm alertForm = new AlertForm();
            alertForm.ShowDialog();
        }

        private StockItem BuildStockItem(string code, StockInfoShort info)
        {
            StockItem item = new StockItem();

            float price = float.Parse(info.price);

            item.code = code;
            item.name = info.name;
            item.price = price;
            item.open = float.Parse(info.open);
            item.high = float.Parse(info.high);
            item.low = float.Parse(info.low);
            item.volume = float.Parse(info.volume);

            return item;
        }

        private void UpdateStockItemList(int start, int count, List<string> codes, List<StockInfoShort> infos)
        {
            lock(listLocker)
            {
                for (int i = 0; i < count; i++)
                {
                    if (stockList.Count < i + start) return;
                    
                    if (stockList.Count == i + start)
                    {
                        stockList.Add(BuildStockItem(codes[i], infos[i]));
                    }
                    else
                    {
                        stockList[i + start] = BuildStockItem(codes[i], infos[i]);
                    }
                }
            }
        }

        private Color GetColor(float price, float changeRate)
        {
            if (price == 0)
                return Color.Gray;

            if (changeRate == 0)
                return Color.White;

            return ((changeRate > 0) ? Color.Red : Color.LimeGreen);
        }

        private ListViewItem BuildLVItem(StockItem item)
        {
            ListViewItem lvItem = new ListViewItem(item.code);
            lvItem.SubItems.Add(item.name);
            lvItem.SubItems.Add((item.price == 0) ? "-" : String.Format("{0:f}%", item.changeRate));
            lvItem.SubItems.Add(String.Format("{0:f}", item.price));
            lvItem.SubItems.Add(String.Format("{0:f}", item.last));
            lvItem.SubItems.Add(String.Format("{0:f}", item.open));
            lvItem.SubItems.Add(String.Format("{0:f}", item.high));
            lvItem.SubItems.Add(String.Format("{0:f}", item.low));
            lvItem.SubItems.Add(String.Format("{0:#,#}", item.amount));

            lvItem.ForeColor = GetColor(item.price, item.changeRate);

            return lvItem;
        }

        private void UpdateLV(int start, int count)
        {
            if (stockList.Count < start + count) return;

            lock(lvLocker)
            {
                for (int i = start; i < start + count; i++)
                {
                    if (lsvStockList.Items.Count < i) return;
                    
                    if (lsvStockList.Items.Count == i)
                    {
                        lsvStockList.Items.Add(BuildLVItem(stockList[i]));
                    }
                    else
                    {
                        ListViewItem item = BuildLVItem(stockList[i]);
                        for (int j=0; j<item.SubItems.Count; j++)
                        {
                            if (lsvStockList.Items[i].SubItems[j].Text.CompareTo(item.SubItems[j].Text) != 0)
                            {
                                lsvStockList.Items[i].SubItems[j].Text = item.SubItems[j].Text;
                            }
                        }
                        lsvStockList.Items[i].ForeColor = item.ForeColor;
                    }
                }
            }
        }

        private List<string> GetFunctionList()
        {
            List<string> functionList = new List<string>();
            functionList.Add(".00    Exit");
            functionList.Add("00    Auto");
            functionList.Add("01    User");
            functionList.Add("02    SH");
            functionList.Add("03    SZ");
            functionList.Add("04    Stop");
            functionList.Add("06    Alert");

            functionList.AddRange(DataController.Instance.StockKeyList);

            return functionList;
        }

        private void DoFunction(string str)
        {
            switch (str)
            {
                case ".00":
                    this.Close();
                    break;
                case "00":
                    if (btnAutoRecieve.Enabled) ShowStockAuto();
                    break;
                case "01":
                    if (btnStockUser.Enabled) ShowStock(DataController.Instance.StockUser);
                    break;
                case "02":
                    if (btnStockSH.Enabled) ShowStock(DataController.Instance.StockSH);
                    break;
                case "03":
                    if (btnStockSZ.Enabled) ShowStock(DataController.Instance.StockSZ);
                    break;
                case "04":
                    if (btnStopRecieve.Enabled) ShowStockStop();
                    break;
                case "06":
                    if (btnAlert.Enabled)
                    {
                        AlertForm alertForm = new AlertForm();
                        alertForm.ShowDialog();
                    }
                    break;
                default:
                    break;
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (CheckKey(keyData))
            {
                List<string> functionList = GetFunctionList();
                KeyCasperForm kcForm = new KeyCasperForm(this.Right, this.Bottom, functionList, keyData);
                if (kcForm.ShowDialog() == DialogResult.OK)
                {
                    //MessageBox.Show("kcForm.KeyString = " + kcForm.KeyString);
                    DoFunction(kcForm.KeyString);
                }

                return true;
            }

            return base.ProcessDialogKey(keyData);
        }

        private bool CheckKey(Keys keyData)
        {
            if (keyData == Keys.Decimal
                || keyData == Keys.NumPad0
                || keyData == Keys.NumPad1
                || keyData == Keys.NumPad2
                || keyData == Keys.NumPad3
                || keyData == Keys.NumPad4
                || keyData == Keys.NumPad5
                || keyData == Keys.NumPad6
                || keyData == Keys.NumPad7
                || keyData == Keys.NumPad8
                || keyData == Keys.NumPad9
                || keyData == Keys.Multiply
                || keyData >= Keys.A && keyData <= Keys.Z)
            {
                return true;
            }

            return false;
        }
    }
}