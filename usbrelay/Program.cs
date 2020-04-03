using System;

namespace usbrelay
{

    class Program
    {
        public static int VID = 5824;
        public static int PID = 1503;

        public static byte SET_CLEAR_OUT = 0x08;
        public static byte CONFIGURE = 0x10;
        public static byte READ_EE = 0x20;
        public static byte WRITE_EE = 0x40;
        public static byte READ_ALL = 0x80;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            

            Console.WriteLine(RelayDeviceWrapper.usb_relay_init());
            var urdi = RelayDeviceWrapper.usb_relay_device_enumerate();
            Console.WriteLine(urdi);

            int handle = RelayDeviceWrapper.usb_relay_device_open_with_serial_number(urdi.serial_number, urdi.serial_number.Length);
            Console.WriteLine(handle);

            for (int x = 0; x < 10; x++)
            {
                RelayDeviceWrapper.usb_relay_device_open_one_relay_channel(handle, 1);
                System.Threading.Thread.Sleep(100);
                RelayDeviceWrapper.usb_relay_device_close_one_relay_channel(handle, 1);
                System.Threading.Thread.Sleep(100);
                Console.WriteLine(x);
            }
        }
    }
}