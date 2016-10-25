using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Data;

namespace TaskWeek1
{
    static class RowStyle
    {

        public static void SetRowStyle(DataGridView dataGridView, String formName)//设置在线显示表格DataGridView属性
        {
            DataGridViewCellStyle m_RowStyleNormal; //DataGrid格式
            DataGridViewCellStyle m_RowStyleAlternate;

            m_RowStyleNormal = new DataGridViewCellStyle();
            m_RowStyleNormal.ForeColor = Color.Black;
            m_RowStyleNormal.BackColor = Color.LightBlue;
            m_RowStyleNormal.SelectionBackColor = Color.LightBlue;
            m_RowStyleNormal.Alignment = DataGridViewContentAlignment.MiddleCenter;
            m_RowStyleNormal.Font = new Font("宋体", 10);

            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                dataGridView.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            if (formName == "Laolian")
            {
                if (dataGridView.Columns.Count == 5)
                {
                    dataGridView.Columns[0].Width = 80;  //测试周期
                    dataGridView.Columns[1].Width = 80;  //输入电压
                    dataGridView.Columns[2].Width = 110;  //老炼时间
                    dataGridView.Columns[3].Width = 110;  //剩余时间
                    dataGridView.Columns[4].Width = 80;  //测试结果
                    dataGridView.RowHeadersWidth = 50;   //列标题宽度
                }
                if (dataGridView.Columns.Count == 6)
                {
                    dataGridView.Columns[0].Width = 50;//周期
                    dataGridView.Columns[1].Width = 120;  //测试通道名——短路测试通道1
                    dataGridView.Columns[2].Width = 105;  //测试点1
                    dataGridView.Columns[3].Width = 105;  //测试点2
                    dataGridView.Columns[4].Width = 80;  //理论值/Ω
                    dataGridView.Columns[5].Width = 80;  //实测值/Ω
                    dataGridView.RowHeadersWidth = 50;   //列标题宽度
                }
                if (dataGridView.Columns.Count == 9)
                {
                    dataGridView.Columns[0].Width = 50;  //周期
                    dataGridView.Columns[1].Width = 140;  //测试通道名
                    dataGridView.Columns[2].Width = 150;  //输入点
                    dataGridView.Columns[3].Width = 150;  //基准点1
                    dataGridView.Columns[4].Width = 80;  //输入电压
                    dataGridView.Columns[5].Width = 150;  //测试点
                    dataGridView.Columns[6].Width = 150;  //基准点2
                    dataGridView.Columns[7].Width = 80;  //理论值
                    dataGridView.Columns[8].Width = 80;  //实测值
                    dataGridView.RowHeadersWidth = 50;   //列标题宽度
                }  
            }
            else
            {
                if (dataGridView.Columns.Count == 5)
                {
                    dataGridView.Columns[0].Width = 140;  //测试通道名——短路测试通道1
                    dataGridView.Columns[1].Width = 120;  //测试点1
                    dataGridView.Columns[2].Width = 120;  //测试点2
                    dataGridView.Columns[3].Width = 80;  //理论值/Ω
                    dataGridView.Columns[4].Width = 80;  //实测值/Ω
                    dataGridView.RowHeadersWidth = 50;   //列标题宽度
                }
                if (dataGridView.Columns.Count == 8)
                {
                    dataGridView.Columns[0].Width = 140;  //测试通道名
                    dataGridView.Columns[1].Width = 150;  //输入点
                    dataGridView.Columns[2].Width = 150;  //基准点1
                    dataGridView.Columns[3].Width = 80;  //输入电压
                    dataGridView.Columns[4].Width = 150;  //测试点
                    dataGridView.Columns[5].Width = 150;  //基准点2
                    dataGridView.Columns[6].Width = 80;  //理论值
                    dataGridView.Columns[7].Width = 80;  //实测值
                    dataGridView.RowHeadersWidth = 50;   //列标题宽度
                }
            }
            //dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            try
            {
                if (dataGridView.Rows.Count > 1)
                {
                    for (int i = 0; i < dataGridView.Rows.Count; i++)
                        dataGridView.Rows[i].HeaderCell.Value = (i + 1).ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("请先正确读取配置文件", "Warning");
            }
            dataGridView.DefaultCellStyle = m_RowStyleNormal;

            m_RowStyleAlternate = new DataGridViewCellStyle();
            m_RowStyleAlternate.ForeColor = Color.Blue;
            m_RowStyleAlternate.BackColor = Color.White;
            m_RowStyleAlternate.Font = new Font("宋体", 9);
            m_RowStyleAlternate.SelectionBackColor = Color.LightSlateGray;
            m_RowStyleAlternate.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.ColumnHeadersDefaultCellStyle = m_RowStyleNormal;
            dataGridView.RowHeadersDefaultCellStyle = m_RowStyleAlternate;
        }

        public static void ChangeRowStyle(DataGridView dataGridView, int row)//改变在线显示表格DataGridView某一行属性(测试没通过)
        {
            DataGridViewCellStyle m_RowStyleAlarm;
            m_RowStyleAlarm = new DataGridViewCellStyle();
            m_RowStyleAlarm.ForeColor = Color.Black;
            m_RowStyleAlarm.BackColor = Color.Gold;
            m_RowStyleAlarm.SelectionBackColor = Color.Gold;
            m_RowStyleAlarm.Alignment = DataGridViewContentAlignment.MiddleCenter;
            m_RowStyleAlarm.Font = new Font("宋体", 10);
            dataGridView.Rows[row].DefaultCellStyle = m_RowStyleAlarm;
        }

        public static void ChangeNormalRowStyle(DataGridView dataGridView, int row)//改变在线显示表格DataGridView某一行属性（测试又通过）
        {
            DataGridViewCellStyle m_RowStyleNormal; //DataGrid格式
            m_RowStyleNormal = new DataGridViewCellStyle();
            m_RowStyleNormal.ForeColor = Color.Black;
            m_RowStyleNormal.BackColor = Color.LightBlue;
            m_RowStyleNormal.SelectionBackColor = Color.LightBlue;
            m_RowStyleNormal.Alignment = DataGridViewContentAlignment.MiddleCenter;
            m_RowStyleNormal.Font = new Font("宋体", 10);
            dataGridView.Rows[row].DefaultCellStyle = m_RowStyleNormal;
        }

        public static void JudgeShort(DataGridView rowMergeView_Short, DataTable checkListShort, ushort[] shortResult, int h, int ChanelNumber, ushort ShortMin)
        {
            UInt16 shortTheory;
            int num = checkListShort.Columns.IndexOf("理论值/Ω");
            for (int k = 1; k <= ChanelNumber; k++)
            {
                if (checkListShort.Rows[h][0].ToString() == ("短路测试通道" + k.ToString()))
                {
                    shortTheory = UInt16.Parse(checkListShort.Rows[h][num].ToString());
                    checkListShort.Rows[h][num + 1] = shortResult[k - 1];//插入虚拟表格checkListShort1
                    if (shortResult[k - 1] <= ShortMin)//判断
                    {
                        rowMergeView_Short.DataSource = checkListShort;
                        rowMergeView_Short.Refresh();
                        RowStyle.ChangeRowStyle(rowMergeView_Short, h);
                    }
                    else
                    {
                        rowMergeView_Short.DataSource = checkListShort;
                        rowMergeView_Short.Refresh();
                        RowStyle.ChangeNormalRowStyle(rowMergeView_Short, h);
                    }
                    break;
                }
            }
        }

        public static void JudgeVolt(DataGridView rowMergeView_Volt, DataTable checkListVolt, float[] voltResult, int h, int ChanelNumber, float VoltErroMin, float VoltErroMax)
        {
            float voltTheory;
            int num = checkListVolt.Columns.IndexOf("理论值/V");
            for (int i = 0; i < checkListVolt.Columns.Count; i++)
            {
                if (checkListVolt.Columns[i].ColumnName.Contains("理论值"))
                {
                    num = i;
                    break;
                }
            }
            for (int k = 1; k <= ChanelNumber; k++)
            {
                if (checkListVolt.Rows[h][0].ToString() == ("电压输出测试通道" + k.ToString()))
                {
                    voltTheory = Math.Abs(float.Parse(checkListVolt.Rows[h][num].ToString()));
                    checkListVolt.Rows[h][num + 1] = voltResult[k - 1];//插入虚拟表格checkListVolt1
                    if ((Math.Abs(voltResult[k - 1]) < voltTheory * VoltErroMin) || (Math.Abs(voltResult[k - 1]) > voltTheory * VoltErroMax))//判断
                    {
                        rowMergeView_Volt.DataSource = checkListVolt;
                        rowMergeView_Volt.Refresh();
                        RowStyle.ChangeRowStyle(rowMergeView_Volt, h);
                    }
                    else
                    {
                        rowMergeView_Volt.DataSource = checkListVolt;
                        rowMergeView_Volt.Refresh();
                        RowStyle.ChangeNormalRowStyle(rowMergeView_Volt, h);
                    }
                    break;
                }
            }
        }

        public static void JudgeIOOut(DataGridView rowMergeView_Fuction, DataTable checkListfuction, float[] IOOutResult, float[] IOOutResulta, int h, int ChanelNumber, float IOOutErroMin, float IOOutErroMax, float IOOutOffset, String formName)
        {
            float IOOutTheory;
            float IOOutTheorya;
            int num = checkListfuction.Columns.IndexOf("理论值/V");
            for (int k = 1; k <= ChanelNumber; k++)
            {
                if (checkListfuction.Rows[h][0].ToString() == ("I/O输出测试通道" + k.ToString()))
                {
                    if (formName == "Zuhe" || formName == "Zhengji" || formName == "Gonglv" || formName == "Laolian")
                    {
                        IOOutTheory = float.Parse(checkListfuction.Rows[h][num].ToString());
                        checkListfuction.Rows[h][num + 1] = IOOutResult[k - 1];//插入虚拟表格checkListVolt1
                        if ((IOOutResult[k - 1] < IOOutTheory - IOOutOffset) || (IOOutResult[k - 1] > IOOutTheory + IOOutOffset))//判断
                        {
                            rowMergeView_Fuction.DataSource = checkListfuction;
                            rowMergeView_Fuction.Refresh();
                            RowStyle.ChangeRowStyle(rowMergeView_Fuction, h);
                        }
                        else
                        {
                            rowMergeView_Fuction.DataSource = checkListfuction;
                            rowMergeView_Fuction.Refresh();
                            RowStyle.ChangeNormalRowStyle(rowMergeView_Fuction, h);
                        }
                        IOOutTheorya = float.Parse(checkListfuction.Rows[h + 1][num].ToString());
                        checkListfuction.Rows[h + 1][num + 1] = IOOutResulta[k - 1];//插入虚拟表格checkListVolt1
                        if ((IOOutResulta[k - 1] < IOOutTheorya * IOOutErroMin) || (IOOutResulta[k - 1] > IOOutTheorya * IOOutErroMax))//判断
                        {
                            rowMergeView_Fuction.DataSource = checkListfuction;
                            rowMergeView_Fuction.Refresh();
                            RowStyle.ChangeRowStyle(rowMergeView_Fuction, h + 1);
                        }
                        else
                        {
                            rowMergeView_Fuction.DataSource = checkListfuction;
                            rowMergeView_Fuction.Refresh();
                            RowStyle.ChangeNormalRowStyle(rowMergeView_Fuction, h + 1);
                        }
                    }
                    if (formName == "Kongzhi" || formName == "Zonghe")
                    {
                        IOOutTheory = float.Parse(checkListfuction.Rows[h][num].ToString());
                        checkListfuction.Rows[h][num + 1] = IOOutResult[k - 1];//插入虚拟表格checkListVolt1
                        if ((IOOutResult[k - 1] < IOOutTheory * IOOutErroMin) || (IOOutResult[k - 1] > IOOutTheory * IOOutErroMax))//判断
                        {
                            rowMergeView_Fuction.DataSource = checkListfuction;
                            rowMergeView_Fuction.Refresh();
                            RowStyle.ChangeRowStyle(rowMergeView_Fuction, h);
                        }
                        else
                        {
                            rowMergeView_Fuction.DataSource = checkListfuction;
                            rowMergeView_Fuction.Refresh();
                            RowStyle.ChangeNormalRowStyle(rowMergeView_Fuction, h);
                        }
                        IOOutTheorya = float.Parse(checkListfuction.Rows[h + 1][num].ToString());
                        checkListfuction.Rows[h + 1][num + 1] = IOOutResulta[k - 1];//插入虚拟表格checkListVolt1
                        if ((IOOutResulta[k - 1] < IOOutTheorya - IOOutOffset) || (IOOutResulta[k - 1] > IOOutTheorya + IOOutOffset))//判断
                        {
                            rowMergeView_Fuction.DataSource = checkListfuction;
                            rowMergeView_Fuction.Refresh();
                            RowStyle.ChangeRowStyle(rowMergeView_Fuction, h + 1);
                        }
                        else
                        {
                            rowMergeView_Fuction.DataSource = checkListfuction;
                            rowMergeView_Fuction.Refresh();
                            RowStyle.ChangeNormalRowStyle(rowMergeView_Fuction, h + 1);
                        }
                    }
                    break;
                }
            }
        }

        public static void JudgeIOIn(DataGridView rowMergeView_Fuction, DataTable checkListfuction, float[] IOInResult, float[] IOInResulta, int h, int ChanelNumber, float IOInErroMin, float IOInErroMax, float IOInOffset, String formName)
        {
            float IOInTheory;
            float IOInTheorya;
            int num = checkListfuction.Columns.IndexOf("理论值/V");
            for (int k = 1; k <= ChanelNumber; k++)
            {
                if (checkListfuction.Rows[h][0].ToString() == ("I/O输入测试通道" + k.ToString()))
                {
                    if (formName == "Zuhe" || formName == "Zhengji" || formName == "Gonglv" || formName == "Kongzhi" || formName == "Laolian")
                    {
                        IOInTheory = float.Parse(checkListfuction.Rows[h][num].ToString());
                        checkListfuction.Rows[h][num + 1] = IOInResult[k - 1];//插入虚拟表格checkListfuction
                        if (IOInResult[k - 1] != IOInTheory)//判断
                        {
                            rowMergeView_Fuction.DataSource = checkListfuction;
                            rowMergeView_Fuction.Refresh();
                            RowStyle.ChangeRowStyle(rowMergeView_Fuction, h);
                        }
                        else
                        {
                            rowMergeView_Fuction.DataSource = checkListfuction;
                            rowMergeView_Fuction.Refresh();
                            RowStyle.ChangeNormalRowStyle(rowMergeView_Fuction, h);
                        }
                        IOInTheorya = float.Parse(checkListfuction.Rows[h + 1][num].ToString());
                        checkListfuction.Rows[h + 1][num + 1] = IOInResulta[k - 1];//插入虚拟表格checkListfuction
                        if (IOInResulta[k - 1] != IOInTheorya)//判断
                        {
                            rowMergeView_Fuction.DataSource = checkListfuction;
                            rowMergeView_Fuction.Refresh();
                            RowStyle.ChangeRowStyle(rowMergeView_Fuction, h + 1);
                        }
                        else
                        {
                            rowMergeView_Fuction.DataSource = checkListfuction;
                            rowMergeView_Fuction.Refresh();
                            RowStyle.ChangeNormalRowStyle(rowMergeView_Fuction, h + 1);
                        }
                    }
                    if (formName == "Zonghe")
                    {
                        IOInTheory = float.Parse(checkListfuction.Rows[h][num].ToString());
                        checkListfuction.Rows[h][num + 1] = IOInResult[k - 1];//插入虚拟表格checkListfuction
                        if ((IOInResult[k - 1] < IOInTheory * IOInErroMin) || (IOInResult[k - 1] > IOInTheory * IOInErroMax))//判断
                        {
                            rowMergeView_Fuction.DataSource = checkListfuction;
                            rowMergeView_Fuction.Refresh();
                            RowStyle.ChangeRowStyle(rowMergeView_Fuction, h);
                        }
                        else
                        {
                            rowMergeView_Fuction.DataSource = checkListfuction;
                            rowMergeView_Fuction.Refresh();
                            RowStyle.ChangeNormalRowStyle(rowMergeView_Fuction, h);
                        }
                        IOInTheorya = float.Parse(checkListfuction.Rows[h + 1][num].ToString());
                        checkListfuction.Rows[h + 1][num + 1] = IOInResulta[k - 1];//插入虚拟表格checkListfuction
                        if ((IOInResulta[k - 1] < IOInTheorya - IOInOffset) || (IOInResulta[k - 1] > IOInTheorya + IOInOffset))//判断
                        {
                            rowMergeView_Fuction.DataSource = checkListfuction;
                            rowMergeView_Fuction.Refresh();
                            RowStyle.ChangeRowStyle(rowMergeView_Fuction, h + 1);
                        }
                        else
                        {
                            rowMergeView_Fuction.DataSource = checkListfuction;
                            rowMergeView_Fuction.Refresh();
                            RowStyle.ChangeNormalRowStyle(rowMergeView_Fuction, h + 1);
                        }
                    }
                    break;
                }
            }
        }

        public static void JudgeDA(DataGridView rowMergeView_Fuction, DataTable checkListfuction, float[] DAResult, float[] DAResulta, int h, int ChanelNumber, float DAErroMin, float DAErroMax, float DAOffset, String formName)
        {
            float DATheory;
            float DATheorya;
            int num = checkListfuction.Columns.IndexOf("理论值/V");
            for (int k = 1; k <= ChanelNumber; k++)
            {
                if (checkListfuction.Rows[h][0].ToString() == ("DA输出测试通道" + k.ToString()))
                {
                    if (formName == "Zuhe" || formName == "Zhengji" || formName == "Gonglv" || formName == "Zonghe" || formName == "Laolian")
                    {
                        DATheory = float.Parse(checkListfuction.Rows[h][num].ToString());
                        checkListfuction.Rows[h][num + 1] = DAResult[k - 1];//插入虚拟表格checkListfuction
                        if ((DAResult[k - 1] < DATheory * DAErroMin) || (DAResult[k - 1] > DATheory * DAErroMax))//判断
                        {
                            rowMergeView_Fuction.DataSource = checkListfuction;
                            rowMergeView_Fuction.Refresh();
                            RowStyle.ChangeRowStyle(rowMergeView_Fuction, h);
                        }
                        else
                        {
                            rowMergeView_Fuction.DataSource = checkListfuction;
                            rowMergeView_Fuction.Refresh();
                            RowStyle.ChangeNormalRowStyle(rowMergeView_Fuction, h);
                        }
                        DATheorya = float.Parse(checkListfuction.Rows[h + 1][num].ToString());
                        checkListfuction.Rows[h + 1][num + 1] = DAResulta[k - 1];//插入虚拟表格checkListfuction
                        if ((DAResulta[k - 1] < DATheorya - DAOffset) || (DAResulta[k - 1] > DATheorya + DAOffset))//判断
                        {
                            rowMergeView_Fuction.DataSource = checkListfuction;
                            rowMergeView_Fuction.Refresh();
                            RowStyle.ChangeRowStyle(rowMergeView_Fuction, h + 1);
                        }
                        else
                        {
                            rowMergeView_Fuction.DataSource = checkListfuction;
                            rowMergeView_Fuction.Refresh();
                            RowStyle.ChangeNormalRowStyle(rowMergeView_Fuction, h + 1);
                        }
                    }
                    if (formName == "Kongzhi")
                    {
                        DATheory = float.Parse(checkListfuction.Rows[h][num].ToString());
                        checkListfuction.Rows[h][num + 1] = DAResult[k - 1];//插入虚拟表格checkListfuction
                        if ((DAResult[k - 1] < DATheory * DAErroMin) || (DAResult[k - 1] > DATheory * DAErroMax))//判断
                        {
                            rowMergeView_Fuction.DataSource = checkListfuction;
                            rowMergeView_Fuction.Refresh();
                            RowStyle.ChangeRowStyle(rowMergeView_Fuction, h);
                        }
                        else
                        {
                            rowMergeView_Fuction.DataSource = checkListfuction;
                            rowMergeView_Fuction.Refresh();
                            RowStyle.ChangeNormalRowStyle(rowMergeView_Fuction, h);
                        }
                        DATheorya = float.Parse(checkListfuction.Rows[h + 1][num].ToString());
                        checkListfuction.Rows[h + 1][num + 1] = DAResulta[k - 1];//插入虚拟表格checkListfuction
                        if ((DAResulta[k - 1] < DATheorya * DAErroMin) || (DAResulta[k - 1] > DATheorya * DAErroMax))//判断
                        {
                            rowMergeView_Fuction.DataSource = checkListfuction;
                            rowMergeView_Fuction.Refresh();
                            RowStyle.ChangeRowStyle(rowMergeView_Fuction, h + 1);
                        }
                        else
                        {
                            rowMergeView_Fuction.DataSource = checkListfuction;
                            rowMergeView_Fuction.Refresh();
                            RowStyle.ChangeNormalRowStyle(rowMergeView_Fuction, h + 1);
                        }
                    }
                    break;
                }
            }
        }

        public static void JudgeAD(DataGridView rowMergeView_Fuction, DataTable checkListfuction, float[] ADResult, float[] ADResulta, int h, int ChanelNumber, float ADErroMin, float ADErroMax)
        {
            float ADTheory;
            float ADTheorya;
            int num = checkListfuction.Columns.IndexOf("理论值/V");
            for (int k = 1; k <= 38; k++)
            {
                if (checkListfuction.Rows[h][0].ToString() == ("AD输入测试通道" + k.ToString()))
                {
                    ADTheory = float.Parse(checkListfuction.Rows[h][num].ToString());
                    checkListfuction.Rows[h][num + 1] = ADResult[k - 1];//插入虚拟表格checkListfuciton1
                    if ((ADResult[k - 1] < ADTheory * ADErroMin) || (ADResult[k - 1] > ADTheory * ADErroMax))//判断
                    {
                        rowMergeView_Fuction.DataSource = checkListfuction;
                        rowMergeView_Fuction.Refresh();
                        RowStyle.ChangeRowStyle(rowMergeView_Fuction, h);
                    }
                    else
                    {
                        rowMergeView_Fuction.DataSource = checkListfuction;
                        rowMergeView_Fuction.Refresh();
                        RowStyle.ChangeNormalRowStyle(rowMergeView_Fuction, h);
                    }
                    ADTheorya = float.Parse(checkListfuction.Rows[h + 1][num].ToString());
                    checkListfuction.Rows[h + 1][num + 1] = ADResulta[k - 1];//插入虚拟表格checkListfuction
                    if ((ADResulta[k - 1] < ADTheorya * ADErroMin) || (ADResulta[k - 1] > ADTheorya * ADErroMax))//判断
                    {
                        rowMergeView_Fuction.DataSource = checkListfuction;
                        rowMergeView_Fuction.Refresh();
                        RowStyle.ChangeRowStyle(rowMergeView_Fuction, h + 1);
                    }
                    else
                    {
                        rowMergeView_Fuction.DataSource = checkListfuction;
                        rowMergeView_Fuction.Refresh();
                        RowStyle.ChangeNormalRowStyle(rowMergeView_Fuction, h + 1);
                    }
                    break;
                }
            }
        }
    }
}
