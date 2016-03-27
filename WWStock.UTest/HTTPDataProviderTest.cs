using System;
using WWStock.Data;
using NUnit.Framework;

namespace WWStock.UTest
{
    [TestFixture]
    public class HTTPDataProviderTest
    {
        private HTTPDataProvider dataProvider;

        [SetUp]
        public void SetUp()
        {
            dataProvider = new HTTPDataProvider();    
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void GetTypeTest()
        {
            //Assert.AreEqual(InfoType.Unknown, dataProvider.GetInfoType(""));
            //Assert.AreEqual(InfoType.Unknown, dataProvider.GetInfoType("1234567890"));
            //Assert.AreEqual(InfoType.Simple, dataProvider.GetInfoType("s_sh000001"));
            //Assert.AreEqual(InfoType.Simple, dataProvider.GetInfoType("s_sz399001"));
            //Assert.AreEqual(InfoType.Simple, dataProvider.GetInfoType("S_SH000001"));
            //Assert.AreEqual(InfoType.Simple, dataProvider.GetInfoType("S_SZ399001"));
            //Assert.AreEqual(InfoType.Simple, dataProvider.GetInfoType("s_sh000000"));
            //Assert.AreEqual(InfoType.Simple, dataProvider.GetInfoType("s_sz000000"));
            //Assert.AreEqual(InfoType.Simple, dataProvider.GetInfoType("s_sz000001"));
            //Assert.AreEqual(InfoType.Full, dataProvider.GetInfoType("sh600001"));
            //Assert.AreEqual(InfoType.Full, dataProvider.GetInfoType("sz000001"));
            //Assert.AreEqual(InfoType.Full, dataProvider.GetInfoType("SH600001"));
            //Assert.AreEqual(InfoType.Full, dataProvider.GetInfoType("SZ000001"));
            //Assert.AreEqual(InfoType.Unknown, dataProvider.GetInfoType("sS600001"));
            //Assert.AreEqual(InfoType.Unknown, dataProvider.GetInfoType("Zs000001"));
            //Assert.AreEqual(InfoType.Unknown, dataProvider.GetInfoType("sha00001"));
            //Assert.AreEqual(InfoType.Unknown, dataProvider.GetInfoType("sza00001"));
            //Assert.AreEqual(InfoType.Unknown, dataProvider.GetInfoType("sz0000001"));
        }

        [Test]
        public void CheckDateTimeTest()
        {
            Assert.AreEqual(false, HTTPDataProvider.CheckDateTime(DateTime.Parse("2008-11-22 09:30:00")));
            Assert.AreEqual(false, HTTPDataProvider.CheckDateTime(DateTime.Parse("2008-11-23 09:30:00")));

            Assert.AreEqual(true, HTTPDataProvider.CheckDateTime(DateTime.Parse("2008-11-17 09:30:00")));
            Assert.AreEqual(true, HTTPDataProvider.CheckDateTime(DateTime.Parse("2008-11-21 09:30:00")));

            Assert.AreEqual(false, HTTPDataProvider.CheckDateTime(DateTime.Parse("09:09")));
            Assert.AreEqual(false, HTTPDataProvider.CheckDateTime(DateTime.Parse("09:09")));
            Assert.AreEqual(true, HTTPDataProvider.CheckDateTime(DateTime.Parse("09:10")));
            Assert.AreEqual(true, HTTPDataProvider.CheckDateTime(DateTime.Parse("09:11")));
            Assert.AreEqual(true, HTTPDataProvider.CheckDateTime(DateTime.Parse("09:30")));
            Assert.AreEqual(true, HTTPDataProvider.CheckDateTime(DateTime.Parse("11:34")));
            Assert.AreEqual(true, HTTPDataProvider.CheckDateTime(DateTime.Parse("11:35")));
            Assert.AreEqual(false, HTTPDataProvider.CheckDateTime(DateTime.Parse("11:36")));
            Assert.AreEqual(false, HTTPDataProvider.CheckDateTime(DateTime.Parse("12:54")));
            Assert.AreEqual(true, HTTPDataProvider.CheckDateTime(DateTime.Parse("12:55")));
            Assert.AreEqual(true, HTTPDataProvider.CheckDateTime(DateTime.Parse("12:56")));
            Assert.AreEqual(true, HTTPDataProvider.CheckDateTime(DateTime.Parse("15:04")));
            Assert.AreEqual(true, HTTPDataProvider.CheckDateTime(DateTime.Parse("15:05")));
            Assert.AreEqual(false, HTTPDataProvider.CheckDateTime(DateTime.Parse("15:06")));
        }
    }
}
