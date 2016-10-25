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
    public partial class FormZuheban : Form
    {
        private FormPassZuheban formPassZuheban;
        public FormZuheban()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            formPassZuheban = new FormPassZuheban(this);
            //formpass.MdiParent =this;
            formPassZuheban.WindowState = FormWindowState.Normal;
            formPassZuheban.ShowDialog();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            //new Thread(() => Application.Run(new FormSelect())).Start();
        }
    }
}
