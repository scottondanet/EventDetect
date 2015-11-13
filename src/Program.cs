using System;
using System.Windows.Forms;

namespace EventDetect
{
    internal class ConsoleApp
    {
        private static void Main()
        {
            DeviceChangeNotifier.DeviceNotify += DeviceChangeNotifierOnDeviceNotify;
            DeviceChangeNotifier.Start();


            Console.ReadKey();
            DeviceChangeNotifier.Stop();
        }

        private static void DeviceChangeNotifierOnDeviceNotify(Message msg)
        {
            Console.WriteLine("Message: {0}, {1}, {2}, {3}", msg.Msg, msg.LParam, msg.WParam, msg.Result);
        }
    }
}