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
        public readonly String ErrorLogDirectory;

        public StartupProcedures(Form Form1Instance)
        {
            this.Form1Instance = Form1Instance;

            this.RootDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            this.ChampollionDirectory = Path.Combine(RootDirectory, "Champollion");
            this.ChampollionFullPath = Path.Combine(ChampollionDirectory, "Champollion.exe");
            this.ErrorLogDirectory = Path.Combine(RootDirectory, "error_logs");
        }



        public bool CheckDependencies()
        {
            String RootDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            String ChampollionDirectory = Path.Combine(RootDirectory, "Champollion");
            String ChampollionFullPath = Path.Combine(ChampollionDirectory, "Champollion.exe");

            return File.Exists(ChampollionFullPath);
        }


        //Settings File (separate class)
        
        //Log files directories
    }
}
