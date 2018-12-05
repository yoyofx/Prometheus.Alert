using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prometheus.Alert
{
    public class AlertRequest
    {
        public Dictionary<string, string> labels { set; get; }

        public Dictionary<string, string> annotations { set; get; }

        public DateTime startsAt { set; get; }

        public DateTime endsAt { set; get; }

        public string generatorURL { set; get; }

        public AlertRequest()
        {
            this.labels = new Dictionary<string, string>();
            this.annotations = new Dictionary<string, string>();
        }


    }


    public class AlertReponse{
        public string status { set; get; }
    }

}
