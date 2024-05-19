using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ChampollionGUI_Update
{
    public class MessageBox : Form
    {
#pragma warning disable CS0649 // Field 'MessageBox.Components' is never assigned to, and will always have its default value null
        private IContainer Components;
#pragma warning restore CS0649 // Field 'MessageBox.Components' is never assigned to, and will always have its default value null
        private Label LabelMessageBoxText;
        private Button ButtonOk;
        private PictureBox MessageBoxIconField;
        private Label LabelMessageBoxText2;
        private Button ButtonCancel;

        //private readonly Font FontDefault = 

#pragma warning disable CS8618

        public MessageBox()
        {
            //this.FontDefault
            this.InitializeComponent();
        }
#pragma warning restore CS8618

        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(MessageBox));
            LabelMessageBoxText = new Label();
            ButtonOk = new Button();
            ButtonCancel = new Button();
            MessageBoxIconField = new PictureBox();
            LabelMessageBoxText2 = new Label();
            ((ISupportInitialize)MessageBoxIconField).BeginInit();
            SuspendLayout();
            // 
            // LabelMessageBoxText
            // 
            LabelMessageBoxText.AutoSize = true;
            LabelMessageBoxText.Font = new Font("Consolas", 9F);
            LabelMessageBoxText.Location = new Point(14, 9);
            LabelMessageBoxText.Margin = new Padding(4, 0, 4, 0);
            LabelMessageBoxText.MaximumSize = new Size(462, 0);
            LabelMessageBoxText.Name = "LabelMessageBoxText";
            LabelMessageBoxText.Size = new Size(462, 84);
            LabelMessageBoxText.TabIndex = 0;
            LabelMessageBoxText.Text = resources.GetString("LabelMessageBoxText.Text");
            // 
            // ButtonOk
            // 
            ButtonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ButtonOk.Location = new Point(463, 201);
            ButtonOk.Margin = new Padding(4, 3, 4, 3);
            ButtonOk.Name = "ButtonOk";
            ButtonOk.Size = new Size(87, 23);
            ButtonOk.TabIndex = 0;
            ButtonOk.Text = "OK";
            ButtonOk.UseVisualStyleBackColor = true;
            // 
            // ButtonCancel
            // 
            ButtonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ButtonCancel.Location = new Point(568, 201);
            ButtonCancel.Margin = new Padding(4, 3, 4, 3);
            ButtonCancel.Name = "ButtonCancel";
            ButtonCancel.Size = new Size(87, 23);
            ButtonCancel.TabIndex = 1;
            ButtonCancel.Text = "Cancel";
            ButtonCancel.UseVisualStyleBackColor = true;
            // 
            // MessageBoxIconField
            // 
            MessageBoxIconField.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            MessageBoxIconField.Location = new Point(486, 9);
            MessageBoxIconField.Name = "MessageBoxIconField";
            MessageBoxIconField.Size = new Size(190, 177);
            MessageBoxIconField.TabIndex = 2;
            MessageBoxIconField.TabStop = false;
            // 
            // LabelMessageBoxText2
            // 
            LabelMessageBoxText2.AutoSize = true;
            LabelMessageBoxText2.Font = new Font("Consolas", 9F);
            LabelMessageBoxText2.Location = new Point(14, 189);
            LabelMessageBoxText2.Margin = new Padding(4, 0, 4, 0);
            LabelMessageBoxText2.MaximumSize = new Size(664, 0);
            LabelMessageBoxText2.Name = "LabelMessageBoxText2";
            LabelMessageBoxText2.Size = new Size(658, 56);
            LabelMessageBoxText2.TabIndex = 3;
            LabelMessageBoxText2.Text = resources.GetString("LabelMessageBoxText2.Text");
            LabelMessageBoxText2.Visible = false;
            // 
            // MessageBox
            // 
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(688, 235);
            Controls.Add(LabelMessageBoxText2);
            Controls.Add(ButtonCancel);
            Controls.Add(ButtonOk);
            Controls.Add(MessageBoxIconField);
            Controls.Add(LabelMessageBoxText);
            Font = new Font("Consolas", 9F);
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
            String MessagePart1 = Message;
            String MessagePart2 = "";
            
            this.Text = Title;
            
            if(!showCancel)
            {
                ButtonCancel.Visible = false;
            }

            int lines = CountLines(Message);
            if(lines > 13)
            {
                this.Height = 291 + (15 * (lines - 13));

                (MessagePart1, MessagePart2) = SplitText(Message);

                LabelMessageBoxText2.Visible = true;
                LabelMessageBoxText2.Text = MessagePart2;
            }

            LabelMessageBoxText.Text = MessagePart1;
            IconSelect(Title);
            this.WireEvents();
        }

        private void IconSelect(String Title)
        {
            switch(Title)
            {
                case "Run Error":
                    MessageBoxIconField.Image = new Bitmap(Properties.ImageResources.error);
                    break;
                case "Warning":
                    MessageBoxIconField.Image = new Bitmap(Properties.ImageResources.warning);
                    break;
                case "Confirm Run":
                    MessageBoxIconField.Image = new Bitmap(Properties.ImageResources.confirm);
                    break;
                case "Champollion Error":
                    MessageBoxIconField.Image = new Bitmap(Properties.ImageResources.champ_error);
                    break;
                case "Champollion Run Complete":
                    MessageBoxIconField.Image = new Bitmap(Properties.ImageResources.finished);
                    break;
                case "Settings":
                    MessageBoxIconField.Image = new Bitmap(Properties.ImageResources.settings);
                    break;
                case "Help":
                    MessageBoxIconField.Image = new Bitmap(Properties.ImageResources.help);
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
            if(disposing && Components != null)
            {
                Components.Dispose();
            }

            base.Dispose(disposing);
        }

        private int CountLines(String Text)
        {
            if(String.IsNullOrEmpty(Text))
            {
                return 0;
            }

            /*
            int lineCount = 1;
            foreach (char c in Text)
            {
                if (c == '\n')
                {
                    lineCount++;
                }
            }
            */
            int lineCount = Text.Split('\n').Length;
            return lineCount;
        }

        private (String, String) SplitText(String Text)
        {
            String[] Lines = Text.Split(['\n']);

            String Part1 = String.Join("\n", Lines.Take(13));
            String Part2 = String.Join("\n", Lines.Skip(13));
            return (Part1, Part2);
        }
    }
}
