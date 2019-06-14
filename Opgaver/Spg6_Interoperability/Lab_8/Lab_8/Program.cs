using System;
using System.Runtime.InteropServices;

namespace Lab_8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Wrapper.MessageBeep(0xFFFFFFFF));
        }
    }

    public class Wrapper
    {
        [DllImport("User32.dll")]
        public static extern Boolean MessageBeep(UInt32 beepType);
    }
}
