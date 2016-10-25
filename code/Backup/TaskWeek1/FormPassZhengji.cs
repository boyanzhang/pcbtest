using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TaskWeek1
{
    public partial class FormPassZhengji : Form
    {
        FormZhengji paForm;
        FormZhengjiPeizhi formZhengjiPeizhi;
        public FormPassZhengji(FormZhengji parent)
        {

            InitializeComponent();
            paForm = parent; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "123456")
            {
                this.Close();
                paForm.Close();
                formZhengjiPeizhi = new FormZhengjiPeizhi();
                formZhengjiPeizhi.Show();

                //new Thread(() => Application.Run(new FormZuhebanPeizhi())).Start();
            }
            else
                this.label1.Text = "密码错误，请重新输入";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
