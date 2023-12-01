using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using Font = System.Drawing.Font;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
//--using Microsoft.WindowsAPICodePack.Dialogs;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;


namespace ChampollionGUI_Update
{
    public class Form1 : Form
    {
        #region declarations

        private IContainer components;
        private Button btnHelp;
        private Button btnAbout;
        private GroupBox groupBoxParams;
        //private FolderBrowserDialog folderBrowserDialog1;
        //--private CommonOpenFileDialog folderDiag;
        private FolderBrowserDialog folderDiag;
        private GroupBox groupBoxProgress;
        private ProgressBar pbProgress;
        private Button btnRun;
        private Label labelCreatedBy;
        private LinkLabel linkLabelAuthorOriginal;
        private Label labelUpdatedBy;
        private LinkLabel linkLabelAuthorRevision;
        private Label labelScriptsFolder;
        private TextBox txtScriptsPEXPath;
        private CheckBox chkOutputAssemblyDiffLocation;
        private Button btnScriptsPathBrowse;
        private CheckBox chkGenerateAssembly;
        private Label labelAssemblyDestination;
        private Label labelSourceDestination;
        private Button btnSourceDestinationBrowse;
        private CheckBox chkGenerateComments;
        private TextBox txtAssemblyPath;
        private CheckBox chkUseDifferentDirectoryForSource;
        private TextBox txtSourcePath;
        private Button btnAssemblyPathBrowse;
        private LinkLabel linkLabelEndorse;
        private Label labelVersion;
        private Button btnExit;

        #endregion

        private readonly String WarningMessage;

        public Form1()
        {
            this.InitializeComponent();

            this.WarningMessage = "You have selected to use a custom directory for the " +
                                  "{0} files, but you have not specified the desired " +
                                  "directory. " +
                                  "\r\n\r\nWould you like to use the default directory? " +
                                  "\r\n\tSelect \"Yes\" to continue with the default directory " +
                                  "\r\n\tSelect \"No\" to cancel." +
                                  "\r\n\r\nDefault directory is: %Scripts Folder%\\{0}";

            this.WireEvents();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Form1));
            btnHelp = new Button();
            btnAbout = new Button();
            groupBoxParams = new GroupBox();
            linkLabelEndorse = new LinkLabel();
            labelScriptsFolder = new Label();
            txtScriptsPEXPath = new TextBox();
            chkOutputAssemblyDiffLocation = new CheckBox();
            btnScriptsPathBrowse = new Button();
            chkGenerateAssembly = new CheckBox();
            labelAssemblyDestination = new Label();
            labelSourceDestination = new Label();
            btnSourceDestinationBrowse = new Button();
            chkGenerateComments = new CheckBox();
            txtAssemblyPath = new TextBox();
            chkUseDifferentDirectoryForSource = new CheckBox();
            txtSourcePath = new TextBox();
            btnAssemblyPathBrowse = new Button();
            groupBoxProgress = new GroupBox();
            pbProgress = new ProgressBar();
            btnRun = new Button();
            btnExit = new Button();
            labelCreatedBy = new Label();
            linkLabelAuthorOriginal = new LinkLabel();
            labelUpdatedBy = new Label();
            linkLabelAuthorRevision = new LinkLabel();
            folderDiag = new FolderBrowserDialog();
            labelVersion = new Label();
            groupBoxParams.SuspendLayout();
            groupBoxProgress.SuspendLayout();
            SuspendLayout();
            // 
            // btnHelp
            // 
            btnHelp.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnHelp.Location = new Point(763, 17);
            btnHelp.Margin = new Padding(4, 3, 4, 3);
            btnHelp.Name = "btnHelp";
            btnHelp.Size = new Size(88, 27);
            btnHelp.TabIndex = 2;
            btnHelp.Text = "Help...";
            btnHelp.UseVisualStyleBackColor = true;
            // 
            // btnAbout
            // 
            btnAbout.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAbout.Location = new Point(668, 17);
            btnAbout.Margin = new Padding(4, 3, 4, 3);
            btnAbout.Name = "btnAbout";
            btnAbout.Size = new Size(88, 27);
            btnAbout.TabIndex = 3;
            btnAbout.Text = "About...";
            btnAbout.UseVisualStyleBackColor = true;
            // 
            // groupBoxParams
            // 
            groupBoxParams.Controls.Add(linkLabelEndorse);
            groupBoxParams.Controls.Add(labelScriptsFolder);
            groupBoxParams.Controls.Add(txtScriptsPEXPath);
            groupBoxParams.Controls.Add(chkOutputAssemblyDiffLocation);
            groupBoxParams.Controls.Add(btnScriptsPathBrowse);
            groupBoxParams.Controls.Add(chkGenerateAssembly);
            groupBoxParams.Controls.Add(labelAssemblyDestination);
            groupBoxParams.Controls.Add(labelSourceDestination);
            groupBoxParams.Controls.Add(btnSourceDestinationBrowse);
            groupBoxParams.Controls.Add(chkGenerateComments);
            groupBoxParams.Controls.Add(txtAssemblyPath);
            groupBoxParams.Controls.Add(chkUseDifferentDirectoryForSource);
            groupBoxParams.Controls.Add(txtSourcePath);
            groupBoxParams.Controls.Add(btnAssemblyPathBrowse);
            groupBoxParams.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            groupBoxParams.Location = new Point(13, 51);
            groupBoxParams.Margin = new Padding(4, 3, 4, 3);
            groupBoxParams.Name = "groupBoxParams";
            groupBoxParams.Padding = new Padding(4, 3, 4, 3);
            groupBoxParams.Size = new Size(838, 261);
            groupBoxParams.TabIndex = 4;
            groupBoxParams.TabStop = false;
            groupBoxParams.Text = "Parameters";
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
            // labelScriptsFolder
            // 
            labelScriptsFolder.AutoSize = true;
            labelScriptsFolder.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            labelScriptsFolder.Location = new Point(13, 29);
            labelScriptsFolder.Margin = new Padding(4, 0, 4, 0);
            labelScriptsFolder.Name = "labelScriptsFolder";
            labelScriptsFolder.Size = new Size(114, 15);
            labelScriptsFolder.TabIndex = 14;
            labelScriptsFolder.Text = "Scripts Folder (.pex):";
            // 
            // txtScriptsPEXPath
            // 
            txtScriptsPEXPath.BackColor = SystemColors.ControlLightLight;
            txtScriptsPEXPath.Location = new Point(223, 23);
            txtScriptsPEXPath.Margin = new Padding(4, 3, 4, 3);
            txtScriptsPEXPath.Name = "txtScriptsPEXPath";
            txtScriptsPEXPath.Size = new Size(506, 27);
            txtScriptsPEXPath.TabIndex = 15;
            // 
            // chkOutputAssemblyDiffLocation
            // 
            chkOutputAssemblyDiffLocation.AutoSize = true;
            chkOutputAssemblyDiffLocation.Enabled = false;
            chkOutputAssemblyDiffLocation.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            chkOutputAssemblyDiffLocation.Location = new Point(223, 149);
            chkOutputAssemblyDiffLocation.Margin = new Padding(4, 3, 4, 3);
            chkOutputAssemblyDiffLocation.Name = "chkOutputAssemblyDiffLocation";
            chkOutputAssemblyDiffLocation.Size = new Size(229, 19);
            chkOutputAssemblyDiffLocation.TabIndex = 22;
            chkOutputAssemblyDiffLocation.Text = "Output Assembly in Different Location";
            chkOutputAssemblyDiffLocation.UseVisualStyleBackColor = true;
            // 
            // btnScriptsPathBrowse
            // 
            btnScriptsPathBrowse.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnScriptsPathBrowse.Location = new Point(734, 22);
            btnScriptsPathBrowse.Margin = new Padding(4, 3, 4, 3);
            btnScriptsPathBrowse.Name = "btnScriptsPathBrowse";
            btnScriptsPathBrowse.Size = new Size(96, 29);
            btnScriptsPathBrowse.TabIndex = 16;
            btnScriptsPathBrowse.Text = "Browse";
            btnScriptsPathBrowse.UseVisualStyleBackColor = true;
            // 
            // chkGenerateAssembly
            // 
            chkGenerateAssembly.AutoSize = true;
            chkGenerateAssembly.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            chkGenerateAssembly.Location = new Point(15, 149);
            chkGenerateAssembly.Margin = new Padding(4, 3, 4, 3);
            chkGenerateAssembly.Name = "chkGenerateAssembly";
            chkGenerateAssembly.Size = new Size(127, 19);
            chkGenerateAssembly.TabIndex = 21;
            chkGenerateAssembly.Text = "Generate Assembly";
            chkGenerateAssembly.UseVisualStyleBackColor = true;
            // 
            // labelAssemblyDestination
            // 
            labelAssemblyDestination.AutoSize = true;
            labelAssemblyDestination.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            labelAssemblyDestination.Location = new Point(13, 189);
            labelAssemblyDestination.Margin = new Padding(4, 0, 4, 0);
            labelAssemblyDestination.Name = "labelAssemblyDestination";
            labelAssemblyDestination.Size = new Size(124, 15);
            labelAssemblyDestination.TabIndex = 23;
            labelAssemblyDestination.Text = "Assembly Destination:";
            // 
            // labelSourceDestination
            // 
            labelSourceDestination.AutoSize = true;
            labelSourceDestination.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            labelSourceDestination.Location = new Point(13, 109);
            labelSourceDestination.Margin = new Padding(4, 0, 4, 0);
            labelSourceDestination.Name = "labelSourceDestination";
            labelSourceDestination.Size = new Size(109, 15);
            labelSourceDestination.TabIndex = 17;
            labelSourceDestination.Text = "Source Destination:";
            // 
            // btnSourceDestinationBrowse
            // 
            btnSourceDestinationBrowse.Enabled = false;
            btnSourceDestinationBrowse.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
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
            chkGenerateComments.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
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
            chkUseDifferentDirectoryForSource.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
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
            btnAssemblyPathBrowse.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnAssemblyPathBrowse.Location = new Point(734, 182);
            btnAssemblyPathBrowse.Margin = new Padding(4, 3, 4, 3);
            btnAssemblyPathBrowse.Name = "btnAssemblyPathBrowse";
            btnAssemblyPathBrowse.Size = new Size(96, 29);
            btnAssemblyPathBrowse.TabIndex = 25;
            btnAssemblyPathBrowse.Text = "Browse";
            btnAssemblyPathBrowse.UseVisualStyleBackColor = true;
            // 
            // groupBoxProgress
            // 
            groupBoxProgress.Controls.Add(pbProgress);
            groupBoxProgress.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            groupBoxProgress.Location = new Point(13, 318);
            groupBoxProgress.Margin = new Padding(4, 3, 4, 3);
            groupBoxProgress.Name = "groupBoxProgress";
            groupBoxProgress.Padding = new Padding(4, 3, 4, 3);
            groupBoxProgress.Size = new Size(838, 96);
            groupBoxProgress.TabIndex = 5;
            groupBoxProgress.TabStop = false;
            groupBoxProgress.Text = "Progress";
            // 
            // pbProgress
            // 
            pbProgress.Location = new Point(7, 38);
            pbProgress.Margin = new Padding(4, 3, 4, 3);
            pbProgress.Name = "pbProgress";
            pbProgress.Size = new Size(823, 27);
            pbProgress.TabIndex = 0;
            // 
            // btnRun
            // 
            btnRun.Location = new Point(436, 423);
            btnRun.Margin = new Padding(4, 3, 4, 3);
            btnRun.Name = "btnRun";
            btnRun.Size = new Size(88, 27);
            btnRun.TabIndex = 0;
            btnRun.Text = "Run...";
            btnRun.UseVisualStyleBackColor = true;
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
            // labelCreatedBy
            // 
            labelCreatedBy.AutoSize = true;
            labelCreatedBy.Location = new Point(12, 9);
            labelCreatedBy.Name = "labelCreatedBy";
            labelCreatedBy.Size = new Size(64, 15);
            labelCreatedBy.TabIndex = 7;
            labelCreatedBy.Text = "Created by";
            // 
            // linkLabelAuthorOriginal
            // 
            linkLabelAuthorOriginal.AutoSize = true;
            linkLabelAuthorOriginal.Location = new Point(73, 9);
            linkLabelAuthorOriginal.Name = "linkLabelAuthorOriginal";
            linkLabelAuthorOriginal.Size = new Size(93, 15);
            linkLabelAuthorOriginal.TabIndex = 8;
            linkLabelAuthorOriginal.TabStop = true;
            linkLabelAuthorOriginal.Text = "Arron Dominion";
            linkLabelAuthorOriginal.LinkClicked += linkLabelAuthorOriginal_LinkClicked;
            // 
            // labelUpdatedBy
            // 
            labelUpdatedBy.AutoSize = true;
            labelUpdatedBy.Location = new Point(12, 29);
            labelUpdatedBy.Name = "labelUpdatedBy";
            labelUpdatedBy.Size = new Size(146, 15);
            labelUpdatedBy.TabIndex = 9;
            labelUpdatedBy.Text = "Updated and enhanced by";
            // 
            // linkLabelAuthorRevision
            // 
            linkLabelAuthorRevision.AutoSize = true;
            linkLabelAuthorRevision.Location = new Point(157, 29);
            linkLabelAuthorRevision.Name = "linkLabelAuthorRevision";
            linkLabelAuthorRevision.Size = new Size(65, 15);
            linkLabelAuthorRevision.TabIndex = 10;
            linkLabelAuthorRevision.TabStop = true;
            linkLabelAuthorRevision.Text = "w1ndStrik3";
            linkLabelAuthorRevision.LinkClicked += linkLabelAuthorRevision_LinkClicked;
            // 
            // labelVersion
            // 
            labelVersion.AutoSize = true;
            labelVersion.ForeColor = Color.Gray;
            labelVersion.Location = new Point(717, 433);
            labelVersion.Name = "labelVersion";
            labelVersion.Size = new Size(135, 15);
            labelVersion.TabIndex = 11;
            labelVersion.Text = "Version: 2.1 (29/11/2023)";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(864, 457);
            Controls.Add(labelVersion);
            Controls.Add(btnRun);
            Controls.Add(linkLabelAuthorRevision);
            Controls.Add(labelUpdatedBy);
            Controls.Add(btnExit);
            Controls.Add(linkLabelAuthorOriginal);
            Controls.Add(labelCreatedBy);
            Controls.Add(groupBoxParams);
            Controls.Add(btnAbout);
            Controls.Add(btnHelp);
            Controls.Add(groupBoxProgress);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "Champollion Interface";
            groupBoxParams.ResumeLayout(false);
            groupBoxParams.PerformLayout();
            groupBoxProgress.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private void WireEvents()
        {
            btnAbout.Click += new EventHandler(this.btnAbout_Click);
            btnAssemblyPathBrowse.Click += new EventHandler(this.btnAssemblyPathBrowse_Click);
            btnExit.Click += new EventHandler(this.btnExit_Click);
            btnHelp.Click += new EventHandler(this.btnHelp_Click);
            btnRun.Click += new EventHandler(this.btnRun_Click);
            btnScriptsPathBrowse.Click += new EventHandler(this.btnScriptsPathBrowse_Click);
            btnSourceDestinationBrowse.Click += new EventHandler(this.btnSourceDestinationBrowse_Click);
            chkGenerateAssembly.CheckedChanged += new EventHandler(this.chkGenerateAssembly_CheckedChanged);
            chkOutputAssemblyDiffLocation.CheckedChanged += new EventHandler(this.chkOutputAssemblyDiffLocation_CheckedChanged);
            chkUseDifferentDirectoryForSource.CheckedChanged += new EventHandler(this.chkUseDifferentDirectoryForSource_CheckedChanged);
        }

        private void UnWireEvents()
        {
            btnAbout.Click -= new EventHandler(this.btnAbout_Click);
            btnAssemblyPathBrowse.Click -= new EventHandler(this.btnAssemblyPathBrowse_Click);
            btnExit.Click -= new EventHandler(this.btnExit_Click);
            btnHelp.Click -= new EventHandler(this.btnHelp_Click);
            btnRun.Click -= new EventHandler(this.btnRun_Click);
            btnScriptsPathBrowse.Click -= new EventHandler(this.btnScriptsPathBrowse_Click);
            btnSourceDestinationBrowse.Click -= new EventHandler(this.btnSourceDestinationBrowse_Click);
            chkGenerateAssembly.CheckedChanged -= new EventHandler(this.chkGenerateAssembly_CheckedChanged);
            chkOutputAssemblyDiffLocation.CheckedChanged -= new EventHandler(this.chkOutputAssemblyDiffLocation_CheckedChanged);
            chkUseDifferentDirectoryForSource.CheckedChanged -= new EventHandler(this.chkUseDifferentDirectoryForSource_CheckedChanged);
        }

        private void chkUseDifferentDirectoryForSource_CheckedChanged(object sender, EventArgs e)
        {
            btnSourceDestinationBrowse.Enabled = chkUseDifferentDirectoryForSource.Checked;
            txtSourcePath.Enabled = chkUseDifferentDirectoryForSource.Checked;

            //Clears the source text box if the checkbox is "unticked"
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

        private void chkOutputAssemblyDiffLocation_CheckedChanged(object sender, EventArgs e)
        {
            btnAssemblyPathBrowse.Enabled = chkOutputAssemblyDiffLocation.Checked;
            txtAssemblyPath.Enabled = chkOutputAssemblyDiffLocation.Checked;

            //Clears the assembly text box if the checkbox is "unticked"
            if (!chkOutputAssemblyDiffLocation.Checked)
            {
                txtAssemblyPath.Text = String.Empty;
            }

            /*
            if (chkOutputAssemblyDiffLocation.Checked)
            {
                 btnAssemblyPathBrowse.Enabled = true;
            }

            else
            {
                btnAssemblyPathBrowse.Enabled = false;
            }
            */
        }

        private void chkGenerateAssembly_CheckedChanged(object sender, EventArgs e)
        {
            chkOutputAssemblyDiffLocation.Enabled = chkGenerateAssembly.Checked;
            if (!chkGenerateAssembly.Checked)
            {
                chkOutputAssemblyDiffLocation.Checked = false;
                if (!chkOutputAssemblyDiffLocation.Checked)
                {
                    txtAssemblyPath.Enabled = false;
                    txtAssemblyPath.Text = String.Empty;
                }

            }
            /*
            if (chkGenerateAssembly.Checked)
            {
                chkOutputAssemblyDiffLocation.Enabled = true;
            }
            else
            {
                chkOutputAssemblyDiffLocation.Enabled = false;
                chkOutputAssemblyDiffLocation.Checked = false;
            }
            */
        }

        private void btnSourceDestinationBrowse_Click(object sender, EventArgs e)
        {
            String Path = SelectFolder();
            if (Path != null)
            {
                txtSourcePath.Text = Path;
            }
            else
            {
                return;
            }
        }

        private void btnScriptsPathBrowse_Click(object sender, EventArgs e)
        {
            String Path = SelectFolder();
            if (Path != null)
            {
                txtScriptsPEXPath.Text = Path;
            }
            else
            {
                return;
            }
        }

        private void btnAssemblyPathBrowse_Click(object sender, EventArgs e)
        {
            String Path = SelectFolder();
            if (Path != null)
            {
                txtAssemblyPath.Text = Path;
            }
            else
            {
                return;
            }
        }

        private String SelectFolder()
        {
            String path = Directory.GetCurrentDirectory();
            folderDiag.InitialDirectory = path;
            //--folderDiag.IsFolderPicker = true;
            //--if (folderDiag.ShowDialog() == CommonFileDialogResult.Ok)
            if (folderDiag.ShowDialog() == DialogResult.OK)
            {
                //--path = folderDiag.FileName;
                path = folderDiag.SelectedPath;
            }
            else
            {
                path = null;
            }
            return path;
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            bool sourceOK = (!String.IsNullOrWhiteSpace(txtScriptsPEXPath.Text) && Directory.Exists(txtScriptsPEXPath.Text));
            bool emptyDir = false;
            bool outputSource = false;
            bool outputAssembly = false;
            bool breakProcess = false;


            if (Directory.GetFiles(txtScriptsPEXPath.Text, "*.pex").Length == 0)
            {
                if (Directory.GetFiles(txtScriptsPEXPath.Text).Length == 0)
                {
                    _ = new MessageBox("Run Error", "Unable to run - Chosen source directory is empty.", false).ShowDialog();
                }
                else
                {
                    _ = new MessageBox("Run Error", "Unable to run - Chosen source directory does not contain any .pex files.", false).ShowDialog();
                }

                sourceOK = false;
                emptyDir = true;
            }


            if (!sourceOK)
            {
                if (!String.IsNullOrWhiteSpace(txtScriptsPEXPath.Text))
                {
                    _ = new MessageBox("Run Error", "Unable to run - PEX Path empty", false).ShowDialog();
                }
                else if (!Directory.Exists(txtScriptsPEXPath.Text))
                {
                    _ = new MessageBox("Run Error", "Unable to run - Source directory does not exist.", false).ShowDialog();
                }
                else if (!emptyDir)
                {
                    //Something real fishy should happen for this to trigger. No idea how it would.
                    String Fishy = "Unknown Error. Please report the following error message\r\n" +
                                   "on the mod page on nexus mods along with a screenshot:" + /* and attach your error log file */ "\r\n" +
                                   "\"Error message: souceOK_Failed_Check\"";

                    _ = new MessageBox("Run Error", Fishy, false).ShowDialog();
                }
                return;
            }
            if (chkUseDifferentDirectoryForSource.Checked)
            {
                if (!String.IsNullOrWhiteSpace(txtSourcePath.Text))
                {
                    outputSource = true;
                }
                else
                {
                    breakProcess = SendWarning("source");
                }
            }

            if(breakProcess)
            {
                return;
            }

            if (chkGenerateAssembly.Checked)
            {
                if (chkOutputAssemblyDiffLocation.Checked)
                {
                    if (!string.IsNullOrWhiteSpace(txtAssemblyPath.Text))
                    {
                        outputAssembly = true;
                    }
                    else
                    {
                        breakProcess = SendWarning("assembly");
                    }
                }
            }

            if (breakProcess)
            {
                return;
            }

            //else
            //{
                if (new MessageBox("Confirm Run", "Are you sure you want to run Champollion?", true).ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                else //(!string.IsNullOrWhiteSpace(txtScriptsPEXPath.Text))
                {
                    /*
                    In the name of Christ and everything holy, that was the longest condition statement i have ever seen.
                    550 character long condition statement... No offense but I will make it look prettier.
                    This is not a criticism, just very surprised. Look, if it works, it works. Everything else is personal preference.
                    The condition statement can be expressed in boolean algebra as "F=(A*B*C)+(C*D*E).
                    -w1ndStrik3



                    if (chkUseDifferentDirectoryForSource.Checked && string.IsNullOrWhiteSpace(txtSourcePath.Text) && new MessageBox("Confirm Continue Run", "Output Source is checked but destination is empty. \n Do you want to continue?", true).DialogResult == DialogResult.Cancel || chkGenerateAssembly.Checked && chkOutputAssemblyDiffLocation.Checked && string.IsNullOrWhiteSpace(txtAssemblyPath.Text) && new MessageBox("Confirm Continue Run", "Assembly Location is checked but destination is empty. \n Do you want to continue?", true).DialogResult == DialogResult.Cancel)
                    {
                        return;
                    }
                    */

                    String text = txtScriptsPEXPath.Text;
                    String srcPath = txtSourcePath.Text;
                    String assmPath = txtAssemblyPath.Text;
                    String defSrcDir = text + @"\source";
                    String defAsmDir = text + @"\assembly";
                    //bool outputSource = chkUseDifferentDirectoryForSource.Checked;
                    bool generateAssembly = chkGenerateAssembly.Checked;
                    //bool outputAssembly = chkOutputAssemblyDiffLocation.Checked;
                    bool generateComments = chkGenerateComments.Checked;

                    String[] pexFiles = Directory.GetFiles(text, "*.pex");

                    pbProgress.Maximum = pexFiles.Length;
                    pbProgress.Value = 0;

                    Action updateProgress = (Action)(() =>
                    {
                        ++pbProgress.Value;
                        pbProgress.Refresh();
                    });
                    bool encounteredError = false;
                    Task task = new Task((Action)(() =>
                    {
                        for (int index1 = 0; index1 < pexFiles.Length; ++index1)
                        {
                            try
                            {
                                List<String> StringList = new List<String>
                                {
                                    String.Format("\"{0}\"", (object)pexFiles[index1])
                                };

                                if (outputSource && !String.IsNullOrWhiteSpace(srcPath))
                                {
                                    StringList.Add(String.Format(" -p \"{0}\"", (object)srcPath));
                                }
                                else
                                {
                                    StringList.Add(String.Format(" -p \"{0}\"", (object)defSrcDir));
                                }

                                if (generateAssembly)
                                {
                                    StringList.Add(" -a");

                                    if (outputAssembly && !String.IsNullOrWhiteSpace(assmPath))
                                    {

                                        StringList.Add(String.Format(" \"{0}\"", (object)assmPath));
                                    }
                                    else
                                    {
                                        StringList.Add(String.Format(" -p \"{0}\"", (object)defAsmDir));
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
                                Process process = new Process();
                                process.StartInfo.UseShellExecute = false;
                                process.StartInfo.RedirectStandardOutput = true;
                                process.StartInfo.WorkingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                                process.StartInfo.FileName = Path.GetFileName("Champollion.exe");
                                process.StartInfo.Arguments = Str;
                                process.Start();
                                String end = process.StandardOutput.ReadToEnd();
                                process.WaitForExit();

                                do
                                {
                                    //wait
                                }
                                while (!process.HasExited);

                                if (!end.Contains("files process"))
                                {
                                    throw new Exception("Champollion encountered an error");
                                }
                                this.Invoke((Delegate)updateProgress);
                            }
                            catch (Exception)
                            {
                                int num = (int)new MessageBox("Champollion Error", String.Format("An error has occurred during execution. \r\n" +
                                                                                                 "Was unable to process {0}. \n Aborting...",
                                                                                                 (object)pexFiles[index1]), false).ShowDialog();
                                encounteredError = true;
                                break;
                            }
                        }
                    }));
                    task.Start();
                    //do
                    //{
                    //    //wait
                    //}
                    //while (task.Status.Equals((object)TaskStatus.Running));

                    if (encounteredError)
                    {
                        return;
                    }

                    task.ContinueWith(task =>
                    {
                        _ = new MessageBox("Champollion Run Complete", "Champollion has successfully processed all files. \r\n" +
                                                                        "Verify your scripts. \n Note: Events will be listed as Functions ", false).ShowDialog();
                    }); 
                }
            //}
        }


        private bool SendWarning(String Type)
        {
            if (new MessageBox("Warning", String.Format(WarningMessage, Type), true).ShowDialog() != DialogResult.OK)
            {
                return true;
            }

            return false;
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            String readme = "readme_instructions.txt";
            String Dir = Directory.GetCurrentDirectory();
            String Wholepath = $"{Dir}\\{readme}";
            Process.Start(new ProcessStartInfo(Wholepath) { UseShellExecute = true });
            //Process.Start(Wholepath);
            //Process.Start(String.Format("{0}\\{1}", (object)Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
            //(object)"readme_instructions.txt"));
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.UnWireEvents();
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnAbout_Click(object sender, EventArgs e)
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

        private void linkLabelAuthorOriginal_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Specify that the link was visited.
            linkLabelAuthorOriginal.LinkVisited = true;

            // Navigate to a URL.
            Process.Start("https://www.nexusmods.com/users/582310");
        }

        private void linkLabelAuthorRevision_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Specify that the link was visited.
            linkLabelAuthorRevision.LinkVisited = true;

            // Navigate to a URL.
            Process.Start("https://www.nexusmods.com/users/39381905");
        }

        private void linkLabelEndorse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Specify that the link was visited.
            linkLabelEndorse.LinkVisited = true;

            // Navigate to a URL.
            Process.Start("https://www.nexusmods.com/skyrimspecialedition/mods/92452");
        }
    }
}