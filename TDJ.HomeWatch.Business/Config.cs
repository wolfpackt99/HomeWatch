﻿using System;
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
                var str = ConfigurationSettings.AppSettings["CLOUDAMQP_URL"];
                if (string.IsNullOrEmpty(str))
                {
                    throw new ArgumentNullException("CLOUDAMQP_URL", "value missing from settings file.");
                }
                else
                {
                    return str;
                }
            }        
        }

        public static string SignalRUri
        {
            get
            {
                var str = ConfigurationSettings.AppSettings["SignalRUri"];
                if (string.IsNullOrEmpty(str))
                {
                    throw new ArgumentNullException("SignalRUri", "value missing from settings file.");
                }
                else
                {
                    return str;
                }
            }
        }

        public static string ConsoleID
        {
            get { return "1111100000"; }
        }
    }
}
