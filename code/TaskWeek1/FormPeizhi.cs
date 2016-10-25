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
    public partial class FormPeizhi : Form
    {
        private List<string> checkList = new List<string>();
        private List<string> checkList1 = new List<string>();
        private string strOut;
        private string strOut1;
        private byte[] peizhiID = new byte[26];
        private byte testtypeinfo = 0x00;
        private int numShort = 0;
        private int numVolt = 0;
        private int numIOOut = 0;
        private int numIOIn = 0;
        private int numDA = 0;
        private int numAD = 0;
        Form showform;
        int i = 0;
        private String whichform;   //用于选择是哪个form的配置

        public FormPeizhi(String passformcome)
        {
            InitializeComponent();
            whichform = passformcome;
            replaceTitle();
        }
        private void CheckResult()//配置文件生成
        {
            testtypeinfo = 0x00;
            numShort = 0x00;
            numVolt = 0x00;
            if (CheckBox_ZhengShort1.Checked == true)  //生成短路1配置
            { 
                peizhiID[0] |= Convert.ToByte("00000001",2);
                testtypeinfo |= Convert.ToByte("00000001", 2);
                numShort += 1;
            }
            if (CheckBox_ZhengShort1.Checked == false)
            {
                peizhiID[0] &= Convert.ToByte("11111100",2);
            }
            if (CheckBox_ZhengShort2.Checked == true)  //生成短路2配置
            {
                peizhiID[0] |= Convert.ToByte("00000100", 2);
                testtypeinfo |= Convert.ToByte("00000001", 2);
                numShort += 1;
            }
            if (CheckBox_ZhengShort2.Checked == false)
            {
                peizhiID[0] &= Convert.ToByte("11110011", 2);
            }
            if (CheckBox_ZhengShort3.Checked == true)  //生成短路3配置
            {
                peizhiID[0] |= Convert.ToByte("00010000", 2);
                testtypeinfo |= Convert.ToByte("00000001", 2);
                numShort += 1;
            }
            if (CheckBox_ZhengShort3.Checked == false)
            {
                peizhiID[0] &= Convert.ToByte("11001111", 2);
            }
            if (CheckBox_ZhengShort4.Checked == true)  //生成短路4配置
            {
                peizhiID[0] |= Convert.ToByte("01000000", 2);
                testtypeinfo |= Convert.ToByte("00000001", 2);
                numShort += 1;
            }
            if (CheckBox_ZhengShort4.Checked == false)
            {
                peizhiID[0] &= Convert.ToByte("00111111", 2);
            }
            if (CheckBox_ZhengShort5.Checked == true)  //生成短路5配置
            {
                peizhiID[1] |= Convert.ToByte("00000001", 2);
                testtypeinfo |= Convert.ToByte("00000001", 2);
                numShort += 1;
            }
            if (CheckBox_ZhengShort5.Checked == false)
            {
                peizhiID[1] &= Convert.ToByte("11111100", 2);
            }
            if (CheckBox_ZhengShort6.Checked == true)  //生成短路6配置
            {
                peizhiID[1] |= Convert.ToByte("00000100", 2);
                testtypeinfo |= Convert.ToByte("00000001", 2);
                numShort += 1;
            }
            if (CheckBox_ZhengShort6.Checked == false)
            {
                peizhiID[1] &= Convert.ToByte("11110011", 2);
            }
            if (CheckBox_ZhengShort7.Checked == true)  //生成短路7配置
            {
                peizhiID[1] |= Convert.ToByte("00010000", 2);
                testtypeinfo |= Convert.ToByte("00000001", 2);
                numShort += 1;
            }
            if (CheckBox_ZhengShort7.Checked == false)
            {
                peizhiID[1] &= Convert.ToByte("11001111", 2);
            }
            if (CheckBox_ZhengShort8.Checked == true)  //生成短路8配置
            {
                peizhiID[1] |= Convert.ToByte("01000000", 2);
                testtypeinfo |= Convert.ToByte("00000001", 2);
                numShort += 1;
            }
            if (CheckBox_ZhengShort8.Checked == false)
            {
                peizhiID[1] &= Convert.ToByte("00111111", 2);
            }
            if (CheckBox_ZhengVolt1.Checked == true)  //生成电压输出1配置
            {
                peizhiID[2] |= Convert.ToByte("00000001", 2);
                testtypeinfo |= Convert.ToByte("00000010", 2);
                numVolt += 1;
            }
            if (CheckBox_ZhengVolt1.Checked == false)
            {
                peizhiID[2] &= Convert.ToByte("11111100", 2);
            }
            if (CheckBox_ZhengVolt2.Checked == true)  //生成电压输出2配置
            {
                peizhiID[2] |= Convert.ToByte("00000100", 2);
                testtypeinfo |= Convert.ToByte("00000010", 2);
                numVolt += 1;
            }
            if (CheckBox_ZhengVolt2.Checked == false)
            {
                peizhiID[2] &= Convert.ToByte("11110011", 2);
            }
            if (CheckBox_ZhengVolt3.Checked == true)  //生成电压输出3配置
            {
                peizhiID[2] |= Convert.ToByte("00010000", 2);
                testtypeinfo |= Convert.ToByte("00000010", 2);
                numVolt += 1;
            }
            if (CheckBox_ZhengVolt3.Checked == false)
            {
                peizhiID[2] &= Convert.ToByte("11001111", 2);
            }
            if (CheckBox_ZhengVolt4.Checked == true)  //生成电压输出4配置
            {
                peizhiID[2] |= Convert.ToByte("01000000", 2);
                testtypeinfo |= Convert.ToByte("00000010", 2);
                numVolt += 1;
            }
            if (CheckBox_ZhengVolt4.Checked == false)
            {
                peizhiID[2] &= Convert.ToByte("00111111", 2);
            }
            if (CheckBox_ZhengVolt5.Checked == true)  //生成电压输出5配置
            {
                peizhiID[3] |= Convert.ToByte("00000001", 2);
                testtypeinfo |= Convert.ToByte("00000010", 2);
                numVolt += 1;
            }
            if (CheckBox_ZhengVolt5.Checked == false)
            {
                peizhiID[3] &= Convert.ToByte("11111100", 2);
            }
            if (CheckBox_ZhengVolt6.Checked == true)  //生成电压输出6配置
            {
                peizhiID[3] |= Convert.ToByte("00000100", 2);
                testtypeinfo |= Convert.ToByte("00000010", 2);
                numVolt += 1;
            }
            if (CheckBox_ZhengVolt6.Checked == false)
            {
                peizhiID[3] &= Convert.ToByte("11110011", 2);
            }
            if (CheckBox_ZhengVolt7.Checked == true)  //生成电压输出7配置
            {
                peizhiID[3] |= Convert.ToByte("00010000", 2);
                testtypeinfo |= Convert.ToByte("00000010", 2);
                numVolt += 1;
            }
            if (CheckBox_ZhengVolt7.Checked == false)
            {
                peizhiID[3] &= Convert.ToByte("11001111", 2);
            }
            if (CheckBox_ZhengVolt8.Checked == true)  //生成电压输出8配置
            {
                peizhiID[3] |= Convert.ToByte("01000000", 2);
                testtypeinfo |= Convert.ToByte("00000010", 2);
                numVolt += 1;
            }
            if (CheckBox_ZhengVolt8.Checked == false)
            {
                peizhiID[3] &= Convert.ToByte("00111111", 2);
            }
            if (CheckBox_ZhengIOOut1.Checked == true)  //IO输出1配置
            {
                testtypeinfo |= Convert.ToByte("00000100", 2);
                if (skinCheckBox_ZhengIOOut1.Checked == true)
                { peizhiID[4] |= Convert.ToByte("00000001", 2);
                  peizhiID[4] &= Convert.ToByte("11111101", 2);
                }
                if (skinCheckBox_ZhengIOOut1.Checked == false)
                { peizhiID[4] |= Convert.ToByte("00000010", 2);
                  peizhiID[4] &= Convert.ToByte("11111110", 2);
                }
                numIOOut += 1;
            }
            if (CheckBox_ZhengIOOut1.Checked == false)
            {
                peizhiID[4] &= Convert.ToByte("11111100", 2);
            }
            if (CheckBox_ZhengIOOut2.Checked == true)  //IO输出2配置
            {
                testtypeinfo |= Convert.ToByte("00000100", 2);
                if (skinCheckBox_ZhengIOOut2.Checked == true)
                {
                    peizhiID[4] |= Convert.ToByte("00000100", 2);
                    peizhiID[4] &= Convert.ToByte("11110111", 2);
                }
                if (skinCheckBox_ZhengIOOut2.Checked == false)
                {
                    peizhiID[4] |= Convert.ToByte("00001000", 2);
                    peizhiID[4] &= Convert.ToByte("11111011", 2);
                }
                numIOOut += 1;
            }
            if (CheckBox_ZhengIOOut2.Checked == false)
            {
                peizhiID[4] &= Convert.ToByte("11110011", 2);
            }
            if (CheckBox_ZhengIOOut3.Checked == true)  //IO输出3配置
            {
                testtypeinfo |= Convert.ToByte("00000100", 2);
                if (skinCheckBox_ZhengIOOut3.Checked == true)
                {
                    peizhiID[4] |= Convert.ToByte("00010000", 2);
                    peizhiID[4] &= Convert.ToByte("11011111", 2);
                }
                if (skinCheckBox_ZhengIOOut3.Checked == false)
                {
                    peizhiID[4] |= Convert.ToByte("00100000", 2);
                    peizhiID[4] &= Convert.ToByte("11101111", 2);
                }
                numIOOut += 1;
            }
            if (CheckBox_ZhengIOOut3.Checked == false)
            {
                peizhiID[4] &= Convert.ToByte("11001111", 2);
            }
            if (CheckBox_ZhengIOOut4.Checked == true)  //IO输出4配置
            {
                testtypeinfo |= Convert.ToByte("00000100", 2);
                if (skinCheckBox_ZhengIOOut4.Checked == true)
                {
                    peizhiID[4] |= Convert.ToByte("01000000", 2);
                    peizhiID[4] &= Convert.ToByte("01111111", 2);
                }
                if (skinCheckBox_ZhengIOOut4.Checked == false)
                {
                    peizhiID[4] |= Convert.ToByte("10000000", 2);
                    peizhiID[4] &= Convert.ToByte("10111111", 2);
                }
                numIOOut += 1;
            }
            if (CheckBox_ZhengIOOut4.Checked == false)
            {
                peizhiID[4] &= Convert.ToByte("00111111", 2);
            }
            if (CheckBox_ZhengIOOut5.Checked == true)  //IO输出5配置
            {
                testtypeinfo |= Convert.ToByte("00000100", 2);
                if (skinCheckBox_ZhengIOOut5.Checked == true)
                {
                    peizhiID[5] |= Convert.ToByte("00000001", 2);
                    peizhiID[5] &= Convert.ToByte("11111101", 2);
                }
                if (skinCheckBox_ZhengIOOut5.Checked == false)
                {
                    peizhiID[5] |= Convert.ToByte("00000010", 2);
                    peizhiID[5] &= Convert.ToByte("11111110", 2);
                }
                numIOOut += 1;
            }
            if (CheckBox_ZhengIOOut5.Checked == false)
            {
                peizhiID[5] &= Convert.ToByte("11111100", 2);
            }
            if (CheckBox_ZhengIOOut6.Checked == true)  //IO输出6配置
            {
                testtypeinfo |= Convert.ToByte("00000100", 2);
                if (skinCheckBox_ZhengIOOut6.Checked == true)
                {
                    peizhiID[5] |= Convert.ToByte("00000100", 2);
                    peizhiID[5] &= Convert.ToByte("11110111", 2);
                }
                if (skinCheckBox_ZhengIOOut6.Checked == false)
                {
                    peizhiID[5] |= Convert.ToByte("00001000", 2);
                    peizhiID[5] &= Convert.ToByte("11111011", 2);
                }
                numIOOut += 1;
            }
            if (CheckBox_ZhengIOOut6.Checked == false)
            {
                peizhiID[5] &= Convert.ToByte("11110011", 2);
            }
            if (CheckBox_ZhengIOOut7.Checked == true)  //IO输出7配置
            {
                testtypeinfo |= Convert.ToByte("00000100", 2);
                if (skinCheckBox_ZhengIOOut7.Checked == true)
                {
                    peizhiID[5] |= Convert.ToByte("00010000", 2);
                    peizhiID[5] &= Convert.ToByte("11011111", 2);
                }
                if (skinCheckBox_ZhengIOOut7.Checked == false)
                {
                    peizhiID[5] |= Convert.ToByte("00100000", 2);
                    peizhiID[5] &= Convert.ToByte("11101111", 2);
                }
                numIOOut += 1;
            }
            if (CheckBox_ZhengIOOut6.Checked == false)
            {
                peizhiID[5] &= Convert.ToByte("11001111", 2);
            }
            if (CheckBox_ZhengIOOut8.Checked == true)  //IO输出8配置
            {
                testtypeinfo |= Convert.ToByte("00000100", 2);
                if (skinCheckBox_ZhengIOOut8.Checked == true)
                {
                    peizhiID[5] |= Convert.ToByte("01000000", 2);
                    peizhiID[5] &= Convert.ToByte("01111111", 2);
                }
                if (skinCheckBox_ZhengIOOut8.Checked == false)
                {
                    peizhiID[5] |= Convert.ToByte("10000000", 2);
                    peizhiID[5] &= Convert.ToByte("10111111", 2);
                }
                numIOOut += 1;
            }
            if (CheckBox_ZhengIOOut8.Checked == false)
            {
                peizhiID[5] &= Convert.ToByte("00111111", 2);
            }
            if (CheckBox_ZhengIOOut9.Checked == true)  //IO输出9配置
            {
                testtypeinfo |= Convert.ToByte("00000100", 2);
                if (skinCheckBox_ZhengIOOut9.Checked == true)
                {
                    peizhiID[6] |= Convert.ToByte("00000001", 2);
                    peizhiID[6] &= Convert.ToByte("11111101", 2);
                }
                if (skinCheckBox_ZhengIOOut9.Checked == false)
                {
                    peizhiID[6] |= Convert.ToByte("00000010", 2);
                    peizhiID[6] &= Convert.ToByte("11111110", 2);
                }
                numIOOut += 1;
            }
            if (CheckBox_ZhengIOOut9.Checked == false)
            {
                peizhiID[6] &= Convert.ToByte("11111100", 2);
            }
            if (CheckBox_ZhengIOOut10.Checked == true)  //IO输出10配置
            {
                testtypeinfo |= Convert.ToByte("00000100", 2);
                if (skinCheckBox_ZhengIOOut10.Checked == true)
                {
                    peizhiID[6] |= Convert.ToByte("00000100", 2);
                    peizhiID[6] &= Convert.ToByte("11110111", 2);
                }
                if (skinCheckBox_ZhengIOOut10.Checked == false)
                {
                    peizhiID[6] |= Convert.ToByte("00001000", 2);
                    peizhiID[6] &= Convert.ToByte("11111011", 2);
                }
                numIOOut += 1;
            }
            if (CheckBox_ZhengIOOut10.Checked == false)
            {
                peizhiID[6] &= Convert.ToByte("11110011", 2);
            }
            if (CheckBox_ZhengIOOut11.Checked == true)  //IO输出11配置
            {
                testtypeinfo |= Convert.ToByte("00000100", 2);
                if (skinCheckBox_ZhengIOOut11.Checked == true)
                {
                    peizhiID[6] |= Convert.ToByte("00010000", 2);
                    peizhiID[6] &= Convert.ToByte("11011111", 2);
                }
                if (skinCheckBox_ZhengIOOut11.Checked == false)
                {
                    peizhiID[6] |= Convert.ToByte("00100000", 2);
                    peizhiID[6] &= Convert.ToByte("11101111", 2);
                }
                numIOOut += 1;
            }
            if (CheckBox_ZhengIOOut11.Checked == false)
            {
                peizhiID[6] &= Convert.ToByte("11001111", 2);
            }
            if (CheckBox_ZhengIOOut12.Checked == true)  //IO输出12配置
            {
                testtypeinfo |= Convert.ToByte("00000100", 2);
                if (skinCheckBox_ZhengIOOut12.Checked == true)
                {
                    peizhiID[6] |= Convert.ToByte("01000000", 2);
                    peizhiID[6] &= Convert.ToByte("01111111", 2);
                }
                if (skinCheckBox_ZhengIOOut12.Checked == false)
                {
                    peizhiID[6] |= Convert.ToByte("10000000", 2);
                    peizhiID[6] &= Convert.ToByte("10111111", 2);
                }
                numIOOut += 1;
            }
            if (CheckBox_ZhengIOOut12.Checked == false)
            {
                peizhiID[6] &= Convert.ToByte("00111111", 2);
            }
            if (CheckBox_ZhengIOOut13.Checked == true)  //IO输出13配置
            {
                testtypeinfo |= Convert.ToByte("00000100", 2);
                if (skinCheckBox_ZhengIOOut13.Checked == true)
                {
                    peizhiID[7] |= Convert.ToByte("00000001", 2);
                    peizhiID[7] &= Convert.ToByte("11111101", 2);
                }
                if (skinCheckBox_ZhengIOOut13.Checked == false)
                {
                    peizhiID[7] |= Convert.ToByte("00000010", 2);
                    peizhiID[7] &= Convert.ToByte("11111110", 2);
                }
                numIOOut += 1;
            }
            if (CheckBox_ZhengIOOut13.Checked == false)
            {
                peizhiID[7] &= Convert.ToByte("11111100", 2);
            }
            if (CheckBox_ZhengIOOut14.Checked == true)  //IO输出14配置
            {
                testtypeinfo |= Convert.ToByte("00000100", 2);
                if (skinCheckBox_ZhengIOOut14.Checked == true)
                {
                    peizhiID[7] |= Convert.ToByte("00000100", 2);
                    peizhiID[7] &= Convert.ToByte("11110111", 2);
                }
                if (skinCheckBox_ZhengIOOut14.Checked == false)
                {
                    peizhiID[7] |= Convert.ToByte("00001000", 2);
                    peizhiID[7] &= Convert.ToByte("11111011", 2);
                }
                numIOOut += 1;
            }
            if (CheckBox_ZhengIOOut14.Checked == false)
            {
                peizhiID[7] &= Convert.ToByte("11110011", 2);
            }
            if (CheckBox_ZhengIOOut15.Checked == true)  //IO输出15配置
            {
                testtypeinfo |= Convert.ToByte("00000100", 2);
                if (skinCheckBox_ZhengIOOut15.Checked == true)
                {
                    peizhiID[7] |= Convert.ToByte("00010000", 2);
                    peizhiID[7] &= Convert.ToByte("11011111", 2);
                }
                if (skinCheckBox_ZhengIOOut15.Checked == false)
                {
                    peizhiID[7] |= Convert.ToByte("00100000", 2);
                    peizhiID[7] &= Convert.ToByte("11101111", 2);
                }
                numIOOut += 1;
            }
            if (CheckBox_ZhengIOOut15.Checked == false)
            {
                peizhiID[7] &= Convert.ToByte("11001111", 2);
            }
            if (CheckBox_ZhengIOOut16.Checked == true)  //IO输出16配置
            {
                testtypeinfo |= Convert.ToByte("00000100", 2);
                if (skinCheckBox_ZhengIOOut16.Checked == true)
                {
                    peizhiID[7] |= Convert.ToByte("01000000", 2);
                    peizhiID[7] &= Convert.ToByte("01111111", 2);
                }
                if (skinCheckBox_ZhengIOOut16.Checked == false)
                {
                    peizhiID[7] |= Convert.ToByte("10000000", 2);
                    peizhiID[7] &= Convert.ToByte("10111111", 2);
                }
                numIOOut += 1;
            }
            if (CheckBox_ZhengIOOut16.Checked == false)
            {
                peizhiID[7] &= Convert.ToByte("00111111", 2);
            }
            if (CheckBox_ZhengIOIn1.Checked == true)  //IO输入1配置
            {
                testtypeinfo |= Convert.ToByte("00001000", 2);
                if (skinCheckBox_ZhengIOIn1.Checked == true)
                {
                    peizhiID[8] |= Convert.ToByte("00000001", 2);
                    peizhiID[8] &= Convert.ToByte("11111101", 2);
                }
                if (skinCheckBox_ZhengIOIn1.Checked == false)
                {
                    peizhiID[8] |= Convert.ToByte("00000010", 2);
                    peizhiID[8] &= Convert.ToByte("11111110", 2);
                }
                numIOIn += 1;
            }
            if (CheckBox_ZhengIOIn1.Checked == false)
            {
                peizhiID[8] &= Convert.ToByte("11111100", 2);
            }
            if (CheckBox_ZhengIOIn2.Checked == true)  //IO输入2配置
            {
                testtypeinfo |= Convert.ToByte("00001000", 2);
                if (skinCheckBox_ZhengIOIn2.Checked == true)
                {
                    peizhiID[8] |= Convert.ToByte("00000100", 2);
                    peizhiID[8] &= Convert.ToByte("11110111", 2);
                }
                if (skinCheckBox_ZhengIOIn2.Checked == false)
                {
                    peizhiID[8] |= Convert.ToByte("00001000", 2);
                    peizhiID[8] &= Convert.ToByte("11111011", 2);
                }
                numIOIn += 1;
            }
            if (CheckBox_ZhengIOIn2.Checked == false)
            {
                peizhiID[8] &= Convert.ToByte("11110011", 2);
            }
            if (CheckBox_ZhengIOIn3.Checked == true)  //IO输入3配置
            {
                testtypeinfo |= Convert.ToByte("00001000", 2);
                if (skinCheckBox_ZhengIOIn3.Checked == true)
                {
                    peizhiID[8] |= Convert.ToByte("00010000", 2);
                    peizhiID[8] &= Convert.ToByte("11011111", 2);
                }
                if (skinCheckBox_ZhengIOIn3.Checked == false)
                {
                    peizhiID[8] |= Convert.ToByte("00100000", 2);
                    peizhiID[8] &= Convert.ToByte("11101111", 2);
                }
                numIOIn += 1;
            }
            if (CheckBox_ZhengIOIn3.Checked == false)
            {
                peizhiID[8] &= Convert.ToByte("11001111", 2);
            }
            if (CheckBox_ZhengIOIn4.Checked == true)  //IO输入4配置
            {
                testtypeinfo |= Convert.ToByte("00001000", 2);
                if (skinCheckBox_ZhengIOIn4.Checked == true)
                {
                    peizhiID[8] |= Convert.ToByte("01000000", 2);
                    peizhiID[8] &= Convert.ToByte("01111111", 2);
                }
                if (skinCheckBox_ZhengIOIn4.Checked == false)
                {
                    peizhiID[8] |= Convert.ToByte("10000000", 2);
                    peizhiID[8] &= Convert.ToByte("10111111", 2);
                }
                numIOIn += 1;
            }
            if (CheckBox_ZhengIOIn4.Checked == false)
            {
                peizhiID[8] &= Convert.ToByte("00111111", 2);
            }
            if (CheckBox_ZhengIOIn5.Checked == true)  //IO输入5配置
            {
                testtypeinfo |= Convert.ToByte("00001000", 2);
                if (skinCheckBox_ZhengIOIn5.Checked == true)
                {
                    peizhiID[9] |= Convert.ToByte("00000001", 2);
                    peizhiID[9] &= Convert.ToByte("11111101", 2);
                }
                if (skinCheckBox_ZhengIOIn5.Checked == false)
                {
                    peizhiID[9] |= Convert.ToByte("00000010", 2);
                    peizhiID[9] &= Convert.ToByte("11111110", 2);
                }
                numIOIn += 1;
            }
            if (CheckBox_ZhengIOIn5.Checked == false)
            {
                peizhiID[9] &= Convert.ToByte("11111100", 2);
            }
            if (CheckBox_ZhengIOIn6.Checked == true)  //IO输入6配置
            {
                testtypeinfo |= Convert.ToByte("00001000", 2);
                if (skinCheckBox_ZhengIOIn6.Checked == true)
                {
                    peizhiID[9] |= Convert.ToByte("00000100", 2);
                    peizhiID[9] &= Convert.ToByte("11110111", 2);
                }
                if (skinCheckBox_ZhengIOIn6.Checked == false)
                {
                    peizhiID[9] |= Convert.ToByte("00001000", 2);
                    peizhiID[9] &= Convert.ToByte("11111011", 2);
                }
                numIOIn += 1;
            }
            if (CheckBox_ZhengIOIn6.Checked == false)
            {
                peizhiID[9] &= Convert.ToByte("11110011", 2);
            }
            if (CheckBox_ZhengIOIn7.Checked == true)  //IO输入7配置
            {
                testtypeinfo |= Convert.ToByte("00001000", 2);
                if (skinCheckBox_ZhengIOIn7.Checked == true)
                {
                    peizhiID[9] |= Convert.ToByte("00010000", 2);
                    peizhiID[9] &= Convert.ToByte("11011111", 2);
                }
                if (skinCheckBox_ZhengIOIn7.Checked == false)
                {
                    peizhiID[9] |= Convert.ToByte("00100000", 2);
                    peizhiID[9] &= Convert.ToByte("11101111", 2);
                }
                numIOIn += 1;
            }
            if (CheckBox_ZhengIOIn7.Checked == false)
            {
                peizhiID[9] &= Convert.ToByte("11001111", 2);
            }
            if (CheckBox_ZhengIOIn8.Checked == true)  //IO输入8配置
            {
                testtypeinfo |= Convert.ToByte("00001000", 2);
                if (skinCheckBox_ZhengIOIn8.Checked == true)
                {
                    peizhiID[9] |= Convert.ToByte("01000000", 2);
                    peizhiID[9] &= Convert.ToByte("01111111", 2);
                }
                if (skinCheckBox_ZhengIOIn8.Checked == false)
                {
                    peizhiID[9] |= Convert.ToByte("10000000", 2);
                    peizhiID[9] &= Convert.ToByte("10111111", 2);
                }
                numIOIn += 1;
            }
            if (CheckBox_ZhengIOIn8.Checked == false)
            {
                peizhiID[9] &= Convert.ToByte("00111111", 2);
            }
            if (CheckBox_ZhengIOIn9.Checked == true)  //IO输入9配置
            {
                testtypeinfo |= Convert.ToByte("00001000", 2);
                if (skinCheckBox_ZhengIOIn9.Checked == true)
                {
                    peizhiID[10] |= Convert.ToByte("00000001", 2);
                    peizhiID[10] &= Convert.ToByte("11111101", 2);
                }
                if (skinCheckBox_ZhengIOIn9.Checked == false)
                {
                    peizhiID[10] |= Convert.ToByte("00000010", 2);
                    peizhiID[10] &= Convert.ToByte("11111110", 2);
                }
                numIOIn += 1;
            }
            if (CheckBox_ZhengIOIn9.Checked == false)
            {
                peizhiID[10] &= Convert.ToByte("11111100", 2);
            }
            if (CheckBox_ZhengIOIn10.Checked == true)  //IO输入10配置
            {
                testtypeinfo |= Convert.ToByte("00001000", 2);
                if (skinCheckBox_ZhengIOIn10.Checked == true)
                {
                    peizhiID[10] |= Convert.ToByte("00000100", 2);
                    peizhiID[10] &= Convert.ToByte("11110111", 2);
                }
                if (skinCheckBox_ZhengIOIn10.Checked == false)
                {
                    peizhiID[10] |= Convert.ToByte("00001000", 2);
                    peizhiID[10] &= Convert.ToByte("11111011", 2);
                }
                numIOIn += 1;
            }
            if (CheckBox_ZhengIOIn10.Checked == false)
            {
                peizhiID[10] &= Convert.ToByte("11110011", 2);
            }
            if (CheckBox_ZhengIOIn11.Checked == true)  //IO输入11配置
            {
                testtypeinfo |= Convert.ToByte("00001000", 2);
                if (radioButton_ZhengIOIn11b_C.Checked == true && skinCheckBox_ZhengIOIn11.Checked == true)
                {
                    peizhiID[10] |= Convert.ToByte("00010000", 2);
                    peizhiID[10] &= Convert.ToByte("11011111", 2);
                }
                if (radioButton_ZhengIOIn11b_C.Checked == true && skinCheckBox_ZhengIOIn11.Checked == false)
                {
                    peizhiID[10] |= Convert.ToByte("00100000", 2);
                    peizhiID[10] &= Convert.ToByte("11101111", 2);
                }
                if (radioButton_ZhengIOIn11a_C.Checked == true)
                {
                    peizhiID[10] |= Convert.ToByte("00110000", 2);
                }
                numIOIn += 1;
            }
            if (CheckBox_ZhengIOIn11.Checked == false)
            {
                peizhiID[10] &= Convert.ToByte("11001111", 2);
            }
            if (CheckBox_ZhengIOIn12.Checked == true)  //IO输入12配置
            {
                testtypeinfo |= Convert.ToByte("00001000", 2);
                if (radioButton_ZhengIOIn12b_C.Checked == true && skinCheckBox_ZhengIOIn12.Checked == true)
                {
                    peizhiID[10] |= Convert.ToByte("01000000", 2);
                    peizhiID[10] &= Convert.ToByte("01111111", 2);
                }
                if (radioButton_ZhengIOIn12b_C.Checked == true && skinCheckBox_ZhengIOIn12.Checked == false)
                {
                    peizhiID[10] |= Convert.ToByte("10000000", 2);
                    peizhiID[10] &= Convert.ToByte("10111111", 2);
                }
                if (radioButton_ZhengIOIn12a_C.Checked == true)
                {
                    peizhiID[10] |= Convert.ToByte("11000000", 2);
                }
                numIOIn += 1;
            }
            if (CheckBox_ZhengIOIn12.Checked == false)
            {
                peizhiID[10] &= Convert.ToByte("00111111", 2);
            }
            if (CheckBox_ZhengIOIn13.Checked == true)  //IO输入13配置
            {
                testtypeinfo |= Convert.ToByte("00001000", 2);
                if (radioButton_ZhengIOIn13b_C.Checked == true && skinCheckBox_ZhengIOIn13.Checked == true)
                {
                    peizhiID[11] |= Convert.ToByte("00000001", 2);
                    peizhiID[11] &= Convert.ToByte("11111101", 2);
                }
                if (radioButton_ZhengIOIn13b_C.Checked == true && skinCheckBox_ZhengIOIn13.Checked == false)
                {
                    peizhiID[11] |= Convert.ToByte("00000010", 2);
                    peizhiID[11] &= Convert.ToByte("11111110", 2);
                }
                if (radioButton_ZhengIOIn13a_C.Checked == true)
                {
                    peizhiID[11] |= Convert.ToByte("00000011", 2);
                }
                numIOIn += 1;
            }
            if (CheckBox_ZhengIOIn13.Checked == false)
            {
                peizhiID[11] &= Convert.ToByte("11111100", 2);
            }
            if (CheckBox_ZhengIOIn14.Checked == true)  //IO输入14配置
            {
                testtypeinfo |= Convert.ToByte("00001000", 2);
                if (radioButton_ZhengIOIn14b_C.Checked == true && skinCheckBox_ZhengIOIn14.Checked == true)
                {
                    peizhiID[11] |= Convert.ToByte("00000100", 2);
                    peizhiID[11] &= Convert.ToByte("11110111", 2);
                }
                if (radioButton_ZhengIOIn14b_C.Checked == true && skinCheckBox_ZhengIOIn14.Checked == false)
                {
                    peizhiID[11] |= Convert.ToByte("00001000", 2);
                    peizhiID[11] &= Convert.ToByte("11111011", 2);
                }
                if (radioButton_ZhengIOIn14a_C.Checked == true)
                {
                    peizhiID[11] |= Convert.ToByte("00001100", 2);
                }
                numIOIn += 1;
            }
            if (CheckBox_ZhengIOIn14.Checked == false)
            {
                peizhiID[11] &= Convert.ToByte("11110011", 2);
            }
            if (CheckBox_ZhengIOIn15.Checked == true)  //IO输入15配置
            {
                testtypeinfo |= Convert.ToByte("00001000", 2);
                if (radioButton_ZhengIOIn15b_C.Checked == true && skinCheckBox_ZhengIOIn15.Checked == true)
                {
                    peizhiID[11] |= Convert.ToByte("00010000", 2);
                    peizhiID[11] &= Convert.ToByte("11011111", 2);
                }
                if (radioButton_ZhengIOIn15b_C.Checked == true && skinCheckBox_ZhengIOIn15.Checked == false)
                {
                    peizhiID[11] |= Convert.ToByte("00100000", 2);
                    peizhiID[11] &= Convert.ToByte("11101111", 2);
                }
                if (radioButton_ZhengIOIn15a_C.Checked == true)
                {
                    peizhiID[11] |= Convert.ToByte("00110000", 2);
                }
                numIOIn += 1;
            }
            if (CheckBox_ZhengIOIn15.Checked == false)
            {
                peizhiID[11] &= Convert.ToByte("11001111", 2);
            }
            if (CheckBox_ZhengIOIn16.Checked == true)  //IO输入16配置
            {
                testtypeinfo |= Convert.ToByte("00001000", 2);
                if (radioButton_ZhengIOIn16b_C.Checked == true && skinCheckBox_ZhengIOIn16.Checked == true)
                {
                    peizhiID[11] |= Convert.ToByte("01000000", 2);
                    peizhiID[11] &= Convert.ToByte("01111111", 2);
                }
                if (radioButton_ZhengIOIn16b_C.Checked == true && skinCheckBox_ZhengIOIn16.Checked == false)
                {
                    peizhiID[11] |= Convert.ToByte("10000000", 2);
                    peizhiID[11] &= Convert.ToByte("10111111", 2);
                }
                if (radioButton_ZhengIOIn16a_C.Checked == true)
                {
                    peizhiID[11] |= Convert.ToByte("11000000", 2);
                }
                numIOIn += 1;
            }
            if (CheckBox_ZhengIOIn16.Checked == false)
            {
                peizhiID[11] &= Convert.ToByte("00111111", 2);
            }
            if (CheckBox_ZhengIOIn17.Checked == true)  //IO输入17配置
            {
                testtypeinfo |= Convert.ToByte("00001000", 2);
                if (radioButton_ZhengIOIn17b_C.Checked == true && skinCheckBox_ZhengIOIn17.Checked == true)
                {
                    peizhiID[12] |= Convert.ToByte("00000001", 2);
                    peizhiID[12] &= Convert.ToByte("11111101", 2);
                }
                if (radioButton_ZhengIOIn17b_C.Checked == true && skinCheckBox_ZhengIOIn17.Checked == false)
                {
                    peizhiID[12] |= Convert.ToByte("00000010", 2);
                    peizhiID[12] &= Convert.ToByte("11111110", 2);
                }
                if (radioButton_ZhengIOIn17a_C.Checked == true)
                {
                    peizhiID[12] |= Convert.ToByte("00000011", 2);
                }
                numIOIn += 1;
            }
            if (CheckBox_ZhengIOIn17.Checked == false)
            {
                peizhiID[12] &= Convert.ToByte("11111100", 2);
            }
            if (CheckBox_ZhengIOIn18.Checked == true)  //IO输入18配置
            {
                testtypeinfo |= Convert.ToByte("00001000", 2);
                if (radioButton_ZhengIOIn18b_C.Checked == true && skinCheckBox_ZhengIOIn18.Checked == true)
                {
                    peizhiID[12] |= Convert.ToByte("00000100", 2);
                    peizhiID[12] &= Convert.ToByte("11110111", 2);
                }
                if (radioButton_ZhengIOIn18b_C.Checked == true && skinCheckBox_ZhengIOIn18.Checked == false)
                {
                    peizhiID[12] |= Convert.ToByte("00001000", 2);
                    peizhiID[12] &= Convert.ToByte("11111011", 2);
                }
                if (radioButton_ZhengIOIn18a_C.Checked == true)
                {
                    peizhiID[12] |= Convert.ToByte("00001100", 2);
                }
                numIOIn += 1;
            }
            if (CheckBox_ZhengIOIn18.Checked == false)
            {
                peizhiID[12] &= Convert.ToByte("11110011", 2);
            }
            if (CheckBox_ZhengIOIn19.Checked == true)  //IO输入19配置
            {
                testtypeinfo |= Convert.ToByte("00001000", 2);
                if (radioButton_ZhengIOIn19b_C.Checked == true && skinCheckBox_ZhengIOIn19.Checked == true)
                {
                    peizhiID[12] |= Convert.ToByte("00010000", 2);
                    peizhiID[12] &= Convert.ToByte("11011111", 2);
                }
                if (radioButton_ZhengIOIn19b_C.Checked == true && skinCheckBox_ZhengIOIn19.Checked == false)
                {
                    peizhiID[12] |= Convert.ToByte("00100000", 2);
                    peizhiID[12] &= Convert.ToByte("11101111", 2);
                }
                if (radioButton_ZhengIOIn19a_C.Checked == true)
                {
                    peizhiID[12] |= Convert.ToByte("00110000", 2);
                }
                numIOIn += 1;
            }
            if (CheckBox_ZhengIOIn19.Checked == false)
            {
                peizhiID[12] &= Convert.ToByte("11001111", 2);
            }
            if (CheckBox_ZhengIOIn20.Checked == true)  //IO输入20配置
            {
                testtypeinfo |= Convert.ToByte("00001000", 2);
                if (radioButton_ZhengIOIn20b_C.Checked == true && skinCheckBox_ZhengIOIn20.Checked == true)
                {
                    peizhiID[12] |= Convert.ToByte("01000000", 2);
                    peizhiID[12] &= Convert.ToByte("01111111", 2);
                }
                if (radioButton_ZhengIOIn20b_C.Checked == true && skinCheckBox_ZhengIOIn20.Checked == false)
                {
                    peizhiID[12] |= Convert.ToByte("10000000", 2);
                    peizhiID[12] &= Convert.ToByte("10111111", 2);
                }
                if (radioButton_ZhengIOIn20a_C.Checked == true)
                {
                    peizhiID[12] |= Convert.ToByte("11000000", 2);
                }
                numIOIn += 1;
            }
            if (CheckBox_ZhengIOIn20.Checked == false)
            {
                peizhiID[12] &= Convert.ToByte("00111111", 2);
            }
            if (CheckBox_ZhengIOIn21.Checked == true)  //IO输入21配置
            {
                testtypeinfo |= Convert.ToByte("00001000", 2);
                if (radioButton_ZhengIOIn21b_C.Checked == true && skinCheckBox_ZhengIOIn21.Checked == true)
                {
                    peizhiID[13] |= Convert.ToByte("00000001", 2);
                    peizhiID[13] &= Convert.ToByte("11111101", 2);
                }
                if (radioButton_ZhengIOIn21b_C.Checked == true && skinCheckBox_ZhengIOIn21.Checked == false)
                {
                    peizhiID[13] |= Convert.ToByte("00000010", 2);
                    peizhiID[13] &= Convert.ToByte("11111110", 2);
                }
                if (radioButton_ZhengIOIn21a_C.Checked == true)
                {
                    peizhiID[13] |= Convert.ToByte("00000011", 2);
                }
                numIOIn += 1;
            }
            if (CheckBox_ZhengIOIn21.Checked == false)
            {
                peizhiID[13] &= Convert.ToByte("11111100", 2);
            }
            if (CheckBox_ZhengIOIn22.Checked == true)  //IO输入22配置
            {
                testtypeinfo |= Convert.ToByte("00001000", 2);
                if (radioButton_ZhengIOIn22b_C.Checked == true && skinCheckBox_ZhengIOIn22.Checked == true)
                {
                    peizhiID[13] |= Convert.ToByte("00000100", 2);
                    peizhiID[13] &= Convert.ToByte("11110111", 2);
                }
                if (radioButton_ZhengIOIn22b_C.Checked == true && skinCheckBox_ZhengIOIn22.Checked == false)
                {
                    peizhiID[13] |= Convert.ToByte("00001000", 2);
                    peizhiID[13] &= Convert.ToByte("11111011", 2);
                }
                if (radioButton_ZhengIOIn22a_C.Checked == true)
                {
                    peizhiID[13] |= Convert.ToByte("00001100", 2);
                }
                numIOIn += 1;
            }
            if (CheckBox_ZhengIOIn22.Checked == false)
            {
                peizhiID[13] &= Convert.ToByte("11110011", 2);
            }
            if (CheckBox_ZhengIOIn23.Checked == true)  //IO输入23配置
            {
                testtypeinfo |= Convert.ToByte("00001000", 2);
                if (radioButton_ZhengIOIn23b_C.Checked == true && skinCheckBox_ZhengIOIn23.Checked == true)
                {
                    peizhiID[13] |= Convert.ToByte("00010000", 2);
                    peizhiID[13] &= Convert.ToByte("11011111", 2);
                }
                if (radioButton_ZhengIOIn23b_C.Checked == true && skinCheckBox_ZhengIOIn23.Checked == false)
                {
                    peizhiID[13] |= Convert.ToByte("00100000", 2);
                    peizhiID[13] &= Convert.ToByte("11101111", 2);
                }
                if (radioButton_ZhengIOIn23a_C.Checked == true)
                {
                    peizhiID[13] |= Convert.ToByte("00110000", 2);
                }
                numIOIn += 1;
            }
            if (CheckBox_ZhengIOIn23.Checked == false)
            {
                peizhiID[13] &= Convert.ToByte("11001111", 2);
            }
            if (CheckBox_ZhengIOIn24.Checked == true)  //IO输入24配置
            {
                testtypeinfo |= Convert.ToByte("00001000", 2);
                if (radioButton_ZhengIOIn24b_C.Checked == true && skinCheckBox_ZhengIOIn24.Checked == true)
                {
                    peizhiID[13] |= Convert.ToByte("01000000", 2);
                    peizhiID[13] &= Convert.ToByte("01111111", 2);
                }
                if (radioButton_ZhengIOIn24b_C.Checked == true && skinCheckBox_ZhengIOIn24.Checked == false)
                {
                    peizhiID[13] |= Convert.ToByte("10000000", 2);
                    peizhiID[13] &= Convert.ToByte("10111111", 2);
                }
                if (radioButton_ZhengIOIn24a_C.Checked == true)
                {
                    peizhiID[13] |= Convert.ToByte("11000000", 2);
                }
                numIOIn += 1;
            }
            if (CheckBox_ZhengIOIn24.Checked == false)
            {
                peizhiID[13] &= Convert.ToByte("00111111", 2);
            }
            if (CheckBox_ZhengIOIn25.Checked == true)  //IO输入25配置
            {
                testtypeinfo |= Convert.ToByte("00001000", 2);
                if (radioButton_ZhengIOIn25b_C.Checked == true && skinCheckBox_ZhengIOIn25.Checked == true)
                {
                    peizhiID[14] |= Convert.ToByte("00000001", 2);
                    peizhiID[14] &= Convert.ToByte("11111101", 2);
                }
                if (radioButton_ZhengIOIn25b_C.Checked == true && skinCheckBox_ZhengIOIn25.Checked == false)
                {
                    peizhiID[14] |= Convert.ToByte("00000010", 2);
                    peizhiID[14] &= Convert.ToByte("11111110", 2);
                }
                if (radioButton_ZhengIOIn25a_C.Checked == true)
                {
                    peizhiID[14] |= Convert.ToByte("00000011", 2);
                }
                numIOIn += 1;
            }
            if (CheckBox_ZhengIOIn25.Checked == false)
            {
                peizhiID[14] &= Convert.ToByte("11111100", 2);
            }
            if (CheckBox_ZhengIOIn26.Checked == true)  //IO输入26配置
            {
                testtypeinfo |= Convert.ToByte("00001000", 2);
                if (radioButton_ZhengIOIn26b_C.Checked == true && skinCheckBox_ZhengIOIn26.Checked == true)
                {
                    peizhiID[14] |= Convert.ToByte("00000100", 2);
                    peizhiID[14] &= Convert.ToByte("11110111", 2);
                }
                if (radioButton_ZhengIOIn26b_C.Checked == true && skinCheckBox_ZhengIOIn26.Checked == false)
                {
                    peizhiID[14] |= Convert.ToByte("00001000", 2);
                    peizhiID[14] &= Convert.ToByte("11111011", 2);
                }
                if (radioButton_ZhengIOIn26a_C.Checked == true)
                {
                    peizhiID[14] |= Convert.ToByte("00001100", 2);
                }
                numIOIn += 1;
            }
            if (CheckBox_ZhengIOIn26.Checked == false)
            {
                peizhiID[14] &= Convert.ToByte("11110011", 2);
            }
            if (CheckBox_ZhengDA1.Checked == true)  //DA输出1配置,0B00不测；0B01输入电压为+3.22V/+0.4096V，待测板输出电压+4V/0V；0B10主控板向待测板发送CAN指令
            {
                testtypeinfo |= Convert.ToByte("00010000", 2);
                if (skinCheckBox_ZhengDA1.Checked == true)
                {
                    peizhiID[14] |= Convert.ToByte("00010000", 2);
                    peizhiID[14] &= Convert.ToByte("11011111", 2);
                }
                if (skinCheckBox_ZhengDA1.Checked == false)
                {
                    peizhiID[14] |= Convert.ToByte("00100000", 2);
                    peizhiID[14] &= Convert.ToByte("11101111", 2);
                }
                numDA += 1;
            }
            if (CheckBox_ZhengDA1.Checked == false)
            {
                peizhiID[14] &= Convert.ToByte("11001111", 2);
            }
            if (CheckBox_ZhengDA2.Checked == true)  //DA输出2配置
            {
                testtypeinfo |= Convert.ToByte("00010000", 2);
                if (skinCheckBox_ZhengDA2.Checked == true)
                {
                    peizhiID[14] |= Convert.ToByte("01000000", 2);
                    peizhiID[14] &= Convert.ToByte("01111111", 2);
                }
                if (skinCheckBox_ZhengDA2.Checked == false)
                {
                    peizhiID[14] |= Convert.ToByte("10000000", 2);
                    peizhiID[14] &= Convert.ToByte("10111111", 2);
                }
                numDA += 1;
            }
            if (CheckBox_ZhengDA2.Checked == false)
            {
                peizhiID[14] &= Convert.ToByte("00111111", 2);
            }
            if (CheckBox_ZhengDA3.Checked == true)  //DA输出3配置
            {
                testtypeinfo |= Convert.ToByte("00010000", 2);
                if (skinCheckBox_ZhengDA3.Checked == true)
                {
                    peizhiID[15] |= Convert.ToByte("00000001", 2);
                    peizhiID[15] &= Convert.ToByte("11111101", 2);
                }
                if (skinCheckBox_ZhengDA3.Checked == false)
                {
                    peizhiID[15] |= Convert.ToByte("00000010", 2);
                    peizhiID[15] &= Convert.ToByte("11111110", 2);
                }
                numDA += 1;
            }
            if (CheckBox_ZhengDA3.Checked == false)
            {
                peizhiID[15] &= Convert.ToByte("11111100", 2);
            }
            if (CheckBox_ZhengDA4.Checked == true)  //DA输出4配置
            {
                testtypeinfo |= Convert.ToByte("00010000", 2);
                if (skinCheckBox_ZhengDA4.Checked == true)
                {
                    peizhiID[15] |= Convert.ToByte("00000100", 2);
                    peizhiID[15] &= Convert.ToByte("11110111", 2);
                }
                if (skinCheckBox_ZhengDA4.Checked == false)
                {
                    peizhiID[15] |= Convert.ToByte("00001000", 2);
                    peizhiID[15] &= Convert.ToByte("11111011", 2);
                }
                numDA += 1;
            }
            if (CheckBox_ZhengDA4.Checked == false)
            {
                peizhiID[15] &= Convert.ToByte("11110011", 2);
            }
            if (CheckBox_ZhengDA5.Checked == true)  //DA输出5配置
            {
                testtypeinfo |= Convert.ToByte("00010000", 2);
                if (skinCheckBox_ZhengDA5.Checked == true)
                {
                    peizhiID[15] |= Convert.ToByte("00010000", 2);
                    peizhiID[15] &= Convert.ToByte("11011111", 2);
                }
                if (skinCheckBox_ZhengDA5.Checked == false)
                {
                    peizhiID[15] |= Convert.ToByte("00100000", 2);
                    peizhiID[15] &= Convert.ToByte("11101111", 2);
                }
                numDA += 1;
            }
            if (CheckBox_ZhengDA5.Checked == false)
            {
                peizhiID[15] &= Convert.ToByte("11001111", 2);
            }
            if (CheckBox_ZhengDA6.Checked == true)  //DA输出6配置
            {
                testtypeinfo |= Convert.ToByte("00010000", 2);
                if (skinCheckBox_ZhengDA6.Checked == true)
                {
                    peizhiID[15] |= Convert.ToByte("01000000", 2);
                    peizhiID[15] &= Convert.ToByte("01111111", 2);
                }
                if (skinCheckBox_ZhengDA6.Checked == false)
                {
                    peizhiID[15] |= Convert.ToByte("10000000", 2);
                    peizhiID[15] &= Convert.ToByte("10111111", 2);
                }
                numDA += 1;
            }
            if (CheckBox_ZhengDA6.Checked == false)
            {
                peizhiID[15] &= Convert.ToByte("00111111", 2);
            }
            if (CheckBox_ZhengDA7.Checked == true)  //DA输出7配置
            {
                testtypeinfo |= Convert.ToByte("00010000", 2);
                if (skinCheckBox_ZhengDA7.Checked == true)
                {
                    peizhiID[16] |= Convert.ToByte("00000001", 2);
                    peizhiID[16] &= Convert.ToByte("11111101", 2);
                }
                if (skinCheckBox_ZhengDA7.Checked == false)
                {
                    peizhiID[16] |= Convert.ToByte("00000010", 2);
                    peizhiID[16] &= Convert.ToByte("11111110", 2);
                }
                numDA += 1;
            }
            if (CheckBox_ZhengDA7.Checked == false)
            {
                peizhiID[16] &= Convert.ToByte("11111100", 2);
            }
            if (CheckBox_ZhengDA8.Checked == true)  //DA输出8配置
            {
                testtypeinfo |= Convert.ToByte("00010000", 2);
                if (skinCheckBox_ZhengDA8.Checked == true)
                {
                    peizhiID[16] |= Convert.ToByte("00000100", 2);
                    peizhiID[16] &= Convert.ToByte("11110111", 2);
                }
                if (skinCheckBox_ZhengDA8.Checked == false)
                {
                    peizhiID[16] |= Convert.ToByte("00001000", 2);
                    peizhiID[16] &= Convert.ToByte("11111011", 2);
                }
                numDA += 1;
            }
            if (CheckBox_ZhengDA8.Checked == false)
            {
                peizhiID[16] &= Convert.ToByte("11110011", 2);
            }
            if (CheckBox_ZhengAD1.Checked == true)  //AD采样1配置
            {
                testtypeinfo |= Convert.ToByte("00100000", 2);
                if (skinCheckBox_ZhengAD1.Checked == true)
                {
                    peizhiID[16] |= Convert.ToByte("00010000", 2);
                    peizhiID[16] &= Convert.ToByte("11011111", 2);
                }
                if (skinCheckBox_ZhengAD1.Checked == false)
                {
                    peizhiID[16] |= Convert.ToByte("00100000", 2);
                    peizhiID[16] &= Convert.ToByte("11101111", 2);
                }
                numAD += 1;
            }
            if (CheckBox_ZhengAD1.Checked == false)
            {
                peizhiID[16] &= Convert.ToByte("11001111", 2);
            }
            if (CheckBox_ZhengAD2.Checked == true)  //AD采样2配置
            {
                testtypeinfo |= Convert.ToByte("00100000", 2);
                if (skinCheckBox_ZhengAD2.Checked == true)
                {
                    peizhiID[16] |= Convert.ToByte("01000000", 2);
                    peizhiID[16] &= Convert.ToByte("01111111", 2);
                }
                if (skinCheckBox_ZhengAD2.Checked == false)
                {
                    peizhiID[16] |= Convert.ToByte("10000000", 2);
                    peizhiID[16] &= Convert.ToByte("10111111", 2);
                }
                numAD += 1;
            }
            if (CheckBox_ZhengAD2.Checked == false)
            {
                peizhiID[16] &= Convert.ToByte("00111111", 2);
            }
            if (CheckBox_ZhengAD3.Checked == true)  //AD采样3配置
            {
                testtypeinfo |= Convert.ToByte("00100000", 2);
                if (skinCheckBox_ZhengAD3.Checked == true)
                {
                    peizhiID[17] |= Convert.ToByte("00000001", 2);
                    peizhiID[17] &= Convert.ToByte("11111101", 2);
                }
                if (skinCheckBox_ZhengAD3.Checked == false)
                {
                    peizhiID[17] |= Convert.ToByte("00000010", 2);
                    peizhiID[17] &= Convert.ToByte("11111110", 2);
                }
                numAD += 1;
            }
            if (CheckBox_ZhengAD3.Checked == false)
            {
                peizhiID[17] &= Convert.ToByte("11111100", 2);
            }
            if (CheckBox_ZhengAD4.Checked == true)  //AD采样4配置
            {
                testtypeinfo |= Convert.ToByte("00100000", 2);
                if (skinCheckBox_ZhengAD4.Checked == true)
                {
                    peizhiID[17] |= Convert.ToByte("00000100", 2);
                    peizhiID[17] &= Convert.ToByte("11110111", 2);
                }
                if (skinCheckBox_ZhengAD4.Checked == false)
                {
                    peizhiID[17] |= Convert.ToByte("00001000", 2);
                    peizhiID[17] &= Convert.ToByte("11111011", 2);
                }
                numAD += 1;
            }
            if (CheckBox_ZhengAD4.Checked == false)
            {
                peizhiID[17] &= Convert.ToByte("11110011", 2);
            }
            if (CheckBox_ZhengAD5.Checked == true)  //AD采样5配置
            {
                testtypeinfo |= Convert.ToByte("00100000", 2);
                if (skinCheckBox_ZhengAD5.Checked == true)
                {
                    peizhiID[17] |= Convert.ToByte("00010000", 2);
                    peizhiID[17] &= Convert.ToByte("11011111", 2);
                }
                if (skinCheckBox_ZhengAD5.Checked == false)
                {
                    peizhiID[17] |= Convert.ToByte("00100000", 2);
                    peizhiID[17] &= Convert.ToByte("11101111", 2);
                }
                numAD += 1;
            }
            if (CheckBox_ZhengAD5.Checked == false)
            {
                peizhiID[17] &= Convert.ToByte("11001111", 2);
            }
            if (CheckBox_ZhengAD6.Checked == true)  //AD采样6配置
            {
                testtypeinfo |= Convert.ToByte("00100000", 2);
                if (skinCheckBox_ZhengAD6.Checked == true)
                {
                    peizhiID[17] |= Convert.ToByte("01000000", 2);
                    peizhiID[17] &= Convert.ToByte("01111111", 2);
                }
                if (skinCheckBox_ZhengAD6.Checked == false)
                {
                    peizhiID[17] |= Convert.ToByte("10000000", 2);
                    peizhiID[17] &= Convert.ToByte("10111111", 2);
                }
                numAD += 1;
            }
            if (CheckBox_ZhengAD6.Checked == false)
            {
                peizhiID[17] &= Convert.ToByte("00111111", 2);
            }
            if (CheckBox_ZhengAD7.Checked == true)  //AD采样7配置
            {
                testtypeinfo |= Convert.ToByte("00100000", 2);
                if (skinCheckBox_ZhengAD7.Checked == true)
                {
                    peizhiID[18] |= Convert.ToByte("00000001", 2);
                    peizhiID[18] &= Convert.ToByte("11111101", 2);
                }
                if (skinCheckBox_ZhengAD7.Checked == false)
                {
                    peizhiID[18] |= Convert.ToByte("00000010", 2);
                    peizhiID[18] &= Convert.ToByte("11111110", 2);
                }
                numAD += 1;
            }
            if (CheckBox_ZhengAD7.Checked == false)
            {
                peizhiID[18] &= Convert.ToByte("11111100", 2);
            }
            if (CheckBox_ZhengAD8.Checked == true)  //AD采样8配置
            {
                testtypeinfo |= Convert.ToByte("00100000", 2);
                if (skinCheckBox_ZhengAD8.Checked == true)
                {
                    peizhiID[18] |= Convert.ToByte("00000100", 2);
                    peizhiID[18] &= Convert.ToByte("11110111", 2);
                }
                if (skinCheckBox_ZhengAD8.Checked == false)
                {
                    peizhiID[18] |= Convert.ToByte("00001000", 2);
                    peizhiID[18] &= Convert.ToByte("11111011", 2);
                }
                numAD += 1;
            }
            if (CheckBox_ZhengAD8.Checked == false)
            {
                peizhiID[18] &= Convert.ToByte("11110011", 2);
            }
            if (CheckBox_ZhengAD9.Checked == true)  //AD采样9配置
            {
                testtypeinfo |= Convert.ToByte("00100000", 2);
                if (skinCheckBox_ZhengAD9.Checked == true)
                {
                    peizhiID[18] |= Convert.ToByte("00010000", 2);
                    peizhiID[18] &= Convert.ToByte("11011111", 2);
                }
                if (skinCheckBox_ZhengAD9.Checked == false)
                {
                    peizhiID[18] |= Convert.ToByte("00100000", 2);
                    peizhiID[18] &= Convert.ToByte("11101111", 2);
                }
                numAD += 1;
            }
            if (CheckBox_ZhengAD9.Checked == false)
            {
                peizhiID[18] &= Convert.ToByte("11001111", 2);
            }
            if (CheckBox_ZhengAD10.Checked == true)  //AD采样10配置
            {
                testtypeinfo |= Convert.ToByte("00100000", 2);
                if (skinCheckBox_ZhengAD10.Checked == true)
                {
                    peizhiID[18] |= Convert.ToByte("01000000", 2);
                    peizhiID[18] &= Convert.ToByte("01111111", 2);
                }
                if (skinCheckBox_ZhengAD10.Checked == false)
                {
                    peizhiID[18] |= Convert.ToByte("10000000", 2);
                    peizhiID[18] &= Convert.ToByte("10111111", 2);
                }
                numAD += 1;
            }
            if (CheckBox_ZhengAD10.Checked == false)
            {
                peizhiID[18] &= Convert.ToByte("00111111", 2);
            }
            if (CheckBox_ZhengAD11.Checked == true)  //AD采样11配置
            {
                testtypeinfo |= Convert.ToByte("00100000", 2);
                if (skinCheckBox_ZhengAD11.Checked == true)
                {
                    peizhiID[19] |= Convert.ToByte("00000001", 2);
                    peizhiID[19] &= Convert.ToByte("11111101", 2);
                }
                if (skinCheckBox_ZhengAD11.Checked == false)
                {
                    peizhiID[19] |= Convert.ToByte("00000010", 2);
                    peizhiID[19] &= Convert.ToByte("11111110", 2);
                }
                numAD += 1;
            }
            if (CheckBox_ZhengAD11.Checked == false)
            {
                peizhiID[19] &= Convert.ToByte("11111100", 2);
            }
            if (CheckBox_ZhengAD12.Checked == true)  //AD采样12配置
            {
                testtypeinfo |= Convert.ToByte("00100000", 2);
                if (skinCheckBox_ZhengAD12.Checked == true)
                {
                    peizhiID[19] |= Convert.ToByte("00000100", 2);
                    peizhiID[19] &= Convert.ToByte("11110111", 2);
                }
                if (skinCheckBox_ZhengAD12.Checked == false)
                {
                    peizhiID[19] |= Convert.ToByte("00001000", 2);
                    peizhiID[19] &= Convert.ToByte("11111011", 2);
                }
                numAD += 1;
            }
            if (CheckBox_ZhengAD12.Checked == false)
            {
                peizhiID[19] &= Convert.ToByte("11110011", 2);
            }
            if (CheckBox_ZhengAD13.Checked == true)  //AD采样13配置
            {
                testtypeinfo |= Convert.ToByte("00100000", 2);
                peizhiID[19] |= Convert.ToByte("00010000", 2);
                peizhiID[19] &= Convert.ToByte("11011111", 2);
                numAD += 1;
            }
            if (CheckBox_ZhengAD13.Checked == false)
            {
                peizhiID[19] &= Convert.ToByte("11001111", 2);
            }
            if (CheckBox_ZhengAD14.Checked == true)  //AD采样14配置
            {
                testtypeinfo |= Convert.ToByte("00100000", 2);
                peizhiID[19] |= Convert.ToByte("01000000", 2);
                peizhiID[19] &= Convert.ToByte("01111111", 2);
                numAD += 1;
            }
            if (CheckBox_ZhengAD14.Checked == false)
            {
                peizhiID[19] &= Convert.ToByte("00111111", 2);
            }
            if (CheckBox_ZhengAD15.Checked == true)  //AD采样15配置
            {
                testtypeinfo |= Convert.ToByte("00100000", 2);
                peizhiID[20] |= Convert.ToByte("00000001", 2);
                peizhiID[20] &= Convert.ToByte("11111101", 2);
                numAD += 1;
            }
            if (CheckBox_ZhengAD15.Checked == false)
            {
                peizhiID[20] &= Convert.ToByte("11111100", 2);
            }
            if (CheckBox_ZhengAD16.Checked == true)  //AD采样16配置
            {
                testtypeinfo |= Convert.ToByte("00100000", 2);
                peizhiID[20] |= Convert.ToByte("00000100", 2);
                peizhiID[20] &= Convert.ToByte("11110111", 2);
                numAD += 1;
            }
            if (CheckBox_ZhengAD16.Checked == false)
            {
                peizhiID[20] &= Convert.ToByte("11110011", 2);
            }
            if (CheckBox_ZhengAD17.Checked == true)  //AD采样17配置
            {
                testtypeinfo |= Convert.ToByte("00100000", 2);
                peizhiID[20] |= Convert.ToByte("00010000", 2);
                peizhiID[20] &= Convert.ToByte("11011111", 2);
                numAD += 1;
            }
            if (CheckBox_ZhengAD17.Checked == false)
            {
                peizhiID[20] &= Convert.ToByte("11001111", 2);
            }
            if (CheckBox_ZhengAD18.Checked == true)  //AD采样18配置
            {
                testtypeinfo |= Convert.ToByte("00100000", 2);
                peizhiID[20] |= Convert.ToByte("01000000", 2);
                peizhiID[20] &= Convert.ToByte("01111111", 2);
                numAD += 1;
            }
            if (CheckBox_ZhengAD18.Checked == false)
            {
                peizhiID[20] &= Convert.ToByte("00111111", 2);
            }
            if (CheckBox_ZhengAD19.Checked == true)  //AD采样19配置
            {
                testtypeinfo |= Convert.ToByte("00100000", 2);
                peizhiID[21] |= Convert.ToByte("00000001", 2);
                peizhiID[21] &= Convert.ToByte("11111101", 2);
                numAD += 1;
            }
            if (CheckBox_ZhengAD19.Checked == false)
            {
                peizhiID[21] &= Convert.ToByte("11111100", 2);
            }
            if (CheckBox_ZhengAD20.Checked == true)  //AD采样20配置
            {
                testtypeinfo |= Convert.ToByte("00100000", 2);
                peizhiID[21] |= Convert.ToByte("00000100", 2);
                peizhiID[21] &= Convert.ToByte("11110111", 2);
                numAD += 1;
            }
            if (CheckBox_ZhengAD20.Checked == false)
            {
                peizhiID[21] &= Convert.ToByte("11110011", 2);
            }
            if (CheckBox_ZhengAD21.Checked == true)  //AD采样21配置
            {
                testtypeinfo |= Convert.ToByte("00100000", 2);
                peizhiID[21] |= Convert.ToByte("00010000", 2);
                peizhiID[21] &= Convert.ToByte("11011111", 2);
                numAD += 1;
            }
            if (CheckBox_ZhengAD21.Checked == false)
            {
                peizhiID[21] &= Convert.ToByte("11001111", 2);
            }
            if (CheckBox_ZhengAD22.Checked == true)  //AD采样22配置
            {
                testtypeinfo |= Convert.ToByte("00100000", 2);
                peizhiID[21] |= Convert.ToByte("01000000", 2);
                peizhiID[21] &= Convert.ToByte("01111111", 2);
                numAD += 1;
            }
            if (CheckBox_ZhengAD22.Checked == false)
            {
                peizhiID[21] &= Convert.ToByte("00111111", 2);
            }
            if (CheckBox_ZhengAD23.Checked == true)  //AD采样23配置
            {
                testtypeinfo |= Convert.ToByte("00100000", 2);
                peizhiID[22] |= Convert.ToByte("00000001", 2);
                peizhiID[22] &= Convert.ToByte("11111101", 2);
                numAD += 1;
            }
            if (CheckBox_ZhengAD23.Checked == false)
            {
                peizhiID[22] &= Convert.ToByte("11111100", 2);
            }
            if (CheckBox_ZhengAD24.Checked == true)  //AD采样24配置
            {
                testtypeinfo |= Convert.ToByte("00100000", 2);
                peizhiID[22] |= Convert.ToByte("00000100", 2);
                peizhiID[22] &= Convert.ToByte("11110111", 2);
                numAD += 1;
            }
            if (CheckBox_ZhengAD24.Checked == false)
            {
                peizhiID[22] &= Convert.ToByte("11110011", 2);
            }
            if (CheckBox_ZhengAD25.Checked == true)  //AD采样25配置
            {
                testtypeinfo |= Convert.ToByte("00100000", 2);
                peizhiID[22] |= Convert.ToByte("00010000", 2);
                peizhiID[22] &= Convert.ToByte("11011111", 2);
                numAD += 1;
            }
            if (CheckBox_ZhengAD25.Checked == false)
            {
                peizhiID[22] &= Convert.ToByte("11001111", 2);
            }
            if (CheckBox_ZhengAD26.Checked == true)  //AD采样26配置
            {
                testtypeinfo |= Convert.ToByte("00100000", 2);
                peizhiID[22] |= Convert.ToByte("01000000", 2);
                peizhiID[22] &= Convert.ToByte("01111111", 2);
                numAD += 1;
            }
            if (CheckBox_ZhengAD26.Checked == false)
            {
                peizhiID[22] &= Convert.ToByte("00111111", 2);
            }
            if (CheckBox_ZhengAD27.Checked == true)  //AD采样27配置
            {
                testtypeinfo |= Convert.ToByte("00100000", 2);
                peizhiID[23] |= Convert.ToByte("00000001", 2);
                peizhiID[23] &= Convert.ToByte("11111101", 2);
                numAD += 1;
            }
            if (CheckBox_ZhengAD27.Checked == false)
            {
                peizhiID[23] &= Convert.ToByte("11111100", 2);
            }
            if (CheckBox_ZhengAD28.Checked == true)  //AD采样28配置
            {
                testtypeinfo |= Convert.ToByte("00100000", 2);
                peizhiID[23] |= Convert.ToByte("00000100", 2);
                peizhiID[23] &= Convert.ToByte("11110111", 2);
                numAD += 1;
            }
            if (CheckBox_ZhengAD28.Checked == false)
            {
                peizhiID[23] &= Convert.ToByte("11110011", 2);
            }
            if (CheckBox_ZhengAD29.Checked == true)  //AD采样29配置
            {
                testtypeinfo |= Convert.ToByte("00100000", 2);
                peizhiID[23] |= Convert.ToByte("00010000", 2);
                peizhiID[23] &= Convert.ToByte("11011111", 2);
                numAD += 1;
            }
            if (CheckBox_ZhengAD29.Checked == false)
            {
                peizhiID[23] &= Convert.ToByte("11001111", 2);
            }
            if (CheckBox_ZhengAD30.Checked == true)  //AD采样30配置
            {
                testtypeinfo |= Convert.ToByte("00100000", 2);
                peizhiID[23] |= Convert.ToByte("01000000", 2);
                peizhiID[23] &= Convert.ToByte("01111111", 2);
                numAD += 1;
            }
            if (CheckBox_ZhengAD30.Checked == false)
            {
                peizhiID[23] &= Convert.ToByte("00111111", 2);
            }
            if (CheckBox_ZhengAD31.Checked == true)  //AD采样31配置
            {
                testtypeinfo |= Convert.ToByte("00100000", 2);
                peizhiID[24] |= Convert.ToByte("00000001", 2);
                peizhiID[24] &= Convert.ToByte("11111101", 2);
                numAD += 1;
            }
            if (CheckBox_ZhengAD31.Checked == false)
            {
                peizhiID[24] &= Convert.ToByte("11111100", 2);
            }
            if (CheckBox_ZhengAD32.Checked == true)  //AD采样32配置
            {
                testtypeinfo |= Convert.ToByte("00100000", 2);
                peizhiID[24] |= Convert.ToByte("00000100", 2);
                peizhiID[24] &= Convert.ToByte("11110111", 2);
                numAD += 1;
            }
            if (CheckBox_ZhengAD32.Checked == false)
            {
                peizhiID[24] &= Convert.ToByte("11110011", 2);
            }
            if (CheckBox_ZhengAD33.Checked == true)  //AD采样33配置
            {
                testtypeinfo |= Convert.ToByte("00100000", 2);
                peizhiID[24] |= Convert.ToByte("00010000", 2);
                peizhiID[24] &= Convert.ToByte("11011111", 2);
                numAD += 1;
            }
            if (CheckBox_ZhengAD33.Checked == false)
            {
                peizhiID[24] &= Convert.ToByte("11001111", 2);
            }
            if (CheckBox_ZhengAD34.Checked == true)  //AD采样34配置
            {
                testtypeinfo |= Convert.ToByte("00100000", 2);
                peizhiID[24] |= Convert.ToByte("01000000", 2);
                peizhiID[24] &= Convert.ToByte("01111111", 2);
                numAD += 1;
            }
            if (CheckBox_ZhengAD34.Checked == false)
            {
                peizhiID[24] &= Convert.ToByte("00111111", 2);
            }
            if (CheckBox_ZhengAD35.Checked == true)  //AD采样35配置
            {
                testtypeinfo |= Convert.ToByte("00100000", 2);
                peizhiID[25] |= Convert.ToByte("00000001", 2);
                peizhiID[25] &= Convert.ToByte("11111101", 2);
                numAD += 1;
            }
            if (CheckBox_ZhengAD35.Checked == false)
            {
                peizhiID[25] &= Convert.ToByte("11111100", 2);
            }
            if (CheckBox_ZhengAD36.Checked == true)  //AD采样36配置
            {
                testtypeinfo |= Convert.ToByte("00100000", 2);
                peizhiID[25] |= Convert.ToByte("00000100", 2);
                peizhiID[25] &= Convert.ToByte("11110111", 2);
                numAD += 1;
            }
            if (CheckBox_ZhengAD36.Checked == false)
            {
                peizhiID[25] &= Convert.ToByte("11110011", 2);
            }
            if (CheckBox_ZhengAD37.Checked == true)  //AD采样37配置
            {
                testtypeinfo |= Convert.ToByte("00100000", 2);
                peizhiID[25] |= Convert.ToByte("00010000", 2);
                peizhiID[25] &= Convert.ToByte("11011111", 2);
                numAD += 1;
            }
            if (CheckBox_ZhengAD37.Checked == false)
            {
                peizhiID[25] &= Convert.ToByte("11001111", 2);
            }
            if (CheckBox_ZhengAD38.Checked == true)  //AD采样38配置
            {
                testtypeinfo |= Convert.ToByte("00100000", 2);
                peizhiID[25] |= Convert.ToByte("01000000", 2);
                peizhiID[25] &= Convert.ToByte("01111111", 2);
                numAD += 1;
            }
            if (CheckBox_ZhengAD38.Checked == false)
            {
                peizhiID[25] &= Convert.ToByte("00111111", 2);
            }
            for (i = 0; i <= 25; i++)
            {
                string peizhiIDbi = Convert.ToString(peizhiID[i], 2);
                    while( peizhiIDbi.Length<8)
                    {
                        peizhiIDbi = "0" + peizhiIDbi;
                    }
                checkList.Add(peizhiIDbi);
            }
            string testtypeinfobi = Convert.ToString(testtypeinfo, 2);
                    while( testtypeinfobi.Length<8)
                {
                    testtypeinfobi = "0" + testtypeinfobi;
                }
            checkList.Add(testtypeinfobi);
            strOut = string.Join(";", checkList.ToArray());
            checkList1.Add(textBox_ZhengNote.Text);
            //短路测试表格信息
            if (CheckBox_ZhengShort1.Checked) { checkList1.Add("短路测试通道1" + ","+  textBox_ZhengShort1_Test1.Text + "," + textBox_ZhengShort1_Test2.Text + "," + textBox_ZhengShort1_Value.Text); }
            if (CheckBox_ZhengShort2.Checked) { checkList1.Add("短路测试通道2" + "," + textBox_ZhengShort2_Test1.Text + "," + textBox_ZhengShort2_Test2.Text + "," + textBox_ZhengShort2_Value.Text); }
            if (CheckBox_ZhengShort3.Checked) { checkList1.Add("短路测试通道3" + "," + textBox_ZhengShort3_Test1.Text + "," + textBox_ZhengShort3_Test2.Text + "," + textBox_ZhengShort3_Value.Text); }
            if (CheckBox_ZhengShort4.Checked) { checkList1.Add("短路测试通道4" + "," + textBox_ZhengShort4_Test1.Text + "," + textBox_ZhengShort4_Test2.Text + "," + textBox_ZhengShort4_Value.Text); }
            if (CheckBox_ZhengShort5.Checked) { checkList1.Add("短路测试通道5" + "," + textBox_ZhengShort5_Test1.Text + "," + textBox_ZhengShort5_Test2.Text + "," + textBox_ZhengShort5_Value.Text); }
            if (CheckBox_ZhengShort6.Checked) { checkList1.Add("短路测试通道6" + "," + textBox_ZhengShort6_Test1.Text + "," + textBox_ZhengShort6_Test2.Text + "," + textBox_ZhengShort6_Value.Text); }
            if (CheckBox_ZhengShort7.Checked) { checkList1.Add("短路测试通道7" + "," + textBox_ZhengShort7_Test1.Text + "," + textBox_ZhengShort7_Test2.Text + "," + textBox_ZhengShort7_Value.Text); }
            if (CheckBox_ZhengShort8.Checked) { checkList1.Add("短路测试通道8" + "," + textBox_ZhengShort8_Test1.Text + "," + textBox_ZhengShort8_Test2.Text + "," + textBox_ZhengShort8_Value.Text); }
            // 电压输出测试表格信息
            if (CheckBox_ZhengVolt1.Checked) { checkList1.Add("电压输出测试通道1" + "," + textBox_ZhengVolt1_Test1.Text + "," + textBox_ZhengVolt1_Test2.Text + "," + textBox_ZhengVolt1_Value.Text); }
            if (CheckBox_ZhengVolt2.Checked) { checkList1.Add("电压输出测试通道2" + "," + textBox_ZhengVolt2_Test1.Text + "," + textBox_ZhengVolt2_Test2.Text + "," + textBox_ZhengVolt2_Value.Text); }
            if (CheckBox_ZhengVolt3.Checked) { checkList1.Add("电压输出测试通道3" + "," + textBox_ZhengVolt3_Test1.Text + "," + textBox_ZhengVolt3_Test2.Text + "," + textBox_ZhengVolt3_Value.Text); }
            if (CheckBox_ZhengVolt4.Checked) { checkList1.Add("电压输出测试通道4" + "," + textBox_ZhengVolt4_Test1.Text + "," + textBox_ZhengVolt4_Test2.Text + "," + textBox_ZhengVolt4_Value.Text); }
            if (CheckBox_ZhengVolt5.Checked) { checkList1.Add("电压输出测试通道5" + "," + textBox_ZhengVolt5_Test1.Text + "," + textBox_ZhengVolt5_Test2.Text + "," + textBox_ZhengVolt5_Value.Text); }
            if (CheckBox_ZhengVolt6.Checked) { checkList1.Add("电压输出测试通道6" + "," + textBox_ZhengVolt6_Test1.Text + "," + textBox_ZhengVolt6_Test2.Text + "," + textBox_ZhengVolt6_Value.Text); }
            if (CheckBox_ZhengVolt7.Checked) { checkList1.Add("电压输出测试通道7" + "," + textBox_ZhengVolt7_Test1.Text + "," + textBox_ZhengVolt7_Test2.Text + "," + textBox_ZhengVolt7_Value.Text); }
            if (CheckBox_ZhengVolt8.Checked) { checkList1.Add("电压输出测试通道8" + "," + textBox_ZhengVolt8_Test1.Text + "," + textBox_ZhengVolt8_Test2.Text + "," + textBox_ZhengVolt8_Value.Text); }
            //IO输出测试表格信息
            if (CheckBox_ZhengIOOut1.Checked)
            {
                if (skinCheckBox_ZhengIOOut1.Checked)
                { checkList1.Add("I/O输出测试通道1" + "," + textBox_ZhengIOOut1_IN.Text + "," + textBox_ZhengIOOut1_Ref1.Text + "," + textBox_ZhengIOOut1_VIn1.Text + "," + textBox_ZhengIOOut1_VIn2.Text + "," + textBox_ZhengIOOut1_Test.Text + "," + textBox_ZhengIOOut1_Ref2.Text + "," + textBox_ZhengIOOut1_Value1.Text + "," + textBox_ZhengIOOut1_Value2.Text); }
                if (skinCheckBox_ZhengIOOut1.Checked == false)
                { checkList1.Add("I/O输出测试通道1" + "," + "/"+ "," + "/" + "," + "/" + "," + "/" + "," + textBox_ZhengIOOut1_Test.Text + "," + textBox_ZhengIOOut1_Ref2.Text + "," + textBox_ZhengIOOut1_Value1.Text + "," + textBox_ZhengIOOut1_Value2.Text); }
            }
            if (CheckBox_ZhengIOOut2.Checked)
            {
                if (skinCheckBox_ZhengIOOut2.Checked)
                { checkList1.Add("I/O输出测试通道2" + "," + textBox_ZhengIOOut2_IN.Text + "," + textBox_ZhengIOOut2_Ref1.Text + "," + textBox_ZhengIOOut2_VIn1.Text + "," + textBox_ZhengIOOut2_VIn2.Text + "," + textBox_ZhengIOOut2_Test.Text + "," + textBox_ZhengIOOut2_Ref2.Text + "," + textBox_ZhengIOOut2_Value1.Text + "," + textBox_ZhengIOOut2_Value2.Text); }
                if (skinCheckBox_ZhengIOOut1.Checked == false)
                { checkList1.Add("I/O输出测试通道2" + "," + "/" + "," + "/" + "," + "/" + "," + "/" + "," + textBox_ZhengIOOut2_Test.Text + "," + textBox_ZhengIOOut2_Ref2.Text + "," + textBox_ZhengIOOut2_Value1.Text + "," + textBox_ZhengIOOut2_Value2.Text); }
            }
            if (CheckBox_ZhengIOOut3.Checked)
            {
                if (skinCheckBox_ZhengIOOut3.Checked)
                { checkList1.Add("I/O输出测试通道3" + "," + textBox_ZhengIOOut3_IN.Text + "," + textBox_ZhengIOOut3_Ref1.Text + "," + textBox_ZhengIOOut3_VIn1.Text + "," + textBox_ZhengIOOut3_VIn2.Text + "," + textBox_ZhengIOOut3_Test.Text + "," + textBox_ZhengIOOut3_Ref2.Text + "," + textBox_ZhengIOOut3_Value1.Text + "," + textBox_ZhengIOOut3_Value2.Text); }
                if (skinCheckBox_ZhengIOOut1.Checked == false)
                { checkList1.Add("I/O输出测试通道3" + "," + "/" + "," + "/" + "," + "/" + "," + "/" + "," + textBox_ZhengIOOut3_Test.Text + "," + textBox_ZhengIOOut3_Ref2.Text + "," + textBox_ZhengIOOut3_Value1.Text + "," + textBox_ZhengIOOut3_Value2.Text); }
            }
            if (CheckBox_ZhengIOOut4.Checked)
            {
                if (skinCheckBox_ZhengIOOut4.Checked)
                { checkList1.Add("I/O输出测试通道4" + "," + textBox_ZhengIOOut4_IN.Text + "," + textBox_ZhengIOOut4_Ref1.Text + "," + textBox_ZhengIOOut4_VIn1.Text + "," + textBox_ZhengIOOut4_VIn2.Text + "," + textBox_ZhengIOOut4_Test.Text + "," + textBox_ZhengIOOut4_Ref2.Text + "," + textBox_ZhengIOOut4_Value1.Text + "," + textBox_ZhengIOOut4_Value2.Text); }
                if (skinCheckBox_ZhengIOOut4.Checked == false)
                { checkList1.Add("I/O输出测试通道4" + "," + "/" + "," + "/" + "," + "/" + "," + "/" + "," + textBox_ZhengIOOut4_Test.Text + "," + textBox_ZhengIOOut4_Ref2.Text + "," + textBox_ZhengIOOut4_Value1.Text + "," + textBox_ZhengIOOut4_Value2.Text); }
            }
            if (CheckBox_ZhengIOOut5.Checked)
            {
                if (skinCheckBox_ZhengIOOut5.Checked)
                { checkList1.Add("I/O输出测试通道5" + "," + textBox_ZhengIOOut5_IN.Text + "," + textBox_ZhengIOOut5_Ref1.Text + "," + textBox_ZhengIOOut5_VIn1.Text + "," + textBox_ZhengIOOut5_VIn2.Text + "," + textBox_ZhengIOOut5_Test.Text + "," + textBox_ZhengIOOut5_Ref2.Text + "," + textBox_ZhengIOOut5_Value1.Text + "," + textBox_ZhengIOOut5_Value2.Text); }
                if (skinCheckBox_ZhengIOOut5.Checked == false)
                { checkList1.Add("I/O输出测试通道5" + "," + "/" + "," + "/" + "," + "/" + "," + "/" + "," + textBox_ZhengIOOut5_Test.Text + "," + textBox_ZhengIOOut5_Ref2.Text + "," + textBox_ZhengIOOut5_Value1.Text + "," + textBox_ZhengIOOut5_Value2.Text); }
            }
            if (CheckBox_ZhengIOOut6.Checked)
            {
                if (skinCheckBox_ZhengIOOut6.Checked)
                { checkList1.Add("I/O输出测试通道6" + "," + textBox_ZhengIOOut6_IN.Text + "," + textBox_ZhengIOOut6_Ref1.Text + "," + textBox_ZhengIOOut6_VIn1.Text + "," + textBox_ZhengIOOut6_VIn2.Text + "," + textBox_ZhengIOOut6_Test.Text + "," + textBox_ZhengIOOut6_Ref2.Text + "," + textBox_ZhengIOOut6_Value1.Text + "," + textBox_ZhengIOOut6_Value2.Text); }
                if (skinCheckBox_ZhengIOOut6.Checked == false)
                { checkList1.Add("I/O输出测试通道6" + "," + "/" + "," + "/" + "," + "/" + "," + "/" + "," + textBox_ZhengIOOut6_Test.Text + "," + textBox_ZhengIOOut6_Ref2.Text + "," + textBox_ZhengIOOut6_Value1.Text + "," + textBox_ZhengIOOut6_Value2.Text); }
            }
            if (CheckBox_ZhengIOOut7.Checked)
            {
                if (skinCheckBox_ZhengIOOut7.Checked)
                { checkList1.Add("I/O输出测试通道7" + "," + textBox_ZhengIOOut7_IN.Text + "," + textBox_ZhengIOOut7_Ref1.Text + "," + textBox_ZhengIOOut7_VIn1.Text + "," + textBox_ZhengIOOut7_VIn2.Text + "," + textBox_ZhengIOOut7_Test.Text + "," + textBox_ZhengIOOut7_Ref2.Text + "," + textBox_ZhengIOOut7_Value1.Text + "," + textBox_ZhengIOOut7_Value2.Text); }
                if (skinCheckBox_ZhengIOOut7.Checked == false)
                { checkList1.Add("I/O输出测试通道7" + "," + "/" + "," + "/" + "," + "/" + "," + "/" + "," + textBox_ZhengIOOut7_Test.Text + "," + textBox_ZhengIOOut7_Ref2.Text + "," + textBox_ZhengIOOut7_Value1.Text + "," + textBox_ZhengIOOut7_Value2.Text); }
            }
            if (CheckBox_ZhengIOOut8.Checked)
            {
                if (skinCheckBox_ZhengIOOut8.Checked)
                { checkList1.Add("I/O输出测试通道8" + "," + textBox_ZhengIOOut8_IN.Text + "," + textBox_ZhengIOOut8_Ref1.Text + "," + textBox_ZhengIOOut8_VIn1.Text + "," + textBox_ZhengIOOut8_VIn2.Text + "," + textBox_ZhengIOOut8_Test.Text + "," + textBox_ZhengIOOut8_Ref2.Text + "," + textBox_ZhengIOOut8_Value1.Text + "," + textBox_ZhengIOOut8_Value2.Text); }
                if (skinCheckBox_ZhengIOOut8.Checked == false)
                { checkList1.Add("I/O输出测试通道8" + "," + "/" + "," + "/" + "," + "/" + "," + "/" + "," + textBox_ZhengIOOut8_Test.Text + "," + textBox_ZhengIOOut8_Ref2.Text + "," + textBox_ZhengIOOut8_Value1.Text + "," + textBox_ZhengIOOut8_Value2.Text); }
            }
            if (CheckBox_ZhengIOOut9.Checked)
            {
                if (skinCheckBox_ZhengIOOut9.Checked)
                { checkList1.Add("I/O输出测试通道9" + "," + textBox_ZhengIOOut9_IN.Text + "," + textBox_ZhengIOOut9_Ref1.Text + "," + textBox_ZhengIOOut9_VIn1.Text + "," + textBox_ZhengIOOut9_VIn2.Text + "," + textBox_ZhengIOOut9_Test.Text + "," + textBox_ZhengIOOut9_Ref2.Text + "," + textBox_ZhengIOOut9_Value1.Text + "," + textBox_ZhengIOOut9_Value2.Text); }
                if (skinCheckBox_ZhengIOOut9.Checked == false)
                { checkList1.Add("I/O输出测试通道9" + "," + "/ " + "," + "/" + "," + "/" + "," + "/" + "," + textBox_ZhengIOOut9_Test.Text + "," + textBox_ZhengIOOut9_Ref2.Text + "," + textBox_ZhengIOOut9_Value1.Text + "," + textBox_ZhengIOOut9_Value2.Text); }
            }
            if (CheckBox_ZhengIOOut10.Checked)
            {
                if (skinCheckBox_ZhengIOOut10.Checked)
                { checkList1.Add("I/O输出测试通道10" + "," + textBox_ZhengIOOut10_IN.Text + "," + textBox_ZhengIOOut10_Ref1.Text + "," + textBox_ZhengIOOut10_VIn1.Text + "," + textBox_ZhengIOOut10_VIn2.Text + "," + textBox_ZhengIOOut10_Test.Text + "," + textBox_ZhengIOOut10_Ref2.Text + "," + textBox_ZhengIOOut10_Value1.Text + "," + textBox_ZhengIOOut10_Value2.Text); }
                if (skinCheckBox_ZhengIOOut1.Checked == false)
                { checkList1.Add("I/O输出测试通道10" + "," + "/" + "," + "/" + "," + "/" + "," + "/" + "," + textBox_ZhengIOOut10_Test.Text + "," + textBox_ZhengIOOut10_Ref2.Text + "," + textBox_ZhengIOOut10_Value1.Text + "," + textBox_ZhengIOOut10_Value2.Text); }
            }
            if (CheckBox_ZhengIOOut11.Checked)
            {
                if (skinCheckBox_ZhengIOOut11.Checked)
                { checkList1.Add("I/O输出测试通道11" + "," + textBox_ZhengIOOut11_IN.Text + "," + textBox_ZhengIOOut11_Ref1.Text + "," + textBox_ZhengIOOut11_VIn1.Text + "," + textBox_ZhengIOOut11_VIn2.Text + "," + textBox_ZhengIOOut11_Test.Text + "," + textBox_ZhengIOOut11_Ref2.Text + "," + textBox_ZhengIOOut11_Value1.Text + "," + textBox_ZhengIOOut11_Value2.Text); }
                if (skinCheckBox_ZhengIOOut1.Checked == false)
                { checkList1.Add("I/O输出测试通道11" + "," + "/" + "," + "/" + "," + "/" + "," + "/" + "," + textBox_ZhengIOOut11_Test.Text + "," + textBox_ZhengIOOut11_Ref2.Text + "," + textBox_ZhengIOOut11_Value1.Text + "," + textBox_ZhengIOOut11_Value2.Text); }
            }
            if (CheckBox_ZhengIOOut12.Checked)
            {
                if (skinCheckBox_ZhengIOOut12.Checked)
                { checkList1.Add("I/O输出测试通道12" + "," + textBox_ZhengIOOut12_IN.Text + "," + textBox_ZhengIOOut12_Ref1.Text + "," + textBox_ZhengIOOut12_VIn1.Text + "," + textBox_ZhengIOOut12_VIn2.Text + "," + textBox_ZhengIOOut12_Test.Text + "," + textBox_ZhengIOOut12_Ref2.Text + "," + textBox_ZhengIOOut12_Value1.Text + "," + textBox_ZhengIOOut12_Value2.Text); }
                if (skinCheckBox_ZhengIOOut12.Checked == false)
                { checkList1.Add("I/O输出测试通道12" + "," + "/" + "," + "/" + "," + "/" + "," + "/" + "," + textBox_ZhengIOOut12_Test.Text + "," + textBox_ZhengIOOut12_Ref2.Text + "," + textBox_ZhengIOOut12_Value1.Text + "," + textBox_ZhengIOOut12_Value2.Text); }
            }
            if (CheckBox_ZhengIOOut13.Checked)
            {
                if (skinCheckBox_ZhengIOOut13.Checked)
                { checkList1.Add("I/O输出测试通道13" + "," + textBox_ZhengIOOut13_IN.Text + "," + textBox_ZhengIOOut13_Ref1.Text + "," + textBox_ZhengIOOut13_VIn1.Text + "," + textBox_ZhengIOOut13_VIn2.Text + "," + textBox_ZhengIOOut13_Test.Text + "," + textBox_ZhengIOOut13_Ref2.Text + "," + textBox_ZhengIOOut13_Value1.Text + "," + textBox_ZhengIOOut13_Value2.Text); }
                if (skinCheckBox_ZhengIOOut13.Checked == false)
                { checkList1.Add("I/O输出测试通道13" + "," + "/" + "," + "/" + "," + "/" + "," + "/" + "," + textBox_ZhengIOOut13_Test.Text + "," + textBox_ZhengIOOut13_Ref2.Text + "," + textBox_ZhengIOOut13_Value1.Text + "," + textBox_ZhengIOOut13_Value2.Text); }
            }
            if (CheckBox_ZhengIOOut14.Checked)
            {
                if (skinCheckBox_ZhengIOOut14.Checked)
                { checkList1.Add("I/O输出测试通道14" + "," + textBox_ZhengIOOut14_IN.Text + "," + textBox_ZhengIOOut14_Ref1.Text + "," + textBox_ZhengIOOut14_VIn1.Text + "," + textBox_ZhengIOOut14_VIn2.Text + "," + textBox_ZhengIOOut14_Test.Text + "," + textBox_ZhengIOOut14_Ref2.Text + "," + textBox_ZhengIOOut14_Value1.Text + "," + textBox_ZhengIOOut14_Value2.Text); }
                if (skinCheckBox_ZhengIOOut14.Checked == false)
                { checkList1.Add("I/O输出测试通道14" + "," + "/" + "," + "/" + "," + "/" + "," + "/" + "," + textBox_ZhengIOOut14_Test.Text + "," + textBox_ZhengIOOut14_Ref2.Text + "," + textBox_ZhengIOOut14_Value1.Text + "," + textBox_ZhengIOOut14_Value2.Text); }
            }
            if (CheckBox_ZhengIOOut15.Checked)
            {
                if (skinCheckBox_ZhengIOOut15.Checked)
                { checkList1.Add("I/O输出测试通道15" + "," + textBox_ZhengIOOut15_IN.Text + "," + textBox_ZhengIOOut15_Ref1.Text + "," + textBox_ZhengIOOut15_VIn1.Text + "," + textBox_ZhengIOOut15_VIn2.Text + "," + textBox_ZhengIOOut15_Test.Text + "," + textBox_ZhengIOOut15_Ref2.Text + "," + textBox_ZhengIOOut15_Value1.Text + "," + textBox_ZhengIOOut15_Value2.Text); }
                if (skinCheckBox_ZhengIOOut15.Checked == false)
                { checkList1.Add("I/O输出测试通道15" + "," + "/" + "," + "/" + "," + "/" + "," + "/" + "," + textBox_ZhengIOOut15_Test.Text + "," + textBox_ZhengIOOut15_Ref2.Text + "," + textBox_ZhengIOOut15_Value1.Text + "," + textBox_ZhengIOOut15_Value2.Text); }
            }
            if (CheckBox_ZhengIOOut16.Checked)
            {
                if (skinCheckBox_ZhengIOOut16.Checked)
                { checkList1.Add("I/O输出测试通道16" + "," + textBox_ZhengIOOut16_IN.Text + "," + textBox_ZhengIOOut16_Ref1.Text + "," + textBox_ZhengIOOut16_VIn1.Text + "," + textBox_ZhengIOOut16_VIn2.Text + "," + textBox_ZhengIOOut16_Test.Text + "," + textBox_ZhengIOOut16_Ref2.Text + "," + textBox_ZhengIOOut16_Value1.Text + "," + textBox_ZhengIOOut16_Value2.Text); }
                if (skinCheckBox_ZhengIOOut1.Checked == false)
                { checkList1.Add("I/O输出测试通道16" + "," + "/" + "," + "/" + "," + "/" + "," + "/" + "," + textBox_ZhengIOOut16_Test.Text + "," + textBox_ZhengIOOut16_Ref2.Text + "," + textBox_ZhengIOOut16_Value1.Text + "," + textBox_ZhengIOOut16_Value2.Text); }
            }
            //IO输入测试表格信息
            if (CheckBox_ZhengIOIn1.Checked)
            {
                if (skinCheckBox_ZhengIOIn1.Checked)
                {checkList1.Add("I/O输入测试通道1" + "," + textBox_ZhengIOIn1_IN.Text + "," + textBox_ZhengIOIn1_Ref1.Text + "," + textBox_ZhengIOIn1_VIn1.Text + "," + textBox_ZhengIOIn1_VIn2.Text + "," + textBox_ZhengIOIn1_Test.Text + "," + textBox_ZhengIOIn1_Ref2.Text + "," + textBox_ZhengIOIn1_Value1.Text + "," + textBox_ZhengIOIn1_Value2.Text); }
                if (skinCheckBox_ZhengIOIn1.Checked == false)
                {checkList1.Add("I/O输入测试通道1" + "," + textBox_ZhengIOIn1_IN.Text + "," + textBox_ZhengIOIn1_Ref1.Text + "," + textBox_ZhengIOIn1_VIn1.Text + "," + textBox_ZhengIOIn1_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengIOIn1_Value1.Text + "," + textBox_ZhengIOIn1_Value2.Text); }
            }
            if (CheckBox_ZhengIOIn2.Checked)
            {
                if (skinCheckBox_ZhengIOIn2.Checked)
                { checkList1.Add("I/O输入测试通道2" + "," + textBox_ZhengIOIn2_IN.Text + "," + textBox_ZhengIOIn2_Ref1.Text + "," + textBox_ZhengIOIn2_VIn1.Text + "," + textBox_ZhengIOIn2_VIn2.Text + "," + textBox_ZhengIOIn2_Test.Text + "," + textBox_ZhengIOIn2_Ref2.Text + "," + textBox_ZhengIOIn2_Value1.Text + "," + textBox_ZhengIOIn2_Value2.Text); }
                if (skinCheckBox_ZhengIOIn2.Checked == false)
                { checkList1.Add("I/O输入测试通道2" + "," + textBox_ZhengIOIn2_IN.Text + "," + textBox_ZhengIOIn2_Ref1.Text + "," + textBox_ZhengIOIn2_VIn1.Text + "," + textBox_ZhengIOIn2_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengIOIn2_Value1.Text + "," + textBox_ZhengIOIn2_Value2.Text); }
            }
            if (CheckBox_ZhengIOIn3.Checked)
            {
                if (skinCheckBox_ZhengIOIn3.Checked)
                { checkList1.Add("I/O输入测试通道3" + "," + textBox_ZhengIOIn3_IN.Text + "," + textBox_ZhengIOIn3_Ref1.Text + "," + textBox_ZhengIOIn3_VIn1.Text + "," + textBox_ZhengIOIn3_VIn2.Text + "," + textBox_ZhengIOIn3_Test.Text + "," + textBox_ZhengIOIn3_Ref2.Text + "," + textBox_ZhengIOIn3_Value1.Text + "," + textBox_ZhengIOIn3_Value2.Text); }
                if (skinCheckBox_ZhengIOIn3.Checked == false)
                { checkList1.Add("I/O输入测试通道3" + "," + textBox_ZhengIOIn3_IN.Text + "," + textBox_ZhengIOIn3_Ref1.Text + "," + textBox_ZhengIOIn3_VIn1.Text + "," + textBox_ZhengIOIn3_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengIOIn3_Value1.Text + "," + textBox_ZhengIOIn3_Value2.Text); }
            }
            if (CheckBox_ZhengIOIn4.Checked)
            {
                if (skinCheckBox_ZhengIOIn4.Checked)
                { checkList1.Add("I/O输入测试通道4" + "," + textBox_ZhengIOIn4_IN.Text + "," + textBox_ZhengIOIn4_Ref1.Text + "," + textBox_ZhengIOIn4_VIn1.Text + "," + textBox_ZhengIOIn4_VIn2.Text + "," + textBox_ZhengIOIn4_Test.Text + "," + textBox_ZhengIOIn4_Ref2.Text + "," + textBox_ZhengIOIn4_Value1.Text + "," + textBox_ZhengIOIn4_Value2.Text); }
                if (skinCheckBox_ZhengIOIn4.Checked == false)
                { checkList1.Add("I/O输入测试通道4" + "," + textBox_ZhengIOIn4_IN.Text + "," + textBox_ZhengIOIn4_Ref1.Text + "," + textBox_ZhengIOIn4_VIn1.Text + "," + textBox_ZhengIOIn4_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengIOIn4_Value1.Text + "," + textBox_ZhengIOIn4_Value2.Text); }
            }
            if (CheckBox_ZhengIOIn5.Checked)
            {
                if (skinCheckBox_ZhengIOIn5.Checked)
                { checkList1.Add("I/O输入测试通道5" + "," + textBox_ZhengIOIn5_IN.Text + "," + textBox_ZhengIOIn5_Ref1.Text + "," + textBox_ZhengIOIn5_VIn1.Text + "," + textBox_ZhengIOIn5_VIn2.Text + "," + textBox_ZhengIOIn5_Test.Text + "," + textBox_ZhengIOIn5_Ref2.Text + "," + textBox_ZhengIOIn5_Value1.Text + "," + textBox_ZhengIOIn5_Value2.Text); }
                if (skinCheckBox_ZhengIOIn5.Checked == false)
                { checkList1.Add("I/O输入测试通道5" + "," + textBox_ZhengIOIn5_IN.Text + "," + textBox_ZhengIOIn5_Ref1.Text + "," + textBox_ZhengIOIn5_VIn1.Text + "," + textBox_ZhengIOIn5_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengIOIn5_Value1.Text + "," + textBox_ZhengIOIn5_Value2.Text); }
            }
            if (CheckBox_ZhengIOIn6.Checked)
            {
                if (skinCheckBox_ZhengIOIn6.Checked)
                { checkList1.Add("I/O输入测试通道6" + "," + textBox_ZhengIOIn6_IN.Text + "," + textBox_ZhengIOIn6_Ref1.Text + "," + textBox_ZhengIOIn6_VIn1.Text + "," + textBox_ZhengIOIn6_VIn2.Text + "," + textBox_ZhengIOIn6_Test.Text + "," + textBox_ZhengIOIn6_Ref2.Text + "," + textBox_ZhengIOIn6_Value1.Text + "," + textBox_ZhengIOIn6_Value2.Text); }
                if (skinCheckBox_ZhengIOIn6.Checked == false)
                { checkList1.Add("I/O输入测试通道6" + "," + textBox_ZhengIOIn6_IN.Text + "," + textBox_ZhengIOIn6_Ref1.Text + "," + textBox_ZhengIOIn6_VIn1.Text + "," + textBox_ZhengIOIn6_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengIOIn6_Value1.Text + "," + textBox_ZhengIOIn6_Value2.Text); }
            }
            if (CheckBox_ZhengIOIn7.Checked)
            {
                if (skinCheckBox_ZhengIOIn7.Checked)
                { checkList1.Add("I/O输入测试通道7" + "," + textBox_ZhengIOIn7_IN.Text + "," + textBox_ZhengIOIn7_Ref1.Text + "," + textBox_ZhengIOIn7_VIn1.Text + "," + textBox_ZhengIOIn7_VIn2.Text + "," + textBox_ZhengIOIn7_Test.Text + "," + textBox_ZhengIOIn7_Ref2.Text + "," + textBox_ZhengIOIn7_Value1.Text + "," + textBox_ZhengIOIn7_Value2.Text); }
                if (skinCheckBox_ZhengIOIn7.Checked == false)
                { checkList1.Add("I/O输入测试通道7" + "," + textBox_ZhengIOIn7_IN.Text + "," + textBox_ZhengIOIn7_Ref1.Text + "," + textBox_ZhengIOIn7_VIn1.Text + "," + textBox_ZhengIOIn7_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengIOIn7_Value1.Text + "," + textBox_ZhengIOIn7_Value2.Text); }
            }
            if (CheckBox_ZhengIOIn8.Checked)
            {
                if (skinCheckBox_ZhengIOIn8.Checked)
                { checkList1.Add("I/O输入测试通道8" + "," + textBox_ZhengIOIn8_IN.Text + "," + textBox_ZhengIOIn8_Ref1.Text + "," + textBox_ZhengIOIn8_VIn1.Text + "," + textBox_ZhengIOIn8_VIn2.Text + "," + textBox_ZhengIOIn8_Test.Text + "," + textBox_ZhengIOIn8_Ref2.Text + "," + textBox_ZhengIOIn8_Value1.Text + "," + textBox_ZhengIOIn8_Value2.Text); }
                if (skinCheckBox_ZhengIOIn8.Checked == false)
                { checkList1.Add("I/O输入测试通道8" + "," + textBox_ZhengIOIn8_IN.Text + "," + textBox_ZhengIOIn8_Ref1.Text + "," + textBox_ZhengIOIn8_VIn1.Text + "," + textBox_ZhengIOIn8_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengIOIn8_Value1.Text + "," + textBox_ZhengIOIn8_Value2.Text); }
            }
            if (CheckBox_ZhengIOIn9.Checked)
            {
                if (skinCheckBox_ZhengIOIn9.Checked)
                { checkList1.Add("I/O输入测试通道9" + "," + textBox_ZhengIOIn9_IN.Text + "," + textBox_ZhengIOIn9_Ref1.Text + "," + textBox_ZhengIOIn9_VIn1.Text + "," + textBox_ZhengIOIn9_VIn2.Text + "," + textBox_ZhengIOIn9_Test.Text + "," + textBox_ZhengIOIn9_Ref2.Text + "," + textBox_ZhengIOIn9_Value1.Text + "," + textBox_ZhengIOIn9_Value2.Text); }
                if (skinCheckBox_ZhengIOIn9.Checked == false)
                { checkList1.Add("I/O输入测试通道9" + "," + textBox_ZhengIOIn9_IN.Text + "," + textBox_ZhengIOIn9_Ref1.Text + "," + textBox_ZhengIOIn9_VIn1.Text + "," + textBox_ZhengIOIn9_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengIOIn9_Value1.Text + "," + textBox_ZhengIOIn9_Value2.Text); }
            }
            if (CheckBox_ZhengIOIn10.Checked)
            {
                if (skinCheckBox_ZhengIOIn10.Checked)
                { checkList1.Add("I/O输入测试通道10" + "," + textBox_ZhengIOIn10_IN.Text + "," + textBox_ZhengIOIn10_Ref1.Text + "," + textBox_ZhengIOIn10_VIn1.Text + "," + textBox_ZhengIOIn10_VIn2.Text + "," + textBox_ZhengIOIn10_Test.Text + "," + textBox_ZhengIOIn10_Ref2.Text + "," + textBox_ZhengIOIn10_Value1.Text + "," + textBox_ZhengIOIn10_Value2.Text); }
                if (skinCheckBox_ZhengIOIn10.Checked == false)
                { checkList1.Add("I/O输入测试通道10" + "," + textBox_ZhengIOIn10_IN.Text + "," + textBox_ZhengIOIn10_Ref1.Text + "," + textBox_ZhengIOIn10_VIn1.Text + "," + textBox_ZhengIOIn10_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengIOIn10_Value1.Text + "," + textBox_ZhengIOIn10_Value2.Text); }
            }
            if (CheckBox_ZhengIOIn11.Checked)
            {
                if (radioButton_ZhengIOIn11a_C.Checked)
                { checkList1.Add("I/O输入测试通道11" + "," + textBox_ZhengIOIn11_IN.Text + "," + textBox_ZhengIOIn11_Ref1.Text + "," + textBox_ZhengIOIn11_VIn1.Text + "," + textBox_ZhengIOIn11_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengIOIn11_Value1.Text + "," + textBox_ZhengIOIn11_Value2.Text); }
                if (radioButton_ZhengIOIn11b_C.Checked)
                {
                    if (skinCheckBox_ZhengIOIn11.Checked)
                    { checkList1.Add("I/O输入测试通道11" + "," + textBox_ZhengIOIn11_IN.Text + "," + textBox_ZhengIOIn11_Ref1.Text + "," + textBox_ZhengIOIn11b_VIn1.Text + "," + textBox_ZhengIOIn11b_VIn2.Text + "," + textBox_ZhengIOIn11_Test.Text + "," + textBox_ZhengIOIn11_Ref2.Text + "," + textBox_ZhengIOIn11_Value1.Text + "," + textBox_ZhengIOIn11_Value2.Text); }
                    if (skinCheckBox_ZhengIOIn11.Checked == false)
                    { checkList1.Add("I/O输入测试通道11" + "," + textBox_ZhengIOIn11_IN.Text + "," + textBox_ZhengIOIn11_Ref1.Text + "," + textBox_ZhengIOIn11b_VIn1.Text + "," + textBox_ZhengIOIn11b_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengIOIn11_Value1.Text + "," + textBox_ZhengIOIn11_Value2.Text); }
                }
            }
            if (CheckBox_ZhengIOIn12.Checked)
            {
                if (radioButton_ZhengIOIn12a_C.Checked)
                { checkList1.Add("I/O输入测试通道12" + "," + textBox_ZhengIOIn12_IN.Text + "," + textBox_ZhengIOIn12_Ref1.Text + "," + textBox_ZhengIOIn12_VIn1.Text + "," + textBox_ZhengIOIn12_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengIOIn12_Value1.Text + "," + textBox_ZhengIOIn12_Value2.Text); }
                if (radioButton_ZhengIOIn12b_C.Checked)
                {
                    if (skinCheckBox_ZhengIOIn12.Checked)
                    { checkList1.Add("I/O输入测试通道12" + "," + textBox_ZhengIOIn12_IN.Text + "," + textBox_ZhengIOIn12_Ref1.Text + "," + textBox_ZhengIOIn12b_VIn1.Text + "," + textBox_ZhengIOIn12b_VIn2.Text + "," + textBox_ZhengIOIn12_Test.Text + "," + textBox_ZhengIOIn12_Ref2.Text + "," + textBox_ZhengIOIn12_Value1.Text + "," + textBox_ZhengIOIn12_Value2.Text); }
                    if (skinCheckBox_ZhengIOIn12.Checked == false)
                    { checkList1.Add("I/O输入测试通道12" + "," + textBox_ZhengIOIn12_IN.Text + "," + textBox_ZhengIOIn12_Ref1.Text + "," + textBox_ZhengIOIn12b_VIn1.Text + "," + textBox_ZhengIOIn12b_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengIOIn12_Value1.Text + "," + textBox_ZhengIOIn12_Value2.Text); }
                }
            }
            if (CheckBox_ZhengIOIn13.Checked)
            {
                if (radioButton_ZhengIOIn13a_C.Checked)
                { checkList1.Add("I/O输入测试通道13" + "," + textBox_ZhengIOIn13_IN.Text + "," + textBox_ZhengIOIn13_Ref1.Text + "," + textBox_ZhengIOIn13_VIn1.Text + "," + textBox_ZhengIOIn13_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengIOIn13_Value1.Text + "," + textBox_ZhengIOIn13_Value2.Text); }
                if (radioButton_ZhengIOIn13b_C.Checked)
                {
                    if (skinCheckBox_ZhengIOIn13.Checked)
                    { checkList1.Add("I/O输入测试通道13" + "," + textBox_ZhengIOIn13_IN.Text + "," + textBox_ZhengIOIn13_Ref1.Text + "," + textBox_ZhengIOIn13b_VIn1.Text + "," + textBox_ZhengIOIn13b_VIn2.Text + "," + textBox_ZhengIOIn13_Test.Text + "," + textBox_ZhengIOIn13_Ref2.Text + "," + textBox_ZhengIOIn13_Value1.Text + "," + textBox_ZhengIOIn13_Value2.Text); }
                    if (skinCheckBox_ZhengIOIn13.Checked == false)
                    { checkList1.Add("I/O输入测试通道13" + "," + textBox_ZhengIOIn13_IN.Text + "," + textBox_ZhengIOIn13_Ref1.Text + "," + textBox_ZhengIOIn13b_VIn1.Text + "," + textBox_ZhengIOIn13b_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengIOIn13_Value1.Text + "," + textBox_ZhengIOIn13_Value2.Text); }
                }
            }
            if (CheckBox_ZhengIOIn14.Checked)
            {
                if (radioButton_ZhengIOIn14a_C.Checked)
                { checkList1.Add("I/O输入测试通道14" + "," + textBox_ZhengIOIn14_IN.Text + "," + textBox_ZhengIOIn14_Ref1.Text + "," + textBox_ZhengIOIn14_VIn1.Text + "," + textBox_ZhengIOIn14_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengIOIn14_Value1.Text + "," + textBox_ZhengIOIn14_Value2.Text); }
                if (radioButton_ZhengIOIn14b_C.Checked)
                {
                    if (skinCheckBox_ZhengIOIn14.Checked)
                    { checkList1.Add("I/O输入测试通道14" + "," + textBox_ZhengIOIn14_IN.Text + "," + textBox_ZhengIOIn14_Ref1.Text + "," + textBox_ZhengIOIn14b_VIn1.Text + "," + textBox_ZhengIOIn14b_VIn2.Text + "," + textBox_ZhengIOIn14_Test.Text + "," + textBox_ZhengIOIn14_Ref2.Text + "," + textBox_ZhengIOIn14_Value1.Text + "," + textBox_ZhengIOIn14_Value2.Text); }
                    if (skinCheckBox_ZhengIOIn14.Checked == false)
                    { checkList1.Add("I/O输入测试通道14" + "," + textBox_ZhengIOIn14_IN.Text + "," + textBox_ZhengIOIn14_Ref1.Text + "," + textBox_ZhengIOIn14b_VIn1.Text + "," + textBox_ZhengIOIn14b_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengIOIn14_Value1.Text + "," + textBox_ZhengIOIn14_Value2.Text); }
                }
            }
            if (CheckBox_ZhengIOIn15.Checked)
            {
                if (radioButton_ZhengIOIn15a_C.Checked)
                { checkList1.Add("I/O输入测试通道15" + "," + textBox_ZhengIOIn15_IN.Text + "," + textBox_ZhengIOIn15_Ref1.Text + "," + textBox_ZhengIOIn15_VIn1.Text + "," + textBox_ZhengIOIn15_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengIOIn15_Value1.Text + "," + textBox_ZhengIOIn15_Value2.Text); }
                if (radioButton_ZhengIOIn15b_C.Checked)
                {
                    if (skinCheckBox_ZhengIOIn15.Checked)
                    { checkList1.Add("I/O输入测试通道15" + "," + textBox_ZhengIOIn15_IN.Text + "," + textBox_ZhengIOIn15_Ref1.Text + "," + textBox_ZhengIOIn15b_VIn1.Text + "," + textBox_ZhengIOIn15b_VIn2.Text + "," + textBox_ZhengIOIn15_Test.Text + "," + textBox_ZhengIOIn15_Ref2.Text + "," + textBox_ZhengIOIn15_Value1.Text + "," + textBox_ZhengIOIn15_Value2.Text); }
                    if (skinCheckBox_ZhengIOIn15.Checked == false)
                    { checkList1.Add("I/O输入测试通道15" + "," + textBox_ZhengIOIn15_IN.Text + "," + textBox_ZhengIOIn15_Ref1.Text + "," + textBox_ZhengIOIn15b_VIn1.Text + "," + textBox_ZhengIOIn15b_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengIOIn15_Value1.Text + "," + textBox_ZhengIOIn15_Value2.Text); }
                }
            }
            if (CheckBox_ZhengIOIn16.Checked)
            {
                if (radioButton_ZhengIOIn16a_C.Checked)
                { checkList1.Add("I/O输入测试通道16" + "," + textBox_ZhengIOIn16_IN.Text + "," + textBox_ZhengIOIn16_Ref1.Text + "," + textBox_ZhengIOIn16_VIn1.Text + "," + textBox_ZhengIOIn16_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengIOIn16_Value1.Text + "," + textBox_ZhengIOIn16_Value2.Text); }
                if (radioButton_ZhengIOIn16b_C.Checked)
                {
                    if (skinCheckBox_ZhengIOIn16.Checked)
                    { checkList1.Add("I/O输入测试通道16" + "," + textBox_ZhengIOIn16_IN.Text + "," + textBox_ZhengIOIn16_Ref1.Text + "," + textBox_ZhengIOIn16b_VIn1.Text + "," + textBox_ZhengIOIn16b_VIn2.Text + "," + textBox_ZhengIOIn16_Test.Text + "," + textBox_ZhengIOIn16_Ref2.Text + "," + textBox_ZhengIOIn16_Value1.Text + "," + textBox_ZhengIOIn16_Value2.Text); }
                    if (skinCheckBox_ZhengIOIn16.Checked == false)
                    { checkList1.Add("I/O输入测试通道16" + "," + textBox_ZhengIOIn16_IN.Text + "," + textBox_ZhengIOIn16_Ref1.Text + "," + textBox_ZhengIOIn16b_VIn1.Text + "," + textBox_ZhengIOIn16b_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengIOIn16_Value1.Text + "," + textBox_ZhengIOIn16_Value2.Text); }
                }
            }
            if (CheckBox_ZhengIOIn17.Checked)
            {
                if (radioButton_ZhengIOIn17a_C.Checked)
                { checkList1.Add("I/O输入测试通道17" + "," + textBox_ZhengIOIn17_IN.Text + "," + textBox_ZhengIOIn17_Ref1.Text + "," + textBox_ZhengIOIn17_VIn1.Text + "," + textBox_ZhengIOIn17_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengIOIn17_Value1.Text + "," + textBox_ZhengIOIn17_Value2.Text); }
                if (radioButton_ZhengIOIn17b_C.Checked)
                {
                    if (skinCheckBox_ZhengIOIn17.Checked)
                    { checkList1.Add("I/O输入测试通道17" + "," + textBox_ZhengIOIn17_IN.Text + "," + textBox_ZhengIOIn17_Ref1.Text + "," + textBox_ZhengIOIn17b_VIn1.Text + "," + textBox_ZhengIOIn17b_VIn2.Text + "," + textBox_ZhengIOIn17_Test.Text + "," + textBox_ZhengIOIn17_Ref2.Text + "," + textBox_ZhengIOIn17_Value1.Text + "," + textBox_ZhengIOIn17_Value2.Text); }
                    if (skinCheckBox_ZhengIOIn17.Checked == false)
                    { checkList1.Add("I/O输入测试通道17" + "," + textBox_ZhengIOIn17_IN.Text + "," + textBox_ZhengIOIn17_Ref1.Text + "," + textBox_ZhengIOIn17b_VIn1.Text + "," + textBox_ZhengIOIn17b_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengIOIn17_Value1.Text + "," + textBox_ZhengIOIn17_Value2.Text); }
                }
            }
            if (CheckBox_ZhengIOIn18.Checked)
            {
                if (radioButton_ZhengIOIn18a_C.Checked)
                { checkList1.Add("I/O输入测试通道18" + "," + textBox_ZhengIOIn18_IN.Text + "," + textBox_ZhengIOIn18_Ref1.Text + "," + textBox_ZhengIOIn18_VIn1.Text + "," + textBox_ZhengIOIn18_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengIOIn18_Value1.Text + "," + textBox_ZhengIOIn18_Value2.Text); }
                if (radioButton_ZhengIOIn18b_C.Checked)
                {
                    if (skinCheckBox_ZhengIOIn18.Checked)
                    { checkList1.Add("I/O输入测试通道18" + "," + textBox_ZhengIOIn18_IN.Text + "," + textBox_ZhengIOIn18_Ref1.Text + "," + textBox_ZhengIOIn18b_VIn1.Text + "," + textBox_ZhengIOIn18b_VIn2.Text + "," + textBox_ZhengIOIn18_Test.Text + "," + textBox_ZhengIOIn18_Ref2.Text + "," + textBox_ZhengIOIn18_Value1.Text + "," + textBox_ZhengIOIn18_Value2.Text); }
                    if (skinCheckBox_ZhengIOIn18.Checked == false)
                    { checkList1.Add("I/O输入测试通道18" + "," + textBox_ZhengIOIn18_IN.Text + "," + textBox_ZhengIOIn18_Ref1.Text + "," + textBox_ZhengIOIn18b_VIn1.Text + "," + textBox_ZhengIOIn18b_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengIOIn18_Value1.Text + "," + textBox_ZhengIOIn18_Value2.Text); }
                }
            }
            if (CheckBox_ZhengIOIn19.Checked)
            {
                if (radioButton_ZhengIOIn19a_C.Checked)
                { checkList1.Add("I/O输入测试通道19" + "," + textBox_ZhengIOIn19_IN.Text + "," + textBox_ZhengIOIn19_Ref1.Text + "," + textBox_ZhengIOIn19_VIn1.Text + "," + textBox_ZhengIOIn19_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengIOIn19_Value1.Text + "," + textBox_ZhengIOIn19_Value2.Text); }
                if (radioButton_ZhengIOIn19b_C.Checked)
                {
                    if (skinCheckBox_ZhengIOIn19.Checked)
                    { checkList1.Add("I/O输入测试通道19" + "," + textBox_ZhengIOIn19_IN.Text + "," + textBox_ZhengIOIn19_Ref1.Text + "," + textBox_ZhengIOIn19b_VIn1.Text + "," + textBox_ZhengIOIn19b_VIn2.Text + "," + textBox_ZhengIOIn19_Test.Text + "," + textBox_ZhengIOIn19_Ref2.Text + "," + textBox_ZhengIOIn19_Value1.Text + "," + textBox_ZhengIOIn19_Value2.Text); }
                    if (skinCheckBox_ZhengIOIn19.Checked == false)
                    { checkList1.Add("I/O输入测试通道19" + "," + textBox_ZhengIOIn19_IN.Text + "," + textBox_ZhengIOIn19_Ref1.Text + "," + textBox_ZhengIOIn19b_VIn1.Text + "," + textBox_ZhengIOIn19b_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengIOIn19_Value1.Text + "," + textBox_ZhengIOIn19_Value2.Text); }
                }
            }
            if (CheckBox_ZhengIOIn20.Checked)
            {
                if (radioButton_ZhengIOIn20a_C.Checked)
                { checkList1.Add("I/O输入测试通道20" + "," + textBox_ZhengIOIn20_IN.Text + "," + textBox_ZhengIOIn20_Ref1.Text + "," + textBox_ZhengIOIn20_VIn1.Text + "," + textBox_ZhengIOIn20_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengIOIn20_Value1.Text + "," + textBox_ZhengIOIn20_Value2.Text); }
                if (radioButton_ZhengIOIn20b_C.Checked)
                {
                    if (skinCheckBox_ZhengIOIn20.Checked)
                    { checkList1.Add("I/O输入测试通道20" + "," + textBox_ZhengIOIn20_IN.Text + "," + textBox_ZhengIOIn20_Ref1.Text + "," + textBox_ZhengIOIn20b_VIn1.Text + "," + textBox_ZhengIOIn20b_VIn2.Text + "," + textBox_ZhengIOIn20_Test.Text + "," + textBox_ZhengIOIn20_Ref2.Text + "," + textBox_ZhengIOIn20_Value1.Text + "," + textBox_ZhengIOIn20_Value2.Text); }
                    if (skinCheckBox_ZhengIOIn20.Checked == false)
                    { checkList1.Add("I/O输入测试通道20" + "," + textBox_ZhengIOIn20_IN.Text + "," + textBox_ZhengIOIn20_Ref1.Text + "," + textBox_ZhengIOIn20b_VIn1.Text + "," + textBox_ZhengIOIn20b_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengIOIn20_Value1.Text + "," + textBox_ZhengIOIn20_Value2.Text); }
                }
            }
            if (CheckBox_ZhengIOIn21.Checked)
            {
                if (radioButton_ZhengIOIn21a_C.Checked)
                { checkList1.Add("I/O输入测试通道21" + "," + textBox_ZhengIOIn21_IN.Text + "," + textBox_ZhengIOIn21_Ref1.Text + "," + textBox_ZhengIOIn21_VIn1.Text + "," + textBox_ZhengIOIn21_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengIOIn21_Value1.Text + "," + textBox_ZhengIOIn21_Value2.Text); }
                if (radioButton_ZhengIOIn21b_C.Checked)
                {
                    if (skinCheckBox_ZhengIOIn21.Checked)
                    { checkList1.Add("I/O输入测试通道21" + "," + textBox_ZhengIOIn21_IN.Text + "," + textBox_ZhengIOIn21_Ref1.Text + "," + textBox_ZhengIOIn21b_VIn1.Text + "," + textBox_ZhengIOIn21b_VIn2.Text + "," + textBox_ZhengIOIn21_Test.Text + "," + textBox_ZhengIOIn21_Ref2.Text + "," + textBox_ZhengIOIn21_Value1.Text + "," + textBox_ZhengIOIn21_Value2.Text); }
                    if (skinCheckBox_ZhengIOIn21.Checked == false)
                    { checkList1.Add("I/O输入测试通道21" + "," + textBox_ZhengIOIn21_IN.Text + "," + textBox_ZhengIOIn21_Ref1.Text + "," + textBox_ZhengIOIn21b_VIn1.Text + "," + textBox_ZhengIOIn21b_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengIOIn21_Value1.Text + "," + textBox_ZhengIOIn21_Value2.Text); }
                }
            }
            if (CheckBox_ZhengIOIn22.Checked)
            {
                if (radioButton_ZhengIOIn22a_C.Checked)
                { checkList1.Add("I/O输入测试通道22" + "," + textBox_ZhengIOIn22_IN.Text + "," + textBox_ZhengIOIn22_Ref1.Text + "," + textBox_ZhengIOIn22_VIn1.Text + "," + textBox_ZhengIOIn22_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengIOIn22_Value1.Text + "," + textBox_ZhengIOIn22_Value2.Text); }
                if (radioButton_ZhengIOIn22b_C.Checked)
                {
                    if (skinCheckBox_ZhengIOIn22.Checked)
                    { checkList1.Add("I/O输入测试通道22" + "," + textBox_ZhengIOIn22_IN.Text + "," + textBox_ZhengIOIn22_Ref1.Text + "," + textBox_ZhengIOIn22b_VIn1.Text + "," + textBox_ZhengIOIn22b_VIn2.Text + "," + textBox_ZhengIOIn22_Test.Text + "," + textBox_ZhengIOIn22_Ref2.Text + "," + textBox_ZhengIOIn22_Value1.Text + "," + textBox_ZhengIOIn22_Value2.Text); }
                    if (skinCheckBox_ZhengIOIn22.Checked == false)
                    { checkList1.Add("I/O输入测试通道22" + "," + textBox_ZhengIOIn22_IN.Text + "," + textBox_ZhengIOIn22_Ref1.Text + "," + textBox_ZhengIOIn22b_VIn1.Text + "," + textBox_ZhengIOIn22b_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengIOIn22_Value1.Text + "," + textBox_ZhengIOIn22_Value2.Text); }
                }
            }
            if (CheckBox_ZhengIOIn23.Checked)
            {
                if (radioButton_ZhengIOIn23a_C.Checked)
                { checkList1.Add("I/O输入测试通道23" + "," + textBox_ZhengIOIn23_IN.Text + "," + textBox_ZhengIOIn23_Ref1.Text + "," + textBox_ZhengIOIn23_VIn1.Text + "," + textBox_ZhengIOIn23_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengIOIn23_Value1.Text + "," + textBox_ZhengIOIn23_Value2.Text); }
                if (radioButton_ZhengIOIn23b_C.Checked)
                {
                    if (skinCheckBox_ZhengIOIn23.Checked)
                    { checkList1.Add("I/O输入测试通道23" + "," + textBox_ZhengIOIn23_IN.Text + "," + textBox_ZhengIOIn23_Ref1.Text + "," + textBox_ZhengIOIn23b_VIn1.Text + "," + textBox_ZhengIOIn23b_VIn2.Text + "," + textBox_ZhengIOIn23_Test.Text + "," + textBox_ZhengIOIn23_Ref2.Text + "," + textBox_ZhengIOIn23_Value1.Text + "," + textBox_ZhengIOIn23_Value2.Text); }
                    if (skinCheckBox_ZhengIOIn23.Checked == false)
                    { checkList1.Add("I/O输入测试通道23" + "," + textBox_ZhengIOIn23_IN.Text + "," + textBox_ZhengIOIn23_Ref1.Text + "," + textBox_ZhengIOIn23b_VIn1.Text + "," + textBox_ZhengIOIn23b_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengIOIn23_Value1.Text + "," + textBox_ZhengIOIn23_Value2.Text); }
                }
            }
            if (CheckBox_ZhengIOIn24.Checked)
            {
                if (radioButton_ZhengIOIn24a_C.Checked)
                { checkList1.Add("I/O输入测试通道24" + "," + textBox_ZhengIOIn24_IN.Text + "," + textBox_ZhengIOIn24_Ref1.Text + "," + textBox_ZhengIOIn24_VIn1.Text + "," + textBox_ZhengIOIn24_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengIOIn24_Value1.Text + "," + textBox_ZhengIOIn24_Value2.Text); }
                if (radioButton_ZhengIOIn24b_C.Checked)
                {
                    if (skinCheckBox_ZhengIOIn24.Checked)
                    { checkList1.Add("I/O输入测试通道24" + "," + textBox_ZhengIOIn24_IN.Text + "," + textBox_ZhengIOIn24_Ref1.Text + "," + textBox_ZhengIOIn24b_VIn1.Text + "," + textBox_ZhengIOIn24b_VIn2.Text + "," + textBox_ZhengIOIn24_Test.Text + "," + textBox_ZhengIOIn24_Ref2.Text + "," + textBox_ZhengIOIn24_Value1.Text + "," + textBox_ZhengIOIn24_Value2.Text); }
                    if (skinCheckBox_ZhengIOIn24.Checked == false)
                    { checkList1.Add("I/O输入测试通道24" + "," + textBox_ZhengIOIn24_IN.Text + "," + textBox_ZhengIOIn24_Ref1.Text + "," + textBox_ZhengIOIn24b_VIn1.Text + "," + textBox_ZhengIOIn24b_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengIOIn24_Value1.Text + "," + textBox_ZhengIOIn24_Value2.Text); }
                }
            }
            if (CheckBox_ZhengIOIn25.Checked)
            {
                if (radioButton_ZhengIOIn25a_C.Checked)
                { checkList1.Add("I/O输入测试通道25" + "," + textBox_ZhengIOIn25_IN.Text + "," + textBox_ZhengIOIn25_Ref1.Text + "," + textBox_ZhengIOIn25_VIn1.Text + "," + textBox_ZhengIOIn25_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengIOIn25_Value1.Text + "," + textBox_ZhengIOIn25_Value2.Text); }
                if (radioButton_ZhengIOIn25b_C.Checked)
                {
                    if (skinCheckBox_ZhengIOIn25.Checked)
                    { checkList1.Add("I/O输入测试通道25" + "," + textBox_ZhengIOIn25_IN.Text + "," + textBox_ZhengIOIn25_Ref1.Text + "," + textBox_ZhengIOIn25b_VIn1.Text + "," + textBox_ZhengIOIn25b_VIn2.Text + "," + textBox_ZhengIOIn25_Test.Text + "," + textBox_ZhengIOIn25_Ref2.Text + "," + textBox_ZhengIOIn25_Value1.Text + "," + textBox_ZhengIOIn25_Value2.Text); }
                    if (skinCheckBox_ZhengIOIn25.Checked == false)
                    { checkList1.Add("I/O输入测试通道25" + "," + textBox_ZhengIOIn25_IN.Text + "," + textBox_ZhengIOIn25_Ref1.Text + "," + textBox_ZhengIOIn25b_VIn1.Text + "," + textBox_ZhengIOIn25b_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengIOIn25_Value1.Text + "," + textBox_ZhengIOIn25_Value2.Text); }
                }
            }
            if (CheckBox_ZhengIOIn26.Checked)
            {
                if (radioButton_ZhengIOIn26a_C.Checked)
                { checkList1.Add("I/O输入测试通道26" + "," + textBox_ZhengIOIn26_IN.Text + "," + textBox_ZhengIOIn26_Ref1.Text + "," + textBox_ZhengIOIn26_VIn1.Text + "," + textBox_ZhengIOIn26_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengIOIn26_Value1.Text + "," + textBox_ZhengIOIn26_Value2.Text); }
                if (radioButton_ZhengIOIn26b_C.Checked)
                {
                    if (skinCheckBox_ZhengIOIn26.Checked)
                    { checkList1.Add("I/O输入测试通道26" + "," + textBox_ZhengIOIn26_IN.Text + "," + textBox_ZhengIOIn26_Ref1.Text + "," + textBox_ZhengIOIn26b_VIn1.Text + "," + textBox_ZhengIOIn26b_VIn2.Text + "," + textBox_ZhengIOIn26_Test.Text + "," + textBox_ZhengIOIn26_Ref2.Text + "," + textBox_ZhengIOIn26_Value1.Text + "," + textBox_ZhengIOIn26_Value2.Text); }
                    if (skinCheckBox_ZhengIOIn26.Checked == false)
                    { checkList1.Add("I/O输入测试通道26" + "," + textBox_ZhengIOIn26_IN.Text + "," + textBox_ZhengIOIn26_Ref1.Text + "," + textBox_ZhengIOIn26b_VIn1.Text + "," + textBox_ZhengIOIn26b_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengIOIn26_Value1.Text + "," + textBox_ZhengIOIn26_Value2.Text); }
                }
            }
            //DA输出测试表格信息
            if (CheckBox_ZhengDA1.Checked)
            {
                if (skinCheckBox_ZhengDA1.Checked)
                { checkList1.Add("DA输出测试通道1" + "," + textBox_ZhengDA1_IN.Text + "," + textBox_ZhengDA1_Ref1.Text + "," + textBox_ZhengDA1_VIn1.Text + "," + textBox_ZhengDA1_VIn2.Text + "," + textBox_ZhengDA1_Test.Text + "," + textBox_ZhengDA1_Ref2.Text + "," + textBox_ZhengDA1_Value1.Text + "," + textBox_ZhengDA1_Value2.Text); }
                if (skinCheckBox_ZhengDA1.Checked == false)
                { checkList1.Add("DA输出测试通道1" + "," + "/" + "," + "/" + "," + "/" + "," + "/" + "," + textBox_ZhengDA1_Test.Text + "," + textBox_ZhengDA1_Ref2.Text + "," + textBox_ZhengDA1_Value1.Text + "," + textBox_ZhengDA1_Value2.Text); }
            }
            if (CheckBox_ZhengDA2.Checked)
            {
                if (skinCheckBox_ZhengDA2.Checked)
                { checkList1.Add("DA输出测试通道2" + "," + textBox_ZhengDA2_IN.Text + "," + textBox_ZhengDA2_Ref1.Text + "," + textBox_ZhengDA2_VIn1.Text + "," + textBox_ZhengDA2_VIn2.Text + "," + textBox_ZhengDA2_Test.Text + "," + textBox_ZhengDA2_Ref2.Text + "," + textBox_ZhengDA2_Value1.Text + "," + textBox_ZhengDA2_Value2.Text); }
                if (skinCheckBox_ZhengDA2.Checked == false)
                { checkList1.Add("DA输出测试通道2" + "," + "/" + "," + "/" + "," + "/" + "," + "/" + "," + textBox_ZhengDA2_Test.Text + "," + textBox_ZhengDA2_Ref2.Text + "," + textBox_ZhengDA2_Value1.Text + "," + textBox_ZhengDA2_Value2.Text); }
            }
            if (CheckBox_ZhengDA3.Checked)
            {
                if (skinCheckBox_ZhengDA3.Checked)
                { checkList1.Add("DA输出测试通道3" + "," + textBox_ZhengDA3_IN.Text + "," + textBox_ZhengDA3_Ref1.Text + "," + textBox_ZhengDA3_VIn1.Text + "," + textBox_ZhengDA3_VIn2.Text + "," + textBox_ZhengDA3_Test.Text + "," + textBox_ZhengDA3_Ref2.Text + "," + textBox_ZhengDA3_Value1.Text + "," + textBox_ZhengDA3_Value2.Text); }
                if (skinCheckBox_ZhengDA3.Checked == false)
                { checkList1.Add("DA输出测试通道3" + "," + "/" + "," + "/" + "," + "/" + "," + "/" + "," + textBox_ZhengDA3_Test.Text + "," + textBox_ZhengDA3_Ref2.Text + "," + textBox_ZhengDA3_Value1.Text + "," + textBox_ZhengDA3_Value2.Text); }
            }
            if (CheckBox_ZhengDA4.Checked)
            {
                if (skinCheckBox_ZhengDA4.Checked)
                { checkList1.Add("DA输出测试通道4" + "," + textBox_ZhengDA4_IN.Text + "," + textBox_ZhengDA4_Ref1.Text + "," + textBox_ZhengDA4_VIn1.Text + "," + textBox_ZhengDA4_VIn2.Text + "," + textBox_ZhengDA4_Test.Text + "," + textBox_ZhengDA4_Ref2.Text + "," + textBox_ZhengDA4_Value1.Text + "," + textBox_ZhengDA4_Value2.Text); }
                if (skinCheckBox_ZhengDA4.Checked == false)
                { checkList1.Add("DA输出测试通道4" + "," + "/" + "," + "/" + "," + "/" + "," + "/" + "," + textBox_ZhengDA4_Test.Text + "," + textBox_ZhengDA4_Ref2.Text + "," + textBox_ZhengDA4_Value1.Text + "," + textBox_ZhengDA4_Value2.Text); }
            }
            if (CheckBox_ZhengDA5.Checked)
            {
                if (skinCheckBox_ZhengDA5.Checked)
                { checkList1.Add("DA输出测试通道5" + "," + textBox_ZhengDA5_IN.Text + "," + textBox_ZhengDA5_Ref1.Text + "," + textBox_ZhengDA5_VIn1.Text + "," + textBox_ZhengDA5_VIn2.Text + "," + textBox_ZhengDA5_Test.Text + "," + textBox_ZhengDA5_Ref2.Text + "," + textBox_ZhengDA5_Value1.Text + "," + textBox_ZhengDA5_Value2.Text); }
                if (skinCheckBox_ZhengDA5.Checked == false)
                { checkList1.Add("DA输出测试通道5" + "," + "/" + "," + "/" + "," + "/" + "," + "/" + "," + textBox_ZhengDA5_Test.Text + "," + textBox_ZhengDA5_Ref2.Text + "," + textBox_ZhengDA5_Value1.Text + "," + textBox_ZhengDA5_Value2.Text); }
            }
            if (CheckBox_ZhengDA6.Checked)
            {
                if (skinCheckBox_ZhengDA6.Checked)
                { checkList1.Add("DA输出测试通道6" + "," + textBox_ZhengDA6_IN.Text + "," + textBox_ZhengDA6_Ref1.Text + "," + textBox_ZhengDA6_VIn1.Text + "," + textBox_ZhengDA6_VIn2.Text + "," + textBox_ZhengDA6_Test.Text + "," + textBox_ZhengDA6_Ref2.Text + "," + textBox_ZhengDA6_Value1.Text + "," + textBox_ZhengDA6_Value2.Text); }
                if (skinCheckBox_ZhengDA6.Checked == false)
                { checkList1.Add("DA输出测试通道6" + "," + "/" + "," + "/" + "," + "/" + "," + "/" + "," + textBox_ZhengDA6_Test.Text + "," + textBox_ZhengDA6_Ref2.Text + "," + textBox_ZhengDA6_Value1.Text + "," + textBox_ZhengDA6_Value2.Text); }
            }
            if (CheckBox_ZhengDA7.Checked)
            {
                if (skinCheckBox_ZhengDA7.Checked)
                { checkList1.Add("DA输出测试通道7" + "," + textBox_ZhengDA7_IN.Text + "," + textBox_ZhengDA7_Ref1.Text + "," + textBox_ZhengDA7_VIn1.Text + "," + textBox_ZhengDA7_VIn2.Text + "," + textBox_ZhengDA7_Test.Text + "," + textBox_ZhengDA7_Ref2.Text + "," + textBox_ZhengDA7_Value1.Text + "," + textBox_ZhengDA7_Value2.Text); }
                if (skinCheckBox_ZhengDA7.Checked == false)
                { checkList1.Add("DA输出测试通道7" + "," + "/" + "," + "/" + "," + "/" + "," + "/" + "," + textBox_ZhengDA7_Test.Text + "," + textBox_ZhengDA7_Ref2.Text + "," + textBox_ZhengDA7_Value1.Text + "," + textBox_ZhengDA7_Value2.Text); }
            }
            if (CheckBox_ZhengDA8.Checked)
            {
                if (skinCheckBox_ZhengDA8.Checked)
                { checkList1.Add("DA输出测试通道8" + "," + textBox_ZhengDA8_IN.Text + "," + textBox_ZhengDA8_Ref1.Text + "," + textBox_ZhengDA8_VIn1.Text + "," + textBox_ZhengDA8_VIn2.Text + "," + textBox_ZhengDA8_Test.Text + "," + textBox_ZhengDA8_Ref2.Text + "," + textBox_ZhengDA8_Value1.Text + "," + textBox_ZhengDA8_Value2.Text); }
                if (skinCheckBox_ZhengDA8.Checked == false)
                { checkList1.Add("DA输出测试通道8" + "," + "/" + "," + "/" + "," + "/" + "," + "/" + "," + textBox_ZhengDA8_Test.Text + "," + textBox_ZhengDA8_Ref2.Text + "," + textBox_ZhengDA8_Value1.Text + "," + textBox_ZhengDA8_Value2.Text); }
            }
            //AD采样测试表格信息
            if (CheckBox_ZhengAD1.Checked)
            {
                if (skinCheckBox_ZhengAD1.Checked)
                { checkList1.Add("AD输入测试通道1" + "," + textBox_ZhengAD1_IN.Text + "," + textBox_ZhengAD1_Ref1.Text + "," + textBox_ZhengAD1_VIn1.Text + "," + textBox_ZhengAD1_VIn2.Text + "," + textBox_ZhengAD1_Test.Text + "," + textBox_ZhengAD1_Ref2.Text + "," + textBox_ZhengAD1_Value1.Text + "," + textBox_ZhengAD1_Value2.Text); }
                if (skinCheckBox_ZhengAD1.Checked == false)
                { checkList1.Add("AD输入测试通道1" + "," + textBox_ZhengAD1_IN.Text + "," + textBox_ZhengAD1_Ref1.Text + "," + textBox_ZhengAD1_VIn1.Text + "," + textBox_ZhengAD1_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengAD1_Value1.Text + "," + textBox_ZhengAD1_Value2.Text); }
            }
            if (CheckBox_ZhengAD2.Checked)
            {
                if (skinCheckBox_ZhengAD2.Checked)
                { checkList1.Add("AD输入测试通道2" + "," + textBox_ZhengAD2_IN.Text + "," + textBox_ZhengAD2_Ref1.Text + "," + textBox_ZhengAD2_VIn1.Text + "," + textBox_ZhengAD2_VIn2.Text + "," + textBox_ZhengAD2_Test.Text + "," + textBox_ZhengAD2_Ref2.Text + "," + textBox_ZhengAD2_Value1.Text + "," + textBox_ZhengAD2_Value2.Text); }
                if (skinCheckBox_ZhengAD2.Checked == false)
                { checkList1.Add("AD输入测试通道2" + "," + textBox_ZhengAD2_IN.Text + "," + textBox_ZhengAD2_Ref1.Text + "," + textBox_ZhengAD2_VIn1.Text + "," + textBox_ZhengAD2_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengAD2_Value1.Text + "," + textBox_ZhengAD2_Value2.Text); }
            }
            if (CheckBox_ZhengAD3.Checked)
            {
                if (skinCheckBox_ZhengAD3.Checked)
                { checkList1.Add("AD输入测试通道3" + "," + textBox_ZhengAD3_IN.Text + "," + textBox_ZhengAD3_Ref1.Text + "," + textBox_ZhengAD3_VIn1.Text + "," + textBox_ZhengAD3_VIn2.Text + "," + textBox_ZhengAD3_Test.Text + "," + textBox_ZhengAD3_Ref2.Text + "," + textBox_ZhengAD3_Value1.Text + "," + textBox_ZhengAD3_Value2.Text); }
                if (skinCheckBox_ZhengAD3.Checked == false)
                { checkList1.Add("AD输入测试通道3" + "," + textBox_ZhengAD3_IN.Text + "," + textBox_ZhengAD3_Ref1.Text + "," + textBox_ZhengAD3_VIn1.Text + "," + textBox_ZhengAD3_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengAD3_Value1.Text + "," + textBox_ZhengAD3_Value2.Text); }
            }
            if (CheckBox_ZhengAD4.Checked)
            {
                if (skinCheckBox_ZhengAD4.Checked)
                { checkList1.Add("AD输入测试通道4" + "," + textBox_ZhengAD4_IN.Text + "," + textBox_ZhengAD4_Ref1.Text + "," + textBox_ZhengAD4_VIn1.Text + "," + textBox_ZhengAD4_VIn2.Text + "," + textBox_ZhengAD4_Test.Text + "," + textBox_ZhengAD4_Ref2.Text + "," + textBox_ZhengAD4_Value1.Text + "," + textBox_ZhengAD4_Value2.Text); }
                if (skinCheckBox_ZhengAD4.Checked == false)
                { checkList1.Add("AD输入测试通道4" + "," + textBox_ZhengAD4_IN.Text + "," + textBox_ZhengAD4_Ref1.Text + "," + textBox_ZhengAD4_VIn1.Text + "," + textBox_ZhengAD4_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengAD4_Value1.Text + "," + textBox_ZhengAD4_Value2.Text); }
            }
            if (CheckBox_ZhengAD5.Checked)
            {
                if (skinCheckBox_ZhengAD5.Checked)
                { checkList1.Add("AD输入测试通道5" + "," + textBox_ZhengAD5_IN.Text + "," + textBox_ZhengAD5_Ref1.Text + "," + textBox_ZhengAD5_VIn1.Text + "," + textBox_ZhengAD5_VIn2.Text + "," + textBox_ZhengAD5_Test.Text + "," + textBox_ZhengAD5_Ref2.Text + "," + textBox_ZhengAD5_Value1.Text + "," + textBox_ZhengAD5_Value2.Text); }
                if (skinCheckBox_ZhengAD5.Checked == false)
                { checkList1.Add("AD输入测试通道5" + "," + textBox_ZhengAD5_IN.Text + "," + textBox_ZhengAD5_Ref1.Text + "," + textBox_ZhengAD5_VIn1.Text + "," + textBox_ZhengAD5_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengAD5_Value1.Text + "," + textBox_ZhengAD5_Value2.Text); }
            }
            if (CheckBox_ZhengAD6.Checked)
            {
                if (skinCheckBox_ZhengAD6.Checked)
                { checkList1.Add("AD输入测试通道6" + "," + textBox_ZhengAD6_IN.Text + "," + textBox_ZhengAD6_Ref1.Text + "," + textBox_ZhengAD6_VIn1.Text + "," + textBox_ZhengAD6_VIn2.Text + "," + textBox_ZhengAD6_Test.Text + "," + textBox_ZhengAD6_Ref2.Text + "," + textBox_ZhengAD6_Value1.Text + "," + textBox_ZhengAD6_Value2.Text); }
                if (skinCheckBox_ZhengAD6.Checked == false)
                { checkList1.Add("AD输入测试通道6" + "," + textBox_ZhengAD6_IN.Text + "," + textBox_ZhengAD6_Ref1.Text + "," + textBox_ZhengAD6_VIn1.Text + "," + textBox_ZhengAD6_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengAD6_Value1.Text + "," + textBox_ZhengAD6_Value2.Text); }
            }
            if (CheckBox_ZhengAD7.Checked)
            {
                if (skinCheckBox_ZhengAD7.Checked)
                { checkList1.Add("AD输入测试通道7" + "," + textBox_ZhengAD7_IN.Text + "," + textBox_ZhengAD7_Ref1.Text + "," + textBox_ZhengAD7_VIn1.Text + "," + textBox_ZhengAD7_VIn2.Text + "," + textBox_ZhengAD7_Test.Text + "," + textBox_ZhengAD7_Ref2.Text + "," + textBox_ZhengAD7_Value1.Text + "," + textBox_ZhengAD7_Value2.Text); }
                if (skinCheckBox_ZhengAD7.Checked == false)
                { checkList1.Add("AD输入测试通道7" + "," + textBox_ZhengAD7_IN.Text + "," + textBox_ZhengAD7_Ref1.Text + "," + textBox_ZhengAD7_VIn1.Text + "," + textBox_ZhengAD7_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengAD7_Value1.Text + "," + textBox_ZhengAD7_Value2.Text); }
            }
            if (CheckBox_ZhengAD8.Checked)
            {
                if (skinCheckBox_ZhengAD8.Checked)
                { checkList1.Add("AD输入测试通道8" + "," + textBox_ZhengAD8_IN.Text + "," + textBox_ZhengAD8_Ref1.Text + "," + textBox_ZhengAD8_VIn1.Text + "," + textBox_ZhengAD8_VIn2.Text + "," + textBox_ZhengAD8_Test.Text + "," + textBox_ZhengAD8_Ref2.Text + "," + textBox_ZhengAD8_Value1.Text + "," + textBox_ZhengAD8_Value2.Text); }
                if (skinCheckBox_ZhengAD8.Checked == false)
                { checkList1.Add("AD输入测试通道8" + "," + textBox_ZhengAD8_IN.Text + "," + textBox_ZhengAD8_Ref1.Text + "," + textBox_ZhengAD8_VIn1.Text + "," + textBox_ZhengAD8_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengAD8_Value1.Text + "," + textBox_ZhengAD8_Value2.Text); }
            }
            if (CheckBox_ZhengAD9.Checked)
            {
                if (skinCheckBox_ZhengAD9.Checked)
                { checkList1.Add("AD输入测试通道9" + "," + textBox_ZhengAD9_IN.Text + "," + textBox_ZhengAD9_Ref1.Text + "," + textBox_ZhengAD9_VIn1.Text + "," + textBox_ZhengAD9_VIn2.Text + "," + textBox_ZhengAD9_Test.Text + "," + textBox_ZhengAD9_Ref2.Text + "," + textBox_ZhengAD9_Value1.Text + "," + textBox_ZhengAD9_Value2.Text); }
                if (skinCheckBox_ZhengAD9.Checked == false)
                { checkList1.Add("AD输入测试通道9" + "," + textBox_ZhengAD9_IN.Text + "," + textBox_ZhengAD9_Ref1.Text + "," + textBox_ZhengAD9_VIn1.Text + "," + textBox_ZhengAD9_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengAD9_Value1.Text + "," + textBox_ZhengAD9_Value2.Text); }
            }
            if (CheckBox_ZhengAD10.Checked)
            {
                if (skinCheckBox_ZhengAD10.Checked)
                { checkList1.Add("AD输入测试通道10" + "," + textBox_ZhengAD10_IN.Text + "," + textBox_ZhengAD10_Ref1.Text + "," + textBox_ZhengAD10_VIn1.Text + "," + textBox_ZhengAD10_VIn2.Text + "," + textBox_ZhengAD10_Test.Text + "," + textBox_ZhengAD10_Ref2.Text + "," + textBox_ZhengAD10_Value1.Text + "," + textBox_ZhengAD10_Value2.Text); }
                if (skinCheckBox_ZhengAD10.Checked == false)
                { checkList1.Add("AD输入测试通道10" + "," + textBox_ZhengAD10_IN.Text + "," + textBox_ZhengAD10_Ref1.Text + "," + textBox_ZhengAD10_VIn1.Text + "," + textBox_ZhengAD10_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengAD10_Value1.Text + "," + textBox_ZhengAD10_Value2.Text); }
            }
            if (CheckBox_ZhengAD11.Checked)
            {
                if (skinCheckBox_ZhengAD11.Checked)
                { checkList1.Add("AD输入测试通道11" + "," + textBox_ZhengAD11_IN.Text + "," + textBox_ZhengAD11_Ref1.Text + "," + textBox_ZhengAD11_VIn1.Text + "," + textBox_ZhengAD11_VIn2.Text + "," + textBox_ZhengAD11_Test.Text + "," + textBox_ZhengAD11_Ref2.Text + "," + textBox_ZhengAD11_Value1.Text + "," + textBox_ZhengAD11_Value2.Text); }
                if (skinCheckBox_ZhengAD11.Checked == false)
                { checkList1.Add("AD输入测试通道11" + "," + textBox_ZhengAD11_IN.Text + "," + textBox_ZhengAD11_Ref1.Text + "," + textBox_ZhengAD11_VIn1.Text + "," + textBox_ZhengAD11_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengAD11_Value1.Text + "," + textBox_ZhengAD11_Value2.Text); }
            }
            if (CheckBox_ZhengAD12.Checked)
            {
                if (skinCheckBox_ZhengAD12.Checked)
                { checkList1.Add("AD输入测试通道12" + "," + textBox_ZhengAD12_IN.Text + "," + textBox_ZhengAD12_Ref1.Text + "," + textBox_ZhengAD12_VIn1.Text + "," + textBox_ZhengAD12_VIn2.Text + "," + textBox_ZhengAD12_Test.Text + "," + textBox_ZhengAD12_Ref2.Text + "," + textBox_ZhengAD12_Value1.Text + "," + textBox_ZhengAD12_Value2.Text); }
                if (skinCheckBox_ZhengAD12.Checked == false)
                { checkList1.Add("AD输入测试通道12" + "," + textBox_ZhengAD12_IN.Text + "," + textBox_ZhengAD12_Ref1.Text + "," + textBox_ZhengAD12_VIn1.Text + "," + textBox_ZhengAD12_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengAD12_Value1.Text + "," + textBox_ZhengAD12_Value2.Text); }
            }
            if (CheckBox_ZhengAD13.Checked)
            { checkList1.Add("AD输入测试通道13" + "," + textBox_ZhengAD13_IN.Text + "," + textBox_ZhengAD13_Ref1.Text + "," + textBox_ZhengAD13_VIn1.Text + "," + textBox_ZhengAD13_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengAD13_Value1.Text + "," + textBox_ZhengAD13_Value2.Text); }
            if (CheckBox_ZhengAD14.Checked)
            { checkList1.Add("AD输入测试通道14" + "," + textBox_ZhengAD14_IN.Text + "," + textBox_ZhengAD14_Ref1.Text + "," + textBox_ZhengAD14_VIn1.Text + "," + textBox_ZhengAD14_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengAD14_Value1.Text + "," + textBox_ZhengAD14_Value2.Text); }
            if (CheckBox_ZhengAD15.Checked)
            { checkList1.Add("AD输入测试通道15" + "," + textBox_ZhengAD15_IN.Text + "," + textBox_ZhengAD15_Ref1.Text + "," + textBox_ZhengAD15_VIn1.Text + "," + textBox_ZhengAD15_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengAD15_Value1.Text + "," + textBox_ZhengAD15_Value2.Text); }
            if (CheckBox_ZhengAD16.Checked)
            { checkList1.Add("AD输入测试通道16" + "," + textBox_ZhengAD16_IN.Text + "," + textBox_ZhengAD16_Ref1.Text + "," + textBox_ZhengAD16_VIn1.Text + "," + textBox_ZhengAD16_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengAD16_Value1.Text + "," + textBox_ZhengAD16_Value2.Text); }
            if (CheckBox_ZhengAD17.Checked)
            { checkList1.Add("AD输入测试通道17" + "," + textBox_ZhengAD17_IN.Text + "," + textBox_ZhengAD17_Ref1.Text + "," + textBox_ZhengAD17_VIn1.Text + "," + textBox_ZhengAD17_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengAD17_Value1.Text + "," + textBox_ZhengAD17_Value2.Text); }
            if (CheckBox_ZhengAD18.Checked)
            { checkList1.Add("AD输入测试通道18" + "," + textBox_ZhengAD18_IN.Text + "," + textBox_ZhengAD18_Ref1.Text + "," + textBox_ZhengAD18_VIn1.Text + "," + textBox_ZhengAD18_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengAD18_Value1.Text + "," + textBox_ZhengAD18_Value2.Text); }
            if (CheckBox_ZhengAD19.Checked)
            { checkList1.Add("AD输入测试通道19" + "," + textBox_ZhengAD19_IN.Text + "," + textBox_ZhengAD19_Ref1.Text + "," + textBox_ZhengAD19_VIn1.Text + "," + textBox_ZhengAD19_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengAD19_Value1.Text + "," + textBox_ZhengAD19_Value2.Text); }
            if (CheckBox_ZhengAD20.Checked)
            { checkList1.Add("AD输入测试通道20" + "," + textBox_ZhengAD20_IN.Text + "," + textBox_ZhengAD20_Ref1.Text + "," + textBox_ZhengAD20_VIn1.Text + "," + textBox_ZhengAD20_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengAD20_Value1.Text + "," + textBox_ZhengAD20_Value2.Text); }
            if (CheckBox_ZhengAD21.Checked)
            { checkList1.Add("AD输入测试通道21" + "," + textBox_ZhengAD21_IN.Text + "," + textBox_ZhengAD21_Ref1.Text + "," + textBox_ZhengAD21_VIn1.Text + "," + textBox_ZhengAD21_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengAD21_Value1.Text + "," + textBox_ZhengAD21_Value2.Text); }
            if (CheckBox_ZhengAD22.Checked)
            { checkList1.Add("AD输入测试通道22" + "," + textBox_ZhengAD22_IN.Text + "," + textBox_ZhengAD22_Ref1.Text + "," + textBox_ZhengAD22_VIn1.Text + "," + textBox_ZhengAD22_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengAD22_Value1.Text + "," + textBox_ZhengAD22_Value2.Text); }
            if (CheckBox_ZhengAD23.Checked)
            { checkList1.Add("AD输入测试通道23" + "," + textBox_ZhengAD23_IN.Text + "," + textBox_ZhengAD23_Ref1.Text + "," + textBox_ZhengAD23_VIn1.Text + "," + textBox_ZhengAD23_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengAD23_Value1.Text + "," + textBox_ZhengAD23_Value2.Text); }
            if (CheckBox_ZhengAD24.Checked)
            { checkList1.Add("AD输入测试通道24" + "," + textBox_ZhengAD24_IN.Text + "," + textBox_ZhengAD24_Ref1.Text + "," + textBox_ZhengAD24_VIn1.Text + "," + textBox_ZhengAD24_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengAD24_Value1.Text + "," + textBox_ZhengAD24_Value2.Text); }
            if (CheckBox_ZhengAD25.Checked)
            { checkList1.Add("AD输入测试通道25" + "," + textBox_ZhengAD25_IN.Text + "," + textBox_ZhengAD25_Ref1.Text + "," + textBox_ZhengAD25_VIn1.Text + "," + textBox_ZhengAD25_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengAD25_Value1.Text + "," + textBox_ZhengAD25_Value2.Text); }
            if (CheckBox_ZhengAD26.Checked)
            { checkList1.Add("AD输入测试通道26" + "," + textBox_ZhengAD26_IN.Text + "," + textBox_ZhengAD26_Ref1.Text + "," + textBox_ZhengAD26_VIn1.Text + "," + textBox_ZhengAD26_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengAD26_Value1.Text + "," + textBox_ZhengAD26_Value2.Text); }
            if (CheckBox_ZhengAD27.Checked)
            { checkList1.Add("AD输入测试通道27" + "," + textBox_ZhengAD27_IN.Text + "," + textBox_ZhengAD27_Ref1.Text + "," + textBox_ZhengAD27_VIn1.Text + "," + textBox_ZhengAD27_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengAD27_Value1.Text + "," + textBox_ZhengAD27_Value2.Text); }
            if (CheckBox_ZhengAD28.Checked)
            { checkList1.Add("AD输入测试通道28" + "," + textBox_ZhengAD28_IN.Text + "," + textBox_ZhengAD28_Ref1.Text + "," + textBox_ZhengAD28_VIn1.Text + "," + textBox_ZhengAD28_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengAD28_Value1.Text + "," + textBox_ZhengAD28_Value2.Text); }
            if (CheckBox_ZhengAD29.Checked)
            { checkList1.Add("AD输入测试通道29" + "," + textBox_ZhengAD29_IN.Text + "," + textBox_ZhengAD29_Ref1.Text + "," + textBox_ZhengAD29_VIn1.Text + "," + textBox_ZhengAD29_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengAD29_Value1.Text + "," + textBox_ZhengAD29_Value2.Text); }
            if (CheckBox_ZhengAD30.Checked)
            { checkList1.Add("AD输入测试通道30" + "," + textBox_ZhengAD30_IN.Text + "," + textBox_ZhengAD30_Ref1.Text + "," + textBox_ZhengAD30_VIn1.Text + "," + textBox_ZhengAD30_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengAD30_Value1.Text + "," + textBox_ZhengAD30_Value2.Text); }
            if (CheckBox_ZhengAD31.Checked)
            { checkList1.Add("AD输入测试通道31" + "," + textBox_ZhengAD31_IN.Text + "," + textBox_ZhengAD31_Ref1.Text + "," + textBox_ZhengAD31_VIn1.Text + "," + textBox_ZhengAD31_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengAD31_Value1.Text + "," + textBox_ZhengAD31_Value2.Text); }
            if (CheckBox_ZhengAD32.Checked)
            { checkList1.Add("AD输入测试通道32" + "," + textBox_ZhengAD32_IN.Text + "," + textBox_ZhengAD32_Ref1.Text + "," + textBox_ZhengAD32_VIn1.Text + "," + textBox_ZhengAD32_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengAD32_Value1.Text + "," + textBox_ZhengAD32_Value2.Text); }
            if (CheckBox_ZhengAD33.Checked)
            { checkList1.Add("AD输入测试通道33" + "," + textBox_ZhengAD33_IN.Text + "," + textBox_ZhengAD33_Ref1.Text + "," + textBox_ZhengAD33_VIn1.Text + "," + textBox_ZhengAD33_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengAD33_Value1.Text + "," + textBox_ZhengAD33_Value2.Text); }
            if (CheckBox_ZhengAD34.Checked)
            { checkList1.Add("AD输入测试通道34" + "," + textBox_ZhengAD34_IN.Text + "," + textBox_ZhengAD34_Ref1.Text + "," + textBox_ZhengAD34_VIn1.Text + "," + textBox_ZhengAD34_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengAD34_Value1.Text + "," + textBox_ZhengAD34_Value2.Text); }
            if (CheckBox_ZhengAD35.Checked)
            { checkList1.Add("AD输入测试通道35" + "," + textBox_ZhengAD35_IN.Text + "," + textBox_ZhengAD35_Ref1.Text + "," + textBox_ZhengAD35_VIn1.Text + "," + textBox_ZhengAD35_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengAD35_Value1.Text + "," + textBox_ZhengAD35_Value2.Text); }
            if (CheckBox_ZhengAD36.Checked)
            { checkList1.Add("AD输入测试通道36" + "," + textBox_ZhengAD36_IN.Text + "," + textBox_ZhengAD36_Ref1.Text + "," + textBox_ZhengAD36_VIn1.Text + "," + textBox_ZhengAD36_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengAD36_Value1.Text + "," + textBox_ZhengAD36_Value2.Text); }
            if (CheckBox_ZhengAD37.Checked)
            { checkList1.Add("AD输入测试通道37" + "," + textBox_ZhengAD37_IN.Text + "," + textBox_ZhengAD37_Ref1.Text + "," + textBox_ZhengAD37_VIn1.Text + "," + textBox_ZhengAD37_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengAD37_Value1.Text + "," + textBox_ZhengAD37_Value2.Text); }
            if (CheckBox_ZhengAD38.Checked)
            { checkList1.Add("AD输入测试通道38" + "," + textBox_ZhengAD38_IN.Text + "," + textBox_ZhengAD38_Ref1.Text + "," + textBox_ZhengAD38_VIn1.Text + "," + textBox_ZhengAD38_VIn2.Text + "," + "/" + "," + "/" + "," + textBox_ZhengAD38_Value1.Text + "," + textBox_ZhengAD38_Value2.Text); }
            strOut1 = string.Join(";", checkList1.ToArray());
        }

        //返回测试界面
        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
            switch (whichform)
            {
                case "Gonglv":
                    showform = new FormTest("Gonglv");
                    break;
                case "Kongzhi":
                    showform = new FormTest("Gonglv");
                    break;
                case "Zonghe":
                    showform = new FormTest("Zonghe");
                    break;
                case "Zuhe":
                    showform = new FormTest("Zuhe");
                    break;
                case "Zhengji":
                    showform = new FormTest("Zhengji");
                    break;
                case "Laolian":
                    showform = new FormLaolian();
                    break;
            }
            showform.Show();
        }

        //保存配置文件
        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = "D:\\";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter checkOut = new StreamWriter(saveFileDialog1.FileName))
                {
                    CheckResult();
                    checkOut.WriteLine(whichform);
                    checkOut.WriteLine(DateTime.Today.ToShortDateString());
                    checkOut.WriteLine(numShort.ToString());
                    checkOut.WriteLine(numVolt.ToString());
                    checkOut.WriteLine(numIOOut.ToString());
                    checkOut.WriteLine(numIOIn.ToString());
                    checkOut.WriteLine(numDA.ToString());
                    checkOut.WriteLine(numAD.ToString());
                    checkOut.WriteLine(strOut);
                    checkOut.WriteLine(strOut1);
                    checkOut.Flush();
                    checkOut.Dispose();
                }
            }
        }

        
        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            choose();
        }

        private void skinCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            choose();
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            choose();         
        }

        private void choose()
        {
            if (CheckBox_ZhengShort1.Checked == true)//短路测试通道1使能
            {
                textBox_ZhengShort1_Test1.Enabled = true;
                textBox_ZhengShort1_Test2.Enabled = true;
                textBox_ZhengShort1_Value.Enabled = true;
            }
            else if (CheckBox_ZhengShort1.Checked == false)
            {
                textBox_ZhengShort1_Test1.Enabled = false;
                textBox_ZhengShort1_Test2.Enabled = false;
                textBox_ZhengShort1_Value.Enabled = false;
            }
            if (CheckBox_ZhengShort2.Checked == true)//短路测试通道2使能
            {
                textBox_ZhengShort2_Test1.Enabled = true;
                textBox_ZhengShort2_Test2.Enabled = true;
                textBox_ZhengShort2_Value.Enabled = true;
            }
            else if (CheckBox_ZhengShort2.Checked == false)
            {
                textBox_ZhengShort2_Test1.Enabled = false;
                textBox_ZhengShort2_Test2.Enabled = false;
                textBox_ZhengShort2_Value.Enabled = false;
            }
            if (CheckBox_ZhengShort3.Checked == true)//短路测试通道3使能
            {
                textBox_ZhengShort3_Test1.Enabled = true;
                textBox_ZhengShort3_Test2.Enabled = true;
                textBox_ZhengShort3_Value.Enabled = true;
            }
            else if (CheckBox_ZhengShort3.Checked == false)
            {
                textBox_ZhengShort3_Test1.Enabled = false;
                textBox_ZhengShort3_Test2.Enabled = false;
                textBox_ZhengShort3_Value.Enabled = false;
            }
            if (CheckBox_ZhengShort4.Checked == true)//短路测试通道4使能
            {
                textBox_ZhengShort4_Test1.Enabled = true;
                textBox_ZhengShort4_Test2.Enabled = true;
                textBox_ZhengShort4_Value.Enabled = true;
            }
            else if (CheckBox_ZhengShort4.Checked == false)
            {
                textBox_ZhengShort4_Test1.Enabled = false;
                textBox_ZhengShort4_Test2.Enabled = false;
                textBox_ZhengShort4_Value.Enabled = false;
            }
            if (CheckBox_ZhengShort5.Checked == true)//短路测试通道5使能
            {
                textBox_ZhengShort5_Test1.Enabled = true;
                textBox_ZhengShort5_Test2.Enabled = true;
                textBox_ZhengShort5_Value.Enabled = true;
            }
            else if (CheckBox_ZhengShort5.Checked == false)
            {
                textBox_ZhengShort5_Test1.Enabled = false;
                textBox_ZhengShort5_Test2.Enabled = false;
                textBox_ZhengShort5_Value.Enabled = false;
            }
            if (CheckBox_ZhengShort6.Checked == true)//短路测试通道6使能
            {
                textBox_ZhengShort6_Test1.Enabled = true;
                textBox_ZhengShort6_Test2.Enabled = true;
                textBox_ZhengShort6_Value.Enabled = true;
            }
            else if (CheckBox_ZhengShort6.Checked == false)
            {
                textBox_ZhengShort6_Test1.Enabled = false;
                textBox_ZhengShort6_Test2.Enabled = false;
                textBox_ZhengShort6_Value.Enabled = false;
            }
            if (CheckBox_ZhengShort7.Checked == true)//短路测试通道7使能
            {
                textBox_ZhengShort7_Test1.Enabled = true;
                textBox_ZhengShort7_Test2.Enabled = true;
                textBox_ZhengShort7_Value.Enabled = true;
            }
            else if (CheckBox_ZhengShort7.Checked == false)
            {
                textBox_ZhengShort7_Test1.Enabled = false;
                textBox_ZhengShort7_Test2.Enabled = false;
                textBox_ZhengShort7_Value.Enabled = false;
            }
            if (CheckBox_ZhengShort8.Checked == true)//短路测试通道8使能
            {
                textBox_ZhengShort8_Test1.Enabled = true;
                textBox_ZhengShort8_Test2.Enabled = true;
                textBox_ZhengShort8_Value.Enabled = true;
            }
            else if (CheckBox_ZhengShort8.Checked == false)
            {
                textBox_ZhengShort8_Test1.Enabled = false;
                textBox_ZhengShort8_Test2.Enabled = false;
                textBox_ZhengShort8_Value.Enabled = false;
            }

            if (CheckBox_ZhengVolt1.Checked == true)//电压输出测试通道1使能
            {
                textBox_ZhengVolt1_Test1.Enabled = true;
                textBox_ZhengVolt1_Test2.Enabled = true;
                textBox_ZhengVolt1_Value.Enabled = true;
            }
            else if (CheckBox_ZhengVolt1.Checked == false)
            {
                textBox_ZhengVolt1_Test1.Enabled = false;
                textBox_ZhengVolt1_Test2.Enabled = false;
                textBox_ZhengVolt1_Value.Enabled = false;
            }
            if (CheckBox_ZhengVolt2.Checked == true)//电压输出测试通道2使能
            {
                textBox_ZhengVolt2_Test1.Enabled = true;
                textBox_ZhengVolt2_Test2.Enabled = true;
                textBox_ZhengVolt2_Value.Enabled = true;
            }
            else if (CheckBox_ZhengVolt2.Checked == false)
            {
                textBox_ZhengVolt2_Test1.Enabled = false;
                textBox_ZhengVolt2_Test2.Enabled = false;
                textBox_ZhengVolt2_Value.Enabled = false;
            }
            if (CheckBox_ZhengVolt3.Checked == true)//电压输出测试通道3使能
            {
                textBox_ZhengVolt3_Test1.Enabled = true;
                textBox_ZhengVolt3_Test2.Enabled = true;
                textBox_ZhengVolt3_Value.Enabled = true;
            }
            else if (CheckBox_ZhengVolt3.Checked == false)
            {
                textBox_ZhengVolt3_Test1.Enabled = false;
                textBox_ZhengVolt3_Test2.Enabled = false;
                textBox_ZhengVolt3_Value.Enabled = false;
            }
            if (CheckBox_ZhengVolt4.Checked == true)//电压输出测试通道4使能
            {
                textBox_ZhengVolt4_Test1.Enabled = true;
                textBox_ZhengVolt4_Test2.Enabled = true;
                textBox_ZhengVolt4_Value.Enabled = true;
            }
            else if (CheckBox_ZhengVolt4.Checked == false)
            {
                textBox_ZhengVolt4_Test1.Enabled = false;
                textBox_ZhengVolt4_Test2.Enabled = false;
                textBox_ZhengVolt4_Value.Enabled = false;
            }
            if (CheckBox_ZhengVolt5.Checked == true)//电压输出测试通道5使能
            {
                textBox_ZhengVolt5_Test1.Enabled = true;
                textBox_ZhengVolt5_Test2.Enabled = true;
                textBox_ZhengVolt5_Value.Enabled = true;
            }
            else if (CheckBox_ZhengVolt5.Checked == false)
            {
                textBox_ZhengVolt5_Test1.Enabled = false;
                textBox_ZhengVolt5_Test2.Enabled = false;
                textBox_ZhengVolt5_Value.Enabled = false;
            }
            if (CheckBox_ZhengVolt6.Checked == true)//电压输出测试通道6使能
            {
                textBox_ZhengVolt6_Test1.Enabled = true;
                textBox_ZhengVolt6_Test2.Enabled = true;
                textBox_ZhengVolt6_Value.Enabled = true;
            }
            else if (CheckBox_ZhengVolt6.Checked == false)
            {
                textBox_ZhengVolt6_Test1.Enabled = false;
                textBox_ZhengVolt6_Test2.Enabled = false;
                textBox_ZhengVolt6_Value.Enabled = false;
            }
            if (CheckBox_ZhengVolt7.Checked == true)//电压输出测试通道7使能
            {
                textBox_ZhengVolt7_Test1.Enabled = true;
                textBox_ZhengVolt7_Test2.Enabled = true;
                textBox_ZhengVolt7_Value.Enabled = true;
            }
            else if (CheckBox_ZhengVolt7.Checked == false)
            {
                textBox_ZhengVolt7_Test1.Enabled = false;
                textBox_ZhengVolt7_Test2.Enabled = false;
                textBox_ZhengVolt7_Value.Enabled = false;
            }
            if (CheckBox_ZhengVolt8.Checked == true)//电压输出测试通道8使能
            {
                textBox_ZhengVolt8_Test1.Enabled = true;
                textBox_ZhengVolt8_Test2.Enabled = true;
                textBox_ZhengVolt8_Value.Enabled = true;
            }
            else if (CheckBox_ZhengVolt8.Checked == false)
            {
                textBox_ZhengVolt8_Test1.Enabled = false;
                textBox_ZhengVolt8_Test2.Enabled = false;
                textBox_ZhengVolt8_Value.Enabled = false;
            }

            if (CheckBox_ZhengIOOut1.Checked == true)//IO输出测试通道1使能
            {
                skinCheckBox_ZhengIOOut1.Enabled = true;
                if (skinCheckBox_ZhengIOOut1.Checked == true)
                {
                    textBox_ZhengIOOut1_IN.Enabled = true;
                    textBox_ZhengIOOut1_Ref1.Enabled = true;
                    textBox_ZhengIOOut1_VIn1.Enabled = true;
                    textBox_ZhengIOOut1_VIn2.Enabled = true;
                }
                else
                {
                    textBox_ZhengIOOut1_IN.Enabled = false;
                    textBox_ZhengIOOut1_Ref1.Enabled = false;
                    textBox_ZhengIOOut1_VIn1.Enabled = false;
                    textBox_ZhengIOOut1_VIn2.Enabled = false;
                }
                textBox_ZhengIOOut1_Test.Enabled = true;
                textBox_ZhengIOOut1_Ref2.Enabled = true;
                textBox_ZhengIOOut1_Value1.Enabled = true;
                textBox_ZhengIOOut1_Value2.Enabled = true;
            }
            else if (CheckBox_ZhengIOOut1.Checked == false)
            {
                skinCheckBox_ZhengIOOut1.Enabled = false;
                skinCheckBox_ZhengIOOut1.Checked = false;
                textBox_ZhengIOOut1_IN.Enabled = false;
                textBox_ZhengIOOut1_Ref1.Enabled = false;
                textBox_ZhengIOOut1_VIn1.Enabled = false;
                textBox_ZhengIOOut1_VIn2.Enabled = false;
                textBox_ZhengIOOut1_Test.Enabled = false;
                textBox_ZhengIOOut1_Ref2.Enabled = false;
                textBox_ZhengIOOut1_Value1.Enabled = false;
                textBox_ZhengIOOut1_Value2.Enabled = false;
            }
            if (CheckBox_ZhengIOOut2.Checked == true)//IO输出测试通道2使能
            {
                skinCheckBox_ZhengIOOut2.Enabled = true;
                if (skinCheckBox_ZhengIOOut2.Checked == true)
                {
                    textBox_ZhengIOOut2_IN.Enabled = true;
                    textBox_ZhengIOOut2_Ref1.Enabled = true;
                    textBox_ZhengIOOut2_VIn1.Enabled = true;
                    textBox_ZhengIOOut2_VIn2.Enabled = true;
                }
                if (skinCheckBox_ZhengIOOut2.Checked == false)
                {
                    textBox_ZhengIOOut2_IN.Enabled = false;
                    textBox_ZhengIOOut2_Ref1.Enabled = false;
                    textBox_ZhengIOOut2_VIn1.Enabled = false;
                    textBox_ZhengIOOut2_VIn2.Enabled = false;
                }
                textBox_ZhengIOOut2_Test.Enabled = true;
                textBox_ZhengIOOut2_Ref2.Enabled = true;
                textBox_ZhengIOOut2_Value1.Enabled = true;
                textBox_ZhengIOOut2_Value2.Enabled = true;
            }
            else if (CheckBox_ZhengIOOut2.Checked == false)
            {
                skinCheckBox_ZhengIOOut2.Enabled = false;
                skinCheckBox_ZhengIOOut2.Checked = false;
                textBox_ZhengIOOut2_IN.Enabled = false;
                textBox_ZhengIOOut2_Ref1.Enabled = false;
                textBox_ZhengIOOut2_VIn1.Enabled = false;
                textBox_ZhengIOOut2_VIn2.Enabled = false;
                textBox_ZhengIOOut2_Test.Enabled = false;
                textBox_ZhengIOOut2_Ref2.Enabled = false;
                textBox_ZhengIOOut2_Value1.Enabled = false;
                textBox_ZhengIOOut2_Value2.Enabled = false;
            }
            if (CheckBox_ZhengIOOut3.Checked == true)//IO输出测试通道3使能
            {
                skinCheckBox_ZhengIOOut3.Enabled = true;
                if (skinCheckBox_ZhengIOOut3.Checked == true)
                {
                    textBox_ZhengIOOut3_IN.Enabled = true;
                    textBox_ZhengIOOut3_Ref1.Enabled = true;
                    textBox_ZhengIOOut3_VIn1.Enabled = true;
                    textBox_ZhengIOOut3_VIn2.Enabled = true;
                }
                if (skinCheckBox_ZhengIOOut3.Checked == false)
                {
                    textBox_ZhengIOOut3_IN.Enabled = false;
                    textBox_ZhengIOOut3_Ref1.Enabled = false;
                    textBox_ZhengIOOut3_VIn1.Enabled = false;
                    textBox_ZhengIOOut3_VIn2.Enabled = false;
                }
                textBox_ZhengIOOut3_Test.Enabled = true;
                textBox_ZhengIOOut3_Ref2.Enabled = true;
                textBox_ZhengIOOut3_Value1.Enabled = true;
                textBox_ZhengIOOut3_Value2.Enabled = true;
            }
            else if (CheckBox_ZhengIOOut3.Checked == false)
            {
                skinCheckBox_ZhengIOOut3.Enabled = false;
                skinCheckBox_ZhengIOOut3.Checked = false;
                textBox_ZhengIOOut3_IN.Enabled = false;
                textBox_ZhengIOOut3_Ref1.Enabled = false;
                textBox_ZhengIOOut3_VIn1.Enabled = false;
                textBox_ZhengIOOut3_VIn2.Enabled = false;
                textBox_ZhengIOOut3_Test.Enabled = false;
                textBox_ZhengIOOut3_Ref2.Enabled = false;
                textBox_ZhengIOOut3_Value1.Enabled = false;
                textBox_ZhengIOOut3_Value2.Enabled = false;
            }
            if (CheckBox_ZhengIOOut4.Checked == true)//IO输出测试通道4使能
            {
                skinCheckBox_ZhengIOOut4.Enabled = true;
                if (skinCheckBox_ZhengIOOut4.Checked == true)
                {
                    textBox_ZhengIOOut4_IN.Enabled = true;
                    textBox_ZhengIOOut4_Ref1.Enabled = true;
                    textBox_ZhengIOOut4_VIn1.Enabled = true;
                    textBox_ZhengIOOut4_VIn2.Enabled = true;
                }
                if (skinCheckBox_ZhengIOOut4.Checked == false)
                {
                    textBox_ZhengIOOut4_IN.Enabled = false;
                    textBox_ZhengIOOut4_Ref1.Enabled = false;
                    textBox_ZhengIOOut4_VIn1.Enabled = false;
                    textBox_ZhengIOOut4_VIn2.Enabled = false;
                }
                textBox_ZhengIOOut4_Test.Enabled = true;
                textBox_ZhengIOOut4_Ref2.Enabled = true;
                textBox_ZhengIOOut4_Value1.Enabled = true;
                textBox_ZhengIOOut4_Value2.Enabled = true;
            }
            else if (CheckBox_ZhengIOOut4.Checked == false)
            {
                skinCheckBox_ZhengIOOut4.Enabled = false;
                skinCheckBox_ZhengIOOut4.Checked = false;
                textBox_ZhengIOOut4_IN.Enabled = false;
                textBox_ZhengIOOut4_Ref1.Enabled = false;
                textBox_ZhengIOOut4_VIn1.Enabled = false;
                textBox_ZhengIOOut4_VIn2.Enabled = false;
                textBox_ZhengIOOut4_Test.Enabled = false;
                textBox_ZhengIOOut4_Ref2.Enabled = false;
                textBox_ZhengIOOut4_Value1.Enabled = false;
                textBox_ZhengIOOut4_Value2.Enabled = false;
            }
            if (CheckBox_ZhengIOOut5.Checked == true)//IO输出测试通道5使能
            {
                skinCheckBox_ZhengIOOut5.Enabled = true;
                if (skinCheckBox_ZhengIOOut5.Checked == true)
                {
                    textBox_ZhengIOOut5_IN.Enabled = true;
                    textBox_ZhengIOOut5_Ref1.Enabled = true;
                    textBox_ZhengIOOut5_VIn1.Enabled = true;
                    textBox_ZhengIOOut5_VIn2.Enabled = true;
                }
                if (skinCheckBox_ZhengIOOut5.Checked == false)
                {
                    textBox_ZhengIOOut5_IN.Enabled = false;
                    textBox_ZhengIOOut5_Ref1.Enabled = false;
                    textBox_ZhengIOOut5_VIn1.Enabled = false;
                    textBox_ZhengIOOut5_VIn2.Enabled = false;
                }
                textBox_ZhengIOOut5_Test.Enabled = true;
                textBox_ZhengIOOut5_Ref2.Enabled = true;
                textBox_ZhengIOOut5_Value1.Enabled = true;
                textBox_ZhengIOOut5_Value2.Enabled = true;
            }
            else if (CheckBox_ZhengIOOut5.Checked == false)
            {
                skinCheckBox_ZhengIOOut5.Enabled = false;
                skinCheckBox_ZhengIOOut5.Checked = false;
                textBox_ZhengIOOut5_IN.Enabled = false;
                textBox_ZhengIOOut5_Ref1.Enabled = false;
                textBox_ZhengIOOut5_VIn1.Enabled = false;
                textBox_ZhengIOOut5_VIn2.Enabled = false;
                textBox_ZhengIOOut5_Test.Enabled = false;
                textBox_ZhengIOOut5_Ref2.Enabled = false;
                textBox_ZhengIOOut5_Value1.Enabled = false;
                textBox_ZhengIOOut5_Value2.Enabled = false;
            }
            if (CheckBox_ZhengIOOut6.Checked == true)//IO输出测试通道6使能
            {
                skinCheckBox_ZhengIOOut6.Enabled = true;
                if (skinCheckBox_ZhengIOOut6.Checked == true)
                {
                    textBox_ZhengIOOut6_IN.Enabled = true;
                    textBox_ZhengIOOut6_Ref1.Enabled = true;
                    textBox_ZhengIOOut6_VIn1.Enabled = true;
                    textBox_ZhengIOOut6_VIn2.Enabled = true;
                }
                if (skinCheckBox_ZhengIOOut6.Checked == false)
                {
                    textBox_ZhengIOOut6_IN.Enabled = false;
                    textBox_ZhengIOOut6_Ref1.Enabled = false;
                    textBox_ZhengIOOut6_VIn1.Enabled = false;
                    textBox_ZhengIOOut6_VIn2.Enabled = false;
                }
                textBox_ZhengIOOut6_Test.Enabled = true;
                textBox_ZhengIOOut6_Ref2.Enabled = true;
                textBox_ZhengIOOut6_Value1.Enabled = true;
                textBox_ZhengIOOut6_Value2.Enabled = true;
            }
            else if (CheckBox_ZhengIOOut6.Checked == false)
            {
                skinCheckBox_ZhengIOOut6.Enabled = false;
                skinCheckBox_ZhengIOOut6.Checked = false;
                textBox_ZhengIOOut6_IN.Enabled = false;
                textBox_ZhengIOOut6_Ref1.Enabled = false;
                textBox_ZhengIOOut6_VIn1.Enabled = false;
                textBox_ZhengIOOut6_VIn2.Enabled = false;
                textBox_ZhengIOOut6_Test.Enabled = false;
                textBox_ZhengIOOut6_Ref2.Enabled = false;
                textBox_ZhengIOOut6_Value1.Enabled = false;
                textBox_ZhengIOOut6_Value2.Enabled = false;
            }
            if (CheckBox_ZhengIOOut7.Checked == true)//IO输出测试通道7使能
            {
                skinCheckBox_ZhengIOOut7.Enabled = true;
                if (skinCheckBox_ZhengIOOut7.Checked == true)
                {
                    textBox_ZhengIOOut7_IN.Enabled = true;
                    textBox_ZhengIOOut7_Ref1.Enabled = true;
                    textBox_ZhengIOOut7_VIn1.Enabled = true;
                    textBox_ZhengIOOut7_VIn2.Enabled = true;
                }
                if (skinCheckBox_ZhengIOOut7.Checked == false)
                {
                    textBox_ZhengIOOut7_IN.Enabled = false;
                    textBox_ZhengIOOut7_Ref1.Enabled = false;
                    textBox_ZhengIOOut7_VIn1.Enabled = false;
                    textBox_ZhengIOOut7_VIn2.Enabled = false;
                }
                textBox_ZhengIOOut7_Test.Enabled = true;
                textBox_ZhengIOOut7_Ref2.Enabled = true;
                textBox_ZhengIOOut7_Value1.Enabled = true;
                textBox_ZhengIOOut7_Value2.Enabled = true;
            }
            else if (CheckBox_ZhengIOOut7.Checked == false)
            {
                skinCheckBox_ZhengIOOut7.Enabled = false;
                skinCheckBox_ZhengIOOut7.Checked = false;
                textBox_ZhengIOOut7_IN.Enabled = false;
                textBox_ZhengIOOut7_Ref1.Enabled = false;
                textBox_ZhengIOOut7_VIn1.Enabled = false;
                textBox_ZhengIOOut7_VIn2.Enabled = false;
                textBox_ZhengIOOut7_Test.Enabled = false;
                textBox_ZhengIOOut7_Ref2.Enabled = false;
                textBox_ZhengIOOut7_Value1.Enabled = false;
                textBox_ZhengIOOut7_Value2.Enabled = false;
            }
            if (CheckBox_ZhengIOOut8.Checked == true)//IO输出测试通道8使能
            {
                skinCheckBox_ZhengIOOut8.Enabled = true;
                if (skinCheckBox_ZhengIOOut8.Checked == true)
                {
                    textBox_ZhengIOOut8_IN.Enabled = true;
                    textBox_ZhengIOOut8_Ref1.Enabled = true;
                    textBox_ZhengIOOut8_VIn1.Enabled = true;
                    textBox_ZhengIOOut8_VIn2.Enabled = true;
                }
                if (skinCheckBox_ZhengIOOut8.Checked == false)
                {
                    textBox_ZhengIOOut8_IN.Enabled = false;
                    textBox_ZhengIOOut8_Ref1.Enabled = false;
                    textBox_ZhengIOOut8_VIn1.Enabled = false;
                    textBox_ZhengIOOut8_VIn2.Enabled = false;
                }
                textBox_ZhengIOOut8_Test.Enabled = true;
                textBox_ZhengIOOut8_Ref2.Enabled = true;
                textBox_ZhengIOOut8_Value1.Enabled = true;
                textBox_ZhengIOOut8_Value2.Enabled = true;
            }
            else if (CheckBox_ZhengIOOut8.Checked == false)
            {
                skinCheckBox_ZhengIOOut8.Enabled = false;
                skinCheckBox_ZhengIOOut8.Checked = false;
                textBox_ZhengIOOut8_IN.Enabled = false;
                textBox_ZhengIOOut8_Ref1.Enabled = false;
                textBox_ZhengIOOut8_VIn1.Enabled = false;
                textBox_ZhengIOOut8_VIn2.Enabled = false;
                textBox_ZhengIOOut8_Test.Enabled = false;
                textBox_ZhengIOOut8_Ref2.Enabled = false;
                textBox_ZhengIOOut8_Value1.Enabled = false;
                textBox_ZhengIOOut8_Value2.Enabled = false;
            }
            if (CheckBox_ZhengIOOut9.Checked == true)//IO输出测试通道9使能
            {
                skinCheckBox_ZhengIOOut9.Enabled = true;
                if (skinCheckBox_ZhengIOOut9.Checked == true)
                {
                    textBox_ZhengIOOut9_IN.Enabled = true;
                    textBox_ZhengIOOut9_Ref1.Enabled = true;
                    textBox_ZhengIOOut9_VIn1.Enabled = true;
                    textBox_ZhengIOOut9_VIn2.Enabled = true;
                }
                if (skinCheckBox_ZhengIOOut9.Checked == false)
                {
                    textBox_ZhengIOOut9_IN.Enabled = false;
                    textBox_ZhengIOOut9_Ref1.Enabled = false;
                    textBox_ZhengIOOut9_VIn1.Enabled = false;
                    textBox_ZhengIOOut9_VIn2.Enabled = false;
                }
                textBox_ZhengIOOut9_Test.Enabled = true;
                textBox_ZhengIOOut9_Ref2.Enabled = true;
                textBox_ZhengIOOut9_Value1.Enabled = true;
                textBox_ZhengIOOut9_Value2.Enabled = true;
            }
            else if (CheckBox_ZhengIOOut9.Checked == false)
            {
                skinCheckBox_ZhengIOOut9.Enabled = false;
                skinCheckBox_ZhengIOOut9.Checked = false;
                textBox_ZhengIOOut9_IN.Enabled = false;
                textBox_ZhengIOOut9_Ref1.Enabled = false;
                textBox_ZhengIOOut9_VIn1.Enabled = false;
                textBox_ZhengIOOut9_VIn2.Enabled = false;
                textBox_ZhengIOOut9_Test.Enabled = false;
                textBox_ZhengIOOut9_Ref2.Enabled = false;
                textBox_ZhengIOOut9_Value1.Enabled = false;
                textBox_ZhengIOOut9_Value2.Enabled = false;
            }
            if (CheckBox_ZhengIOOut10.Checked == true)//IO输出测试通道10使能
            {
                skinCheckBox_ZhengIOOut10.Enabled = true;
                if (skinCheckBox_ZhengIOOut10.Checked == true)
                {
                    textBox_ZhengIOOut10_IN.Enabled = true;
                    textBox_ZhengIOOut10_Ref1.Enabled = true;
                    textBox_ZhengIOOut10_VIn1.Enabled = true;
                    textBox_ZhengIOOut10_VIn2.Enabled = true;
                }
                if (skinCheckBox_ZhengIOOut10.Checked == false)
                {
                    textBox_ZhengIOOut10_IN.Enabled = false;
                    textBox_ZhengIOOut10_Ref1.Enabled = false;
                    textBox_ZhengIOOut10_VIn1.Enabled = false;
                    textBox_ZhengIOOut10_VIn2.Enabled = false;
                }
                textBox_ZhengIOOut10_Test.Enabled = true;
                textBox_ZhengIOOut10_Ref2.Enabled = true;
                textBox_ZhengIOOut10_Value1.Enabled = true;
                textBox_ZhengIOOut10_Value2.Enabled = true;
            }
            else if (CheckBox_ZhengIOOut10.Checked == false)
            {
                skinCheckBox_ZhengIOOut10.Enabled = false;
                skinCheckBox_ZhengIOOut10.Checked = false;
                textBox_ZhengIOOut10_IN.Enabled = false;
                textBox_ZhengIOOut10_Ref1.Enabled = false;
                textBox_ZhengIOOut10_VIn1.Enabled = false;
                textBox_ZhengIOOut10_VIn2.Enabled = false;
                textBox_ZhengIOOut10_Test.Enabled = false;
                textBox_ZhengIOOut10_Ref2.Enabled = false;
                textBox_ZhengIOOut10_Value1.Enabled = false;
                textBox_ZhengIOOut10_Value2.Enabled = false;
            }
            if (CheckBox_ZhengIOOut11.Checked == true)//IO输出测试通道11使能
            {
                skinCheckBox_ZhengIOOut11.Enabled = true;
                if (skinCheckBox_ZhengIOOut11.Checked == true)
                {
                    textBox_ZhengIOOut11_IN.Enabled = true;
                    textBox_ZhengIOOut11_Ref1.Enabled = true;
                    textBox_ZhengIOOut11_VIn1.Enabled = true;
                    textBox_ZhengIOOut11_VIn2.Enabled = true;
                }
                if (skinCheckBox_ZhengIOOut11.Checked == false)
                {
                    textBox_ZhengIOOut11_IN.Enabled = false;
                    textBox_ZhengIOOut11_Ref1.Enabled = false;
                    textBox_ZhengIOOut11_VIn1.Enabled = false;
                    textBox_ZhengIOOut11_VIn2.Enabled = false;
                }
                textBox_ZhengIOOut11_Test.Enabled = true;
                textBox_ZhengIOOut11_Ref2.Enabled = true;
                textBox_ZhengIOOut11_Value1.Enabled = true;
                textBox_ZhengIOOut11_Value2.Enabled = true;
            }
            else if (CheckBox_ZhengIOOut11.Checked == false)
            {
                skinCheckBox_ZhengIOOut11.Enabled = false;
                skinCheckBox_ZhengIOOut11.Checked = false;
                textBox_ZhengIOOut11_IN.Enabled = false;
                textBox_ZhengIOOut11_Ref1.Enabled = false;
                textBox_ZhengIOOut11_VIn1.Enabled = false;
                textBox_ZhengIOOut11_VIn2.Enabled = false;
                textBox_ZhengIOOut11_Test.Enabled = false;
                textBox_ZhengIOOut11_Ref2.Enabled = false;
                textBox_ZhengIOOut11_Value1.Enabled = false;
                textBox_ZhengIOOut11_Value2.Enabled = false;
            }
            if (CheckBox_ZhengIOOut12.Checked == true)//IO输出测试通道12使能
            {
                skinCheckBox_ZhengIOOut12.Enabled = true;
                if (skinCheckBox_ZhengIOOut12.Checked == true)
                {
                    textBox_ZhengIOOut12_IN.Enabled = true;
                    textBox_ZhengIOOut12_Ref1.Enabled = true;
                    textBox_ZhengIOOut12_VIn1.Enabled = true;
                    textBox_ZhengIOOut12_VIn2.Enabled = true;
                }
                if (skinCheckBox_ZhengIOOut12.Checked == false)
                {
                    textBox_ZhengIOOut12_IN.Enabled = false;
                    textBox_ZhengIOOut12_Ref1.Enabled = false;
                    textBox_ZhengIOOut12_VIn1.Enabled = false;
                    textBox_ZhengIOOut12_VIn2.Enabled = false;
                }
                textBox_ZhengIOOut12_Test.Enabled = true;
                textBox_ZhengIOOut12_Ref2.Enabled = true;
                textBox_ZhengIOOut12_Value1.Enabled = true;
                textBox_ZhengIOOut12_Value2.Enabled = true;
            }
            else if (CheckBox_ZhengIOOut12.Checked == false)
            {
                skinCheckBox_ZhengIOOut12.Enabled = false;
                skinCheckBox_ZhengIOOut12.Checked = false;
                textBox_ZhengIOOut12_IN.Enabled = false;
                textBox_ZhengIOOut12_Ref1.Enabled = false;
                textBox_ZhengIOOut12_VIn1.Enabled = false;
                textBox_ZhengIOOut12_VIn2.Enabled = false;
                textBox_ZhengIOOut12_Test.Enabled = false;
                textBox_ZhengIOOut12_Ref2.Enabled = false;
                textBox_ZhengIOOut12_Value1.Enabled = false;
                textBox_ZhengIOOut12_Value2.Enabled = false;
            }
            if (CheckBox_ZhengIOOut13.Checked == true)//IO输出测试通道13使能
            {
                skinCheckBox_ZhengIOOut13.Enabled = true;
                if (skinCheckBox_ZhengIOOut13.Checked == true)
                {
                    textBox_ZhengIOOut13_IN.Enabled = true;
                    textBox_ZhengIOOut13_Ref1.Enabled = true;
                    textBox_ZhengIOOut13_VIn1.Enabled = true;
                    textBox_ZhengIOOut13_VIn2.Enabled = true;
                }
                if (skinCheckBox_ZhengIOOut13.Checked == false)
                {
                    textBox_ZhengIOOut13_IN.Enabled = false;
                    textBox_ZhengIOOut13_Ref1.Enabled = false;
                    textBox_ZhengIOOut13_VIn1.Enabled = false;
                    textBox_ZhengIOOut13_VIn2.Enabled = false;
                }
                textBox_ZhengIOOut13_Test.Enabled = true;
                textBox_ZhengIOOut13_Ref2.Enabled = true;
                textBox_ZhengIOOut13_Value1.Enabled = true;
                textBox_ZhengIOOut13_Value2.Enabled = true;
            }
            else if (CheckBox_ZhengIOOut13.Checked == false)
            {
                skinCheckBox_ZhengIOOut13.Enabled = false;
                skinCheckBox_ZhengIOOut13.Checked = false;
                textBox_ZhengIOOut13_IN.Enabled = false;
                textBox_ZhengIOOut13_Ref1.Enabled = false;
                textBox_ZhengIOOut13_VIn1.Enabled = false;
                textBox_ZhengIOOut13_VIn2.Enabled = false;
                textBox_ZhengIOOut13_Test.Enabled = false;
                textBox_ZhengIOOut13_Ref2.Enabled = false;
                textBox_ZhengIOOut13_Value1.Enabled = false;
                textBox_ZhengIOOut13_Value2.Enabled = false;
            }
            if (CheckBox_ZhengIOOut14.Checked == true)//IO输出测试通道14使能
            {
                skinCheckBox_ZhengIOOut14.Enabled = true;
                if (skinCheckBox_ZhengIOOut14.Checked == true)
                {
                    textBox_ZhengIOOut14_IN.Enabled = true;
                    textBox_ZhengIOOut14_Ref1.Enabled = true;
                    textBox_ZhengIOOut14_VIn1.Enabled = true;
                    textBox_ZhengIOOut14_VIn2.Enabled = true;
                }
                if (skinCheckBox_ZhengIOOut14.Checked == false)
                {
                    textBox_ZhengIOOut14_IN.Enabled = false;
                    textBox_ZhengIOOut14_Ref1.Enabled = false;
                    textBox_ZhengIOOut14_VIn1.Enabled = false;
                    textBox_ZhengIOOut14_VIn2.Enabled = false;
                }
                textBox_ZhengIOOut14_Test.Enabled = true;
                textBox_ZhengIOOut14_Ref2.Enabled = true;
                textBox_ZhengIOOut14_Value1.Enabled = true;
                textBox_ZhengIOOut14_Value2.Enabled = true;
            }
            else if (CheckBox_ZhengIOOut14.Checked == false)
            {
                skinCheckBox_ZhengIOOut14.Enabled = false;
                skinCheckBox_ZhengIOOut14.Checked = false;
                textBox_ZhengIOOut14_IN.Enabled = false;
                textBox_ZhengIOOut14_Ref1.Enabled = false;
                textBox_ZhengIOOut14_VIn1.Enabled = false;
                textBox_ZhengIOOut14_VIn2.Enabled = false;
                textBox_ZhengIOOut14_Test.Enabled = false;
                textBox_ZhengIOOut14_Ref2.Enabled = false;
                textBox_ZhengIOOut14_Value1.Enabled = false;
                textBox_ZhengIOOut14_Value2.Enabled = false;
            }
            if (CheckBox_ZhengIOOut15.Checked == true)//IO输出测试通道15使能
            {
                skinCheckBox_ZhengIOOut15.Enabled = true;
                if (skinCheckBox_ZhengIOOut15.Checked == true)
                {
                    textBox_ZhengIOOut15_IN.Enabled = true;
                    textBox_ZhengIOOut15_Ref1.Enabled = true;
                    textBox_ZhengIOOut15_VIn1.Enabled = true;
                    textBox_ZhengIOOut15_VIn2.Enabled = true;
                }
                if (skinCheckBox_ZhengIOOut15.Checked == false)
                {
                    textBox_ZhengIOOut15_IN.Enabled = false;
                    textBox_ZhengIOOut15_Ref1.Enabled = false;
                    textBox_ZhengIOOut15_VIn1.Enabled = false;
                    textBox_ZhengIOOut15_VIn2.Enabled = false;
                }
                textBox_ZhengIOOut15_Test.Enabled = true;
                textBox_ZhengIOOut15_Ref2.Enabled = true;
                textBox_ZhengIOOut15_Value1.Enabled = true;
                textBox_ZhengIOOut15_Value2.Enabled = true;
            }
            else if (CheckBox_ZhengIOOut15.Checked == false)
            {
                skinCheckBox_ZhengIOOut15.Enabled = false;
                skinCheckBox_ZhengIOOut15.Checked = false;
                textBox_ZhengIOOut15_IN.Enabled = false;
                textBox_ZhengIOOut15_Ref1.Enabled = false;
                textBox_ZhengIOOut15_VIn1.Enabled = false;
                textBox_ZhengIOOut15_VIn2.Enabled = false;
                textBox_ZhengIOOut15_Test.Enabled = false;
                textBox_ZhengIOOut15_Ref2.Enabled = false;
                textBox_ZhengIOOut15_Value1.Enabled = false;
                textBox_ZhengIOOut15_Value2.Enabled = false;
            }
            if (CheckBox_ZhengIOOut16.Checked == true)//IO输出测试通道16使能
            {
                skinCheckBox_ZhengIOOut16.Enabled = true;
                if (skinCheckBox_ZhengIOOut16.Checked == true)
                {
                    textBox_ZhengIOOut16_IN.Enabled = true;
                    textBox_ZhengIOOut16_Ref1.Enabled = true;
                    textBox_ZhengIOOut16_VIn1.Enabled = true;
                    textBox_ZhengIOOut16_VIn2.Enabled = true;
                }
                if (skinCheckBox_ZhengIOOut16.Checked == false)
                {
                    textBox_ZhengIOOut16_IN.Enabled = false;
                    textBox_ZhengIOOut16_Ref1.Enabled = false;
                    textBox_ZhengIOOut16_VIn1.Enabled = false;
                    textBox_ZhengIOOut16_VIn2.Enabled = false;
                }
                textBox_ZhengIOOut16_Test.Enabled = true;
                textBox_ZhengIOOut16_Ref2.Enabled = true;
                textBox_ZhengIOOut16_Value1.Enabled = true;
                textBox_ZhengIOOut16_Value2.Enabled = true;
            }
            else if (CheckBox_ZhengIOOut16.Checked == false)
            {
                skinCheckBox_ZhengIOOut16.Enabled = false;
                skinCheckBox_ZhengIOOut16.Checked = false;
                textBox_ZhengIOOut16_IN.Enabled = false;
                textBox_ZhengIOOut16_Ref1.Enabled = false;
                textBox_ZhengIOOut16_VIn1.Enabled = false;
                textBox_ZhengIOOut16_VIn2.Enabled = false;
                textBox_ZhengIOOut16_Test.Enabled = false;
                textBox_ZhengIOOut16_Ref2.Enabled = false;
                textBox_ZhengIOOut16_Value1.Enabled = false;
                textBox_ZhengIOOut16_Value2.Enabled = false;
            }

            if (CheckBox_ZhengIOIn1.Checked == true)//IO输入测试通道1使能
            {
                textBox_ZhengIOIn1_IN.Enabled = true;
                textBox_ZhengIOIn1_Ref1.Enabled = true;
                textBox_ZhengIOIn1_VIn1.Enabled = true;
                textBox_ZhengIOIn1_VIn2.Enabled = true;
                skinCheckBox_ZhengIOIn1.Enabled = true;
                textBox_ZhengIOIn1_Value1.Enabled = true;
                textBox_ZhengIOIn1_Value2.Enabled = true;
                if (skinCheckBox_ZhengIOIn1.Checked == true)//梳理skin复选框逻辑
                {
                    textBox_ZhengIOIn1_Test.Enabled = true;
                    textBox_ZhengIOIn1_Ref2.Enabled = true;
                }
                if (skinCheckBox_ZhengIOIn1.Checked == false)
                {
                    textBox_ZhengIOIn1_Test.Enabled = false;
                    textBox_ZhengIOIn1_Ref2.Enabled = false;
                }
            }
            else if (CheckBox_ZhengIOIn1.Checked == false)
            {
                textBox_ZhengIOIn1_IN.Enabled = false;
                textBox_ZhengIOIn1_Ref1.Enabled = false;
                textBox_ZhengIOIn1_VIn1.Enabled = false;
                textBox_ZhengIOIn1_VIn2.Enabled = false;
                skinCheckBox_ZhengIOIn1.Enabled = false;
                skinCheckBox_ZhengIOIn1.Checked = false;
                textBox_ZhengIOIn1_Test.Enabled = false;
                textBox_ZhengIOIn1_Ref2.Enabled = false;
                textBox_ZhengIOIn1_Value1.Enabled = false;
                textBox_ZhengIOIn1_Value2.Enabled = false;
            }
            if (CheckBox_ZhengIOIn2.Checked == true)//IO输入测试通道2使能
            {
                textBox_ZhengIOIn2_IN.Enabled = true;
                textBox_ZhengIOIn2_Ref1.Enabled = true;
                textBox_ZhengIOIn2_VIn1.Enabled = true;
                textBox_ZhengIOIn2_VIn2.Enabled = true;
                skinCheckBox_ZhengIOIn2.Enabled = true;
                textBox_ZhengIOIn2_Value1.Enabled = true;
                textBox_ZhengIOIn2_Value2.Enabled = true;
                if (skinCheckBox_ZhengIOIn2.Checked == true)//梳理skin复选框逻辑
                {
                    textBox_ZhengIOIn2_Test.Enabled = true;
                    textBox_ZhengIOIn2_Ref2.Enabled = true;
                }
                if (skinCheckBox_ZhengIOIn2.Checked == false)
                {
                    textBox_ZhengIOIn2_Test.Enabled = false;
                    textBox_ZhengIOIn2_Ref2.Enabled = false;
                }
            }
            else if (CheckBox_ZhengIOIn2.Checked == false)
            {
                textBox_ZhengIOIn2_IN.Enabled = false;
                textBox_ZhengIOIn2_Ref1.Enabled = false;
                textBox_ZhengIOIn2_VIn1.Enabled = false;
                textBox_ZhengIOIn2_VIn2.Enabled = false;
                skinCheckBox_ZhengIOIn2.Enabled = false;
                skinCheckBox_ZhengIOIn2.Checked = false;
                textBox_ZhengIOIn2_Test.Enabled = false;
                textBox_ZhengIOIn2_Ref2.Enabled = false;
                textBox_ZhengIOIn2_Value1.Enabled = false;
                textBox_ZhengIOIn2_Value2.Enabled = false;
            }
            if (CheckBox_ZhengIOIn3.Checked == true)//IO输入测试通道3使能
            {
                textBox_ZhengIOIn3_IN.Enabled = true;
                textBox_ZhengIOIn3_Ref1.Enabled = true;
                textBox_ZhengIOIn3_VIn1.Enabled = true;
                textBox_ZhengIOIn3_VIn2.Enabled = true;
                skinCheckBox_ZhengIOIn3.Enabled = true;
                textBox_ZhengIOIn3_Value1.Enabled = true;
                textBox_ZhengIOIn3_Value2.Enabled = true;
                if (skinCheckBox_ZhengIOIn3.Checked == true)//梳理skin复选框逻辑
                {
                    textBox_ZhengIOIn3_Test.Enabled = true;
                    textBox_ZhengIOIn3_Ref2.Enabled = true;
                }
                if (skinCheckBox_ZhengIOIn3.Checked == false)
                {
                    textBox_ZhengIOIn3_Test.Enabled = false;
                    textBox_ZhengIOIn3_Ref2.Enabled = false;
                }
            }
            else if (CheckBox_ZhengIOIn3.Checked == false)
            {
                textBox_ZhengIOIn3_IN.Enabled = false;
                textBox_ZhengIOIn3_Ref1.Enabled = false;
                textBox_ZhengIOIn3_VIn1.Enabled = false;
                textBox_ZhengIOIn3_VIn2.Enabled = false;
                skinCheckBox_ZhengIOIn3.Enabled = false;
                skinCheckBox_ZhengIOIn3.Checked = false;
                textBox_ZhengIOIn3_Test.Enabled = false;
                textBox_ZhengIOIn3_Ref2.Enabled = false;
                textBox_ZhengIOIn3_Value1.Enabled = false;
                textBox_ZhengIOIn3_Value2.Enabled = false;
            }
            if (CheckBox_ZhengIOIn4.Checked == true)//IO输入测试通道4使能
            {
                textBox_ZhengIOIn4_IN.Enabled = true;
                textBox_ZhengIOIn4_Ref1.Enabled = true;
                textBox_ZhengIOIn4_VIn1.Enabled = true;
                textBox_ZhengIOIn4_VIn2.Enabled = true;
                skinCheckBox_ZhengIOIn4.Enabled = true;
                textBox_ZhengIOIn4_Value1.Enabled = true;
                textBox_ZhengIOIn4_Value2.Enabled = true;
                if (skinCheckBox_ZhengIOIn4.Checked == true)//梳理skin复选框逻辑
                {
                    textBox_ZhengIOIn4_Test.Enabled = true;
                    textBox_ZhengIOIn4_Ref2.Enabled = true;
                }
                if (skinCheckBox_ZhengIOIn4.Checked == false)
                {
                    textBox_ZhengIOIn4_Test.Enabled = false;
                    textBox_ZhengIOIn4_Ref2.Enabled = false;
                }
            }
            else if (CheckBox_ZhengIOIn4.Checked == false)
            {
                textBox_ZhengIOIn4_IN.Enabled = false;
                textBox_ZhengIOIn4_Ref1.Enabled = false;
                textBox_ZhengIOIn4_VIn1.Enabled = false;
                textBox_ZhengIOIn4_VIn2.Enabled = false;
                skinCheckBox_ZhengIOIn4.Enabled = false;
                skinCheckBox_ZhengIOIn4.Checked = false;
                textBox_ZhengIOIn4_Test.Enabled = false;
                textBox_ZhengIOIn4_Ref2.Enabled = false;
                textBox_ZhengIOIn4_Value1.Enabled = false;
                textBox_ZhengIOIn4_Value2.Enabled = false;
            }
            if (CheckBox_ZhengIOIn5.Checked == true)//IO输入测试通道5使能
            {
                textBox_ZhengIOIn5_IN.Enabled = true;
                textBox_ZhengIOIn5_Ref1.Enabled = true;
                textBox_ZhengIOIn5_VIn1.Enabled = true;
                textBox_ZhengIOIn5_VIn2.Enabled = true;
                skinCheckBox_ZhengIOIn5.Enabled = true;
                textBox_ZhengIOIn5_Value1.Enabled = true;
                textBox_ZhengIOIn5_Value2.Enabled = true;
                if (skinCheckBox_ZhengIOIn5.Checked == true)//梳理skin复选框逻辑
                {
                    textBox_ZhengIOIn5_Test.Enabled = true;
                    textBox_ZhengIOIn5_Ref2.Enabled = true;
                }
                if (skinCheckBox_ZhengIOIn5.Checked == false)
                {
                    textBox_ZhengIOIn5_Test.Enabled = false;
                    textBox_ZhengIOIn5_Ref2.Enabled = false;
                }
            }
            else if (CheckBox_ZhengIOIn5.Checked == false)
            {
                textBox_ZhengIOIn5_IN.Enabled = false;
                textBox_ZhengIOIn5_Ref1.Enabled = false;
                textBox_ZhengIOIn5_VIn1.Enabled = false;
                textBox_ZhengIOIn5_VIn2.Enabled = false;
                skinCheckBox_ZhengIOIn5.Enabled = false;
                skinCheckBox_ZhengIOIn5.Checked = false;
                textBox_ZhengIOIn5_Test.Enabled = false;
                textBox_ZhengIOIn5_Ref2.Enabled = false;
                textBox_ZhengIOIn5_Value1.Enabled = false;
                textBox_ZhengIOIn5_Value2.Enabled = false;
            }
            if (CheckBox_ZhengIOIn6.Checked == true)//IO输入测试通道6使能
            {
                textBox_ZhengIOIn6_IN.Enabled = true;
                textBox_ZhengIOIn6_Ref1.Enabled = true;
                textBox_ZhengIOIn6_VIn1.Enabled = true;
                textBox_ZhengIOIn6_VIn2.Enabled = true;
                skinCheckBox_ZhengIOIn6.Enabled = true;
                textBox_ZhengIOIn6_Value1.Enabled = true;
                textBox_ZhengIOIn6_Value2.Enabled = true;
                if (skinCheckBox_ZhengIOIn6.Checked == true)//梳理skin复选框逻辑
                {
                    textBox_ZhengIOIn6_Test.Enabled = true;
                    textBox_ZhengIOIn6_Ref2.Enabled = true;
                }
                if (skinCheckBox_ZhengIOIn6.Checked == false)
                {
                    textBox_ZhengIOIn6_Test.Enabled = false;
                    textBox_ZhengIOIn6_Ref2.Enabled = false;
                }
            }
            else if (CheckBox_ZhengIOIn6.Checked == false)
            {
                textBox_ZhengIOIn6_IN.Enabled = false;
                textBox_ZhengIOIn6_Ref1.Enabled = false;
                textBox_ZhengIOIn6_VIn1.Enabled = false;
                textBox_ZhengIOIn6_VIn2.Enabled = false;
                skinCheckBox_ZhengIOIn6.Enabled = false;
                skinCheckBox_ZhengIOIn6.Checked = false;
                textBox_ZhengIOIn6_Test.Enabled = false;
                textBox_ZhengIOIn6_Ref2.Enabled = false;
                textBox_ZhengIOIn6_Value1.Enabled = false;
                textBox_ZhengIOIn6_Value2.Enabled = false;
            }
            if (CheckBox_ZhengIOIn7.Checked == true)//IO输入测试通道7使能
            {
                textBox_ZhengIOIn7_IN.Enabled = true;
                textBox_ZhengIOIn7_Ref1.Enabled = true;
                textBox_ZhengIOIn7_VIn1.Enabled = true;
                textBox_ZhengIOIn7_VIn2.Enabled = true;
                skinCheckBox_ZhengIOIn7.Enabled = true;
                textBox_ZhengIOIn7_Value1.Enabled = true;
                textBox_ZhengIOIn7_Value2.Enabled = true;
                if (skinCheckBox_ZhengIOIn7.Checked == true)//梳理skin复选框逻辑
                {
                    textBox_ZhengIOIn7_Test.Enabled = true;
                    textBox_ZhengIOIn7_Ref2.Enabled = true;
                }
                if (skinCheckBox_ZhengIOIn7.Checked == false)
                {
                    textBox_ZhengIOIn7_Test.Enabled = false;
                    textBox_ZhengIOIn7_Ref2.Enabled = false;
                }
            }
            else if (CheckBox_ZhengIOIn7.Checked == false)
            {
                textBox_ZhengIOIn7_IN.Enabled = false;
                textBox_ZhengIOIn7_Ref1.Enabled = false;
                textBox_ZhengIOIn7_VIn1.Enabled = false;
                textBox_ZhengIOIn7_VIn2.Enabled = false;
                skinCheckBox_ZhengIOIn7.Enabled = false;
                skinCheckBox_ZhengIOIn7.Checked = false;
                textBox_ZhengIOIn7_Test.Enabled = false;
                textBox_ZhengIOIn7_Ref2.Enabled = false;
                textBox_ZhengIOIn7_Value1.Enabled = false;
                textBox_ZhengIOIn7_Value2.Enabled = false;
            }
            if (CheckBox_ZhengIOIn8.Checked == true)//IO输入测试通道8使能
            {
                textBox_ZhengIOIn8_IN.Enabled = true;
                textBox_ZhengIOIn8_Ref1.Enabled = true;
                textBox_ZhengIOIn8_VIn1.Enabled = true;
                textBox_ZhengIOIn8_VIn2.Enabled = true;
                skinCheckBox_ZhengIOIn8.Enabled = true;
                textBox_ZhengIOIn8_Value1.Enabled = true;
                textBox_ZhengIOIn8_Value2.Enabled = true;
                if (skinCheckBox_ZhengIOIn8.Checked == true)//梳理skin复选框逻辑
                {
                    textBox_ZhengIOIn8_Test.Enabled = true;
                    textBox_ZhengIOIn8_Ref2.Enabled = true;
                }
                if (skinCheckBox_ZhengIOIn8.Checked == false)
                {
                    textBox_ZhengIOIn8_Test.Enabled = false;
                    textBox_ZhengIOIn8_Ref2.Enabled = false;
                }
            }
            else if (CheckBox_ZhengIOIn8.Checked == false)
            {
                textBox_ZhengIOIn8_IN.Enabled = false;
                textBox_ZhengIOIn8_Ref1.Enabled = false;
                textBox_ZhengIOIn8_VIn1.Enabled = false;
                textBox_ZhengIOIn8_VIn2.Enabled = false;
                skinCheckBox_ZhengIOIn8.Enabled = false;
                skinCheckBox_ZhengIOIn8.Checked = false;
                textBox_ZhengIOIn8_Test.Enabled = false;
                textBox_ZhengIOIn8_Ref2.Enabled = false;
                textBox_ZhengIOIn8_Value1.Enabled = false;
                textBox_ZhengIOIn8_Value2.Enabled = false;
            }
            if (CheckBox_ZhengIOIn9.Checked == true)//IO输入测试通道9使能
            {
                textBox_ZhengIOIn9_IN.Enabled = true;
                textBox_ZhengIOIn9_Ref1.Enabled = true;
                textBox_ZhengIOIn9_VIn1.Enabled = true;
                textBox_ZhengIOIn9_VIn2.Enabled = true;
                skinCheckBox_ZhengIOIn9.Enabled = true;
                textBox_ZhengIOIn9_Value1.Enabled = true;
                textBox_ZhengIOIn9_Value2.Enabled = true;
                if (skinCheckBox_ZhengIOIn9.Checked == true)//梳理skin复选框逻辑
                {
                    textBox_ZhengIOIn9_Test.Enabled = true;
                    textBox_ZhengIOIn9_Ref2.Enabled = true;
                }
                if (skinCheckBox_ZhengIOIn9.Checked == false)
                {
                    textBox_ZhengIOIn9_Test.Enabled = false;
                    textBox_ZhengIOIn9_Ref2.Enabled = false;
                }
            }
            else if (CheckBox_ZhengIOIn9.Checked == false)
            {
                textBox_ZhengIOIn9_IN.Enabled = false;
                textBox_ZhengIOIn9_Ref1.Enabled = false;
                textBox_ZhengIOIn9_VIn1.Enabled = false;
                textBox_ZhengIOIn9_VIn2.Enabled = false;
                skinCheckBox_ZhengIOIn9.Enabled = false;
                skinCheckBox_ZhengIOIn9.Checked = false;
                textBox_ZhengIOIn9_Test.Enabled = false;
                textBox_ZhengIOIn9_Ref2.Enabled = false;
                textBox_ZhengIOIn9_Value1.Enabled = false;
                textBox_ZhengIOIn9_Value2.Enabled = false;
            }
            if (CheckBox_ZhengIOIn10.Checked == true)//IO输入测试通道10使能
            {
                textBox_ZhengIOIn10_IN.Enabled = true;
                textBox_ZhengIOIn10_Ref1.Enabled = true;
                textBox_ZhengIOIn10_VIn1.Enabled = true;
                textBox_ZhengIOIn10_VIn2.Enabled = true;
                skinCheckBox_ZhengIOIn10.Enabled = true;
                textBox_ZhengIOIn10_Value1.Enabled = true;
                textBox_ZhengIOIn10_Value2.Enabled = true;
                if (skinCheckBox_ZhengIOIn10.Checked == true)//梳理skin复选框逻辑
                {
                    textBox_ZhengIOIn10_Test.Enabled = true;
                    textBox_ZhengIOIn10_Ref2.Enabled = true;
                }
                if (skinCheckBox_ZhengIOIn10.Checked == false)
                {
                    textBox_ZhengIOIn10_Test.Enabled = false;
                    textBox_ZhengIOIn10_Ref2.Enabled = false;
                }
            }
            else if (CheckBox_ZhengIOIn10.Checked == false)
            {
                textBox_ZhengIOIn10_IN.Enabled = false;
                textBox_ZhengIOIn10_Ref1.Enabled = false;
                textBox_ZhengIOIn10_VIn1.Enabled = false;
                textBox_ZhengIOIn10_VIn2.Enabled = false;
                skinCheckBox_ZhengIOIn10.Enabled = false;
                skinCheckBox_ZhengIOIn10.Checked = false;
                textBox_ZhengIOIn10_Test.Enabled = false;
                textBox_ZhengIOIn10_Ref2.Enabled = false;
                textBox_ZhengIOIn10_Value1.Enabled = false;
                textBox_ZhengIOIn10_Value2.Enabled = false;
            }
            if (CheckBox_ZhengIOIn11.Checked == true)//IO输入测试通道11使能
            {
                textBox_ZhengIOIn11_IN.Enabled = true;
                textBox_ZhengIOIn11_Ref1.Enabled = true;
                radioButton_ZhengIOIn11a_C.Enabled = true;
                radioButton_ZhengIOIn11b_C.Enabled = true;
                textBox_ZhengIOIn11_Value1.Enabled = true;
                textBox_ZhengIOIn11_Value2.Enabled = true;
                if (radioButton_ZhengIOIn11a_C.Checked == true)//梳理单选框逻辑
                {
                    textBox_ZhengIOIn11_VIn1.Enabled = true;
                    textBox_ZhengIOIn11_VIn2.Enabled = true;
                }
                else
                {
                    textBox_ZhengIOIn11_VIn1.Enabled = false;
                    textBox_ZhengIOIn11_VIn2.Enabled = false;
                }
                if (radioButton_ZhengIOIn11b_C.Checked == true)
                {
                    textBox_ZhengIOIn11b_VIn1.Enabled = true;
                    textBox_ZhengIOIn11b_VIn2.Enabled = true;
                    skinCheckBox_ZhengIOIn11.Enabled = true;
                    if (skinCheckBox_ZhengIOIn11.Checked == true)
                    {
                        textBox_ZhengIOIn11_Test.Enabled = true;
                        textBox_ZhengIOIn11_Ref2.Enabled = true;
                    }
                    else
                    {
                        textBox_ZhengIOIn11_Test.Enabled = false;
                        textBox_ZhengIOIn11_Ref2.Enabled = false;
                    }
                }
                else
                {
                    textBox_ZhengIOIn11b_VIn1.Enabled = false;
                    textBox_ZhengIOIn11b_VIn2.Enabled = false;
                    skinCheckBox_ZhengIOIn11.Enabled = false;
                    skinCheckBox_ZhengIOIn11.Checked = false;
                    textBox_ZhengIOIn11_Test.Enabled = false;
                    textBox_ZhengIOIn11_Ref2.Enabled = false;
                }
            }
            else if (CheckBox_ZhengIOIn11.Checked == false)
            {
                textBox_ZhengIOIn11_IN.Enabled = false;
                textBox_ZhengIOIn11_Ref1.Enabled = false;
                radioButton_ZhengIOIn11a_C.Enabled = false;
                radioButton_ZhengIOIn11a_C.Checked = true;
                radioButton_ZhengIOIn11b_C.Enabled = false;
                textBox_ZhengIOIn11_VIn1.Enabled = false;
                textBox_ZhengIOIn11_VIn2.Enabled = false;
                textBox_ZhengIOIn11b_VIn1.Enabled = false;
                textBox_ZhengIOIn11b_VIn2.Enabled = false;
                skinCheckBox_ZhengIOIn11.Enabled = false;
                skinCheckBox_ZhengIOIn11.Checked = false;
                textBox_ZhengIOIn11_Test.Enabled = false;
                textBox_ZhengIOIn11_Ref2.Enabled = false;
                textBox_ZhengIOIn11_Value1.Enabled = false;
                textBox_ZhengIOIn11_Value2.Enabled = false;
            }
            if (CheckBox_ZhengIOIn12.Checked == true)//IO输入测试通道12使能
            {
                textBox_ZhengIOIn12_IN.Enabled = true;
                textBox_ZhengIOIn12_Ref1.Enabled = true;
                radioButton_ZhengIOIn12a_C.Enabled = true;
                radioButton_ZhengIOIn12b_C.Enabled = true;
                textBox_ZhengIOIn12_Value1.Enabled = true;
                textBox_ZhengIOIn12_Value2.Enabled = true;
                if (radioButton_ZhengIOIn12a_C.Checked == true)//梳理单选框逻辑
                {
                    textBox_ZhengIOIn12_VIn1.Enabled = true;
                    textBox_ZhengIOIn12_VIn2.Enabled = true;
                }
                else
                {
                    textBox_ZhengIOIn12_VIn1.Enabled = false;
                    textBox_ZhengIOIn12_VIn2.Enabled = false;
                }
                if (radioButton_ZhengIOIn12b_C.Checked == true)
                {
                    textBox_ZhengIOIn12b_VIn1.Enabled = true;
                    textBox_ZhengIOIn12b_VIn2.Enabled = true;
                    skinCheckBox_ZhengIOIn12.Enabled = true;
                    if (skinCheckBox_ZhengIOIn12.Checked == true)
                    {
                        textBox_ZhengIOIn12_Test.Enabled = true;
                        textBox_ZhengIOIn12_Ref2.Enabled = true;
                    }
                    else
                    {
                        textBox_ZhengIOIn12_Test.Enabled = false;
                        textBox_ZhengIOIn12_Ref2.Enabled = false;
                    }
                }
                else
                {
                    textBox_ZhengIOIn12b_VIn1.Enabled = false;
                    textBox_ZhengIOIn12b_VIn2.Enabled = false;
                    skinCheckBox_ZhengIOIn12.Enabled = false;
                    skinCheckBox_ZhengIOIn12.Checked = false;
                    textBox_ZhengIOIn12_Test.Enabled = false;
                    textBox_ZhengIOIn12_Ref2.Enabled = false;
                }
            }
            else if (CheckBox_ZhengIOIn12.Checked == false)
            {
                textBox_ZhengIOIn12_IN.Enabled = false;
                textBox_ZhengIOIn12_Ref1.Enabled = false;
                radioButton_ZhengIOIn12a_C.Enabled = false;
                radioButton_ZhengIOIn12a_C.Checked = true;
                radioButton_ZhengIOIn12b_C.Enabled = false;
                textBox_ZhengIOIn12_VIn1.Enabled = false;
                textBox_ZhengIOIn12_VIn2.Enabled = false;
                textBox_ZhengIOIn12b_VIn1.Enabled = false;
                textBox_ZhengIOIn12b_VIn2.Enabled = false;
                skinCheckBox_ZhengIOIn12.Enabled = false;
                skinCheckBox_ZhengIOIn12.Checked = false;
                textBox_ZhengIOIn12_Test.Enabled = false;
                textBox_ZhengIOIn12_Ref2.Enabled = false;
                textBox_ZhengIOIn12_Value1.Enabled = false;
                textBox_ZhengIOIn12_Value2.Enabled = false;
            }
            if (CheckBox_ZhengIOIn13.Checked == true)//IO输入测试通道13使能
            {
                textBox_ZhengIOIn13_IN.Enabled = true;
                textBox_ZhengIOIn13_Ref1.Enabled = true;
                radioButton_ZhengIOIn13a_C.Enabled = true;
                radioButton_ZhengIOIn13b_C.Enabled = true;
                textBox_ZhengIOIn13_Value1.Enabled = true;
                textBox_ZhengIOIn13_Value2.Enabled = true;
                if (radioButton_ZhengIOIn13a_C.Checked == true)//梳理单选框逻辑
                {
                    textBox_ZhengIOIn13_VIn1.Enabled = true;
                    textBox_ZhengIOIn13_VIn2.Enabled = true;
                }
                else
                {
                    textBox_ZhengIOIn13_VIn1.Enabled = false;
                    textBox_ZhengIOIn13_VIn2.Enabled = false;
                }
                if (radioButton_ZhengIOIn13b_C.Checked == true)
                {
                    textBox_ZhengIOIn13b_VIn1.Enabled = true;
                    textBox_ZhengIOIn13b_VIn2.Enabled = true;
                    skinCheckBox_ZhengIOIn13.Enabled = true;
                    if (skinCheckBox_ZhengIOIn13.Checked == true)
                    {
                        textBox_ZhengIOIn13_Test.Enabled = true;
                        textBox_ZhengIOIn13_Ref2.Enabled = true;
                    }
                    else
                    {
                        textBox_ZhengIOIn13_Test.Enabled = false;
                        textBox_ZhengIOIn13_Ref2.Enabled = false;
                    }
                }
                else
                {
                    textBox_ZhengIOIn13b_VIn1.Enabled = false;
                    textBox_ZhengIOIn13b_VIn2.Enabled = false;
                    skinCheckBox_ZhengIOIn13.Enabled = false;
                    skinCheckBox_ZhengIOIn13.Checked = false;
                    textBox_ZhengIOIn13_Test.Enabled = false;
                    textBox_ZhengIOIn13_Ref2.Enabled = false;
                }
            }
            else if (CheckBox_ZhengIOIn13.Checked == false)
            {
                textBox_ZhengIOIn13_IN.Enabled = false;
                textBox_ZhengIOIn13_Ref1.Enabled = false;
                radioButton_ZhengIOIn13a_C.Enabled = false;
                radioButton_ZhengIOIn13a_C.Checked = true;
                radioButton_ZhengIOIn13b_C.Enabled = false;
                textBox_ZhengIOIn13_VIn1.Enabled = false;
                textBox_ZhengIOIn13_VIn2.Enabled = false;
                textBox_ZhengIOIn13b_VIn1.Enabled = false;
                textBox_ZhengIOIn13b_VIn2.Enabled = false;
                skinCheckBox_ZhengIOIn13.Enabled = false;
                skinCheckBox_ZhengIOIn13.Checked = false;
                textBox_ZhengIOIn13_Test.Enabled = false;
                textBox_ZhengIOIn13_Ref2.Enabled = false;
                textBox_ZhengIOIn13_Value1.Enabled = false;
                textBox_ZhengIOIn13_Value2.Enabled = false;
            }
            if (CheckBox_ZhengIOIn14.Checked == true)//IO输入测试通道14使能
            {
                textBox_ZhengIOIn14_IN.Enabled = true;
                textBox_ZhengIOIn14_Ref1.Enabled = true;
                radioButton_ZhengIOIn14a_C.Enabled = true;
                radioButton_ZhengIOIn14b_C.Enabled = true;
                textBox_ZhengIOIn14_Value1.Enabled = true;
                textBox_ZhengIOIn14_Value2.Enabled = true;
                if (radioButton_ZhengIOIn14a_C.Checked == true)//梳理单选框逻辑
                {
                    textBox_ZhengIOIn14_VIn1.Enabled = true;
                    textBox_ZhengIOIn14_VIn2.Enabled = true;
                }
                else
                {
                    textBox_ZhengIOIn14_VIn1.Enabled = false;
                    textBox_ZhengIOIn14_VIn2.Enabled = false;
                }
                if (radioButton_ZhengIOIn14b_C.Checked == true)
                {
                    textBox_ZhengIOIn14b_VIn1.Enabled = true;
                    textBox_ZhengIOIn14b_VIn2.Enabled = true;
                    skinCheckBox_ZhengIOIn14.Enabled = true;
                    if (skinCheckBox_ZhengIOIn14.Checked == true)
                    {
                        textBox_ZhengIOIn14_Test.Enabled = true;
                        textBox_ZhengIOIn14_Ref2.Enabled = true;
                    }
                    else
                    {
                        textBox_ZhengIOIn14_Test.Enabled = false;
                        textBox_ZhengIOIn14_Ref2.Enabled = false;
                    }
                }
                else
                {
                    textBox_ZhengIOIn14b_VIn1.Enabled = false;
                    textBox_ZhengIOIn14b_VIn2.Enabled = false;
                    skinCheckBox_ZhengIOIn14.Enabled = false;
                    skinCheckBox_ZhengIOIn14.Checked = false;
                    textBox_ZhengIOIn14_Test.Enabled = false;
                    textBox_ZhengIOIn14_Ref2.Enabled = false;
                }
            }
            else if (CheckBox_ZhengIOIn14.Checked == false)
            {
                textBox_ZhengIOIn14_IN.Enabled = false;
                textBox_ZhengIOIn14_Ref1.Enabled = false;
                radioButton_ZhengIOIn14a_C.Enabled = false;
                radioButton_ZhengIOIn14a_C.Checked = true;
                radioButton_ZhengIOIn14b_C.Enabled = false;
                textBox_ZhengIOIn14_VIn1.Enabled = false;
                textBox_ZhengIOIn14_VIn2.Enabled = false;
                textBox_ZhengIOIn14b_VIn1.Enabled = false;
                textBox_ZhengIOIn14b_VIn2.Enabled = false;
                skinCheckBox_ZhengIOIn14.Enabled = false;
                skinCheckBox_ZhengIOIn14.Checked = false;
                textBox_ZhengIOIn14_Test.Enabled = false;
                textBox_ZhengIOIn14_Ref2.Enabled = false;
                textBox_ZhengIOIn14_Value1.Enabled = false;
                textBox_ZhengIOIn14_Value2.Enabled = false;
            }
            if (CheckBox_ZhengIOIn15.Checked == true)//IO输入测试通道15使能
            {
                textBox_ZhengIOIn15_IN.Enabled = true;
                textBox_ZhengIOIn15_Ref1.Enabled = true;
                radioButton_ZhengIOIn15a_C.Enabled = true;
                radioButton_ZhengIOIn15b_C.Enabled = true;
                textBox_ZhengIOIn15_Value1.Enabled = true;
                textBox_ZhengIOIn15_Value2.Enabled = true;
                if (radioButton_ZhengIOIn15a_C.Checked == true)//梳理单选框逻辑
                {
                    textBox_ZhengIOIn15_VIn1.Enabled = true;
                    textBox_ZhengIOIn15_VIn2.Enabled = true;
                }
                else
                {
                    textBox_ZhengIOIn15_VIn1.Enabled = false;
                    textBox_ZhengIOIn15_VIn2.Enabled = false;
                }
                if (radioButton_ZhengIOIn15b_C.Checked == true)
                {
                    textBox_ZhengIOIn15b_VIn1.Enabled = true;
                    textBox_ZhengIOIn15b_VIn2.Enabled = true;
                    skinCheckBox_ZhengIOIn15.Enabled = true;
                    if (skinCheckBox_ZhengIOIn15.Checked == true)
                    {
                        textBox_ZhengIOIn15_Test.Enabled = true;
                        textBox_ZhengIOIn15_Ref2.Enabled = true;
                    }
                    else
                    {
                        textBox_ZhengIOIn15_Test.Enabled = false;
                        textBox_ZhengIOIn15_Ref2.Enabled = false;
                    }
                }
                else
                {
                    textBox_ZhengIOIn15b_VIn1.Enabled = false;
                    textBox_ZhengIOIn15b_VIn2.Enabled = false;
                    skinCheckBox_ZhengIOIn15.Enabled = false;
                    skinCheckBox_ZhengIOIn15.Checked = false;
                    textBox_ZhengIOIn15_Test.Enabled = false;
                    textBox_ZhengIOIn15_Ref2.Enabled = false;
                }
            }
            else if (CheckBox_ZhengIOIn15.Checked == false)
            {
                textBox_ZhengIOIn15_IN.Enabled = false;
                textBox_ZhengIOIn15_Ref1.Enabled = false;
                radioButton_ZhengIOIn15a_C.Enabled = false;
                radioButton_ZhengIOIn15a_C.Checked = true;
                radioButton_ZhengIOIn15b_C.Enabled = false;
                textBox_ZhengIOIn15_VIn1.Enabled = false;
                textBox_ZhengIOIn15_VIn2.Enabled = false;
                textBox_ZhengIOIn15b_VIn1.Enabled = false;
                textBox_ZhengIOIn15b_VIn2.Enabled = false;
                skinCheckBox_ZhengIOIn15.Enabled = false;
                skinCheckBox_ZhengIOIn15.Checked = false;
                textBox_ZhengIOIn15_Test.Enabled = false;
                textBox_ZhengIOIn15_Ref2.Enabled = false;
                textBox_ZhengIOIn15_Value1.Enabled = false;
                textBox_ZhengIOIn15_Value2.Enabled = false;
            }
            if (CheckBox_ZhengIOIn16.Checked == true)//IO输入测试通道16使能
            {
                textBox_ZhengIOIn16_IN.Enabled = true;
                textBox_ZhengIOIn16_Ref1.Enabled = true;
                radioButton_ZhengIOIn16a_C.Enabled = true;
                radioButton_ZhengIOIn16b_C.Enabled = true;
                textBox_ZhengIOIn16_Value1.Enabled = true;
                textBox_ZhengIOIn16_Value2.Enabled = true;
                if (radioButton_ZhengIOIn16a_C.Checked == true)//梳理单选框逻辑
                {
                    textBox_ZhengIOIn16_VIn1.Enabled = true;
                    textBox_ZhengIOIn16_VIn2.Enabled = true;
                }
                else
                {
                    textBox_ZhengIOIn16_VIn1.Enabled = false;
                    textBox_ZhengIOIn16_VIn2.Enabled = false;
                }
                if (radioButton_ZhengIOIn16b_C.Checked == true)
                {
                    textBox_ZhengIOIn16b_VIn1.Enabled = true;
                    textBox_ZhengIOIn16b_VIn2.Enabled = true;
                    skinCheckBox_ZhengIOIn16.Enabled = true;
                    if (skinCheckBox_ZhengIOIn16.Checked == true)
                    {
                        textBox_ZhengIOIn16_Test.Enabled = true;
                        textBox_ZhengIOIn16_Ref2.Enabled = true;
                    }
                    else
                    {
                        textBox_ZhengIOIn16_Test.Enabled = false;
                        textBox_ZhengIOIn16_Ref2.Enabled = false;
                    }
                }
                else
                {
                    textBox_ZhengIOIn16b_VIn1.Enabled = false;
                    textBox_ZhengIOIn16b_VIn2.Enabled = false;
                    skinCheckBox_ZhengIOIn16.Enabled = false;
                    skinCheckBox_ZhengIOIn16.Checked = false;
                    textBox_ZhengIOIn16_Test.Enabled = false;
                    textBox_ZhengIOIn16_Ref2.Enabled = false;
                }
            }
            else if (CheckBox_ZhengIOIn16.Checked == false)
            {
                textBox_ZhengIOIn16_IN.Enabled = false;
                textBox_ZhengIOIn16_Ref1.Enabled = false;
                radioButton_ZhengIOIn16a_C.Enabled = false;
                radioButton_ZhengIOIn16a_C.Checked = true;
                radioButton_ZhengIOIn16b_C.Enabled = false;
                textBox_ZhengIOIn16_VIn1.Enabled = false;
                textBox_ZhengIOIn16_VIn2.Enabled = false;
                textBox_ZhengIOIn16b_VIn1.Enabled = false;
                textBox_ZhengIOIn16b_VIn2.Enabled = false;
                skinCheckBox_ZhengIOIn16.Enabled = false;
                skinCheckBox_ZhengIOIn16.Checked = false;
                textBox_ZhengIOIn16_Test.Enabled = false;
                textBox_ZhengIOIn16_Ref2.Enabled = false;
                textBox_ZhengIOIn16_Value1.Enabled = false;
                textBox_ZhengIOIn16_Value2.Enabled = false;
            }
            if (CheckBox_ZhengIOIn17.Checked == true)//IO输入测试通道17使能
            {
                textBox_ZhengIOIn17_IN.Enabled = true;
                textBox_ZhengIOIn17_Ref1.Enabled = true;
                radioButton_ZhengIOIn17a_C.Enabled = true;
                radioButton_ZhengIOIn17b_C.Enabled = true;
                textBox_ZhengIOIn17_Value1.Enabled = true;
                textBox_ZhengIOIn17_Value2.Enabled = true;
                if (radioButton_ZhengIOIn17a_C.Checked == true)//梳理单选框逻辑
                {
                    textBox_ZhengIOIn17_VIn1.Enabled = true;
                    textBox_ZhengIOIn17_VIn2.Enabled = true;
                }
                else
                {
                    textBox_ZhengIOIn17_VIn1.Enabled = false;
                    textBox_ZhengIOIn17_VIn2.Enabled = false;
                }
                if (radioButton_ZhengIOIn17b_C.Checked == true)
                {
                    textBox_ZhengIOIn17b_VIn1.Enabled = true;
                    textBox_ZhengIOIn17b_VIn2.Enabled = true;
                    skinCheckBox_ZhengIOIn17.Enabled = true;
                    if (skinCheckBox_ZhengIOIn17.Checked == true)
                    {
                        textBox_ZhengIOIn17_Test.Enabled = true;
                        textBox_ZhengIOIn17_Ref2.Enabled = true;
                    }
                    else
                    {
                        textBox_ZhengIOIn17_Test.Enabled = false;
                        textBox_ZhengIOIn17_Ref2.Enabled = false;
                    }
                }
                else
                {
                    textBox_ZhengIOIn17b_VIn1.Enabled = false;
                    textBox_ZhengIOIn17b_VIn2.Enabled = false;
                    skinCheckBox_ZhengIOIn17.Enabled = false;
                    skinCheckBox_ZhengIOIn17.Checked = false;
                    textBox_ZhengIOIn17_Test.Enabled = false;
                    textBox_ZhengIOIn17_Ref2.Enabled = false;
                }
            }
            else if (CheckBox_ZhengIOIn17.Checked == false)
            {
                textBox_ZhengIOIn17_IN.Enabled = false;
                textBox_ZhengIOIn17_Ref1.Enabled = false;
                radioButton_ZhengIOIn17a_C.Enabled = false;
                radioButton_ZhengIOIn17a_C.Checked = true;
                radioButton_ZhengIOIn17b_C.Enabled = false;
                textBox_ZhengIOIn17_VIn1.Enabled = false;
                textBox_ZhengIOIn17_VIn2.Enabled = false;
                textBox_ZhengIOIn17b_VIn1.Enabled = false;
                textBox_ZhengIOIn17b_VIn2.Enabled = false;
                skinCheckBox_ZhengIOIn17.Enabled = false;
                skinCheckBox_ZhengIOIn17.Checked = false;
                textBox_ZhengIOIn17_Test.Enabled = false;
                textBox_ZhengIOIn17_Ref2.Enabled = false;
                textBox_ZhengIOIn17_Value1.Enabled = false;
                textBox_ZhengIOIn17_Value2.Enabled = false;
            }
            if (CheckBox_ZhengIOIn18.Checked == true)//IO输入测试通道18使能
            {
                textBox_ZhengIOIn18_IN.Enabled = true;
                textBox_ZhengIOIn18_Ref1.Enabled = true;
                radioButton_ZhengIOIn18a_C.Enabled = true;
                radioButton_ZhengIOIn18b_C.Enabled = true;
                textBox_ZhengIOIn18_Value1.Enabled = true;
                textBox_ZhengIOIn18_Value2.Enabled = true;
                if (radioButton_ZhengIOIn18a_C.Checked == true)//梳理单选框逻辑
                {
                    textBox_ZhengIOIn18_VIn1.Enabled = true;
                    textBox_ZhengIOIn18_VIn2.Enabled = true;
                }
                else
                {
                    textBox_ZhengIOIn18_VIn1.Enabled = false;
                    textBox_ZhengIOIn18_VIn2.Enabled = false;
                }
                if (radioButton_ZhengIOIn18b_C.Checked == true)
                {
                    textBox_ZhengIOIn18b_VIn1.Enabled = true;
                    textBox_ZhengIOIn18b_VIn2.Enabled = true;
                    skinCheckBox_ZhengIOIn18.Enabled = true;
                    if (skinCheckBox_ZhengIOIn18.Checked == true)
                    {
                        textBox_ZhengIOIn18_Test.Enabled = true;
                        textBox_ZhengIOIn18_Ref2.Enabled = true;
                    }
                    else
                    {
                        textBox_ZhengIOIn18_Test.Enabled = false;
                        textBox_ZhengIOIn18_Ref2.Enabled = false;
                    }
                }
                else
                {
                    textBox_ZhengIOIn18b_VIn1.Enabled = false;
                    textBox_ZhengIOIn18b_VIn2.Enabled = false;
                    skinCheckBox_ZhengIOIn18.Enabled = false;
                    skinCheckBox_ZhengIOIn18.Checked = false;
                    textBox_ZhengIOIn18_Test.Enabled = false;
                    textBox_ZhengIOIn18_Ref2.Enabled = false;
                }
            }
            else if (CheckBox_ZhengIOIn18.Checked == false)
            {
                textBox_ZhengIOIn18_IN.Enabled = false;
                textBox_ZhengIOIn18_Ref1.Enabled = false;
                radioButton_ZhengIOIn18a_C.Enabled = false;
                radioButton_ZhengIOIn18a_C.Checked = true;
                radioButton_ZhengIOIn18b_C.Enabled = false;
                textBox_ZhengIOIn18_VIn1.Enabled = false;
                textBox_ZhengIOIn18_VIn2.Enabled = false;
                textBox_ZhengIOIn18b_VIn1.Enabled = false;
                textBox_ZhengIOIn18b_VIn2.Enabled = false;
                skinCheckBox_ZhengIOIn18.Enabled = false;
                skinCheckBox_ZhengIOIn18.Checked = false;
                textBox_ZhengIOIn18_Test.Enabled = false;
                textBox_ZhengIOIn18_Ref2.Enabled = false;
                textBox_ZhengIOIn18_Value1.Enabled = false;
                textBox_ZhengIOIn18_Value2.Enabled = false;
            }
            if (CheckBox_ZhengIOIn19.Checked == true)//IO输入测试通道19使能
            {
                textBox_ZhengIOIn19_IN.Enabled = true;
                textBox_ZhengIOIn19_Ref1.Enabled = true;
                radioButton_ZhengIOIn19a_C.Enabled = true;
                radioButton_ZhengIOIn19b_C.Enabled = true;
                textBox_ZhengIOIn19_Value1.Enabled = true;
                textBox_ZhengIOIn19_Value2.Enabled = true;
                if (radioButton_ZhengIOIn19a_C.Checked == true)//梳理单选框逻辑
                {
                    textBox_ZhengIOIn19_VIn1.Enabled = true;
                    textBox_ZhengIOIn19_VIn2.Enabled = true;
                }
                else
                {
                    textBox_ZhengIOIn19_VIn1.Enabled = false;
                    textBox_ZhengIOIn19_VIn2.Enabled = false;
                }
                if (radioButton_ZhengIOIn19b_C.Checked == true)
                {
                    textBox_ZhengIOIn19b_VIn1.Enabled = true;
                    textBox_ZhengIOIn19b_VIn2.Enabled = true;
                    skinCheckBox_ZhengIOIn19.Enabled = true;
                    if (skinCheckBox_ZhengIOIn19.Checked == true)
                    {
                        textBox_ZhengIOIn19_Test.Enabled = true;
                        textBox_ZhengIOIn19_Ref2.Enabled = true;
                    }
                    else
                    {
                        textBox_ZhengIOIn19_Test.Enabled = false;
                        textBox_ZhengIOIn19_Ref2.Enabled = false;
                    }
                }
                else
                {
                    textBox_ZhengIOIn19b_VIn1.Enabled = false;
                    textBox_ZhengIOIn19b_VIn2.Enabled = false;
                    skinCheckBox_ZhengIOIn19.Enabled = false;
                    skinCheckBox_ZhengIOIn19.Checked = false;
                    textBox_ZhengIOIn19_Test.Enabled = false;
                    textBox_ZhengIOIn19_Ref2.Enabled = false;
                }
            }
            else if (CheckBox_ZhengIOIn19.Checked == false)
            {
                textBox_ZhengIOIn19_IN.Enabled = false;
                textBox_ZhengIOIn19_Ref1.Enabled = false;
                radioButton_ZhengIOIn19a_C.Enabled = false;
                radioButton_ZhengIOIn19a_C.Checked = true;
                radioButton_ZhengIOIn19b_C.Enabled = false;
                textBox_ZhengIOIn19_VIn1.Enabled = false;
                textBox_ZhengIOIn19_VIn2.Enabled = false;
                textBox_ZhengIOIn19b_VIn1.Enabled = false;
                textBox_ZhengIOIn19b_VIn2.Enabled = false;
                skinCheckBox_ZhengIOIn19.Enabled = false;
                skinCheckBox_ZhengIOIn19.Checked = false;
                textBox_ZhengIOIn19_Test.Enabled = false;
                textBox_ZhengIOIn19_Ref2.Enabled = false;
                textBox_ZhengIOIn19_Value1.Enabled = false;
                textBox_ZhengIOIn19_Value2.Enabled = false;
            }
            if (CheckBox_ZhengIOIn20.Checked == true)//IO输入测试通道20使能
            {
                textBox_ZhengIOIn20_IN.Enabled = true;
                textBox_ZhengIOIn20_Ref1.Enabled = true;
                radioButton_ZhengIOIn20a_C.Enabled = true;
                radioButton_ZhengIOIn20b_C.Enabled = true;
                textBox_ZhengIOIn20_Value1.Enabled = true;
                textBox_ZhengIOIn20_Value2.Enabled = true;
                if (radioButton_ZhengIOIn20a_C.Checked == true)//梳理单选框逻辑
                {
                    textBox_ZhengIOIn20_VIn1.Enabled = true;
                    textBox_ZhengIOIn20_VIn2.Enabled = true;
                }
                else
                {
                    textBox_ZhengIOIn20_VIn1.Enabled = false;
                    textBox_ZhengIOIn20_VIn2.Enabled = false;
                }
                if (radioButton_ZhengIOIn20b_C.Checked == true)
                {
                    textBox_ZhengIOIn20b_VIn1.Enabled = true;
                    textBox_ZhengIOIn20b_VIn2.Enabled = true;
                    skinCheckBox_ZhengIOIn20.Enabled = true;
                    if (skinCheckBox_ZhengIOIn20.Checked == true)
                    {
                        textBox_ZhengIOIn20_Test.Enabled = true;
                        textBox_ZhengIOIn20_Ref2.Enabled = true;
                    }
                    else
                    {
                        textBox_ZhengIOIn20_Test.Enabled = false;
                        textBox_ZhengIOIn20_Ref2.Enabled = false;
                    }
                }
                else
                {
                    textBox_ZhengIOIn20b_VIn1.Enabled = false;
                    textBox_ZhengIOIn20b_VIn2.Enabled = false;
                    skinCheckBox_ZhengIOIn20.Enabled = false;
                    skinCheckBox_ZhengIOIn20.Checked = false;
                    textBox_ZhengIOIn20_Test.Enabled = false;
                    textBox_ZhengIOIn20_Ref2.Enabled = false;
                }
            }
            else if (CheckBox_ZhengIOIn20.Checked == false)
            {
                textBox_ZhengIOIn20_IN.Enabled = false;
                textBox_ZhengIOIn20_Ref1.Enabled = false;
                radioButton_ZhengIOIn20a_C.Enabled = false;
                radioButton_ZhengIOIn20a_C.Checked = true;
                radioButton_ZhengIOIn20b_C.Enabled = false;
                textBox_ZhengIOIn20_VIn1.Enabled = false;
                textBox_ZhengIOIn20_VIn2.Enabled = false;
                textBox_ZhengIOIn20b_VIn1.Enabled = false;
                textBox_ZhengIOIn20b_VIn2.Enabled = false;
                skinCheckBox_ZhengIOIn20.Enabled = false;
                skinCheckBox_ZhengIOIn20.Checked = false;
                textBox_ZhengIOIn20_Test.Enabled = false;
                textBox_ZhengIOIn20_Ref2.Enabled = false;
                textBox_ZhengIOIn20_Value1.Enabled = false;
                textBox_ZhengIOIn20_Value2.Enabled = false;
            }
            if (CheckBox_ZhengIOIn21.Checked == true)//IO输入测试通道21使能
            {
                textBox_ZhengIOIn21_IN.Enabled = true;
                textBox_ZhengIOIn21_Ref1.Enabled = true;
                radioButton_ZhengIOIn21a_C.Enabled = true;
                radioButton_ZhengIOIn21b_C.Enabled = true;
                textBox_ZhengIOIn21_Value1.Enabled = true;
                textBox_ZhengIOIn21_Value2.Enabled = true;
                if (radioButton_ZhengIOIn21a_C.Checked == true)//梳理单选框逻辑
                {
                    textBox_ZhengIOIn21_VIn1.Enabled = true;
                    textBox_ZhengIOIn21_VIn2.Enabled = true;
                }
                else
                {
                    textBox_ZhengIOIn21_VIn1.Enabled = false;
                    textBox_ZhengIOIn21_VIn2.Enabled = false;
                }
                if (radioButton_ZhengIOIn21b_C.Checked == true)
                {
                    textBox_ZhengIOIn21b_VIn1.Enabled = true;
                    textBox_ZhengIOIn21b_VIn2.Enabled = true;
                    skinCheckBox_ZhengIOIn21.Enabled = true;
                    if (skinCheckBox_ZhengIOIn21.Checked == true)
                    {
                        textBox_ZhengIOIn21_Test.Enabled = true;
                        textBox_ZhengIOIn21_Ref2.Enabled = true;
                    }
                    else
                    {
                        textBox_ZhengIOIn21_Test.Enabled = false;
                        textBox_ZhengIOIn21_Ref2.Enabled = false;
                    }
                }
                else
                {
                    textBox_ZhengIOIn21b_VIn1.Enabled = false;
                    textBox_ZhengIOIn21b_VIn2.Enabled = false;
                    skinCheckBox_ZhengIOIn21.Enabled = false;
                    skinCheckBox_ZhengIOIn21.Checked = false;
                    textBox_ZhengIOIn21_Test.Enabled = false;
                    textBox_ZhengIOIn21_Ref2.Enabled = false;
                }
            }
            else if (CheckBox_ZhengIOIn21.Checked == false)
            {
                textBox_ZhengIOIn21_IN.Enabled = false;
                textBox_ZhengIOIn21_Ref1.Enabled = false;
                radioButton_ZhengIOIn21a_C.Enabled = false;
                radioButton_ZhengIOIn21a_C.Checked = true;
                radioButton_ZhengIOIn21b_C.Enabled = false;
                textBox_ZhengIOIn21_VIn1.Enabled = false;
                textBox_ZhengIOIn21_VIn2.Enabled = false;
                textBox_ZhengIOIn21b_VIn1.Enabled = false;
                textBox_ZhengIOIn21b_VIn2.Enabled = false;
                skinCheckBox_ZhengIOIn21.Enabled = false;
                skinCheckBox_ZhengIOIn21.Checked = false;
                textBox_ZhengIOIn21_Test.Enabled = false;
                textBox_ZhengIOIn21_Ref2.Enabled = false;
                textBox_ZhengIOIn21_Value1.Enabled = false;
                textBox_ZhengIOIn21_Value2.Enabled = false;
            }
            if (CheckBox_ZhengIOIn22.Checked == true)//IO输入测试通道22使能
            {
                textBox_ZhengIOIn22_IN.Enabled = true;
                textBox_ZhengIOIn22_Ref1.Enabled = true;
                radioButton_ZhengIOIn22a_C.Enabled = true;
                radioButton_ZhengIOIn22b_C.Enabled = true;
                textBox_ZhengIOIn22_Value1.Enabled = true;
                textBox_ZhengIOIn22_Value2.Enabled = true;
                if (radioButton_ZhengIOIn22a_C.Checked == true)//梳理单选框逻辑
                {
                    textBox_ZhengIOIn22_VIn1.Enabled = true;
                    textBox_ZhengIOIn22_VIn2.Enabled = true;
                }
                else
                {
                    textBox_ZhengIOIn22_VIn1.Enabled = false;
                    textBox_ZhengIOIn22_VIn2.Enabled = false;
                }
                if (radioButton_ZhengIOIn22b_C.Checked == true)
                {
                    textBox_ZhengIOIn22b_VIn1.Enabled = true;
                    textBox_ZhengIOIn22b_VIn2.Enabled = true;
                    skinCheckBox_ZhengIOIn22.Enabled = true;
                    if (skinCheckBox_ZhengIOIn22.Checked == true)
                    {
                        textBox_ZhengIOIn22_Test.Enabled = true;
                        textBox_ZhengIOIn22_Ref2.Enabled = true;
                    }
                    else
                    {
                        textBox_ZhengIOIn22_Test.Enabled = false;
                        textBox_ZhengIOIn22_Ref2.Enabled = false;
                    }
                }
                else
                {
                    textBox_ZhengIOIn22b_VIn1.Enabled = false;
                    textBox_ZhengIOIn22b_VIn2.Enabled = false;
                    skinCheckBox_ZhengIOIn22.Enabled = false;
                    skinCheckBox_ZhengIOIn22.Checked = false;
                    textBox_ZhengIOIn22_Test.Enabled = false;
                    textBox_ZhengIOIn22_Ref2.Enabled = false;
                }
            }
            else if (CheckBox_ZhengIOIn22.Checked == false)
            {
                textBox_ZhengIOIn22_IN.Enabled = false;
                textBox_ZhengIOIn22_Ref1.Enabled = false;
                radioButton_ZhengIOIn22a_C.Enabled = false;
                radioButton_ZhengIOIn22a_C.Checked = true;
                radioButton_ZhengIOIn22b_C.Enabled = false;
                textBox_ZhengIOIn22_VIn1.Enabled = false;
                textBox_ZhengIOIn22_VIn2.Enabled = false;
                textBox_ZhengIOIn22b_VIn1.Enabled = false;
                textBox_ZhengIOIn22b_VIn2.Enabled = false;
                skinCheckBox_ZhengIOIn22.Enabled = false;
                skinCheckBox_ZhengIOIn22.Checked = false;
                textBox_ZhengIOIn22_Test.Enabled = false;
                textBox_ZhengIOIn22_Ref2.Enabled = false;
                textBox_ZhengIOIn22_Value1.Enabled = false;
                textBox_ZhengIOIn22_Value2.Enabled = false;
            }
            if (CheckBox_ZhengIOIn23.Checked == true)//IO输入测试通道23使能
            {
                textBox_ZhengIOIn23_IN.Enabled = true;
                textBox_ZhengIOIn23_Ref1.Enabled = true;
                radioButton_ZhengIOIn23a_C.Enabled = true;
                radioButton_ZhengIOIn23b_C.Enabled = true;
                textBox_ZhengIOIn23_Value1.Enabled = true;
                textBox_ZhengIOIn23_Value2.Enabled = true;
                if (radioButton_ZhengIOIn23a_C.Checked == true)//梳理单选框逻辑
                {
                    textBox_ZhengIOIn23_VIn1.Enabled = true;
                    textBox_ZhengIOIn23_VIn2.Enabled = true;
                }
                else
                {
                    textBox_ZhengIOIn23_VIn1.Enabled = false;
                    textBox_ZhengIOIn23_VIn2.Enabled = false;
                }
                if (radioButton_ZhengIOIn23b_C.Checked == true)
                {
                    textBox_ZhengIOIn23b_VIn1.Enabled = true;
                    textBox_ZhengIOIn23b_VIn2.Enabled = true;
                    skinCheckBox_ZhengIOIn23.Enabled = true;
                    if (skinCheckBox_ZhengIOIn23.Checked == true)
                    {
                        textBox_ZhengIOIn23_Test.Enabled = true;
                        textBox_ZhengIOIn23_Ref2.Enabled = true;
                    }
                    else
                    {
                        textBox_ZhengIOIn23_Test.Enabled = false;
                        textBox_ZhengIOIn23_Ref2.Enabled = false;
                    }
                }
                else
                {
                    textBox_ZhengIOIn23b_VIn1.Enabled = false;
                    textBox_ZhengIOIn23b_VIn2.Enabled = false;
                    skinCheckBox_ZhengIOIn23.Enabled = false;
                    skinCheckBox_ZhengIOIn23.Checked = false;
                    textBox_ZhengIOIn23_Test.Enabled = false;
                    textBox_ZhengIOIn23_Ref2.Enabled = false;
                }
            }
            else if (CheckBox_ZhengIOIn23.Checked == false)
            {
                textBox_ZhengIOIn23_IN.Enabled = false;
                textBox_ZhengIOIn23_Ref1.Enabled = false;
                radioButton_ZhengIOIn23a_C.Enabled = false;
                radioButton_ZhengIOIn23a_C.Checked = true;
                radioButton_ZhengIOIn23b_C.Enabled = false;
                textBox_ZhengIOIn23_VIn1.Enabled = false;
                textBox_ZhengIOIn23_VIn2.Enabled = false;
                textBox_ZhengIOIn23b_VIn1.Enabled = false;
                textBox_ZhengIOIn23b_VIn2.Enabled = false;
                skinCheckBox_ZhengIOIn23.Enabled = false;
                skinCheckBox_ZhengIOIn23.Checked = false;
                textBox_ZhengIOIn23_Test.Enabled = false;
                textBox_ZhengIOIn23_Ref2.Enabled = false;
                textBox_ZhengIOIn23_Value1.Enabled = false;
                textBox_ZhengIOIn23_Value2.Enabled = false;
            }
            if (CheckBox_ZhengIOIn24.Checked == true)//IO输入测试通道24使能
            {
                textBox_ZhengIOIn24_IN.Enabled = true;
                textBox_ZhengIOIn24_Ref1.Enabled = true;
                radioButton_ZhengIOIn24a_C.Enabled = true;
                radioButton_ZhengIOIn24b_C.Enabled = true;
                textBox_ZhengIOIn24_Value1.Enabled = true;
                textBox_ZhengIOIn24_Value2.Enabled = true;
                if (radioButton_ZhengIOIn24a_C.Checked == true)//梳理单选框逻辑
                {
                    textBox_ZhengIOIn24_VIn1.Enabled = true;
                    textBox_ZhengIOIn24_VIn2.Enabled = true;
                }
                else
                {
                    textBox_ZhengIOIn24_VIn1.Enabled = false;
                    textBox_ZhengIOIn24_VIn2.Enabled = false;
                }
                if (radioButton_ZhengIOIn24b_C.Checked == true)
                {
                    textBox_ZhengIOIn24b_VIn1.Enabled = true;
                    textBox_ZhengIOIn24b_VIn2.Enabled = true;
                    skinCheckBox_ZhengIOIn24.Enabled = true;
                    if (skinCheckBox_ZhengIOIn24.Checked == true)
                    {
                        textBox_ZhengIOIn24_Test.Enabled = true;
                        textBox_ZhengIOIn24_Ref2.Enabled = true;
                    }
                    else
                    {
                        textBox_ZhengIOIn24_Test.Enabled = false;
                        textBox_ZhengIOIn24_Ref2.Enabled = false;
                    }
                }
                else
                {
                    textBox_ZhengIOIn24b_VIn1.Enabled = false;
                    textBox_ZhengIOIn24b_VIn2.Enabled = false;
                    skinCheckBox_ZhengIOIn24.Enabled = false;
                    skinCheckBox_ZhengIOIn24.Checked = false;
                    textBox_ZhengIOIn24_Test.Enabled = false;
                    textBox_ZhengIOIn24_Ref2.Enabled = false;
                }
            }
            else if (CheckBox_ZhengIOIn24.Checked == false)
            {
                textBox_ZhengIOIn24_IN.Enabled = false;
                textBox_ZhengIOIn24_Ref1.Enabled = false;
                radioButton_ZhengIOIn24a_C.Enabled = false;
                radioButton_ZhengIOIn24a_C.Checked = true;
                radioButton_ZhengIOIn24b_C.Enabled = false;
                textBox_ZhengIOIn24_VIn1.Enabled = false;
                textBox_ZhengIOIn24_VIn2.Enabled = false;
                textBox_ZhengIOIn24b_VIn1.Enabled = false;
                textBox_ZhengIOIn24b_VIn2.Enabled = false;
                skinCheckBox_ZhengIOIn24.Enabled = false;
                skinCheckBox_ZhengIOIn24.Checked = false;
                textBox_ZhengIOIn24_Test.Enabled = false;
                textBox_ZhengIOIn24_Ref2.Enabled = false;
                textBox_ZhengIOIn24_Value1.Enabled = false;
                textBox_ZhengIOIn24_Value2.Enabled = false;
            }
            if (CheckBox_ZhengIOIn25.Checked == true)//IO输入测试通道25使能
            {
                textBox_ZhengIOIn25_IN.Enabled = true;
                textBox_ZhengIOIn25_Ref1.Enabled = true;
                radioButton_ZhengIOIn25a_C.Enabled = true;
                radioButton_ZhengIOIn25b_C.Enabled = true;
                textBox_ZhengIOIn25_Value1.Enabled = true;
                textBox_ZhengIOIn25_Value2.Enabled = true;
                if (radioButton_ZhengIOIn25a_C.Checked == true)//梳理单选框逻辑
                {
                    textBox_ZhengIOIn25_VIn1.Enabled = true;
                    textBox_ZhengIOIn25_VIn2.Enabled = true;
                }
                else
                {
                    textBox_ZhengIOIn25_VIn1.Enabled = false;
                    textBox_ZhengIOIn25_VIn2.Enabled = false;
                }
                if (radioButton_ZhengIOIn25b_C.Checked == true)
                {
                    textBox_ZhengIOIn25b_VIn1.Enabled = true;
                    textBox_ZhengIOIn25b_VIn2.Enabled = true;
                    skinCheckBox_ZhengIOIn25.Enabled = true;
                    if (skinCheckBox_ZhengIOIn25.Checked == true)
                    {
                        textBox_ZhengIOIn25_Test.Enabled = true;
                        textBox_ZhengIOIn25_Ref2.Enabled = true;
                    }
                    else
                    {
                        textBox_ZhengIOIn25_Test.Enabled = false;
                        textBox_ZhengIOIn25_Ref2.Enabled = false;
                    }
                }
                else
                {
                    textBox_ZhengIOIn25b_VIn1.Enabled = false;
                    textBox_ZhengIOIn25b_VIn2.Enabled = false;
                    skinCheckBox_ZhengIOIn25.Enabled = false;
                    skinCheckBox_ZhengIOIn25.Checked = false;
                    textBox_ZhengIOIn25_Test.Enabled = false;
                    textBox_ZhengIOIn25_Ref2.Enabled = false;
                }
            }
            else if (CheckBox_ZhengIOIn25.Checked == false)
            {
                textBox_ZhengIOIn25_IN.Enabled = false;
                textBox_ZhengIOIn25_Ref1.Enabled = false;
                radioButton_ZhengIOIn25a_C.Enabled = false;
                radioButton_ZhengIOIn25a_C.Checked = true;
                radioButton_ZhengIOIn25b_C.Enabled = false;
                textBox_ZhengIOIn25_VIn1.Enabled = false;
                textBox_ZhengIOIn25_VIn2.Enabled = false;
                textBox_ZhengIOIn25b_VIn1.Enabled = false;
                textBox_ZhengIOIn25b_VIn2.Enabled = false;
                skinCheckBox_ZhengIOIn25.Enabled = false;
                skinCheckBox_ZhengIOIn25.Checked = false;
                textBox_ZhengIOIn25_Test.Enabled = false;
                textBox_ZhengIOIn25_Ref2.Enabled = false;
                textBox_ZhengIOIn25_Value1.Enabled = false;
                textBox_ZhengIOIn25_Value2.Enabled = false;
            }
            if (CheckBox_ZhengIOIn26.Checked == true)//IO输入测试通道26使能
            {
                textBox_ZhengIOIn26_IN.Enabled = true;
                textBox_ZhengIOIn26_Ref1.Enabled = true;
                radioButton_ZhengIOIn26a_C.Enabled = true;
                radioButton_ZhengIOIn26b_C.Enabled = true;
                textBox_ZhengIOIn26_Value1.Enabled = true;
                textBox_ZhengIOIn26_Value2.Enabled = true;
                if (radioButton_ZhengIOIn26a_C.Checked == true)//梳理单选框逻辑
                {
                    textBox_ZhengIOIn26_VIn1.Enabled = true;
                    textBox_ZhengIOIn26_VIn2.Enabled = true;
                }
                else
                {
                    textBox_ZhengIOIn26_VIn1.Enabled = false;
                    textBox_ZhengIOIn26_VIn2.Enabled = false;
                }
                if (radioButton_ZhengIOIn26b_C.Checked == true)
                {
                    textBox_ZhengIOIn26b_VIn1.Enabled = true;
                    textBox_ZhengIOIn26b_VIn2.Enabled = true;
                    skinCheckBox_ZhengIOIn26.Enabled = true;
                    if (skinCheckBox_ZhengIOIn26.Checked == true)
                    {
                        textBox_ZhengIOIn26_Test.Enabled = true;
                        textBox_ZhengIOIn26_Ref2.Enabled = true;
                    }
                    else
                    {
                        textBox_ZhengIOIn26_Test.Enabled = false;
                        textBox_ZhengIOIn26_Ref2.Enabled = false;
                    }
                }
                else
                {
                    textBox_ZhengIOIn26b_VIn1.Enabled = false;
                    textBox_ZhengIOIn26b_VIn2.Enabled = false;
                    skinCheckBox_ZhengIOIn26.Enabled = false;
                    skinCheckBox_ZhengIOIn26.Checked = false;
                    textBox_ZhengIOIn26_Test.Enabled = false;
                    textBox_ZhengIOIn26_Ref2.Enabled = false;
                }
            }
            else if (CheckBox_ZhengIOIn26.Checked == false)
            {
                textBox_ZhengIOIn26_IN.Enabled = false;
                textBox_ZhengIOIn26_Ref1.Enabled = false;
                radioButton_ZhengIOIn26a_C.Enabled = false;
                radioButton_ZhengIOIn26a_C.Checked = true;
                radioButton_ZhengIOIn26b_C.Enabled = false;
                textBox_ZhengIOIn26_VIn1.Enabled = false;
                textBox_ZhengIOIn26_VIn2.Enabled = false;
                textBox_ZhengIOIn26b_VIn1.Enabled = false;
                textBox_ZhengIOIn26b_VIn2.Enabled = false;
                skinCheckBox_ZhengIOIn26.Enabled = false;
                skinCheckBox_ZhengIOIn26.Checked = false;
                textBox_ZhengIOIn26_Test.Enabled = false;
                textBox_ZhengIOIn26_Ref2.Enabled = false;
                textBox_ZhengIOIn26_Value1.Enabled = false;
                textBox_ZhengIOIn26_Value2.Enabled = false;
            }

            if (CheckBox_ZhengDA1.Checked == true)//DA输出测试通道1使能
            {
                skinCheckBox_ZhengDA1.Enabled = true;
                if (skinCheckBox_ZhengDA1.Checked == true)
                {
                    textBox_ZhengDA1_IN.Enabled = true;
                    textBox_ZhengDA1_Ref1.Enabled = true;
                    textBox_ZhengDA1_VIn1.Enabled = true;
                    textBox_ZhengDA1_VIn2.Enabled = true;
                }
                if (skinCheckBox_ZhengDA1.Checked == false)
                {
                    textBox_ZhengDA1_IN.Enabled = false;
                    textBox_ZhengDA1_Ref1.Enabled = false;
                    textBox_ZhengDA1_VIn1.Enabled = false;
                    textBox_ZhengDA1_VIn2.Enabled = false;
                }
                textBox_ZhengDA1_Test.Enabled = true;
                textBox_ZhengDA1_Ref2.Enabled = true;
                textBox_ZhengDA1_Value1.Enabled = true;
                textBox_ZhengDA1_Value2.Enabled = true;
            }
            else if (CheckBox_ZhengDA1.Checked == false)
            {
                skinCheckBox_ZhengDA1.Enabled = false;
                skinCheckBox_ZhengDA1.Checked = false;
                textBox_ZhengDA1_IN.Enabled = false;
                textBox_ZhengDA1_Ref1.Enabled = false;
                textBox_ZhengDA1_VIn1.Enabled = false;
                textBox_ZhengDA1_VIn2.Enabled = false;
                textBox_ZhengDA1_Test.Enabled = false;
                textBox_ZhengDA1_Ref2.Enabled = false;
                textBox_ZhengDA1_Value1.Enabled = false;
                textBox_ZhengDA1_Value2.Enabled = false;
            }
            if (CheckBox_ZhengDA2.Checked == true)//DA输出测试通道2使能
            {
                skinCheckBox_ZhengDA2.Enabled = true;
                if (skinCheckBox_ZhengDA2.Checked == true)
                {
                    textBox_ZhengDA2_IN.Enabled = true;
                    textBox_ZhengDA2_Ref1.Enabled = true;
                    textBox_ZhengDA2_VIn1.Enabled = true;
                    textBox_ZhengDA2_VIn2.Enabled = true;
                }
                if (skinCheckBox_ZhengDA2.Checked == false)
                {
                    textBox_ZhengDA2_IN.Enabled = false;
                    textBox_ZhengDA2_Ref1.Enabled = false;
                    textBox_ZhengDA2_VIn1.Enabled = false;
                    textBox_ZhengDA2_VIn2.Enabled = false;
                }
                textBox_ZhengDA2_Test.Enabled = true;
                textBox_ZhengDA2_Ref2.Enabled = true;
                textBox_ZhengDA2_Value1.Enabled = true;
                textBox_ZhengDA2_Value2.Enabled = true;
            }
            else if (CheckBox_ZhengDA2.Checked == false)
            {
                skinCheckBox_ZhengDA2.Enabled = false;
                skinCheckBox_ZhengDA2.Checked = false;
                textBox_ZhengDA2_IN.Enabled = false;
                textBox_ZhengDA2_Ref1.Enabled = false;
                textBox_ZhengDA2_VIn1.Enabled = false;
                textBox_ZhengDA2_VIn2.Enabled = false;
                textBox_ZhengDA2_Test.Enabled = false;
                textBox_ZhengDA2_Ref2.Enabled = false;
                textBox_ZhengDA2_Value1.Enabled = false;
                textBox_ZhengDA2_Value2.Enabled = false;
            }
            if (CheckBox_ZhengDA3.Checked == true)//DA输出测试通道3使能
            {
                skinCheckBox_ZhengDA3.Enabled = true;
                if (skinCheckBox_ZhengDA3.Checked == true)
                {
                    textBox_ZhengDA3_IN.Enabled = true;
                    textBox_ZhengDA3_Ref1.Enabled = true;
                    textBox_ZhengDA3_VIn1.Enabled = true;
                    textBox_ZhengDA3_VIn2.Enabled = true;
                }
                if (skinCheckBox_ZhengDA3.Checked == false)
                {
                    textBox_ZhengDA3_IN.Enabled = false;
                    textBox_ZhengDA3_Ref1.Enabled = false;
                    textBox_ZhengDA3_VIn1.Enabled = false;
                    textBox_ZhengDA3_VIn2.Enabled = false;
                }
                textBox_ZhengDA3_Test.Enabled = true;
                textBox_ZhengDA3_Ref2.Enabled = true;
                textBox_ZhengDA3_Value1.Enabled = true;
                textBox_ZhengDA3_Value2.Enabled = true;
            }
            else if (CheckBox_ZhengDA3.Checked == false)
            {
                skinCheckBox_ZhengDA3.Enabled = false;
                skinCheckBox_ZhengDA3.Checked = false;
                textBox_ZhengDA3_IN.Enabled = false;
                textBox_ZhengDA3_Ref1.Enabled = false;
                textBox_ZhengDA3_VIn1.Enabled = false;
                textBox_ZhengDA3_VIn2.Enabled = false;
                textBox_ZhengDA3_Test.Enabled = false;
                textBox_ZhengDA3_Ref2.Enabled = false;
                textBox_ZhengDA3_Value1.Enabled = false;
                textBox_ZhengDA3_Value2.Enabled = false;
            }
            if (CheckBox_ZhengDA4.Checked == true)//DA输出测试通道4使能
            {
                skinCheckBox_ZhengDA4.Enabled = true;
                if (skinCheckBox_ZhengDA4.Checked == true)
                {
                    textBox_ZhengDA4_IN.Enabled = true;
                    textBox_ZhengDA4_Ref1.Enabled = true;
                    textBox_ZhengDA4_VIn1.Enabled = true;
                    textBox_ZhengDA4_VIn2.Enabled = true;
                }
                if (skinCheckBox_ZhengDA4.Checked == false)
                {
                    textBox_ZhengDA4_IN.Enabled = false;
                    textBox_ZhengDA4_Ref1.Enabled = false;
                    textBox_ZhengDA4_VIn1.Enabled = false;
                    textBox_ZhengDA4_VIn2.Enabled = false;
                }
                textBox_ZhengDA4_Test.Enabled = true;
                textBox_ZhengDA4_Ref2.Enabled = true;
                textBox_ZhengDA4_Value1.Enabled = true;
                textBox_ZhengDA4_Value2.Enabled = true;
            }
            else if (CheckBox_ZhengDA4.Checked == false)
            {
                skinCheckBox_ZhengDA4.Enabled = false;
                skinCheckBox_ZhengDA4.Checked = false;
                textBox_ZhengDA4_IN.Enabled = false;
                textBox_ZhengDA4_Ref1.Enabled = false;
                textBox_ZhengDA4_VIn1.Enabled = false;
                textBox_ZhengDA4_VIn2.Enabled = false;
                textBox_ZhengDA4_Test.Enabled = false;
                textBox_ZhengDA4_Ref2.Enabled = false;
                textBox_ZhengDA4_Value1.Enabled = false;
                textBox_ZhengDA4_Value2.Enabled = false;
            }
            if (CheckBox_ZhengDA5.Checked == true)//DA输出测试通道5使能
            {
                skinCheckBox_ZhengDA5.Enabled = true;
                if (skinCheckBox_ZhengDA5.Checked == true)
                {
                    textBox_ZhengDA5_IN.Enabled = true;
                    textBox_ZhengDA5_Ref1.Enabled = true;
                    textBox_ZhengDA5_VIn1.Enabled = true;
                    textBox_ZhengDA5_VIn2.Enabled = true;
                }
                if (skinCheckBox_ZhengDA5.Checked == false)
                {
                    textBox_ZhengDA5_IN.Enabled = false;
                    textBox_ZhengDA5_Ref1.Enabled = false;
                    textBox_ZhengDA5_VIn1.Enabled = false;
                    textBox_ZhengDA5_VIn2.Enabled = false;
                }
                textBox_ZhengDA5_Test.Enabled = true;
                textBox_ZhengDA5_Ref2.Enabled = true;
                textBox_ZhengDA5_Value1.Enabled = true;
                textBox_ZhengDA5_Value2.Enabled = true;
            }
            else if (CheckBox_ZhengDA5.Checked == false)
            {
                skinCheckBox_ZhengDA5.Enabled = false;
                skinCheckBox_ZhengDA5.Checked = false;
                textBox_ZhengDA5_IN.Enabled = false;
                textBox_ZhengDA5_Ref1.Enabled = false;
                textBox_ZhengDA5_VIn1.Enabled = false;
                textBox_ZhengDA5_VIn2.Enabled = false;
                textBox_ZhengDA5_Test.Enabled = false;
                textBox_ZhengDA5_Ref2.Enabled = false;
                textBox_ZhengDA5_Value1.Enabled = false;
                textBox_ZhengDA5_Value2.Enabled = false;
            }
            if (CheckBox_ZhengDA6.Checked == true)//DA输出测试通道6使能
            {
                skinCheckBox_ZhengDA6.Enabled = true;
                if (skinCheckBox_ZhengDA6.Checked == true)
                {
                    textBox_ZhengDA6_IN.Enabled = true;
                    textBox_ZhengDA6_Ref1.Enabled = true;
                    textBox_ZhengDA6_VIn1.Enabled = true;
                    textBox_ZhengDA6_VIn2.Enabled = true;
                }
                if (skinCheckBox_ZhengDA6.Checked == false)
                {
                    textBox_ZhengDA6_IN.Enabled = false;
                    textBox_ZhengDA6_Ref1.Enabled = false;
                    textBox_ZhengDA6_VIn1.Enabled = false;
                    textBox_ZhengDA6_VIn2.Enabled = false;
                }
                textBox_ZhengDA6_Test.Enabled = true;
                textBox_ZhengDA6_Ref2.Enabled = true;
                textBox_ZhengDA6_Value1.Enabled = true;
                textBox_ZhengDA6_Value2.Enabled = true;
            }
            else if (CheckBox_ZhengDA6.Checked == false)
            {
                skinCheckBox_ZhengDA6.Enabled = false;
                skinCheckBox_ZhengDA6.Checked = false;
                textBox_ZhengDA6_IN.Enabled = false;
                textBox_ZhengDA6_Ref1.Enabled = false;
                textBox_ZhengDA6_VIn1.Enabled = false;
                textBox_ZhengDA6_VIn2.Enabled = false;
                textBox_ZhengDA6_Test.Enabled = false;
                textBox_ZhengDA6_Ref2.Enabled = false;
                textBox_ZhengDA6_Value1.Enabled = false;
                textBox_ZhengDA6_Value2.Enabled = false;
            }
            if (CheckBox_ZhengDA7.Checked == true)//DA输出测试通道7使能
            {
                skinCheckBox_ZhengDA7.Enabled = true;
                if (skinCheckBox_ZhengDA7.Checked == true)
                {
                    textBox_ZhengDA7_IN.Enabled = true;
                    textBox_ZhengDA7_Ref1.Enabled = true;
                    textBox_ZhengDA7_VIn1.Enabled = true;
                    textBox_ZhengDA7_VIn2.Enabled = true;
                }
                if (skinCheckBox_ZhengDA7.Checked == false)
                {
                    textBox_ZhengDA7_IN.Enabled = false;
                    textBox_ZhengDA7_Ref1.Enabled = false;
                    textBox_ZhengDA7_VIn1.Enabled = false;
                    textBox_ZhengDA7_VIn2.Enabled = false;
                }
                textBox_ZhengDA7_Test.Enabled = true;
                textBox_ZhengDA7_Ref2.Enabled = true;
                textBox_ZhengDA7_Value1.Enabled = true;
                textBox_ZhengDA7_Value2.Enabled = true;
            }
            else if (CheckBox_ZhengDA7.Checked == false)
            {
                skinCheckBox_ZhengDA7.Enabled = false;
                skinCheckBox_ZhengDA7.Checked = false;
                textBox_ZhengDA7_IN.Enabled = false;
                textBox_ZhengDA7_Ref1.Enabled = false;
                textBox_ZhengDA7_VIn1.Enabled = false;
                textBox_ZhengDA7_VIn2.Enabled = false;
                textBox_ZhengDA7_Test.Enabled = false;
                textBox_ZhengDA7_Ref2.Enabled = false;
                textBox_ZhengDA7_Value1.Enabled = false;
                textBox_ZhengDA7_Value2.Enabled = false;
            }
            if (CheckBox_ZhengDA8.Checked == true)//DA输出测试通道8使能
            {
                skinCheckBox_ZhengDA8.Enabled = true;
                if (skinCheckBox_ZhengDA8.Checked == true)
                {
                    textBox_ZhengDA8_IN.Enabled = true;
                    textBox_ZhengDA8_Ref1.Enabled = true;
                    textBox_ZhengDA8_VIn1.Enabled = true;
                    textBox_ZhengDA8_VIn2.Enabled = true;
                }
                if (skinCheckBox_ZhengDA8.Checked == false)
                {
                    textBox_ZhengDA8_IN.Enabled = false;
                    textBox_ZhengDA8_Ref1.Enabled = false;
                    textBox_ZhengDA8_VIn1.Enabled = false;
                    textBox_ZhengDA8_VIn2.Enabled = false;
                }
                textBox_ZhengDA8_Test.Enabled = true;
                textBox_ZhengDA8_Ref2.Enabled = true;
                textBox_ZhengDA8_Value1.Enabled = true;
                textBox_ZhengDA8_Value2.Enabled = true;
            }
            else if (CheckBox_ZhengDA8.Checked == false)
            {
                skinCheckBox_ZhengDA8.Enabled = false;
                skinCheckBox_ZhengDA8.Checked = false;
                textBox_ZhengDA8_IN.Enabled = false;
                textBox_ZhengDA8_Ref1.Enabled = false;
                textBox_ZhengDA8_VIn1.Enabled = false;
                textBox_ZhengDA8_VIn2.Enabled = false;
                textBox_ZhengDA8_Test.Enabled = false;
                textBox_ZhengDA8_Ref2.Enabled = false;
                textBox_ZhengDA8_Value1.Enabled = false;
                textBox_ZhengDA8_Value2.Enabled = false;
            }

            if (CheckBox_ZhengAD1.Checked == true)//AD采样测试通道1使能
            {
                textBox_ZhengAD1_IN.Enabled = true;
                textBox_ZhengAD1_Ref1.Enabled = true;
                textBox_ZhengAD1_VIn1.Enabled = true;
                textBox_ZhengAD1_VIn2.Enabled = true;
                skinCheckBox_ZhengAD1.Enabled = true;
                textBox_ZhengAD1_Value1.Enabled = true;
                textBox_ZhengAD1_Value2.Enabled = true;
                if (skinCheckBox_ZhengAD1.Checked == true)//梳理skin复选框逻辑
                {
                    textBox_ZhengAD1_Test.Enabled = true;
                    textBox_ZhengAD1_Ref2.Enabled = true;
                }
                if (skinCheckBox_ZhengAD1.Checked == false)
                {
                    textBox_ZhengAD1_Test.Enabled = false;
                    textBox_ZhengAD1_Ref2.Enabled = false;
                }

            }
            else if (CheckBox_ZhengAD1.Checked == false)
            {
                textBox_ZhengAD1_IN.Enabled = false;
                textBox_ZhengAD1_Ref1.Enabled = false;
                textBox_ZhengAD1_VIn1.Enabled = false;
                textBox_ZhengAD1_VIn2.Enabled = false;
                skinCheckBox_ZhengAD1.Enabled = false;
                skinCheckBox_ZhengAD1.Checked = false;
                textBox_ZhengAD1_Test.Enabled = false;
                textBox_ZhengAD1_Ref2.Enabled = false;
                textBox_ZhengAD1_Value1.Enabled = false;
                textBox_ZhengAD1_Value2.Enabled = false;
            }
            if (CheckBox_ZhengAD2.Checked == true)//AD采样测试通道2使能
            {
                textBox_ZhengAD2_IN.Enabled = true;
                textBox_ZhengAD2_Ref1.Enabled = true;
                textBox_ZhengAD2_VIn1.Enabled = true;
                textBox_ZhengAD2_VIn2.Enabled = true;
                skinCheckBox_ZhengAD2.Enabled = true;
                textBox_ZhengAD2_Value1.Enabled = true;
                textBox_ZhengAD2_Value2.Enabled = true;
                if (skinCheckBox_ZhengAD2.Checked == true)//梳理skin复选框逻辑
                {
                    textBox_ZhengAD2_Test.Enabled = true;
                    textBox_ZhengAD2_Ref2.Enabled = true;
                }
                if (skinCheckBox_ZhengAD2.Checked == false)
                {
                    textBox_ZhengAD2_Test.Enabled = false;
                    textBox_ZhengAD2_Ref2.Enabled = false;
                }

            }
            else if (CheckBox_ZhengAD2.Checked == false)
            {
                textBox_ZhengAD2_IN.Enabled = false;
                textBox_ZhengAD2_Ref1.Enabled = false;
                textBox_ZhengAD2_VIn1.Enabled = false;
                textBox_ZhengAD2_VIn2.Enabled = false;
                skinCheckBox_ZhengAD2.Enabled = false;
                skinCheckBox_ZhengAD2.Checked = false;
                textBox_ZhengAD2_Test.Enabled = false;
                textBox_ZhengAD2_Ref2.Enabled = false;
                textBox_ZhengAD2_Value1.Enabled = false;
                textBox_ZhengAD2_Value2.Enabled = false;
            }
            if (CheckBox_ZhengAD3.Checked == true)//AD采样测试通道3使能
            {
                textBox_ZhengAD3_IN.Enabled = true;
                textBox_ZhengAD3_Ref1.Enabled = true;
                textBox_ZhengAD3_VIn1.Enabled = true;
                textBox_ZhengAD3_VIn2.Enabled = true;
                skinCheckBox_ZhengAD3.Enabled = true;
                textBox_ZhengAD3_Value1.Enabled = true;
                textBox_ZhengAD3_Value2.Enabled = true;
                if (skinCheckBox_ZhengAD3.Checked == true)//梳理skin复选框逻辑
                {
                    textBox_ZhengAD3_Test.Enabled = true;
                    textBox_ZhengAD3_Ref2.Enabled = true;
                }
                if (skinCheckBox_ZhengAD3.Checked == false)
                {
                    textBox_ZhengAD3_Test.Enabled = false;
                    textBox_ZhengAD3_Ref2.Enabled = false;
                }

            }
            else if (CheckBox_ZhengAD3.Checked == false)
            {
                textBox_ZhengAD3_IN.Enabled = false;
                textBox_ZhengAD3_Ref1.Enabled = false;
                textBox_ZhengAD3_VIn1.Enabled = false;
                textBox_ZhengAD3_VIn2.Enabled = false;
                skinCheckBox_ZhengAD3.Enabled = false;
                skinCheckBox_ZhengAD3.Checked = false;
                textBox_ZhengAD3_Test.Enabled = false;
                textBox_ZhengAD3_Ref2.Enabled = false;
                textBox_ZhengAD3_Value1.Enabled = false;
                textBox_ZhengAD3_Value2.Enabled = false;
            }
            if (CheckBox_ZhengAD4.Checked == true)//AD采样测试通道4使能
            {
                textBox_ZhengAD4_IN.Enabled = true;
                textBox_ZhengAD4_Ref1.Enabled = true;
                textBox_ZhengAD4_VIn1.Enabled = true;
                textBox_ZhengAD4_VIn2.Enabled = true;
                skinCheckBox_ZhengAD4.Enabled = true;
                textBox_ZhengAD4_Value1.Enabled = true;
                textBox_ZhengAD4_Value2.Enabled = true;
                if (skinCheckBox_ZhengAD4.Checked == true)//梳理skin复选框逻辑
                {
                    textBox_ZhengAD4_Test.Enabled = true;
                    textBox_ZhengAD4_Ref2.Enabled = true;
                }
                if (skinCheckBox_ZhengAD4.Checked == false)
                {
                    textBox_ZhengAD4_Test.Enabled = false;
                    textBox_ZhengAD4_Ref2.Enabled = false;
                }

            }
            else if (CheckBox_ZhengAD4.Checked == false)
            {
                textBox_ZhengAD4_IN.Enabled = false;
                textBox_ZhengAD4_Ref1.Enabled = false;
                textBox_ZhengAD4_VIn1.Enabled = false;
                textBox_ZhengAD4_VIn2.Enabled = false;
                skinCheckBox_ZhengAD4.Enabled = false;
                skinCheckBox_ZhengAD4.Checked = false;
                textBox_ZhengAD4_Test.Enabled = false;
                textBox_ZhengAD4_Ref2.Enabled = false;
                textBox_ZhengAD4_Value1.Enabled = false;
                textBox_ZhengAD4_Value2.Enabled = false;
            }
            if (CheckBox_ZhengAD5.Checked == true)//AD采样测试通道5使能
            {
                textBox_ZhengAD5_IN.Enabled = true;
                textBox_ZhengAD5_Ref1.Enabled = true;
                textBox_ZhengAD5_VIn1.Enabled = true;
                textBox_ZhengAD5_VIn2.Enabled = true;
                skinCheckBox_ZhengAD5.Enabled = true;
                textBox_ZhengAD5_Value1.Enabled = true;
                textBox_ZhengAD5_Value2.Enabled = true;
                if (skinCheckBox_ZhengAD5.Checked == true)//梳理skin复选框逻辑
                {
                    textBox_ZhengAD5_Test.Enabled = true;
                    textBox_ZhengAD5_Ref2.Enabled = true;
                }
                if (skinCheckBox_ZhengAD5.Checked == false)
                {
                    textBox_ZhengAD5_Test.Enabled = false;
                    textBox_ZhengAD5_Ref2.Enabled = false;
                }

            }
            else if (CheckBox_ZhengAD5.Checked == false)
            {
                textBox_ZhengAD5_IN.Enabled = false;
                textBox_ZhengAD5_Ref1.Enabled = false;
                textBox_ZhengAD5_VIn1.Enabled = false;
                textBox_ZhengAD5_VIn2.Enabled = false;
                skinCheckBox_ZhengAD5.Enabled = false;
                skinCheckBox_ZhengAD5.Checked = false;
                textBox_ZhengAD5_Test.Enabled = false;
                textBox_ZhengAD5_Ref2.Enabled = false;
                textBox_ZhengAD5_Value1.Enabled = false;
                textBox_ZhengAD5_Value2.Enabled = false;
            }
            if (CheckBox_ZhengAD6.Checked == true)//AD采样测试通道6使能
            {
                textBox_ZhengAD6_IN.Enabled = true;
                textBox_ZhengAD6_Ref1.Enabled = true;
                textBox_ZhengAD6_VIn1.Enabled = true;
                textBox_ZhengAD6_VIn2.Enabled = true;
                skinCheckBox_ZhengAD6.Enabled = true;
                textBox_ZhengAD6_Value1.Enabled = true;
                textBox_ZhengAD6_Value2.Enabled = true;
                if (skinCheckBox_ZhengAD6.Checked == true)//梳理skin复选框逻辑
                {
                    textBox_ZhengAD6_Test.Enabled = true;
                    textBox_ZhengAD6_Ref2.Enabled = true;
                }
                if (skinCheckBox_ZhengAD6.Checked == false)
                {
                    textBox_ZhengAD6_Test.Enabled = false;
                    textBox_ZhengAD6_Ref2.Enabled = false;
                }

            }
            else if (CheckBox_ZhengAD6.Checked == false)
            {
                textBox_ZhengAD6_IN.Enabled = false;
                textBox_ZhengAD6_Ref1.Enabled = false;
                textBox_ZhengAD6_VIn1.Enabled = false;
                textBox_ZhengAD6_VIn2.Enabled = false;
                skinCheckBox_ZhengAD6.Enabled = false;
                skinCheckBox_ZhengAD6.Checked = false;
                textBox_ZhengAD6_Test.Enabled = false;
                textBox_ZhengAD6_Ref2.Enabled = false;
                textBox_ZhengAD6_Value1.Enabled = false;
                textBox_ZhengAD6_Value2.Enabled = false;
            }
            if (CheckBox_ZhengAD7.Checked == true)//AD采样测试通道7使能
            {
                textBox_ZhengAD7_IN.Enabled = true;
                textBox_ZhengAD7_Ref1.Enabled = true;
                textBox_ZhengAD7_VIn1.Enabled = true;
                textBox_ZhengAD7_VIn2.Enabled = true;
                skinCheckBox_ZhengAD7.Enabled = true;
                textBox_ZhengAD7_Value1.Enabled = true;
                textBox_ZhengAD7_Value2.Enabled = true;
                if (skinCheckBox_ZhengAD7.Checked == true)//梳理skin复选框逻辑
                {
                    textBox_ZhengAD7_Test.Enabled = true;
                    textBox_ZhengAD7_Ref2.Enabled = true;
                }
                if (skinCheckBox_ZhengAD7.Checked == false)
                {
                    textBox_ZhengAD7_Test.Enabled = false;
                    textBox_ZhengAD7_Ref2.Enabled = false;
                }

            }
            else if (CheckBox_ZhengAD7.Checked == false)
            {
                textBox_ZhengAD7_IN.Enabled = false;
                textBox_ZhengAD7_Ref1.Enabled = false;
                textBox_ZhengAD7_VIn1.Enabled = false;
                textBox_ZhengAD7_VIn2.Enabled = false;
                skinCheckBox_ZhengAD7.Enabled = false;
                skinCheckBox_ZhengAD7.Checked = false;
                textBox_ZhengAD7_Test.Enabled = false;
                textBox_ZhengAD7_Ref2.Enabled = false;
                textBox_ZhengAD7_Value1.Enabled = false;
                textBox_ZhengAD7_Value2.Enabled = false;
            }
            if (CheckBox_ZhengAD8.Checked == true)//AD采样测试通道8使能
            {
                textBox_ZhengAD8_IN.Enabled = true;
                textBox_ZhengAD8_Ref1.Enabled = true;
                textBox_ZhengAD8_VIn1.Enabled = true;
                textBox_ZhengAD8_VIn2.Enabled = true;
                skinCheckBox_ZhengAD8.Enabled = true;
                textBox_ZhengAD8_Value1.Enabled = true;
                textBox_ZhengAD8_Value2.Enabled = true;
                if (skinCheckBox_ZhengAD8.Checked == true)//梳理skin复选框逻辑
                {
                    textBox_ZhengAD8_Test.Enabled = true;
                    textBox_ZhengAD8_Ref2.Enabled = true;
                }
                if (skinCheckBox_ZhengAD8.Checked == false)
                {
                    textBox_ZhengAD8_Test.Enabled = false;
                    textBox_ZhengAD8_Ref2.Enabled = false;
                }

            }
            else if (CheckBox_ZhengAD8.Checked == false)
            {
                textBox_ZhengAD8_IN.Enabled = false;
                textBox_ZhengAD8_Ref1.Enabled = false;
                textBox_ZhengAD8_VIn1.Enabled = false;
                textBox_ZhengAD8_VIn2.Enabled = false;
                skinCheckBox_ZhengAD8.Enabled = false;
                skinCheckBox_ZhengAD8.Checked = false;
                textBox_ZhengAD8_Test.Enabled = false;
                textBox_ZhengAD8_Ref2.Enabled = false;
                textBox_ZhengAD8_Value1.Enabled = false;
                textBox_ZhengAD8_Value2.Enabled = false;
            }
            if (CheckBox_ZhengAD9.Checked == true)//AD采样测试通道9使能
            {
                textBox_ZhengAD9_IN.Enabled = true;
                textBox_ZhengAD9_Ref1.Enabled = true;
                textBox_ZhengAD9_VIn1.Enabled = true;
                textBox_ZhengAD9_VIn2.Enabled = true;
                skinCheckBox_ZhengAD9.Enabled = true;
                textBox_ZhengAD9_Value1.Enabled = true;
                textBox_ZhengAD9_Value2.Enabled = true;
                if (skinCheckBox_ZhengAD9.Checked == true)//梳理skin复选框逻辑
                {
                    textBox_ZhengAD9_Test.Enabled = true;
                    textBox_ZhengAD9_Ref2.Enabled = true;
                }
                if (skinCheckBox_ZhengAD9.Checked == false)
                {
                    textBox_ZhengAD9_Test.Enabled = false;
                    textBox_ZhengAD9_Ref2.Enabled = false;
                }

            }
            else if (CheckBox_ZhengAD9.Checked == false)
            {
                textBox_ZhengAD9_IN.Enabled = false;
                textBox_ZhengAD9_Ref1.Enabled = false;
                textBox_ZhengAD9_VIn1.Enabled = false;
                textBox_ZhengAD9_VIn2.Enabled = false;
                skinCheckBox_ZhengAD9.Enabled = false;
                skinCheckBox_ZhengAD9.Checked = false;
                textBox_ZhengAD9_Test.Enabled = false;
                textBox_ZhengAD9_Ref2.Enabled = false;
                textBox_ZhengAD9_Value1.Enabled = false;
                textBox_ZhengAD9_Value2.Enabled = false;
            }
            if (CheckBox_ZhengAD10.Checked == true)//AD采样测试通道10使能
            {
                textBox_ZhengAD10_IN.Enabled = true;
                textBox_ZhengAD10_Ref1.Enabled = true;
                textBox_ZhengAD10_VIn1.Enabled = true;
                textBox_ZhengAD10_VIn2.Enabled = true;
                skinCheckBox_ZhengAD10.Enabled = true;
                textBox_ZhengAD10_Value1.Enabled = true;
                textBox_ZhengAD10_Value2.Enabled = true;
                if (skinCheckBox_ZhengAD10.Checked == true)//梳理skin复选框逻辑
                {
                    textBox_ZhengAD10_Test.Enabled = true;
                    textBox_ZhengAD10_Ref2.Enabled = true;
                }
                if (skinCheckBox_ZhengAD10.Checked == false)
                {
                    textBox_ZhengAD10_Test.Enabled = false;
                    textBox_ZhengAD10_Ref2.Enabled = false;
                }

            }
            else if (CheckBox_ZhengAD10.Checked == false)
            {
                textBox_ZhengAD10_IN.Enabled = false;
                textBox_ZhengAD10_Ref1.Enabled = false;
                textBox_ZhengAD10_VIn1.Enabled = false;
                textBox_ZhengAD10_VIn2.Enabled = false;
                skinCheckBox_ZhengAD10.Enabled = false;
                skinCheckBox_ZhengAD10.Checked = false;
                textBox_ZhengAD10_Test.Enabled = false;
                textBox_ZhengAD10_Ref2.Enabled = false;
                textBox_ZhengAD10_Value1.Enabled = false;
                textBox_ZhengAD10_Value2.Enabled = false;
            }
            if (CheckBox_ZhengAD11.Checked == true)//AD采样测试通道11使能
            {
                textBox_ZhengAD11_IN.Enabled = true;
                textBox_ZhengAD11_Ref1.Enabled = true;
                textBox_ZhengAD11_VIn1.Enabled = true;
                textBox_ZhengAD11_VIn2.Enabled = true;
                skinCheckBox_ZhengAD11.Enabled = true;
                textBox_ZhengAD11_Value1.Enabled = true;
                textBox_ZhengAD11_Value2.Enabled = true;
                if (skinCheckBox_ZhengAD11.Checked == true)//梳理skin复选框逻辑
                {
                    textBox_ZhengAD11_Test.Enabled = true;
                    textBox_ZhengAD11_Ref2.Enabled = true;
                }
                if (skinCheckBox_ZhengAD11.Checked == false)
                {
                    textBox_ZhengAD11_Test.Enabled = false;
                    textBox_ZhengAD11_Ref2.Enabled = false;
                }

            }
            else if (CheckBox_ZhengAD11.Checked == false)
            {
                textBox_ZhengAD11_IN.Enabled = false;
                textBox_ZhengAD11_Ref1.Enabled = false;
                textBox_ZhengAD11_VIn1.Enabled = false;
                textBox_ZhengAD11_VIn2.Enabled = false;
                skinCheckBox_ZhengAD11.Enabled = false;
                skinCheckBox_ZhengAD11.Checked = false;
                textBox_ZhengAD11_Test.Enabled = false;
                textBox_ZhengAD11_Ref2.Enabled = false;
                textBox_ZhengAD11_Value1.Enabled = false;
                textBox_ZhengAD11_Value2.Enabled = false;
            }
            if (CheckBox_ZhengAD12.Checked == true)//AD采样测试通道12使能
            {
                textBox_ZhengAD12_IN.Enabled = true;
                textBox_ZhengAD12_Ref1.Enabled = true;
                textBox_ZhengAD12_VIn1.Enabled = true;
                textBox_ZhengAD12_VIn2.Enabled = true;
                skinCheckBox_ZhengAD12.Enabled = true;
                textBox_ZhengAD12_Value1.Enabled = true;
                textBox_ZhengAD12_Value2.Enabled = true;
                if (skinCheckBox_ZhengAD12.Checked == true)//梳理skin复选框逻辑
                {
                    textBox_ZhengAD12_Test.Enabled = true;
                    textBox_ZhengAD12_Ref2.Enabled = true;
                }
                if (skinCheckBox_ZhengAD12.Checked == false)
                {
                    textBox_ZhengAD12_Test.Enabled = false;
                    textBox_ZhengAD12_Ref2.Enabled = false;
                }

            }
            else if (CheckBox_ZhengAD12.Checked == false)
            {
                textBox_ZhengAD12_IN.Enabled = false;
                textBox_ZhengAD12_Ref1.Enabled = false;
                textBox_ZhengAD12_VIn1.Enabled = false;
                textBox_ZhengAD12_VIn2.Enabled = false;
                skinCheckBox_ZhengAD12.Enabled = false;
                skinCheckBox_ZhengAD12.Checked = false;
                textBox_ZhengAD12_Test.Enabled = false;
                textBox_ZhengAD12_Ref2.Enabled = false;
                textBox_ZhengAD12_Value1.Enabled = false;
                textBox_ZhengAD12_Value2.Enabled = false;
            }

            if (CheckBox_ZhengAD13.Checked == true)//AD采样测试通道13使能
            {
                textBox_ZhengAD13_IN.Enabled = true;
                textBox_ZhengAD13_Ref1.Enabled = true;
                textBox_ZhengAD13_VIn1.Enabled = true;
                textBox_ZhengAD13_VIn2.Enabled = true;
                textBox_ZhengAD13_Value1.Enabled = true;
                textBox_ZhengAD13_Value2.Enabled = true;
            }
            else if (CheckBox_ZhengAD13.Checked == false)
            {
                textBox_ZhengAD13_IN.Enabled = false;
                textBox_ZhengAD13_Ref1.Enabled = false;
                textBox_ZhengAD13_VIn1.Enabled = false;
                textBox_ZhengAD13_VIn2.Enabled = false;
                textBox_ZhengAD13_Value1.Enabled = false;
                textBox_ZhengAD13_Value2.Enabled = false;
            }
            if (CheckBox_ZhengAD14.Checked == true)//AD采样测试通道14使能
            {
                textBox_ZhengAD14_IN.Enabled = true;
                textBox_ZhengAD14_Ref1.Enabled = true;
                textBox_ZhengAD14_VIn1.Enabled = true;
                textBox_ZhengAD14_VIn2.Enabled = true;
                textBox_ZhengAD14_Value1.Enabled = true;
                textBox_ZhengAD14_Value2.Enabled = true;
            }
            else if (CheckBox_ZhengAD14.Checked == false)
            {
                textBox_ZhengAD14_IN.Enabled = false;
                textBox_ZhengAD14_Ref1.Enabled = false;
                textBox_ZhengAD14_VIn1.Enabled = false;
                textBox_ZhengAD14_VIn2.Enabled = false;
                textBox_ZhengAD14_Value1.Enabled = false;
                textBox_ZhengAD14_Value2.Enabled = false;
            }
            if (CheckBox_ZhengAD15.Checked == true)//AD采样测试通道15使能
            {
                textBox_ZhengAD15_IN.Enabled = true;
                textBox_ZhengAD15_Ref1.Enabled = true;
                textBox_ZhengAD15_VIn1.Enabled = true;
                textBox_ZhengAD15_VIn2.Enabled = true;
                textBox_ZhengAD15_Value1.Enabled = true;
                textBox_ZhengAD15_Value2.Enabled = true;
            }
            else if (CheckBox_ZhengAD15.Checked == false)
            {
                textBox_ZhengAD15_IN.Enabled = false;
                textBox_ZhengAD15_Ref1.Enabled = false;
                textBox_ZhengAD15_VIn1.Enabled = false;
                textBox_ZhengAD15_VIn2.Enabled = false;
                textBox_ZhengAD15_Value1.Enabled = false;
                textBox_ZhengAD15_Value2.Enabled = false;
            }
            if (CheckBox_ZhengAD16.Checked == true)//AD采样测试通道16使能
            {
                textBox_ZhengAD16_IN.Enabled = true;
                textBox_ZhengAD16_Ref1.Enabled = true;
                textBox_ZhengAD16_VIn1.Enabled = true;
                textBox_ZhengAD16_VIn2.Enabled = true;
                textBox_ZhengAD16_Value1.Enabled = true;
                textBox_ZhengAD16_Value2.Enabled = true;
            }
            else if (CheckBox_ZhengAD16.Checked == false)
            {
                textBox_ZhengAD16_IN.Enabled = false;
                textBox_ZhengAD16_Ref1.Enabled = false;
                textBox_ZhengAD16_VIn1.Enabled = false;
                textBox_ZhengAD16_VIn2.Enabled = false;
                textBox_ZhengAD16_Value1.Enabled = false;
                textBox_ZhengAD16_Value2.Enabled = false;
            }
            if (CheckBox_ZhengAD17.Checked == true)//AD采样测试通道17使能
            {
                textBox_ZhengAD17_IN.Enabled = true;
                textBox_ZhengAD17_Ref1.Enabled = true;
                textBox_ZhengAD17_VIn1.Enabled = true;
                textBox_ZhengAD17_VIn2.Enabled = true;
                textBox_ZhengAD17_Value1.Enabled = true;
                textBox_ZhengAD17_Value2.Enabled = true;
            }
            else if (CheckBox_ZhengAD17.Checked == false)
            {
                textBox_ZhengAD17_IN.Enabled = false;
                textBox_ZhengAD17_Ref1.Enabled = false;
                textBox_ZhengAD17_VIn1.Enabled = false;
                textBox_ZhengAD17_VIn2.Enabled = false;
                textBox_ZhengAD17_Value1.Enabled = false;
                textBox_ZhengAD17_Value2.Enabled = false;
            }
            if (CheckBox_ZhengAD18.Checked == true)//AD采样测试通道18使能
            {
                textBox_ZhengAD18_IN.Enabled = true;
                textBox_ZhengAD18_Ref1.Enabled = true;
                textBox_ZhengAD18_VIn1.Enabled = true;
                textBox_ZhengAD18_VIn2.Enabled = true;
                textBox_ZhengAD18_Value1.Enabled = true;
                textBox_ZhengAD18_Value2.Enabled = true;
            }
            else if (CheckBox_ZhengAD18.Checked == false)
            {
                textBox_ZhengAD18_IN.Enabled = false;
                textBox_ZhengAD18_Ref1.Enabled = false;
                textBox_ZhengAD18_VIn1.Enabled = false;
                textBox_ZhengAD18_VIn2.Enabled = false;
                textBox_ZhengAD18_Value1.Enabled = false;
                textBox_ZhengAD18_Value2.Enabled = false;
            }
            if (CheckBox_ZhengAD19.Checked == true)//AD采样测试通道19使能
            {
                textBox_ZhengAD19_IN.Enabled = true;
                textBox_ZhengAD19_Ref1.Enabled = true;
                textBox_ZhengAD19_VIn1.Enabled = true;
                textBox_ZhengAD19_VIn2.Enabled = true;
                textBox_ZhengAD19_Value1.Enabled = true;
                textBox_ZhengAD19_Value2.Enabled = true;
            }
            else if (CheckBox_ZhengAD19.Checked == false)
            {
                textBox_ZhengAD19_IN.Enabled = false;
                textBox_ZhengAD19_Ref1.Enabled = false;
                textBox_ZhengAD19_VIn1.Enabled = false;
                textBox_ZhengAD19_VIn2.Enabled = false;
                textBox_ZhengAD19_Value1.Enabled = false;
                textBox_ZhengAD19_Value2.Enabled = false;
            }
            if (CheckBox_ZhengAD20.Checked == true)//AD采样测试通道20使能
            {
                textBox_ZhengAD20_IN.Enabled = true;
                textBox_ZhengAD20_Ref1.Enabled = true;
                textBox_ZhengAD20_VIn1.Enabled = true;
                textBox_ZhengAD20_VIn2.Enabled = true;
                textBox_ZhengAD20_Value1.Enabled = true;
                textBox_ZhengAD20_Value2.Enabled = true;
            }
            else if (CheckBox_ZhengAD20.Checked == false)
            {
                textBox_ZhengAD20_IN.Enabled = false;
                textBox_ZhengAD20_Ref1.Enabled = false;
                textBox_ZhengAD20_VIn1.Enabled = false;
                textBox_ZhengAD20_VIn2.Enabled = false;
                textBox_ZhengAD20_Value1.Enabled = false;
                textBox_ZhengAD20_Value2.Enabled = false;
            }
            if (CheckBox_ZhengAD21.Checked == true)//AD采样测试通道21使能
            {
                textBox_ZhengAD21_IN.Enabled = true;
                textBox_ZhengAD21_Ref1.Enabled = true;
                textBox_ZhengAD21_VIn1.Enabled = true;
                textBox_ZhengAD21_VIn2.Enabled = true;
                textBox_ZhengAD21_Value1.Enabled = true;
                textBox_ZhengAD21_Value2.Enabled = true;
            }
            else if (CheckBox_ZhengAD21.Checked == false)
            {
                textBox_ZhengAD21_IN.Enabled = false;
                textBox_ZhengAD21_Ref1.Enabled = false;
                textBox_ZhengAD21_VIn1.Enabled = false;
                textBox_ZhengAD21_VIn2.Enabled = false;
                textBox_ZhengAD21_Value1.Enabled = false;
                textBox_ZhengAD21_Value2.Enabled = false;
            }
            if (CheckBox_ZhengAD22.Checked == true)//AD采样测试通道22使能
            {
                textBox_ZhengAD22_IN.Enabled = true;
                textBox_ZhengAD22_Ref1.Enabled = true;
                textBox_ZhengAD22_VIn1.Enabled = true;
                textBox_ZhengAD22_VIn2.Enabled = true;
                textBox_ZhengAD22_Value1.Enabled = true;
                textBox_ZhengAD22_Value2.Enabled = true;
            }
            else if (CheckBox_ZhengAD22.Checked == false)
            {
                textBox_ZhengAD22_IN.Enabled = false;
                textBox_ZhengAD22_Ref1.Enabled = false;
                textBox_ZhengAD22_VIn1.Enabled = false;
                textBox_ZhengAD22_VIn2.Enabled = false;
                textBox_ZhengAD22_Value1.Enabled = false;
                textBox_ZhengAD22_Value2.Enabled = false;
            }
            if (CheckBox_ZhengAD23.Checked == true)//AD采样测试通道23使能
            {
                textBox_ZhengAD23_IN.Enabled = true;
                textBox_ZhengAD23_Ref1.Enabled = true;
                textBox_ZhengAD23_VIn1.Enabled = true;
                textBox_ZhengAD23_VIn2.Enabled = true;
                textBox_ZhengAD23_Value1.Enabled = true;
                textBox_ZhengAD23_Value2.Enabled = true;
            }
            else if (CheckBox_ZhengAD23.Checked == false)
            {
                textBox_ZhengAD23_IN.Enabled = false;
                textBox_ZhengAD23_Ref1.Enabled = false;
                textBox_ZhengAD23_VIn1.Enabled = false;
                textBox_ZhengAD23_VIn2.Enabled = false;
                textBox_ZhengAD23_Value1.Enabled = false;
                textBox_ZhengAD23_Value2.Enabled = false;
            }
            if (CheckBox_ZhengAD24.Checked == true)//AD采样测试通道24使能
            {
                textBox_ZhengAD24_IN.Enabled = true;
                textBox_ZhengAD24_Ref1.Enabled = true;
                textBox_ZhengAD24_VIn1.Enabled = true;
                textBox_ZhengAD24_VIn2.Enabled = true;
                textBox_ZhengAD24_Value1.Enabled = true;
                textBox_ZhengAD24_Value2.Enabled = true;
            }
            else if (CheckBox_ZhengAD24.Checked == false)
            {
                textBox_ZhengAD24_IN.Enabled = false;
                textBox_ZhengAD24_Ref1.Enabled = false;
                textBox_ZhengAD24_VIn1.Enabled = false;
                textBox_ZhengAD24_VIn2.Enabled = false;
                textBox_ZhengAD24_Value1.Enabled = false;
                textBox_ZhengAD24_Value2.Enabled = false;
            }
            if (CheckBox_ZhengAD25.Checked == true)//AD采样测试通道25使能
            {
                textBox_ZhengAD25_IN.Enabled = true;
                textBox_ZhengAD25_Ref1.Enabled = true;
                textBox_ZhengAD25_VIn1.Enabled = true;
                textBox_ZhengAD25_VIn2.Enabled = true;
                textBox_ZhengAD25_Value1.Enabled = true;
                textBox_ZhengAD25_Value2.Enabled = true;
            }
            else if (CheckBox_ZhengAD25.Checked == false)
            {
                textBox_ZhengAD25_IN.Enabled = false;
                textBox_ZhengAD25_Ref1.Enabled = false;
                textBox_ZhengAD25_VIn1.Enabled = false;
                textBox_ZhengAD25_VIn2.Enabled = false;
                textBox_ZhengAD25_Value1.Enabled = false;
                textBox_ZhengAD25_Value2.Enabled = false;
            }
            if (CheckBox_ZhengAD26.Checked == true)//AD采样测试通道26使能
            {
                textBox_ZhengAD26_IN.Enabled = true;
                textBox_ZhengAD26_Ref1.Enabled = true;
                textBox_ZhengAD26_VIn1.Enabled = true;
                textBox_ZhengAD26_VIn2.Enabled = true;
                textBox_ZhengAD26_Value1.Enabled = true;
                textBox_ZhengAD26_Value2.Enabled = true;
            }
            else if (CheckBox_ZhengAD26.Checked == false)
            {
                textBox_ZhengAD26_IN.Enabled = false;
                textBox_ZhengAD26_Ref1.Enabled = false;
                textBox_ZhengAD26_VIn1.Enabled = false;
                textBox_ZhengAD26_VIn2.Enabled = false;
                textBox_ZhengAD26_Value1.Enabled = false;
                textBox_ZhengAD26_Value2.Enabled = false;
            }
            if (CheckBox_ZhengAD27.Checked == true)//AD采样测试通道27使能
            {
                textBox_ZhengAD27_IN.Enabled = true;
                textBox_ZhengAD27_Ref1.Enabled = true;
                textBox_ZhengAD27_VIn1.Enabled = true;
                textBox_ZhengAD27_VIn2.Enabled = true;
                textBox_ZhengAD27_Value1.Enabled = true;
                textBox_ZhengAD27_Value2.Enabled = true;
            }
            else if (CheckBox_ZhengAD27.Checked == false)
            {
                textBox_ZhengAD27_IN.Enabled = false;
                textBox_ZhengAD27_Ref1.Enabled = false;
                textBox_ZhengAD27_VIn1.Enabled = false;
                textBox_ZhengAD27_VIn2.Enabled = false;
                textBox_ZhengAD27_Value1.Enabled = false;
                textBox_ZhengAD27_Value2.Enabled = false;
            }
            if (CheckBox_ZhengAD28.Checked == true)//AD采样测试通道28使能
            {
                textBox_ZhengAD28_IN.Enabled = true;
                textBox_ZhengAD28_Ref1.Enabled = true;
                textBox_ZhengAD28_VIn1.Enabled = true;
                textBox_ZhengAD28_VIn2.Enabled = true;
                textBox_ZhengAD28_Value1.Enabled = true;
                textBox_ZhengAD28_Value2.Enabled = true;
            }
            else if (CheckBox_ZhengAD28.Checked == false)
            {
                textBox_ZhengAD28_IN.Enabled = false;
                textBox_ZhengAD28_Ref1.Enabled = false;
                textBox_ZhengAD28_VIn1.Enabled = false;
                textBox_ZhengAD28_VIn2.Enabled = false;
                textBox_ZhengAD28_Value1.Enabled = false;
                textBox_ZhengAD28_Value2.Enabled = false;
            }
            if (CheckBox_ZhengAD29.Checked == true)//AD采样测试通道29使能
            {
                textBox_ZhengAD29_IN.Enabled = true;
                textBox_ZhengAD29_Ref1.Enabled = true;
                textBox_ZhengAD29_VIn1.Enabled = true;
                textBox_ZhengAD29_VIn2.Enabled = true;
                textBox_ZhengAD29_Value1.Enabled = true;
                textBox_ZhengAD29_Value2.Enabled = true;
            }
            else if (CheckBox_ZhengAD29.Checked == false)
            {
                textBox_ZhengAD29_IN.Enabled = false;
                textBox_ZhengAD29_Ref1.Enabled = false;
                textBox_ZhengAD29_VIn1.Enabled = false;
                textBox_ZhengAD29_VIn2.Enabled = false;
                textBox_ZhengAD29_Value1.Enabled = false;
                textBox_ZhengAD29_Value2.Enabled = false;
            }
            if (CheckBox_ZhengAD30.Checked == true)//AD采样测试通道30使能
            {
                textBox_ZhengAD30_IN.Enabled = true;
                textBox_ZhengAD30_Ref1.Enabled = true;
                textBox_ZhengAD30_VIn1.Enabled = true;
                textBox_ZhengAD30_VIn2.Enabled = true;
                textBox_ZhengAD30_Value1.Enabled = true;
                textBox_ZhengAD30_Value2.Enabled = true;
            }
            else if (CheckBox_ZhengAD30.Checked == false)
            {
                textBox_ZhengAD30_IN.Enabled = false;
                textBox_ZhengAD30_Ref1.Enabled = false;
                textBox_ZhengAD30_VIn1.Enabled = false;
                textBox_ZhengAD30_VIn2.Enabled = false;
                textBox_ZhengAD30_Value1.Enabled = false;
                textBox_ZhengAD30_Value2.Enabled = false;
            }
            if (CheckBox_ZhengAD31.Checked == true)//AD采样测试通道31使能
            {
                textBox_ZhengAD31_IN.Enabled = true;
                textBox_ZhengAD31_Ref1.Enabled = true;
                textBox_ZhengAD31_VIn1.Enabled = true;
                textBox_ZhengAD31_VIn2.Enabled = true;
                textBox_ZhengAD31_Value1.Enabled = true;
                textBox_ZhengAD31_Value2.Enabled = true;
            }
            else if (CheckBox_ZhengAD31.Checked == false)
            {
                textBox_ZhengAD31_IN.Enabled = false;
                textBox_ZhengAD31_Ref1.Enabled = false;
                textBox_ZhengAD31_VIn1.Enabled = false;
                textBox_ZhengAD31_VIn2.Enabled = false;
                textBox_ZhengAD31_Value1.Enabled = false;
                textBox_ZhengAD31_Value2.Enabled = false;
            }
            if (CheckBox_ZhengAD32.Checked == true)//AD采样测试通道32使能
            {
                textBox_ZhengAD32_IN.Enabled = true;
                textBox_ZhengAD32_Ref1.Enabled = true;
                textBox_ZhengAD32_VIn1.Enabled = true;
                textBox_ZhengAD32_VIn2.Enabled = true;
                textBox_ZhengAD32_Value1.Enabled = true;
                textBox_ZhengAD32_Value2.Enabled = true;
            }
            else if (CheckBox_ZhengAD32.Checked == false)
            {
                textBox_ZhengAD32_IN.Enabled = false;
                textBox_ZhengAD32_Ref1.Enabled = false;
                textBox_ZhengAD32_VIn1.Enabled = false;
                textBox_ZhengAD32_VIn2.Enabled = false;
                textBox_ZhengAD32_Value1.Enabled = false;
                textBox_ZhengAD32_Value2.Enabled = false;
            }
            if (CheckBox_ZhengAD33.Checked == true)//AD采样测试通道33使能
            {
                textBox_ZhengAD33_IN.Enabled = true;
                textBox_ZhengAD33_Ref1.Enabled = true;
                textBox_ZhengAD33_VIn1.Enabled = true;
                textBox_ZhengAD33_VIn2.Enabled = true;
                textBox_ZhengAD33_Value1.Enabled = true;
                textBox_ZhengAD33_Value2.Enabled = true;
            }
            else if (CheckBox_ZhengAD33.Checked == false)
            {
                textBox_ZhengAD33_IN.Enabled = false;
                textBox_ZhengAD33_Ref1.Enabled = false;
                textBox_ZhengAD33_VIn1.Enabled = false;
                textBox_ZhengAD33_VIn2.Enabled = false;
                textBox_ZhengAD33_Value1.Enabled = false;
                textBox_ZhengAD33_Value2.Enabled = false;
            }
            if (CheckBox_ZhengAD34.Checked == true)//AD采样测试通道34使能
            {
                textBox_ZhengAD34_IN.Enabled = true;
                textBox_ZhengAD34_Ref1.Enabled = true;
                textBox_ZhengAD34_VIn1.Enabled = true;
                textBox_ZhengAD34_VIn2.Enabled = true;
                textBox_ZhengAD34_Value1.Enabled = true;
                textBox_ZhengAD34_Value2.Enabled = true;
            }
            else if (CheckBox_ZhengAD34.Checked == false)
            {
                textBox_ZhengAD34_IN.Enabled = false;
                textBox_ZhengAD34_Ref1.Enabled = false;
                textBox_ZhengAD34_VIn1.Enabled = false;
                textBox_ZhengAD34_VIn2.Enabled = false;
                textBox_ZhengAD34_Value1.Enabled = false;
                textBox_ZhengAD34_Value2.Enabled = false;
            }
            if (CheckBox_ZhengAD35.Checked == true)//AD采样测试通道35使能
            {
                textBox_ZhengAD35_IN.Enabled = true;
                textBox_ZhengAD35_Ref1.Enabled = true;
                textBox_ZhengAD35_VIn1.Enabled = true;
                textBox_ZhengAD35_VIn2.Enabled = true;
                textBox_ZhengAD35_Value1.Enabled = true;
                textBox_ZhengAD35_Value2.Enabled = true;
            }
            else if (CheckBox_ZhengAD35.Checked == false)
            {
                textBox_ZhengAD35_IN.Enabled = false;
                textBox_ZhengAD35_Ref1.Enabled = false;
                textBox_ZhengAD35_VIn1.Enabled = false;
                textBox_ZhengAD35_VIn2.Enabled = false;
                textBox_ZhengAD35_Value1.Enabled = false;
                textBox_ZhengAD35_Value2.Enabled = false;
            }
            if (CheckBox_ZhengAD36.Checked == true)//AD采样测试通道36使能
            {
                textBox_ZhengAD36_IN.Enabled = true;
                textBox_ZhengAD36_Ref1.Enabled = true;
                textBox_ZhengAD36_VIn1.Enabled = true;
                textBox_ZhengAD36_VIn2.Enabled = true;
                textBox_ZhengAD36_Value1.Enabled = true;
                textBox_ZhengAD36_Value2.Enabled = true;
            }
            else if (CheckBox_ZhengAD36.Checked == false)
            {
                textBox_ZhengAD36_IN.Enabled = false;
                textBox_ZhengAD36_Ref1.Enabled = false;
                textBox_ZhengAD36_VIn1.Enabled = false;
                textBox_ZhengAD36_VIn2.Enabled = false;
                textBox_ZhengAD36_Value1.Enabled = false;
                textBox_ZhengAD36_Value2.Enabled = false;
            }
            if (CheckBox_ZhengAD37.Checked == true)//AD采样测试通道37使能
            {
                textBox_ZhengAD37_IN.Enabled = true;
                textBox_ZhengAD37_Ref1.Enabled = true;
                textBox_ZhengAD37_VIn1.Enabled = true;
                textBox_ZhengAD37_VIn2.Enabled = true;
                textBox_ZhengAD37_Value1.Enabled = true;
                textBox_ZhengAD37_Value2.Enabled = true;
            }
            else if (CheckBox_ZhengAD37.Checked == false)
            {
                textBox_ZhengAD37_IN.Enabled = false;
                textBox_ZhengAD37_Ref1.Enabled = false;
                textBox_ZhengAD37_VIn1.Enabled = false;
                textBox_ZhengAD37_VIn2.Enabled = false;
                textBox_ZhengAD37_Value1.Enabled = false;
                textBox_ZhengAD37_Value2.Enabled = false;
            }
            if (CheckBox_ZhengAD38.Checked == true)//AD采样测试通道38使能
            {
                textBox_ZhengAD38_IN.Enabled = true;
                textBox_ZhengAD38_Ref1.Enabled = true;
                textBox_ZhengAD38_VIn1.Enabled = true;
                textBox_ZhengAD38_VIn2.Enabled = true;
                textBox_ZhengAD38_Value1.Enabled = true;
                textBox_ZhengAD38_Value2.Enabled = true;
            }
            else if (CheckBox_ZhengAD38.Checked == false)
            {
                textBox_ZhengAD38_IN.Enabled = false;
                textBox_ZhengAD38_Ref1.Enabled = false;
                textBox_ZhengAD38_VIn1.Enabled = false;
                textBox_ZhengAD38_VIn2.Enabled = false;
                textBox_ZhengAD38_Value1.Enabled = false;
                textBox_ZhengAD38_Value2.Enabled = false;
            }

        }

        //读取配置文件
        private void button_ReadFile_Click(object sender, EventArgs e)
        {
            string[] peizhiInfoFull;
            byte[] peizhiInfoData = new byte[27];//配置文件里第9行配置信息
            int readShort = 0, readVolt = 0, readIOOut = 0, readIOIn = 0, readDA = 0, readAD = 0;
            DataTable checkListShort1, checkListVolt1, checkListfuction1;
            List<string> note;

            openFileDialog1.InitialDirectory = "D:\\";
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileStream filest = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.ReadWrite);
                    StreamReader checkIn = new StreamReader(filest);
                    string fileFlag = checkIn.ReadLine();
                    if (fileFlag != whichform)
                    {
                        MessageBox.Show("读取文件错误，请重新读取");
                        return;
                    }
                    string fileTime = checkIn.ReadLine();

                    readShort = int.Parse(checkIn.ReadLine());
                    readVolt = int.Parse(checkIn.ReadLine());
                    readIOOut = int.Parse(checkIn.ReadLine());
                    readIOIn = int.Parse(checkIn.ReadLine());
                    readDA = int.Parse(checkIn.ReadLine());
                    readAD = int.Parse(checkIn.ReadLine());
                    string peizhiInfo = checkIn.ReadLine();

                    peizhiInfoFull = peizhiInfo.Split(';');//数组peizhiInfoFull包含需要发送到下位机的配置资源全部信息

                    for (int i = 0; i <= 26; i++)//数组peizhiInfoFull数组中的二进制字符串转化为byte数组
                    {
                        peizhiInfoData[i] = Convert.ToByte(peizhiInfoFull[i], 2);
                    }

                    string peizhi = checkIn.ReadLine();//peizhi 一个字符串包含在线显示和Word报表信息
                    List<List<string>> peizhiList = new List<List<string>>();//将peizhi字符串中的信息分解到数组peizhiList中
                    checkListShort1 = new DataTable();//实例化
                    checkListShort1.Columns.Add("资源测试通道");
                    checkListShort1.Columns.Add("测试点1");
                    checkListShort1.Columns.Add("测试点2");
                    checkListShort1.Columns.Add("理论值/Ω");


                    checkListVolt1 = new DataTable();
                    checkListVolt1.Columns.Add("资源测试通道");
                    checkListVolt1.Columns.Add("测试点");
                    checkListVolt1.Columns.Add("基准点");
                    checkListVolt1.Columns.Add("理论值/V");


                    checkListfuction1 = new DataTable();
                    checkListfuction1.Columns.Add("资源测试通道");
                    checkListfuction1.Columns.Add("输入点");
                    checkListfuction1.Columns.Add("基准点1");
                    checkListfuction1.Columns.Add("输入电压1");
                    checkListfuction1.Columns.Add("输入电压2");
                    checkListfuction1.Columns.Add("测试点");
                    checkListfuction1.Columns.Add("基准点2");
                    checkListfuction1.Columns.Add("理论值1/V");
                    checkListfuction1.Columns.Add("理论值2/V");


                    string[] peizhiDeal = peizhi.Split(';');
                    for (int i = 0; i < peizhiDeal.Length; i++)//分解配置信息的过程
                    {
                        string[] s = peizhiDeal[i].Split(',');
                        List<string> item = new List<string>();
                        for (int j = 0; j < s.Length; j++)
                            item.Add(s[j]);
                        peizhiList.Add(item);
                    }
                    note = peizhiList[0];
                    if (readShort != 0)
                    {
                        for (int j = 1; j <= readShort; j++)
                        {
                            List<string> peizhiListItem = peizhiList[j];
                            DataRow newRow = checkListShort1.NewRow();
                            newRow[0] = peizhiListItem[0];
                            newRow[1] = peizhiListItem[1];
                            newRow[2] = peizhiListItem[2];
                            newRow[3] = peizhiListItem[3];
                            checkListShort1.Rows.Add(newRow);

                        }
                    }

                    if (readVolt != 0)
                    {
                        for (int k = readShort + 1; k <= (readShort + readVolt); k++)
                        {
                            List<string> peizhiListItem = peizhiList[k];
                            DataRow newRow = checkListVolt1.NewRow();
                            newRow[0] = peizhiListItem[0];
                            newRow[1] = peizhiListItem[1];
                            newRow[2] = peizhiListItem[2];
                            newRow[3] = peizhiListItem[3];
                            //思路：准备采用动态插入的办法，识别测试通道数，插入相应测试结果。如何识别通道数？识别“汉字字符”好了
                            checkListVolt1.Rows.Add(newRow);

                        }
                    }
                    if ((readIOOut + readIOIn + readDA + readAD) != 0)
                    {
                        for (int h = readShort + readVolt + 1; h <= (readShort + readVolt + readIOOut + readIOIn + readDA + readAD); h++)
                        {
                            List<string> peizhiListItem = peizhiList[h];
                            DataRow newRow = checkListfuction1.NewRow();
                            newRow[0] = peizhiListItem[0];
                            newRow[1] = peizhiListItem[1];
                            newRow[2] = peizhiListItem[2];
                            newRow[3] = peizhiListItem[3];
                            newRow[4] = peizhiListItem[4];
                            newRow[5] = peizhiListItem[5];
                            newRow[6] = peizhiListItem[6];
                            newRow[7] = peizhiListItem[7];
                            newRow[8] = peizhiListItem[8];
                            checkListfuction1.Rows.Add(newRow);
                        }
                    }

                    for (int h = 0; h < checkListShort1.Rows.Count; h++)
                    {
                        switch (checkListShort1.Rows[h][0].ToString())
                        {
                            case "短路测试通道1":
                                CheckBox_ZhengShort1.Checked = true;
                                textBox_ZhengShort1_Test1.Text = checkListShort1.Rows[h][1].ToString();
                                textBox_ZhengShort1_Test2.Text = checkListShort1.Rows[h][2].ToString();
                                textBox_ZhengShort1_Value.Text = checkListShort1.Rows[h][3].ToString();
                                break;
                            case "短路测试通道2":
                                CheckBox_ZhengShort2.Checked = true;
                                textBox_ZhengShort2_Test1.Text = checkListShort1.Rows[h][1].ToString();
                                textBox_ZhengShort2_Test2.Text = checkListShort1.Rows[h][2].ToString();
                                textBox_ZhengShort2_Value.Text = checkListShort1.Rows[h][3].ToString();
                                break;
                            case "短路测试通道3":
                                CheckBox_ZhengShort3.Checked = true;
                                textBox_ZhengShort3_Test1.Text = checkListShort1.Rows[h][1].ToString();
                                textBox_ZhengShort3_Test2.Text = checkListShort1.Rows[h][2].ToString();
                                textBox_ZhengShort3_Value.Text = checkListShort1.Rows[h][3].ToString();
                                break;
                            case "短路测试通道4":
                                CheckBox_ZhengShort4.Checked = true;
                                textBox_ZhengShort4_Test1.Text = checkListShort1.Rows[h][1].ToString();
                                textBox_ZhengShort4_Test2.Text = checkListShort1.Rows[h][2].ToString();
                                textBox_ZhengShort4_Value.Text = checkListShort1.Rows[h][3].ToString();
                                break;
                            case "短路测试通道5":
                                CheckBox_ZhengShort5.Checked = true;
                                textBox_ZhengShort5_Test1.Text = checkListShort1.Rows[h][1].ToString();
                                textBox_ZhengShort5_Test2.Text = checkListShort1.Rows[h][2].ToString();
                                textBox_ZhengShort5_Value.Text = checkListShort1.Rows[h][3].ToString();
                                break;
                            case "短路测试通道6":
                                CheckBox_ZhengShort6.Checked = true;
                                textBox_ZhengShort6_Test1.Text = checkListShort1.Rows[h][1].ToString();
                                textBox_ZhengShort6_Test2.Text = checkListShort1.Rows[h][2].ToString();
                                textBox_ZhengShort6_Value.Text = checkListShort1.Rows[h][3].ToString();
                                break;
                            case "短路测试通道7":
                                CheckBox_ZhengShort7.Checked = true;
                                textBox_ZhengShort7_Test1.Text = checkListShort1.Rows[h][1].ToString();
                                textBox_ZhengShort7_Test2.Text = checkListShort1.Rows[h][2].ToString();
                                textBox_ZhengShort7_Value.Text = checkListShort1.Rows[h][3].ToString();
                                break;
                            case "短路测试通道8":
                                CheckBox_ZhengShort8.Checked = true;
                                textBox_ZhengShort8_Test1.Text = checkListShort1.Rows[h][1].ToString();
                                textBox_ZhengShort8_Test2.Text = checkListShort1.Rows[h][2].ToString();
                                textBox_ZhengShort8_Value.Text = checkListShort1.Rows[h][3].ToString();
                                break;
                            default:
                                break;
                        }
                    }
                    for (int h = 0; h < checkListVolt1.Rows.Count; h++)
                    {
                        switch (checkListVolt1.Rows[h][0].ToString())
                        {
                            case "电压输出测试通道1":
                                CheckBox_ZhengVolt1.Checked = true;
                                textBox_ZhengVolt1_Test1.Text = checkListVolt1.Rows[h][1].ToString();
                                textBox_ZhengVolt1_Test2.Text = checkListVolt1.Rows[h][2].ToString();
                                textBox_ZhengVolt1_Value.Text = checkListVolt1.Rows[h][3].ToString();
                                break;
                            case "电压输出测试通道2":
                                CheckBox_ZhengVolt2.Checked = true;
                                textBox_ZhengVolt2_Test1.Text = checkListVolt1.Rows[h][1].ToString();
                                textBox_ZhengVolt2_Test2.Text = checkListVolt1.Rows[h][2].ToString();
                                textBox_ZhengVolt2_Value.Text = checkListVolt1.Rows[h][3].ToString();
                                break;
                            case "电压输出测试通道3":
                                CheckBox_ZhengVolt3.Checked = true;
                                textBox_ZhengVolt3_Test1.Text = checkListVolt1.Rows[h][1].ToString();
                                textBox_ZhengVolt3_Test2.Text = checkListVolt1.Rows[h][2].ToString();
                                textBox_ZhengVolt3_Value.Text = checkListVolt1.Rows[h][3].ToString();
                                break;
                            case "电压输出测试通道4":
                                CheckBox_ZhengVolt4.Checked = true;
                                textBox_ZhengVolt4_Test1.Text = checkListVolt1.Rows[h][1].ToString();
                                textBox_ZhengVolt4_Test2.Text = checkListVolt1.Rows[h][2].ToString();
                                textBox_ZhengVolt4_Value.Text = checkListVolt1.Rows[h][3].ToString();
                                break;
                            case "电压输出测试通道5":
                                CheckBox_ZhengVolt5.Checked = true;
                                textBox_ZhengVolt5_Test1.Text = checkListVolt1.Rows[h][1].ToString();
                                textBox_ZhengVolt5_Test2.Text = checkListVolt1.Rows[h][2].ToString();
                                textBox_ZhengVolt5_Value.Text = checkListVolt1.Rows[h][3].ToString();
                                break;
                            case "电压输出测试通道6":
                                CheckBox_ZhengVolt6.Checked = true;
                                textBox_ZhengVolt6_Test1.Text = checkListVolt1.Rows[h][1].ToString();
                                textBox_ZhengVolt6_Test2.Text = checkListVolt1.Rows[h][2].ToString();
                                textBox_ZhengVolt6_Value.Text = checkListVolt1.Rows[h][3].ToString();
                                break;
                            case "电压输出测试通道7":
                                CheckBox_ZhengVolt7.Checked = true;
                                textBox_ZhengVolt7_Test1.Text = checkListVolt1.Rows[h][1].ToString();
                                textBox_ZhengVolt7_Test2.Text = checkListVolt1.Rows[h][2].ToString();
                                textBox_ZhengVolt7_Value.Text = checkListVolt1.Rows[h][3].ToString();
                                break;
                            case "电压输出测试通道8":
                                CheckBox_ZhengVolt8.Checked = true;
                                textBox_ZhengVolt8_Test1.Text = checkListVolt1.Rows[h][1].ToString();
                                textBox_ZhengVolt8_Test2.Text = checkListVolt1.Rows[h][2].ToString();
                                textBox_ZhengVolt8_Value.Text = checkListVolt1.Rows[h][3].ToString();
                                break;
                            default:
                                break;
                        }
                    }
                    for (int h = 0; h < checkListfuction1.Rows.Count; h++)
                    {
                        switch (checkListfuction1.Rows[h][0].ToString())
                        {
                            case "I/O输出测试通道1":
                                CheckBox_ZhengIOOut1.Checked = true;
                                switch (peizhiInfoData[4] & 0x03)
                                {
                                    case 0x01:
                                        skinCheckBox_ZhengIOOut1.Checked = true;
                                        textBox_ZhengIOOut1_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOOut1_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOOut1_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOOut1_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOOut1_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengIOOut1_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengIOOut1_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOOut1_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x02:
                                        textBox_ZhengIOOut1_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengIOOut1_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengIOOut1_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOOut1_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case "I/O输出测试通道2":
                                CheckBox_ZhengIOOut2.Checked = true;
                                switch ((peizhiInfoData[4] & 0x0C) >> 2)
                                {
                                    case 0x01:
                                        skinCheckBox_ZhengIOOut2.Checked = true;
                                        textBox_ZhengIOOut2_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOOut2_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOOut2_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOOut2_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOOut2_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengIOOut2_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengIOOut2_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOOut2_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x02:
                                        textBox_ZhengIOOut2_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengIOOut2_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengIOOut2_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOOut2_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case "I/O输出测试通道3":
                                CheckBox_ZhengIOOut3.Checked = true;
                                switch ((peizhiInfoData[4] & 0x30) >> 4)
                                {
                                    case 0x01:
                                        skinCheckBox_ZhengIOOut3.Checked = true;
                                        textBox_ZhengIOOut3_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOOut3_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOOut3_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOOut3_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOOut3_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengIOOut3_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengIOOut3_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOOut3_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x02:
                                        textBox_ZhengIOOut3_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengIOOut3_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengIOOut3_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOOut3_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case "I/O输出测试通道4":
                                CheckBox_ZhengIOOut4.Checked = true;
                                switch ((peizhiInfoData[4] & 0xC0) >> 6)
                                {
                                    case 0x01:
                                        skinCheckBox_ZhengIOOut4.Checked = true;
                                        textBox_ZhengIOOut4_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOOut4_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOOut4_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOOut4_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOOut4_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengIOOut4_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengIOOut4_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOOut4_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x02:
                                        textBox_ZhengIOOut4_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengIOOut4_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengIOOut4_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOOut4_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case "I/O输出测试通道5":
                                CheckBox_ZhengIOOut5.Checked = true;
                                switch (peizhiInfoData[5] & 0x03)
                                {
                                    case 0x01:
                                        skinCheckBox_ZhengIOOut5.Checked = true;
                                        textBox_ZhengIOOut5_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOOut5_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOOut5_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOOut5_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOOut5_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengIOOut5_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengIOOut5_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOOut5_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x02:
                                        textBox_ZhengIOOut5_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengIOOut5_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengIOOut5_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOOut5_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case "I/O输出测试通道6":
                                CheckBox_ZhengIOOut6.Checked = true;
                                switch ((peizhiInfoData[5] & 0x0C) >> 2)
                                {
                                    case 0x01:
                                        skinCheckBox_ZhengIOOut6.Checked = true;
                                        textBox_ZhengIOOut6_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOOut6_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOOut6_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOOut6_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOOut6_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengIOOut6_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengIOOut6_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOOut6_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x02:
                                        textBox_ZhengIOOut6_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengIOOut6_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengIOOut6_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOOut6_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case "I/O输出测试通道7":
                                CheckBox_ZhengIOOut7.Checked = true;
                                switch ((peizhiInfoData[5] & 0x30) >> 4)
                                {
                                    case 0x01:
                                        skinCheckBox_ZhengIOOut7.Checked = true;
                                        textBox_ZhengIOOut7_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOOut7_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOOut7_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOOut7_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOOut7_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengIOOut7_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengIOOut7_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOOut7_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x02:
                                        textBox_ZhengIOOut7_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengIOOut7_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengIOOut7_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOOut7_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case "I/O输出测试通道8":
                                CheckBox_ZhengIOOut8.Checked = true;
                                switch ((peizhiInfoData[5] & 0xC0) >> 6)
                                {
                                    case 0x01:
                                        skinCheckBox_ZhengIOOut8.Checked = true;
                                        textBox_ZhengIOOut8_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOOut8_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOOut8_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOOut8_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOOut8_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengIOOut8_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengIOOut8_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOOut8_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x02:
                                        textBox_ZhengIOOut8_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengIOOut8_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengIOOut8_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOOut8_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case "I/O输出测试通道9":
                                CheckBox_ZhengIOOut9.Checked = true;
                                switch (peizhiInfoData[6] & 0x03)
                                {
                                    case 0x01:
                                        skinCheckBox_ZhengIOOut9.Checked = true;
                                        textBox_ZhengIOOut9_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOOut9_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOOut9_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOOut9_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOOut9_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengIOOut9_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengIOOut9_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOOut9_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x02:
                                        textBox_ZhengIOOut9_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengIOOut9_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengIOOut9_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOOut9_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case "I/O输出测试通道10":
                                CheckBox_ZhengIOOut10.Checked = true;
                                switch ((peizhiInfoData[6] & 0x0C) >> 2)
                                {
                                    case 0x01:
                                        skinCheckBox_ZhengIOOut10.Checked = true;
                                        textBox_ZhengIOOut10_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOOut10_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOOut10_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOOut10_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOOut10_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengIOOut10_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengIOOut10_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOOut10_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x02:
                                        textBox_ZhengIOOut10_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengIOOut10_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengIOOut10_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOOut10_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case "I/O输出测试通道11":
                                CheckBox_ZhengIOOut11.Checked = true;
                                switch ((peizhiInfoData[6] & 0x30) >> 4)
                                {
                                    case 0x01:
                                        skinCheckBox_ZhengIOOut11.Checked = true;
                                        textBox_ZhengIOOut11_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOOut11_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOOut11_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOOut11_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOOut11_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengIOOut11_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengIOOut11_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOOut11_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x02:
                                        textBox_ZhengIOOut11_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengIOOut11_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengIOOut11_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOOut11_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case "I/O输出测试通道12":
                                CheckBox_ZhengIOOut12.Checked = true;
                                switch ((peizhiInfoData[6] & 0xC0) >> 6)
                                {
                                    case 0x01:
                                        skinCheckBox_ZhengIOOut12.Checked = true;
                                        textBox_ZhengIOOut12_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOOut12_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOOut12_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOOut12_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOOut12_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengIOOut12_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengIOOut12_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOOut12_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x02:
                                        textBox_ZhengIOOut12_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengIOOut12_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengIOOut12_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOOut12_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case "I/O输出测试通道13":
                                CheckBox_ZhengIOOut13.Checked = true;
                                switch (peizhiInfoData[7] & 0x03)
                                {
                                    case 0x01:
                                        skinCheckBox_ZhengIOOut13.Checked = true;
                                        textBox_ZhengIOOut13_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOOut13_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOOut13_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOOut13_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOOut13_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengIOOut13_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengIOOut13_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOOut13_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x02:
                                        textBox_ZhengIOOut13_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengIOOut13_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengIOOut13_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOOut13_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case "I/O输出测试通道14":
                                CheckBox_ZhengIOOut14.Checked = true;
                                switch ((peizhiInfoData[7] & 0x0C) >> 2)
                                {
                                    case 0x01:
                                        skinCheckBox_ZhengIOOut14.Checked = true;
                                        textBox_ZhengIOOut14_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOOut14_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOOut14_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOOut14_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOOut14_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengIOOut14_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengIOOut14_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOOut14_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x02:
                                        textBox_ZhengIOOut14_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengIOOut14_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengIOOut14_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOOut14_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case "I/O输出测试通道15":
                                CheckBox_ZhengIOOut15.Checked = true;
                                switch ((peizhiInfoData[7] & 0x30) >> 4)
                                {
                                    case 0x01:
                                        skinCheckBox_ZhengIOOut15.Checked = true;
                                        textBox_ZhengIOOut15_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOOut15_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOOut15_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOOut15_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOOut15_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengIOOut15_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengIOOut15_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOOut15_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x02:
                                        textBox_ZhengIOOut15_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengIOOut15_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengIOOut15_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOOut15_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case "I/O输出测试通道16":
                                CheckBox_ZhengIOOut16.Checked = true;
                                switch ((peizhiInfoData[7] & 0xC0) >> 6)
                                {
                                    case 0x01:
                                        skinCheckBox_ZhengIOOut16.Checked = true;
                                        textBox_ZhengIOOut16_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOOut16_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOOut16_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOOut16_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOOut16_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengIOOut16_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengIOOut16_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOOut16_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x02:
                                        textBox_ZhengIOOut16_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengIOOut16_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengIOOut16_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOOut16_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case "I/O输入测试通道1":
                                CheckBox_ZhengIOIn1.Checked = true;
                                switch (peizhiInfoData[8] & 0x03)
                                {
                                    case 0x01:
                                        skinCheckBox_ZhengIOIn1.Checked = true;
                                        textBox_ZhengIOIn1_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOIn1_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOIn1_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOIn1_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOIn1_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengIOIn1_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengIOIn1_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOIn1_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x02:
                                        textBox_ZhengIOIn1_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOIn1_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOIn1_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOIn1_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOIn1_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOIn1_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case "I/O输入测试通道2":
                                CheckBox_ZhengIOIn2.Checked = true;
                                switch ((peizhiInfoData[8] & 0x0C) >> 2)
                                {
                                    case 0x01:
                                        skinCheckBox_ZhengIOIn2.Checked = true;
                                        textBox_ZhengIOIn2_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOIn2_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOIn2_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOIn2_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOIn2_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengIOIn2_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengIOIn2_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOIn2_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x02:
                                        textBox_ZhengIOIn2_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOIn2_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOIn2_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOIn2_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOIn2_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOIn2_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case "I/O输入测试通道3":
                                CheckBox_ZhengIOIn3.Checked = true;
                                switch ((peizhiInfoData[8] & 0x30) >> 4)
                                {
                                    case 0x01:
                                        skinCheckBox_ZhengIOIn3.Checked = true;
                                        textBox_ZhengIOIn3_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOIn3_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOIn3_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOIn3_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOIn3_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengIOIn3_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengIOIn3_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOIn3_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x02:
                                        textBox_ZhengIOIn3_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOIn3_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOIn3_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOIn3_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOIn3_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOIn3_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case "I/O输入测试通道4":
                                CheckBox_ZhengIOIn4.Checked = true;
                                switch ((peizhiInfoData[8] & 0xC0) >> 6)
                                {
                                    case 0x01:
                                        skinCheckBox_ZhengIOIn4.Checked = true;
                                        textBox_ZhengIOIn4_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOIn4_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOIn4_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOIn4_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOIn4_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengIOIn4_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengIOIn4_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOIn4_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x02:
                                        textBox_ZhengIOIn4_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOIn4_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOIn4_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOIn4_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOIn4_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOIn4_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case "I/O输入测试通道5":
                                CheckBox_ZhengIOIn5.Checked = true;
                                switch (peizhiInfoData[9] & 0x03)
                                {
                                    case 0x01:
                                        skinCheckBox_ZhengIOIn5.Checked = true;
                                        textBox_ZhengIOIn5_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOIn5_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOIn5_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOIn5_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOIn5_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengIOIn5_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengIOIn5_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOIn5_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x02:
                                        textBox_ZhengIOIn5_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOIn5_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOIn5_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOIn5_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOIn5_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOIn5_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case "I/O输入测试通道6":
                                CheckBox_ZhengIOIn6.Checked = true;
                                switch ((peizhiInfoData[9] & 0x0C) >> 2)
                                {
                                    case 0x01:
                                        skinCheckBox_ZhengIOIn6.Checked = true;
                                        textBox_ZhengIOIn6_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOIn6_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOIn6_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOIn6_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOIn6_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengIOIn6_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengIOIn6_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOIn6_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x02:
                                        textBox_ZhengIOIn6_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOIn6_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOIn6_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOIn6_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOIn6_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOIn6_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case "I/O输入测试通道7":
                                CheckBox_ZhengIOIn7.Checked = true;
                                switch ((peizhiInfoData[9] & 0x30) >> 4)
                                {
                                    case 0x01:
                                        skinCheckBox_ZhengIOIn7.Checked = true;
                                        textBox_ZhengIOIn7_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOIn7_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOIn7_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOIn7_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOIn7_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengIOIn7_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengIOIn7_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOIn7_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x02:
                                        textBox_ZhengIOIn7_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOIn7_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOIn7_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOIn7_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOIn7_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOIn7_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case "I/O输入测试通道8":
                                CheckBox_ZhengIOIn8.Checked = true;
                                switch ((peizhiInfoData[9] & 0xC0) >> 6)
                                {
                                    case 0x01:
                                        skinCheckBox_ZhengIOIn8.Checked = true;
                                        textBox_ZhengIOIn8_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOIn8_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOIn8_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOIn8_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOIn8_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengIOIn8_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengIOIn8_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOIn8_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x02:
                                        textBox_ZhengIOIn8_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOIn8_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOIn8_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOIn8_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOIn8_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOIn8_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case "I/O输入测试通道9":
                                CheckBox_ZhengIOIn9.Checked = true;
                                switch (peizhiInfoData[10] & 0x03)
                                {
                                    case 0x01:
                                        skinCheckBox_ZhengIOIn9.Checked = true;
                                        textBox_ZhengIOIn9_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOIn9_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOIn9_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOIn9_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOIn9_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengIOIn9_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengIOIn9_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOIn9_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x02:
                                        textBox_ZhengIOIn9_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOIn9_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOIn9_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOIn9_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOIn9_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOIn9_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case "I/O输入测试通道10":
                                CheckBox_ZhengIOIn10.Checked = true;
                                switch ((peizhiInfoData[10] & 0x0C) >> 2)
                                {
                                    case 0x01:
                                        skinCheckBox_ZhengIOIn10.Checked = true;
                                        textBox_ZhengIOIn10_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOIn10_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOIn10_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOIn10_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOIn10_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengIOIn10_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengIOIn10_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOIn10_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x02:
                                        textBox_ZhengIOIn10_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOIn10_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOIn10_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOIn10_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOIn10_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOIn10_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case "I/O输入测试通道11":
                                CheckBox_ZhengIOIn11.Checked = true;
                                switch ((peizhiInfoData[10] & 0x30) >> 4)
                                {
                                    case 0x01:
                                        radioButton_ZhengIOIn11b_C.Checked = true;
                                        skinCheckBox_ZhengIOIn11.Checked = true;
                                        textBox_ZhengIOIn11_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOIn11_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOIn11b_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOIn11b_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOIn11_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengIOIn11_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengIOIn11_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOIn11_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x02:
                                        radioButton_ZhengIOIn11b_C.Checked = true;
                                        textBox_ZhengIOIn11_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOIn11_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOIn11b_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOIn11b_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOIn11_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOIn11_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x03:
                                        radioButton_ZhengIOIn11a_C.Checked = true;
                                        textBox_ZhengIOIn11_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOIn11_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOIn11_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOIn11_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOIn11_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOIn11_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case "I/O输入测试通道12":
                                CheckBox_ZhengIOIn12.Checked = true;
                                switch ((peizhiInfoData[10] & 0xC0) >> 6)
                                {
                                    case 0x01:
                                        radioButton_ZhengIOIn12b_C.Checked = true;
                                        skinCheckBox_ZhengIOIn12.Checked = true;
                                        textBox_ZhengIOIn12_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOIn12_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOIn12b_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOIn12b_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOIn12_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengIOIn12_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengIOIn12_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOIn12_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x02:
                                        radioButton_ZhengIOIn12b_C.Checked = true;
                                        textBox_ZhengIOIn12_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOIn12_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOIn12b_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOIn12b_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOIn12_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOIn12_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x03:
                                        radioButton_ZhengIOIn12a_C.Checked = true;
                                        textBox_ZhengIOIn12_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOIn12_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOIn12_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOIn12_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOIn12_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOIn12_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case "I/O输入测试通道13":
                                CheckBox_ZhengIOIn13.Checked = true;
                                switch (peizhiInfoData[11] & 0x03)
                                {
                                    case 0x01:
                                        radioButton_ZhengIOIn13b_C.Checked = true;
                                        skinCheckBox_ZhengIOIn13.Checked = true;
                                        textBox_ZhengIOIn13_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOIn13_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOIn13b_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOIn13b_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOIn13_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengIOIn13_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengIOIn13_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOIn13_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x02:
                                        radioButton_ZhengIOIn13b_C.Checked = true;
                                        textBox_ZhengIOIn13_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOIn13_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOIn13b_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOIn13b_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOIn13_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOIn13_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x03:
                                        radioButton_ZhengIOIn13a_C.Checked = true;
                                        textBox_ZhengIOIn13_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOIn13_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOIn13_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOIn13_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOIn13_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOIn13_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case "I/O输入测试通道14":
                                CheckBox_ZhengIOIn14.Checked = true;
                                switch ((peizhiInfoData[11] & 0x0C) >> 2)
                                {
                                    case 0x01:
                                        radioButton_ZhengIOIn14b_C.Checked = true;
                                        skinCheckBox_ZhengIOIn14.Checked = true;
                                        textBox_ZhengIOIn14_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOIn14_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOIn14b_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOIn14b_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOIn14_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengIOIn14_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengIOIn14_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOIn14_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x02:
                                        radioButton_ZhengIOIn14b_C.Checked = true;
                                        textBox_ZhengIOIn14_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOIn14_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOIn14b_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOIn14b_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOIn14_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOIn14_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x03:
                                        radioButton_ZhengIOIn14a_C.Checked = true;
                                        textBox_ZhengIOIn14_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOIn14_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOIn14_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOIn14_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOIn14_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOIn14_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case "I/O输入测试通道15":
                                CheckBox_ZhengIOIn15.Checked = true;
                                switch ((peizhiInfoData[11] & 0x30) >> 4)
                                {
                                    case 0x01:
                                        radioButton_ZhengIOIn15b_C.Checked = true;
                                        skinCheckBox_ZhengIOIn15.Checked = true;
                                        textBox_ZhengIOIn15_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOIn15_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOIn15b_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOIn15b_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOIn15_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengIOIn15_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengIOIn15_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOIn15_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x02:
                                        radioButton_ZhengIOIn15b_C.Checked = true;
                                        textBox_ZhengIOIn15_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOIn15_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOIn15b_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOIn15b_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOIn15_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOIn15_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x03:
                                        radioButton_ZhengIOIn15a_C.Checked = true;
                                        textBox_ZhengIOIn15_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOIn15_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOIn15_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOIn15_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOIn15_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOIn15_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case "I/O输入测试通道16":
                                CheckBox_ZhengIOIn16.Checked = true;
                                switch ((peizhiInfoData[11] & 0xC0) >> 6)
                                {
                                    case 0x01:
                                        radioButton_ZhengIOIn16b_C.Checked = true;
                                        skinCheckBox_ZhengIOIn16.Checked = true;
                                        textBox_ZhengIOIn16_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOIn16_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOIn16b_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOIn16b_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOIn16_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengIOIn16_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengIOIn16_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOIn16_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x02:
                                        radioButton_ZhengIOIn16b_C.Checked = true;
                                        textBox_ZhengIOIn16_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOIn16_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOIn16b_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOIn16b_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOIn16_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOIn16_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x03:
                                        radioButton_ZhengIOIn16a_C.Checked = true;
                                        textBox_ZhengIOIn16_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOIn16_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOIn16_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOIn16_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOIn16_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOIn16_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case "I/O输入测试通道17":
                                CheckBox_ZhengIOIn17.Checked = true;
                                switch (peizhiInfoData[12] & 0x03)
                                {
                                    case 0x01:
                                        radioButton_ZhengIOIn17b_C.Checked = true;
                                        skinCheckBox_ZhengIOIn17.Checked = true;
                                        textBox_ZhengIOIn17_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOIn17_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOIn17b_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOIn17b_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOIn17_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengIOIn17_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengIOIn17_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOIn17_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x02:
                                        radioButton_ZhengIOIn17b_C.Checked = true;
                                        textBox_ZhengIOIn17_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOIn17_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOIn17b_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOIn17b_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOIn17_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOIn17_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x03:
                                        radioButton_ZhengIOIn17a_C.Checked = true;
                                        textBox_ZhengIOIn17_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOIn17_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOIn17_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOIn17_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOIn17_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOIn17_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case "I/O输入测试通道18":
                                CheckBox_ZhengIOIn18.Checked = true;
                                switch ((peizhiInfoData[12] & 0x0C) >> 2)
                                {
                                    case 0x01:
                                        radioButton_ZhengIOIn18b_C.Checked = true;
                                        skinCheckBox_ZhengIOIn18.Checked = true;
                                        textBox_ZhengIOIn18_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOIn18_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOIn18b_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOIn18b_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOIn18_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengIOIn18_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengIOIn18_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOIn18_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x02:
                                        radioButton_ZhengIOIn18b_C.Checked = true;
                                        textBox_ZhengIOIn18_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOIn18_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOIn18b_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOIn18b_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOIn18_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOIn18_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x03:
                                        radioButton_ZhengIOIn18a_C.Checked = true;
                                        textBox_ZhengIOIn18_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOIn18_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOIn18_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOIn18_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOIn18_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOIn18_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case "I/O输入测试通道19":
                                CheckBox_ZhengIOIn19.Checked = true;
                                switch ((peizhiInfoData[12] & 0x30) >> 4)
                                {
                                    case 0x01:
                                        radioButton_ZhengIOIn19b_C.Checked = true;
                                        skinCheckBox_ZhengIOIn19.Checked = true;
                                        textBox_ZhengIOIn19_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOIn19_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOIn19b_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOIn19b_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOIn19_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengIOIn19_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengIOIn19_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOIn19_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x02:
                                        radioButton_ZhengIOIn19b_C.Checked = true;
                                        textBox_ZhengIOIn19_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOIn19_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOIn19b_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOIn19b_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOIn19_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOIn19_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x03:
                                        radioButton_ZhengIOIn19a_C.Checked = true;
                                        textBox_ZhengIOIn19_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOIn19_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOIn19_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOIn19_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOIn19_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOIn19_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case "I/O输入测试通道20":
                                CheckBox_ZhengIOIn20.Checked = true;
                                switch ((peizhiInfoData[12] & 0xC0) >> 6)
                                {
                                    case 0x01:
                                        radioButton_ZhengIOIn20b_C.Checked = true;
                                        skinCheckBox_ZhengIOIn20.Checked = true;
                                        textBox_ZhengIOIn20_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOIn20_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOIn20b_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOIn20b_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOIn20_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengIOIn20_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengIOIn20_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOIn20_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x02:
                                        radioButton_ZhengIOIn20b_C.Checked = true;
                                        textBox_ZhengIOIn20_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOIn20_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOIn20b_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOIn20b_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOIn20_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOIn20_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x03:
                                        radioButton_ZhengIOIn20a_C.Checked = true;
                                        textBox_ZhengIOIn20_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOIn20_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOIn20_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOIn20_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOIn20_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOIn20_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case "I/O输入测试通道21":
                                CheckBox_ZhengIOIn21.Checked = true;
                                switch (peizhiInfoData[13] & 0x03)
                                {
                                    case 0x01:
                                        radioButton_ZhengIOIn21b_C.Checked = true;
                                        skinCheckBox_ZhengIOIn21.Checked = true;
                                        textBox_ZhengIOIn21_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOIn21_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOIn21b_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOIn21b_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOIn21_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengIOIn21_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengIOIn21_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOIn21_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x02:
                                        radioButton_ZhengIOIn21b_C.Checked = true;
                                        textBox_ZhengIOIn21_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOIn21_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOIn21b_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOIn21b_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOIn21_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOIn21_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x03:
                                        radioButton_ZhengIOIn21a_C.Checked = true;
                                        textBox_ZhengIOIn21_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOIn21_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOIn21_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOIn21_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOIn21_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOIn21_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case "I/O输入测试通道22":
                                CheckBox_ZhengIOIn22.Checked = true;
                                switch ((peizhiInfoData[13] & 0x0C) >> 2)
                                {
                                    case 0x01:
                                        radioButton_ZhengIOIn22b_C.Checked = true;
                                        skinCheckBox_ZhengIOIn22.Checked = true;
                                        textBox_ZhengIOIn22_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOIn22_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOIn22b_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOIn22b_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOIn22_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengIOIn22_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengIOIn22_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOIn22_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x02:
                                        radioButton_ZhengIOIn22b_C.Checked = true;
                                        textBox_ZhengIOIn22_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOIn22_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOIn22b_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOIn22b_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOIn22_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOIn22_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x03:
                                        radioButton_ZhengIOIn22a_C.Checked = true;
                                        textBox_ZhengIOIn22_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOIn22_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOIn22_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOIn22_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOIn22_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOIn22_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case "I/O输入测试通道23":
                                CheckBox_ZhengIOIn23.Checked = true;
                                switch ((peizhiInfoData[13] & 0x30) >> 4)
                                {
                                    case 0x01:
                                        radioButton_ZhengIOIn23b_C.Checked = true;
                                        skinCheckBox_ZhengIOIn23.Checked = true;
                                        textBox_ZhengIOIn23_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOIn23_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOIn23b_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOIn23b_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOIn23_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengIOIn23_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengIOIn23_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOIn23_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x02:
                                        radioButton_ZhengIOIn23b_C.Checked = true;
                                        textBox_ZhengIOIn23_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOIn23_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOIn23b_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOIn23b_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOIn23_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOIn23_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x03:
                                        radioButton_ZhengIOIn23a_C.Checked = true;
                                        textBox_ZhengIOIn23_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOIn23_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOIn23_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOIn23_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOIn23_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOIn23_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case "I/O输入测试通道24":
                                CheckBox_ZhengIOIn24.Checked = true;
                                switch ((peizhiInfoData[13] & 0xC0) >> 6)
                                {
                                    case 0x01:
                                        radioButton_ZhengIOIn24b_C.Checked = true;
                                        skinCheckBox_ZhengIOIn24.Checked = true;
                                        textBox_ZhengIOIn24_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOIn24_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOIn24b_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOIn24b_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOIn24_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengIOIn24_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengIOIn24_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOIn24_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x02:
                                        radioButton_ZhengIOIn24b_C.Checked = true;
                                        textBox_ZhengIOIn24_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOIn24_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOIn24b_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOIn24b_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOIn24_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOIn24_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x03:
                                        radioButton_ZhengIOIn24a_C.Checked = true;
                                        textBox_ZhengIOIn24_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOIn24_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOIn24_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOIn24_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOIn24_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOIn24_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case "I/O输入测试通道25":
                                CheckBox_ZhengIOIn25.Checked = true;
                                switch (peizhiInfoData[14] & 0x03)
                                {
                                    case 0x01:
                                        radioButton_ZhengIOIn25b_C.Checked = true;
                                        skinCheckBox_ZhengIOIn25.Checked = true;
                                        textBox_ZhengIOIn25_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOIn25_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOIn25b_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOIn25b_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOIn25_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengIOIn25_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengIOIn25_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOIn25_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x02:
                                        radioButton_ZhengIOIn25b_C.Checked = true;
                                        textBox_ZhengIOIn25_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOIn25_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOIn25b_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOIn25b_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOIn25_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOIn25_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x03:
                                        radioButton_ZhengIOIn25a_C.Checked = true;
                                        textBox_ZhengIOIn25_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOIn25_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOIn25_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOIn25_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOIn25_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOIn25_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case "I/O输入测试通道26":
                                CheckBox_ZhengIOIn26.Checked = true;
                                switch ((peizhiInfoData[14] & 0x0C) >> 2)
                                {
                                    case 0x01:
                                        radioButton_ZhengIOIn26b_C.Checked = true;
                                        skinCheckBox_ZhengIOIn26.Checked = true;
                                        textBox_ZhengIOIn26_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOIn26_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOIn26b_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOIn26b_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOIn26_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengIOIn26_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengIOIn26_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOIn26_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x02:
                                        radioButton_ZhengIOIn26b_C.Checked = true;
                                        textBox_ZhengIOIn26_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOIn26_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOIn26b_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOIn26b_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOIn26_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOIn26_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x03:
                                        radioButton_ZhengIOIn26a_C.Checked = true;
                                        textBox_ZhengIOIn26_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengIOIn26_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengIOIn26_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengIOIn26_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengIOIn26_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengIOIn26_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case "DA输出测试通道1":
                                CheckBox_ZhengDA1.Checked = true;
                                switch ((peizhiInfoData[14] & 0x30) >> 4)
                                {
                                    case 0x01:
                                        skinCheckBox_ZhengDA1.Checked = true;
                                        textBox_ZhengDA1_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengDA1_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengDA1_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengDA1_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengDA1_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengDA1_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengDA1_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengDA1_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x02:
                                        textBox_ZhengDA1_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengDA1_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengDA1_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengDA1_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case "DA输出测试通道2":
                                CheckBox_ZhengDA2.Checked = true;
                                switch ((peizhiInfoData[14] & 0xC0) >> 6)
                                {
                                    case 0x01:
                                        skinCheckBox_ZhengDA2.Checked = true;
                                        textBox_ZhengDA2_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengDA2_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengDA2_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengDA2_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengDA2_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengDA2_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengDA2_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengDA2_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x02:
                                        textBox_ZhengDA2_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengDA2_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengDA2_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengDA2_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case "DA输出测试通道3":
                                CheckBox_ZhengDA3.Checked = true;
                                switch (peizhiInfoData[15] & 0x03)
                                {
                                    case 0x01:
                                        skinCheckBox_ZhengDA3.Checked = true;
                                        textBox_ZhengDA3_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengDA3_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengDA3_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengDA3_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengDA3_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengDA3_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengDA3_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengDA3_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x02:
                                        textBox_ZhengDA3_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengDA3_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengDA3_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengDA3_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case "DA输出测试通道4":
                                CheckBox_ZhengDA4.Checked = true;
                                switch ((peizhiInfoData[15] & 0x0C) >> 2)
                                {
                                    case 0x01:
                                        skinCheckBox_ZhengDA4.Checked = true;
                                        textBox_ZhengDA4_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengDA4_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengDA4_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengDA4_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengDA4_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengDA4_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengDA4_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengDA4_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x02:
                                        textBox_ZhengDA4_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengDA4_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengDA4_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengDA4_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case "DA输出测试通道5":
                                CheckBox_ZhengDA5.Checked = true;
                                switch ((peizhiInfoData[15] & 0x30) >> 4)
                                {
                                    case 0x01:
                                        skinCheckBox_ZhengDA5.Checked = true;
                                        textBox_ZhengDA5_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengDA5_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengDA5_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengDA5_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengDA5_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengDA5_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengDA5_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengDA5_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x02:
                                        textBox_ZhengDA5_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengDA5_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengDA5_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengDA5_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case "DA输出测试通道6":
                                CheckBox_ZhengDA6.Checked = true;
                                switch ((peizhiInfoData[15] & 0xC0) >> 6)
                                {
                                    case 0x01:
                                        skinCheckBox_ZhengDA6.Checked = true;
                                        textBox_ZhengDA6_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengDA6_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengDA6_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengDA6_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengDA6_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengDA6_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengDA6_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengDA6_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x02:
                                        textBox_ZhengDA6_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengDA6_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengDA6_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengDA6_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case "DA输出测试通道7":
                                CheckBox_ZhengDA7.Checked = true;
                                switch (peizhiInfoData[16] & 0x03)
                                {
                                    case 0x01:
                                        skinCheckBox_ZhengDA7.Checked = true;
                                        textBox_ZhengDA7_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengDA7_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengDA7_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengDA7_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengDA7_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengDA7_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengDA7_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengDA7_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x02:
                                        textBox_ZhengDA7_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengDA7_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengDA7_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengDA7_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case "DA输出测试通道8":
                                CheckBox_ZhengDA8.Checked = true;
                                switch ((peizhiInfoData[16] & 0x0C) >> 2)
                                {
                                    case 0x01:
                                        skinCheckBox_ZhengDA8.Checked = true;
                                        textBox_ZhengDA8_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengDA8_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengDA8_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengDA8_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengDA8_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengDA8_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengDA8_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengDA8_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x02:
                                        textBox_ZhengDA8_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengDA8_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengDA8_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengDA8_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case "AD输入测试通道1":
                                CheckBox_ZhengAD1.Checked = true;
                                switch ((peizhiInfoData[16] & 0x30) >> 4)
                                {
                                    case 0x01:
                                        skinCheckBox_ZhengAD1.Checked = true;
                                        textBox_ZhengAD1_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengAD1_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengAD1_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengAD1_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengAD1_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengAD1_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengAD1_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengAD1_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x02:
                                        textBox_ZhengAD1_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengAD1_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengAD1_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengAD1_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengAD1_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengAD1_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                }
                                break;
                            case "AD输入测试通道2":
                                CheckBox_ZhengAD2.Checked = true;
                                switch ((peizhiInfoData[16] & 0xC0) >> 6)
                                {
                                    case 0x01:
                                        skinCheckBox_ZhengAD2.Checked = true;
                                        textBox_ZhengAD2_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengAD2_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengAD2_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengAD2_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengAD2_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengAD2_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengAD2_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengAD2_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x02:
                                        textBox_ZhengAD2_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengAD2_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengAD2_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengAD2_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengAD2_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengAD2_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                }
                                break;
                            case "AD输入测试通道3":
                                CheckBox_ZhengAD3.Checked = true;
                                switch (peizhiInfoData[17] & 0x03)
                                {
                                    case 0x01:
                                        skinCheckBox_ZhengAD3.Checked = true;
                                        textBox_ZhengAD3_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengAD3_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengAD3_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengAD3_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengAD3_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengAD3_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengAD3_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengAD3_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x02:
                                        textBox_ZhengAD3_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengAD3_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengAD3_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengAD3_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengAD3_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengAD3_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                }
                                break;
                            case "AD输入测试通道4":
                                CheckBox_ZhengAD4.Checked = true;
                                switch ((peizhiInfoData[17] & 0x0C) >> 2)
                                {
                                    case 0x01:
                                        skinCheckBox_ZhengAD4.Checked = true;
                                        textBox_ZhengAD4_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengAD4_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengAD4_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengAD4_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengAD4_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengAD4_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengAD4_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengAD4_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x02:
                                        textBox_ZhengAD4_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengAD4_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengAD4_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengAD4_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengAD4_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengAD4_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                }
                                break;
                            case "AD输入测试通道5":
                                CheckBox_ZhengAD5.Checked = true;
                                switch ((peizhiInfoData[17] & 0x30) >> 4)
                                {
                                    case 0x01:
                                        skinCheckBox_ZhengAD5.Checked = true;
                                        textBox_ZhengAD5_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengAD5_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengAD5_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengAD5_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengAD5_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengAD5_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengAD5_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengAD5_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x02:
                                        textBox_ZhengAD5_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengAD5_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengAD5_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengAD5_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengAD5_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengAD5_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                }
                                break;
                            case "AD输入测试通道6":
                                CheckBox_ZhengAD6.Checked = true;
                                switch ((peizhiInfoData[17] & 0xC0) >> 6)
                                {
                                    case 0x01:
                                        skinCheckBox_ZhengAD6.Checked = true;
                                        textBox_ZhengAD6_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengAD6_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengAD6_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengAD6_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengAD6_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengAD6_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengAD6_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengAD6_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x02:
                                        textBox_ZhengAD6_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengAD6_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengAD6_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengAD6_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengAD6_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengAD6_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                }
                                break;
                            case "AD输入测试通道7":
                                CheckBox_ZhengAD7.Checked = true;
                                switch (peizhiInfoData[18] & 0x03)
                                {
                                    case 0x01:
                                        skinCheckBox_ZhengAD7.Checked = true;
                                        textBox_ZhengAD7_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengAD7_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengAD7_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengAD7_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengAD7_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengAD7_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengAD7_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengAD7_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x02:
                                        textBox_ZhengAD7_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengAD7_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengAD7_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengAD7_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengAD7_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengAD7_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                }
                                break;
                            case "AD输入测试通道8":
                                CheckBox_ZhengAD8.Checked = true;
                                switch ((peizhiInfoData[18] & 0x0C) >> 2)
                                {
                                    case 0x01:
                                        skinCheckBox_ZhengAD8.Checked = true;
                                        textBox_ZhengAD8_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengAD8_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengAD8_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengAD8_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengAD8_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengAD8_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengAD8_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengAD8_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x02:
                                        textBox_ZhengAD8_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengAD8_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengAD8_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengAD8_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengAD8_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengAD8_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                }
                                break;
                            case "AD输入测试通道9":
                                CheckBox_ZhengAD9.Checked = true;
                                switch ((peizhiInfoData[18] & 0x30) >> 4)
                                {
                                    case 0x01:
                                        skinCheckBox_ZhengAD9.Checked = true;
                                        textBox_ZhengAD9_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengAD9_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengAD9_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengAD9_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengAD9_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengAD9_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengAD9_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengAD9_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x02:
                                        textBox_ZhengAD9_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengAD9_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengAD9_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengAD9_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengAD9_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengAD9_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                }
                                break;
                            case "AD输入测试通道10":
                                CheckBox_ZhengAD10.Checked = true;
                                switch ((peizhiInfoData[18] & 0xC0) >> 6)
                                {
                                    case 0x01:
                                        skinCheckBox_ZhengAD10.Checked = true;
                                        textBox_ZhengAD10_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengAD10_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengAD10_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengAD10_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengAD10_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengAD10_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengAD10_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengAD10_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x02:
                                        textBox_ZhengAD10_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengAD10_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengAD10_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengAD10_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengAD10_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengAD10_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                }
                                break;
                            case "AD输入测试通道11":
                                CheckBox_ZhengAD11.Checked = true;
                                switch (peizhiInfoData[19] & 0x03)
                                {
                                    case 0x01:
                                        skinCheckBox_ZhengAD11.Checked = true;
                                        textBox_ZhengAD11_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengAD11_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengAD11_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengAD11_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengAD11_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengAD11_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengAD11_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengAD11_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x02:
                                        textBox_ZhengAD11_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengAD11_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengAD11_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengAD11_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengAD11_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengAD11_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                }
                                break;
                            case "AD输入测试通道12":
                                CheckBox_ZhengAD12.Checked = true;
                                switch ((peizhiInfoData[19] & 0x0C) >> 2)
                                {
                                    case 0x01:
                                        skinCheckBox_ZhengAD12.Checked = true;
                                        textBox_ZhengAD12_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengAD12_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengAD12_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengAD12_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengAD12_Test.Text = checkListfuction1.Rows[h][5].ToString();
                                        textBox_ZhengAD12_Ref2.Text = checkListfuction1.Rows[h][6].ToString();
                                        textBox_ZhengAD12_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengAD12_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                    case 0x02:
                                        textBox_ZhengAD12_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                        textBox_ZhengAD12_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                        textBox_ZhengAD12_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                        textBox_ZhengAD12_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                        textBox_ZhengAD12_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                        textBox_ZhengAD12_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                        break;
                                }
                                break;
                            case "AD输入测试通道13":
                                CheckBox_ZhengAD13.Checked = true;
                                textBox_ZhengAD13_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                textBox_ZhengAD13_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                textBox_ZhengAD13_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                textBox_ZhengAD13_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                textBox_ZhengAD13_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                textBox_ZhengAD13_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                break;
                            case "AD输入测试通道14":
                                CheckBox_ZhengAD14.Checked = true;
                                textBox_ZhengAD14_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                textBox_ZhengAD14_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                textBox_ZhengAD14_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                textBox_ZhengAD14_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                textBox_ZhengAD14_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                textBox_ZhengAD14_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                break;
                            case "AD输入测试通道15":
                                CheckBox_ZhengAD15.Checked = true;
                                textBox_ZhengAD15_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                textBox_ZhengAD15_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                textBox_ZhengAD15_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                textBox_ZhengAD15_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                textBox_ZhengAD15_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                textBox_ZhengAD15_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                break;
                            case "AD输入测试通道16":
                                CheckBox_ZhengAD16.Checked = true;
                                textBox_ZhengAD16_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                textBox_ZhengAD16_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                textBox_ZhengAD16_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                textBox_ZhengAD16_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                textBox_ZhengAD16_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                textBox_ZhengAD16_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                break;
                            case "AD输入测试通道17":
                                CheckBox_ZhengAD17.Checked = true;
                                textBox_ZhengAD17_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                textBox_ZhengAD17_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                textBox_ZhengAD17_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                textBox_ZhengAD17_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                textBox_ZhengAD17_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                textBox_ZhengAD17_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                break;
                            case "AD输入测试通道18":
                                CheckBox_ZhengAD18.Checked = true;
                                textBox_ZhengAD18_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                textBox_ZhengAD18_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                textBox_ZhengAD18_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                textBox_ZhengAD18_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                textBox_ZhengAD18_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                textBox_ZhengAD18_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                break;
                            case "AD输入测试通道19":
                                CheckBox_ZhengAD19.Checked = true;
                                textBox_ZhengAD19_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                textBox_ZhengAD19_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                textBox_ZhengAD19_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                textBox_ZhengAD19_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                textBox_ZhengAD19_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                textBox_ZhengAD19_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                break;
                            case "AD输入测试通道20":
                                CheckBox_ZhengAD20.Checked = true;
                                textBox_ZhengAD20_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                textBox_ZhengAD20_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                textBox_ZhengAD20_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                textBox_ZhengAD20_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                textBox_ZhengAD20_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                textBox_ZhengAD20_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                break;
                            case "AD输入测试通道21":
                                CheckBox_ZhengAD21.Checked = true;
                                textBox_ZhengAD21_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                textBox_ZhengAD21_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                textBox_ZhengAD21_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                textBox_ZhengAD21_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                textBox_ZhengAD21_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                textBox_ZhengAD21_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                break;
                            case "AD输入测试通道22":
                                CheckBox_ZhengAD22.Checked = true;
                                textBox_ZhengAD22_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                textBox_ZhengAD22_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                textBox_ZhengAD22_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                textBox_ZhengAD22_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                textBox_ZhengAD22_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                textBox_ZhengAD22_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                break;
                            case "AD输入测试通道23":
                                CheckBox_ZhengAD23.Checked = true;
                                textBox_ZhengAD23_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                textBox_ZhengAD23_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                textBox_ZhengAD23_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                textBox_ZhengAD23_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                textBox_ZhengAD23_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                textBox_ZhengAD23_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                break;
                            case "AD输入测试通道24":
                                CheckBox_ZhengAD24.Checked = true;
                                textBox_ZhengAD24_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                textBox_ZhengAD24_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                textBox_ZhengAD24_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                textBox_ZhengAD24_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                textBox_ZhengAD24_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                textBox_ZhengAD24_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                break;
                            case "AD输入测试通道25":
                                CheckBox_ZhengAD25.Checked = true;
                                textBox_ZhengAD25_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                textBox_ZhengAD25_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                textBox_ZhengAD25_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                textBox_ZhengAD25_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                textBox_ZhengAD25_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                textBox_ZhengAD25_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                break;
                            case "AD输入测试通道26":
                                CheckBox_ZhengAD26.Checked = true;
                                textBox_ZhengAD26_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                textBox_ZhengAD26_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                textBox_ZhengAD26_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                textBox_ZhengAD26_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                textBox_ZhengAD26_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                textBox_ZhengAD26_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                break;
                            case "AD输入测试通道27":
                                CheckBox_ZhengAD27.Checked = true;
                                textBox_ZhengAD27_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                textBox_ZhengAD27_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                textBox_ZhengAD27_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                textBox_ZhengAD27_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                textBox_ZhengAD27_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                textBox_ZhengAD27_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                break;
                            case "AD输入测试通道28":
                                CheckBox_ZhengAD28.Checked = true;
                                textBox_ZhengAD28_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                textBox_ZhengAD28_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                textBox_ZhengAD28_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                textBox_ZhengAD28_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                textBox_ZhengAD28_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                textBox_ZhengAD28_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                break;
                            case "AD输入测试通道29":
                                CheckBox_ZhengAD29.Checked = true;
                                textBox_ZhengAD29_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                textBox_ZhengAD29_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                textBox_ZhengAD29_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                textBox_ZhengAD29_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                textBox_ZhengAD29_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                textBox_ZhengAD29_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                break;
                            case "AD输入测试通道30":
                                CheckBox_ZhengAD30.Checked = true;
                                textBox_ZhengAD30_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                textBox_ZhengAD30_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                textBox_ZhengAD30_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                textBox_ZhengAD30_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                textBox_ZhengAD30_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                textBox_ZhengAD30_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                break;
                            case "AD输入测试通道31":
                                CheckBox_ZhengAD31.Checked = true;
                                textBox_ZhengAD31_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                textBox_ZhengAD31_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                textBox_ZhengAD31_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                textBox_ZhengAD31_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                textBox_ZhengAD31_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                textBox_ZhengAD31_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                break;
                            case "AD输入测试通道32":
                                CheckBox_ZhengAD32.Checked = true;
                                textBox_ZhengAD32_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                textBox_ZhengAD32_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                textBox_ZhengAD32_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                textBox_ZhengAD32_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                textBox_ZhengAD32_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                textBox_ZhengAD32_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                break;
                            case "AD输入测试通道33":
                                CheckBox_ZhengAD33.Checked = true;
                                textBox_ZhengAD33_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                textBox_ZhengAD33_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                textBox_ZhengAD33_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                textBox_ZhengAD33_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                textBox_ZhengAD33_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                textBox_ZhengAD33_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                break;
                            case "AD输入测试通道34":
                                CheckBox_ZhengAD34.Checked = true;
                                textBox_ZhengAD34_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                textBox_ZhengAD34_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                textBox_ZhengAD34_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                textBox_ZhengAD34_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                textBox_ZhengAD34_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                textBox_ZhengAD34_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                break;
                            case "AD输入测试通道35":
                                CheckBox_ZhengAD35.Checked = true;
                                textBox_ZhengAD35_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                textBox_ZhengAD35_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                textBox_ZhengAD35_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                textBox_ZhengAD35_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                textBox_ZhengAD35_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                textBox_ZhengAD35_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                break;
                            case "AD输入测试通道36":
                                CheckBox_ZhengAD36.Checked = true;
                                textBox_ZhengAD36_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                textBox_ZhengAD36_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                textBox_ZhengAD36_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                textBox_ZhengAD36_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                textBox_ZhengAD36_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                textBox_ZhengAD36_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                break;
                            case "AD输入测试通道37":
                                CheckBox_ZhengAD37.Checked = true;
                                textBox_ZhengAD37_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                textBox_ZhengAD37_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                textBox_ZhengAD37_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                textBox_ZhengAD37_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                textBox_ZhengAD37_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                textBox_ZhengAD37_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                break;
                            case "AD输入测试通道38":
                                CheckBox_ZhengAD38.Checked = true;
                                textBox_ZhengAD38_IN.Text = checkListfuction1.Rows[h][1].ToString();
                                textBox_ZhengAD38_Ref1.Text = checkListfuction1.Rows[h][2].ToString();
                                textBox_ZhengAD38_VIn1.Text = checkListfuction1.Rows[h][3].ToString();
                                textBox_ZhengAD38_VIn2.Text = checkListfuction1.Rows[h][4].ToString();
                                textBox_ZhengAD38_Value1.Text = checkListfuction1.Rows[h][7].ToString();
                                textBox_ZhengAD38_Value2.Text = checkListfuction1.Rows[h][8].ToString();
                                break;
                            default:
                                break;
                        }
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

        //替换标题名称
        private void replaceTitle()
        {
            String x = "";
            switch (whichform)
            {
                case "Gonglv":
                    x = "功率板";
                    break;
                case "Kongzhi":
                    x = "控制板";
                    break;
                case "Zonghe":
                    x = "综合板";
                    break;
                case "Zuhe":
                    x = "组合板";
                    break;
                case "Zhengji":
                    x = "整机";
                    break;
                case "Laolian":
                    x = "老炼";
                    break;
            }
            Title.Text = Title.Text.Replace("xxx", x);
        }

    }       
}
