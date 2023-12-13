using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ChampollionGUI_Update
{
    public class MessageBox : Form
    {
        private IContainer Components;
        private Label LabelMessageBoxText;
        private Button ButtonOk;
        private PictureBox MessageBoxIconField;
        private Button ButtonCancel;

        #pragma warning disable CS8618
        public MessageBox() => this.InitializeComponent();
#pragma warning restore CS8618

        private void InitializeComponent()
        {
            LabelMessageBoxText = new Label();
            ButtonOk = new Button();
            ButtonCancel = new Button();
            MessageBoxIconField = new PictureBox();
            ((ISupportInitialize)MessageBoxIconField).BeginInit();
            SuspendLayout();
            // 
            // LabelMessageBoxText
            // 
            LabelMessageBoxText.AutoSize = true;
            LabelMessageBoxText.Font = new Font("Segoe UI", 9F);
            LabelMessageBoxText.Location = new Point(14, 10);
            LabelMessageBoxText.Margin = new Padding(4, 0, 4, 0);
            LabelMessageBoxText.MaximumSize = new Size(430, 0);
            LabelMessageBoxText.Name = "LabelMessageBoxText";
            LabelMessageBoxText.Size = new Size(427, 45);
            LabelMessageBoxText.TabIndex = 0;
            LabelMessageBoxText.Text = "abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyz\nMessage Box Text Goes Here. If you are seeing this, please report it";
            // 
            // ButtonOk
            // 
            ButtonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ButtonOk.Location = new Point(463, 215);
            ButtonOk.Margin = new Padding(4, 3, 4, 3);
            ButtonOk.Name = "ButtonOk";
            ButtonOk.Size = new Size(87, 25);
            ButtonOk.TabIndex = 0;
            ButtonOk.Text = "OK";
            ButtonOk.UseVisualStyleBackColor = true;
            // 
            // ButtonCancel
            // 
            ButtonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ButtonCancel.Location = new Point(568, 215);
            ButtonCancel.Margin = new Padding(4, 3, 4, 3);
            ButtonCancel.Name = "ButtonCancel";
            ButtonCancel.Size = new Size(87, 25);
            ButtonCancel.TabIndex = 1;
            ButtonCancel.Text = "Cancel";
            ButtonCancel.UseVisualStyleBackColor = true;
            // 
            // MessageBoxIconField
            // 
            MessageBoxIconField.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            MessageBoxIconField.Location = new Point(464, 8);
            MessageBoxIconField.Name = "MessageBoxIconField";
            MessageBoxIconField.Size = new Size(190, 190);
            MessageBoxIconField.TabIndex = 2;
            MessageBoxIconField.TabStop = false;
            // 
            // MessageBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(688, 252);
            Controls.Add(ButtonCancel);
            Controls.Add(ButtonOk);
            Controls.Add(MessageBoxIconField);
            Controls.Add(LabelMessageBoxText);
            Margin = new Padding(4, 3, 4, 3);
            Name = "MessageBox";
            StartPosition = FormStartPosition.CenterParent;
            Text = "MessageBox";
            ((ISupportInitialize)MessageBoxIconField).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        //************************************************************************
        /// <summary>
        /// A new Message box is constructed, with the three parameters "Title",
        /// "Message" and "showCancel".
        /// </summary>
        /// <param name="Title">
        /// The Title shown in the top bar/edge of the Message box.
        /// </param>
        /// <param name="Message">
        /// The PexFileDirectory of the Message that the Message box will display.
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
            LabelMessageBoxText.Text = Message;
            if (!showCancel)
            {
                ButtonCancel.Visible = false;
            }
            /*
            else
            {
                btnOk.PexFileDirectory = "Yes";
                btnCancel.PexFileDirectory = "No";
            }
            */
            int lines = CountLines(Text);
            if (lines > 13)
            {
                lines -= 13;
                this.Height = 291 + 15 * lines;
            }


            IconSelect(Title);
            this.WireEvents();
        }

        private void IconSelect(String Title)
        {
            String Dir = Directory.GetCurrentDirectory() + @"\images\";
            switch (Title)
            {
                case "Run Error":
                    MessageBoxIconField.Image = new Bitmap(Dir + "error.jpg");
                    break;
                case "Warning":
                    MessageBoxIconField.Image = new Bitmap(Dir + "warning.jpg");
                    break;
                case "Confirm Run":
                    MessageBoxIconField.Image = new Bitmap(Dir + "confirm.jpg");
                    break;
                case "Champollion Error":
                    MessageBoxIconField.Image = new Bitmap(Dir + "champ_error.jpg");
                    break;
                case "Champollion Run Complete":
                    MessageBoxIconField.Image = new Bitmap(Dir + "finished.jpg");
                    break;
                case "About":
                    MessageBoxIconField.Image = new Bitmap(Dir + "about.jpg");
                    break;
                default:
                    MessageBoxIconField.Image = null;
                    break;
            }
        }

        private void WireEvents()
        {
            ButtonOk.Click += new EventHandler(this.ButtonOk_Click);
            ButtonCancel.Click += new EventHandler(this.ButtonCancel_Click);
        }

        private void UnWireEvents()
        {
            ButtonOk.Click -= new EventHandler(this.ButtonOk_Click);
            ButtonCancel.Click -= new EventHandler(this.ButtonCancel_Click);
        }

        private void ButtonCancel_Click(Object? Sender, EventArgs EA)
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
            _ = new EventHandler(this.ButtonCancel_Click);
            FCEA.Cancel = true;
        }

        private void ButtonOk_Click(Object? Sender, EventArgs EA)
        {
            this.UnWireEvents();
            this.DialogResult = DialogResult.OK;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && Components != null)
            {
                Components.Dispose();
            }
            base.Dispose(disposing);
        }

        private int CountLines(String Text)
        {
            if (String.IsNullOrEmpty(Text))
            {
                return 0;
            }

            int lineCount = 1;
            foreach (char c in Text)
            {
                if (c == '\n')
                {
                    lineCount++;
                }
            }
            return lineCount;
        }
    }
}
