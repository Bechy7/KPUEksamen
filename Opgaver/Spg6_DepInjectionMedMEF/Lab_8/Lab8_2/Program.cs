using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab8_2
{
    class Program
    {
        // imports from DLL

        // extern "C" LAB1DLL_API int AddNumbers(int a, int b);
        [DllImport("LAB1DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int AddNumbers(int a, int b);

        // extern "C" LAB1DLL_API char* AddChars(char* a, char* b);
        [DllImport("LAB1DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr AddChars(string a, string b);

        // extern "C" LAB1DLL_API std::string AddStrings(std::string a, std::string b);
        [DllImport("LAB1DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr AddStrings(string a, string b);

        static void Main(string[] args)
        {
            Console.WriteLine("Calling AddNumbers with 1, 2): " + AddNumbers(1, 2));

            // char array returned into IntPtr
            IntPtr resCharPtr = AddChars("a", "b"); // must return IntPtr for correct return type

            Console.WriteLine("Calling AddChars with a, b): " + Marshal.PtrToStringAnsi(resCharPtr));

            // resCharPtr er allokeret i C++
            // -> DeletePtr funktion
            // -> LocalAlloc.  Marshal.FreeHGlobal kan anvendes



            // throws exception because calling native c++ from c# -> not possible

            // IntPtr resStringPtr = AddStrings("a", "b");
        }
    }
}
