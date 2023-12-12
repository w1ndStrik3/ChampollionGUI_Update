using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ChampollionGUI_Update
{
    public class MessageBox : Form
    {
        private IContainer components;
        private Label labelMsgBoxText;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnOk;
        private PictureBox msgBoxIconField;
        private Button btnCancel;

        #pragma warning disable CS8618
        public MessageBox() => this.InitializeComponent();
        #pragma warning restore CS8618

        //************************************************************************
        /// <summary>
        /// A new Message box is constructed, with the three parameters "Title",
        /// "Message" and "showCancel".
        /// </summary>
        /// <param name="Title">
        /// The Title shown in the top bar/edge of the Message box.
        /// </param>
        /// <param name="Message">
        /// The text of the Message that the Message box will display.
        /// </param>
        /// <param name="showCancel">
        /// The boolean "showCancel" indicates whether the Message box should
        /// display "Cancel" button in addition to the "OK" button, or only the
        /// "OK" button. When "showCancel" is true, the "Cancel" button is
        /// displayed.
        /// </param>
        //************************************************************************
        public MessageBox(String Title, String Message, bool showCancel) : this()
        {
            this.Text = Title;
            labelMsgBoxText.Text = Message;
            if (!showCancel)
            {
                btnCancel.Visible = false;
            }
            /*
            else
            {
                btnOk.Text = "Yes";
                btnCancel.Text = "No";
            }
            */

            iconSelect(Title);
            this.WireEvents();
        }

        private void iconSelect(String Title)
        {
            String Dir = Directory.GetCurrentDirectory() + @"\images\";
            switch (Title)
            {
                case "Run Error":
                    msgBoxIconField.Image = new Bitmap(Dir + "error.jpg");
                    break;
                case "Warning":
                    msgBoxIconField.Image = new Bitmap(Dir + "warning.jpg");
                    break;
                case "Confirm Run":
                    msgBoxIconField.Image = new Bitmap(Dir + "confirm.jpg");
                    break;
                case "Champollion Error":
                    msgBoxIconField.Image = new Bitmap(Dir + "champ_error.jpg");
                    break;
                case "Champollion Run Complete":
                    msgBoxIconField.Image = new Bitmap(Dir + "finished.jpg");
                    break;
                case "About":
                    msgBoxIconField.Image = new Bitmap(Dir + "about.jpg");
                    break;
                default:
                    msgBoxIconField.Image = null;
                    break;
            }
        }

        private void WireEvents()
        {
            btnOk.Click += new EventHandler(this.btnOk_Click);
            btnCancel.Click += new EventHandler(this.btnCancel_Click);
        }

        private void UnWireEvents()
        {
            btnOk.Click -= new EventHandler(this.btnOk_Click);
            btnCancel.Click -= new EventHandler(this.btnCancel_Click);
        }

        private void btnCancel_Click(Object? Sender, EventArgs EA)
        {
            this.UnWireEvents();
            this.DialogResult = DialogResult.Cancel;
        }

        //************************************************************************
        /// <summary>
        /// Adds check to see if the user if a wierdo and clicks the close (X) 
        /// button in the corner instead of using the No/Cancel button like a 
        /// normal human
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="FCEA"></param>
        //************************************************************************
        private void MessageBox_FormClosing(Object? Sender, FormClosingEventArgs FCEA)
        {
            _ = new EventHandler(this.btnCancel_Click);
            FCEA.Cancel = true;
        }

        private void btnOk_Click(Object? Sender, EventArgs EA)
        {
            this.UnWireEvents();
            this.DialogResult = DialogResult.OK;
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
            labelMsgBoxText = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnOk = new Button();
            btnCancel = new Button();
            msgBoxIconField = new PictureBox();
            tableLayoutPanel1.SuspendLayout();
            ((ISupportInitialize)msgBoxIconField).BeginInit();
            SuspendLayout();
            // 
            // labelMsgBoxText
            // 
            labelMsgBoxText.AutoSize = true;
            labelMsgBoxText.Location = new Point(14, 10);
            labelMsgBoxText.Margin = new Padding(4, 0, 4, 0);
            labelMsgBoxText.MaximumSize = new Size(386, 0);
            labelMsgBoxText.Name = "labelMsgBoxText";
            labelMsgBoxText.Size = new Size(355, 15);
            labelMsgBoxText.TabIndex = 0;
            labelMsgBoxText.Text = "Message Box Text Goes Here. If you are seeing this, please report it";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(btnOk, 0, 0);
            tableLayoutPanel1.Controls.Add(btnCancel, 1, 0);
            tableLayoutPanel1.Location = new Point(464, 208);
            tableLayoutPanel1.Margin = new Padding(4, 3, 4, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(190, 32);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(4, 3);
            btnOk.Margin = new Padding(4, 3, 4, 3);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(87, 25);
            btnOk.TabIndex = 0;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(99, 3);
            btnCancel.Margin = new Padding(4, 3, 4, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(87, 25);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // msgBoxIconField
            // 
            msgBoxIconField.Location = new Point(464, 8);
            msgBoxIconField.Name = "msgBoxIconField";
            msgBoxIconField.Size = new Size(190, 190);
            msgBoxIconField.TabIndex = 2;
            msgBoxIconField.TabStop = false;
            // 
            // MessageBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(688, 252);
            Controls.Add(msgBoxIconField);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(labelMsgBoxText);
            Margin = new Padding(4, 3, 4, 3);
            Name = "MessageBox";
            StartPosition = FormStartPosition.CenterParent;
            Text = "MessageBox";
            tableLayoutPanel1.ResumeLayout(false);
            ((ISupportInitialize)msgBoxIconField).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
