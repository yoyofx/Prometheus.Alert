using Prometheus.Alert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlertDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            AlertClient.SetOpation(new AlertOpation
            {
                AppId = "chejiatiantianbao",
                Service = "service399",
                Url = "http://172.20.12.58:9093/api/v1/alerts"
            });

            Task.Run(async () =>
            {
                 await AlertClient.SendAlertAsync("测试报错1", "参数", null,new Exception("错误1"));

            }).GetAwaiter().GetResult();


       


        }
    }
}
