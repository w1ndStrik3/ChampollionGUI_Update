using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using Font = System.Drawing.Font;

#pragma warning disable CS8600
#pragma warning disable CS8622

namespace ChampollionGUI_Update
{
    public class Form1 : Form
    {
        #region declarations
        #region Form elements
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
        public Button ButtonOpenReadme;
        #endregion

        #region CheckBoxes
        public CheckBox CheckBoxUseDifferentDirectoryForSource;
        public CheckBox CheckBoxGenerateAssembly;
        public CheckBox CheckBoxGenerateComments;
        public CheckBox CheckBoxOutputAssemblyDiffLocation;
        public CheckBox CheckBoxIgnoreCorruptFiles;
        public CheckBox CheckBoxThreaded;
        public GroupBox GroupBoxAdditionalSettings;
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
        public Label LabelReadTheReadMe;
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

        #region ToolStripMenuItems & MenuStrip
        public MenuStrip MenuStrip;
        public ToolStripMenuItem ToolStripMenuItemSettings;
        public ToolStripMenuItem ToolStripMenuItemAbout;
        public ToolStripMenuItem ToolStripMenuItemHelp;
        public ToolStripMenuItem ToolStripMenuItemReadme;
        #endregion
        #endregion //Form elements

        #region Directories

        ///***********************************************************************
        /// <summary>
        /// 
        /// The root directory of the Champollion GUI installation. The name of
        /// the root folder is <c>"\ChampollionGUI_Update"</c>. The exact path is
        /// determined by the <see cref="StartupProcedures"/>.
        /// 
        /// <example>
        /// For example:
        /// <para>
        /// <c>X:\ExampleDir\ChampollionGUI_Update</c>
        /// </para>
        /// </example>
        /// 
        /// </summary>
        ///***********************************************************************
        public readonly String RootDirectory;

        ///***********************************************************************
        /// <summary>
        /// 
        /// The Champollion folder. It is located inside the ChampollionGUI_Update
        /// folder (the root folder). The exact path is determined by the 
        /// <see cref="StartupProcedures"/> class.
        /// 
        /// <example>
        /// For example:
        /// <para>
        /// <c>X:\ExampleDir\ChampollionGUI_Update\Champollion</c>
        /// </para>
        /// </example>
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// <para><b>Additional remarks:</b></para>
        /// Root folder: <see cref="RootDirectory"/>
        /// <para>
        /// The specific contents of this folder are as follows:
        /// </para>
        /// <list type="bullet">
        /// 
        /// <item><c>Champollion.exe</c></item>
        /// <item><c>Decompiler.dll</c></item>
        /// <item><c>Pex.dll</c></item>
        /// 
        /// </list>
        /// </remarks>
        ///***********************************************************************
        public readonly String ChampollionDirectory;

        ///***********************************************************************
        /// <summary>
        /// 
        /// The full path to the Champollion.exe executable file itself. Located
        /// inside the "Champollion" folder. The exact path is determined by the 
        /// <see cref="StartupProcedures"/> class.
        /// 
        /// <example>
        /// For example:
        /// <para>
        /// <c>X:\ExampleDir\ChampollionGUI_Update\Champollion\Champollion.exe</c>
        /// </para>
        /// </example>
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// <para><b>Additional remarks:</b></para>
        /// Champollion folder: <see cref="ChampollionDirectory"/>
        /// 
        /// </remarks>
        ///***********************************************************************
        public readonly String ChampollionFullPath;

        ///***********************************************************************
        /// <summary>
        /// 
        /// The logs folder. This is where all generated log files will go.
        /// Located inside the ChampollionGUI_Update (i.e. the root) folder. The
        /// exact path is determined by the <see cref="StartupProcedures"/> class.
        /// 
        /// <example>
        /// For example:
        /// <para>
        /// <c>X:\ExampleDir\ChampollionGUI_Update\Logs</c>
        /// </para>
        /// </example>
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// <para><b>Additional remarks:</b></para>
        /// Root folder: <see cref="RootDirectory"/>
        /// 
        /// </remarks>
        ///***********************************************************************
        public readonly String LogsDirectory;
        #endregion

        #region Others
        public FolderBrowserDialog FolderDialog;
        private StartupProcedures StartupProceduresInstance;
        private Decompilation Decompiler;

        ///***********************************************************************
        /// <summary>
        /// A template for a warning message that can be thrown in the case of the
        /// user having selected to use a custom output directory, for either the
        /// scripts or the assembly files, but the folder path given by the user
        /// is invalid, i.e. either the textbox is empty, the path has a typo or
        /// if the directory does not exist.
        /// </summary>
        ///***********************************************************************
        public readonly String WarningMessage;
        #endregion //Others

        #endregion

#pragma warning disable CS8618
        public Form1()
        {
            this.InitializeComponent();
            this.WireEvents();

            this.StartupProceduresInstance = new StartupProcedures(this);

            //Sets the paths of the directories to the proper values.
            this.RootDirectory = StartupProceduresInstance.RootDirectory;
            this.ChampollionDirectory = StartupProceduresInstance.ChampollionDirectory;
            this.ChampollionFullPath = StartupProceduresInstance.ChampollionFullPath;
            this.LogsDirectory = StartupProceduresInstance.LogsDirectory;
            this.WarningMessage = StartupProceduresInstance.WarningMessage;
        }

#pragma warning restore CS8618

        ///***********************************************************************
        /// <summary>
        ///	The Dispose method ensures that when a form or control is disposed of,
        ///	any components it contains are also disposed of, provided that the 
        ///	Dispose method is called with disposing set to true. This helps to
        ///	free up resources and prevent memory leaks by properly cleaning up 
        ///	both managed and unmanaged resources used by the form or control and 
        ///	its components. 
        /// </summary>
        /// <param name="disposing">
        /// Indicates where the method was called from.
        /// <para>Called by the program code if <c>true</c></para>
        /// <para>Called by the runtime if <c>false</c> </para>
        /// 
        /// </param>
        ///***********************************************************************
        protected override void Dispose(bool disposing)
        {
            //Firsts disposes the Components if any
            if(disposing && Components != null)
            {
                Components.Dispose();
            }

            //Calls the base Dispose to clean everything
            base.Dispose(disposing);
        }

        ///***********************************************************************
        /// <summary>
        /// Instantiates and i nitializes all the UI elements in thw form window,
        /// and applies all the default values to those elements.
        /// </summary>
        ///***********************************************************************
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
            ToolStripMenuItemSettings = new ToolStripMenuItem();
            ToolStripMenuItemAbout = new ToolStripMenuItem();
            ToolStripMenuItemHelp = new ToolStripMenuItem();
            MenuStrip = new MenuStrip();
            ToolStripMenuItemReadme = new ToolStripMenuItem();
            GroupBoxParameters.SuspendLayout();
            GroupBoxProgress.SuspendLayout();
            GroupBoxAdditionalSettings.SuspendLayout();
            MenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // ButtonHelp
            // 
            ButtonHelp.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ButtonHelp.Location = new Point(667, 36);
            ButtonHelp.Margin = new Padding(4, 3, 4, 3);
            ButtonHelp.Name = "ButtonHelp";
            ButtonHelp.Size = new Size(88, 27);
            ButtonHelp.TabIndex = 2;
            ButtonHelp.Text = "Help...";
            ButtonHelp.UseVisualStyleBackColor = true;
            // 
            // ButtonAbout
            // 
            ButtonAbout.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ButtonAbout.Location = new Point(571, 36);
            ButtonAbout.Margin = new Padding(4, 3, 4, 3);
            ButtonAbout.Name = "ButtonAbout";
            ButtonAbout.Size = new Size(88, 27);
            ButtonAbout.TabIndex = 3;
            ButtonAbout.Text = "About...";
            ButtonAbout.UseVisualStyleBackColor = true;
            // 
            // GroupBoxParameters
            // 
            GroupBoxParameters.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
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
            GroupBoxParameters.Location = new Point(13, 75);
            GroupBoxParameters.Margin = new Padding(4, 3, 4, 3);
            GroupBoxParameters.Name = "GroupBoxParameters";
            GroupBoxParameters.Padding = new Padding(4, 3, 4, 3);
            GroupBoxParameters.Size = new Size(838, 226);
            GroupBoxParameters.TabIndex = 4;
            GroupBoxParameters.TabStop = false;
            GroupBoxParameters.Text = "Parameters";
            // 
            // LinkLabelEndorse
            // 
            LinkLabelEndorse.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            LinkLabelEndorse.AutoSize = true;
            LinkLabelEndorse.Location = new Point(611, 146);
            LinkLabelEndorse.Name = "LinkLabelEndorse";
            LinkLabelEndorse.Size = new Size(118, 20);
            LinkLabelEndorse.TabIndex = 28;
            LinkLabelEndorse.TabStop = true;
            LinkLabelEndorse.Text = "Please Endorse!";
            LinkLabelEndorse.LinkClicked += LinkLabelEndorse_LinkClicked;
            // 
            // LabelScriptsFolder
            // 
            LabelScriptsFolder.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
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
            TextBoxScriptsPEXPath.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            TextBoxScriptsPEXPath.BackColor = SystemColors.ControlLightLight;
            TextBoxScriptsPEXPath.Location = new Point(223, 23);
            TextBoxScriptsPEXPath.Margin = new Padding(4, 3, 4, 3);
            TextBoxScriptsPEXPath.Name = "TextBoxScriptsPEXPath";
            TextBoxScriptsPEXPath.Size = new Size(506, 27);
            TextBoxScriptsPEXPath.TabIndex = 15;
            // 
            // CheckBoxOutputAssemblyDiffLocation
            // 
            CheckBoxOutputAssemblyDiffLocation.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
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
            ButtonScriptsPathBrowse.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
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
            CheckBoxGenerateAssembly.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
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
            LabelAssemblyDestination.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
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
            LabelSourceDestination.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            LabelSourceDestination.AutoSize = true;
            LabelSourceDestination.Font = new Font("Segoe UI", 9F);
            LabelSourceDestination.Location = new Point(13, 109);
            LabelSourceDestination.Margin = new Padding(4, 0, 4, 0);
            LabelSourceDestination.Name = "LabelSourceDestination";
            LabelSourceDestination.Size = new Size(109, 15);
            LabelSourceDestination.TabIndex = 17;
            LabelSourceDestination.Text = "Source Destination:";
            // 
            // ButtonSourceDestinationBrowse
            // 
            ButtonSourceDestinationBrowse.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ButtonSourceDestinationBrowse.Enabled = false;
            ButtonSourceDestinationBrowse.Font = new Font("Segoe UI", 9F);
            ButtonSourceDestinationBrowse.Location = new Point(734, 102);
            ButtonSourceDestinationBrowse.Margin = new Padding(4, 3, 4, 3);
            ButtonSourceDestinationBrowse.Name = "ButtonSourceDestinationBrowse";
            ButtonSourceDestinationBrowse.Size = new Size(96, 29);
            ButtonSourceDestinationBrowse.TabIndex = 20;
            ButtonSourceDestinationBrowse.Text = "Browse";
            ButtonSourceDestinationBrowse.UseVisualStyleBackColor = true;
            // 
            // TextBoxAssemblyPath
            // 
            TextBoxAssemblyPath.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            TextBoxAssemblyPath.BackColor = SystemColors.ControlLightLight;
            TextBoxAssemblyPath.Enabled = false;
            TextBoxAssemblyPath.Location = new Point(223, 183);
            TextBoxAssemblyPath.Margin = new Padding(4, 3, 4, 3);
            TextBoxAssemblyPath.Name = "TextBoxAssemblyPath";
            TextBoxAssemblyPath.Size = new Size(506, 27);
            TextBoxAssemblyPath.TabIndex = 24;
            // 
            // CheckBoxUseDifferentDirectoryForSource
            // 
            CheckBoxUseDifferentDirectoryForSource.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            CheckBoxUseDifferentDirectoryForSource.AutoSize = true;
            CheckBoxUseDifferentDirectoryForSource.Font = new Font("Segoe UI", 9F);
            CheckBoxUseDifferentDirectoryForSource.Location = new Point(15, 69);
            CheckBoxUseDifferentDirectoryForSource.Margin = new Padding(4, 3, 4, 3);
            CheckBoxUseDifferentDirectoryForSource.Name = "CheckBoxUseDifferentDirectoryForSource";
            CheckBoxUseDifferentDirectoryForSource.Size = new Size(247, 19);
            CheckBoxUseDifferentDirectoryForSource.TabIndex = 18;
            CheckBoxUseDifferentDirectoryForSource.Text = "Use custom source (.psc) output directory";
            CheckBoxUseDifferentDirectoryForSource.UseVisualStyleBackColor = true;
            // 
            // TextBoxSourcePath
            // 
            TextBoxSourcePath.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            TextBoxSourcePath.BackColor = SystemColors.ControlLightLight;
            TextBoxSourcePath.Enabled = false;
            TextBoxSourcePath.Location = new Point(223, 103);
            TextBoxSourcePath.Margin = new Padding(4, 3, 4, 3);
            TextBoxSourcePath.Name = "TextBoxSourcePath";
            TextBoxSourcePath.Size = new Size(506, 27);
            TextBoxSourcePath.TabIndex = 19;
            // 
            // ButtonAssemblyPathBrowse
            // 
            ButtonAssemblyPathBrowse.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ButtonAssemblyPathBrowse.Enabled = false;
            ButtonAssemblyPathBrowse.Font = new Font("Segoe UI", 9F);
            ButtonAssemblyPathBrowse.Location = new Point(734, 182);
            ButtonAssemblyPathBrowse.Margin = new Padding(4, 3, 4, 3);
            ButtonAssemblyPathBrowse.Name = "ButtonAssemblyPathBrowse";
            ButtonAssemblyPathBrowse.Size = new Size(96, 29);
            ButtonAssemblyPathBrowse.TabIndex = 25;
            ButtonAssemblyPathBrowse.Text = "Browse";
            ButtonAssemblyPathBrowse.UseVisualStyleBackColor = true;
            // 
            // CheckBoxIgnoreCorruptFiles
            // 
            CheckBoxIgnoreCorruptFiles.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            CheckBoxIgnoreCorruptFiles.AutoSize = true;
            CheckBoxIgnoreCorruptFiles.Font = new Font("Segoe UI", 9F);
            CheckBoxIgnoreCorruptFiles.Location = new Point(275, 26);
            CheckBoxIgnoreCorruptFiles.Margin = new Padding(4, 3, 4, 3);
            CheckBoxIgnoreCorruptFiles.Name = "CheckBoxIgnoreCorruptFiles";
            CheckBoxIgnoreCorruptFiles.Size = new Size(130, 19);
            CheckBoxIgnoreCorruptFiles.TabIndex = 30;
            CheckBoxIgnoreCorruptFiles.Text = "Ignore Corrupt Files";
            CheckBoxIgnoreCorruptFiles.UseVisualStyleBackColor = true;
            CheckBoxIgnoreCorruptFiles.CheckedChanged += CheckBoxIgnoreCorruptFiles_CheckedChanged;
            // 
            // CheckBoxThreaded
            // 
            CheckBoxThreaded.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            CheckBoxThreaded.AutoSize = true;
            CheckBoxThreaded.Font = new Font("Segoe UI", 9F);
            CheckBoxThreaded.Location = new Point(158, 26);
            CheckBoxThreaded.Margin = new Padding(4, 3, 4, 3);
            CheckBoxThreaded.Name = "CheckBoxThreaded";
            CheckBoxThreaded.Size = new Size(109, 19);
            CheckBoxThreaded.TabIndex = 29;
            CheckBoxThreaded.Text = "Threaded mode";
            CheckBoxThreaded.UseVisualStyleBackColor = true;
            CheckBoxThreaded.CheckedChanged += CheckBoxThreaded_CheckedChanged;
            // 
            // CheckBoxGenerateComments
            // 
            CheckBoxGenerateComments.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            CheckBoxGenerateComments.AutoSize = true;
            CheckBoxGenerateComments.Font = new Font("Segoe UI", 9F);
            CheckBoxGenerateComments.Location = new Point(15, 26);
            CheckBoxGenerateComments.Margin = new Padding(4, 3, 4, 3);
            CheckBoxGenerateComments.Name = "CheckBoxGenerateComments";
            CheckBoxGenerateComments.Size = new Size(135, 19);
            CheckBoxGenerateComments.TabIndex = 26;
            CheckBoxGenerateComments.Text = "Generate Comments";
            CheckBoxGenerateComments.UseVisualStyleBackColor = true;
            // 
            // GroupBoxProgress
            // 
            GroupBoxProgress.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            GroupBoxProgress.Controls.Add(ProgressBarProgress);
            GroupBoxProgress.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            GroupBoxProgress.Location = new Point(12, 370);
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
            ProgressBarProgress.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ProgressBarProgress.Location = new Point(7, 38);
            ProgressBarProgress.Margin = new Padding(4, 3, 4, 3);
            ProgressBarProgress.Name = "ProgressBarProgress";
            ProgressBarProgress.Size = new Size(823, 27);
            ProgressBarProgress.TabIndex = 0;
            // 
            // ButtonRun
            // 
            ButtonRun.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ButtonRun.Location = new Point(435, 475);
            ButtonRun.Margin = new Padding(4, 3, 4, 3);
            ButtonRun.Name = "ButtonRun";
            ButtonRun.Size = new Size(88, 27);
            ButtonRun.TabIndex = 0;
            ButtonRun.Text = "Run...";
            ButtonRun.UseVisualStyleBackColor = true;
            // 
            // ButtonExit
            // 
            ButtonExit.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ButtonExit.Location = new Point(338, 475);
            ButtonExit.Margin = new Padding(4, 3, 4, 3);
            ButtonExit.Name = "ButtonExit";
            ButtonExit.Size = new Size(88, 27);
            ButtonExit.TabIndex = 1;
            ButtonExit.Text = "Exit";
            ButtonExit.UseVisualStyleBackColor = true;
            // 
            // LabelAuthor
            // 
            LabelAuthor.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            LabelAuthor.AutoSize = true;
            LabelAuthor.Location = new Point(12, 33);
            LabelAuthor.Name = "LabelAuthor";
            LabelAuthor.Size = new Size(64, 15);
            LabelAuthor.TabIndex = 7;
            LabelAuthor.Text = "Created by";
            // 
            // LinkLabelAuthorOriginal
            // 
            LinkLabelAuthorOriginal.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            LinkLabelAuthorOriginal.AutoSize = true;
            LinkLabelAuthorOriginal.Location = new Point(73, 33);
            LinkLabelAuthorOriginal.Name = "LinkLabelAuthorOriginal";
            LinkLabelAuthorOriginal.Size = new Size(93, 15);
            LinkLabelAuthorOriginal.TabIndex = 8;
            LinkLabelAuthorOriginal.TabStop = true;
            LinkLabelAuthorOriginal.Text = "Arron Dominion";
            LinkLabelAuthorOriginal.LinkClicked += LinkLabelAuthorOriginal_LinkClicked;
            // 
            // LabelUpdatedBy
            // 
            LabelUpdatedBy.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            LabelUpdatedBy.AutoSize = true;
            LabelUpdatedBy.Location = new Point(12, 53);
            LabelUpdatedBy.Name = "LabelUpdatedBy";
            LabelUpdatedBy.Size = new Size(146, 15);
            LabelUpdatedBy.TabIndex = 9;
            LabelUpdatedBy.Text = "Updated and enhanced by";
            // 
            // LinkLabelAuthorRevision
            // 
            LinkLabelAuthorRevision.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            LinkLabelAuthorRevision.AutoSize = true;
            LinkLabelAuthorRevision.Location = new Point(157, 53);
            LinkLabelAuthorRevision.Name = "LinkLabelAuthorRevision";
            LinkLabelAuthorRevision.Size = new Size(65, 15);
            LinkLabelAuthorRevision.TabIndex = 10;
            LinkLabelAuthorRevision.TabStop = true;
            LinkLabelAuthorRevision.Text = "w1ndStrik3";
            LinkLabelAuthorRevision.LinkClicked += LinkLabelAuthorRevision_LinkClicked;
            // 
            // LabelVersion
            // 
            LabelVersion.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            LabelVersion.AutoSize = true;
            LabelVersion.ForeColor = Color.Gray;
            LabelVersion.Location = new Point(778, 481);
            LabelVersion.Name = "LabelVersion";
            LabelVersion.Size = new Size(74, 15);
            LabelVersion.TabIndex = 11;
            LabelVersion.Text = "2.2.0.0-alpha";
            // 
            // GroupBoxAdditionalSettings
            // 
            GroupBoxAdditionalSettings.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            GroupBoxAdditionalSettings.Controls.Add(LabelReadTheReadMe);
            GroupBoxAdditionalSettings.Controls.Add(CheckBoxIgnoreCorruptFiles);
            GroupBoxAdditionalSettings.Controls.Add(CheckBoxThreaded);
            GroupBoxAdditionalSettings.Controls.Add(CheckBoxGenerateComments);
            GroupBoxAdditionalSettings.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            GroupBoxAdditionalSettings.Location = new Point(13, 307);
            GroupBoxAdditionalSettings.Margin = new Padding(4, 3, 4, 3);
            GroupBoxAdditionalSettings.Name = "GroupBoxAdditionalSettings";
            GroupBoxAdditionalSettings.Padding = new Padding(4, 3, 4, 3);
            GroupBoxAdditionalSettings.Size = new Size(838, 57);
            GroupBoxAdditionalSettings.TabIndex = 12;
            GroupBoxAdditionalSettings.TabStop = false;
            GroupBoxAdditionalSettings.Text = "Additional Settings";
            // 
            // LabelReadTheReadMe
            // 
            LabelReadTheReadMe.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            LabelReadTheReadMe.AutoSize = true;
            LabelReadTheReadMe.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            LabelReadTheReadMe.Location = new Point(438, 18);
            LabelReadTheReadMe.Margin = new Padding(4, 0, 4, 0);
            LabelReadTheReadMe.MaximumSize = new Size(350, 0);
            LabelReadTheReadMe.Name = "LabelReadTheReadMe";
            LabelReadTheReadMe.Size = new Size(344, 30);
            LabelReadTheReadMe.TabIndex = 31;
            LabelReadTheReadMe.Text =
                "Please read the README before using the \"Threaded mode\" " +
                "option (RECOMMENDED for batches of 500+ files)";
            // 
            // ButtonOpenReadme
            // 
            ButtonOpenReadme.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ButtonOpenReadme.Location = new Point(763, 36);
            ButtonOpenReadme.Margin = new Padding(4, 3, 4, 3);
            ButtonOpenReadme.Name = "ButtonOpenReadme";
            ButtonOpenReadme.Size = new Size(88, 27);
            ButtonOpenReadme.TabIndex = 13;
            ButtonOpenReadme.Text = "README";
            ButtonOpenReadme.UseVisualStyleBackColor = true;
            ButtonOpenReadme.Click += ButtonOpenReadme_Click;
            // 
            // ToolStripMenuItemSettings
            // 
            ToolStripMenuItemSettings.Name = "ToolStripMenuItemSettings";
            ToolStripMenuItemSettings.Size = new Size(61, 20);
            ToolStripMenuItemSettings.Text = "Settings";
            ToolStripMenuItemSettings.Click += ToolStripMenuItemSettings_Click;
            // 
            // ToolStripMenuItemAbout
            // 
            ToolStripMenuItemAbout.CheckOnClick = true;
            ToolStripMenuItemAbout.Name = "ToolStripMenuItemAbout";
            ToolStripMenuItemAbout.Size = new Size(52, 20);
            ToolStripMenuItemAbout.Text = "About";
            ToolStripMenuItemAbout.Click += ToolStripMenuItemAbout_Click;
            // 
            // ToolStripMenuItemHelp
            // 
            ToolStripMenuItemHelp.CheckOnClick = true;
            ToolStripMenuItemHelp.Name = "ToolStripMenuItemHelp";
            ToolStripMenuItemHelp.Size = new Size(44, 20);
            ToolStripMenuItemHelp.Text = "Help";
            ToolStripMenuItemHelp.Click += ToolStripMenuItemHelp_Click;
            // 
            // MenuStrip
            // 
            MenuStrip.BackColor = Color.White;
            MenuStrip.Items.AddRange
            (
                new ToolStripItem[]
                {
                    ToolStripMenuItemSettings,
                    ToolStripMenuItemAbout,
                    ToolStripMenuItemHelp,
                    ToolStripMenuItemReadme
                }
            );
            MenuStrip.Location = new Point(0, 0);
            MenuStrip.Name = "MenuStrip";
            MenuStrip.Size = new Size(864, 24);
            MenuStrip.TabIndex = 0;
            // 
            // ToolStripMenuItemReadme
            // 
            ToolStripMenuItemReadme.Name = "ToolStripMenuItemReadme";
            ToolStripMenuItemReadme.Size = new Size(65, 20);
            ToolStripMenuItemReadme.Text = "README";
            ToolStripMenuItemReadme.Click += ToolStripMenuItemReadme_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(864, 509);
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
            Controls.Add(MenuStrip);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = MenuStrip;
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "Champollion Interface";
            GroupBoxParameters.ResumeLayout(false);
            GroupBoxParameters.PerformLayout();
            GroupBoxProgress.ResumeLayout(false);
            GroupBoxAdditionalSettings.ResumeLayout(false);
            GroupBoxAdditionalSettings.PerformLayout();
            MenuStrip.ResumeLayout(false);
            MenuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }


        ///***********************************************************************
        /// <summary>
        /// Adds eventhandlers to the different possible events that can occur/be
        /// fired when using the UI, and ensures the right method is called when 
        /// the user performs some action in the program.
        /// </summary>
        ///***********************************************************************
        private void WireEvents()
        {
            #region Checkboxes
            /* 
            Template
            
            .CheckedChanged += 
                new EventHandler(this._CheckedChanged);
            
             */
            CheckBoxUseDifferentDirectoryForSource.CheckedChanged +=
                new EventHandler(this.CheckBoxUseDifferentDirectoryForSource_CheckedChanged);
            CheckBoxOutputAssemblyDiffLocation.CheckedChanged +=
                new EventHandler(this.CheckBoxOutputAssemblyDiffLocation_CheckedChanged);
            CheckBoxGenerateAssembly.CheckedChanged +=
                new EventHandler(this.CheckBoxGenerateAssembly_CheckedChanged);
            CheckBoxIgnoreCorruptFiles.CheckedChanged +=
                new EventHandler(this.CheckBoxIgnoreCorruptFiles_CheckedChanged);
            CheckBoxThreaded.CheckedChanged +=
                new EventHandler(this.CheckBoxThreaded_CheckedChanged);
            #endregion //Checkboxes
            #region Buttons
            /* 
            Template
            
            .Click += 
                new EventHandler(this._Click);
            
             */
            ButtonSourceDestinationBrowse.Click +=
                new EventHandler(this.ButtonSourceDestinationBrowse_Click);
            ButtonScriptsPathBrowse.Click +=
                new EventHandler(this.ButtonScriptsPathBrowse_Click);
            ButtonAssemblyPathBrowse.Click +=
                new EventHandler(this.ButtonAssemblyPathBrowse_Click);
            ButtonRun.Click +=
                new EventHandler(this.ButtonRun_Click);
            ButtonExit.Click +=
                new EventHandler(this.ButtonExit_Click);
            ButtonOpenReadme.Click +=
                new EventHandler(this.ButtonOpenReadme_Click);
            //ButtonAbout.Click += new EventHandler(this.ButtonAbout_Click);
            //ButtonHelp.Click += new EventHandler(this.ButtonHelp_Click);
            #endregion //Buttons
            #region Link labels
            /* 
            Template

            .LinkClicked += 
               new LinkLabelLinkClickedEventHandler(this._LinkClicked);

            */

            LinkLabelAuthorOriginal.LinkClicked +=
                new LinkLabelLinkClickedEventHandler(this.LinkLabelAuthorOriginal_LinkClicked);
            LinkLabelAuthorRevision.LinkClicked +=
               new LinkLabelLinkClickedEventHandler(this.LinkLabelAuthorRevision_LinkClicked);
            LinkLabelEndorse.LinkClicked +=
               new LinkLabelLinkClickedEventHandler(this.LinkLabelEndorse_LinkClicked);
            #endregion //Link labels
            #region Toolstrip buttons
            /* 
            Template

            .Click += 
              new EventArgs(this._Click);

            */

            ToolStripMenuItemSettings.Click +=
              new EventHandler(this.ToolStripMenuItemSettings_Click);
            ToolStripMenuItemAbout.Click +=
              new EventHandler(this.ToolStripMenuItemAbout_Click);
            ToolStripMenuItemHelp.Click +=
              new EventHandler(this.ToolStripMenuItemHelp_Click);
            ToolStripMenuItemReadme.Click +=
              new EventHandler(this.ToolStripMenuItemReadme_Click);

            #endregion //Toolstrip buttons
        }

        ///***********************************************************************
        /// <summary>
        /// Does the exact opposite of <see cref="WireEvents"/>, i.e. it removes
        /// the eventhandlers from all the events. Is used when the program is
        /// closed. Is only called by the <see cref="ButtonExit_Click"/> method.
        /// </summary>
        ///***********************************************************************
        private void UnWireEvents()
        {
            #region Checkboxes
            /* 
            Template
            
            .CheckedChanged -= 
                new EventHandler(this._CheckedChanged);
            
             */
            CheckBoxUseDifferentDirectoryForSource.CheckedChanged -=
                new EventHandler(this.CheckBoxUseDifferentDirectoryForSource_CheckedChanged);
            CheckBoxOutputAssemblyDiffLocation.CheckedChanged -=
                new EventHandler(this.CheckBoxOutputAssemblyDiffLocation_CheckedChanged);
            CheckBoxGenerateAssembly.CheckedChanged -=
                new EventHandler(this.CheckBoxGenerateAssembly_CheckedChanged);
            CheckBoxIgnoreCorruptFiles.CheckedChanged -=
                new EventHandler(this.CheckBoxIgnoreCorruptFiles_CheckedChanged);
            CheckBoxThreaded.CheckedChanged -=
                new EventHandler(this.CheckBoxThreaded_CheckedChanged);
            #endregion //Checkboxes
            #region Buttons
            /* 
            Template
            
            .Click -= 
                new EventHandler(this._Click);
            
             */
            ButtonSourceDestinationBrowse.Click -=
                new EventHandler(this.ButtonSourceDestinationBrowse_Click);
            ButtonScriptsPathBrowse.Click -=
                new EventHandler(this.ButtonScriptsPathBrowse_Click);
            ButtonAssemblyPathBrowse.Click -=
                new EventHandler(this.ButtonAssemblyPathBrowse_Click);
            ButtonRun.Click -=
                new EventHandler(this.ButtonRun_Click);
            ButtonExit.Click -=
                new EventHandler(this.ButtonExit_Click);
            ButtonOpenReadme.Click -=
                new EventHandler(this.ButtonOpenReadme_Click);
            //ButtonAbout.Click -= new EventHandler(this.ButtonAbout_Click);
            //ButtonHelp.Click -= new EventHandler(this.ButtonHelp_Click);
            #endregion //Buttons
            #region Link labels
            /* 
            Template

            .LinkClicked -= 
               new LinkLabelLinkClickedEventHandler(this._LinkClicked);

            */

            LinkLabelAuthorOriginal.LinkClicked -=
                new LinkLabelLinkClickedEventHandler(this.LinkLabelAuthorOriginal_LinkClicked);
            LinkLabelAuthorRevision.LinkClicked -=
               new LinkLabelLinkClickedEventHandler(this.LinkLabelAuthorRevision_LinkClicked);
            LinkLabelEndorse.LinkClicked -=
               new LinkLabelLinkClickedEventHandler(this.LinkLabelEndorse_LinkClicked);
            #endregion //Link labels
            #region Toolstrip buttons
            /* 
            Template

            .Click -= 
              new EventArgs(this._Click);

            */

            ToolStripMenuItemSettings.Click -=
              new EventHandler(this.ToolStripMenuItemSettings_Click);
            ToolStripMenuItemAbout.Click -=
              new EventHandler(this.ToolStripMenuItemAbout_Click);
            ToolStripMenuItemHelp.Click -=
              new EventHandler(this.ToolStripMenuItemHelp_Click);
            ToolStripMenuItemReadme.Click -=
              new EventHandler(this.ToolStripMenuItemReadme_Click);

            #endregion //Toolstrip buttons
        }

        #region Form methods
        #region Checkboxes
        private void CheckBoxUseDifferentDirectoryForSource_CheckedChanged(Object? Sender, EventArgs EA)
        {
            ButtonSourceDestinationBrowse.Enabled = CheckBoxUseDifferentDirectoryForSource.Checked;
            TextBoxSourcePath.Enabled = CheckBoxUseDifferentDirectoryForSource.Checked;

            //Clears the source PexFileDirectory box if the checkbox is "unticked"
            if(!CheckBoxUseDifferentDirectoryForSource.Checked)
            {
                TextBoxSourcePath.Text = String.Empty;
            }
        }

        private void CheckBoxOutputAssemblyDiffLocation_CheckedChanged(Object? Sender, EventArgs EA)
        {
            ButtonAssemblyPathBrowse.Enabled = CheckBoxOutputAssemblyDiffLocation.Checked;
            TextBoxAssemblyPath.Enabled = CheckBoxOutputAssemblyDiffLocation.Checked;

            //Clears the assembly PexFileDirectory box if the checkbox is "unticked"
            if(!CheckBoxOutputAssemblyDiffLocation.Checked)
            {
                TextBoxAssemblyPath.Text = String.Empty;
            }
        }

        private void CheckBoxGenerateAssembly_CheckedChanged(Object? Sender, EventArgs EA)
        {
            CheckBoxOutputAssemblyDiffLocation.Enabled = CheckBoxGenerateAssembly.Checked;
            if(!CheckBoxGenerateAssembly.Checked)
            {
                CheckBoxOutputAssemblyDiffLocation.Checked = false;
                if(!CheckBoxOutputAssemblyDiffLocation.Checked)
                {
                    TextBoxAssemblyPath.Enabled = false;
                    TextBoxAssemblyPath.Text = String.Empty;
                }

            }
        }

        private void CheckBoxIgnoreCorruptFiles_CheckedChanged(Object? sender, EventArgs EA)
        {
            CheckBoxThreaded.Enabled = !CheckBoxIgnoreCorruptFiles.Checked;
            CheckBoxThreaded.Checked = false;
        }

        private void CheckBoxThreaded_CheckedChanged(Object? sender, EventArgs EA)
        {
            CheckBoxIgnoreCorruptFiles.Enabled = !CheckBoxThreaded.Checked;
            CheckBoxIgnoreCorruptFiles.Checked = false;
        }
        #endregion //Checkboxes
        #region Buttons
        private void ButtonSourceDestinationBrowse_Click(Object? Sender, EventArgs EA)
        {
            String Path = SelectFolder();
            if(Path != "")
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
            if(Path != "")
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
            if(Path != "")
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
            catch(PreDecompilationException PDE)
            {
                return;
            }

            try
            {
                if(new MessageBox("Confirm Run", "Are you sure you want to run Champollion?", true).ShowDialog() == DialogResult.OK)
                {
                    if(option == 'E')
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
            catch(PreDecompilationException PDE)
            {

            }
            catch(IntraDecompilationException IDE)
            {

            }
        }

        private void ButtonExit_Click(Object? Sender, EventArgs EA)
        {
            this.UnWireEvents();
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }


        //private void ButtonHelp_Click(Object? Sender, EventArgs EA)
        //{
        //    String Help_Text = Properties.TextResources.help;
        //    /*
        //    About_Strings Help_Strings = new About_Strings();
        //    Help_Strings.AppendLine("READ THE README BEFORE YOU POST ABOUT AN ISSUE! YOUR QUESTION IS");
        //    Help_Strings.AppendLine("LIKELY ANSWERED THERE ALREADY!");
        //    Help_Strings.AppendLine("The readme can be found at:");
        //    Help_Strings.AppendLine("https://github.com/w1ndStrik3/ChampollionGUI_Update/ and also");
        //    Help_Strings.AppendLine("and also inside the doc folder (Champollion_directory/doc/readme.txt");
        //    Help_Strings.AppendLine("");
        //    Help_Strings.AppendLine("If you have trouble and need assistance, please comments on the mod");
        //    Help_Strings.AppendLine("page on Nexus or post a new issue on the GitHub page. You are welcome");
        //    Help_Strings.AppendLine("to contact me directly on Steam");
        //    Help_Strings.AppendLine("https://steamcommunity.com/id/w1ndStrik3_official/, but I would highly");
        //    Help_Strings.AppendLine("prefer if you would post your issue on Nexus or GitHub, because other");
        //    Help_Strings.AppendLine("people might have the same issue as you, and find the solution on Nexus");
        //    Help_Strings.AppendLine("or GitHub. That way I will not 117 people message me about the same");
        //    Help_Strings.AppendLine("thing. If it so happens that I do not respond within 72 hours of you");
        //    Help_Strings.AppendLine("writing your post, please contact me on Steam and let me know about");
        //    Help_Strings.AppendLine("your post. I might not have gotten a notification about your post if I");
        //    Help_Strings.AppendLine("do not respond within 72 hours. Thank you very much.");
        //    Help_Strings.AppendLine("-w1ndStrik3");
        //    */
        //    _ = new MessageBox("Help", Help_Text /*Help_Strings.ToString()*/, false).ShowDialog();
        //}
        //
        //
        //private void ButtonAbout_Click(Object? Sender, EventArgs EA)
        //{
        //    String About_Text = Properties.TextResources.about;
        //    /*
        //    StringBuilder About_Strings = new StringBuilder();
        //    About_Strings.AppendLine("Summary of the program:");
        //    About_Strings.AppendLine("This program provides a Graphical User Interface (GUI) to li1nx's ");
        //    About_Strings.AppendLine("\"Champollion a PEX to Papyrus decompiler\"");
        //    About_Strings.AppendLine("Link to Original Tool: http://www.nexusmods.com/skyrim/mods/35307/");
        //    About_Strings.AppendLine("");
        //    About_Strings.AppendLine("This program is a significant upgrade and modernizations of the");
        //    About_Strings.AppendLine("original \"Champollion Graphical User Interface\" which was originally");
        //    About_Strings.AppendLine("made by Arron Dominion. https://www.nexusmods.com/skyrim/mods/82367");
        //    About_Strings.AppendLine("");
        //    About_Strings.AppendLine("Compared to the old Champollion GUI, this version improves the");
        //    About_Strings.AppendLine("performance of the program (this version runs on the newest .NET,");
        //    About_Strings.AppendLine("which is .NET version 8 currently). Additionaly, this updated");
        //    About_Strings.AppendLine("version of the Champollion Graphical User Interface severely improves");
        //    About_Strings.AppendLine("the user experience and the ease of use, along with a few added");
        //    About_Strings.AppendLine("features compared to the original version by Arron Dominion.");
        //    About_Strings.AppendLine("");
        //    About_Strings.AppendLine("The README can be found at:");
        //    About_Strings.AppendLine("https://github.com/w1ndStrik3/ChampollionGUI_Update/");
        //    */
        //    _ = new MessageBox("About", About_Text /*About_Strings.ToString()*/, false).ShowDialog();
        //
        //}

        private void ButtonOpenReadme_Click(Object? sender, EventArgs e)
        {





        }
        #endregion //Buttons
        #region Link labels
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
        #endregion //Link labels
        #region Tooltsrip buttons
        private void ToolStripMenuItemSettings_Click(Object? sender, EventArgs EA)
        {

        }

        private void ToolStripMenuItemAbout_Click(Object? sender, EventArgs EA)
        {
            _ = new AboutBox().ShowDialog();
        }

        private void ToolStripMenuItemHelp_Click(Object? sender, EventArgs EA)
        {
            String Help_Text = Properties.TextResources.help;
            _ = new MessageBox("Help", Help_Text /*Help_Strings.ToString()*/, false).ShowDialog();
        }

        private void ToolStripMenuItemReadme_Click(Object? sender, EventArgs EA)
        {
            //TODO: Create try/catch. See Exeption class for TODO
            //String Readme = "readme_instructions.txt";
            //String Dir = Directory.GetCurrentDirectory();
            //String Wholepath = $"{Dir}\\doc\\{Readme}";
            //Process.Start(new ProcessStartInfo(Wholepath) { UseShellExecute = true });
            String ReadMe_Text = Properties.TextResources.readme_instructions;
            _ = new MessageBox("Settings", ReadMe_Text, false).ShowDialog();
        }
        #endregion //Tooltsrip buttons
        #endregion //Form methods
        #region Custom methods
        private String SelectFolder()
        {
            String Path = Directory.GetCurrentDirectory();
            FolderDialog.InitialDirectory = Path;
            if(FolderDialog.ShowDialog() == DialogResult.OK)
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
                                   $"\r\nError message: {Error}" +
                                   "\r\n" +
                                   "\r\nAn error log file has also been created.";

            _ = new MessageBox("Run Error", Fishy, false).ShowDialog();
        }
        #endregion //Custom methods

    }
}