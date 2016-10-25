using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace TaskWeek1
{
    public partial class FormZhengjiPeizhi : Form
    {
        private List<string> checkList = new List<string>();
        private string strOut;
        FormZhengji formZhengji;
        public FormZhengjiPeizhi()
        {
            InitializeComponent();
        }

        private void CheckResult()
        {   //16个IO输出配置选择
            if (skinCheckBox1.Checked) { checkList.Add("IO_OUT1"); }
            if (skinCheckBox2.Checked) { checkList.Add("IO_OUT2"); }
            if (skinCheckBox3.Checked) { checkList.Add("IO_OUT3"); }
            if (skinCheckBox4.Checked) { checkList.Add("IO_OUT4"); }
            if (skinCheckBox5.Checked) { checkList.Add("IO_OUT5"); }
            if (skinCheckBox6.Checked) { checkList.Add("IO_OUT6"); }
            if (skinCheckBox7.Checked) { checkList.Add("IO_OUT7"); }
            if (skinCheckBox8.Checked) { checkList.Add("IO_OUT8"); }
            if (skinCheckBox9.Checked) { checkList.Add("IO_OUT9"); }
            if (skinCheckBox10.Checked) { checkList.Add("IO_OUT10"); }
            if (skinCheckBox11.Checked) { checkList.Add("IO_OUT11"); }
            if (skinCheckBox12.Checked) { checkList.Add("IO_OUT12"); }
            if (skinCheckBox13.Checked) { checkList.Add("IO_OUT13"); }
            if (skinCheckBox14.Checked) { checkList.Add("IO_OUT14"); }
            if (skinCheckBox15.Checked) { checkList.Add("IO_OUT15"); }
            if (skinCheckBox16.Checked) { checkList.Add("IO_OUT16"); }
            //IOIN
            if (skinCheckBox17.Checked) { checkList.Add("IO_IN1"); }
            if (skinCheckBox18.Checked) { checkList.Add("IO_IN2"); }
            if (skinCheckBox19.Checked) { checkList.Add("IO_IN3"); }
            if (skinCheckBox20.Checked) { checkList.Add("IO_IN4"); }
            if (skinCheckBox22.Checked) { checkList.Add("IO_IN5"); }
            if (skinCheckBox22.Checked) { checkList.Add("IO_IN6"); }
            if (skinCheckBox23.Checked) { checkList.Add("IO_IN7"); }
            if (skinCheckBox24.Checked) { checkList.Add("IO_IN8"); }
            if (skinCheckBox25.Checked) { checkList.Add("IO_IN9"); }
            if (skinCheckBox26.Checked) { checkList.Add("IO_IN10"); }
            if (skinCheckBox27.Checked) { checkList.Add("IO_IN11"); }
            if (skinCheckBox28.Checked) { checkList.Add("IO_IN12"); }
            if (skinCheckBox29.Checked) { checkList.Add("IO_IN13"); }
            if (skinCheckBox30.Checked) { checkList.Add("IO_OUT14"); }
            if (skinCheckBox31.Checked) { checkList.Add("IO_OUT15"); }
            if (skinCheckBox32.Checked) { checkList.Add("IO_OUT16"); }
            //D/A资源配置
            if (skinCheckBox33.Checked) { checkList.Add("DA1"); }
            if (skinCheckBox34.Checked) { checkList.Add("DA2"); }
            if (skinCheckBox35.Checked) { checkList.Add("DA3"); }
            if (skinCheckBox36.Checked) { checkList.Add("DA4"); }
            if (skinCheckBox37.Checked) { checkList.Add("DA5"); }
            if (skinCheckBox38.Checked) { checkList.Add("DA6"); }
            if (skinCheckBox39.Checked) { checkList.Add("DA7"); }
            if (skinCheckBox40.Checked) { checkList.Add("DA8"); }
            //A/D资源配置
            if (skinCheckBox41.Checked) { checkList.Add("AD1"); }
            if (skinCheckBox42.Checked) { checkList.Add("AD2"); }
            if (skinCheckBox43.Checked) { checkList.Add("AD3"); }
            if (skinCheckBox44.Checked) { checkList.Add("AD4"); }
            if (skinCheckBox45.Checked) { checkList.Add("AD5"); }
            if (skinCheckBox46.Checked) { checkList.Add("AD6"); }
            if (skinCheckBox47.Checked) { checkList.Add("AD7"); }
            if (skinCheckBox48.Checked) { checkList.Add("AD8"); }
            if (skinCheckBox49.Checked) { checkList.Add("AD9"); }
            if (skinCheckBox50.Checked) { checkList.Add("AD10"); }
            if (skinCheckBox51.Checked) { checkList.Add("AD11"); }
            if (skinCheckBox52.Checked) { checkList.Add("AD12"); }
            if (skinCheckBox53.Checked) { checkList.Add("AD13"); }
            if (skinCheckBox54.Checked) { checkList.Add("AD14"); }
            if (skinCheckBox55.Checked) { checkList.Add("AD15"); }
            if (skinCheckBox56.Checked) { checkList.Add("AD16"); }
            if (skinCheckBox57.Checked) { checkList.Add("AD17"); }
            if (skinCheckBox58.Checked) { checkList.Add("AD18"); }
            if (skinCheckBox59.Checked) { checkList.Add("AD19"); }
            if (skinCheckBox60.Checked) { checkList.Add("AD20"); }
            if (skinCheckBox61.Checked) { checkList.Add("AD21"); }
            if (skinCheckBox62.Checked) { checkList.Add("AD22"); }
            if (skinCheckBox63.Checked) { checkList.Add("AD23"); }
            if (skinCheckBox64.Checked) { checkList.Add("AD24"); }
            if (skinCheckBox65.Checked) { checkList.Add("AD25"); }
            if (skinCheckBox66.Checked) { checkList.Add("AD26"); }
            strOut = string.Join(",", checkList.ToArray());

        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            formZhengji = new FormZhengji();
            formZhengji.Show();
            // new Thread(() => Application.Run(new FormZhengji())).Start();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter checkOut = new StreamWriter(saveFileDialog1.FileName))
                {
                    CheckResult();
                    checkOut.WriteLine("Zhengji");
                    checkOut.WriteLine(strOut);
                    checkOut.Flush();
                    checkOut.Dispose();
                }

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            skinCheckBox1.Checked = true;
            skinCheckBox2.Checked = true;
            skinCheckBox3.Checked = true;
            skinCheckBox4.Checked = true;
            skinCheckBox5.Checked = true;
            skinCheckBox6.Checked = true;
            skinCheckBox7.Checked = true;
            skinCheckBox8.Checked = true;
            skinCheckBox9.Checked = true;
            skinCheckBox10.Checked = true;
            skinCheckBox11.Checked = true;
            skinCheckBox12.Checked = true;
            skinCheckBox13.Checked = true;
            skinCheckBox14.Checked = true;
            skinCheckBox15.Checked = true;
            skinCheckBox16.Checked = true;
            skinCheckBox17.Checked = true;
            skinCheckBox18.Checked = true;
            skinCheckBox19.Checked = true;
            skinCheckBox20.Checked = true;
            skinCheckBox21.Checked = true;
            skinCheckBox22.Checked = true;
            skinCheckBox23.Checked = true;
            skinCheckBox24.Checked = true;
            skinCheckBox25.Checked = true;
            skinCheckBox26.Checked = true;
            skinCheckBox27.Checked = true;
            skinCheckBox28.Checked = true;
            skinCheckBox29.Checked = true;
            skinCheckBox30.Checked = true;
            skinCheckBox31.Checked = true;
            skinCheckBox32.Checked = true;
            skinCheckBox33.Checked = true;
            skinCheckBox34.Checked = true;
            skinCheckBox35.Checked = true;
            skinCheckBox36.Checked = true;
            skinCheckBox37.Checked = true;
            skinCheckBox38.Checked = true;
            skinCheckBox39.Checked = true;
            skinCheckBox40.Checked = true;
            skinCheckBox41.Checked = true;
            skinCheckBox42.Checked = true;
            skinCheckBox43.Checked = true;
            skinCheckBox44.Checked = true;
            skinCheckBox45.Checked = true;
            skinCheckBox46.Checked = true;
            skinCheckBox47.Checked = true;
            skinCheckBox48.Checked = true;
            skinCheckBox49.Checked = true;
            skinCheckBox50.Checked = true;
            skinCheckBox51.Checked = true;
            skinCheckBox52.Checked = true;
            skinCheckBox53.Checked = true;
            skinCheckBox54.Checked = true;
            skinCheckBox55.Checked = true;
            skinCheckBox56.Checked = true;
            skinCheckBox57.Checked = true;
            skinCheckBox58.Checked = true;
            skinCheckBox59.Checked = true;
            skinCheckBox60.Checked = true;
            skinCheckBox61.Checked = true;
            skinCheckBox62.Checked = true;
            skinCheckBox63.Checked = true;
            skinCheckBox64.Checked = true;
            skinCheckBox65.Checked = true;
            skinCheckBox66.Checked = true;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            skinCheckBox1.Checked = false;
            skinCheckBox2.Checked = false;
            skinCheckBox3.Checked = false;
            skinCheckBox4.Checked = false;
            skinCheckBox5.Checked = false;
            skinCheckBox6.Checked = false;
            skinCheckBox7.Checked = false;
            skinCheckBox8.Checked = false;
            skinCheckBox9.Checked = false;
            skinCheckBox10.Checked = false;
            skinCheckBox11.Checked = false;
            skinCheckBox12.Checked = false;
            skinCheckBox13.Checked = false;
            skinCheckBox14.Checked = false;
            skinCheckBox15.Checked = false;
            skinCheckBox16.Checked = false;
            skinCheckBox17.Checked = false;
            skinCheckBox18.Checked = false;
            skinCheckBox19.Checked = false;
            skinCheckBox20.Checked = false;
            skinCheckBox21.Checked = false;
            skinCheckBox22.Checked = false;
            skinCheckBox23.Checked = false;
            skinCheckBox24.Checked = false;
            skinCheckBox25.Checked = false;
            skinCheckBox26.Checked = false;
            skinCheckBox27.Checked = false;
            skinCheckBox28.Checked = false;
            skinCheckBox29.Checked = false;
            skinCheckBox30.Checked = false;
            skinCheckBox31.Checked = false;
            skinCheckBox32.Checked = false;
            skinCheckBox33.Checked = false;
            skinCheckBox34.Checked = false;
            skinCheckBox35.Checked = false;
            skinCheckBox36.Checked = false;
            skinCheckBox37.Checked = false;
            skinCheckBox38.Checked = false;
            skinCheckBox39.Checked = false;
            skinCheckBox40.Checked = false;
            skinCheckBox41.Checked = false;
            skinCheckBox42.Checked = false;
            skinCheckBox43.Checked = false;
            skinCheckBox44.Checked = false;
            skinCheckBox45.Checked = false;
            skinCheckBox46.Checked = false;
            skinCheckBox47.Checked = false;
            skinCheckBox48.Checked = false;
            skinCheckBox49.Checked = false;
            skinCheckBox50.Checked = false;
            skinCheckBox51.Checked = false;
            skinCheckBox52.Checked = false;
            skinCheckBox53.Checked = false;
            skinCheckBox54.Checked = false;
            skinCheckBox55.Checked = false;
            skinCheckBox56.Checked = false;
            skinCheckBox57.Checked = false;
            skinCheckBox58.Checked = false;
            skinCheckBox59.Checked = false;
            skinCheckBox60.Checked = false;
            skinCheckBox61.Checked = false;
            skinCheckBox62.Checked = false;
            skinCheckBox63.Checked = false;
            skinCheckBox64.Checked = false;
            skinCheckBox65.Checked = false;
            skinCheckBox66.Checked = false;
        }

    }       
}
