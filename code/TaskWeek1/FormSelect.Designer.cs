namespace TaskWeek1
{
    partial class FormSelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSelect));
            this.label1 = new System.Windows.Forms.Label();
            this.GonglvButton = new System.Windows.Forms.Button();
            this.KongzhiButton = new System.Windows.Forms.Button();
            this.ZongheButton = new System.Windows.Forms.Button();
            this.ZuheButton = new System.Windows.Forms.Button();
            this.ZhengjiButton = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("黑体", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(272, 211);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 33);
            this.label1.TabIndex = 2;
            this.label1.Text = "请选择测试类型";
            // 
            // GonglvButton
            // 
            this.GonglvButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.GonglvButton.Font = new System.Drawing.Font("黑体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GonglvButton.Location = new System.Drawing.Point(186, 266);
            this.GonglvButton.Name = "GonglvButton";
            this.GonglvButton.Size = new System.Drawing.Size(171, 44);
            this.GonglvButton.TabIndex = 3;
            this.GonglvButton.Text = "功率板测试";
            this.GonglvButton.UseVisualStyleBackColor = false;
            this.GonglvButton.Click += new System.EventHandler(this.SelectForm_Click);
            // 
            // KongzhiButton
            // 
            this.KongzhiButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.KongzhiButton.Font = new System.Drawing.Font("黑体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.KongzhiButton.Location = new System.Drawing.Point(186, 330);
            this.KongzhiButton.Name = "KongzhiButton";
            this.KongzhiButton.Size = new System.Drawing.Size(171, 44);
            this.KongzhiButton.TabIndex = 4;
            this.KongzhiButton.Text = "控制板测试";
            this.KongzhiButton.UseVisualStyleBackColor = false;
            this.KongzhiButton.Click += new System.EventHandler(this.SelectForm_Click);
            // 
            // ZongheButton
            // 
            this.ZongheButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ZongheButton.Font = new System.Drawing.Font("黑体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ZongheButton.Location = new System.Drawing.Point(186, 394);
            this.ZongheButton.Name = "ZongheButton";
            this.ZongheButton.Size = new System.Drawing.Size(171, 44);
            this.ZongheButton.TabIndex = 5;
            this.ZongheButton.Text = "综合板测试";
            this.ZongheButton.UseVisualStyleBackColor = false;
            this.ZongheButton.Click += new System.EventHandler(this.SelectForm_Click);
            // 
            // ZuheButton
            // 
            this.ZuheButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ZuheButton.Font = new System.Drawing.Font("黑体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ZuheButton.Location = new System.Drawing.Point(186, 454);
            this.ZuheButton.Name = "ZuheButton";
            this.ZuheButton.Size = new System.Drawing.Size(171, 44);
            this.ZuheButton.TabIndex = 6;
            this.ZuheButton.Text = "组合板测试";
            this.ZuheButton.UseVisualStyleBackColor = false;
            this.ZuheButton.Click += new System.EventHandler(this.SelectForm_Click);
            // 
            // ZhengjiButton
            // 
            this.ZhengjiButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ZhengjiButton.Font = new System.Drawing.Font("黑体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ZhengjiButton.Location = new System.Drawing.Point(430, 287);
            this.ZhengjiButton.Name = "ZhengjiButton";
            this.ZhengjiButton.Size = new System.Drawing.Size(171, 44);
            this.ZhengjiButton.TabIndex = 7;
            this.ZhengjiButton.Text = "产品整机测试";
            this.ZhengjiButton.UseVisualStyleBackColor = false;
            this.ZhengjiButton.Click += new System.EventHandler(this.SelectForm_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button6.Font = new System.Drawing.Font("黑体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button6.Location = new System.Drawing.Point(430, 349);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(171, 44);
            this.button6.TabIndex = 8;
            this.button6.Text = "产品老炼测试";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button7.Font = new System.Drawing.Font("宋体", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button7.Location = new System.Drawing.Point(604, 487);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(150, 44);
            this.button7.TabIndex = 9;
            this.button7.Text = "*退出系统";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button8.Font = new System.Drawing.Font("黑体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button8.Location = new System.Drawing.Point(430, 415);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(171, 44);
            this.button8.TabIndex = 10;
            this.button8.Text = "产品温循测试";
            this.button8.UseVisualStyleBackColor = false;
            // 
            // FormSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TaskWeek1.Properties.Resources.中国航天;
            this.ClientSize = new System.Drawing.Size(790, 607);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.ZhengjiButton);
            this.Controls.Add(this.ZuheButton);
            this.Controls.Add(this.ZongheButton);
            this.Controls.Add(this.KongzhiButton);
            this.Controls.Add(this.GonglvButton);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.FormSelect_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button GonglvButton;
        private System.Windows.Forms.Button KongzhiButton;
        private System.Windows.Forms.Button ZongheButton;
        private System.Windows.Forms.Button ZuheButton;
        private System.Windows.Forms.Button ZhengjiButton;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
    }
}