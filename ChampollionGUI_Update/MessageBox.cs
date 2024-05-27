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
            this.InitializeComponent();
        }
#pragma warning restore CS8618

        ///***********************************************************************
        /// <summary>
        /// Instantiates and initializes all the UI elements in the form window,
        /// and applies all the default values to those elements.
        /// </summary>
        ///***********************************************************************
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

        ///************************************************************************
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
        ///************************************************************************
        public MessageBox(String Title, String Message, bool showCancel) : this()
        {
            String MessagePart1 = Message;
            this.Text = Title;

            if(!showCancel)
            {
                ButtonCancel.Visible = false;
            }

            //If the message is longer than 13 lines, the message will be split
            //into two parts, and use two different text boxes, so the entire
            //message will be able to fit properly.
            int lines = CountLines(Message);
            if(lines > 13)
            {
                this.Height = 291 + (15 * (lines - 13));

                String MessagePart2;
                (MessagePart1, MessagePart2) = SplitText(Message);

                LabelMessageBoxText2.Visible = true;
                LabelMessageBoxText2.Text = MessagePart2;
            }

            LabelMessageBoxText.Text = MessagePart1;
            IconSelect(Title);
            this.WireEvents();
        }

        ///************************************************************************
        /// <summary>
        /// The message box can show different icons based on the reason the
        /// message box was created. This method chooses the correct icon to be
        /// displayed.
        /// </summary>
        /// <param name="Title">
        /// This parameter is used to determine the appropriate icon.
        /// </param>
        ///************************************************************************
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

        ///***********************************************************************
        /// <summary>
        /// Adds eventhandlers to the different possible events that can occur/be
        /// fired when using the UI, and ensures the right method is called when 
        /// the user performs some action in the program.
        /// </summary>
        ///***********************************************************************
        private void WireEvents()
        {
            ButtonOk.Click += new EventHandler(this.ButtonOk_Click);
            ButtonCancel.Click += new EventHandler(this.ButtonCancel_Click);
        }

        ///***********************************************************************
        /// <summary>
        /// Does the exact opposite of <see cref="WireEvents"/>, i.e. it removes
        /// the eventhandlers from all the events. Is used when the program is
        /// closed. Is only called by either the <see cref="ButtonCancel_Click"/> or
        /// <see cref="ButtonOk_Click"/>   method.
        /// </summary>
        ///***********************************************************************
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

        ///************************************************************************
        /// <summary>
        /// Called when the user presses the close (red "X") button in the upper 
        /// right corner of the message box, instead of either the OK or Cancel 
        /// buttons. This method cancels the normal process of closing the message
        /// box, and instead calls the <see cref="ButtonCancel_Click"/> method.
        /// </summary>
        ///************************************************************************
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
        /// </param>
        ///***********************************************************************
        protected override void Dispose(bool disposing)
        {
            if(disposing && Components != null)
            {
                Components.Dispose();
            }

            base.Dispose(disposing);
        }

        ///***********************************************************************
        /// <summary>
        /// Counts the number of lines ('\n') in the string passed to the method.
        /// Called by the constructor.
        /// </summary>
        /// <param name="Text">
        /// This is the string in which the number of lines are counted.
        /// </param>
        /// <returns>
        /// Integer value corresponding to the amount of lines ('\n') counted.
        /// </returns>
        ///***********************************************************************
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

        ///***********************************************************************
        /// <summary>
        /// Splits a string of text into two parts, where the first part contains
        /// the first 13 lines of text, and the second part contains the rest.
        /// </summary>
        /// <param name="Text">
        /// This is the string which will be split.
        /// </param>
        /// <returns>
        /// Two strings (String, String) where the first string is the first part
        /// of the splits text, and the second string is the second part.
        /// </returns>
        ///***********************************************************************
        private (String, String) SplitText(String Text)
        {
            String[] Lines = Text.Split(['\n']);

            String Part1 = String.Join("\n", Lines.Take(13));
            String Part2 = String.Join("\n", Lines.Skip(13));
            return (Part1, Part2);
        }
    }
}
