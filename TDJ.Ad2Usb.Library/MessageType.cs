using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDJ.Ad2Usb.Library
{
    public enum MessageType
    {
        Empty,
        Ready,
        ArmedAway,
        ArmedHome,
        BackLight,
        ProgrammingMode,
        Beep,
        ZonesBypassed,
        ACPower,
        ChimeMode,
        AlarmOccurredStickyBit,
        AlarmBell,
        BatteryLow,
        EntryDelayOff,
        FireAlarm,
        CheckZone,
        PerimeterOnly
    }
}
