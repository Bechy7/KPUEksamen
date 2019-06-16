using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Service
{
    public partial class MyCoolService : ServiceBase
    {
        const string USER = "";

        string MASTER_FILE_PATH = $"C:\\Users\\{USER}\\Desktop\\KPU_MASTER.txt";
        // string MONITORED_FOLDER_PATH = @"C:\Windows\Temp\KPU1";
        string PARAMETER_FILE_PATH = $"C:\\Users\\{USER}\\Desktop\\KPU_PARAMETER.txt";


        private enum MyCoolCommands
        {
            UpdatePaths = 128,
        };

        public MyCoolService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            if (!EventLog.SourceExists(ServiceName))
            {

                EventLog.CreateEventSource(ServiceName, "Application");
            }
        }

        protected override void OnStop()
        {
        }

        private void fileSystemWatcher1_Created(object sender, FileSystemEventArgs e)
        {
            LogEvent("File created", EventLogEntryType.Information);

            try
            {
                // read new file, append to master file
                // Read entire text file content in one string  
                string fileContent = File.ReadAllText(e.FullPath);

                // This text is always added, making the file longer over time
                // if it is not deleted.
                using (StreamWriter sw = File.AppendText(MASTER_FILE_PATH))
                {
                    sw.WriteLine(fileContent);
                }
            }
            catch (Exception exception)
            {
                LogEvent(exception.Message, EventLogEntryType.Error);
            }
        }

        protected override void OnCustomCommand(int command)
        {
            switch (command)
            {
                case (int)MyCoolCommands.UpdatePaths:

                    string parameters = File.ReadAllText(PARAMETER_FILE_PATH);
                    var splitParameters = parameters.Split(';');

                    fileSystemWatcher1.Path = splitParameters[0];
                    MASTER_FILE_PATH = splitParameters[1];

                    LogEvent($"Updated path with monitored: {fileSystemWatcher1.Path}, " +
                             $"master: {MASTER_FILE_PATH}", 
                        EventLogEntryType.Information);
                    break;
                default:
                    LogEvent("Received no proper command", EventLogEntryType.Error);
                    break;
            }
        }


        private void LogEvent(string message, EventLogEntryType entryType)
        {
            EventLog eventLog = new EventLog();
            eventLog.Source = ServiceName;
            eventLog.Log = "Application";
            eventLog.WriteEntry(message, entryType);
        }

        private void notifyIcon1_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {

        }
    }
}
