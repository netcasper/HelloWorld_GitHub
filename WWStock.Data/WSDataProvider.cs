using System.Collections.Generic;
using WWStock.Core;

namespace WWStock.Data
{
    public class WSDataProvider: IDataProvider
    {
        private DataProvider.ChinaStockWebService wsProvider;
        private readonly string[] defination = {"股票代码", 
                                                "股票名称", 
                                                "行情时间", 
                                                "最新价格", 
                                                "昨日收盘", 
                                                "今日开盘", 
                                                "涨跌额（元）", 
                                                "最低", 
                                                "最高", 
                                                "涨跌幅（%）", 
                                                "成交量（手）", 
                                                "成交额（万元）", 
                                                "竞买价格", 
                                                "竞卖价格", 
                                                "委比（%）", 
                                                "买一", 
                                                "买二", 
                                                "买三", 
                                                "买四", 
                                                "买五", 
                                                "卖一", 
                                                "卖二", 
                                                "卖三", 
                                                "卖四", 
                                                "卖五" };

        public bool Connect(string connectionString)
        {
            wsProvider = new DataProvider.ChinaStockWebService();

            return (wsProvider != null) ? true : false;
        }

        public void Disconnect()
        {
        }

        public bool GetDataInfo(string code, List<string> lstDataInfo)
        {
            string[] lst = wsProvider.getStockInfoByCode(code);
            lstDataInfo.Clear();
            lstDataInfo.AddRange(lst);

            return true;
        }

        public bool GetDataInfo(string code, ref string strDataInfo)
        {
            string[] lst = wsProvider.getStockInfoByCode(code);

            if (lst.GetLength(0) != 25)
            {
                return false;
            }

            for (int i = 0; i < 25; i++ )
            {
                strDataInfo += defination[i] + "：" + lst[i] + "\n";
            }

            return true;
        }
    }
}
