using System;
using System.Diagnostics;
using System.Reflection;
using System.Text;

#pragma warning disable CS8618
#pragma warning disable CS8622
#pragma warning disable CS8600

namespace ChampollionGUI_Update
{
    public class Decompilation
    {
        #region native variables
        private Process DecompilationProcess;
        private System.Threading.Timer outputTimeoutTimer;
        private readonly int timeoutMilliseconds = 5000;

        private bool outputSource = false;
        private bool useDefaultSourceDirectory = false;

        private bool outputAssembly = false;
        private bool useDefaultAssemblyDirectory = false;

        private bool generateAssembly = false;
        private bool generateComments = false;

        private String PexFileDirectory = "";

        private String DefaultSourceDirectory = "";
        private String DefaultAssemblyDirectory = "";

        private String SourcePath = "";
        private String AssemblyPath = "";
        #endregion

        #region form related variables
        private Form1 Form1Instance;

        private TextBox TextBoxScriptsPEXPath;
        private TextBox TextBoxSourcePath;
        private TextBox TextBoxAssemblyPath;

        private CheckBox CheckBoxUseDifferentDirectoryForSource;
        private CheckBox CheckBoxGenerateAssembly;
        private CheckBox CheckBoxOutputAssemblyDiffLocation;

        private CheckBox CheckBoxGenerateComments;
        private CheckBox CheckBoxThreaded;
        private CheckBox CheckBoxIgnoreCorruptFiles;

        private ProgressBar ProgressBarProgress;

        private String WarningMessage;
        #endregion
        public Decompilation(Form1 Form1Instance)
        {
            this.Form1Instance = Form1Instance;
            this.InitializeComponent();
        }
        
        public void InitializeComponent()
        {
            this.TextBoxScriptsPEXPath = Form1Instance.TextBoxScriptsPEXPath;
            this.TextBoxSourcePath = Form1Instance.TextBoxSourcePath;
            this.TextBoxAssemblyPath = Form1Instance.TextBoxAssemblyPath;

            this.CheckBoxUseDifferentDirectoryForSource = Form1Instance.CheckBoxUseDifferentDirectoryForSource;
            this.CheckBoxGenerateAssembly = Form1Instance.CheckBoxGenerateAssembly;
            this.CheckBoxOutputAssemblyDiffLocation = Form1Instance.CheckBoxOutputAssemblyDiffLocation;
            
            this.CheckBoxGenerateComments = Form1Instance.CheckBoxGenerateComments;
            this.CheckBoxThreaded = Form1Instance.CheckBoxThreaded;
            this.CheckBoxIgnoreCorruptFiles = Form1Instance.CheckBoxIgnoreCorruptFiles;

            this.ProgressBarProgress = Form1Instance.ProgressBarProgress;
            
            this.WarningMessage = Form1Instance.WarningMessage;
        }

        #region Pre decompilation methods
        public char PreDecompilationChecks()
        {
            char result = 'E';

            bool pexDirOK = (!String.IsNullOrWhiteSpace(TextBoxScriptsPEXPath.Text) && Directory.Exists(TextBoxScriptsPEXPath.Text));

            bool threaded = CheckBoxThreaded.Checked;
            bool ignoreCorrupt = CheckBoxIgnoreCorruptFiles.Checked;

            generateAssembly = CheckBoxGenerateAssembly.Checked;
            generateComments = CheckBoxGenerateComments.Checked;

            //bool breakProcess = false;

            if (!pexDirOK)
            {
                if (String.IsNullOrWhiteSpace(TextBoxScriptsPEXPath.Text))
                {
                    _ = new MessageBox("Run Error", $"Unable to run - Scripts Path empty\r\n-{TextBoxScriptsPEXPath.Text}-", false).ShowDialog();

                    throw new PreDecompilationException($"Pex Path is Null or Whitespace:");
                }
                else if (!Directory.Exists(TextBoxScriptsPEXPath.Text))
                {
                    _ = new MessageBox("Run Error", "Unable to run - Source directory does not exist.", false).ShowDialog();
                }

                else //if(!emptyDir)
                {
                    //Something real fishy should happen for this to trigger. No idea how it would.
                    Fishy("pexDirOK Failed Check");
                }

                throw new PreDecompilationException("");
            }

            if (Directory.GetFiles(TextBoxScriptsPEXPath.Text, "*.pex").Length == 0)
            {
                if (Directory.GetFiles(TextBoxScriptsPEXPath.Text).Length == 0)
                {
                    _ = new MessageBox("Run Error", "Unable to run - Chosen scripts directory is empty.", false).ShowDialog();
                }
                else
                {
                    _ = new MessageBox("Run Error", "Unable to run - Chosen scripts directory does not contain any .pex files.", false).ShowDialog();
                }

                throw new PreDecompilationException("");

                //pexDirOK = false;
                //emptyDir = true;
            }

            if (CheckBoxUseDifferentDirectoryForSource.Checked)
            {
                //if (!String.IsNullOrWhiteSpace(TextBoxSourcePath.PexFileDirectory) && Directory.Exists(TextBoxSourcePath.PexFileDirectory))
                if (CheckDirectory(TextBoxSourcePath.Text))
                {
                    outputSource = true;
                }
                else
                {
                    if (!SendWarning("source"))
                    {
                        throw new PreDecompilationException("");
                    }
                    useDefaultSourceDirectory = true;
                }
            }

            /*
            if (breakProcess)
            {
                return;
            }
            */

            if (generateAssembly)
            {
                if (CheckBoxOutputAssemblyDiffLocation.Checked)
                {
                    //if (!String.IsNullOrWhiteSpace(TextBoxAssemblyPath.PexFileDirectory) && Directory.Exists(TextBoxAssemblyPath.PexFileDirectory))
                    if (CheckDirectory(TextBoxAssemblyPath.Text))
                    {
                        outputAssembly = true;
                    }
                    else
                    {
                        if (!SendWarning("assembly"))
                        {
                            throw new PreDecompilationException("");
                        }
                        useDefaultAssemblyDirectory = true;
                    }
                }
            }

            /*
            if (breakProcess)
            {
                return;
            }
            */

            /*
            bool[,] result =
            {
                {
                    outputSource,               //[0,0]
                    useDefaultSourceDirectory   //[0,1]
                },

                {
                    outputAssembly,             //[1,0]
                    useDefaultAssemblyDirectory //[1,1]
                }
            };
            */

            if (threaded && !ignoreCorrupt) //Threaded decompilation
            {
                result = 'T';
            }
            else if (ignoreCorrupt && !threaded) //Ignoring corrupt/errouneous files decompilation
            {
                result = 'I';
            }
            else if (!threaded && !ignoreCorrupt) //Regular decompilation
            {
                result = 'R';
            }
            else if (threaded && ignoreCorrupt) //Should not happen
            {
                Fishy("Threaded & Ignore Corrupt both true");

            }
            else //Critical error, which I cannot imagine whould ever occur
            {
                Fishy("Threaded & Ignore Corrupt Critical Error");
            }

            PexFileDirectory = TextBoxScriptsPEXPath.Text;

            DefaultSourceDirectory = PexFileDirectory + @"\source";
            DefaultAssemblyDirectory = PexFileDirectory + @"\assembly";

            SourcePath = DefaultSourceDirectory;
            AssemblyPath = DefaultAssemblyDirectory;

            if (!useDefaultSourceDirectory)
            {
                SourcePath = TextBoxSourcePath.Text;
            }

            if (!useDefaultAssemblyDirectory)
            {
                AssemblyPath = TextBoxAssemblyPath.Text;
            }

            return result;
        }

        private bool SendWarning(String Type)
        {
            /*
            if (new MessageBox("Warning", String.Format(WarningMessage, Type), true).ShowDialog() == DialogResult.OK)
            {
                return true;
            }

            return false;
            */
            return new MessageBox("Warning", String.Format(WarningMessage, Type), true).ShowDialog() == DialogResult.OK;
        }

        private bool CheckDirectory(String Path)
        {
            bool isEmpty = String.IsNullOrWhiteSpace(Path);
            bool exists = Directory.Exists(Path);
            return !isEmpty && exists;
        }
        #endregion

        #region The meat and potatoes
        public void Decompile(char option)
        {
            /*
             * arguments: [[a,b],[c,d]]
             * Index: [x,y]
             * a(x) = 0; a(y) = 0 -> a = [0,0]
             * b(x) = 0; b(y) = 1 -> b = [0,1]
             * c(x) = 1; c(y) = 0 -> c = [1,0] 
             * d(x) = 1; d(y) = 1 -> d = [1,1]
             *
             *
             *                                          (x)
             *                         0                                   1                 
             *       +-----------------------------------+-----------------------------------+
             *       |                                   |                                   |    
             *     0 |           outputSource            |           outputAssembly          |          
             *       |                                   |                                   |
             *  (y)  +-----------------------------------+-----------------------------------+
             *       |                                   |                                   |
             *     1 |     useDefaultSourceDirectory     |    useDefaultAssemblyDirectory    |
             *       |                                   |                                   |
             *       +-----------------------------------+-----------------------------------+      
             *
             * I spent almost 50 minutes doing this diagram. I need to learn to prioritize stuff
             * Six hours later, I have just found out that this Diagram is completely useless, 
             * Since I am no longer using the array stuff that this diagram was trying to visualize
             */

            switch (option)
            {
                case 'T':
                    ThreadedDecompilation();
                    break;
                case 'I':
                    IgnoreCorruptFilesDecompilation();
                    break;
                case 'R':
                    RegularDecompilation();
                    break;
                default:
                    Fishy("Switch Option is default");
                    break;
            }
        }

        private void RegularDecompilation()
        {
            /*
               In the name of Christ and everything holy, that was the longest condition statement i have ever seen.
               550 character long condition statement... No offense but I will make it look prettier.
               This is not a criticism, just very surprised. Look, if it works, it works. Everything else is personal preference.
               The condition statement can be expressed in boolean algebra as "F=(A*B*C)+(C*D*E).
               -w1ndStrik3

               if (CheckBoxUseDifferentDirectoryForSource.Checked && string.IsNullOrWhiteSpace(TextBoxSourcePath.PexFileDirectory) && new MessageBox("Confirm Continue Decompile", "LastLine Source is checked but destination is empty. \n Do you want to continue?", true).DialogResult == DialogResult.Cancel || CheckBoxGenerateAssembly.Checked && CheckBoxOutputAssemblyDiffLocation.Checked && string.IsNullOrWhiteSpace(TextBoxAssemblyPath.PexFileDirectory) && new MessageBox("Confirm Continue Decompile", "Assembly Location is checked but destination is empty. \n Do you want to continue?", true).DialogResult == DialogResult.Cancel)
               {
                   return;
               }
               */
            /*
            bool outputSource = arguments[0, 0];
            bool useDefaultSourceDirectory = arguments[0, 1];
            bool outputAssembly = arguments[1, 0];
            bool useDefaultAssemblyDirectory = arguments[1, 1];
            */

            /*
            String PexFileDirectory = TextBoxScriptsPEXPath.PexFileDirectory;
            
            String DefaultSourceDirectory = PexFileDirectory + @"\source";
            String DefaultAssemblyDirectory = PexFileDirectory + @"\assembly";

            String SourcePath = DefaultSourceDirectory;
            String AssemblyPath = DefaultAssemblyDirectory;
            */

            /*
            if (!useDefaultSourceDirectory)
            {
                SourcePath = TextBoxSourcePath.PexFileDirectory;
            }

            if (!useDefaultAssemblyDirectory)
            {
                AssemblyPath = TextBoxAssemblyPath.PexFileDirectory;
            }
            */

            //bool outputSource = CheckBoxUseDifferentDirectoryForSource.Checked;

            //bool outputAssembly = CheckBoxOutputAssemblyDiffLocation.Checked;

            String LastLine = "";

            String[] PexFiles = Directory.GetFiles(PexFileDirectory, "*.pex");

            ProgressBarProgress.Maximum = PexFiles.Length;
            ProgressBarProgress.Value = 0;

            Action UpdateProgress = () =>
            {
                ++ProgressBarProgress.Value;
                ProgressBarProgress.Refresh();
            };
            bool encounteredError = false;
            Task DecompilationTask = new(() =>
            {
                //TODO: Rewrite this.
                //This implementation essentially takes each file and gives each file as a
                //separate command to Champollion instead of just giving champollion an
                //entire directory to decompile. This substantially increases the waiting
                //time for the user.

                for (int index1 = 0; index1 < PexFiles.Length; ++index1)
                {
                    try
                    {
                        /*
                        List<String> CommandList = new List<String>
                        {
                            String.Format("\"{0}\"", (object)PexFiles[index1])
                        };

                        if (outputSource && !String.IsNullOrWhiteSpace(SourcePath))
                        {
                            CommandList.Add(String.Format(" -p \"{0}\"", (object)SourcePath));
                        }
                        else
                        {
                            CommandList.Add(String.Format(" -p \"{0}\"", (object)DefaultSourceDirectory));
                        }

                        if (generateAssembly)
                        {
                            CommandList.Add(" -a");

                            if (outputAssembly && !String.IsNullOrWhiteSpace(AssemblyPath))
                            {

                                CommandList.Add(String.Format(" \"{0}\"", (object)AssemblyPath));
                            }
                            else
                            {
                                CommandList.Add(String.Format(" \"{0}\"", (object)DefaultAssemblyDirectory));
                            }
                        }
                        if (generateComments)
                        {
                            CommandList.Add(" -c");
                        }
                        String Str = "";
                        for (int index2 = 0; index2 < CommandList.Count; ++index2)
                        {
                            Str += CommandList[index2];
                        }
                        */

                        String Command = CommandBuilder(PexFiles[index1], SourcePath, AssemblyPath, false);

                        DecompilationProcess = new Process();

                        DecompilationProcess.StartInfo.UseShellExecute = false;
                        DecompilationProcess.StartInfo.RedirectStandardOutput = true;

                        DecompilationProcess.StartInfo.WorkingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                        DecompilationProcess.StartInfo.FileName = Path.GetFileName("Champollion.exe");
                        DecompilationProcess.StartInfo.Arguments = Command;

                        DecompilationProcess.OutputDataReceived += (Sender, E) =>
                        {
                            if (!String.IsNullOrWhiteSpace(E.Data))
                            {
                                outputTimeoutTimer.Change(timeoutMilliseconds, Timeout.Infinite);
                                LastLine = E.Data;
                                Form1Instance.Invoke((Delegate)UpdateProgress);
                            }
                        };

                        DecompilationProcess.Start();

                        DecompilationProcess.BeginOutputReadLine();

                        String End = DecompilationProcess.StandardOutput.ReadToEnd();
                        DecompilationProcess.WaitForExit(5000);

                        if (!DecompilationProcess.HasExited)
                        {
                            DecompilationProcess.Kill();
                            throw new IntraDecompilationException($"Champollion encountered an error while decompiling {PexFiles[index1]}");
                        }

                        /*
                        do
                        {
                            //wait
                        }
                        while (!DecompilationProcess.HasExited);
                        */

                        if (!End.Contains("files processed in"))
                        {
                            throw new IntraDecompilationException($"Champollion encountered an error while decompiling {PexFiles[index1]}. ");
                        }

                        if (End.Contains("ERROR: "))
                        {
                            throw new IntraDecompilationException($"There was a problem with the file {PexFiles[index1]}. It is likely corrupt. ");
                        }

                        Form1Instance.Invoke((Delegate)UpdateProgress);
                    }
                    catch (IntraDecompilationException IDE)
                    {
                        ProcessAbortedMessage(IDE.Message);
                        //_ = new MessageBox("Champollion Error", IDE.Message + "Aborting...", false).ShowDialog();
                        /*
                        _ = new MessageBox("Champollion Error", String.Format("An error has occurred during execution. \r\n" +
                                                                                         "Champollion was unable to process {0}. \n Aborting...",
                                                                                         (object)PexFiles[index1]), false).ShowDialog();
                        */
                        encounteredError = true;
                        break;
                    }
                }
            });
            DecompilationTask.Start();

            /*
            do
            {
                //wait
            }
            while (DecompilationTask.Status.Equals((object)TaskStatus.Running));
            */

            /*
            if (encounteredError)
            {
                return;
            }
            */

            DecompilationTask.ContinueWith(task =>
            {
                if (!encounteredError)
                {
                    DisplayMessageOnCompletetion(LastLine, 0);
                }
            });
        }

        private void IgnoreCorruptFilesDecompilation()
        {
            ProgressBarProgress.Maximum = Directory.GetFiles(PexFileDirectory, "*.pex").Length;
            ProgressBarProgress.Value = 0;

            String LastLine = "";

            int errors = 0;

            Action UpdateProgress = () =>
            {
                ++ProgressBarProgress.Value;
                ProgressBarProgress.Refresh();
            };
            Task DecompilationTask = new(() =>
            {
                //TODO: Rewrite this.
                //This implementation essentially takes each file and gives each file as a
                //separate command to Champollion instead of just giving champollion an
                //entire directory to decompile. This substantially increases the waiting
                //time for the user.

                try
                {
                    String Command = CommandBuilder(PexFileDirectory, SourcePath, AssemblyPath, false);

                    DecompilationProcess = new Process();

                    DecompilationProcess.StartInfo.UseShellExecute = false;
                    DecompilationProcess.StartInfo.RedirectStandardOutput = true;

                    DecompilationProcess.StartInfo.WorkingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    DecompilationProcess.StartInfo.FileName = Path.GetFileName("Champollion.exe");
                    DecompilationProcess.StartInfo.Arguments = Command;

                    DecompilationProcess.OutputDataReceived += (Sender, E) =>
                    {
                        if (!String.IsNullOrWhiteSpace(E.Data))
                        {
                            outputTimeoutTimer.Change(timeoutMilliseconds, Timeout.Infinite);
                            LastLine = E.Data;
                            if (LastLine.Contains("ERROR: "))
                            {
                                errors++;
                            }
                            Form1Instance.Invoke((Delegate)UpdateProgress);
                        }
                    };

                    DecompilationProcess.Start();

                    outputTimeoutTimer = new System.Threading.Timer(KillProcessOnTimeout, null, Timeout.Infinite, Timeout.Infinite);
                    outputTimeoutTimer.Change(timeoutMilliseconds, Timeout.Infinite);

                    DecompilationProcess.BeginOutputReadLine();

                    DecompilationProcess.WaitForExit();

                    /*
                    if (!DecompilationProcess.HasExited)
                    {
                        throw new IntraDecompilationException($"Champollion encountered an error while decompiling {PexFiles[index1]}");
                    }
                    */

                    if (DecompilationProcess.HasExited && !LastLine.Contains("files processed in"))
                    {
                        throw new IntraDecompilationException($"Champollion encountered an error.");
                    }
                }
                catch (IntraDecompilationException IDE)
                {
                    ProcessAbortedMessage(IDE.Message);
                }
            });
            DecompilationTask.Start();
            //do
            //{
            //    //wait
            //}
            //while (DecompilationTask.Status.Equals((object)TaskStatus.Running));

            /*
            if (encounteredError)
            {
                return;
            }
            */

            DecompilationTask.ContinueWith(task =>
            {
                DisplayMessageOnCompletetion(LastLine, errors);
            });
        }

        private void ThreadedDecompilation()
        {
            String ChampollionDirectory = "";

            Task DecompilationTask = new(() =>
            {
                //TODO: Rewrite this.
                //This implementation essentially takes each file and gives each file as a
                //separate command to Champollion instead of just giving champollion an
                //entire directory to decompile. This substantially increases the waiting
                //time for the user.

                String Command = CommandBuilder(PexFileDirectory, SourcePath, AssemblyPath, true);

                DecompilationProcess = new Process();

                DecompilationProcess.StartInfo.UseShellExecute = false;
                DecompilationProcess.StartInfo.RedirectStandardOutput = true;

                ChampollionDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                DecompilationProcess.StartInfo.WorkingDirectory = ChampollionDirectory;
                DecompilationProcess.StartInfo.FileName = Path.GetFileName("Champollion.exe");
                DecompilationProcess.StartInfo.Arguments = Command;

                _ = new MessageBox("Champollion Run Complete", Command, false).ShowDialog();

                DecompilationProcess.Start();

                DecompilationProcess.WaitForExit();
            });
            DecompilationTask.Start();

            DecompilationTask.ContinueWith(task =>
            {
                DisplayMessageOnCompletetionThreaded(ChampollionDirectory);
            });
        }
        #endregion

        #region Intra decompilation methods
        private String CommandBuilder(String FilePath, String SourcePath, String AssemblyPath, bool threaded)
        {
            StringBuilder Command = new StringBuilder();

            Command.Append($" {FilePath}");

            if (outputSource)
            {
                Command.Append($" -p {SourcePath}");
            }

            if (generateAssembly)
            {
                Command.Append(" -a");
                if (outputAssembly)
                {
                    Command.Append($" {AssemblyPath}");
                }
            }

            if (generateComments)
            {
                Command.Append(" -c");
            }

            if (threaded) 
            {
                Command.Append(" -t > output.txt");
            }

            return Command.ToString();
        }

        private static void DisplayMessageOnCompletetion(String Result, int errors)
        {
            String Message;
            if (errors > 0)
            {
                Message =
                "Champollion has processed all files.\r\n" +
                Result + "\r\n" +
               $"Errors encountered: {errors}\r\n" +
                "See log file for details.\r\n" +
                "Verify your scripts.\r\n" +
                "Note: Events will be listed as Functions ";
            }
            else
            {
                Message =
                "Champollion has successfully processed all files. \r\n" +
                Result + "\r\n" +
                "Verify your scripts.\r\n" +
                "Note: Events will be listed as Functions ";
            }
            _ = new MessageBox("Champollion Run Complete", Message, false).ShowDialog();
        }

        private static void DisplayMessageOnCompletetionThreaded(String Path)
        {
            String Message =
                "Champollion has processed all files. \r\n" +
                "As stated in the README (which you have\r\n" + 
                "TOTALLY read, trust me bro),\r\n" + 
                "the output of this decompilation is stored in:\r\n" +
               $"{Path}\\output_threaded.txt\r\n" + 
                "Verify your scripts.\r\n" +
                "Note: Events will be listed as Functions ";
           
            _ = new MessageBox("Champollion Run Complete", Message, false).ShowDialog();
        }

        private void KillProcessOnTimeout(Object State)
        {
            if (!DecompilationProcess.HasExited)
            {
                DecompilationProcess.Kill();
                throw new IntraDecompilationException("Champollion.exe is not responding. Terminating process.");
            }
        }

        private static void ProcessAbortedMessage(String Message)
        {
            _ = new MessageBox("Champollion Error", Message + " Aborting...", false).ShowDialog();
        }

        private void Fishy(String Error)
        {
            Form1Instance.Fishy(Error);
        }
        #endregion
    }
}
