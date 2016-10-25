namespace TaskWeek1
{
    partial class FormPass
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
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_PassWord = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.changePasswordButton = new System.Windows.Forms.Button();
            this.textBox_ID = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.passwordPanel = new System.Windows.Forms.Panel();
            this.changePasswordPanel = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.returnButton = new System.Windows.Forms.Button();
            this.changePasswordLabel = new System.Windows.Forms.Label();
            this.changePasswordNewTextbox = new System.Windows.Forms.TextBox();
            this.changePasswordIDTextbox = new System.Windows.Forms.TextBox();
            this.changeOKButton = new System.Windows.Forms.Button();
            this.changePasswordOldTextbox = new System.Windows.Forms.TextBox();
            this.passwordPanel.SuspendLayout();
            this.changePasswordPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.button2.Location = new System.Drawing.Point(206, 124);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(81, 27);
            this.button2.TabIndex = 5;
            this.button2.Text = "退出";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.closeClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(28, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(240, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "请输入资源配置权限密码";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(28, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "提示：";
            // 
            // textBox_PassWord
            // 
            this.textBox_PassWord.Location = new System.Drawing.Point(91, 98);
            this.textBox_PassWord.Name = "textBox_PassWord";
            this.textBox_PassWord.Size = new System.Drawing.Size(118, 21);
            this.textBox_PassWord.TabIndex = 2;
            this.textBox_PassWord.UseSystemPasswordChar = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.button1.Location = new System.Drawing.Point(10, 124);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 27);
            this.button1.TabIndex = 3;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.loginClicked);
            // 
            // changePasswordButton
            // 
            this.changePasswordButton.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.changePasswordButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.changePasswordButton.Location = new System.Drawing.Point(101, 124);
            this.changePasswordButton.Name = "changePasswordButton";
            this.changePasswordButton.Size = new System.Drawing.Size(99, 27);
            this.changePasswordButton.TabIndex = 4;
            this.changePasswordButton.Text = "修改密码";
            this.changePasswordButton.UseVisualStyleBackColor = true;
            this.changePasswordButton.Click += new System.EventHandler(this.changePasswordButton_Click);
            // 
            // textBox_ID
            // 
            this.textBox_ID.Location = new System.Drawing.Point(91, 55);
            this.textBox_ID.Name = "textBox_ID";
            this.textBox_ID.Size = new System.Drawing.Size(118, 21);
            this.textBox_ID.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::TaskWeek1.Properties.Resources.ID;
            this.panel2.Location = new System.Drawing.Point(62, 52);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(24, 24);
            this.panel2.TabIndex = 13;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::TaskWeek1.Properties.Resources._20150601073650399_easyicon_net_24;
            this.panel1.Location = new System.Drawing.Point(62, 96);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(24, 24);
            this.panel1.TabIndex = 10;
            // 
            // passwordPanel
            // 
            this.passwordPanel.Controls.Add(this.panel2);
            this.passwordPanel.Controls.Add(this.button2);
            this.passwordPanel.Controls.Add(this.textBox_ID);
            this.passwordPanel.Controls.Add(this.changePasswordButton);
            this.passwordPanel.Controls.Add(this.panel1);
            this.passwordPanel.Controls.Add(this.button1);
            this.passwordPanel.Controls.Add(this.textBox_PassWord);
            this.passwordPanel.Controls.Add(this.label2);
            this.passwordPanel.Controls.Add(this.label1);
            this.passwordPanel.Location = new System.Drawing.Point(-2, 3);
            this.passwordPanel.Name = "passwordPanel";
            this.passwordPanel.Size = new System.Drawing.Size(298, 215);
            this.passwordPanel.TabIndex = 14;
            // 
            // changePasswordPanel
            // 
            this.changePasswordPanel.Controls.Add(this.label5);
            this.changePasswordPanel.Controls.Add(this.label4);
            this.changePasswordPanel.Controls.Add(this.label3);
            this.changePasswordPanel.Controls.Add(this.returnButton);
            this.changePasswordPanel.Controls.Add(this.changePasswordLabel);
            this.changePasswordPanel.Controls.Add(this.changePasswordNewTextbox);
            this.changePasswordPanel.Controls.Add(this.changePasswordIDTextbox);
            this.changePasswordPanel.Controls.Add(this.changeOKButton);
            this.changePasswordPanel.Controls.Add(this.changePasswordOldTextbox);
            this.changePasswordPanel.Location = new System.Drawing.Point(1, 3);
            this.changePasswordPanel.Name = "changePasswordPanel";
            this.changePasswordPanel.Size = new System.Drawing.Size(292, 212);
            this.changePasswordPanel.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label5.Location = new System.Drawing.Point(20, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "新密码";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label4.Location = new System.Drawing.Point(20, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "旧密码";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label3.Location = new System.Drawing.Point(20, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "用户名";
            // 
            // returnButton
            // 
            this.returnButton.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.returnButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.returnButton.Location = new System.Drawing.Point(156, 145);
            this.returnButton.Name = "returnButton";
            this.returnButton.Size = new System.Drawing.Size(99, 27);
            this.returnButton.TabIndex = 10;
            this.returnButton.Text = "返回";
            this.returnButton.UseVisualStyleBackColor = true;
            this.returnButton.Click += new System.EventHandler(this.returnButton_Click);
            // 
            // changePasswordLabel
            // 
            this.changePasswordLabel.AutoSize = true;
            this.changePasswordLabel.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.changePasswordLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.changePasswordLabel.Location = new System.Drawing.Point(20, 185);
            this.changePasswordLabel.Name = "changePasswordLabel";
            this.changePasswordLabel.Size = new System.Drawing.Size(72, 20);
            this.changePasswordLabel.TabIndex = 9;
            this.changePasswordLabel.Text = "提示：";
            // 
            // changePasswordNewTextbox
            // 
            this.changePasswordNewTextbox.Location = new System.Drawing.Point(117, 109);
            this.changePasswordNewTextbox.Name = "changePasswordNewTextbox";
            this.changePasswordNewTextbox.Size = new System.Drawing.Size(118, 21);
            this.changePasswordNewTextbox.TabIndex = 8;
            this.changePasswordNewTextbox.UseSystemPasswordChar = true;
            // 
            // changePasswordIDTextbox
            // 
            this.changePasswordIDTextbox.Location = new System.Drawing.Point(117, 28);
            this.changePasswordIDTextbox.Name = "changePasswordIDTextbox";
            this.changePasswordIDTextbox.Size = new System.Drawing.Size(118, 21);
            this.changePasswordIDTextbox.TabIndex = 5;
            // 
            // changeOKButton
            // 
            this.changeOKButton.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.changeOKButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.changeOKButton.Location = new System.Drawing.Point(29, 145);
            this.changeOKButton.Name = "changeOKButton";
            this.changeOKButton.Size = new System.Drawing.Size(99, 27);
            this.changeOKButton.TabIndex = 7;
            this.changeOKButton.Text = "确定";
            this.changeOKButton.UseVisualStyleBackColor = true;
            this.changeOKButton.Click += new System.EventHandler(this.changeOKButton_Click);
            // 
            // changePasswordOldTextbox
            // 
            this.changePasswordOldTextbox.Location = new System.Drawing.Point(117, 71);
            this.changePasswordOldTextbox.Name = "changePasswordOldTextbox";
            this.changePasswordOldTextbox.Size = new System.Drawing.Size(118, 21);
            this.changePasswordOldTextbox.TabIndex = 6;
            this.changePasswordOldTextbox.UseSystemPasswordChar = true;
            // 
            // FormPass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 217);
            this.Controls.Add(this.passwordPanel);
            this.Controls.Add(this.changePasswordPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormPass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.passwordPanel.ResumeLayout(false);
            this.passwordPanel.PerformLayout();
            this.changePasswordPanel.ResumeLayout(false);
            this.changePasswordPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_PassWord;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button changePasswordButton;
        private System.Windows.Forms.TextBox textBox_ID;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel passwordPanel;
        private System.Windows.Forms.Panel changePasswordPanel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button returnButton;
        private System.Windows.Forms.Label changePasswordLabel;
        private System.Windows.Forms.TextBox changePasswordNewTextbox;
        private System.Windows.Forms.TextBox changePasswordIDTextbox;
        private System.Windows.Forms.Button changeOKButton;
        private System.Windows.Forms.TextBox changePasswordOldTextbox;
    }
}