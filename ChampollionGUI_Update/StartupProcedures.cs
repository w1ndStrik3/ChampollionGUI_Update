using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ChampollionGUI_Update
{
    public class StartupProcedures
    {
        private readonly Form Form1Instance;

        public readonly String RootDirectory;
        public readonly String ChampollionDirectory;
        public readonly String ChampollionFullPath;
        public readonly String SettingsFileFullPath;
        public readonly String LogsDirectory;

        public readonly String WarningMessage;

        //TODO:
        //  Create Settings
        //  Fill "CreateSettings" method
        //  Fill "CreateMissingDirectories" method
        //  Set up logging
        //  Use CGUI exceptions

        //Settings File (separate class)

        //Log
        //
        //  Startup report
        //  Settings Change
        //
        //  Compilations
        //      Type
        //      Directories
        //      Comments
        //      File amounts
        //      Decompilation time
        //
        //  Errors


        public struct startupReport
        {
            public bool DependenciesFulfilled
            {
                get; set;
            }
            public bool LogsDirectoryExists
            {
                get; set;
            }
            public bool SettingsFileExists
            {
                get; set;
            }
        }

        public StartupProcedures(Form Form1Instance)
        {
            this.Form1Instance = Form1Instance;

            this.WarningMessage = "You have selected to use a custom directory for the " +
                                  "{0} files, but either you have not specified the " +
                                  "location of the custom directory, OR the specified " +
                                  "directory does not exist." +
                                  "\r\n\r\nWould you like to use the default directory? " +
                                  "\r\n\tSelect \"OK\" to continue with the default directory " +
                                  "\r\n\tSelect \"Cancel\" to cancel." +
                                  "\r\n\r\nDefault directory is: %Scripts Folder%\\{0}";

            this.RootDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            this.ChampollionDirectory = Path.Combine(RootDirectory, "Champollion");
            this.ChampollionFullPath = Path.Combine(ChampollionDirectory, "Champollion.exe");
            this.SettingsFileFullPath = Path.Combine(RootDirectory, "settings.ini");
            this.LogsDirectory = Path.Combine(RootDirectory, "Logs");
        }

        public startupReport GetStatus()
        {
            startupReport report = new startupReport();
            report.DependenciesFulfilled = CheckDependencies();
            report.LogsDirectoryExists = CheckLogsDirectory();
            report.SettingsFileExists = CheckSettingsFile();

            return report;
        }

        public void CreateMissingDirectories(bool logs, bool settings)
        {

        }

        public bool CheckDependencies()
        {
            return File.Exists(ChampollionFullPath);
        }

        public bool CheckLogsDirectory()
        {
            return Directory.Exists(LogsDirectory);
        }

        public bool CheckSettingsFile()
        {
            return File.Exists(SettingsFileFullPath);
        }


        private void CreateLogsDirectory()
        {
            if(!Directory.Exists(LogsDirectory))
            {
                Directory.CreateDirectory(LogsDirectory);
            }
        }

        private void CreateSettingsFile()
        {
            if(!File.Exists(SettingsFileFullPath))
            {
                File.Create(SettingsFileFullPath);
            }
        }
    }
}
