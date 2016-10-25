using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using WordPlay = TaskWeek1.WordPlayer;

namespace TaskWeek1
{
    public partial class FormZhengji : Form
    {
        private FormPassZhengji formPassZhengji;
        private DataGridViewCellStyle m_RowStyleNormal;
        private DataGridViewCellStyle m_RowStyleAlternate;
        private DataTable checkListChoose, checkListAll;//测试表格，选择和所有
        private DataTable wordSheet1, wordSheet2, wordSheet3, wordSheet4;//word报表
        private byte checkFlag = 0;//0x00 表示自动测试；0x01短路测试；0x02电压输入测试；0x03 IO输出测试；0x04IO输入测试；0x05DA测试；0x06AD测试；

        public FormZhengji()
        {
            InitializeComponent();
        }
        private void SetRowStyle(DataGridView dataGridView)//设置表格属性
        {
            //可根据需要设置更多样式属性，如字体、对齐、前景色、背景色等
            this.m_RowStyleNormal = new DataGridViewCellStyle();
            this.m_RowStyleNormal.ForeColor = Color.Black;
            this.m_RowStyleNormal.BackColor = Color.LightBlue;
            this.m_RowStyleNormal.SelectionBackColor = Color.LightSteelBlue;
            this.m_RowStyleNormal.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.m_RowStyleNormal.Font = new Font("宋体", 10);
            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                dataGridView.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dataGridView.Columns[0].Width = 170;
            dataGridView.Columns[1].Width = 80;
            dataGridView.Columns[2].Width = 80;
            dataGridView.Columns[3].Width = 80;
            dataGridView.RowHeadersWidth = 50;
            //dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            try
            {
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                    dataGridView.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("请先正确读取配置文件", "Warning");
            }
            dataGridView.DefaultCellStyle = this.m_RowStyleNormal;

            this.m_RowStyleAlternate = new DataGridViewCellStyle();
            this.m_RowStyleAlternate.ForeColor = Color.Blue;
            this.m_RowStyleAlternate.BackColor = Color.White;
            this.m_RowStyleAlternate.Font = new Font("黑体", 12);
            this.m_RowStyleAlternate.SelectionBackColor = Color.LightSlateGray;
            this.m_RowStyleAlternate.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.ColumnHeadersDefaultCellStyle = this.m_RowStyleAlternate;
        }
        private void InsetCell(int row, int column, string str, DataGridView dataGrid, DataTable table)//插入一个数据
        {
            table.Rows[row][column] = str;
            dataGrid.DataSource = table;
            for (int i = 0; i < dataGrid.Rows.Count; i++)
                dataGrid.Rows[i].HeaderCell.Value = (i + 1).ToString();
            // dataGrid.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            formPassZhengji = new FormPassZhengji(this);
            //formpass.MdiParent =this;
            formPassZhengji.WindowState = FormWindowState.Normal;
            formPassZhengji.ShowDialog();
           // new Thread(() => Application.Run(new FormZhengjiPeizhi())).Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileStream filest = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.ReadWrite);
                    StreamReader checkIn = new StreamReader(filest);
                    string strIn = checkIn.ReadLine();
                    if (strIn != "Zhengji")
                    {
                        MessageBox.Show("配置文件错误，请检测");
                        return;
                    }
                    strIn = checkIn.ReadLine();
                    checkListChoose = new DataTable();
                    checkListChoose.Columns.Add("检测内容");
                    checkListChoose.Columns.Add("理论值");
                    checkListChoose.Columns.Add("实际值");
                    checkListChoose.Columns.Add("结果");
                    for (int i = 0; i < 7; i++)
                    {
                        DataRow newRow = checkListChoose.NewRow();
                        newRow[0] = checkListAll.Rows[i][0];
                        newRow[1] = checkListAll.Rows[i][1];
                        newRow[2] = "";
                        newRow[3] = "";
                        checkListChoose.Rows.Add(newRow);
                    }
                    for (int i = 0; i < FileRead.DealFile(strIn); i++)
                    {
                        DataRow newRow = checkListChoose.NewRow();
                        newRow[0] = checkListAll.Rows[FileRead.intCheckList[i] + 6][0];
                        newRow[1] = checkListAll.Rows[FileRead.intCheckList[i] + 6][1];
                        newRow[2] = "";
                        newRow[3] = "";
                        checkListChoose.Rows.Add(newRow);
                    }
                    checkIn.Close();
                    filest.Close();
                    MessageBox.Show("配置文件读取完毕", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show("文件打开错误", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FormZhengji_Load(object sender, EventArgs e)
        {
            checkListAll = new DataTable();
            checkListAll.Columns.Add("检测内容");
            checkListAll.Columns.Add("理论值");

            checkListAll.Rows.Add("短路测试-1", "绝缘");
            checkListAll.Rows.Add("短路测试-2", "绝缘");
            checkListAll.Rows.Add("短路测试-3", "绝缘");
            checkListAll.Rows.Add("短路测试-4", "绝缘");
            checkListAll.Rows.Add("短路测试-5", "绝缘");
            checkListAll.Rows.Add("短路测试-6", "绝缘");
            checkListAll.Rows.Add("短路测试-7", "绝缘");

            checkListAll.Rows.Add("IO输出口-1", "+24V");
            checkListAll.Rows.Add("IO输出口-2", "+24V");
            checkListAll.Rows.Add("IO输出口-3", "+24V");
            checkListAll.Rows.Add("IO输出口-4", "+24V");
            checkListAll.Rows.Add("IO输出口-5", "+24V");
            checkListAll.Rows.Add("IO输出口-6", "+24V");
            checkListAll.Rows.Add("IO输出口-7", "+24V");
            checkListAll.Rows.Add("IO输出口-8", "+24V");
            checkListAll.Rows.Add("IO输出口-9", "+24V");
            checkListAll.Rows.Add("IO输出口-10", "+24V");
            checkListAll.Rows.Add("IO输出口-11", "+24V");
            checkListAll.Rows.Add("IO输出口-12", "+24V");
            checkListAll.Rows.Add("IO输出口-13", "+24V");
            checkListAll.Rows.Add("IO输出口-14", "+24V");
            checkListAll.Rows.Add("IO输出口-15", "+24V");
            checkListAll.Rows.Add("IO输出口-16", "+24V");

            checkListAll.Rows.Add("IO输入口-1", "+24V");
            checkListAll.Rows.Add("IO输入口-2", "+24V");
            checkListAll.Rows.Add("IO输入口-3", "+24V");
            checkListAll.Rows.Add("IO输入口-4", "+24V");
            checkListAll.Rows.Add("IO输入口-5", "+24V");
            checkListAll.Rows.Add("IO输入口-6", "+24V");
            checkListAll.Rows.Add("IO输入口-7", "+24V");
            checkListAll.Rows.Add("IO输入口-8", "+24V");
            checkListAll.Rows.Add("IO输入口-9", "+24V");
            checkListAll.Rows.Add("IO输入口-10", "+24V");
            checkListAll.Rows.Add("IO输入口-11", "+3.6-5V");
            checkListAll.Rows.Add("IO输入口-12", "+3.6-5V");
            checkListAll.Rows.Add("IO输入口-13", "+3.6-5V");
            checkListAll.Rows.Add("IO输入口-14", "+3.6-5V");
            checkListAll.Rows.Add("IO输入口-15", "+0-1.4V");
            checkListAll.Rows.Add("IO输入口-16", "+0-1.4V");

            checkListAll.Rows.Add("DA输出测试-1", "+4V");
            checkListAll.Rows.Add("DA输出测试-2", "+4V");
            checkListAll.Rows.Add("DA输出测试-3", "+4V");
            checkListAll.Rows.Add("DA输出测试-4", "+4V");
            checkListAll.Rows.Add("DA输出测试-5", "+4V");
            checkListAll.Rows.Add("DA输出测试-6", "+4V");
            checkListAll.Rows.Add("DA输出测试-7", "+4V");
            checkListAll.Rows.Add("DA输出测试-8", "+4V");

            checkListAll.Rows.Add("ADC输入测试-1", "+24V");
            checkListAll.Rows.Add("ADC输入测试-2", "+24V");
            checkListAll.Rows.Add("ADC输入测试-3", "+24V");
            checkListAll.Rows.Add("ADC输入测试-4", "+24V");
            checkListAll.Rows.Add("ADC输入测试-5", "+24V");
            checkListAll.Rows.Add("ADC输入测试-6", "+24V");
            checkListAll.Rows.Add("ADC输入测试-7", "+24V");
            checkListAll.Rows.Add("ADC输入测试-8", "+24V");
            checkListAll.Rows.Add("ADC输入测试-9", "+24V");
            checkListAll.Rows.Add("ADC输入测试-10", "+24V");
            checkListAll.Rows.Add("ADC输入测试-11", "+24V");
            checkListAll.Rows.Add("ADC输入测试-12", "+24V");

            checkListAll.Rows.Add("CUR_Bat1", "+3.3V");
            checkListAll.Rows.Add("CUR_Bat1", "+3.3V");
            checkListAll.Rows.Add("CUR_Bat1", "+3.3V");
            checkListAll.Rows.Add("CUR_Bat1", "+3.3V");
            checkListAll.Rows.Add("CUR_Rsv1", "+3.3V");
            checkListAll.Rows.Add("CUR_Rsv2", "+3.3V");
            checkListAll.Rows.Add("CUR_U", "+3.3V");
            checkListAll.Rows.Add("CUR_V", "+3.3V");
            checkListAll.Rows.Add("CUR_W", "+3.3V");
            checkListAll.Rows.Add("VOL_U", "+3.3V");
            checkListAll.Rows.Add("VOL_V", "+3.3V");
            checkListAll.Rows.Add("VOL_W", "+3.3V");
            checkListAll.Rows.Add("SPD", "+0.5V");
            checkListAll.Rows.Add("RSV", "+0.5V");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (skinCheckBox1.Checked == true)
            {
                wordSheet1 = new DataTable();
                wordSheet1 = checkListChoose.Copy();
                dataGridView1.DataSource = wordSheet1;
                SetRowStyle(dataGridView1);
            }
            if (skinCheckBox2.Checked == true)
            {
                wordSheet2 = new DataTable();
                wordSheet2 = checkListChoose.Copy();
                dataGridView2.DataSource = wordSheet2;
                SetRowStyle(dataGridView2);
            }
            if (skinCheckBox3.Checked == true)
            {
                wordSheet3 = new DataTable();
                wordSheet3 = checkListChoose.Copy();
                dataGridView3.DataSource = wordSheet3;
                SetRowStyle(dataGridView3);

            } if (skinCheckBox4.Checked == true)
            {
                wordSheet4 = new DataTable();
                wordSheet4 = checkListChoose.Copy();
                dataGridView4.DataSource = wordSheet4;
                SetRowStyle(dataGridView4);
            }

        }
        private void GenerateWord(DataTable table)
        {
            string savePath = null;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                savePath = saveFileDialog1.FileName;
            }
            else
            {
                MessageBox.Show("保存文档请选择一个文件地址和文件名");
                return;
            }
            if (WordPlay.CreateWord(true) == false)
            {
                MessageBox.Show("Create Error!", "Attention!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //WordPlay.SetPage(WordPlay.Orientation.竖版,3,2.4,1.87,2.3);
            WordPlay.InsertText("测 试 结 果 表", new Font("黑体", 14, FontStyle.Bold), WordPlay.Alignment.居中对齐, true);
            WordPlay.InsertText("制表时间" + DateTime.Now, new Font("宋体", 10.5F, FontStyle.Regular), WordPlay.Alignment.右对齐, true);
            WordPlay.InsertTable(table, true, null, new string[] { "序号", "测试内容", "理论值", "实际值", "结果" });
            WordPlay.InsertText("北京航空航天大学702", new Font("宋体", 10.5F, FontStyle.Regular), WordPlay.Alignment.右对齐, false);
            WordPlay.Save(savePath, true);
            WordPlay.Quit();
        }


        private void button10_Click(object sender, EventArgs e)
        {
            if (skinRadioButton1.Checked == true)
            {
                checkFlag = System.Convert.ToByte(skinComboBox1.SelectedIndex + 1);
            }
            if (skinRadioButton2.Checked == true)
            {
                checkFlag = 0x00;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            GenerateWord(wordSheet1);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            GenerateWord(wordSheet2);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            GenerateWord(wordSheet3);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            GenerateWord(wordSheet4);
        }

        private void skinRadioButton1_Click(object sender, EventArgs e)
        {
            if (skinRadioButton1.Checked == true)
            {
                skinComboBox1.Enabled = true;
            }
            if (skinRadioButton2.Checked == true)
            {

                skinComboBox1.Enabled = false;
            }
        }
    }
}
