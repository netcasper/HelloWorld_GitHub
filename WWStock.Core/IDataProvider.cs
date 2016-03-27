using System.Collections.Generic;

namespace WWStock.Core
{
    public interface IDataProvider
    {
        bool Connect(string connectionString);
        void Disconnect();
        bool GetDataInfo(string code, List<string> lstDataInfo);
        bool GetDataInfo(string code, ref string strDataInfo);
    }
}
