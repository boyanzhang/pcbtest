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
        private FormZuheban formZuheban;
        private FormZhengji formZhengji;
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

        private void button4_Click(object sender, EventArgs e)
        {
            //this.Close();
           // new Thread(() => Application.Run(new FormZuheban())).Start();
            formZuheban = new FormZuheban();
            formZuheban.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
           // this.Close();
           //new Thread(() => Application.Run(new FormZhengji())).Start();
            formZhengji = new FormZhengji();
            formZhengji.Show();
        }
    }
}
