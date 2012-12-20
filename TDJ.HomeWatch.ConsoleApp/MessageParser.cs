using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TDJ.HomeWatch.ConsoleApp
{
    public class MessageParser
    {
        private string _message;
        private string _regexPattern;

        public Message Msg { get; set; }

        public MessageParser(string message)
        {
            _message = message;
            _regexPattern = "(\"(?:[^\"]|\"\")*\"|[^,]*),(\"(?:[^\"]|\"\")*\"|[^,]*),(\"(?:[^\"]|\"\")*\"|[^,]*),(\"(?:[^\"]|\"\")*\"|[^,]*)";
        }

        public string[] Process()
        {
            var m = new List<Message>();
            var strArrays = Regex.Split(this._message, this._regexPattern);
            if (strArrays.Length == 6)
            {
                uint num1 = 0;
                try
                {
                    string str = strArrays[3].Substring(3, 8);
                    num1 = Convert.ToUInt32(str, 16);
                    Debug.WriteLine("num1: {0}", num1);
                }
                catch
                {
                    Debug.WriteLine(string.Format("Bad packet or parse error: '{0}'", this._message));
                }
                if ((0xFF80 & num1) > 0)
                {
                    Message empty = new Message();
                    empty.Text = string.Empty;
                    try
                    {
                        empty.Ready = Convert.ToBoolean(Convert.ToInt16(strArrays[1].Substring(1, 1)));
                        empty.Armed_Away = Convert.ToBoolean(Convert.ToInt16(strArrays[1].Substring(2, 1)));
                        empty.Armed_Home = Convert.ToBoolean(Convert.ToInt16(strArrays[1].Substring(3, 1)));
                        empty.Back_Light = Convert.ToBoolean(Convert.ToInt16(strArrays[1].Substring(4, 1)));
                        empty.Programming_Mode = Convert.ToBoolean(Convert.ToInt16(strArrays[1].Substring(5, 1)));
                        empty.Beeps = Convert.ToInt16(strArrays[1].Substring(6, 1));
                        empty.Bypass = Convert.ToBoolean(Convert.ToInt16(strArrays[1].Substring(7, 1)));
                        empty.AC = Convert.ToBoolean(Convert.ToInt16(strArrays[1].Substring(8, 1)));
                        empty.Chime_Mode = Convert.ToBoolean(Convert.ToInt16(strArrays[1].Substring(9, 1)));
                        empty.AlarmEventOccured = Convert.ToBoolean(Convert.ToInt16(strArrays[1].Substring(10, 1)));
                        empty.AlarmBell = Convert.ToBoolean(Convert.ToInt16(strArrays[1].Substring(11, 1)));
                        empty.LowBattery = Convert.ToBoolean(Convert.ToInt16(strArrays[1].Substring(12, 1)));
                        empty.EntryDelayOff = Convert.ToBoolean(Convert.ToInt16(strArrays[1].Substring(13, 1)));
                        empty.FireAlarm = Convert.ToBoolean(Convert.ToInt16(strArrays[1].Substring(14, 1)));
                        empty.CheckZone = Convert.ToBoolean(Convert.ToInt16(strArrays[1].Substring(15, 1)));
                        empty.PerimeterOnly = Convert.ToBoolean(Convert.ToInt16(strArrays[1].Substring(16, 1)));
                        empty.Numeric = strArrays[2];
                        empty.Text = strArrays[4].Substring(1, 32);
                        int num2 = Convert.ToInt16(strArrays[3].Substring(19, 2), 16);
                        if ((num2 & 1) <= 0)
                        {
                            empty.Cursor = -1;
                        }
                        else
                        {
                            empty.Cursor = Convert.ToInt16(strArrays[3].Substring(21, 2), 16);
                        }
                        this.Msg = empty;
                        return strArrays;
                    }
                    catch
                    {
                        Debug.WriteLine(string.Format("Bad packet or parse error: '{0}'", this._message));
                    }
                }
            }
            return null;
        }
    }
}
