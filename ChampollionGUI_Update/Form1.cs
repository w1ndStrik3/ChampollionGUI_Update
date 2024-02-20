using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using Font = System.Drawing.Font;

#pragma warning disable CS8600
#pragma warning disable CS8622

namespace ChampollionGUI_Update
{
    public class Form1 : Form
    {
        #region declarations

        #region IContainers
        public IContainer Components;
        #endregion

        #region Buttons
        public Button ButtonHelp;
        public Button ButtonAbout;
        public Button ButtonRun;
        public Button ButtonScriptsPathBrowse;
        public Button ButtonSourceDestinationBrowse;
        public Button ButtonAssemblyPathBrowse;
        public Button ButtonExit;
        #endregion

        #region CheckBoxes
        public CheckBox CheckBoxUseDifferentDirectoryForSource;
        public CheckBox CheckBoxGenerateAssembly;
        public CheckBox CheckBoxGenerateComments;
        public CheckBox CheckBoxOutputAssemblyDiffLocation;
        #endregion

        #region FolderBrowserDialogs
        public FolderBrowserDialog FolderDialog;
        #endregion

        #region Groupboxes
        public GroupBox GroupBoxParameters;
        public GroupBox GroupBoxProgress;
        public GroupBox GroupBoxAdditionalParameters;
        #endregion

        #region Labels
        public Label LabelAuthor;
        public Label LabelUpdatedBy;
        public Label LabelScriptsFolder;
        public Label LabelAssemblyDestination;
        public Label LabelSourceDestination;
        public Label LabelVersion;
        #endregion

        #region LinkLabels
        public LinkLabel LinkLabelAuthorOriginal;
        public LinkLabel LinkLabelAuthorRevision;
        public LinkLabel LinkLabelEndorse;
        #endregion

        #region ProgressBars
        public ProgressBar ProgressBarProgress;
        #endregion

        #region TextBoxes
        public TextBox TextBoxScriptsPEXPath;
        public TextBox TextBoxAssemblyPath;
        public TextBox TextBoxSourcePath;
        #endregion

        #region Others
        private Decompilation Decompiler;
        public CheckBox CheckBoxIgnoreCorruptFiles;
        public CheckBox CheckBoxThreaded;
        public GroupBox GroupBoxAdditionalSettings;
        public Button ButtonOpenReadme;
        public Label LabelReadTheReadMe;
        public readonly String WarningMessage;
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
            LinkLabelEndorse = new LinkLabel();
            LabelScriptsFolder = new Label();
            TextBoxScriptsPEXPath = new TextBox();
            CheckBoxOutputAssemblyDiffLocation = new CheckBox();
            ButtonScriptsPathBrowse = new Button();
            CheckBoxGenerateAssembly = new CheckBox();
            LabelAssemblyDestination = new Label();
            LabelSourceDestination = new Label();
            ButtonSourceDestinationBrowse = new Button();
            TextBoxAssemblyPath = new TextBox();
            CheckBoxUseDifferentDirectoryForSource = new CheckBox();
            TextBoxSourcePath = new TextBox();
            ButtonAssemblyPathBrowse = new Button();
            CheckBoxIgnoreCorruptFiles = new CheckBox();
            CheckBoxThreaded = new CheckBox();
            CheckBoxGenerateComments = new CheckBox();
            GroupBoxProgress = new GroupBox();
            ProgressBarProgress = new ProgressBar();
            ButtonRun = new Button();
            ButtonExit = new Button();
            LabelAuthor = new Label();
            LinkLabelAuthorOriginal = new LinkLabel();
            LabelUpdatedBy = new Label();
            LinkLabelAuthorRevision = new LinkLabel();
            FolderDialog = new FolderBrowserDialog();
            LabelVersion = new Label();
            GroupBoxAdditionalSettings = new GroupBox();
            LabelReadTheReadMe = new Label();
            ButtonOpenReadme = new Button();
            GroupBoxParameters.SuspendLayout();
            GroupBoxProgress.SuspendLayout();
            GroupBoxAdditionalSettings.SuspendLayout();
            SuspendLayout();
            // 
            // ButtonHelp
            // 
            ButtonHelp.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ButtonHelp.Location = new Point(762, 16);
            ButtonHelp.Margin = new Padding(5, 4, 5, 4);
            ButtonHelp.Name = "ButtonHelp";
            ButtonHelp.Size = new Size(101, 36);
            ButtonHelp.TabIndex = 2;
            ButtonHelp.Text = "Help...";
            ButtonHelp.UseVisualStyleBackColor = true;
            // 
            // ButtonAbout
            // 
            ButtonAbout.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ButtonAbout.Location = new Point(653, 16);
            ButtonAbout.Margin = new Padding(5, 4, 5, 4);
            ButtonAbout.Name = "ButtonAbout";
            ButtonAbout.Size = new Size(101, 36);
            ButtonAbout.TabIndex = 3;
            ButtonAbout.Text = "About...";
            ButtonAbout.UseVisualStyleBackColor = true;
            // 
            // GroupBoxParameters
            // 
            GroupBoxParameters.Controls.Add(LinkLabelEndorse);
            GroupBoxParameters.Controls.Add(LabelScriptsFolder);
            GroupBoxParameters.Controls.Add(TextBoxScriptsPEXPath);
            GroupBoxParameters.Controls.Add(CheckBoxOutputAssemblyDiffLocation);
            GroupBoxParameters.Controls.Add(ButtonScriptsPathBrowse);
            GroupBoxParameters.Controls.Add(CheckBoxGenerateAssembly);
            GroupBoxParameters.Controls.Add(LabelAssemblyDestination);
            GroupBoxParameters.Controls.Add(LabelSourceDestination);
            GroupBoxParameters.Controls.Add(ButtonSourceDestinationBrowse);
            GroupBoxParameters.Controls.Add(TextBoxAssemblyPath);
            GroupBoxParameters.Controls.Add(CheckBoxUseDifferentDirectoryForSource);
            GroupBoxParameters.Controls.Add(TextBoxSourcePath);
            GroupBoxParameters.Controls.Add(ButtonAssemblyPathBrowse);
            GroupBoxParameters.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            GroupBoxParameters.Location = new Point(15, 68);
            GroupBoxParameters.Margin = new Padding(5, 4, 5, 4);
            GroupBoxParameters.Name = "GroupBoxParameters";
            GroupBoxParameters.Padding = new Padding(5, 4, 5, 4);
            GroupBoxParameters.Size = new Size(958, 301);
            GroupBoxParameters.TabIndex = 4;
            GroupBoxParameters.TabStop = false;
            GroupBoxParameters.Text = "Parameters";
            // 
            // LinkLabelEndorse
            // 
            LinkLabelEndorse.AutoSize = true;
            LinkLabelEndorse.Location = new Point(698, 195);
            LinkLabelEndorse.Name = "LinkLabelEndorse";
            LinkLabelEndorse.Size = new Size(150, 25);
            LinkLabelEndorse.TabIndex = 28;
            LinkLabelEndorse.TabStop = true;
            LinkLabelEndorse.Text = "Please Endorse!";
            LinkLabelEndorse.LinkClicked += LinkLabelEndorse_LinkClicked;
            // 
            // LabelScriptsFolder
            // 
            LabelScriptsFolder.AutoSize = true;
            LabelScriptsFolder.Font = new Font("Segoe UI", 9F);
            LabelScriptsFolder.Location = new Point(15, 39);
            LabelScriptsFolder.Margin = new Padding(5, 0, 5, 0);
            LabelScriptsFolder.Name = "LabelScriptsFolder";
            LabelScriptsFolder.Size = new Size(143, 20);
            LabelScriptsFolder.TabIndex = 14;
            LabelScriptsFolder.Text = "Scripts Folder (.pex):";
            // 
            // TextBoxScriptsPEXPath
            // 
            TextBoxScriptsPEXPath.BackColor = SystemColors.ControlLightLight;
            TextBoxScriptsPEXPath.Location = new Point(255, 31);
            TextBoxScriptsPEXPath.Margin = new Padding(5, 4, 5, 4);
            TextBoxScriptsPEXPath.Name = "TextBoxScriptsPEXPath";
            TextBoxScriptsPEXPath.Size = new Size(578, 32);
            TextBoxScriptsPEXPath.TabIndex = 15;
            // 
            // CheckBoxOutputAssemblyDiffLocation
            // 
            CheckBoxOutputAssemblyDiffLocation.AutoSize = true;
            CheckBoxOutputAssemblyDiffLocation.Enabled = false;
            CheckBoxOutputAssemblyDiffLocation.Font = new Font("Segoe UI", 9F);
            CheckBoxOutputAssemblyDiffLocation.Location = new Point(255, 199);
            CheckBoxOutputAssemblyDiffLocation.Margin = new Padding(5, 4, 5, 4);
            CheckBoxOutputAssemblyDiffLocation.Name = "CheckBoxOutputAssemblyDiffLocation";
            CheckBoxOutputAssemblyDiffLocation.Size = new Size(284, 24);
            CheckBoxOutputAssemblyDiffLocation.TabIndex = 22;
            CheckBoxOutputAssemblyDiffLocation.Text = "Output Assembly in Different Location";
            CheckBoxOutputAssemblyDiffLocation.UseVisualStyleBackColor = true;
            // 
            // ButtonScriptsPathBrowse
            // 
            ButtonScriptsPathBrowse.Font = new Font("Segoe UI", 9F);
            ButtonScriptsPathBrowse.Location = new Point(839, 29);
            ButtonScriptsPathBrowse.Margin = new Padding(5, 4, 5, 4);
            ButtonScriptsPathBrowse.Name = "ButtonScriptsPathBrowse";
            ButtonScriptsPathBrowse.Size = new Size(110, 39);
            ButtonScriptsPathBrowse.TabIndex = 16;
            ButtonScriptsPathBrowse.Text = "Browse";
            ButtonScriptsPathBrowse.UseVisualStyleBackColor = true;
            // 
            // CheckBoxGenerateAssembly
            // 
            CheckBoxGenerateAssembly.AutoSize = true;
            CheckBoxGenerateAssembly.Font = new Font("Segoe UI", 9F);
            CheckBoxGenerateAssembly.Location = new Point(17, 199);
            CheckBoxGenerateAssembly.Margin = new Padding(5, 4, 5, 4);
            CheckBoxGenerateAssembly.Name = "CheckBoxGenerateAssembly";
            CheckBoxGenerateAssembly.Size = new Size(158, 24);
            CheckBoxGenerateAssembly.TabIndex = 21;
            CheckBoxGenerateAssembly.Text = "Generate Assembly";
            CheckBoxGenerateAssembly.UseVisualStyleBackColor = true;
            // 
            // LabelAssemblyDestination
            // 
            LabelAssemblyDestination.AutoSize = true;
            LabelAssemblyDestination.Font = new Font("Segoe UI", 9F);
            LabelAssemblyDestination.Location = new Point(15, 252);
            LabelAssemblyDestination.Margin = new Padding(5, 0, 5, 0);
            LabelAssemblyDestination.Name = "LabelAssemblyDestination";
            LabelAssemblyDestination.Size = new Size(155, 20);
            LabelAssemblyDestination.TabIndex = 23;
            LabelAssemblyDestination.Text = "Assembly Destination:";
            // 
            // LabelSourceDestination
            // 
            LabelSourceDestination.AutoSize = true;
            LabelSourceDestination.Font = new Font("Segoe UI", 9F);
            LabelSourceDestination.Location = new Point(15, 145);
            LabelSourceDestination.Margin = new Padding(5, 0, 5, 0);
            LabelSourceDestination.Name = "LabelSourceDestination";
            LabelSourceDestination.Size = new Size(137, 20);
            LabelSourceDestination.TabIndex = 17;
            LabelSourceDestination.Text = "Source Destination:";
            // 
            // ButtonSourceDestinationBrowse
            // 
            ButtonSourceDestinationBrowse.Enabled = false;
            ButtonSourceDestinationBrowse.Font = new Font("Segoe UI", 9F);
            ButtonSourceDestinationBrowse.Location = new Point(839, 136);
            ButtonSourceDestinationBrowse.Margin = new Padding(5, 4, 5, 4);
            ButtonSourceDestinationBrowse.Name = "ButtonSourceDestinationBrowse";
            ButtonSourceDestinationBrowse.Size = new Size(110, 39);
            ButtonSourceDestinationBrowse.TabIndex = 20;
            ButtonSourceDestinationBrowse.Text = "Browse";
            ButtonSourceDestinationBrowse.UseVisualStyleBackColor = true;
            // 
            // TextBoxAssemblyPath
            // 
            TextBoxAssemblyPath.BackColor = SystemColors.ControlLightLight;
            TextBoxAssemblyPath.Enabled = false;
            TextBoxAssemblyPath.Location = new Point(255, 244);
            TextBoxAssemblyPath.Margin = new Padding(5, 4, 5, 4);
            TextBoxAssemblyPath.Name = "TextBoxAssemblyPath";
            TextBoxAssemblyPath.Size = new Size(578, 32);
            TextBoxAssemblyPath.TabIndex = 24;
            // 
            // CheckBoxUseDifferentDirectoryForSource
            // 
            CheckBoxUseDifferentDirectoryForSource.AutoSize = true;
            CheckBoxUseDifferentDirectoryForSource.Font = new Font("Segoe UI", 9F);
            CheckBoxUseDifferentDirectoryForSource.Location = new Point(17, 92);
            CheckBoxUseDifferentDirectoryForSource.Margin = new Padding(5, 4, 5, 4);
            CheckBoxUseDifferentDirectoryForSource.Name = "CheckBoxUseDifferentDirectoryForSource";
            CheckBoxUseDifferentDirectoryForSource.Size = new Size(304, 24);
            CheckBoxUseDifferentDirectoryForSource.TabIndex = 18;
            CheckBoxUseDifferentDirectoryForSource.Text = "Use custom source (.psc) output directory";
            CheckBoxUseDifferentDirectoryForSource.UseVisualStyleBackColor = true;
            // 
            // TextBoxSourcePath
            // 
            TextBoxSourcePath.BackColor = SystemColors.ControlLightLight;
            TextBoxSourcePath.Enabled = false;
            TextBoxSourcePath.Location = new Point(255, 137);
            TextBoxSourcePath.Margin = new Padding(5, 4, 5, 4);
            TextBoxSourcePath.Name = "TextBoxSourcePath";
            TextBoxSourcePath.Size = new Size(578, 32);
            TextBoxSourcePath.TabIndex = 19;
            // 
            // ButtonAssemblyPathBrowse
            // 
            ButtonAssemblyPathBrowse.Enabled = false;
            ButtonAssemblyPathBrowse.Font = new Font("Segoe UI", 9F);
            ButtonAssemblyPathBrowse.Location = new Point(839, 243);
            ButtonAssemblyPathBrowse.Margin = new Padding(5, 4, 5, 4);
            ButtonAssemblyPathBrowse.Name = "ButtonAssemblyPathBrowse";
            ButtonAssemblyPathBrowse.Size = new Size(110, 39);
            ButtonAssemblyPathBrowse.TabIndex = 25;
            ButtonAssemblyPathBrowse.Text = "Browse";
            ButtonAssemblyPathBrowse.UseVisualStyleBackColor = true;
            // 
            // CheckBoxIgnoreCorruptFiles
            // 
            CheckBoxIgnoreCorruptFiles.AutoSize = true;
            CheckBoxIgnoreCorruptFiles.Font = new Font("Segoe UI", 9F);
            CheckBoxIgnoreCorruptFiles.Location = new Point(314, 35);
            CheckBoxIgnoreCorruptFiles.Margin = new Padding(5, 4, 5, 4);
            CheckBoxIgnoreCorruptFiles.Name = "CheckBoxIgnoreCorruptFiles";
            CheckBoxIgnoreCorruptFiles.Size = new Size(161, 24);
            CheckBoxIgnoreCorruptFiles.TabIndex = 30;
            CheckBoxIgnoreCorruptFiles.Text = "Ignore Corrupt Files";
            CheckBoxIgnoreCorruptFiles.UseVisualStyleBackColor = true;
            CheckBoxIgnoreCorruptFiles.CheckedChanged += CheckBoxIgnoreCorruptFiles_CheckedChanged;
            // 
            // CheckBoxThreaded
            // 
            CheckBoxThreaded.AutoSize = true;
            CheckBoxThreaded.Font = new Font("Segoe UI", 9F);
            CheckBoxThreaded.Location = new Point(181, 35);
            CheckBoxThreaded.Margin = new Padding(5, 4, 5, 4);
            CheckBoxThreaded.Name = "CheckBoxThreaded";
            CheckBoxThreaded.Size = new Size(137, 24);
            CheckBoxThreaded.TabIndex = 29;
            CheckBoxThreaded.Text = "Threaded mode";
            CheckBoxThreaded.UseVisualStyleBackColor = true;
            CheckBoxThreaded.CheckedChanged += CheckBoxThreaded_CheckedChanged;
            // 
            // CheckBoxGenerateComments
            // 
            CheckBoxGenerateComments.AutoSize = true;
            CheckBoxGenerateComments.Font = new Font("Segoe UI", 9F);
            CheckBoxGenerateComments.Location = new Point(17, 35);
            CheckBoxGenerateComments.Margin = new Padding(5, 4, 5, 4);
            CheckBoxGenerateComments.Name = "CheckBoxGenerateComments";
            CheckBoxGenerateComments.Size = new Size(166, 24);
            CheckBoxGenerateComments.TabIndex = 26;
            CheckBoxGenerateComments.Text = "Generate Comments";
            CheckBoxGenerateComments.UseVisualStyleBackColor = true;
            // 
            // GroupBoxProgress
            // 
            GroupBoxProgress.Controls.Add(ProgressBarProgress);
            GroupBoxProgress.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            GroupBoxProgress.Location = new Point(14, 461);
            GroupBoxProgress.Margin = new Padding(5, 4, 5, 4);
            GroupBoxProgress.Name = "GroupBoxProgress";
            GroupBoxProgress.Padding = new Padding(5, 4, 5, 4);
            GroupBoxProgress.Size = new Size(958, 128);
            GroupBoxProgress.TabIndex = 5;
            GroupBoxProgress.TabStop = false;
            GroupBoxProgress.Text = "Progress";
            // 
            // ProgressBarProgress
            // 
            ProgressBarProgress.Location = new Point(8, 51);
            ProgressBarProgress.Margin = new Padding(5, 4, 5, 4);
            ProgressBarProgress.Name = "ProgressBarProgress";
            ProgressBarProgress.Size = new Size(941, 36);
            ProgressBarProgress.TabIndex = 0;
            // 
            // ButtonRun
            // 
            ButtonRun.Location = new Point(497, 601);
            ButtonRun.Margin = new Padding(5, 4, 5, 4);
            ButtonRun.Name = "ButtonRun";
            ButtonRun.Size = new Size(101, 36);
            ButtonRun.TabIndex = 0;
            ButtonRun.Text = "Run...";
            ButtonRun.UseVisualStyleBackColor = true;
            // 
            // ButtonExit
            // 
            ButtonExit.Location = new Point(386, 601);
            ButtonExit.Margin = new Padding(5, 4, 5, 4);
            ButtonExit.Name = "ButtonExit";
            ButtonExit.Size = new Size(101, 36);
            ButtonExit.TabIndex = 1;
            ButtonExit.Text = "Exit";
            ButtonExit.UseVisualStyleBackColor = true;
            // 
            // LabelAuthor
            // 
            LabelAuthor.AutoSize = true;
            LabelAuthor.Location = new Point(14, 12);
            LabelAuthor.Name = "LabelAuthor";
            LabelAuthor.Size = new Size(81, 20);
            LabelAuthor.TabIndex = 7;
            LabelAuthor.Text = "Created by";
            // 
            // LinkLabelAuthorOriginal
            // 
            LinkLabelAuthorOriginal.AutoSize = true;
            LinkLabelAuthorOriginal.Location = new Point(83, 12);
            LinkLabelAuthorOriginal.Name = "LinkLabelAuthorOriginal";
            LinkLabelAuthorOriginal.Size = new Size(116, 20);
            LinkLabelAuthorOriginal.TabIndex = 8;
            LinkLabelAuthorOriginal.TabStop = true;
            LinkLabelAuthorOriginal.Text = "Arron Dominion";
            LinkLabelAuthorOriginal.LinkClicked += LinkLabelAuthorOriginal_LinkClicked;
            // 
            // LabelUpdatedBy
            // 
            LabelUpdatedBy.AutoSize = true;
            LabelUpdatedBy.Location = new Point(14, 39);
            LabelUpdatedBy.Name = "LabelUpdatedBy";
            LabelUpdatedBy.Size = new Size(184, 20);
            LabelUpdatedBy.TabIndex = 9;
            LabelUpdatedBy.Text = "Updated and enhanced by";
            // 
            // LinkLabelAuthorRevision
            // 
            LinkLabelAuthorRevision.AutoSize = true;
            LinkLabelAuthorRevision.Location = new Point(179, 39);
            LinkLabelAuthorRevision.Name = "LinkLabelAuthorRevision";
            LinkLabelAuthorRevision.Size = new Size(82, 20);
            LinkLabelAuthorRevision.TabIndex = 10;
            LinkLabelAuthorRevision.TabStop = true;
            LinkLabelAuthorRevision.Text = "w1ndStrik3";
            LinkLabelAuthorRevision.LinkClicked += LinkLabelAuthorRevision_LinkClicked;
            // 
            // LabelVersion
            // 
            LabelVersion.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            LabelVersion.AutoSize = true;
            LabelVersion.ForeColor = Color.Gray;
            LabelVersion.Location = new Point(718, 609);
            LabelVersion.Name = "LabelVersion";
            LabelVersion.Size = new Size(287, 20);
            LabelVersion.TabIndex = 11;
            LabelVersion.Text = "Version: 2.1.0.1 (Stable release, 29/1/2024)";
            // 
            // GroupBoxAdditionalSettings
            // 
            GroupBoxAdditionalSettings.Controls.Add(LabelReadTheReadMe);
            GroupBoxAdditionalSettings.Controls.Add(CheckBoxIgnoreCorruptFiles);
            GroupBoxAdditionalSettings.Controls.Add(CheckBoxThreaded);
            GroupBoxAdditionalSettings.Controls.Add(CheckBoxGenerateComments);
            GroupBoxAdditionalSettings.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            GroupBoxAdditionalSettings.Location = new Point(15, 377);
            GroupBoxAdditionalSettings.Margin = new Padding(5, 4, 5, 4);
            GroupBoxAdditionalSettings.Name = "GroupBoxAdditionalSettings";
            GroupBoxAdditionalSettings.Padding = new Padding(5, 4, 5, 4);
            GroupBoxAdditionalSettings.Size = new Size(958, 76);
            GroupBoxAdditionalSettings.TabIndex = 12;
            GroupBoxAdditionalSettings.TabStop = false;
            GroupBoxAdditionalSettings.Text = "Additional Settings";
            // 
            // LabelReadTheReadMe
            // 
            LabelReadTheReadMe.AutoSize = true;
            LabelReadTheReadMe.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            LabelReadTheReadMe.Location = new Point(501, 24);
            LabelReadTheReadMe.Margin = new Padding(5, 0, 5, 0);
            LabelReadTheReadMe.MaximumSize = new Size(343, 0);
            LabelReadTheReadMe.Name = "LabelReadTheReadMe";
            LabelReadTheReadMe.Size = new Size(304, 40);
            LabelReadTheReadMe.TabIndex = 31;
            LabelReadTheReadMe.Text = "Please read the README before using the \"Threaded mode\" option";
            // 
            // ButtonOpenReadme
            // 
            ButtonOpenReadme.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ButtonOpenReadme.Location = new Point(872, 16);
            ButtonOpenReadme.Margin = new Padding(5, 4, 5, 4);
            ButtonOpenReadme.Name = "ButtonOpenReadme";
            ButtonOpenReadme.Size = new Size(101, 36);
            ButtonOpenReadme.TabIndex = 13;
            ButtonOpenReadme.Text = "README";
            ButtonOpenReadme.UseVisualStyleBackColor = true;
            ButtonOpenReadme.Click += ButtonOpenReadme_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(987, 647);
            Controls.Add(ButtonOpenReadme);
            Controls.Add(GroupBoxAdditionalSettings);
            Controls.Add(LabelVersion);
            Controls.Add(ButtonRun);
            Controls.Add(LinkLabelAuthorRevision);
            Controls.Add(LabelUpdatedBy);
            Controls.Add(ButtonExit);
            Controls.Add(LinkLabelAuthorOriginal);
            Controls.Add(LabelAuthor);
            Controls.Add(GroupBoxParameters);
            Controls.Add(ButtonAbout);
            Controls.Add(ButtonHelp);
            Controls.Add(GroupBoxProgress);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5, 4, 5, 4);
            Name = "Form1";
            Text = "Champollion Interface";
            GroupBoxParameters.ResumeLayout(false);
            GroupBoxParameters.PerformLayout();
            GroupBoxProgress.ResumeLayout(false);
            GroupBoxAdditionalSettings.ResumeLayout(false);
            GroupBoxAdditionalSettings.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private void WireEvents()
        {
            ButtonAbout.Click += new EventHandler(this.ButtonAbout_Click);
            ButtonAssemblyPathBrowse.Click += new EventHandler(this.ButtonAssemblyPathBrowse_Click);
            ButtonExit.Click += new EventHandler(this.ButtonExit_Click);
            ButtonHelp.Click += new EventHandler(this.ButtonHelp_Click);
            ButtonRun.Click += new EventHandler(this.ButtonRun_Click);
            ButtonScriptsPathBrowse.Click += new EventHandler(this.ButtonScriptsPathBrowse_Click);
            ButtonSourceDestinationBrowse.Click += new EventHandler(this.ButtonSourceDestinationBrowse_Click);
            CheckBoxGenerateAssembly.CheckedChanged += new EventHandler(this.CheckBoxGenerateAssembly_CheckedChanged);
            CheckBoxOutputAssemblyDiffLocation.CheckedChanged += new EventHandler(this.CheckBoxOutputAssemblyDiffLocation_CheckedChanged);
            CheckBoxUseDifferentDirectoryForSource.CheckedChanged += new EventHandler(this.CheckBoxUseDifferentDirectoryForSource_CheckedChanged);
        }

        private void UnWireEvents()
        {
            ButtonAbout.Click -= new EventHandler(this.ButtonAbout_Click);
            ButtonAssemblyPathBrowse.Click -= new EventHandler(this.ButtonAssemblyPathBrowse_Click);
            ButtonExit.Click -= new EventHandler(this.ButtonExit_Click);
            ButtonHelp.Click -= new EventHandler(this.ButtonHelp_Click);
            ButtonRun.Click -= new EventHandler(this.ButtonRun_Click);
            ButtonScriptsPathBrowse.Click -= new EventHandler(this.ButtonScriptsPathBrowse_Click);
            ButtonSourceDestinationBrowse.Click -= new EventHandler(this.ButtonSourceDestinationBrowse_Click);
            CheckBoxGenerateAssembly.CheckedChanged -= new EventHandler(this.CheckBoxGenerateAssembly_CheckedChanged);
            CheckBoxOutputAssemblyDiffLocation.CheckedChanged -= new EventHandler(this.CheckBoxOutputAssemblyDiffLocation_CheckedChanged);
            CheckBoxUseDifferentDirectoryForSource.CheckedChanged -= new EventHandler(this.CheckBoxUseDifferentDirectoryForSource_CheckedChanged);
        }

        #region Form methods
        private void CheckBoxUseDifferentDirectoryForSource_CheckedChanged(Object? Sender, EventArgs EA)
        {
            ButtonSourceDestinationBrowse.Enabled = CheckBoxUseDifferentDirectoryForSource.Checked;
            TextBoxSourcePath.Enabled = CheckBoxUseDifferentDirectoryForSource.Checked;

            //Clears the source PexFileDirectory box if the checkbox is "unticked"
            if (!CheckBoxUseDifferentDirectoryForSource.Checked)
            {
                TextBoxSourcePath.Text = String.Empty;
            }
        }

        private void CheckBoxOutputAssemblyDiffLocation_CheckedChanged(Object? Sender, EventArgs EA)
        {
            ButtonAssemblyPathBrowse.Enabled = CheckBoxOutputAssemblyDiffLocation.Checked;
            TextBoxAssemblyPath.Enabled = CheckBoxOutputAssemblyDiffLocation.Checked;

            //Clears the assembly PexFileDirectory box if the checkbox is "unticked"
            if (!CheckBoxOutputAssemblyDiffLocation.Checked)
            {
                TextBoxAssemblyPath.Text = String.Empty;
            }
        }

        private void CheckBoxGenerateAssembly_CheckedChanged(Object? Sender, EventArgs EA)
        {
            CheckBoxOutputAssemblyDiffLocation.Enabled = CheckBoxGenerateAssembly.Checked;
            if (!CheckBoxGenerateAssembly.Checked)
            {
                CheckBoxOutputAssemblyDiffLocation.Checked = false;
                if (!CheckBoxOutputAssemblyDiffLocation.Checked)
                {
                    TextBoxAssemblyPath.Enabled = false;
                    TextBoxAssemblyPath.Text = String.Empty;
                }

            }
        }

        private void CheckBoxIgnoreCorruptFiles_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxThreaded.Enabled = !CheckBoxIgnoreCorruptFiles.Checked;
            CheckBoxThreaded.Checked = false;
        }

        private void CheckBoxThreaded_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxIgnoreCorruptFiles.Enabled = !CheckBoxThreaded.Checked;
            CheckBoxIgnoreCorruptFiles.Checked = false;
        }

        private void ButtonSourceDestinationBrowse_Click(Object? Sender, EventArgs EA)
        {
            String Path = SelectFolder();
            if (Path != "")
            {
                TextBoxSourcePath.Text = Path;
            }
            else
            {
                return;
            }
        }

        private void ButtonScriptsPathBrowse_Click(Object? Sender, EventArgs EA)
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

        private void ButtonAssemblyPathBrowse_Click(Object? Sender, EventArgs EA)
        {
            String Path = SelectFolder();
            if (Path != "")
            {
                TextBoxAssemblyPath.Text = Path;
            }
            else
            {
                return;
            }
        }

        private void ButtonRun_Click(Object? Sender, EventArgs EA)
        {
            Decompiler = new Decompilation(this);
            char option;
            try
            {
                option = Decompiler.PreDecompilationChecks();
            }
            catch (PreDecompilationException PDE)
            {
                return;
            }

            try
            {
                if (new MessageBox("Confirm Run", "Are you sure you want to run Champollion?", true).ShowDialog() == DialogResult.OK)
                {
                    if (option == 'E')
                    {
                        Fishy("option is 'E'");
                        throw new PreDecompilationException("");
                    }
                    else
                    {
                        Decompiler.Decompile(option);
                    }
                }
                return;
            }
            catch (PreDecompilationException PDE)
            {

            }
            catch (IntraDecompilationException IDE)
            {

            }
        }

        private void ButtonHelp_Click(Object? Sender, EventArgs EA)
        {
            StringBuilder StringBuilder = new StringBuilder();
            StringBuilder.AppendLine("READ THE README BEFORE YOU POST ABOUT AN ISSUE! YOUR QUESTION IS");
            StringBuilder.AppendLine("LIKELY ANSWERED THERE ALREADY!");
            StringBuilder.AppendLine("The readme can be found at:");
            StringBuilder.AppendLine("https://github.com/w1ndStrik3/ChampollionGUI_Update/ and also");
            StringBuilder.AppendLine("and also inside the doc folder (Champollion_directory/doc/readme.txt");
            StringBuilder.AppendLine("");
            StringBuilder.AppendLine("If you have trouble and need assistance, please comments on the mod");
            StringBuilder.AppendLine("page on Nexus or post a new issue on the GitHub page. You are welcome");
            StringBuilder.AppendLine("to contact me directly on Steam");
            StringBuilder.AppendLine("https://steamcommunity.com/id/w1ndStrik3_official/, but I would highly");
            StringBuilder.AppendLine("prefer if you would post your issue on Nexus or GitHub, because other");
            StringBuilder.AppendLine("people might have the same issue as you, and find the solution on Nexus");
            StringBuilder.AppendLine("or GitHub. That way I will not 117 people message me about the same");
            StringBuilder.AppendLine("thing. If it so happens that I do not respond within 72 hours of you");
            StringBuilder.AppendLine("writing your post, please contact me on Steam and let me know about");
            StringBuilder.AppendLine("your post. I might not have gotten a notification about your post if I");
            StringBuilder.AppendLine("do not respond within 72 hours. Thank you very much.");
            StringBuilder.AppendLine("-w1ndStrik3");

            _ = new MessageBox("About", StringBuilder.ToString(), false).ShowDialog();
        }

        private void ButtonExit_Click(Object? Sender, EventArgs EA)
        {
            this.UnWireEvents();
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ButtonAbout_Click(Object? Sender, EventArgs EA)
        {
            StringBuilder StringBuilder = new StringBuilder();
            StringBuilder.AppendLine("Summary of the program:");
            StringBuilder.AppendLine("This program provides a Graphical User Interface (GUI) to li1nx's ");
            StringBuilder.AppendLine("\"Champollion a PEX to Papyrus decompiler\"");
            StringBuilder.AppendLine("Link to Original Tool: http://www.nexusmods.com/skyrim/mods/35307/");
            StringBuilder.AppendLine("");
            StringBuilder.AppendLine("This program is a significant upgrade and modernizations of the");
            StringBuilder.AppendLine("original \"Champollion Graphical User Interface\" which was originally");
            StringBuilder.AppendLine("made by Arron Dominion. https://www.nexusmods.com/skyrim/mods/82367");
            StringBuilder.AppendLine("");
            StringBuilder.AppendLine("Compared to the old Champollion GUI, this version improves the");
            StringBuilder.AppendLine("performance of the program (this version runs on the newest .NET,");
            StringBuilder.AppendLine("which is .NET version 8 currently). Additionaly, this updated");
            StringBuilder.AppendLine("version of the Champollion Graphical User Interface severely improves");
            StringBuilder.AppendLine("the user experience and the ease of use, along with a few added");
            StringBuilder.AppendLine("features compared to the original version by Arron Dominion.");
            StringBuilder.AppendLine("");
            StringBuilder.AppendLine("The README can be found at:");
            StringBuilder.AppendLine("https://github.com/w1ndStrik3/ChampollionGUI_Update/");

            _ = new MessageBox("About", StringBuilder.ToString(), false).ShowDialog();

        }

        private void ButtonOpenReadme_Click(object sender, EventArgs e)
        {
            String Readme = "readme_instructions.txt";
            String Dir = Directory.GetCurrentDirectory();
            String Wholepath = $"{Dir}\\doc\\{Readme}";
            Process.Start(new ProcessStartInfo(Wholepath) { UseShellExecute = true });
        }

        private void LinkLabelAuthorOriginal_LinkClicked(Object? Sender, LinkLabelLinkClickedEventArgs LLLCEA)
        {
            // Specify that the link was visited.
            LinkLabelAuthorOriginal.LinkVisited = true;

            // Navigate to a URL.
            Process.Start("https://www.nexusmods.com/users/582310");
        }

        private void LinkLabelAuthorRevision_LinkClicked(Object? Sender, LinkLabelLinkClickedEventArgs LLLCEA)
        {
            // Specify that the link was visited.
            LinkLabelAuthorRevision.LinkVisited = true;

            // Navigate to a URL.
            Process.Start("https://www.nexusmods.com/users/39381905");
        }

        private void LinkLabelEndorse_LinkClicked(Object? Sender, LinkLabelLinkClickedEventArgs LLLCEA)
        {
            // Specify that the link was visited.
            LinkLabelEndorse.LinkVisited = true;

            // Navigate to a URL.
            Process.Start("https://www.nexusmods.com/skyrimspecialedition/mods/92452");
        }
        #endregion

        #region Custom methods
        private String SelectFolder()
        {
            String Path = Directory.GetCurrentDirectory();
            FolderDialog.InitialDirectory = Path;
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

        public void Fishy(String Error)
        {
            String Fishy = "Unknown Error. Please report the following error message\r\n" +
                                   "on the mod page on nexus mods along with a screenshot:" +
                                   $"\r\nError message: {Error}";

            _ = new MessageBox("Run Error", Fishy, false).ShowDialog();
        }
        #endregion
    }
}