using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WWStock.Data;
using WWStock.UI;

namespace WWStock.App
{
    public partial class AlertForm : Form
    {
        class AlertInfo 
        {
            public string code;
            public string name;
            public float price;
            public float last;
            public float buy;
            public float sell;
            public string trend;
            public string level;
            public string comments;
            public string alert;
        }

        private readonly Object listLocker = new Object();
        private readonly Object lvLocker = new Object();
        private List<AlertInfo> alertList = new List<AlertInfo>();

        public AlertForm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AlertForm_Load(object sender, EventArgs e)
        {
            InitAlertList(Application.StartupPath + "\\alert.txt", alertList);
            InitializeListView(alertList);

            PopulateAlertList(alertList);
            PopulateListView(alertList);
        }

        private void InitAlertList(string strFileName, List<AlertInfo> list)
        {
            try
            {
                lock(listLocker)
                {
                    list.Clear();

                    using (StreamReader reader = new StreamReader(strFileName))
                    {
                        string line = string.Empty;
                        while ((line = reader.ReadLine()) != null)
                        {
                            // code, target, trend, level, comments
                            string[] fields = line.Split('/');
                            if (fields.Length != 5) continue;

                            AlertInfo alertItem = new AlertInfo();
                            alertItem.code = fields[0].Trim();
                            alertItem.buy = float.Parse(fields[1].Trim());
                            alertItem.trend = fields[2].Trim();
                            alertItem.level = fields[3].Trim();
                            string str = fields[4].Trim();
                            //str = str.Replace('1', 'Á¿');
                            //str = str.Replace('2','×¢');
                            alertItem.comments = str;

                            list.Add(alertItem);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void InitializeListView(List<AlertInfo> list)
        {
            lock(lvLocker)
            {
                lvAlert.Items.Clear();

                foreach (AlertInfo item in list)
                {
                    ListViewItem lvItem = new ListViewItem(item.code);  // code
                    lvItem.SubItems.Add("");    // name
                    lvItem.SubItems.Add("");    // changeRate
                    lvItem.SubItems.Add("");    // price
                    lvItem.SubItems.Add("");    // ceiling
                    lvItem.SubItems.Add("");    // floor
                    lvItem.SubItems.Add(String.Format("{0:f}", item.buy));   // target
                    lvItem.SubItems.Add("");    // gap
                    lvItem.SubItems.Add("");    // gapRate
                    lvItem.SubItems.Add(item.trend);    // trend
                    lvItem.SubItems.Add(item.level);    // level
                    lvItem.SubItems.Add(item.comments); // comments
                    lvItem.SubItems.Add("");    // alert

                    lvAlert.Items.Add(lvItem);
                }
            }
        }

        private void PopulateListView(List<AlertInfo> list)
        {
            try
            {
                lock(lvLocker)
                {
                    int i = 0;
                    foreach (AlertInfo item in list)
                    {
                        lvAlert.Items[i].SubItems[0].Text = item.code;
                        lvAlert.Items[i].SubItems[1].Text = item.name;
                        lvAlert.Items[i].SubItems[2].Text = (item.price == 0) ? "-" : String.Format("{0:f}%", (item.price - item.last) * 100 / item.last);
                        lvAlert.Items[i].SubItems[3].Text = String.Format("{0:f}", item.price);
                        lvAlert.Items[i].SubItems[4].Text = String.Format("{0:f}", item.last * 1.1);
                        lvAlert.Items[i].SubItems[5].Text = String.Format("{0:f}", item.last * 0.9);
                        lvAlert.Items[i].SubItems[6].Text = String.Format("{0:f}", item.buy);
                        lvAlert.Items[i].SubItems[7].Text = String.Format("{0:f}", item.price - item.buy);
                        lvAlert.Items[i].SubItems[8].Text = (item.price == 0) ? "-" : String.Format("{0:f}%", (item.price - item.buy) * 100 / item.buy);
                        lvAlert.Items[i].SubItems[9].Text = item.trend;
                        lvAlert.Items[i].SubItems[10].Text = item.level;
                        lvAlert.Items[i].SubItems[11].Text = item.comments;
                        lvAlert.Items[i].SubItems[12].Text = item.alert;

                        lvAlert.Items[i].BackColor = GetColor(item);

                        i++;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void UpdateListView(List<AlertInfo> list)
        {
            try
            {
                lock (lvLocker)
                {
                    List<string> notificationList = new List<string>();
                    int i = 0;
                    foreach (AlertInfo item in list)
                    {
                        string str = (item.price == 0) ? "-" : String.Format("{0:f}%", (item.price - item.last) * 100 / item.last);
                        if (lvAlert.Items[i].SubItems[2].Text.CompareTo(str) != 0)
                        {
                            lvAlert.Items[i].SubItems[2].Text = str;
                        }

                        str = String.Format("{0:f}", item.price);
                        if (lvAlert.Items[i].SubItems[3].Text.CompareTo(str) != 0)
                        {
                            lvAlert.Items[i].SubItems[3].Text = str;
                        }

                        str = String.Format("{0:f}", item.last*1.1f);
                        if (lvAlert.Items[i].SubItems[4].Text.CompareTo(str) != 0)
                        {
                            lvAlert.Items[i].SubItems[4].Text = str;
                        }

                        str = String.Format("{0:f}", item.last*0.9f);
                        if (lvAlert.Items[i].SubItems[5].Text.CompareTo(str) != 0)
                        {
                            lvAlert.Items[i].SubItems[5].Text = str;
                        }

                        str = String.Format("{0:f}", item.price - item.buy);
                        if (lvAlert.Items[i].SubItems[7].Text.CompareTo(str) != 0)
                        {
                            lvAlert.Items[i].SubItems[7].Text = str;
                        }

                        str = (item.price == 0) ? "-" : String.Format("{0:f}%", (item.price - item.buy) * 100 / item.buy);
                        if (lvAlert.Items[i].SubItems[8].Text.CompareTo(str) != 0)
                        {
                            lvAlert.Items[i].SubItems[8].Text = str;
                        }

                        lvAlert.Items[i].BackColor = GetColor(item);

                        UpdateNotificationList(notificationList, lvAlert.Items[i], item);

                        i++;
                    }

                    ShowNotificationForm(notificationList);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private Color GetColor(AlertInfo info)
        {
            if (info.price == 0) return Color.Gray;

            float iGapRate = (info.price - info.buy) * 100 / info.buy;
            if (iGapRate <= 0) return Color.Red;
            if (iGapRate <= 2) return Color.Tomato;
            if (iGapRate <= 5) return Color.Orange;

            return (info.buy >= info.last * 0.9) ? Color.PeachPuff : Color.White;
        }

        private void UpdateNotificationList(List<string> list, ListViewItem lvItem, AlertInfo info)
        {
            if (info.price == 0) return;
            float iGapRate = (info.price - info.buy) * 100 / info.buy;

            if (iGapRate <= 5 && (lvItem.SubItems[12].Text.CompareTo("!") != 0))
            {
                lvItem.SubItems[12].Text = "!";
                list.Add(BuildNofiticationItem(lvItem));
            }
        }

        private string BuildNofiticationItem(ListViewItem lvItem)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(lvItem.SubItems[0].Text + " ");
            sb.Append(lvItem.SubItems[1].Text + " ");
            sb.Append(lvItem.SubItems[2].Text + " ");
            sb.Append(lvItem.SubItems[3].Text + " ");
            sb.Append(lvItem.SubItems[6].Text + " ");
            sb.Append(lvItem.SubItems[8].Text);

            return sb.ToString();
        }

        private void ShowNotificationForm(List<string> notificationList)
        {
            if (notificationList.Count == 0) return;
            NotificationForm ntyForm = new NotificationForm(notificationList, 10000);
            ntyForm.Show();
        }

        private void PopulateAlertList(List<AlertInfo> list)
        {
            List<StockInfoShort> infos = new List<StockInfoShort>(list.Count);
            if (GetData(list, infos))
            {
                UpdateAlertList(list, infos);
            }
        }

        private bool GetData(List<AlertInfo> list, List<StockInfoShort> infos)
        {
            HTTPDataProvider dataProvider = new HTTPDataProvider();
            if (dataProvider.Connect(null))
            {
                List<string> codes = new List<string>(list.Count);
                foreach (AlertInfo item in list)
                {
                    codes.Add("s_sh" + item.code);
                }

                if (!dataProvider.GetStockInfoList(codes, infos))
                {
                    dataProvider.Disconnect();
                    return false;
                }

                dataProvider.Disconnect();
            }

            return true;
        }

        private void UpdateAlertList(List<AlertInfo> list, List<StockInfoShort> infos)
        {
            lock(listLocker)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    list[i].name = infos[i].name;
                    list[i].price = float.Parse(infos[i].price);
                    list[i].last = float.Parse(infos[i].price) - float.Parse(infos[i].changePrice);
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnStop.Enabled = true;

            bgwListView.RunWorkerAsync(alertList);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStop.Enabled = false;

            bgwListView.CancelAsync();
        }

        private void bgwListView_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            if (worker == null) return;

            RetrieveAlertInfo(alertList, worker, e);
        }

        private void bgwListView_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            UpdateListView(alertList);
        }

        private void bgwListView_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }

        private void RetrieveAlertInfo(List<AlertInfo> list, BackgroundWorker worker, DoWorkEventArgs e)
        {
            try
            {
                // get stock name, price, and change value
                List<StockInfoShort> infos = new List<StockInfoShort>(list.Count);
                HTTPDataProvider dataProvider = new HTTPDataProvider();
                if (dataProvider.Connect(null))
                {
                    List<string> codes = new List<string>(list.Count);
                    foreach (AlertInfo item in list)
                    {
                        codes.Add("s_sh" + item.code);
                    }

                    while (true)
                    {
                        if (worker.CancellationPending)
                        {
                            e.Cancel = true;
                            break;
                        }

                        infos.Clear();
                        if(dataProvider.GetStockInfoList(codes, infos))
                        {
                            UpdateAlertList(list, infos);

                            worker.ReportProgress(1);
                        }
                        
                        Thread.Sleep(500);
                    }

                    dataProvider.Disconnect();
                }

            }
            catch (Exception eX)
            {
                MessageBox.Show(eX.Message);
            }
        }

        private void AlertForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            bgwListView.CancelAsync();
        }
    }
}