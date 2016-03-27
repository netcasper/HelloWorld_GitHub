using System.Collections.Generic;
using WWStock.Core;

namespace WWStock.Data
{
    public class WSDataProvider: IDataProvider
    {
        private DataProvider.ChinaStockWebService wsProvider;
        private readonly string[] defination = {"��Ʊ����", 
                                                "��Ʊ����", 
                                                "����ʱ��", 
                                                "���¼۸�", 
                                                "��������", 
                                                "���տ���", 
                                                "�ǵ��Ԫ��", 
                                                "���", 
                                                "���", 
                                                "�ǵ�����%��", 
                                                "�ɽ������֣�", 
                                                "�ɽ����Ԫ��", 
                                                "����۸�", 
                                                "�����۸�", 
                                                "ί�ȣ�%��", 
                                                "��һ", 
                                                "���", 
                                                "����", 
                                                "����", 
                                                "����", 
                                                "��һ", 
                                                "����", 
                                                "����", 
                                                "����", 
                                                "����" };

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
                strDataInfo += defination[i] + "��" + lst[i] + "\n";
            }

            return true;
        }
    }
}
