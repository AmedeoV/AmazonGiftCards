namespace AmazonGiftCards
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gmailButton = new System.Windows.Forms.Button();
            this.twitterButton = new System.Windows.Forms.Button();
            this.facebookButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(158, 217);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(164, 36);
            this.button1.TabIndex = 0;
            this.button1.Text = "Generate Gift Card";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.insertText_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.BackColor = System.Drawing.SystemColors.Info;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(123, 116);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(43, 17);
            this.radioButton1.TabIndex = 2;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "$10";
            this.radioButton1.UseVisualStyleBackColor = false;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.BackColor = System.Drawing.SystemColors.Info;
            this.radioButton2.Location = new System.Drawing.Point(178, 116);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(43, 17);
            this.radioButton2.TabIndex = 3;
            this.radioButton2.Text = "$20";
            this.radioButton2.UseVisualStyleBackColor = false;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.BackColor = System.Drawing.SystemColors.Info;
            this.radioButton3.Location = new System.Drawing.Point(236, 116);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(43, 17);
            this.radioButton3.TabIndex = 4;
            this.radioButton3.Text = "$50";
            this.radioButton3.UseVisualStyleBackColor = false;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.BackColor = System.Drawing.SystemColors.Info;
            this.radioButton4.Location = new System.Drawing.Point(299, 116);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(49, 17);
            this.radioButton4.TabIndex = 5;
            this.radioButton4.Text = "$100";
            this.radioButton4.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(129, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 31);
            this.label1.TabIndex = 7;
            this.label1.Text = "PLEASE LOGIN!";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Info;
            this.label2.Location = new System.Drawing.Point(93, 270);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(325, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Only for Amazon Employees. Please do not share.";
            // 
            // gmailButton
            // 
            this.gmailButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gmailButton.BackgroundImage")));
            this.gmailButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.gmailButton.Location = new System.Drawing.Point(137, 154);
            this.gmailButton.Name = "gmailButton";
            this.gmailButton.Size = new System.Drawing.Size(57, 36);
            this.gmailButton.TabIndex = 9;
            this.gmailButton.UseVisualStyleBackColor = true;
            this.gmailButton.Click += new System.EventHandler(this.gmail_btn);
            // 
            // twitterButton
            // 
            this.twitterButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("twitterButton.BackgroundImage")));
            this.twitterButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.twitterButton.Location = new System.Drawing.Point(209, 154);
            this.twitterButton.Name = "twitterButton";
            this.twitterButton.Size = new System.Drawing.Size(57, 36);
            this.twitterButton.TabIndex = 10;
            this.twitterButton.UseVisualStyleBackColor = true;
            this.twitterButton.Click += new System.EventHandler(this.twitterButton_Click);
            // 
            // facebookButton
            // 
            this.facebookButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("facebookButton.BackgroundImage")));
            this.facebookButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.facebookButton.Location = new System.Drawing.Point(281, 154);
            this.facebookButton.Name = "facebookButton";
            this.facebookButton.Size = new System.Drawing.Size(57, 36);
            this.facebookButton.TabIndex = 11;
            this.facebookButton.UseVisualStyleBackColor = true;
            this.facebookButton.Click += new System.EventHandler(this.facebookButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(145, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Gmail";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(216, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Twitter";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(278, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "Facebook";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.BackgroundImage = global::AmazonGiftCards.Properties.Resources.Amazon;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(483, 309);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.facebookButton);
            this.Controls.Add(this.twitterButton);
            this.Controls.Add(this.gmailButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radioButton4);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.button1);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Amazon Gift Cards";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button gmailButton;
        private System.Windows.Forms.Button twitterButton;
        private System.Windows.Forms.Button facebookButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

