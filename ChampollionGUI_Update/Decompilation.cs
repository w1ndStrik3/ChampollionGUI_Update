using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ChampollionGUI_Update
{
    public class Decompilation : Form1
    {
        public bool[,] PreDecompilationChecks()
        {
            bool pexDirOK = (!String.IsNullOrWhiteSpace(TextBoxScriptsPEXPath.Text) && Directory.Exists(TextBoxScriptsPEXPath.Text));

            bool outputSource = false;
            bool useDefaultSourceDirectory = false;

            bool outputAssembly = false;
            bool useDefaultAssemblyDirectory = false;
            //bool breakProcess = false;

            if (!pexDirOK)
            {
                if (!String.IsNullOrWhiteSpace(TextBoxScriptsPEXPath.Text))
                {
                    _ = new MessageBox("Run Error", "Unable to run - Scripts Path empty", false).ShowDialog();
                }
                else if (!Directory.Exists(TextBoxScriptsPEXPath.Text))
                {
                    _ = new MessageBox("Run Error", "Unable to run - Source directory does not exist.", false).ShowDialog();
                }

                else //if(!emptyDir)
                {
                    //Something real fishy should happen for this to trigger. No idea how it would.
                    String Fishy = "Unknown Error. Please report the following error message\r\n" +
                                   "on the mod page on nexus mods along with a screenshot:" +
                                   "\r\nError message: pexDirOK Failed Check";

                    _ = new MessageBox("Run Error", Fishy, false).ShowDialog();


                }

                throw new ChampollionGUIException();
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

                throw new ChampollionGUIException();

                //pexDirOK = false;
                //emptyDir = true;
            }

            if (chkUseDifferentDirectoryForSource.Checked)
            {
                //if (!String.IsNullOrWhiteSpace(txtSourcePath.Text) && Directory.Exists(txtSourcePath.Text))
                if (CheckDirectory(txtSourcePath.Text))
                {
                    outputSource = true;
                }
                else
                {
                    if (!SendWarning("source"))
                    {
                        throw new ChampollionGUIException();
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

            if (CheckBoxGenerateAssembly.Checked)
            {
                if (CheckBoxOutputAssemblyDiffLocation.Checked)
                {
                    //if (!String.IsNullOrWhiteSpace(txtAssemblyPath.Text) && Directory.Exists(txtAssemblyPath.Text))
                    if (CheckDirectory(txtAssemblyPath.Text))
                    {
                        outputAssembly = true;
                    }
                    else
                    {
                        if (!SendWarning("assembly"))
                        {
                            throw new ChampollionGUIException();
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

        public void Run(bool[,] arguments)
        {
            /*
             * arguments: [[a,b],[c,d]]
             * Index: [x,y]
             * a(x) = 0; a(y) = 0 -> a = [0,0]
             * b(x) = 0; b(y) = 1 -> b = [0,1]
             * c(x) = 1; c(y) = 0 -> c = [1,0] 
             * d(x) = 1; d(y) = 1 -> d = [1,1]
             */

            //                                          (x)
            //                         0                                   1                 
            //       +-----------------------------------+-----------------------------------+
            //       |                                   |                                   |    
            //     0 |           outputSource            |           outputAssembly          |          
            //       |                                   |                                   |
            //  (y)  +-----------------------------------+-----------------------------------+
            //       |                                   |                                   |
            //     1 |     useDefaultSourceDirectory     |    useDefaultAssemblyDirectory    |
            //       |                                   |                                   |
            //       +-----------------------------------+-----------------------------------+      

            //I spent almost 50 minutes doing this diagram. I need to learn to prioritize stuff

            bool outputSource = arguments[0, 0];
            bool useDefaultSourceDirectory = arguments[0, 1];
            bool outputAssembly = arguments[1, 0];
            bool useDefaultAssemblyDirectory = arguments[1, 1];

            #region The meat and potatoes
            if (new MessageBox("Confirm Run", "Are you sure you want to run Champollion?", true).ShowDialog() != DialogResult.OK)
            {
                return;
            }
            else //(!string.IsNullOrWhiteSpace(TextBoxScriptsPEXPath.Text))
            {
                /*
                In the name of Christ and everything holy, that was the longest condition statement i have ever seen.
                550 character long condition statement... No offense but I will make it look prettier.
                This is not a criticism, just very surprised. Look, if it works, it works. Everything else is personal preference.
                The condition statement can be expressed in boolean algebra as "F=(A*B*C)+(C*D*E).
                -w1ndStrik3
                
                if (chkUseDifferentDirectoryForSource.Checked && string.IsNullOrWhiteSpace(txtSourcePath.Text) && new MessageBox("Confirm Continue Run", "Output Source is checked but destination is empty. \n Do you want to continue?", true).DialogResult == DialogResult.Cancel || CheckBoxGenerateAssembly.Checked && CheckBoxOutputAssemblyDiffLocation.Checked && string.IsNullOrWhiteSpace(txtAssemblyPath.Text) && new MessageBox("Confirm Continue Run", "Assembly Location is checked but destination is empty. \n Do you want to continue?", true).DialogResult == DialogResult.Cancel)
                {
                    return;
                }
                */

                String Text = TextBoxScriptsPEXPath.Text;
                String SourcePath = txtSourcePath.Text;
                String AssemblyPath = txtAssemblyPath.Text;
                String DefaultSourceDirectory = Text + @"\source";
                String DefaultAssemblyDirectory = Text + @"\assembly";
                //bool outputSource = chkUseDifferentDirectoryForSource.Checked;
                bool generateAssembly = CheckBoxGenerateAssembly.Checked;
                //bool outputAssembly = CheckBoxOutputAssemblyDiffLocation.Checked;
                bool generateComments = chkGenerateComments.Checked;

                String[] PexFiles = Directory.GetFiles(Text, "*.pex");

                ProgressBarProgress.Maximum = PexFiles.Length;
                ProgressBarProgress.Value = 0;

                Action UpdateProgress = (Action)(() =>
                {
                    ++ProgressBarProgress.Value;
                    ProgressBarProgress.Refresh();
                });
                bool encounteredError = false;
                Task DecompilationTask = new Task((Action)(() =>
                {
                    //TODO: Rewrite this.
                    //This implementation essentially takes each file and gives each file as a
                    //separate command to Champollion instead of just giving champollion an
                    //entire directory to decompile. While this allows the program to halt the
                    //decompilation as soon as an erroneous/corrupt file is encountered, it
                    //also results in a longer waiting time for the user, espcially if the
                    //user wants to decompile a large amount of files. Additionally, the user
                    //may not care if some files are corrupt, and would prefer to just have
                    //the program skip over those files instead and continue on.

                    for (int index1 = 0; index1 < PexFiles.Length; ++index1)
                    {
                        try
                        {
                            List<String> StringList = new List<String>
                            {
                                    String.Format("\"{0}\"", (object)PexFiles[index1])
                            };

                            if (outputSource && !String.IsNullOrWhiteSpace(SourcePath))
                            {
                                StringList.Add(String.Format(" -p \"{0}\"", (object)SourcePath));
                            }
                            else
                            {
                                StringList.Add(String.Format(" -p \"{0}\"", (object)DefaultSourceDirectory));
                            }

                            if (generateAssembly)
                            {
                                StringList.Add(" -a");

                                if (outputAssembly && !String.IsNullOrWhiteSpace(AssemblyPath))
                                {

                                    StringList.Add(String.Format(" \"{0}\"", (object)AssemblyPath));
                                }
                                else
                                {
                                    StringList.Add(String.Format(" -p \"{0}\"", (object)DefaultAssemblyDirectory));
                                }
                            }
                            if (generateComments)
                            {
                                StringList.Add(" -c");
                            }
                            String Str = "";
                            for (int index2 = 0; index2 < StringList.Count; ++index2)
                            {
                                Str += StringList[index2];
                            }
                            Process DecompilationProcess = new Process();
                            DecompilationProcess.StartInfo.UseShellExecute = false;
                            DecompilationProcess.StartInfo.RedirectStandardOutput = true;
                            DecompilationProcess.StartInfo.WorkingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                            DecompilationProcess.StartInfo.FileName = Path.GetFileName("Champollion.exe");
                            DecompilationProcess.StartInfo.Arguments = Str;
                            DecompilationProcess.Start();
                            String End = DecompilationProcess.StandardOutput.ReadToEnd();
                            DecompilationProcess.WaitForExit();

                            do
                            {
                                //wait
                            }
                            while (!DecompilationProcess.HasExited);

                            if (!End.Contains("files process"))
                            {
                                throw new Exception("Champollion encountered an error");
                            }
                            this.Invoke((Delegate)UpdateProgress);
                        }
                        catch (Exception)
                        {
                            _ = new MessageBox("Champollion Error", String.Format("An error has occurred during execution. \r\n" +
                                                                                             "Was unable to process {0}. \n Aborting...",
                                                                                             (object)PexFiles[index1]), false).ShowDialog();
                            encounteredError = true;
                            break;
                        }
                    }
                }));
                DecompilationTask.Start();
                //do
                //{
                //    //wait
                //}
                //while (DecompilationTask.Status.Equals((object)TaskStatus.Running));

                if (encounteredError)
                {
                    return;
                }

                DecompilationTask.ContinueWith(task =>
                {
                    _ = new MessageBox("Champollion Run Complete", "Champollion has successfully processed all files. \r\n" +
                                                                    "Verify your scripts. \n Note: Events will be listed as Functions ", false).ShowDialog();
                });
            }
            #endregion
        }
    }
}
