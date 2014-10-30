using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PavL.Common
{
    public enum ServerityLevel
    {
        Error = 0,
        Warning = 1, 
        Information = 2
    }

    public class LogItem
    {
        public string Summary { get; set; }
        public string Details { get; set; }

        public ServerityLevel Serverity { get; set; }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static LogItem Parse(string serializedLogItem)
        {
            return JsonConvert.DeserializeObject<LogItem>(serializedLogItem);
        }

    }
}
