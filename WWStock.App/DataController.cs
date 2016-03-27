using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;

namespace WWStock.App
{
    internal class DataController
    {
        private Dictionary<string, string> currentData = new Dictionary<string, string>();
        public Dictionary<string, string> CurrentData
        {
            get { return currentData; }
            set { currentData = value; }
        }

        private List<string> stockKeyList = new List<string>();
        public List<string> StockKeyList
        {
            get { return stockKeyList; }
            set { stockKeyList = value; }
        }

        private Dictionary<string, string> stockSH = new Dictionary<string, string>();
	    public Dictionary<string, string> StockSH
	    {
		    get { return stockSH; }
		    set { stockSH = value; }
	    }

        private Dictionary<string, string> stockSHIndex = new Dictionary<string, string>();
	    public Dictionary<string, string> StockSHIndex
	    {
		    get { return stockSHIndex; }
		    set { stockSHIndex = value; }
	    }

        private Dictionary<string, string> stockSZ = new Dictionary<string, string>();
	    public Dictionary<string, string> StockSZ
	    {
		    get { return stockSZ; }
		    set { stockSZ = value; }
	    }

        private Dictionary<string, string> stockSZIndex = new Dictionary<string, string>();
	    public Dictionary<string, string> StockSZIndex
	    {
		    get { return stockSZIndex; }
		    set { stockSZIndex = value; }
	    }

        private Dictionary<string, string> stockUser = new Dictionary<string, string>();
	    public Dictionary<string, string> StockUser
	    {
		    get { return stockUser; }
		    set { stockUser = value; }
	    }

        private static Object m_lock = new Object();
        private static DataController instance;
	    public static DataController Instance
	    {
		    get
            {
                if (instance == null)
                {
                    lock (m_lock)
                    {
                        if (instance == null)
                        {
                            instance = new DataController();
                        }
                    }

                }

                return instance; 
            }
	    }

        private DataController()
        {
        }

        public void LoadData()
        {
            PopulateDictionary(Application.StartupPath + "\\StockSH.xml", stockSH);
            PopulateDictionary(Application.StartupPath + "\\StockSHIndex.xml", stockSHIndex);
            PopulateDictionary(Application.StartupPath + "\\StockSZ.xml", stockSZ);
            PopulateDictionary(Application.StartupPath + "\\StockSZIndex.xml", stockSZIndex);
            PopulateDictionary(Application.StartupPath + "\\StockUser.xml", stockUser);

            PopulateKeyList(stockKeyList, stockSH);
            PopulateKeyList(stockKeyList, stockSZ);
        }

        private void PopulateKeyList(List<string> keyList, Dictionary<string, string> dictStock)
        {
            if (keyList == null) return;

            foreach (KeyValuePair<string, string> pair in dictStock)
            {
                keyList.Add(pair.Key.Substring(2) + "    " + pair.Value);
                keyList.Add(GetPYString(pair.Value).ToUpper() + "    " + pair.Key.Substring(2) + "  " + pair.Value);
            }
        }

        private string GetPYString(string str)
        {
            string tempStr = "";
            foreach (char c in str)
            {
                tempStr += (c >= 33 && c <= 126) ? c.ToString() : GetPYChar(c.ToString());
            }

            return tempStr;
        }

        private string GetPYChar(string str)
        {
            byte[] array = new byte[2];
            array = Encoding.Default.GetBytes(str);
            int i = (short)(array[0] - '\0') * 256 + ((short)(array[1] - '\0'));
            if (i < 0xB0A1) return "*";
            if (i < 0xB0C5) return "a";
            if (i < 0xB2C1) return "b";
            if (i < 0xB4EE) return "c";
            if (i < 0xB6EA) return "d";
            if (i < 0xB7A2) return "e";
            if (i < 0xB8C1) return "f";
            if (i < 0xB9FE) return "g";
            if (i < 0xBBF7) return "h";
            if (i < 0xBFA6) return "g";
            if (i < 0xC0AC) return "k";
            if (i < 0xC2E8) return "l";
            if (i < 0xC4C3) return "m";
            if (i < 0xC5B6) return "n";
            if (i < 0xC5BE) return "o";
            if (i < 0xC6DA) return "p";
            if (i < 0xC8BB) return "q";
            if (i < 0xC8F6) return "r";
            if (i < 0xCBFA) return "s";
            if (i < 0xCDDA) return "t";
            if (i < 0xCEF4) return "w";
            if (i < 0xD1B9) return "x";
            if (i < 0xD4D1) return "y";
            if (i < 0xD7FA) return "z";
            return "?";
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

        public bool ConvertFiles()
        {
            if (!ConvertStockDataFile(Application.StartupPath + "\\SH0701.csv", Application.StartupPath + "\\SZZS200701.xml"))
            {
                return false;
            }
            if (!ConvertStockDataFile(Application.StartupPath + "\\SH0702.csv", Application.StartupPath + "\\SZZS200702.xml"))
            {
                return false;
            }
            if (!ConvertStockDataFile(Application.StartupPath + "\\SH0703.csv", Application.StartupPath + "\\SZZS200703.xml"))
            {
                return false;
            }
            if (!ConvertStockDataFile(Application.StartupPath + "\\SH0704.csv", Application.StartupPath + "\\SZZS200704.xml"))
            {
                return false;
            }
            if (!ConvertStockDataFile(Application.StartupPath + "\\SH0705.csv", Application.StartupPath + "\\SZZS200705.xml"))
            {
                return false;
            }
            if (!ConvertStockDataFile(Application.StartupPath + "\\SH0706.csv", Application.StartupPath + "\\SZZS200706.xml"))
            {
                return false;
            }

            return true;
        }

        private bool ConvertStockDataFile(string fileNameSrc, string fileNameDst)
        {
            //List<StockItemMinute> list = new List<StockItemMinute>();
            List<string> list = new List<string>();
            try
            {
                using (StreamReader reader = new StreamReader(fileNameSrc))
                {
                    // read source file
                    string line;
                    reader.ReadLine();
                    while ((line = reader.ReadLine()) != null)
                    {
                        line.Trim();
                        list.AddRange(line.Split(','));
                    }

                    // write xml file
                    XmlTextWriter writer = new XmlTextWriter(fileNameDst, Encoding.UTF8);
                    writer.Formatting = Formatting.Indented;
                    writer.WriteStartDocument();
                        writer.WriteStartElement("stock");
                            writer.WriteStartElement("stockItem");
                                writer.WriteAttributeString("code", "sh000001");
                                writer.WriteAttributeString("name", "上证指数");
                                writer.WriteStartElement("data");

                                    for (int i = 0; i < list.Count / 240 / 7; i++)
                                    {
                                        writer.WriteStartElement("dayData");
                                        string[] datetime = list[i * 240 * 7].Split(' ');
                                        writer.WriteAttributeString("date", datetime[0]);
                                            for (int j = 0; j < 240; j++ )
                                            {
                                                writer.WriteStartElement("minuteData");
                                                    string[] dt = list[i * 240 * 7 + j * 7 + 0].Split(' ');
                                                    string time = dt[1];
                                                    if (time.Length == 4) time = "0" + time;
                                                    writer.WriteElementString("time", time.Substring(0, 5));
                                                    writer.WriteElementString("open", list[i * 240 * 7 + j * 7 + 1]);
                                                    writer.WriteElementString("low", list[i * 240 * 7 + j * 7 + 2]);
                                                    writer.WriteElementString("high", list[i * 240 * 7 + j * 7 + 3]);
                                                    writer.WriteElementString("close", list[i * 240 * 7 + j * 7 + 4]);
                                                    writer.WriteElementString("volume", list[i * 240 * 7 + j * 7 + 5]);
                                                    writer.WriteElementString("amount", list[i * 240 * 7 + j * 7 + 6]);
                                                writer.WriteEndElement();
                                            }
                                        writer.WriteEndElement();
                                    }

                                writer.WriteEndElement();
                            writer.WriteEndElement();
                        writer.WriteEndElement();
                    writer.WriteEndDocument();
                    writer.Close();
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private void FormatXMLData(string srcFileName, string dstFileName)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(srcFileName);

                string last = "";
                XPathNavigator nav = doc.CreateNavigator();
                if (nav == null) return;
                if (nav.CanEdit)
                {
                    XPathNodeIterator dayIter = nav.Select("/stock/stockItem/data/dayData");
                    while (dayIter.MoveNext())
                    {
                        XPathNodeIterator dateIter = dayIter.Current.Select("@date");
                        dateIter.MoveNext();
                        dateIter.Current.InnerXml = DateTime.Parse(dayIter.Current.GetAttribute("date", "")).ToString("yyyy-MM-dd");

                        XPathNodeIterator openIter = dayIter.Current.Select("minuteData[1]/open");
                        openIter.MoveNext();
                        string open = openIter.Current.Value;

                        XPathNodeIterator closeIter = dayIter.Current.Select("minuteData[last()]/close");
                        closeIter.MoveNext();
                        string close = closeIter.Current.Value;

                        string volume = dayIter.Current.Evaluate("sum(minuteData/volume)").ToString();
                        string amount = dayIter.Current.Evaluate("sum(minuteData/amount)").ToString();

                        double maxHigh = 0.0f;
                        XPathNodeIterator highIter = dayIter.Current.Select("minuteData/high");
                        while (highIter.MoveNext())
                        {
                            if (highIter.Current.ValueAsDouble > maxHigh) 
                                maxHigh = highIter.Current.ValueAsDouble;
                        }
                        string high = maxHigh.ToString();

                        double minLow = maxHigh;
                        XPathNodeIterator lowIter = dayIter.Current.Select("minuteData/low");
                        while (lowIter.MoveNext())
                        {
                            if (lowIter.Current.ValueAsDouble < minLow) 
                                minLow = lowIter.Current.ValueAsDouble;
                        }
                        string low = minLow.ToString();

                        double maxVolume = 0;
                        XPathNodeIterator volumeIter = dayIter.Current.Select("minuteData/volume");
                        while (volumeIter.MoveNext())
                        {
                            if (volumeIter.Current.ValueAsDouble > maxVolume)
                                maxVolume = volumeIter.Current.ValueAsDouble;
                        }

                        double maxAmount = 0;
                        XPathNodeIterator amountIter = dayIter.Current.Select("minuteData/amount");
                        while (amountIter.MoveNext())
                        {
                            if (amountIter.Current.ValueAsDouble > maxAmount)
                                maxAmount = amountIter.Current.ValueAsDouble;
                        }

                        dayIter.Current.CreateAttribute("", "last", "", last);
                        dayIter.Current.CreateAttribute("", "open", "", open);
                        dayIter.Current.CreateAttribute("", "low", "", low);
                        dayIter.Current.CreateAttribute("", "high", "", high);
                        dayIter.Current.CreateAttribute("", "close", "", close);
                        dayIter.Current.CreateAttribute("", "volume", "", volume);
                        dayIter.Current.CreateAttribute("", "maxVolume", "", maxVolume.ToString());
                        dayIter.Current.CreateAttribute("", "amount", "", amount);
                        dayIter.Current.CreateAttribute("", "maxAmount", "", maxAmount.ToString());

                        last = close;
                    }
                }

                doc.Save(dstFileName);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void FormatXMLFiles()
        {
            FormatXMLData(Application.StartupPath + "\\SZZS200701.xml", Application.StartupPath + "\\SZIndex200701.xml");
            FormatXMLData(Application.StartupPath + "\\SZZS200702.xml", Application.StartupPath + "\\SZIndex200702.xml");
            FormatXMLData(Application.StartupPath + "\\SZZS200703.xml", Application.StartupPath + "\\SZIndex200703.xml");
            FormatXMLData(Application.StartupPath + "\\SZZS200704.xml", Application.StartupPath + "\\SZIndex200704.xml");
            FormatXMLData(Application.StartupPath + "\\SZZS200705.xml", Application.StartupPath + "\\SZIndex200705.xml");
            FormatXMLData(Application.StartupPath + "\\SZZS200706.xml", Application.StartupPath + "\\SZIndex200706.xml");
        }
    }
}
