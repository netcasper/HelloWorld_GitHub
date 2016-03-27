using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace WWStock.App
{
    public partial class SetupForm : Form
    {
        Dictionary<string, string> stockSH = new Dictionary<string, string>();
        Dictionary<string, string> stockSHIndex = new Dictionary<string, string>();
        Dictionary<string, string> stockSZ = new Dictionary<string, string>();
        Dictionary<string, string> stockSZIndex = new Dictionary<string, string>();
        Dictionary<string, string> stockUser = new Dictionary<string, string>();

        public SetupForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // save selected list
            SaveUserData(Application.StartupPath + "\\StockUser.xml");

            Close();
        }

        private void SaveUserData(string strFileName)
        {
            XmlTextWriter w = new XmlTextWriter(strFileName, Encoding.Unicode);
            w.Formatting = Formatting.Indented;
            w.WriteStartDocument();
            w.WriteStartElement("settings");
            foreach (ListViewItem item in lvSelected.Items)
            {
                w.WriteStartElement("stock");
                w.WriteElementString("code", item.SubItems[0].Text);
                w.WriteElementString("name", item.SubItems[1].Text);
                w.WriteEndElement();
            }
            w.WriteEndElement();
            w.WriteEndDocument();
            w.Close();
        }

        private void SetupForm_Load(object sender, EventArgs e)
        {
            // load stock info files
            LoadDataFile();

            // populate category
            lvCategory.Items.Add(new ListViewItem("上证股票"));
            lvCategory.Items.Add(new ListViewItem("深证股票"));
            lvCategory.Items.Add(new ListViewItem("上证指数"));
            lvCategory.Items.Add(new ListViewItem("深证指数"));

            // populate stock list
            PopulateListView(stockSH, lvStock);

            // populate selected list
            PopulateListView(stockUser, lvSelected);
        }

        private void PopulateListView(Dictionary<string, string> dict, ListView lv)
        {
            foreach (KeyValuePair<string, string> pair in dict)
            {
                ListViewItem item = new ListViewItem(pair.Key);
                item.SubItems.Add(pair.Value);
                lv.Items.Add(item);
            }
        }

        private void LoadDataFile()
        {
            PopulateDictionary(Application.StartupPath + "\\StockSH.xml", stockSH);
            PopulateDictionary(Application.StartupPath + "\\StockSHIndex.xml", stockSHIndex);
            PopulateDictionary(Application.StartupPath + "\\StockSZ.xml", stockSZ);
            PopulateDictionary(Application.StartupPath + "\\StockSZIndex.xml", stockSZIndex);
            PopulateDictionary(Application.StartupPath + "\\StockUser.xml", stockUser);
        }

        private bool PopulateDictionary(string strFileName, Dictionary<string, string> dict)
        {
            try
            {
                dict.Clear();
                string code = "";
                string name = "";

                XmlDocument doc = new XmlDocument();
                doc.Load(strFileName);
                XmlNodeList nodes = doc.GetElementsByTagName("stock");

                foreach (XmlNode node in nodes)
                {
                    foreach (XmlNode childNode in node.ChildNodes)
                    {
                        if (childNode.Name == "code")
                        {
                            code = childNode.InnerText;
                        }
                        if (childNode.Name == "name")
                        {
                            name = childNode.InnerText;
                        }
                    }

                    dict.Add(code, name);
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private void lvCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvStock.Items.Clear();

            if (lvCategory.SelectedItems.Count < 1) return;

            switch (lvCategory.SelectedItems[0].Index)
            {
                case 0:
                    PopulateListView(stockSH, lvStock);
                    break;
                case 1:
                    PopulateListView(stockSZ, lvStock);
                    break;
                case 2:
                    PopulateListView(stockSHIndex, lvStock);
                    break;
                case 3:
                    PopulateListView(stockSZIndex, lvStock);
                    break;
                default:
                    break;
            }
        }

        private void lvStock_DoubleClick(object sender, EventArgs e)
        {
            if (!CheckExistence(lvStock.SelectedItems[0], lvSelected))
            {
                lvSelected.Items.Add((ListViewItem)lvStock.SelectedItems[0].Clone());
            }
        }

        private void lvSelected_DoubleClick(object sender, EventArgs e)
        {
            lvSelected.Items.Remove(lvSelected.SelectedItems[0]);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvStock.SelectedItems)
            {
                if (!CheckExistence(item, lvSelected))
                {
                    lvSelected.Items.Add((ListViewItem)item.Clone());
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvSelected.SelectedItems)
            {
                lvSelected.Items.Remove(item);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            lvSelected.Items.Clear();
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {

        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {

        }

        private bool CheckExistence(ListViewItem lvi, ListView lv)
        {
            foreach (ListViewItem item in lv.Items)
            {
                if (item.Text.CompareTo(lvi.Text) == 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}