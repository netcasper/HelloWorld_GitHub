using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;
using WWStock.Core;
using System.IO;
using Newtonsoft.Json;

// Test for GitHub WWStock, WY_Engine
// test 1

namespace WWStock.Data
{
    public struct StockInfo
    {
        public string code;
        public string name;
        public float price;
        public float last;
        public float open;
        public float high;
        public float low;
        public double volume;
        public double inside;
        public double outside;
        public float amount;
        public float buyPrice;
        public double buyVolume;
        public float sellPrice;
        public double sellVolume;
    }

    public struct StockInfoLong
    {
        public string name;
        public string open;
        public string last;
        public string price;
        public string high;
        public string low;
        public string buy;
        public string sell;
        public string volume;
        public string amount;
        public string buy1Volume;
        public string buy1Price;
        public string buy2Volume;
        public string buy2Price;
        public string buy3Volume;
        public string buy3Price;
        public string buy4Volume;
        public string buy4Price;
        public string buy5Volume;
        public string buy5Price;
        public string sell1Volume;
        public string sell1Price;
        public string sell2Volume;
        public string sell2Price;
        public string sell3Volume;
        public string sell3Price;
        public string sell4Volume;
        public string sell4Price;
        public string sell5Volume;
        public string sell5Price;
        public string date;
        public string time;
    }

    //public struct StockInfoShort
    //{
    //    public string name;
    //    public string price;
    //    public string changePrice;
    //    public string changeRate;
    //    public string volume;
    //    public string amount;
    //}

    //public struct StockInfoShort
    //{
    //    public string number;
    //    public string name;
    //    public string code;
    //    public string price;
    //    public string changePrice;
    //    public string changeRate;
    //    public string volume;
    //    public string amount;
    //    public string padding1;
    //    public string padding2;
    //}

    public struct StockInfoShort
    {
        public string code;
        public string percent;
        public string high;
        public string askvol3;
        public string askvol2;
        public string askvol5;
        public string askvol4;
        public string price;
        public string open;
        public string bid5;
        public string bid4;
        public string bid3;
        public string bid2;
        public string bid1;
        public string low;
        public string updown;
        public string type;
        public string bidvol1;
        public string status;
        public string bidvol3;
        public string bidvol2;
        public string symbol;
        public string update;
        public string bidvol5;
        public string bidvol4;
        public string volume;
        public string askvol1;
        public string ask5;
        public string ask4;
        public string ask1;
        public string name;
        public string ask3;
        public string ask2;
        public string arrow;
        public string time;
        public string yestclose;
        public string turnover;
    }

    public enum InfoType
    {
        Full = 0,
        Simple = 1,
        Unknown = -1,
    }

    internal enum FullInfoIndexer
    {
        Name = 0,
        Open = 1,
        Last = 2,
        Price = 3,
        High = 4,
        Low = 5,
        Buy = 6,
        Sell = 7,
        Volume = 8,
        Amount = 9,
        Buy1Volume = 10,
        Buy1Price = 11,
        Buy2Volume = 12,
        Buy2Price = 13,
        Buy3Volume = 14,
        Buy3Price = 15,
        Buy4Volume = 16,
        Buy4Price = 17,
        Buy5Volume = 18,
        Buy5Price = 19,
        Sell1Volume = 20,
        Sell1Price = 21,
        Sell2Volume = 22,
        Sell2Price = 23,
        Sell3Volume = 24,
        Sell3Price = 25,
        Sell4Volume = 26,
        Sell4Price = 27,
        Sell5Volume = 28,
        Sell5Price = 29,
        Date = 30,
        Time = 31,
    }

    //internal enum SimpleInfoIndexer
    //{
    //    Name = 0,
    //    Price = 1,
    //    ChangePrice = 2,
    //    ChangeRate = 3,
    //    Volume = 4,
    //    Amount = 5,
    //}

    //internal enum SimpleInfoIndexer
    //{
    //    Number = 0,
    //    Name = 1,
    //    Code = 2,
    //    Price = 3,
    //    ChangePrice = 4,
    //    ChangeRate = 5,
    //    Volume = 6,
    //    Amount = 7,
    //    Padding1 = 8,
    //    Padding2 = 9,
    //}

    internal enum SimpleInfoIndexer
    {
        code = 0,
        percent = 1,
        high = 2,
        askvol3 = 3,
        askvol2 = 4,
        askvol5 = 5,
        askvol4 = 6,
        price = 7,
        open = 8,
        bid5 = 9,
        bid4 = 10,
        bid3 = 11,
        bid2 = 12,
        bid1 = 13,
        low = 14,
        updown = 15,
        type = 16,
        bidvol1 = 17,
        status = 18,
        bidvol3 = 19,
        bidvol2 = 20,
        symbol = 21,
        update = 22,
        bidvol5 = 23,
        bidvol4 = 24,
        volume = 25,
        askvol1 = 26,
        ask5 = 27,
        ask4 = 28,
        ask1 = 29,
        name = 30,
        ask3 = 31,
        ask2 = 32,
        arrow = 33,
        time = 34,
        yestclose = 35,
        turnover = 36,
    }

    public class WYStockItem
    {
        public string code { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
        public string update { get; set; }
        public string arrow { get; set; }
        public string time { get; set; }
        public string type { get; set; }
        public float percent { get; set; }
        public float price { get; set; }
        public float yestclose { get; set; }
        public float open { get; set; }
        public float high { get; set; }
        public float low { get; set; }
        public float updown { get; set; }
        public float turnover { get; set; }
        public int status { get; set; }
        public float volume { get; set; } // the value is too big to use int.
        public int askvol1 { get; set; }
        public int askvol2 { get; set; }
        public int askvol3 { get; set; }
        public int askvol4 { get; set; }
        public int askvol5 { get; set; }
        public int bidvol1 { get; set; }
        public int bidvol2 { get; set; }
        public int bidvol3 { get; set; }
        public int bidvol4 { get; set; }
        public int bidvol5 { get; set; }
        public float ask1 { get; set; }
        public float ask2 { get; set; }
        public float ask3 { get; set; }
        public float ask4 { get; set; }
        public float ask5 { get; set; }
        public float bid1 { get; set; }
        public float bid2 { get; set; }
        public float bid3 { get; set; }
        public float bid4 { get; set; }
        public float bid5 { get; set; }

        // the following 2 fields only exist in 510xxx
        public float precloseiopv { get; set; }
        public float iopv { get; set; }
    }

    public class HTTPDataProvider : IDataProvider
    {      
        public static readonly int MAXSTOCKITEMS = 100;
        //private readonly int SIMPLEFIELDCOUNT = 6;
        //private readonly int SIMPLEFIELDCOUNT = 10;
        private readonly int SIMPLEFIELDCOUNT = 37;
        private readonly int FULLFIELDCOUNT = 32;
        private readonly Regex fullRule = new Regex(@"S[H|Z][0-9]{6}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private readonly Regex simpleRule = new Regex(@"S_S[H|Z][0-9]{6}", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        //private readonly string prefix = @"http://hq.sinajs.cn/list=";
        //private readonly string prefix = @"http://qt.gtimg.cn/q=";
        private readonly string prefix = @"http://api.money.126.net/data/feed/";

        private readonly string[] definationFull = {
                                                "股票名称",
                                                "今日开盘",
                                                "昨日收盘",
                                                "当前价格",
                                                "最高价格",
                                                "最低价格",
                                                "竞买价格",
                                                "竞卖价格",
                                                "成交手数",
                                                "成交万元",
                                                "买一手数",
                                                "买一价格",
                                                "买二手数",
                                                "买二价格",
                                                "买三手数",
                                                "买三价格",
                                                "买四手数",
                                                "买四价格",
                                                "买五手数",
                                                "买五价格",
                                                "卖一手数",
                                                "卖一价格",
                                                "卖二手数",
                                                "卖二价格",
                                                "卖三手数",
                                                "卖三价格",
                                                "卖四手数",
                                                "卖四价格",
                                                "卖五手数",
                                                "卖五价格",
                                                "当前日期",
                                                "当前时间" 
                                              };

        private readonly string[] definationSimple = {
                                                  "股票名称",
                                                  "当前价格",
                                                  "涨跌价格",
                                                  "涨跌幅度",
                                                  "成交手数",
                                                  "成交万元"
                                              };

        public bool Connect(string connectionString)
        {
            return true;
        }

        public void Disconnect()
        {
        }

        private InfoType GetInfoType(string code)
        {
            if (string.IsNullOrEmpty(code)) 
                return InfoType.Unknown;

            if (code.Length == 8 && fullRule.IsMatch(code)) 
                return InfoType.Full;

            //if (code.Length == 10 && simpleRule.IsMatch(code))
            if (code.Length == 7)
                    return InfoType.Simple;

            return InfoType.Unknown;
        }

        private InfoType GetInfoType(List<string> codes)
        {
            if (codes == null) return InfoType.Unknown;
            if (codes.Count < 1) return InfoType.Unknown;

            InfoType infoType = GetInfoType(codes[0]);
            foreach (string code in codes)
            {
                if (GetInfoType(code) != infoType)
                {
                    return InfoType.Unknown;
                }
            }

            return infoType;
        }

        private bool GetDataInfoFromWeb(string url, ref string strDataInfo)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url.ToLower());
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                Stream receiveStream = response.GetResponseStream();
                Encoding encode = Encoding.GetEncoding("GBK");
                StreamReader readStream = new StreamReader(receiveStream, encode);
                strDataInfo = readStream.ReadToEnd();

                //char[] read = new Char[BUFFERSIZE];
                //int count = readStream.Read(read, 0, BUFFERSIZE);

                //StringBuilder sb = new StringBuilder();
                //while (count > 0)
                //{
                //    sb.Append(new string(read, 0, count));
                //    count = readStream.Read(read, 0, BUFFERSIZE);
                //}
                //strDataInfo = sb.ToString();

                readStream.Close();
                response.Close();
            }
            catch (Exception)
            {
                //MessageBox.Show(e.Message);
                return false;
            }

            return true;
        }

        public bool GetDataInfo(string code, List<WYStockItem> lstWYStockItem)
        {
            return GetDataInfo(GetInfoType(code), code, lstWYStockItem);
        }

        public bool GetDataInfo(string code, List<string> lstDataInfo)
        {
            return true;
        }

        private bool GetDataInfo(InfoType infoType, string code, List<WYStockItem> lstWYStockItem)
        {
            string strDataInfo = "";
            if (!GetDataInfoFromWeb(prefix + code, ref strDataInfo))
            {
                return false;
            }

            if (!ParseDataInfo(infoType, strDataInfo, lstWYStockItem))
            {
                return false;
            }

            return true;
        }

        public bool GetDataInfo(string code, ref string strDataInfo)
        {
            InfoType infoType = GetInfoType(code);
            if (infoType == InfoType.Unknown)
            {
                return false;
            }

            List<WYStockItem> lstWYStockItem = new List<WYStockItem>();
            if (!GetDataInfo(code, lstWYStockItem))
            {
                return false;
            }

            strDataInfo = BuildDataInfo(lstWYStockItem);

            return true;
        }

        private bool ParseDataInfo(InfoType infoType, string strDataInfo, List<WYStockItem> lstWYStockItem)
        {
            if (infoType == InfoType.Unknown || string.IsNullOrEmpty(strDataInfo))
            {
                return false;
            }

            int nFieldCount;
            switch (infoType)
            {
                case InfoType.Full:
                    nFieldCount = FULLFIELDCOUNT;
                    break;

                case InfoType.Simple:
                    nFieldCount = SIMPLEFIELDCOUNT;
                    break;

                default:
                    return false;
            }

            //strDataInfo = strDataInfo.Trim("_ntes_quote_callback");
            strDataInfo = strDataInfo.Trim().TrimStart(@"_ntes_quote_callback({".ToCharArray()).TrimEnd(@"} });".ToCharArray());
            string[] infos = strDataInfo.Split('}');
            if (infos.Length > 0)
            {
                for (int i = 0; i < infos.Length; i++ )
                {
                    string[] jsonItem = infos[i].Split('{');
                    WYStockItem item = JsonConvert.DeserializeObject<WYStockItem>("{" + jsonItem[1] + "}");
                    lstWYStockItem.Add(item);
                }
            } 
            else
            {
                return false;
            }

            return true;
        }

        private string BuildDataInfo(List<WYStockItem> lstInfo)
        {
            if (lstInfo == null) return null;
            if (lstInfo.Count != SIMPLEFIELDCOUNT && lstInfo.Count != FULLFIELDCOUNT) return null;

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < lstInfo.Count; i++)
            {
                sb.Append(((lstInfo.Count != SIMPLEFIELDCOUNT) ? definationSimple[i] : definationFull[i]) + "：" + lstInfo[i] + "\n");
            }

            return sb.ToString();
        }

        public static bool CheckDateTime(DateTime dt)
        {
            if (dt.DayOfWeek.Equals(DayOfWeek.Saturday)) return false;
            if (dt.DayOfWeek.Equals(DayOfWeek.Sunday)) return false;
            if (dt.ToString("HH:mm").CompareTo("09:10") < 0) return false;
            if (dt.ToString("HH:mm").CompareTo("15:05") > 0) return false;
            if (dt.ToString("HH:mm").CompareTo("11:35") > 0 && dt.ToString("HH:mm").CompareTo("12:55") < 0) return false;

            return true;
        }

        public bool GetStockInfoList(List<string> codes, List<StockInfoShort> infos)
        {
            if (codes == null) return false;
            if (codes.Count < 1) return false;
            if (GetInfoType(codes) != InfoType.Simple) return false;

            int i = 0;
            do
            {
                int nCount = (i < codes.Count / MAXSTOCKITEMS) ? (MAXSTOCKITEMS) : (codes.Count % MAXSTOCKITEMS);
                if (nCount == 0) continue;
                if (!GetStockInfoListBlock(codes.GetRange(i * MAXSTOCKITEMS, nCount), infos))
                {
                    return false;
                }
            } while (++i < codes.Count / MAXSTOCKITEMS + 1);

            return (codes.Count == infos.Count);
        }

        public bool GetStockInfoListBlock(List<string> codes, List<StockInfoShort> infos)
        {
            if (codes == null) return false;
            if (codes.Count < 1 || codes.Count > MAXSTOCKITEMS) return false;

            StringBuilder sb = new StringBuilder();
            foreach (string code in codes)
            {
                sb.Append(code + ",");
            }
            string strCodes = sb.ToString();

            List<WYStockItem> lstWYStockItem = new List<WYStockItem>();
            if (!GetDataInfo(InfoType.Simple, strCodes, lstWYStockItem))
            {
                return false;
            }

            BuildStockInfoList(codes, lstWYStockItem, infos);

            return true;
        }


        private void BuildStockInfoList(List<string> codes, List<WYStockItem> lstDataInfo, List<StockInfoShort> infos)
        {
            foreach(WYStockItem item in lstDataInfo)
            {
                StockInfoShort stockItem = new StockInfoShort();
                stockItem.price = item.price.ToString();
                stockItem.percent = item.percent.ToString();
                stockItem.volume = item.volume.ToString();
                stockItem.turnover = item.turnover.ToString();
                infos.Add(stockItem);

            }
        }

        private void BuildStockInfoList(List<string> codes, List<string> lstDataInfo, List<StockInfoLong> infos)
        {
            for (int i = 0; i < codes.Count; i++)
            {
                List<string> lstDataInfoItem = lstDataInfo.GetRange(i * FULLFIELDCOUNT, FULLFIELDCOUNT);
                infos.Add(BuildStockInfoLong(lstDataInfoItem));
            }
        }

        private StockInfoShort BuildStockInfoShort(List<string> lstDataInfo)
        {
            StockInfoShort info;
            info.code = lstDataInfo[(int)SimpleInfoIndexer.code];
            info.percent = lstDataInfo[(int)SimpleInfoIndexer.percent];
            info.high = lstDataInfo[(int)SimpleInfoIndexer.high];
            info.askvol3 = lstDataInfo[(int)SimpleInfoIndexer.askvol3];
            info.askvol2 = lstDataInfo[(int)SimpleInfoIndexer.askvol2];
            info.askvol5 = lstDataInfo[(int)SimpleInfoIndexer.askvol5];
            info.askvol4 = lstDataInfo[(int)SimpleInfoIndexer.askvol4];
            info.price = lstDataInfo[(int)SimpleInfoIndexer.price];
            info.open = lstDataInfo[(int)SimpleInfoIndexer.open];
            info.bid5 = lstDataInfo[(int)SimpleInfoIndexer.bid5];
            info.bid4 = lstDataInfo[(int)SimpleInfoIndexer.bid4];
            info.bid3 = lstDataInfo[(int)SimpleInfoIndexer.bid3];
            info.bid2 = lstDataInfo[(int)SimpleInfoIndexer.bid2];
            info.bid1 = lstDataInfo[(int)SimpleInfoIndexer.bid1];
            info.low = lstDataInfo[(int)SimpleInfoIndexer.low];
            info.updown = lstDataInfo[(int)SimpleInfoIndexer.updown];
            info.type = lstDataInfo[(int)SimpleInfoIndexer.type];
            info.bidvol1 = lstDataInfo[(int)SimpleInfoIndexer.bidvol1];
            info.status = lstDataInfo[(int)SimpleInfoIndexer.status];
            info.bidvol3 = lstDataInfo[(int)SimpleInfoIndexer.bidvol3];
            info.bidvol2 = lstDataInfo[(int)SimpleInfoIndexer.bidvol2];
            info.symbol = lstDataInfo[(int)SimpleInfoIndexer.symbol];
            info.update = lstDataInfo[(int)SimpleInfoIndexer.update];
            info.bidvol5 = lstDataInfo[(int)SimpleInfoIndexer.bidvol5];
            info.bidvol4 = lstDataInfo[(int)SimpleInfoIndexer.bidvol4];
            info.volume = lstDataInfo[(int)SimpleInfoIndexer.volume];
            info.askvol1 = lstDataInfo[(int)SimpleInfoIndexer.askvol1];
            info.ask5 = lstDataInfo[(int)SimpleInfoIndexer.ask5];
            info.ask4 = lstDataInfo[(int)SimpleInfoIndexer.ask4];
            info.ask1 = lstDataInfo[(int)SimpleInfoIndexer.ask1];
            info.name = lstDataInfo[(int)SimpleInfoIndexer.name];
            info.ask3 = lstDataInfo[(int)SimpleInfoIndexer.ask3];
            info.ask2 = lstDataInfo[(int)SimpleInfoIndexer.ask2];
            info.arrow = lstDataInfo[(int)SimpleInfoIndexer.arrow];
            info.time = lstDataInfo[(int)SimpleInfoIndexer.time];
            info.yestclose = lstDataInfo[(int)SimpleInfoIndexer.yestclose];
            info.turnover = lstDataInfo[(int)SimpleInfoIndexer.turnover];

            return info;
        }

        private StockInfoLong BuildStockInfoLong(List<string> lstDataInfo)
        {
            StockInfoLong info;
            info.name = lstDataInfo[(int)FullInfoIndexer.Name];
            info.open = lstDataInfo[(int)FullInfoIndexer.Open];
            info.last = lstDataInfo[(int)FullInfoIndexer.Last];
            info.price = lstDataInfo[(int)FullInfoIndexer.Price];
            info.high = lstDataInfo[(int)FullInfoIndexer.High];
            info.low = lstDataInfo[(int)FullInfoIndexer.Low];
            info.buy = lstDataInfo[(int)FullInfoIndexer.Buy];
            info.sell = lstDataInfo[(int)FullInfoIndexer.Sell];
            info.volume = lstDataInfo[(int)FullInfoIndexer.Volume];
            info.amount = lstDataInfo[(int)FullInfoIndexer.Amount];
            info.buy1Volume = lstDataInfo[(int)FullInfoIndexer.Buy1Volume];
            info.buy1Price = lstDataInfo[(int)FullInfoIndexer.Buy1Price];
            info.buy2Volume = lstDataInfo[(int)FullInfoIndexer.Buy2Volume];
            info.buy2Price = lstDataInfo[(int)FullInfoIndexer.Buy2Price];
            info.buy3Volume = lstDataInfo[(int)FullInfoIndexer.Buy3Volume];
            info.buy3Price = lstDataInfo[(int)FullInfoIndexer.Buy3Price];
            info.buy4Volume = lstDataInfo[(int)FullInfoIndexer.Buy4Volume];
            info.buy4Price = lstDataInfo[(int)FullInfoIndexer.Buy4Price];
            info.buy5Volume = lstDataInfo[(int)FullInfoIndexer.Buy5Volume];
            info.buy5Price = lstDataInfo[(int)FullInfoIndexer.Buy5Price];
            info.sell1Volume = lstDataInfo[(int)FullInfoIndexer.Sell1Volume];
            info.sell1Price = lstDataInfo[(int)FullInfoIndexer.Sell1Price];
            info.sell2Volume = lstDataInfo[(int)FullInfoIndexer.Sell2Volume];
            info.sell2Price = lstDataInfo[(int)FullInfoIndexer.Sell2Price];
            info.sell3Volume = lstDataInfo[(int)FullInfoIndexer.Sell3Volume];
            info.sell3Price = lstDataInfo[(int)FullInfoIndexer.Sell3Price];
            info.sell4Volume = lstDataInfo[(int)FullInfoIndexer.Sell4Volume];
            info.sell4Price = lstDataInfo[(int)FullInfoIndexer.Sell4Price];
            info.sell5Volume = lstDataInfo[(int)FullInfoIndexer.Sell5Volume];
            info.sell5Price = lstDataInfo[(int)FullInfoIndexer.Sell5Price];
            info.date = lstDataInfo[(int)FullInfoIndexer.Date];
            info.time = lstDataInfo[(int)FullInfoIndexer.Time];

            return info;
        }
    }
}
