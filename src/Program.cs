using System;
using System.Windows.Forms;

namespace EventDetect
{
    internal class ConsoleApp
    {
        private static void Main()
        {
            DeviceChangeNotifier.DeviceChangeNotifier.DeviceNotify += DeviceChangeNotifierOnDeviceNotify;
            DeviceChangeNotifier.DeviceChangeNotifier.Start();


            Console.ReadKey();
            DeviceChangeNotifier.DeviceChangeNotifier.Stop();
        }

        private static void DeviceChangeNotifierOnDeviceNotify(Message message)
        {
            Console.WriteLine("Message: {0}, {1}, {2}, {3}", message.Msg, message.LParam, message.WParam, message.Result);
        }
    }
}