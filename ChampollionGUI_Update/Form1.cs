using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using Microsoft.WindowsAPICodePack.Dialogs;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;


namespace ChampollionGUI_Update
{
    public class Form1 : Form
    {
        #region declarations

        private IContainer components;
        private Button btnHelp;
        private Button btnAbout;
        private GroupBox groupBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private TextBox txtScriptsPEXPath;
        private Button btnScriptsPathBrowse;
        private Label label2;
        private CheckBox chkUseDifferentDirectoryForSource;
        private TextBox txtSourcePath;
        private Button btnSourceDestinationBrowse;
        private CheckBox chkGenerateAssembly;
        private CheckBox chkOutputAssemblyDiffLocation;
        private Label label3;
        private TextBox txtAssemblyPath;
        private Button btnAssemblyPathBrowse;
        private CheckBox chkGenerateComments;
        //private FolderBrowserDialog folderBrowserDialog1;
        private CommonOpenFileDialog folderDiag;
        private GroupBox groupBox2;
        private ProgressBar pbProgress;
        private TableLayoutPanel tableLayoutPanel2;
        private Button btnRun;
        private Label label4;
        private Label label5;
        private LinkLabel linkLabel1;
        private Label label6;
        private LinkLabel linkLabel2;
        private Button btnExit;

        #endregion

        public Form1()
        {
            this.InitializeComponent();
            this.WireEvents();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Form1));
            btnHelp = new Button();
            btnAbout = new Button();
            groupBox1 = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            txtScriptsPEXPath = new TextBox();
            btnScriptsPathBrowse = new Button();
            label2 = new Label();
            chkUseDifferentDirectoryForSource = new CheckBox();
            txtSourcePath = new TextBox();
            btnSourceDestinationBrowse = new Button();
            chkGenerateAssembly = new CheckBox();
            chkOutputAssemblyDiffLocation = new CheckBox();
            label3 = new Label();
            txtAssemblyPath = new TextBox();
            btnAssemblyPathBrowse = new Button();
            chkGenerateComments = new CheckBox();
            label4 = new Label();
            groupBox2 = new GroupBox();
            pbProgress = new ProgressBar();
            tableLayoutPanel2 = new TableLayoutPanel();
            btnRun = new Button();
            btnExit = new Button();
            label5 = new Label();
            linkLabel1 = new LinkLabel();
            label6 = new Label();
            linkLabel2 = new LinkLabel();
            folderDiag = new CommonOpenFileDialog();
            groupBox1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            groupBox2.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // btnHelp
            // 
            btnHelp.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnHelp.Location = new Point(768, 17);
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
            btnAbout.Location = new Point(673, 17);
            btnAbout.Margin = new Padding(4, 3, 4, 3);
            btnAbout.Name = "btnAbout";
            btnAbout.Size = new Size(88, 27);
            btnAbout.TabIndex = 3;
            btnAbout.Text = "About...";
            btnAbout.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(tableLayoutPanel1);
            groupBox1.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.Location = new Point(15, 51);
            groupBox1.Margin = new Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 3, 4, 3);
            groupBox1.Size = new Size(840, 387);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Parameters";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 8;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(txtScriptsPEXPath, 2, 0);
            tableLayoutPanel1.Controls.Add(btnScriptsPathBrowse, 7, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 2);
            tableLayoutPanel1.Controls.Add(chkUseDifferentDirectoryForSource, 0, 1);
            tableLayoutPanel1.Controls.Add(txtSourcePath, 2, 2);
            tableLayoutPanel1.Controls.Add(btnSourceDestinationBrowse, 7, 2);
            tableLayoutPanel1.Controls.Add(chkGenerateAssembly, 0, 3);
            tableLayoutPanel1.Controls.Add(chkOutputAssemblyDiffLocation, 2, 3);
            tableLayoutPanel1.Controls.Add(label3, 0, 4);
            tableLayoutPanel1.Controls.Add(txtAssemblyPath, 2, 4);
            tableLayoutPanel1.Controls.Add(btnAssemblyPathBrowse, 7, 4);
            tableLayoutPanel1.Controls.Add(chkGenerateComments, 0, 5);
            tableLayoutPanel1.Controls.Add(label4, 4, 6);
            tableLayoutPanel1.Location = new Point(7, 25);
            tableLayoutPanel1.Margin = new Padding(4, 3, 4, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 9;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.11111F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.11111F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.11111F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.11111F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.11111F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.11111F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.11111F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.11111F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.11111F));
            tableLayoutPanel1.Size = new Size(825, 352);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left;
            label1.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(label1, 2);
            label1.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(4, 12);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(119, 15);
            label1.TabIndex = 0;
            label1.Text = "Scripts Folder (.pex):";
            // 
            // txtScriptsPEXPath
            // 
            txtScriptsPEXPath.BackColor = SystemColors.ControlLightLight;
            tableLayoutPanel1.SetColumnSpan(txtScriptsPEXPath, 5);
            txtScriptsPEXPath.Location = new Point(210, 3);
            txtScriptsPEXPath.Margin = new Padding(4, 3, 4, 3);
            txtScriptsPEXPath.Name = "txtScriptsPEXPath";
            txtScriptsPEXPath.Size = new Size(506, 23);
            txtScriptsPEXPath.TabIndex = 1;
            // 
            // btnScriptsPathBrowse
            // 
            btnScriptsPathBrowse.Font = new Font("Microsoft Sans Serif", 8.5F, FontStyle.Regular, GraphicsUnit.Point);
            btnScriptsPathBrowse.Location = new Point(725, 3);
            btnScriptsPathBrowse.Margin = new Padding(4, 3, 4, 3);
            btnScriptsPathBrowse.Name = "btnScriptsPathBrowse";
            btnScriptsPathBrowse.Size = new Size(96, 23);
            btnScriptsPathBrowse.TabIndex = 2;
            btnScriptsPathBrowse.Text = "Browse";
            btnScriptsPathBrowse.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left;
            label2.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(label2, 2);
            label2.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(4, 90);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(114, 15);
            label2.TabIndex = 3;
            label2.Text = "Source Destination:";
            // 
            // chkUseDifferentDirectoryForSource
            // 
            chkUseDifferentDirectoryForSource.Anchor = AnchorStyles.Left;
            chkUseDifferentDirectoryForSource.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(chkUseDifferentDirectoryForSource, 3);
            chkUseDifferentDirectoryForSource.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            chkUseDifferentDirectoryForSource.Location = new Point(4, 49);
            chkUseDifferentDirectoryForSource.Margin = new Padding(4, 3, 4, 3);
            chkUseDifferentDirectoryForSource.Name = "chkUseDifferentDirectoryForSource";
            chkUseDifferentDirectoryForSource.Size = new Size(216, 19);
            chkUseDifferentDirectoryForSource.TabIndex = 4;
            chkUseDifferentDirectoryForSource.Text = "Output Source in Different Location";
            chkUseDifferentDirectoryForSource.UseVisualStyleBackColor = true;
            // 
            // txtSourcePath
            // 
            txtSourcePath.BackColor = SystemColors.ControlLightLight;
            tableLayoutPanel1.SetColumnSpan(txtSourcePath, 5);
            txtSourcePath.Enabled = false;
            txtSourcePath.Location = new Point(210, 81);
            txtSourcePath.Margin = new Padding(4, 3, 4, 3);
            txtSourcePath.Name = "txtSourcePath";
            txtSourcePath.Size = new Size(506, 23);
            txtSourcePath.TabIndex = 5;
            // 
            // btnSourceDestinationBrowse
            // 
            btnSourceDestinationBrowse.Enabled = false;
            btnSourceDestinationBrowse.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnSourceDestinationBrowse.Location = new Point(725, 81);
            btnSourceDestinationBrowse.Margin = new Padding(4, 3, 4, 3);
            btnSourceDestinationBrowse.Name = "btnSourceDestinationBrowse";
            btnSourceDestinationBrowse.Size = new Size(96, 23);
            btnSourceDestinationBrowse.TabIndex = 6;
            btnSourceDestinationBrowse.Text = "Browse";
            btnSourceDestinationBrowse.UseVisualStyleBackColor = true;
            // 
            // chkGenerateAssembly
            // 
            chkGenerateAssembly.Anchor = AnchorStyles.Left;
            chkGenerateAssembly.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(chkGenerateAssembly, 2);
            chkGenerateAssembly.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            chkGenerateAssembly.Location = new Point(4, 127);
            chkGenerateAssembly.Margin = new Padding(4, 3, 4, 3);
            chkGenerateAssembly.Name = "chkGenerateAssembly";
            chkGenerateAssembly.Size = new Size(132, 19);
            chkGenerateAssembly.TabIndex = 7;
            chkGenerateAssembly.Text = "Generate Assembly";
            chkGenerateAssembly.UseVisualStyleBackColor = true;
            // 
            // chkOutputAssemblyDiffLocation
            // 
            chkOutputAssemblyDiffLocation.Anchor = AnchorStyles.Left;
            chkOutputAssemblyDiffLocation.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(chkOutputAssemblyDiffLocation, 3);
            chkOutputAssemblyDiffLocation.Enabled = false;
            chkOutputAssemblyDiffLocation.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            chkOutputAssemblyDiffLocation.Location = new Point(210, 127);
            chkOutputAssemblyDiffLocation.Margin = new Padding(4, 3, 4, 3);
            chkOutputAssemblyDiffLocation.Name = "chkOutputAssemblyDiffLocation";
            chkOutputAssemblyDiffLocation.Size = new Size(229, 19);
            chkOutputAssemblyDiffLocation.TabIndex = 8;
            chkOutputAssemblyDiffLocation.Text = "Output Assembly in Different Location";
            chkOutputAssemblyDiffLocation.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Left;
            label3.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(label3, 2);
            label3.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(4, 168);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(127, 15);
            label3.TabIndex = 9;
            label3.Text = "Assembly Destination:";
            // 
            // txtAssemblyPath
            // 
            txtAssemblyPath.BackColor = SystemColors.ControlLightLight;
            tableLayoutPanel1.SetColumnSpan(txtAssemblyPath, 5);
            txtAssemblyPath.Enabled = false;
            txtAssemblyPath.Location = new Point(210, 159);
            txtAssemblyPath.Margin = new Padding(4, 3, 4, 3);
            txtAssemblyPath.Name = "txtAssemblyPath";
            txtAssemblyPath.Size = new Size(506, 23);
            txtAssemblyPath.TabIndex = 10;
            // 
            // btnAssemblyPathBrowse
            // 
            btnAssemblyPathBrowse.Enabled = false;
            btnAssemblyPathBrowse.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnAssemblyPathBrowse.Location = new Point(725, 159);
            btnAssemblyPathBrowse.Margin = new Padding(4, 3, 4, 3);
            btnAssemblyPathBrowse.Name = "btnAssemblyPathBrowse";
            btnAssemblyPathBrowse.Size = new Size(96, 23);
            btnAssemblyPathBrowse.TabIndex = 11;
            btnAssemblyPathBrowse.Text = "Browse";
            btnAssemblyPathBrowse.UseVisualStyleBackColor = true;
            // 
            // chkGenerateComments
            // 
            chkGenerateComments.Anchor = AnchorStyles.Left;
            chkGenerateComments.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(chkGenerateComments, 2);
            chkGenerateComments.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            chkGenerateComments.Location = new Point(4, 205);
            chkGenerateComments.Margin = new Padding(4, 3, 4, 3);
            chkGenerateComments.Name = "chkGenerateComments";
            chkGenerateComments.Size = new Size(140, 19);
            chkGenerateComments.TabIndex = 12;
            chkGenerateComments.Text = "Generate Comments";
            chkGenerateComments.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(415, 234);
            label4.Name = "label4";
            label4.Size = new Size(72, 34);
            label4.TabIndex = 13;
            label4.Text = "Please Endorse!";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(pbProgress);
            groupBox2.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox2.Location = new Point(15, 444);
            groupBox2.Margin = new Padding(4, 3, 4, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4, 3, 4, 3);
            groupBox2.Size = new Size(840, 96);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Progress";
            // 
            // pbProgress
            // 
            pbProgress.Location = new Point(7, 38);
            pbProgress.Margin = new Padding(4, 3, 4, 3);
            pbProgress.Name = "pbProgress";
            pbProgress.Size = new Size(825, 27);
            pbProgress.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(btnRun, 0, 0);
            tableLayoutPanel2.Controls.Add(btnExit, 1, 0);
            tableLayoutPanel2.Location = new Point(321, 547);
            tableLayoutPanel2.Margin = new Padding(4, 3, 4, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(233, 38);
            tableLayoutPanel2.TabIndex = 6;
            // 
            // btnRun
            // 
            btnRun.Anchor = AnchorStyles.None;
            btnRun.Location = new Point(14, 5);
            btnRun.Margin = new Padding(4, 3, 4, 3);
            btnRun.Name = "btnRun";
            btnRun.Size = new Size(88, 27);
            btnRun.TabIndex = 0;
            btnRun.Text = "Run...";
            btnRun.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.None;
            btnExit.Location = new Point(130, 5);
            btnExit.Margin = new Padding(4, 3, 4, 3);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(88, 27);
            btnExit.TabIndex = 1;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 9);
            label5.Name = "label5";
            label5.Size = new Size(64, 15);
            label5.TabIndex = 7;
            label5.Text = "Created by";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(73, 9);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(93, 15);
            linkLabel1.TabIndex = 8;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Arron Dominion";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 29);
            label6.Name = "label6";
            label6.Size = new Size(146, 15);
            label6.TabIndex = 9;
            label6.Text = "Updated and enhanced by";
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.Location = new Point(154, 29);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(65, 15);
            linkLabel2.TabIndex = 10;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "w1ndStrik3";
            linkLabel2.LinkClicked += linkLabel2_LinkClicked;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(869, 600);
            Controls.Add(linkLabel2);
            Controls.Add(label6);
            Controls.Add(linkLabel1);
            Controls.Add(label5);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(btnAbout);
            Controls.Add(btnHelp);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "Champollion Interface";
            groupBox1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            groupBox2.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
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
            folderDiag.IsFolderPicker = true;
            if (folderDiag.ShowDialog() == CommonFileDialogResult.Ok)
            {
                path = folderDiag.FileName;
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
                    String Warning = "You have selected to use a custom directory for the " +
                                     "source files but have left the directory path field " +
                                     "Would you like to use the default directory? Select " +
                                     "\"Yes\" to continue with the default directory or " +
                                     "select \"No\" to cancel.\r\nDefault directory is: " +
                                     "%Scripts Folder%\\source";

                    if (new MessageBox("Warning", Warning, true).ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }
                }
            }

            if (chkGenerateAssembly.Checked)
            {
                if (chkOutputAssemblyDiffLocation.Checked)
                {
                    if (!string.IsNullOrWhiteSpace(txtAssemblyPath.Text))
                    {
                        outputAssembly = true;
                    }
                    String warning = "You have selected to use a custom directory for the " +
                                     "assembly files but have left the directory path field " +
                                     "Would you like to use the default directory? Select " +
                                     "\"Yes\" to continue with the default directory or " +
                                     "select \"No\" to cancel.\r\nDefault directory is: " +
                                     "%Scripts Folder%\\assembly";

                    if (new MessageBox("Warning", warning, true).ShowDialog() == DialogResult.OK)
                    {
                        return;
                    }
                }
            }
            else
            {
                if (new MessageBox("Confirm Run", "Are you sure you want to run Champollion?", true).ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                else //(!string.IsNullOrWhiteSpace(txtScriptsPEXPath.Text))
                {
                    /*
                    In the name of Christ and everything holy, that was the longest condition statement i have ever seen. Daymn.
                    550 character long condition statement... No offense but I will make it look prettier.
                    This is not a criticism, just very surprised. Look, if it works, it works. Everything else is personal preference.
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
                                List<String> StringList = new List<String>();
                                StringList.Add(String.Format("\"{0}\"", (object)pexFiles[index1]));

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
                            catch (Exception ex)
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
                    do
                    {
                        //wait
                    }
                    while (task.Status.Equals((object)TaskStatus.Running));

                    if (encounteredError)
                    {
                        return;
                    }
                    _ = new MessageBox("Champollion Run Complete", "Champollion has successfully processed all files. \r\n" +
                                                                    "Verify your scripts. \n Note: Events will be listed as Functions ", false).ShowDialog();
                }
            }
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
            StringBuilder.AppendLine("Champollion a PEX to Papyrus decompiler User Interface Version 2");
            StringBuilder.AppendLine("");
            StringBuilder.AppendLine("by Arron Dominion (Updated by w1ndStrik3)");
            StringBuilder.AppendLine("");
            StringBuilder.AppendLine("Description: This program provides an interface to li1nx's");
            StringBuilder.AppendLine("                   Champollion a PEX to Papyrus decompiler program");
            StringBuilder.AppendLine("Link to Original Tool: http://www.nexusmods.com/skyrim/mods/35307/");
            _ = new MessageBox("About", StringBuilder.ToString(), false).ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Specify that the link was visited.
            linkLabel1.LinkVisited = true;

            // Navigate to a URL.
            Process.Start("https://www.nexusmods.com/users/582310");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Specify that the link was visited.
            linkLabel2.LinkVisited = true;

            // Navigate to a URL.
            Process.Start("https://www.nexusmods.com/users/39381905");
        }
    }
}