using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace TaskWeek1
{
    public partial class FormSelect : Form
    {
        private FormStart paForm;
        private FormTest formTest;
        private FormLaolian formLaolian;
        public FormSelect(FormStart parent)
        {
            InitializeComponent();
            paForm = parent;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
            paForm.Close();
           
        }

        private void FormSelect_Load(object sender, EventArgs e)
        {
            label1.BackColor = Color.Transparent;
            //this.Close();
        }

        private void SelectForm_Click(object sender, EventArgs e)
        {
            //this.Close();
           // new Thread(() => Application.Run(new FormZuheban())).Start();
            Button selectButton = sender as Button;
            switch (selectButton.Name)
            {
                case "GonglvButton":
                    formTest = new FormTest("Gonglv");
                    break;
                case "KongzhiButton":
                    formTest = new FormTest("Kongzhi");
                    break;
                case "ZongheButton":
                    formTest = new FormTest("Zonghe");
                    break;
                case "ZuheButton":
                    formTest = new FormTest("Zuhe");
                    break;     
                case "ZhengjiButton":
                    formTest = new FormTest("Zhengji");
                    break;
            }
            formTest.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            formLaolian = new FormLaolian();
            formLaolian.Show();
        }
    }
}
