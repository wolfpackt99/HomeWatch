using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDJ.HomeWatch.Business
{
    public static class Config
    {
        public static string RabbitUri
        {
            get 
            {
                var str = ConfigurationSettings.AppSettings["RabbitUri"];
                if (string.IsNullOrEmpty(str))
                {
                    return "localhost";
                }
                else
                {
#if DEBUG
                    str = "localhost";
#endif
                    return str;
                }
            }        
        }
    }
}
