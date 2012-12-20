using System;
namespace TDJ.Ad2Usb.Library
{
    public interface IMessageParser
    {
        Message Process(string rawOutputMessage);
    }
}
