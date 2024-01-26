using System;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using static System.Windows.Forms.LinkLabel;

#pragma warning disable CS8618
#pragma warning disable CS8622
#pragma warning disable CS8600

namespace ChampollionGUI_Update
{
    public class Decompilation
    {
        #region native variables and objects
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

        #region form related variables and objects
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

                else       
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
            }

            if (CheckBoxUseDifferentDirectoryForSource.Checked)
            {
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

            if (generateAssembly)
            {
                if (CheckBoxOutputAssemblyDiffLocation.Checked)
                {
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
            String LastLine = "";

            String[] PexFiles = Directory.GetFiles(PexFileDirectory, "*.pex");

            ProgressBarProgress.Maximum = PexFiles.Length;
            ProgressBarProgress.Value = 0;

            Action UpdateProgress = () =>
            {
                ProgressBarProgress.Value++;
                ProgressBarProgress.Refresh();
            };
            bool encounteredError = false;

            outputTimeoutTimer = new System.Threading.Timer(KillProcessOnTimeout, null, Timeout.Infinite, Timeout.Infinite);

            Task DecompilationTask = new(() =>
            {

                for (int index1 = 0; index1 < PexFiles.Length; ++index1)
                {
                    try
                    {
                        String Command = CommandBuilder(PexFiles[index1], SourcePath, AssemblyPath, null, false);

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
                                LastLine = E.Data;
                            }
                        };

                        outputTimeoutTimer.Change(timeoutMilliseconds, Timeout.Infinite);

                        DecompilationProcess.Start();

                        DecompilationProcess.BeginOutputReadLine();

                        DecompilationProcess.WaitForExit(5000);

                        if (!DecompilationProcess.HasExited)
                        {
                            DecompilationProcess.Kill();
                            throw new IntraDecompilationException($"Champollion encountered an error while decompiling {PexFiles[index1]}");
                        }

                        if (LastLine.Contains("ERROR: "))
                        {
                            throw new IntraDecompilationException($"There was a problem with the file {PexFiles[index1]}. It is likely corrupt. ");
                        }

                        Form1Instance.Invoke((Delegate)UpdateProgress);
                    }
                    catch (IntraDecompilationException IDE)
                    {
                        ProcessAbortedMessage(IDE.Message);
                        encounteredError = true;
                        break;
                    }
                }
            });
            DecompilationTask.Start();

            DecompilationTask.ContinueWith(task =>
            {
                if (!encounteredError)
                {
                    DisplayMessageOnCompletetion(LastLine, 0, false);
                }
            });
        }

        private void IgnoreCorruptFilesDecompilation()
        {
            ProgressBarProgress.Maximum = Directory.GetFiles(PexFileDirectory, "*.pex").Length + 1;
            ProgressBarProgress.Value = 0;

            String LastLine = "";

            int errors = 0;

            List<String> Errors = new List<string>();
            String ChampollionPath = "";
            Action UpdateProgress = () =>
            {
                ProgressBarProgress.Value++;
                ProgressBarProgress.Refresh();
            };
            Task DecompilationTask = new(() =>
            {
                try
                {
                    String Command = CommandBuilder(PexFileDirectory, SourcePath, AssemblyPath, null, false);

                    DecompilationProcess = new Process();

                    DecompilationProcess.StartInfo.UseShellExecute = false;
                    DecompilationProcess.StartInfo.RedirectStandardOutput = true;

                    DecompilationProcess.StartInfo.WorkingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    ChampollionPath = DecompilationProcess.StartInfo.WorkingDirectory;
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
                                Errors.Add(LastLine);
                            }

                            if (!LastLine.Contains("dissassembled to "))
                            { 
                                Form1Instance.Invoke((Delegate)UpdateProgress); 
                            }
                        }
                    };

                    DecompilationProcess.Start();

                    outputTimeoutTimer = new System.Threading.Timer(KillProcessOnTimeout, null, Timeout.Infinite, Timeout.Infinite);
                    outputTimeoutTimer.Change(timeoutMilliseconds, Timeout.Infinite);

                    DecompilationProcess.BeginOutputReadLine();

                    DecompilationProcess.WaitForExit();

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

            DecompilationTask.ContinueWith(task =>
            {
                DisplayMessageOnCompletetion(LastLine, errors, true);
                String TimeNowUTC = DateTime.UtcNow.ToString("dd_MM_yyyy_HH_mm_ss");
                if (errors > 0)
                {
                    using (StreamWriter outputFile = new StreamWriter(Path.Combine(ChampollionPath, $"Champollion_log_{TimeNowUTC}.txt")))
                    {
                        foreach (String Error in Errors)
                        {
                            outputFile.WriteLine(Error);
                        }
                    }
                }
            });
        }

        private void ThreadedDecompilation()
        {
            String ChampollionDirectory = "";

            Task DecompilationTask = new(() =>
            {
                DecompilationProcess = new Process();

                DecompilationProcess.StartInfo.UseShellExecute = false;
                DecompilationProcess.StartInfo.RedirectStandardOutput = true;

                ChampollionDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                DecompilationProcess.StartInfo.WorkingDirectory = ChampollionDirectory;
                DecompilationProcess.StartInfo.FileName = Path.GetFileName("Champollion.exe");

                String Command = CommandBuilder(PexFileDirectory, SourcePath, AssemblyPath, ChampollionDirectory, true);

                DecompilationProcess.StartInfo.Arguments = Command;

                DecompilationProcess.Start();

                using (StreamReader StmRdr = DecompilationProcess.StandardOutput)
                {
                    using (StreamWriter StmWtr = new StreamWriter(ChampollionDirectory + @"\output.txt"))
                    {
                        while (!StmRdr.EndOfStream)
                        {
                            int charRead = StmRdr.Read();
                            StmWtr.Write((char)charRead);
                        }
                    }
                }

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
        private String CommandBuilder(String FilePath, String SourcePath, String AssemblyPath, String ChampollionDirectory, bool threaded)
        {
            StringBuilder Command = new StringBuilder();

            Command.Append($"\"{FilePath}\"");

            if (outputSource)
            {
                Command.Append($" -p \"{SourcePath}\"");
            }

            if (generateAssembly)
            {
                Command.Append(" -a");
                if (outputAssembly)
                {
                    Command.Append($" \"{AssemblyPath}\"");
                }
            }

            if (generateComments)
            {
                Command.Append(" -c");
            }

            if (threaded)
            {
                Command.Append($" -t");
            }

            return Command.ToString();
        }

        private static void DisplayMessageOnCompletetion(String Result, int errors, bool ignoreCorrupt)
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
            else if (!ignoreCorrupt)
            {
                Message =
                "Champollion has successfully processed all files. \r\n" +
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

        private static void DisplayMessageOnCompletetionThreaded(String ChampollionDirectory)
        {
            String Message =
                "Champollion has processed all files. \r\n" +
                "As stated in the README (which you have\r\n" +
                "TOTALLY read, trust me bro),\r\n" +
                "the output of this decompilation is stored in:\r\n" +
               $"{ChampollionDirectory}\\output.txt\r\n" +
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
