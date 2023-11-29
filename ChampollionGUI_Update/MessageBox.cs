using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ChampollionGUI_Update
{
    public class MessageBox : Form
    {
        private IContainer components;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnOk;
        private PictureBox msgBoxIconField;
        private Button btnCancel;

        public MessageBox() => this.InitializeComponent();

        public MessageBox(String title, String message, bool showCancel) : this()
        {
            this.Text = title;
            label1.Text = message;
            if (!showCancel)
            {
                btnCancel.Visible = false;
            }
            else
            {
                btnOk.Text = "Yes";
                btnCancel.Text = "No";
            }
            iconSelect(title);
            this.WireEvents();
        }

        private void iconSelect(String title)
        {
            String Dir = Directory.GetCurrentDirectory() + @"\images\";
            switch (title)
            {
                case "Run Error":
                    msgBoxIconField.Image = new Bitmap(Dir+"error.jpg");
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.UnWireEvents();
            this.DialogResult = DialogResult.Cancel;
        }

        //Adds check to see if the user if a wierdo and clicks the close (X) button
        //in the corner instead of using the No/Cancel button like a normal human
        private void MessageBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            _ = new EventHandler(this.btnCancel_Click);
            e.Cancel = true;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.UnWireEvents();
            this.DialogResult = DialogResult.OK;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            label1 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnOk = new Button();
            btnCancel = new Button();
            msgBoxIconField = new PictureBox();
            tableLayoutPanel1.SuspendLayout();
            ((ISupportInitialize)msgBoxIconField).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(14, 10);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.MaximumSize = new Size(386, 0);
            label1.Name = "label1";
            label1.Size = new Size(52, 17);
            label1.TabIndex = 0;
            label1.Text = "label1";
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
            Controls.Add(label1);
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
