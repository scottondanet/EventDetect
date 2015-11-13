using System;
using System.Threading;
using System.Windows.Forms;

namespace EventDetect
{
    public class DeviceChangeNotifier : Form
    {
        public delegate void DeviceNotifyDelegate(Message msg);

        private static DeviceChangeNotifier _mInstance;
        public static event DeviceNotifyDelegate DeviceNotify;

        public static void Start()
        {
            var t = new Thread(RunForm);
            t.SetApartmentState(ApartmentState.STA);
            t.IsBackground = true;
            t.Start();
        }

        public static void Stop()
        {
            if (_mInstance == null) throw new InvalidOperationException("Notifier not started");
            DeviceNotify = null;
            _mInstance.Invoke(new MethodInvoker(_mInstance.EndForm));
        }

        private static void RunForm()
        {
            Application.Run(new DeviceChangeNotifier());
        }

        private void EndForm()
        {
            Close();
        }

        protected override void SetVisibleCore(bool value)
        {
            if (_mInstance == null) CreateHandle();
            _mInstance = this;
            base.SetVisibleCore(false);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x219)
            {
                var handler = DeviceNotify;
                if (handler != null) handler(m);
            }
            base.WndProc(ref m);
        }
    }
}