using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prometheus.Alert;
using System;
using System.Threading.Tasks;

namespace AlertUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void alertTest()
        {
            AlertClient.SetOpation(new AlertOpation
            {
                AppId = "chejiatiantianbao",
                Service = "service399",
                Url = "http://172.20.12.58:9093/api/v1/alerts"
            });

            Exception ex = null;
            try
            {
                var a = 0;
               var d=  1 / a;
            }
            catch(Exception e)
            {
                ex = e;
            }


            Task.Run(async () =>
            {

                for (int i = 0; i < 5; i++)
                {

                    bool ss = await AlertClient.SendAlertAsync("²âÊÔ±¨´í1", "²ÎÊý:" + i.ToString(), null, ex);
                    Assert.IsTrue(ss);
                }
                // Actual test code here.
            }).GetAwaiter().GetResult();


         


        }
    }
}
