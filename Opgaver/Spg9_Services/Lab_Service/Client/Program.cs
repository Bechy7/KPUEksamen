using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;


namespace Client
{
    class Program
    {
        private const string serviceName = "CoolFatimaService";
        const string PARAMETER_FILE_PATH = @"C:\Users\Fatima\Desktop\KPU_PARAMETER.txt";

        private enum MyCoolCommands
        {
            UpdatePaths = 128,
        };

        static void Main(string[] args)
        {
            ServiceController[] scServices;
            scServices = ServiceController.GetServices();
            ServiceController sc = null;

            foreach (var service in scServices)
            {
                if (service.ServiceName == serviceName)
                {
                    sc = new ServiceController(serviceName);
                }
            }

            if (sc == null)
            {
                Console.WriteLine("Service not found");
                return;
            }

            
            while (true)
            {
                Console.WriteLine("Enter command\nStart(1)\nStop(2)\nSend command(3)");

                string cmd = Console.ReadLine();

                switch (cmd)
                {
                    case "1":
                        Console.WriteLine("Starting service");
                        sc.Start();
                        break;
                    case "2":
                        Console.WriteLine("Stopping service");
                        sc.Stop();
                        break;
                    case "3":
                        SendCommand();
                        sc.ExecuteCommand((int)MyCoolCommands.UpdatePaths);
                        Console.WriteLine("Sending parameters");
                        break;
                    default:
                        Console.WriteLine("Command not recognized");
                        break;
                }

            }
        }
        private static void SendCommand()
        {
            Console.WriteLine("Enter new path to be monitored: ");
            string monitoredPath = Console.ReadLine();

            Console.WriteLine("Enter new master file path: ");
            string masterFile = Console.ReadLine();

            using (StreamWriter sw = new StreamWriter(PARAMETER_FILE_PATH))
            {
                sw.Flush();
                sw.Write(monitoredPath);
                sw.Write(';');
                sw.Write(masterFile);
            }
        }

    }
}
