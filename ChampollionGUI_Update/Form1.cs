using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using Font = System.Drawing.Font;
#region unnecessary using directives
//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.IO;
//using System.Reflection;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using static System.Net.Mime.MediaTypeNames;
//using System.Xml.Linq;
//--using Microsoft.WindowsAPICodePack.Dialogs;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
#endregion


namespace ChampollionGUI_Update
{
    public class Form1 : Form
    {
        #region declarations

        #region IContainers
        public /*private*/ IContainer Components;
        #endregion

        #region Buttons
        public /*private*/ Button ButtonHelp;
        public /*private*/ Button ButtonAbout;
        public /*private*/ Button ButtonRun;
        public /*private*/ Button ButtonScriptsPathBrowse;
        public /*private*/ Button btnSourceDestinationBrowse;
        public /*private*/ Button btnAssemblyPathBrowse;
        public /*private*/ Button btnExit;
        #endregion

        #region CheckBoxes
        public /*private*/ CheckBox chkUseDifferentDirectoryForSource;
        public /*private*/ CheckBox CheckBoxGenerateAssembly;
        public /*private*/ CheckBox chkGenerateComments;
        public /*private*/ CheckBox CheckBoxOutputAssemblyDiffLocation;
        #endregion

        #region FolderBrowserDialogs
        public /*private*/ FolderBrowserDialog FolderDialog;
        #endregion

        #region Groupboxes
        public /*private*/ GroupBox GroupBoxParameters;
        public /*private*/ GroupBox GroupBoxProgress;
        #endregion

        #region Labels
        public /*private*/ Label LabelAuthor;
        public /*private*/ Label LabelUpdatedBy;
        public /*private*/ Label LabelScriptsFolder;
        public /*private*/ Label LabelAssemblyDestination;
        public /*private*/ Label LabelSourceDestination;
        public /*private*/ Label labelVersion;
        #endregion

        #region LinkLabels
        public /*private*/ LinkLabel LinkLabelAuthorOriginal;
        public /*private*/ LinkLabel LinkLabelAuthorRevision;
        public /*private*/ LinkLabel linkLabelEndorse;
        #endregion

        #region ProgressBars
        public /*private*/ ProgressBar ProgressBarProgress;
        #endregion

        #region TextBoxes
        public /*private*/ TextBox TextBoxScriptsPEXPath;
        public /*private*/ TextBox txtAssemblyPath;
        public /*private*/ TextBox txtSourcePath;
        #endregion

        #region Others
        private Decompilation Decompiler;
        public /*private*/ readonly String WarningMessage;
        #endregion

        #region Deprecated (to be deleted)
        //private FolderBrowserDialog folderBrowserDialog1;
        //--private CommonOpenFileDialog FolderDialog;
        #endregion

        #endregion

#pragma warning disable CS8618
        public Form1()
        {
            this.InitializeComponent();

            this.WarningMessage = "You have selected to use a custom directory for the " +
                                  "{0} files, but either you have not specified the " +
                                  "location of the custom directory, OR the specified " +
                                  "directory does not exist." +
                                  "\r\n\r\nWould you like to use the default directory? " +
                                  "\r\n\tSelect \"OK\" to continue with the default directory " +
                                  "\r\n\tSelect \"Cancel\" to cancel." +
                                  "\r\n\r\nDefault directory is: %Scripts Folder%\\{0}";

            this.WireEvents();
        }
#pragma warning restore CS8618

        protected override void Dispose(bool disposing)
        {
            if (disposing && Components != null)
            {
                Components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Form1));
            ButtonHelp = new Button();
            ButtonAbout = new Button();
            GroupBoxParameters = new GroupBox();
            linkLabelEndorse = new LinkLabel();
            LabelScriptsFolder = new Label();
            TextBoxScriptsPEXPath = new TextBox();
            CheckBoxOutputAssemblyDiffLocation = new CheckBox();
            ButtonScriptsPathBrowse = new Button();
            CheckBoxGenerateAssembly = new CheckBox();
            LabelAssemblyDestination = new Label();
            LabelSourceDestination = new Label();
            btnSourceDestinationBrowse = new Button();
            chkGenerateComments = new CheckBox();
            txtAssemblyPath = new TextBox();
            chkUseDifferentDirectoryForSource = new CheckBox();
            txtSourcePath = new TextBox();
            btnAssemblyPathBrowse = new Button();
            GroupBoxProgress = new GroupBox();
            ProgressBarProgress = new ProgressBar();
            ButtonRun = new Button();
            btnExit = new Button();
            LabelAuthor = new Label();
            LinkLabelAuthorOriginal = new LinkLabel();
            LabelUpdatedBy = new Label();
            LinkLabelAuthorRevision = new LinkLabel();
            FolderDialog = new FolderBrowserDialog();
            labelVersion = new Label();
            GroupBoxParameters.SuspendLayout();
            GroupBoxProgress.SuspendLayout();
            SuspendLayout();
            // 
            // ButtonHelp
            // 
            ButtonHelp.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ButtonHelp.Location = new Point(763, 17);
            ButtonHelp.Margin = new Padding(4, 3, 4, 3);
            ButtonHelp.Name = "ButtonHelp";
            ButtonHelp.Size = new Size(88, 27);
            ButtonHelp.TabIndex = 2;
            ButtonHelp.Text = "Help...";
            ButtonHelp.UseVisualStyleBackColor = true;
            // 
            // ButtonAbout
            // 
            ButtonAbout.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ButtonAbout.Location = new Point(668, 17);
            ButtonAbout.Margin = new Padding(4, 3, 4, 3);
            ButtonAbout.Name = "ButtonAbout";
            ButtonAbout.Size = new Size(88, 27);
            ButtonAbout.TabIndex = 3;
            ButtonAbout.Text = "About...";
            ButtonAbout.UseVisualStyleBackColor = true;
            // 
            // GroupBoxParameters
            // 
            GroupBoxParameters.Controls.Add(linkLabelEndorse);
            GroupBoxParameters.Controls.Add(LabelScriptsFolder);
            GroupBoxParameters.Controls.Add(TextBoxScriptsPEXPath);
            GroupBoxParameters.Controls.Add(CheckBoxOutputAssemblyDiffLocation);
            GroupBoxParameters.Controls.Add(ButtonScriptsPathBrowse);
            GroupBoxParameters.Controls.Add(CheckBoxGenerateAssembly);
            GroupBoxParameters.Controls.Add(LabelAssemblyDestination);
            GroupBoxParameters.Controls.Add(LabelSourceDestination);
            GroupBoxParameters.Controls.Add(btnSourceDestinationBrowse);
            GroupBoxParameters.Controls.Add(chkGenerateComments);
            GroupBoxParameters.Controls.Add(txtAssemblyPath);
            GroupBoxParameters.Controls.Add(chkUseDifferentDirectoryForSource);
            GroupBoxParameters.Controls.Add(txtSourcePath);
            GroupBoxParameters.Controls.Add(btnAssemblyPathBrowse);
            GroupBoxParameters.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            GroupBoxParameters.Location = new Point(13, 51);
            GroupBoxParameters.Margin = new Padding(4, 3, 4, 3);
            GroupBoxParameters.Name = "GroupBoxParameters";
            GroupBoxParameters.Padding = new Padding(4, 3, 4, 3);
            GroupBoxParameters.Size = new Size(838, 261);
            GroupBoxParameters.TabIndex = 4;
            GroupBoxParameters.TabStop = false;
            GroupBoxParameters.Text = "Parameters";
            // 
            // linkLabelEndorse
            // 
            linkLabelEndorse.AutoSize = true;
            linkLabelEndorse.Location = new Point(611, 146);
            linkLabelEndorse.Name = "linkLabelEndorse";
            linkLabelEndorse.Size = new Size(118, 20);
            linkLabelEndorse.TabIndex = 28;
            linkLabelEndorse.TabStop = true;
            linkLabelEndorse.Text = "Please Endorse!";
            linkLabelEndorse.LinkClicked += linkLabelEndorse_LinkClicked;
            // 
            // LabelScriptsFolder
            // 
            LabelScriptsFolder.AutoSize = true;
            LabelScriptsFolder.Font = new Font("Segoe UI", 9F);
            LabelScriptsFolder.Location = new Point(13, 29);
            LabelScriptsFolder.Margin = new Padding(4, 0, 4, 0);
            LabelScriptsFolder.Name = "LabelScriptsFolder";
            LabelScriptsFolder.Size = new Size(114, 15);
            LabelScriptsFolder.TabIndex = 14;
            LabelScriptsFolder.Text = "Scripts Folder (.pex):";
            // 
            // TextBoxScriptsPEXPath
            // 
            TextBoxScriptsPEXPath.BackColor = SystemColors.ControlLightLight;
            TextBoxScriptsPEXPath.Location = new Point(223, 23);
            TextBoxScriptsPEXPath.Margin = new Padding(4, 3, 4, 3);
            TextBoxScriptsPEXPath.Name = "TextBoxScriptsPEXPath";
            TextBoxScriptsPEXPath.Size = new Size(506, 27);
            TextBoxScriptsPEXPath.TabIndex = 15;
            // 
            // CheckBoxOutputAssemblyDiffLocation
            // 
            CheckBoxOutputAssemblyDiffLocation.AutoSize = true;
            CheckBoxOutputAssemblyDiffLocation.Enabled = false;
            CheckBoxOutputAssemblyDiffLocation.Font = new Font("Segoe UI", 9F);
            CheckBoxOutputAssemblyDiffLocation.Location = new Point(223, 149);
            CheckBoxOutputAssemblyDiffLocation.Margin = new Padding(4, 3, 4, 3);
            CheckBoxOutputAssemblyDiffLocation.Name = "CheckBoxOutputAssemblyDiffLocation";
            CheckBoxOutputAssemblyDiffLocation.Size = new Size(229, 19);
            CheckBoxOutputAssemblyDiffLocation.TabIndex = 22;
            CheckBoxOutputAssemblyDiffLocation.Text = "Output Assembly in Different Location";
            CheckBoxOutputAssemblyDiffLocation.UseVisualStyleBackColor = true;
            // 
            // ButtonScriptsPathBrowse
            // 
            ButtonScriptsPathBrowse.Font = new Font("Segoe UI", 9F);
            ButtonScriptsPathBrowse.Location = new Point(734, 22);
            ButtonScriptsPathBrowse.Margin = new Padding(4, 3, 4, 3);
            ButtonScriptsPathBrowse.Name = "ButtonScriptsPathBrowse";
            ButtonScriptsPathBrowse.Size = new Size(96, 29);
            ButtonScriptsPathBrowse.TabIndex = 16;
            ButtonScriptsPathBrowse.Text = "Browse";
            ButtonScriptsPathBrowse.UseVisualStyleBackColor = true;
            // 
            // CheckBoxGenerateAssembly
            // 
            CheckBoxGenerateAssembly.AutoSize = true;
            CheckBoxGenerateAssembly.Font = new Font("Segoe UI", 9F);
            CheckBoxGenerateAssembly.Location = new Point(15, 149);
            CheckBoxGenerateAssembly.Margin = new Padding(4, 3, 4, 3);
            CheckBoxGenerateAssembly.Name = "CheckBoxGenerateAssembly";
            CheckBoxGenerateAssembly.Size = new Size(127, 19);
            CheckBoxGenerateAssembly.TabIndex = 21;
            CheckBoxGenerateAssembly.Text = "Generate Assembly";
            CheckBoxGenerateAssembly.UseVisualStyleBackColor = true;
            // 
            // LabelAssemblyDestination
            // 
            LabelAssemblyDestination.AutoSize = true;
            LabelAssemblyDestination.Font = new Font("Segoe UI", 9F);
            LabelAssemblyDestination.Location = new Point(13, 189);
            LabelAssemblyDestination.Margin = new Padding(4, 0, 4, 0);
            LabelAssemblyDestination.Name = "LabelAssemblyDestination";
            LabelAssemblyDestination.Size = new Size(124, 15);
            LabelAssemblyDestination.TabIndex = 23;
            LabelAssemblyDestination.Text = "Assembly Destination:";
            // 
            // LabelSourceDestination
            // 
            LabelSourceDestination.AutoSize = true;
            LabelSourceDestination.Font = new Font("Segoe UI", 9F);
            LabelSourceDestination.Location = new Point(13, 109);
            LabelSourceDestination.Margin = new Padding(4, 0, 4, 0);
            LabelSourceDestination.Name = "LabelSourceDestination";
            LabelSourceDestination.Size = new Size(109, 15);
            LabelSourceDestination.TabIndex = 17;
            LabelSourceDestination.Text = "Source Destination:";
            // 
            // btnSourceDestinationBrowse
            // 
            btnSourceDestinationBrowse.Enabled = false;
            btnSourceDestinationBrowse.Font = new Font("Segoe UI", 9F);
            btnSourceDestinationBrowse.Location = new Point(734, 102);
            btnSourceDestinationBrowse.Margin = new Padding(4, 3, 4, 3);
            btnSourceDestinationBrowse.Name = "btnSourceDestinationBrowse";
            btnSourceDestinationBrowse.Size = new Size(96, 29);
            btnSourceDestinationBrowse.TabIndex = 20;
            btnSourceDestinationBrowse.Text = "Browse";
            btnSourceDestinationBrowse.UseVisualStyleBackColor = true;
            // 
            // chkGenerateComments
            // 
            chkGenerateComments.AutoSize = true;
            chkGenerateComments.Font = new Font("Segoe UI", 9F);
            chkGenerateComments.Location = new Point(15, 229);
            chkGenerateComments.Margin = new Padding(4, 3, 4, 3);
            chkGenerateComments.Name = "chkGenerateComments";
            chkGenerateComments.Size = new Size(135, 19);
            chkGenerateComments.TabIndex = 26;
            chkGenerateComments.Text = "Generate Comments";
            chkGenerateComments.UseVisualStyleBackColor = true;
            // 
            // txtAssemblyPath
            // 
            txtAssemblyPath.BackColor = SystemColors.ControlLightLight;
            txtAssemblyPath.Enabled = false;
            txtAssemblyPath.Location = new Point(223, 183);
            txtAssemblyPath.Margin = new Padding(4, 3, 4, 3);
            txtAssemblyPath.Name = "txtAssemblyPath";
            txtAssemblyPath.Size = new Size(506, 27);
            txtAssemblyPath.TabIndex = 24;
            // 
            // chkUseDifferentDirectoryForSource
            // 
            chkUseDifferentDirectoryForSource.AutoSize = true;
            chkUseDifferentDirectoryForSource.Font = new Font("Segoe UI", 9F);
            chkUseDifferentDirectoryForSource.Location = new Point(15, 69);
            chkUseDifferentDirectoryForSource.Margin = new Padding(4, 3, 4, 3);
            chkUseDifferentDirectoryForSource.Name = "chkUseDifferentDirectoryForSource";
            chkUseDifferentDirectoryForSource.Size = new Size(247, 19);
            chkUseDifferentDirectoryForSource.TabIndex = 18;
            chkUseDifferentDirectoryForSource.Text = "Use custom source (.psc) output directory";
            chkUseDifferentDirectoryForSource.UseVisualStyleBackColor = true;
            // 
            // txtSourcePath
            // 
            txtSourcePath.BackColor = SystemColors.ControlLightLight;
            txtSourcePath.Enabled = false;
            txtSourcePath.Location = new Point(223, 103);
            txtSourcePath.Margin = new Padding(4, 3, 4, 3);
            txtSourcePath.Name = "txtSourcePath";
            txtSourcePath.Size = new Size(506, 27);
            txtSourcePath.TabIndex = 19;
            // 
            // btnAssemblyPathBrowse
            // 
            btnAssemblyPathBrowse.Enabled = false;
            btnAssemblyPathBrowse.Font = new Font("Segoe UI", 9F);
            btnAssemblyPathBrowse.Location = new Point(734, 182);
            btnAssemblyPathBrowse.Margin = new Padding(4, 3, 4, 3);
            btnAssemblyPathBrowse.Name = "btnAssemblyPathBrowse";
            btnAssemblyPathBrowse.Size = new Size(96, 29);
            btnAssemblyPathBrowse.TabIndex = 25;
            btnAssemblyPathBrowse.Text = "Browse";
            btnAssemblyPathBrowse.UseVisualStyleBackColor = true;
            // 
            // GroupBoxProgress
            // 
            GroupBoxProgress.Controls.Add(ProgressBarProgress);
            GroupBoxProgress.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            GroupBoxProgress.Location = new Point(13, 318);
            GroupBoxProgress.Margin = new Padding(4, 3, 4, 3);
            GroupBoxProgress.Name = "GroupBoxProgress";
            GroupBoxProgress.Padding = new Padding(4, 3, 4, 3);
            GroupBoxProgress.Size = new Size(838, 96);
            GroupBoxProgress.TabIndex = 5;
            GroupBoxProgress.TabStop = false;
            GroupBoxProgress.Text = "Progress";
            // 
            // ProgressBarProgress
            // 
            ProgressBarProgress.Location = new Point(7, 38);
            ProgressBarProgress.Margin = new Padding(4, 3, 4, 3);
            ProgressBarProgress.Name = "ProgressBarProgress";
            ProgressBarProgress.Size = new Size(823, 27);
            ProgressBarProgress.TabIndex = 0;
            // 
            // ButtonRun
            // 
            ButtonRun.Location = new Point(436, 423);
            ButtonRun.Margin = new Padding(4, 3, 4, 3);
            ButtonRun.Name = "ButtonRun";
            ButtonRun.Size = new Size(88, 27);
            ButtonRun.TabIndex = 0;
            ButtonRun.Text = "Run...";
            ButtonRun.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(339, 423);
            btnExit.Margin = new Padding(4, 3, 4, 3);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(88, 27);
            btnExit.TabIndex = 1;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            // 
            // LabelAuthor
            // 
            LabelAuthor.AutoSize = true;
            LabelAuthor.Location = new Point(12, 9);
            LabelAuthor.Name = "LabelAuthor";
            LabelAuthor.Size = new Size(64, 15);
            LabelAuthor.TabIndex = 7;
            LabelAuthor.Text = "Created by";
            // 
            // LinkLabelAuthorOriginal
            // 
            LinkLabelAuthorOriginal.AutoSize = true;
            LinkLabelAuthorOriginal.Location = new Point(73, 9);
            LinkLabelAuthorOriginal.Name = "LinkLabelAuthorOriginal";
            LinkLabelAuthorOriginal.Size = new Size(93, 15);
            LinkLabelAuthorOriginal.TabIndex = 8;
            LinkLabelAuthorOriginal.TabStop = true;
            LinkLabelAuthorOriginal.Text = "Arron Dominion";
            LinkLabelAuthorOriginal.LinkClicked += linkLabelAuthorOriginal_LinkClicked;
            // 
            // LabelUpdatedBy
            // 
            LabelUpdatedBy.AutoSize = true;
            LabelUpdatedBy.Location = new Point(12, 29);
            LabelUpdatedBy.Name = "LabelUpdatedBy";
            LabelUpdatedBy.Size = new Size(146, 15);
            LabelUpdatedBy.TabIndex = 9;
            LabelUpdatedBy.Text = "Updated and enhanced by";
            // 
            // LinkLabelAuthorRevision
            // 
            LinkLabelAuthorRevision.AutoSize = true;
            LinkLabelAuthorRevision.Location = new Point(157, 29);
            LinkLabelAuthorRevision.Name = "LinkLabelAuthorRevision";
            LinkLabelAuthorRevision.Size = new Size(65, 15);
            LinkLabelAuthorRevision.TabIndex = 10;
            LinkLabelAuthorRevision.TabStop = true;
            LinkLabelAuthorRevision.Text = "w1ndStrik3";
            LinkLabelAuthorRevision.LinkClicked += linkLabelAuthorRevision_LinkClicked;
            // 
            // labelVersion
            // 
            labelVersion.AutoSize = true;
            labelVersion.ForeColor = Color.Gray;
            labelVersion.Location = new Point(683, 433);
            labelVersion.Name = "labelVersion";
            labelVersion.Size = new Size(169, 15);
            labelVersion.TabIndex = 11;
            labelVersion.Text = "Version: 2.1 Alpha (12/12/2023)";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(864, 457);
            Controls.Add(labelVersion);
            Controls.Add(ButtonRun);
            Controls.Add(LinkLabelAuthorRevision);
            Controls.Add(LabelUpdatedBy);
            Controls.Add(btnExit);
            Controls.Add(LinkLabelAuthorOriginal);
            Controls.Add(LabelAuthor);
            Controls.Add(GroupBoxParameters);
            Controls.Add(ButtonAbout);
            Controls.Add(ButtonHelp);
            Controls.Add(GroupBoxProgress);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "Champollion Interface";
            GroupBoxParameters.ResumeLayout(false);
            GroupBoxParameters.PerformLayout();
            GroupBoxProgress.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private void WireEvents()
        {
            ButtonAbout.Click += new EventHandler(this.btnAbout_Click);
            btnAssemblyPathBrowse.Click += new EventHandler(this.btnAssemblyPathBrowse_Click);
            btnExit.Click += new EventHandler(this.btnExit_Click);
            ButtonHelp.Click += new EventHandler(this.btnHelp_Click);
            ButtonRun.Click += new EventHandler(this.btnRun_Click);
            ButtonScriptsPathBrowse.Click += new EventHandler(this.btnScriptsPathBrowse_Click);
            btnSourceDestinationBrowse.Click += new EventHandler(this.btnSourceDestinationBrowse_Click);
            CheckBoxGenerateAssembly.CheckedChanged += new EventHandler(this.chkGenerateAssembly_CheckedChanged);
            CheckBoxOutputAssemblyDiffLocation.CheckedChanged += new EventHandler(this.chkOutputAssemblyDiffLocation_CheckedChanged);
            chkUseDifferentDirectoryForSource.CheckedChanged += new EventHandler(this.chkUseDifferentDirectoryForSource_CheckedChanged);
        }

        private void UnWireEvents()
        {
            ButtonAbout.Click -= new EventHandler(this.btnAbout_Click);
            btnAssemblyPathBrowse.Click -= new EventHandler(this.btnAssemblyPathBrowse_Click);
            btnExit.Click -= new EventHandler(this.btnExit_Click);
            ButtonHelp.Click -= new EventHandler(this.btnHelp_Click);
            ButtonRun.Click -= new EventHandler(this.btnRun_Click);
            ButtonScriptsPathBrowse.Click -= new EventHandler(this.btnScriptsPathBrowse_Click);
            btnSourceDestinationBrowse.Click -= new EventHandler(this.btnSourceDestinationBrowse_Click);
            CheckBoxGenerateAssembly.CheckedChanged -= new EventHandler(this.chkGenerateAssembly_CheckedChanged);
            CheckBoxOutputAssemblyDiffLocation.CheckedChanged -= new EventHandler(this.chkOutputAssemblyDiffLocation_CheckedChanged);
            chkUseDifferentDirectoryForSource.CheckedChanged -= new EventHandler(this.chkUseDifferentDirectoryForSource_CheckedChanged);
        }

        #region Form methods
        private void chkUseDifferentDirectoryForSource_CheckedChanged(Object? Sender, EventArgs EA)
        {
            btnSourceDestinationBrowse.Enabled = chkUseDifferentDirectoryForSource.Checked;
            txtSourcePath.Enabled = chkUseDifferentDirectoryForSource.Checked;

            //Clears the source Text box if the checkbox is "unticked"
            if (!chkUseDifferentDirectoryForSource.Checked)
            {
                txtSourcePath.Text = String.Empty;
            }

            /*
            if (chkUseDifferentDirectoryForSource.Checked)
            {
                btnSourceDestinationBrowse.Enabled = true;
            }
            else
            {
                btnSourceDestinationBrowse.Enabled = false;
            }
            */
        }

        private void chkOutputAssemblyDiffLocation_CheckedChanged(Object? Sender, EventArgs EA)
        {
            btnAssemblyPathBrowse.Enabled = CheckBoxOutputAssemblyDiffLocation.Checked;
            txtAssemblyPath.Enabled = CheckBoxOutputAssemblyDiffLocation.Checked;

            //Clears the assembly Text box if the checkbox is "unticked"
            if (!CheckBoxOutputAssemblyDiffLocation.Checked)
            {
                txtAssemblyPath.Text = String.Empty;
            }

            /*
            if (CheckBoxOutputAssemblyDiffLocation.Checked)
            {
                 btnAssemblyPathBrowse.Enabled = true;
            }

            else
            {
                btnAssemblyPathBrowse.Enabled = false;
            }
            */
        }

        private void chkGenerateAssembly_CheckedChanged(Object? Sender, EventArgs EA)
        {
            CheckBoxOutputAssemblyDiffLocation.Enabled = CheckBoxGenerateAssembly.Checked;
            if (!CheckBoxGenerateAssembly.Checked)
            {
                CheckBoxOutputAssemblyDiffLocation.Checked = false;
                if (!CheckBoxOutputAssemblyDiffLocation.Checked)
                {
                    txtAssemblyPath.Enabled = false;
                    txtAssemblyPath.Text = String.Empty;
                }

            }
            /*
            if (CheckBoxGenerateAssembly.Checked)
            {
                CheckBoxOutputAssemblyDiffLocation.Enabled = true;
            }
            else
            {
                CheckBoxOutputAssemblyDiffLocation.Enabled = false;
                CheckBoxOutputAssemblyDiffLocation.Checked = false;
            }
            */
        }

        private void btnSourceDestinationBrowse_Click(Object? Sender, EventArgs EA)
        {
            String Path = SelectFolder();
            if (Path != "")
            {
                txtSourcePath.Text = Path;
            }
            else
            {
                return;
            }
        }

        private void btnScriptsPathBrowse_Click(Object? Sender, EventArgs EA)
        {
            String Path = SelectFolder();
            if (Path != "")
            {
                TextBoxScriptsPEXPath.Text = Path;
            }
            else
            {
                return;
            }
        }

        private void btnAssemblyPathBrowse_Click(Object? Sender, EventArgs EA)
        {
            String Path = SelectFolder();
            if (Path != "")
            {
                txtAssemblyPath.Text = Path;
            }
            else
            {
                return;
            }
        }

        private void btnRun_Click(Object? Sender, EventArgs EA)
        {
            Decompiler = new Decompilation();
            bool[,] arguments;
            try
            {
                arguments = Decompiler.PreDecompilationChecks();
            }
            catch (ChampollionGUIException)
            {
                return;
            }

            Decompiler.Run(arguments);

            //bool pexDirOK = (!String.IsNullOrWhiteSpace(TextBoxScriptsPEXPath.Text) && Directory.Exists(TextBoxScriptsPEXPath.Text));
            //bool emptyDir = false;
            //bool outputSource = arguments[0, 0];
            //bool outputAssembly = arguments[1, 0];
            //bool breakProcess = arguments[2];

            /*
            if (breakProcess)
            {
                return;
            }
            */


        }

        private void btnHelp_Click(Object? Sender, EventArgs EA)
        {
            String Readme = "readme_instructions.txt";
            String Dir = Directory.GetCurrentDirectory();
            String Wholepath = $"{Dir}\\{Readme}";
            Process.Start(new ProcessStartInfo(Wholepath) { UseShellExecute = true });
            //Process.Start(Wholepath);
            //Process.Start(String.Format("{0}\\{1}", (object)Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
            //(object)"readme_instructions.txt"));
        }

        private void btnExit_Click(Object? Sender, EventArgs EA)
        {
            this.UnWireEvents();
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnAbout_Click(Object? Sender, EventArgs EA)
        {
            StringBuilder StringBuilder = new StringBuilder();
            StringBuilder.AppendLine("Champollion a PEX to Papyrus decompiler Graphical User Interface Version 2.1");
            StringBuilder.AppendLine("");
            StringBuilder.AppendLine("by Arron Dominion (Updated by w1ndStrik3)");
            StringBuilder.AppendLine("");
            StringBuilder.AppendLine("Description: This program provides an interface to li1nx's");
            StringBuilder.AppendLine("                   Champollion a PEX to Papyrus decompiler program");
            StringBuilder.AppendLine("Link to Original Tool: http://www.nexusmods.com/skyrim/mods/35307/");
            _ = new MessageBox("About", StringBuilder.ToString(), false).ShowDialog();
        }

        private void linkLabelAuthorOriginal_LinkClicked(Object? Sender, LinkLabelLinkClickedEventArgs LLLCEA)
        {
            // Specify that the link was visited.
            LinkLabelAuthorOriginal.LinkVisited = true;

            // Navigate to a URL.
            Process.Start("https://www.nexusmods.com/users/582310");
        }

        private void linkLabelAuthorRevision_LinkClicked(Object? Sender, LinkLabelLinkClickedEventArgs LLLCEA)
        {
            // Specify that the link was visited.
            LinkLabelAuthorRevision.LinkVisited = true;

            // Navigate to a URL.
            Process.Start("https://www.nexusmods.com/users/39381905");
        }

        private void linkLabelEndorse_LinkClicked(Object? Sender, LinkLabelLinkClickedEventArgs LLLCEA)
        {
            // Specify that the link was visited.
            linkLabelEndorse.LinkVisited = true;

            // Navigate to a URL.
            Process.Start("https://www.nexusmods.com/skyrimspecialedition/mods/92452");
        }
        #endregion

        #region Custom methods
        private String SelectFolder()
        {
            String Path = Directory.GetCurrentDirectory();
            FolderDialog.InitialDirectory = Path;
            //--FolderDialog.IsFolderPicker = true;
            //--if (FolderDialog.ShowDialog() == CommonFileDialogResult.Ok)
            if (FolderDialog.ShowDialog() == DialogResult.OK)
            {
                //--Path = FolderDialog.FileName;
                Path = FolderDialog.SelectedPath;
            }
            else
            {
                Path = "";
            }
            return Path;
        }

        
        #endregion
    }
}