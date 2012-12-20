using Microsoft.AspNet.SignalR.Client.Hubs;
using Ninject;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDJ.Ad2Usb.Library;
using TDJ.HomeWatch.Business;

namespace TDJ.HomeWatch.ConsoleApp
{
    class Program
    {
        public static SerialPort serial { get;set;}
        private static readonly IKernel _kernel = new StandardKernel(new Bindings());
        private static HubConnection connection = new HubConnection(Config.SignalRUri);
        private static IHubProxy hub;

        static void Main(string[] args)
        {
            
            hub = connection.CreateHubProxy("info");

            connection.Start().ContinueWith(task =>
            {
                if (!task.IsFaulted)
                {
                    Console.WriteLine("Connected...");
                }
                else
                {
                    Console.WriteLine("Failed to start: {0}", task.Exception.GetBaseException());
                }
            }).Wait();
            hub.Invoke<string>("subscribe", "Product");
            //hub.Invoke<string>("Send", "From the console");

            //hub.On("fromServer", data => { 
            //    Console.WriteLine(data);
            //});

            //hub.On("addMessage", data =>
            //{
            //    Console.WriteLine(data);
            //});

            OpenCom();

            // Keep going until somebody hits 'x'
            while (true)
            {
                ConsoleKeyInfo ki = Console.ReadKey(true);
                if (ki.Key == ConsoleKey.X)
                {
                    break;
                }
            }
        }

        private static void OpenCom()
        {
            serial = new SerialPort("COM7", 115200, Parity.None, 8, StopBits.One);
            serial.Handshake = Handshake.None;
            //serial.WriteBufferSize = 1;
            serial.ReadTimeout = 10;
            serial.WriteTimeout = 500;
            serial.Open();

            serial.DataReceived +=serial_DataReceived;
        }

        static void serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] bytes = new byte[serial.BytesToRead];
            // read the bytes
            serial.Read(bytes, 0, bytes.Length);
            // convert the bytes into a string
            string raw = System.Text.Encoding.UTF8.GetString(bytes);

            // write the received bytes, as a string, to the console
            var p = _kernel.Get<IMessageParser>();
            var msg = p.Process(raw);

            if (msg != null)
            {
                Console.WriteLine("ReadyState: {0}", msg.Ready);
                hub.Invoke("publish", string.Format("Ready: {0}", msg.Ready), "Product");
            }
            
        }
    }
}
