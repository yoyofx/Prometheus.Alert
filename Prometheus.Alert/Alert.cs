using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prometheus.Alert
{

    public class AlertOpation
    {
        public string AppId { set; get; }

        public string Service { set; get; }

        public string Url { set; get; }

    }


    public class AlertClient
    {
        private static AlertOpation Opation;

        public static void SetOpation(AlertOpation opation)
        {
            Opation = opation;
        }

        public static async Task<bool> SendAlertAsync(string alertUrl, AlertRequest alertInfo)
        {
            alertInfo.startsAt = DateTime.Now;
            //alertInfo.endsAt = DateTime.Now;

            string postJson = JsonConvert.SerializeObject(new object[] { alertInfo },
                            new JsonSerializerSettings {  DateTimeZoneHandling = DateTimeZoneHandling.Utc });


            string responseJson = await HttpHelper.HttpPostAsync(alertUrl, postJson, "application/json");

            var alertReponse = JsonConvert.DeserializeObject<AlertReponse>(responseJson);


            return alertReponse.status == "success";
        }

        /// <summary>
        /// 异步发送错误报警邮件
        /// </summary>
        /// <param name="title">报警标题</param>
        /// <param name="requestparam">请求参数</param>
        /// <param name="errorMessage">报警信息</param>
        /// <param name="exception">异常信息(如异常则报警信息无效)</param>
        /// <param name="annotations">其它附加信息(如IP，HOST，URL等)</param>
        /// <returns></returns>
        public static async Task<bool> SendAlertAsync(string title,string requestparam, string errorMessage,Exception exception = null,Dictionary<string,string> annotations=null)
        {
            AlertRequest alertRequest = new AlertRequest();
            alertRequest.labels.Add("appid", Opation.AppId);
            alertRequest.labels.Add("service", Opation.Service);
            alertRequest.labels.Add("title", title);
            alertRequest.labels.Add("time", DateTime.Now.Ticks.ToString());
            string errorMsg = errorMessage;
            if (exception != null)
                errorMsg = exception.Message;

            alertRequest.annotations.Add("requestparam", requestparam);
            alertRequest.annotations.Add("errormessage", errorMsg);
            alertRequest.annotations.Add("stacktrace", exception.StackTrace);

            if (annotations != null)
            {
                foreach(var ann in annotations)
                {
                    alertRequest.annotations.Add(ann.Key, ann.Value);
                }
            }

            return await SendAlertAsync(Opation.Url, alertRequest);

        }




    }
}
