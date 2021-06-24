using Microsoft.VisualStudio.TestTools.UnitTesting;
using MRPApp.View.Setting;
using System;
using System.Linq;

namespace MRPApp.Test
{
    [TestClass]
    public class SettingsTest
    {
        // DB상에 중복된 데이터가 있는 지 검색.
        [TestMethod]
        public void IsDuplicateDataTest()
        {
            var expectVal = true;//예상값
            var inputCode = "PC010001";//DB상에 있는 값
            var code = Logic.DataAccess.GetSettings().Where(d => d.BasicCode.Contains(inputCode)).FirstOrDefault();
            bool realVal = code != null ? true:false;


            Assert.AreEqual(expectVal, realVal);//값이 같으면 pass, 다르면 Fail
        }
    }
}
