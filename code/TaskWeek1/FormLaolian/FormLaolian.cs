using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace TaskWeek1
{
    public partial class FormLaolian : Form
    {
        private FormPass formPassLaolian;
        private DataTable checkListShort1, checkListShort2, checkListShort3, checkListShort4, checkListVolt1, checkListVolt2, checkListVolt3, checkListVolt4, checkListfuction1, checkListfuction2, checkListfuction3, checkListfuction4;//虚拟表格——根据配置文件生成的，用来指导在线显示以及报表生成

        //老炼相关定义
        private DataTable checkListTime1, checkListTime2, checkListTime3, checkListTime4;
        private double testTime1, testTime2, testTime3, timeall,timeTemp;//+20V,+24V,+30V测试时间
        private double curTime, waitTime;//单位为秒，通电时间，断电时间
        private double curTime1,waitTime1;//单位为时
        private double[,]trailTable=new double[300,2];
        private double[] trailSecond;
        private int periodNum;
        private int jNum=0;//二位数组线索
        private int timeCount = 0;//数组一维计数
        private int periodflag = 0;
        private int periodcount = 0;  //统计当前老炼进入第几周期
        private int ErroFlag1 = 0, ErroFlag2 = 0, ErroFlag3 = 0, ErroFlag4 = 0;








        private List<string> note;//note指的是电路板测试时外加电压说明
        private int flag_Read=0, flag_Confirm=0;
        private int flag_InfoSendOK = 0, flag_StartSendOK = 0;//由主控板发送的配置信息接收成功标志；开始测试指令接收成功标志
        private int numShort;//配置文件里第3行-8行配置信息
        private int numVolt;
        private int numIOOut;
        private int numIOIn;
        private int numAD;
        private int numDA;
        private string[] peizhiInfoFull;
        private byte[] peizhiInfoData = new byte[27];//配置文件里第9行配置信息
        private byte flagTestNum = 0;
        private UInt16[] shortResult1 = new UInt16[9];
        private float[] voltResult1 = new float[9];
        private float[] IOOutResult1 = new float[16];
        private float[] IOInResult1 = new float[26];
        private float[] DAResult1 = new float[8];
        private float[] ADResult1 = new float[38];
        private float[] IOOutResult1a = new float[16];
        private float[] IOInResult1a = new float[26];
        private float[] DAResult1a = new float[8];
        private float[] ADResult1a = new float[38];
        private UInt16[] shortTheory1 = new UInt16[9];
        private float[] voltTheory1 = new float[9];
        private float[] IOOutTheory1 = new float[16];
        private float[] IOInTheory1 = new float[26];
        private float[] DATheory1 = new float[8];
        private float[] ADTheory1 = new float[38];
        private float[] IOOutTheory1a = new float[16];
        private float[] IOInTheory1a = new float[26];
        private float[] DATheory1a = new float[8];
        private float[] ADTheory1a = new float[38];
        private UInt16[] shortResult2 = new UInt16[9];
        private float[] voltResult2 = new float[9];
        private float[] IOOutResult2 = new float[16];
        private float[] IOInResult2 = new float[26];
        private float[] DAResult2 = new float[8];
        private float[] ADResult2 = new float[38];
        private float[] IOOutResult2a = new float[16];
        private float[] IOInResult2a = new float[26];
        private float[] DAResult2a = new float[8];
        private float[] ADResult2a = new float[38];
        private UInt16[] shortTheory2 = new UInt16[9];
        private float[] voltTheory2 = new float[9];
        private float[] IOOutTheory2 = new float[16];
        private float[] IOInTheory2 = new float[26];
        private float[] DATheory2 = new float[8];
        private float[] ADTheory2 = new float[38];
        private float[] IOOutTheory2a = new float[16];
        private float[] IOInTheory2a = new float[26];
        private float[] DATheory2a = new float[8];
        private float[] ADTheory2a = new float[38];
        private UInt16[] shortResult3 = new UInt16[9];
        private float[] voltResult3 = new float[9];
        private float[] IOOutResult3 = new float[16];
        private float[] IOInResult3 = new float[26];
        private float[] DAResult3 = new float[8];
        private float[] ADResult3 = new float[38];
        private float[] IOOutResult3a = new float[16];
        private float[] IOInResult3a = new float[26];
        private float[] DAResult3a = new float[8];
        private float[] ADResult3a = new float[38];
        private UInt16[] shortTheory3 = new UInt16[9];
        private float[] voltTheory3 = new float[9];
        private float[] IOOutTheory3 = new float[16];
        private float[] IOInTheory3 = new float[26];
        private float[] DATheory3 = new float[8];
        private float[] ADTheory3 = new float[38];
        private float[] IOOutTheory3a = new float[16];
        private float[] IOInTheory3a= new float[26];
        private float[] DATheory3a = new float[8];
        private float[] ADTheory3a = new float[38];
        private UInt16[] shortResult4 = new UInt16[9];
        private float[] voltResult4 = new float[9];
        private float[] IOOutResult4 = new float[16];
        private float[] IOInResult4 = new float[26];
        private float[] DAResult4 = new float[8];
        private float[] ADResult4 = new float[38];
        private float[] IOOutResult4a = new float[16];
        private float[] IOInResult4a = new float[26];
        private float[] DAResult4a = new float[8];
        private float[] ADResult4a = new float[38];
        private UInt16[] shortTheory4 = new UInt16[9];
        private float[] voltTheory4 = new float[9];
        private float[] IOOutTheory4 = new float[16];
        private float[] IOInTheory4 = new float[26];
        private float[] DATheory4 = new float[8];
        private float[] ADTheory4 = new float[38];
        private float[] IOOutTheory4a = new float[16];
        private float[] IOInTheory4a = new float[26];
        private float[] DATheory4a = new float[8];
        private float[] ADTheory4a = new float[38];     
        private UInt16 ShortMin = 50;
        private float VoltErroMin = 0.85f;
        private float VoltErroMax = 1.15f;
        private float IOOutErroMin = 0.5f;
        private float IOOutErroMax = 1.5f;
        private float IOOutOffset = 0.5f; //理论值为0时无法使用倍数，故用偏移量
        private float IOInErroMin = 0f;
        private float IOInErroMax = 0f;
        private float IOInOffset = 0f; //理论值为0时无法使用倍数，故用偏移量
        private float DAErroMin = 0.6f;
        private float DAErroMax = 1.4f;
        private float DAOffset = 0.8f; //理论值为0时无法使用倍数，故用偏移量
        private float ADErroMin = 0.8f;
        private float ADErroMax = 1.2f;

        private String formName = "Laolian"; //传来是具体哪种测试

        public FormLaolian()
        {
            InitializeComponent();
        }
        #region-读入资源配置文件-
        private void button_读入配置文件_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "D:\\";
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileStream filest = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.ReadWrite);
                    StreamReader checkIn = new StreamReader(filest);
                    string fileFlag = checkIn.ReadLine();
                    if (fileFlag != "Laolian")
                    {
                        MessageBox.Show("配置文件错误，请重新配置");
                        return;
                    }

                    rowMergeView1_Short.DataSource = null;
                    rowMergeView1_Short.Refresh();
                    rowMergeView1_Volt.DataSource = null;
                    rowMergeView1_Volt.Refresh();
                    rowMergeView1_Fuction.DataSource = null;
                    rowMergeView1_Fuction.Refresh();

                    rowMergeView2_Short.DataSource = null;
                    rowMergeView2_Short.Refresh();
                    rowMergeView2_Volt.DataSource = null;
                    rowMergeView2_Volt.Refresh();
                    rowMergeView2_Fuction.DataSource = null;
                    rowMergeView2_Fuction.Refresh(); 

                    rowMergeView3_Short.DataSource = null;
                    rowMergeView3_Short.Refresh();
                    rowMergeView3_Volt.DataSource = null;
                    rowMergeView3_Volt.Refresh();
                    rowMergeView3_Fuction.DataSource = null;
                    rowMergeView3_Fuction.Refresh();

                    rowMergeView4_Short.DataSource = null;
                    rowMergeView4_Short.Refresh();
                    rowMergeView4_Volt.DataSource = null;
                    rowMergeView4_Volt.Refresh();
                    rowMergeView4_Fuction.DataSource = null;
                    rowMergeView4_Fuction.Refresh();
                   
                    string fileTime = checkIn.ReadLine();
                    
                    numShort = int.Parse(checkIn.ReadLine());
                    numVolt = int.Parse(checkIn.ReadLine());
                    numIOOut = int.Parse(checkIn.ReadLine());
                    numIOIn = int.Parse(checkIn.ReadLine());
                    numDA = int.Parse(checkIn.ReadLine());
                    numAD = int.Parse(checkIn.ReadLine());
                    string peizhiInfo = checkIn.ReadLine();
                    
             
                    peizhiInfoFull = peizhiInfo.Split(';');//数组peizhiInfoFull包含需要发送到下位机的配置资源全部信息
                    
                   for (int i = 0; i <= 26; i++)//数组peizhiInfoFull数组中的二进制字符串转化为byte数组
                   {
                      peizhiInfoData[i] = Convert.ToByte(peizhiInfoFull[i], 2);
                   }
                    if ((peizhiInfoData[0] & 0x03) == 0)
                       ovalShortShape1.FillColor=Color.Aqua;
                    else
                       ovalShortShape1.FillColor = Color.Lime;
                    if ((peizhiInfoData[0] & 0x0C) == 0)
                        ovalShortShape2.FillColor = Color.Aqua;
                    else
                        ovalShortShape2.FillColor = Color.Lime;
                    if ((peizhiInfoData[0] & 0x30) == 0)
                        ovalShortShape3.FillColor = Color.Aqua;
                    else
                        ovalShortShape3.FillColor = Color.Lime;
                    if ((peizhiInfoData[0] & 0xC0) == 0)
                        ovalShortShape4.FillColor = Color.Aqua;
                    else
                        ovalShortShape4.FillColor = Color.Lime;

                    if ((peizhiInfoData[1] & 0x03) == 0)
                        ovalShortShape5.FillColor = Color.Aqua;
                    else
                        ovalShortShape5.FillColor = Color.Lime;
                    if ((peizhiInfoData[1] & 0x0C) == 0)
                        ovalShortShape6.FillColor = Color.Aqua;
                    else
                        ovalShortShape6.FillColor = Color.Lime;
                    if ((peizhiInfoData[1] & 0x30) == 0)
                        ovalShortShape7.FillColor = Color.Aqua;
                    else
                        ovalShortShape7.FillColor = Color.Lime;
                    if ((peizhiInfoData[1] & 0xC0) == 0)
                        ovalShortShape8.FillColor = Color.Aqua;
                    else
                        ovalShortShape8.FillColor = Color.Lime;

                    if ((peizhiInfoData[2] & 0x03) == 0)
                        ovalVoltShape1.FillColor = Color.Aqua;
                    else
                        ovalVoltShape1.FillColor = Color.Lime;
                    if ((peizhiInfoData[2] & 0x0C) == 0)
                        ovalVoltShape2.FillColor = Color.Aqua;
                    else
                        ovalVoltShape2.FillColor = Color.Lime;
                    if ((peizhiInfoData[2] & 0x30) == 0)
                        ovalVoltShape3.FillColor = Color.Aqua;
                    else
                        ovalVoltShape3.FillColor = Color.Lime;
                    if ((peizhiInfoData[2] & 0xC0) == 0)
                        ovalVoltShape4.FillColor = Color.Aqua;
                    else
                        ovalVoltShape4.FillColor = Color.Lime;

                    if ((peizhiInfoData[3] & 0x03) == 0)
                        ovalVoltShape5.FillColor = Color.Aqua;
                    else
                        ovalVoltShape5.FillColor = Color.Lime;
                    if ((peizhiInfoData[3] & 0x0C) == 0)
                        ovalVoltShape6.FillColor = Color.Aqua;
                    else
                        ovalVoltShape6.FillColor = Color.Lime;
                    if ((peizhiInfoData[3] & 0x30) == 0)
                        ovalVoltShape7.FillColor = Color.Aqua;
                    else
                        ovalVoltShape7.FillColor = Color.Lime;
                    if ((peizhiInfoData[3] & 0xC0) == 0)
                        ovalVoltShape8.FillColor = Color.Aqua;
                    else
                        ovalVoltShape8.FillColor = Color.Lime;

                    if ((peizhiInfoData[4] & 0x03) == 0)
                        ovalIOOutShape1.FillColor = Color.Aqua;
                    else
                        ovalIOOutShape1.FillColor = Color.Lime;
                    if ((peizhiInfoData[4] & 0x0C) == 0)
                        ovalIOOutShape2.FillColor = Color.Aqua;
                    else
                        ovalIOOutShape2.FillColor = Color.Lime;
                    if ((peizhiInfoData[4] & 0x30) == 0)
                        ovalIOOutShape3.FillColor = Color.Aqua;
                    else
                        ovalIOOutShape3.FillColor = Color.Lime;
                    if ((peizhiInfoData[4] & 0xC0) == 0)
                        ovalIOOutShape4.FillColor = Color.Aqua;
                    else
                        ovalIOOutShape4.FillColor = Color.Lime;

                    if ((peizhiInfoData[5] & 0x03) == 0)
                        ovalIOOutShape5.FillColor = Color.Aqua;
                    else
                        ovalIOOutShape5.FillColor = Color.Lime;
                    if ((peizhiInfoData[5] & 0x0C) == 0)
                        ovalIOOutShape6.FillColor = Color.Aqua;
                    else
                        ovalIOOutShape6.FillColor = Color.Lime;
                    if ((peizhiInfoData[5] & 0x30) == 0)
                        ovalIOOutShape7.FillColor = Color.Aqua;
                    else
                        ovalIOOutShape7.FillColor = Color.Lime;
                    if ((peizhiInfoData[5] & 0xC0) == 0)
                        ovalIOOutShape8.FillColor = Color.Aqua;
                    else
                        ovalIOOutShape8.FillColor = Color.Lime;

                    if ((peizhiInfoData[6] & 0x03) == 0)
                        ovalIOOutShape9.FillColor = Color.Aqua;
                    else
                        ovalIOOutShape9.FillColor = Color.Lime;
                    if ((peizhiInfoData[6] & 0x0C) == 0)
                        ovalIOOutShape10.FillColor = Color.Aqua;
                    else
                        ovalIOOutShape10.FillColor = Color.Lime;
                    if ((peizhiInfoData[6] & 0x30) == 0)
                        ovalIOOutShape11.FillColor = Color.Aqua;
                    else
                        ovalIOOutShape11.FillColor = Color.Lime;
                    if ((peizhiInfoData[6] & 0xC0) == 0)
                        ovalIOOutShape12.FillColor = Color.Aqua;
                    else
                        ovalIOOutShape12.FillColor = Color.Lime;

                    if ((peizhiInfoData[7] & 0x03) == 0)
                        ovalIOOutShape13.FillColor = Color.Aqua;
                    else
                        ovalIOOutShape13.FillColor = Color.Lime;
                    if ((peizhiInfoData[7] & 0x0C) == 0)
                        ovalIOOutShape14.FillColor = Color.Aqua;
                    else
                        ovalIOOutShape14.FillColor = Color.Lime;
                    if ((peizhiInfoData[7] & 0x30) == 0)
                        ovalIOOutShape15.FillColor = Color.Aqua;
                    else
                        ovalIOOutShape15.FillColor = Color.Lime;
                    if ((peizhiInfoData[7] & 0xC0) == 0)
                        ovalIOOutShape16.FillColor = Color.Aqua;
                    else
                        ovalIOOutShape16.FillColor = Color.Lime;

                    if ((peizhiInfoData[8] & 0x03) == 0)
                        ovalIOInShape1.FillColor = Color.Aqua;
                    else
                        ovalIOInShape1.FillColor = Color.Lime;
                    if ((peizhiInfoData[8] & 0x0C) == 0)
                        ovalIOInShape2.FillColor = Color.Aqua;
                    else
                        ovalIOInShape2.FillColor = Color.Lime;
                    if ((peizhiInfoData[8] & 0x30) == 0)
                        ovalIOInShape3.FillColor = Color.Aqua;
                    else
                        ovalIOInShape3.FillColor = Color.Lime;
                    if ((peizhiInfoData[8] & 0xC0) == 0)
                        ovalIOInShape4.FillColor = Color.Aqua;
                    else
                        ovalIOInShape4.FillColor = Color.Lime;

                    if ((peizhiInfoData[9] & 0x03) == 0)
                        ovalIOInShape5.FillColor = Color.Aqua;
                    else
                        ovalIOInShape5.FillColor = Color.Lime;
                    if ((peizhiInfoData[9] & 0x0C) == 0)
                        ovalIOInShape6.FillColor = Color.Aqua;
                    else
                        ovalIOInShape6.FillColor = Color.Lime;
                    if ((peizhiInfoData[9] & 0x30) == 0)
                        ovalIOInShape7.FillColor = Color.Aqua;
                    else
                        ovalIOInShape7.FillColor = Color.Lime;
                    if ((peizhiInfoData[9] & 0xC0) == 0)
                        ovalIOInShape8.FillColor = Color.Aqua;
                    else
                        ovalIOInShape8.FillColor = Color.Lime;

                    if ((peizhiInfoData[10] & 0x03) == 0)
                        ovalIOInShape9.FillColor = Color.Aqua;
                    else
                        ovalIOInShape9.FillColor = Color.Lime;
                    if ((peizhiInfoData[10] & 0x0C) == 0)
                        ovalIOInShape10.FillColor = Color.Aqua;
                    else
                        ovalIOInShape10.FillColor = Color.Lime;
                    if ((peizhiInfoData[10] & 0x30) == 0)
                        ovalIOInShape11.FillColor = Color.Aqua;
                    else
                        ovalIOInShape11.FillColor = Color.Lime;
                    if ((peizhiInfoData[10] & 0xC0) == 0)
                        ovalIOInShape12.FillColor = Color.Aqua;
                    else
                        ovalIOInShape12.FillColor = Color.Lime;

                    if ((peizhiInfoData[11] & 0x03) == 0)
                        ovalIOInShape13.FillColor = Color.Aqua;
                    else
                        ovalIOInShape13.FillColor = Color.Lime;
                    if ((peizhiInfoData[11] & 0x0C) == 0)
                        ovalIOInShape14.FillColor = Color.Aqua;
                    else
                        ovalIOInShape14.FillColor = Color.Lime;
                    if ((peizhiInfoData[11] & 0x30) == 0)
                        ovalIOInShape15.FillColor = Color.Aqua;
                    else
                        ovalIOInShape15.FillColor = Color.Lime;
                    if ((peizhiInfoData[11] & 0xC0) == 0)
                        ovalIOInShape16.FillColor = Color.Aqua;
                    else
                        ovalIOInShape16.FillColor = Color.Lime;

                    if ((peizhiInfoData[12] & 0x03) == 0)
                        ovalIOInShape17.FillColor = Color.Aqua;
                    else
                        ovalIOInShape17.FillColor = Color.Lime;
                    if ((peizhiInfoData[12] & 0x0C) == 0)
                        ovalIOInShape18.FillColor = Color.Aqua;
                    else
                        ovalIOInShape18.FillColor = Color.Lime;
                    if ((peizhiInfoData[12] & 0x30) == 0)
                        ovalIOInShape19.FillColor = Color.Aqua;
                    else
                        ovalIOInShape19.FillColor = Color.Lime;
                    if ((peizhiInfoData[12] & 0xC0) == 0)
                        ovalIOInShape20.FillColor = Color.Aqua;
                    else
                        ovalIOInShape20.FillColor = Color.Lime;

                    if ((peizhiInfoData[13] & 0x03) == 0)
                        ovalIOInShape21.FillColor = Color.Aqua;
                    else
                        ovalIOInShape21.FillColor = Color.Lime;
                    if ((peizhiInfoData[13] & 0x0C) == 0)
                        ovalIOInShape22.FillColor = Color.Aqua;
                    else
                        ovalIOInShape22.FillColor = Color.Lime;
                    if ((peizhiInfoData[13] & 0x30) == 0)
                        ovalIOInShape23.FillColor = Color.Aqua;
                    else
                        ovalIOInShape23.FillColor = Color.Lime;
                    if ((peizhiInfoData[13] & 0xC0) == 0)
                        ovalIOInShape24.FillColor = Color.Aqua;
                    else
                        ovalIOInShape24.FillColor = Color.Lime;

                    if ((peizhiInfoData[14] & 0x03) == 0)
                        ovalIOInShape25.FillColor = Color.Aqua;
                    else
                        ovalIOInShape25.FillColor = Color.Lime;
                    if ((peizhiInfoData[14] & 0x0C) == 0)
                        ovalIOInShape26.FillColor = Color.Aqua;
                    else
                        ovalIOInShape26.FillColor = Color.Lime;
                    if ((peizhiInfoData[14] & 0x30) == 0)
                        ovalDAShape1.FillColor = Color.Aqua;
                    else
                        ovalDAShape1.FillColor = Color.Lime;
                    if ((peizhiInfoData[14] & 0xC0) == 0)
                        ovalDAShape2.FillColor = Color.Aqua;
                    else
                        ovalDAShape2.FillColor = Color.Lime;

                    if ((peizhiInfoData[15] & 0x03) == 0)
                        ovalDAShape3.FillColor = Color.Aqua;
                    else
                        ovalDAShape3.FillColor = Color.Lime;
                    if ((peizhiInfoData[15] & 0x0C) == 0)
                        ovalDAShape4.FillColor = Color.Aqua;
                    else
                        ovalDAShape4.FillColor = Color.Lime;
                    if ((peizhiInfoData[15] & 0x30) == 0)
                        ovalDAShape5.FillColor = Color.Aqua;
                    else
                        ovalDAShape5.FillColor = Color.Lime;
                    if ((peizhiInfoData[15] & 0xC0) == 0)
                        ovalDAShape6.FillColor = Color.Aqua;
                    else
                        ovalDAShape6.FillColor = Color.Lime;

                    if ((peizhiInfoData[16] & 0x03) == 0)
                        ovalDAShape7.FillColor = Color.Aqua;
                    else
                        ovalDAShape7.FillColor = Color.Lime;
                    if ((peizhiInfoData[16] & 0x0C) == 0)
                        ovalDAShape8.FillColor = Color.Aqua;
                    else
                        ovalDAShape8.FillColor = Color.Lime;
                    if ((peizhiInfoData[16] & 0x30) == 0)
                        ovalADShape1.FillColor = Color.Aqua;
                    else
                        ovalADShape1.FillColor = Color.Lime;
                    if ((peizhiInfoData[16] & 0xC0) == 0)
                        ovalADShape2.FillColor = Color.Aqua;
                    else
                        ovalADShape2.FillColor = Color.Lime;

                    if ((peizhiInfoData[17] & 0x03) == 0)
                        ovalADShape3.FillColor = Color.Aqua;
                    else
                        ovalADShape3.FillColor = Color.Lime;
                    if ((peizhiInfoData[17] & 0x0C) == 0)
                        ovalADShape4.FillColor = Color.Aqua;
                    else
                        ovalADShape4.FillColor = Color.Lime;
                    if ((peizhiInfoData[17] & 0x30) == 0)
                        ovalADShape5.FillColor = Color.Aqua;
                    else
                        ovalADShape5.FillColor = Color.Lime;
                    if ((peizhiInfoData[17] & 0xC0) == 0)
                        ovalADShape6.FillColor = Color.Aqua;
                    else
                        ovalADShape6.FillColor = Color.Lime;

                    if ((peizhiInfoData[18] & 0x03) == 0)
                        ovalADShape7.FillColor = Color.Aqua;
                    else
                        ovalADShape7.FillColor = Color.Lime;
                    if ((peizhiInfoData[18] & 0x0C) == 0)
                        ovalADShape8.FillColor = Color.Aqua;
                    else
                        ovalADShape8.FillColor = Color.Lime;
                    if ((peizhiInfoData[18] & 0x30) == 0)
                        ovalADShape9.FillColor = Color.Aqua;
                    else
                        ovalADShape9.FillColor = Color.Lime;
                    if ((peizhiInfoData[18] & 0xC0) == 0)
                        ovalADShape10.FillColor = Color.Aqua;
                    else
                        ovalADShape10.FillColor = Color.Lime;

                    if ((peizhiInfoData[19] & 0x03) == 0)
                        ovalADShape11.FillColor = Color.Aqua;
                    else
                        ovalADShape11.FillColor = Color.Lime;
                    if ((peizhiInfoData[19] & 0x0C) == 0)
                        ovalADShape12.FillColor = Color.Aqua;
                    else
                        ovalADShape12.FillColor = Color.Lime;
                    if ((peizhiInfoData[19] & 0x30) == 0)
                        ovalADShape13.FillColor = Color.Aqua;
                    else
                        ovalADShape13.FillColor = Color.Lime;
                    if ((peizhiInfoData[19] & 0xC0) == 0)
                        ovalADShape14.FillColor = Color.Aqua;
                    else
                        ovalADShape14.FillColor = Color.Lime;

                    if ((peizhiInfoData[20] & 0x03) == 0)
                        ovalADShape15.FillColor = Color.Aqua;
                    else
                        ovalADShape15.FillColor = Color.Lime;
                    if ((peizhiInfoData[20] & 0x0C) == 0)
                        ovalADShape16.FillColor = Color.Aqua;
                    else
                        ovalADShape16.FillColor = Color.Lime;
                    if ((peizhiInfoData[20] & 0x30) == 0)
                        ovalADShape17.FillColor = Color.Aqua;
                    else
                        ovalADShape17.FillColor = Color.Lime;
                    if ((peizhiInfoData[20] & 0xC0) == 0)
                        ovalADShape18.FillColor = Color.Aqua;
                    else
                        ovalADShape18.FillColor = Color.Lime;

                    if ((peizhiInfoData[21] & 0x03) == 0)
                        ovalADShape19.FillColor = Color.Aqua;
                    else
                        ovalADShape19.FillColor = Color.Lime;
                    if ((peizhiInfoData[21] & 0x0C) == 0)
                        ovalADShape20.FillColor = Color.Aqua;
                    else
                        ovalADShape20.FillColor = Color.Lime;
                    if ((peizhiInfoData[21] & 0x30) == 0)
                        ovalADShape21.FillColor = Color.Aqua;
                    else
                        ovalADShape21.FillColor = Color.Lime;
                    if ((peizhiInfoData[21] & 0xC0) == 0)
                        ovalADShape22.FillColor = Color.Aqua;
                    else
                        ovalADShape22.FillColor = Color.Lime;

                    if ((peizhiInfoData[22] & 0x03) == 0)
                        ovalADShape23.FillColor = Color.Aqua;
                    else
                        ovalADShape23.FillColor = Color.Lime;
                    if ((peizhiInfoData[22] & 0x0C) == 0)
                        ovalADShape24.FillColor = Color.Aqua;
                    else
                        ovalADShape24.FillColor = Color.Lime;
                    if ((peizhiInfoData[22] & 0x30) == 0)
                        ovalADShape25.FillColor = Color.Aqua;
                    else
                        ovalADShape25.FillColor = Color.Lime;
                    if ((peizhiInfoData[22] & 0xC0) == 0)
                        ovalADShape26.FillColor = Color.Aqua;
                    else
                        ovalADShape26.FillColor = Color.Lime;

                    if ((peizhiInfoData[23] & 0x03) == 0)
                        ovalADShape27.FillColor = Color.Aqua;
                    else
                        ovalADShape27.FillColor = Color.Lime;
                    if ((peizhiInfoData[23] & 0x0C) == 0)
                        ovalADShape28.FillColor = Color.Aqua;
                    else
                        ovalADShape28.FillColor = Color.Lime;
                    if ((peizhiInfoData[23] & 0x30) == 0)
                        ovalADShape29.FillColor = Color.Aqua;
                    else
                        ovalADShape29.FillColor = Color.Lime;
                    if ((peizhiInfoData[23] & 0xC0) == 0)
                        ovalADShape30.FillColor = Color.Aqua;
                    else
                        ovalADShape30.FillColor = Color.Lime;

                    if ((peizhiInfoData[24] & 0x03) == 0)
                        ovalADShape31.FillColor = Color.Aqua;
                    else
                        ovalADShape31.FillColor = Color.Lime;
                    if ((peizhiInfoData[24] & 0x0C) == 0)
                        ovalADShape32.FillColor = Color.Aqua;
                    else
                        ovalADShape32.FillColor = Color.Lime;
                    if ((peizhiInfoData[24] & 0x30) == 0)
                        ovalADShape33.FillColor = Color.Aqua;
                    else
                        ovalADShape33.FillColor = Color.Lime;
                    if ((peizhiInfoData[24] & 0xC0) == 0)
                        ovalADShape34.FillColor = Color.Aqua;
                    else
                        ovalADShape34.FillColor = Color.Lime;

                    if ((peizhiInfoData[25] & 0x03) == 0)
                        ovalADShape35.FillColor = Color.Aqua;
                    else
                        ovalADShape35.FillColor = Color.Lime;
                    if ((peizhiInfoData[25] & 0x0C) == 0)
                        ovalADShape36.FillColor = Color.Aqua;
                    else
                        ovalADShape36.FillColor = Color.Lime;
                    if ((peizhiInfoData[25] & 0x30) == 0)
                        ovalADShape37.FillColor = Color.Aqua;
                    else
                        ovalADShape37.FillColor = Color.Lime;
                    if ((peizhiInfoData[25] & 0xC0) == 0)
                        ovalADShape38.FillColor = Color.Aqua;
                    else
                        ovalADShape38.FillColor = Color.Lime;

                   


                    string peizhi = checkIn.ReadLine();//peizhi 一个字符串包含在线显示和Word报表信息
                    List<List<string>> peizhiList = new List<List<string>>();//将peizhi字符串中的信息分解到数组peizhiList中
                    checkListShort1 = new DataTable();//实例化
                    checkListShort2 = new DataTable();
                    checkListShort3 = new DataTable();
                    checkListShort4 = new DataTable();
                    checkListShort1.Columns.Add("周期");
                    checkListShort1.Columns.Add("资源测试通道");
                    checkListShort1.Columns.Add("测试点1");
                    checkListShort1.Columns.Add("测试点2");
                    checkListShort1.Columns.Add("理论值/Ω");
                    checkListShort1.Columns.Add("实测值/Ω");
                    checkListShort2.Columns.Add("周期");
                    checkListShort2.Columns.Add("资源测试通道");
                    checkListShort2.Columns.Add("测试点1");
                    checkListShort2.Columns.Add("测试点2");
                    checkListShort2.Columns.Add("理论值/Ω");
                    checkListShort2.Columns.Add("实测值/Ω");
                    checkListShort3.Columns.Add("周期");
                    checkListShort3.Columns.Add("资源测试通道");
                    checkListShort3.Columns.Add("测试点1");
                    checkListShort3.Columns.Add("测试点2");
                    checkListShort3.Columns.Add("理论值/Ω");
                    checkListShort3.Columns.Add("实测值/Ω");
                    checkListShort4.Columns.Add("周期");
                    checkListShort4.Columns.Add("资源测试通道");
                    checkListShort4.Columns.Add("测试点1");
                    checkListShort4.Columns.Add("测试点2");
                    checkListShort4.Columns.Add("理论值/Ω");
                    checkListShort4.Columns.Add("实测值/Ω");
                    
                    checkListVolt1 = new DataTable();
                    checkListVolt2 = new DataTable();
                    checkListVolt3 = new DataTable();
                    checkListVolt4 = new DataTable();
                    checkListVolt1.Columns.Add("周期");
                    checkListVolt1.Columns.Add("资源测试通道");
                    checkListVolt1.Columns.Add("测试点");
                    checkListVolt1.Columns.Add("基准点");
                    checkListVolt1.Columns.Add("理论值/V");
                    checkListVolt1.Columns.Add("实测值/V");
                    checkListVolt2.Columns.Add("周期");
                    checkListVolt2.Columns.Add("资源测试通道");
                    checkListVolt2.Columns.Add("测试点");
                    checkListVolt2.Columns.Add("基准点");
                    checkListVolt2.Columns.Add("理论值/V");
                    checkListVolt2.Columns.Add("实测值/V");
                    checkListVolt3.Columns.Add("周期");
                    checkListVolt3.Columns.Add("资源测试通道");
                    checkListVolt3.Columns.Add("测试点");
                    checkListVolt3.Columns.Add("基准点");
                    checkListVolt3.Columns.Add("理论值/V");
                    checkListVolt3.Columns.Add("实测值/V");
                    checkListVolt4.Columns.Add("周期");
                    checkListVolt4.Columns.Add("资源测试通道");
                    checkListVolt4.Columns.Add("测试点");
                    checkListVolt4.Columns.Add("基准点");
                    checkListVolt4.Columns.Add("理论值/V");
                    checkListVolt4.Columns.Add("实测值/V");
                    
                    checkListfuction1 = new DataTable();
                    checkListfuction2 = new DataTable();
                    checkListfuction3 = new DataTable();
                    checkListfuction4 = new DataTable();
                    checkListfuction1.Columns.Add("周期");
                    checkListfuction1.Columns.Add("资源测试通道");
                    checkListfuction1.Columns.Add("输入点");
                    checkListfuction1.Columns.Add("基准点1");
                    checkListfuction1.Columns.Add("输入电压");
                    checkListfuction1.Columns.Add("测试点");
                    checkListfuction1.Columns.Add("基准点2");
                    checkListfuction1.Columns.Add("理论值/V");
                    checkListfuction1.Columns.Add("实测值/V");
                    checkListfuction2.Columns.Add("周期");
                    checkListfuction2.Columns.Add("资源测试通道");
                    checkListfuction2.Columns.Add("输入点");
                    checkListfuction2.Columns.Add("基准点1");
                    checkListfuction2.Columns.Add("输入电压");
                    checkListfuction2.Columns.Add("测试点");
                    checkListfuction2.Columns.Add("基准点2");
                    checkListfuction2.Columns.Add("理论值/V");
                    checkListfuction2.Columns.Add("实测值/V");
                    checkListfuction3.Columns.Add("周期");
                    checkListfuction3.Columns.Add("资源测试通道");
                    checkListfuction3.Columns.Add("输入点");
                    checkListfuction3.Columns.Add("基准点1");
                    checkListfuction3.Columns.Add("输入电压");
                    checkListfuction3.Columns.Add("测试点");
                    checkListfuction3.Columns.Add("基准点2");
                    checkListfuction3.Columns.Add("理论值/V");
                    checkListfuction3.Columns.Add("实测值/V");
                    checkListfuction4.Columns.Add("周期");
                    checkListfuction4.Columns.Add("资源测试通道");
                    checkListfuction4.Columns.Add("输入点");
                    checkListfuction4.Columns.Add("基准点1");
                    checkListfuction4.Columns.Add("输入电压");
                    checkListfuction4.Columns.Add("测试点");
                    checkListfuction4.Columns.Add("基准点2");
                    checkListfuction4.Columns.Add("理论值/V");
                    checkListfuction4.Columns.Add("实测值/V");
                    
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
                    if (numShort != 0)
                    {
                        for (int j = 1; j <= numShort; j++)
                        { 
                            List<string> peizhiListItem = peizhiList[j];
                            DataRow newRow = checkListShort1.NewRow();
                            newRow[0] = "周期1";
                            newRow[1] = peizhiListItem[0];
                            newRow[2] = peizhiListItem[1];
                            newRow[3] = peizhiListItem[2];
                            newRow[4] = peizhiListItem[3];
                            //思路：准备采用动态插入的办法，识别测试通道数，插入相应测试结果。如何识别通道数？识别“汉字字符”好了
                            checkListShort1.Rows.Add(newRow);
                            DataRow newRow1 = checkListShort2.NewRow();
                            newRow1[0] = "周期1";
                            newRow1[1] = peizhiListItem[0];
                            newRow1[2] = peizhiListItem[1];
                            newRow1[3] = peizhiListItem[2];
                            newRow1[4] = peizhiListItem[3];
                            checkListShort2.Rows.Add(newRow1);
                            DataRow newRow2 = checkListShort3.NewRow();
                            newRow2[0] = "周期1";
                            newRow2[1] = peizhiListItem[0];
                            newRow2[2] = peizhiListItem[1];
                            newRow2[3] = peizhiListItem[2];
                            newRow2[4] = peizhiListItem[3];
                            checkListShort3.Rows.Add(newRow2);
                            DataRow newRow3 = checkListShort4.NewRow();
                            newRow3[0] = "周期1";
                            newRow3[1] = peizhiListItem[0];
                            newRow3[2] = peizhiListItem[1];
                            newRow3[3] = peizhiListItem[2];
                            newRow3[4] = peizhiListItem[3];
                            checkListShort4.Rows.Add(newRow3);
                        }
                    }                  
                   if (numVolt != 0)
                   {
                       for (int k = numShort + 1; k <= (numShort+numVolt); k++)
                       {
                           List<string> peizhiListItem = peizhiList[k];
                           DataRow newRow = checkListVolt1.NewRow();
                           newRow[0] = "周期1";
                           newRow[1] = peizhiListItem[0];
                           newRow[2] = peizhiListItem[1];
                           newRow[3] = peizhiListItem[2];
                           newRow[4] = peizhiListItem[3];
                           //思路：准备采用动态插入的办法，识别测试通道数，插入相应测试结果。如何识别通道数？识别“汉字字符”好了
                           checkListVolt1.Rows.Add(newRow);
                           DataRow newRow1 = checkListVolt2.NewRow();
                           newRow1[0] = "周期1";
                           newRow1[1] = peizhiListItem[0];
                           newRow1[2] = peizhiListItem[1];
                           newRow1[3] = peizhiListItem[2];
                           newRow1[4] = peizhiListItem[3];
                           checkListVolt2.Rows.Add(newRow1);
                           DataRow newRow2 = checkListVolt3.NewRow();
                           newRow2[0] = "周期1";
                           newRow2[1] = peizhiListItem[0];
                           newRow2[2] = peizhiListItem[1];
                           newRow2[3] = peizhiListItem[2];
                           newRow2[4] = peizhiListItem[3];
                           checkListVolt3.Rows.Add(newRow);
                           DataRow newRow3 = checkListVolt4.NewRow();
                           newRow3[0] = "周期1";
                           newRow3[1] = peizhiListItem[0];
                           newRow3[2] = peizhiListItem[1];
                           newRow3[3] = peizhiListItem[2];
                           newRow3[4] = peizhiListItem[3];
                           checkListVolt4.Rows.Add(newRow3);
                       }
                        }
                   if ((numIOOut+numIOIn+numDA+numAD) != 0)
                   {
                       for (int h = numShort + numVolt + 1; h <= (numShort+numVolt+numIOOut + numIOIn + numDA + numAD); h++)
                       {
                           List<string> peizhiListItem = peizhiList[h];
                           DataRow newRow = checkListfuction1.NewRow();
                           newRow[0] = "周期1";
                           newRow[1] = peizhiListItem[0];
                           newRow[2] = peizhiListItem[1];
                           newRow[3] = peizhiListItem[2];
                           newRow[4] = peizhiListItem[3];
                           newRow[5] = peizhiListItem[5];
                           newRow[6] = peizhiListItem[6];
                           newRow[7] = peizhiListItem[7];
                           //思路：准备采用动态插入的办法，识别测试通道数，插入相应测试结果。如何识别通道数？识别“汉字字符”好了
                           checkListfuction1.Rows.Add(newRow);
                           newRow = checkListfuction1.NewRow();
                           newRow[0] = "周期1";
                           newRow[1] = peizhiListItem[0];
                           newRow[2] = peizhiListItem[1];
                           newRow[3] = peizhiListItem[2];
                           newRow[4] = peizhiListItem[4];
                           newRow[5] = peizhiListItem[5];
                           newRow[6] = peizhiListItem[6];
                           newRow[7] = peizhiListItem[8];
                           //思路：准备采用动态插入的办法，识别测试通道数，插入相应测试结果。如何识别通道数？识别“汉字字符”好了
                           checkListfuction1.Rows.Add(newRow);
                           DataRow newRow1 = checkListfuction2.NewRow();
                           newRow1[0] = "周期1";
                           newRow1[1] = peizhiListItem[0];
                           newRow1[2] = peizhiListItem[1];
                           newRow1[3] = peizhiListItem[2];
                           newRow1[4] = peizhiListItem[3];
                           newRow1[5] = peizhiListItem[5];
                           newRow1[6] = peizhiListItem[6];
                           newRow1[7] = peizhiListItem[7];
                           checkListfuction2.Rows.Add(newRow1);
                           newRow1 = checkListfuction2.NewRow();
                           newRow1[0] = "周期1";
                           newRow1[1] = peizhiListItem[0];
                           newRow1[2] = peizhiListItem[1];
                           newRow1[3] = peizhiListItem[2];
                           newRow1[4] = peizhiListItem[4];
                           newRow1[5] = peizhiListItem[5];
                           newRow1[6] = peizhiListItem[6];
                           newRow1[7] = peizhiListItem[8];
                           checkListfuction2.Rows.Add(newRow1);

                           DataRow newRow2 = checkListfuction3.NewRow();
                           newRow2[0] = "周期1";
                           newRow2[1] = peizhiListItem[0];
                           newRow2[2] = peizhiListItem[1];
                           newRow2[3] = peizhiListItem[2];
                           newRow2[4] = peizhiListItem[3];
                           newRow2[5] = peizhiListItem[5];
                           newRow2[6] = peizhiListItem[6];
                           newRow2[7] = peizhiListItem[7];
                           checkListfuction3.Rows.Add(newRow2);
                           newRow2 = checkListfuction3.NewRow();
                           newRow2[0] = "周期1";
                           newRow2[1] = peizhiListItem[0];
                           newRow2[2] = peizhiListItem[1];
                           newRow2[3] = peizhiListItem[2];
                           newRow2[4] = peizhiListItem[4];
                           newRow2[5] = peizhiListItem[5];
                           newRow2[6] = peizhiListItem[6];
                           newRow2[7] = peizhiListItem[8];
                           checkListfuction3.Rows.Add(newRow2);

                           DataRow newRow3 = checkListfuction4.NewRow();
                           newRow3[0] = "周期1";
                           newRow3[1] = peizhiListItem[0];
                           newRow3[2] = peizhiListItem[1];
                           newRow3[3] = peizhiListItem[2];
                           newRow3[4] = peizhiListItem[3];
                           newRow3[5] = peizhiListItem[5];
                           newRow3[6] = peizhiListItem[6];
                           newRow3[7] = peizhiListItem[7];
                           checkListfuction4.Rows.Add(newRow3);
                           newRow3 = checkListfuction4.NewRow();
                           newRow3[0] = "周期1";
                           newRow3[1] = peizhiListItem[0];
                           newRow3[2] = peizhiListItem[1];
                           newRow3[3] = peizhiListItem[2];
                           newRow3[4] = peizhiListItem[4];
                           newRow3[5] = peizhiListItem[5];
                           newRow3[6] = peizhiListItem[6];
                           newRow3[7] = peizhiListItem[8];
                           checkListfuction4.Rows.Add(newRow3);
                       }
                   }  
                    checkIn.Close();
                    filest.Close();
                    flag_Read = 1;
                    flag_Confirm = 0;
                    MessageBox.Show("配置文件读取完毕", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                catch (Exception)
                {
                    MessageBox.Show("文件打开错误", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion
        #region-生成Word报表
        private void GenerateWord(DataTable table1, DataTable table2,DataTable table3)
        {
            string savePath = null;
           
            saveFileDialog1.InitialDirectory = "D:\\";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                savePath = saveFileDialog1.FileName;
            }
            else
            {
                MessageBox.Show("保存文档请选择一个文件地址和文件名");
                return;
            }
            WordCreat word = new WordCreat();
            word.CreateNewDocument("C:\\Documents and Settings\\USER\\桌面\\TaskWeek2\\整机测试报表模板.docx");
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("周期");
            dt1.Columns.Add("资源测试通道");
            dt1.Columns.Add("测试点1");
            dt1.Columns.Add("测试点2");
            dt1.Columns.Add("理论值/Ω");
            dt1.Columns.Add("实测值/Ω");
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("周期");
            dt2.Columns.Add("资源测试通道");
            dt2.Columns.Add("测试点");
            dt2.Columns.Add("基准点");
            dt2.Columns.Add("理论值/V");
            dt2.Columns.Add("实测值/V");
            DataTable dt3 = new DataTable();
            dt3.Columns.Add("周期");
            dt3.Columns.Add("资源测试通道");
            dt3.Columns.Add("输入点");
            dt3.Columns.Add("基准点1");
            dt3.Columns.Add("输入电压/V");
            dt3.Columns.Add("测试点");
            dt3.Columns.Add("基准点2");
            dt3.Columns.Add("理论值/V");
            dt3.Columns.Add("实测值/V");
            word.InsertValue("time", DateTime.Now.ToString());
            for (int i = 0; i < table1.Rows.Count;i++)
            {
                DataRow newRow = dt1.NewRow();
                newRow[0] = table1.Rows[i][0];
                newRow[1] = table1.Rows[i][1];
                newRow[2] = table1.Rows[i][2];
                newRow[3] = table1.Rows[i][3];
                newRow[4] = table1.Rows[i][4];
                dt1.Rows.Add(newRow);
            }
            word.insertrow("Short", dt1);
            dt1.Clear();
            word.InsertValue("note", note[0]);
            for (int i = 0; i < table2.Rows.Count; i++)
            {
                DataRow newRow = dt2.NewRow();
                newRow[0] = table2.Rows[i][0];
                newRow[1] = table2.Rows[i][1];
                newRow[2] = table2.Rows[i][2];
                newRow[3] = table2.Rows[i][3];
                newRow[4] = table2.Rows[i][4];
                dt2.Rows.Add(newRow);
            }
            word.insertrow("Volt", dt2);
            dt2.Clear();
            for (int i = 0; i < table3.Rows.Count; i++)
            {
                string resouceName = table3.Rows[i][0].ToString();
                if (resouceName.Contains("I/O输出测试通道"))
                {
                    DataRow newRow = dt3.NewRow();
                    newRow[0] = table3.Rows[i][0];
                    newRow[1] = table3.Rows[i][1];
                    newRow[2] = table3.Rows[i][2];
                    newRow[3] = table3.Rows[i][3];
                    newRow[4] = table3.Rows[i][4];
                    newRow[5] = table3.Rows[i][5];
                    newRow[6] = table3.Rows[i][6];
                    newRow[7] = table3.Rows[i][7];
                    dt3.Rows.Add(newRow);
                }
            }
            word.insertrow("IOOut", dt3);
            dt3.Clear();
            for (int i = 0; i < table3.Rows.Count; i++)
            {
                string resouceName = table3.Rows[i][0].ToString();
                if (resouceName.Contains("I/O输入测试通道"))
                {
                    DataRow newRow = dt3.NewRow();
                    newRow[0] = table3.Rows[i][0];
                    newRow[1] = table3.Rows[i][1];
                    newRow[2] = table3.Rows[i][2];
                    newRow[3] = table3.Rows[i][3];
                    newRow[4] = table3.Rows[i][4];
                    newRow[5] = table3.Rows[i][5];
                    newRow[6] = table3.Rows[i][6];
                    newRow[7] = table3.Rows[i][7];
                    dt3.Rows.Add(newRow);
                }
            }
            word.insertrow("IOIn", dt3);
            dt3.Clear();
            for (int i = 0; i < table3.Rows.Count; i++)
            {
                string resouceName = table3.Rows[i][0].ToString();
                if (resouceName.Contains("DA输出测试通道"))
                {
                    DataRow newRow = dt3.NewRow();
                    newRow[0] = table3.Rows[i][0];
                    newRow[1] = table3.Rows[i][1];
                    newRow[2] = table3.Rows[i][2];
                    newRow[3] = table3.Rows[i][3];
                    newRow[4] = table3.Rows[i][4];
                    newRow[5] = table3.Rows[i][5];
                    newRow[6] = table3.Rows[i][6];
                    newRow[7] = table3.Rows[i][7];
                    dt3.Rows.Add(newRow);
                }
            }
            word.insertrow("DA", dt3);
            dt3.Clear();
            for (int i = 0; i < table3.Rows.Count; i++)
            {
                string resouceName = table3.Rows[i][0].ToString();
                if (resouceName.Contains("AD输入测试通道"))
                {
                    DataRow newRow = dt3.NewRow();
                    newRow[0] = table3.Rows[i][0];
                    newRow[1] = table3.Rows[i][1];
                    newRow[2] = table3.Rows[i][2];
                    newRow[3] = table3.Rows[i][3];
                    newRow[4] = table3.Rows[i][4];
                    newRow[5] = table3.Rows[i][5];
                    newRow[6] = table3.Rows[i][6];
                    newRow[7] = table3.Rows[i][7];
                    dt3.Rows.Add(newRow);
                }
            }
            word.insertrow("AD", dt3);
            dt3.Clear();
            
            word.SaveDocument(savePath);
        }

        private void GeneratePeriodWord(DataTable table1)
        {
            string savePath = null;
            string wordpath = null;
            string basicpath = null;

            saveFileDialog1.InitialDirectory = "D:\\";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                savePath = saveFileDialog1.FileName;
            }
            else
            {
                MessageBox.Show("保存文档请选择一个文件地址和文件名");
                return;
            }
            WordCreat word = new WordCreat();
            basicpath = System.AppDomain.CurrentDomain.BaseDirectory;
            wordpath = System.IO.Path.Combine(basicpath, "老炼测试报表示例.docx");
            word.CreateNewDocument(wordpath);
            DataTable dt0 = new DataTable();
            dt0.Columns.Add("测试周期");
            dt0.Columns.Add("老炼时间");
            dt0.Columns.Add("输入电压");
            dt0.Columns.Add("剩余时间");
            dt0.Columns.Add("测试结果");
            for (int i = 0; i < table1.Rows.Count-1; i++)
            {
                DataRow newRow = dt0.NewRow();
                newRow[0] = table1.Rows[i][0];
                newRow[1] = table1.Rows[i][2];
                newRow[2] = table1.Rows[i][1];
                newRow[3] = table1.Rows[i][3];
                newRow[4] = table1.Rows[i][4];
                dt0.Rows.Add(newRow);
            }

            word.InsertValue("time", DateTime.Now.ToString());
            word.insertperidword("period", dt0);
            word.SaveDocument(savePath);

        }
        #endregion
        private void button_报表1_Click(object sender, EventArgs e)
        {
            if ((flag_Read == 1) & (flag_Confirm == 1))
            { GeneratePeriodWord(checkListTime1); }
            if ((flag_Read == 1) & (flag_Confirm == 0))
            { MessageBox.Show("请先选择测试号", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            if (flag_Read == 0)
            { MessageBox.Show("请先读取测试资源配置文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void button_报表2_Click(object sender, EventArgs e)
        {
            if ((flag_Read == 1) & (flag_Confirm == 1))
            { GeneratePeriodWord(checkListTime1); }
            if ((flag_Read == 1) & (flag_Confirm == 0))
            { MessageBox.Show("请先选择测试号", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            if (flag_Read == 0)
            { MessageBox.Show("请先读取测试资源配置文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void button_报表3_Click(object sender, EventArgs e)
        {
            if ((flag_Read == 1) & (flag_Confirm == 1))
            { GeneratePeriodWord(checkListTime1); }
            if ((flag_Read == 1) & (flag_Confirm == 0))
            { MessageBox.Show("请先选择测试号", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            if (flag_Read == 0)
            { MessageBox.Show("请先读取测试资源配置文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void button_报表4_Click(object sender, EventArgs e)
        {
            if ((flag_Read == 1) & (flag_Confirm == 1))
            { GeneratePeriodWord(checkListTime1); }
            if ((flag_Read == 1) & (flag_Confirm == 0))
            { MessageBox.Show("请先选择测试号", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            if (flag_Read == 0)
            { MessageBox.Show("请先读取测试资源配置文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

       

        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_Transmit(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd, ref VCI_CAN_OBJ pSend, UInt32 Len);
        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_GetReceiveNum(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd);
        [DllImport("controlcan.dll", CharSet = CharSet.Ansi)]
        static extern UInt32 VCI_Receive(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd, IntPtr pReceive, UInt32 Len, Int32 WaitTime);
        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_CloseDevice(UInt32 DeviceType, UInt32 DeviceInd);

        private void FormLaoLian_Load(object sender, EventArgs e)
        {
            //FormZhengji_Load时打开can卡
            Can.CANConnectAndStart(timer_receive);
            skinTabControl1.SelectTab(1);
            skinTabControl2.SelectTab(1);
            skinTabControl2.SelectTab(2);
            skinTabControl2.SelectTab(3);
            skinTabControl2.SelectTab(0);
            skinTabControl1.SelectTab(0);
        }

        unsafe private void button_开始老炼键_Click(object sender, EventArgs e)
        {
            timeCount = 0;
            trailSecond = ExchangeTime(trailTable, jNum);

            flag_InfoSendOK = 0;
            if ((flag_Read == 1) & (flag_Confirm == 0))
            { MessageBox.Show("请先选择测试号", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            if (flag_Read == 0)
            { MessageBox.Show("请先读取测试资源配置资源文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            if ((flag_Read == 1) & (flag_Confirm == 1))
            {
                if (flag_InfoSendOK == 0)
                {
                    VCI_CAN_OBJ sendobj = new VCI_CAN_OBJ();//实例化sendobj
                    sendobj.SendType = 0;   //发送帧类型，=0时为正常发送，=1时为单次发送，=2时为自发自收，=3时为单次自发自收
                    sendobj.RemoteFlag = 0;
                    sendobj.ExternFlag = 1;
                    sendobj.DataLen = 8;

                    sendobj.ID = 0x10000500;
                    sendobj.Data[0] = peizhiInfoData[0];
                    sendobj.Data[1] = peizhiInfoData[1];
                    sendobj.Data[2] = peizhiInfoData[2];
                    sendobj.Data[3] = peizhiInfoData[3];
                    sendobj.Data[4] = peizhiInfoData[4];
                    sendobj.Data[5] = peizhiInfoData[5];
                    sendobj.Data[6] = peizhiInfoData[6];
                    sendobj.Data[7] = peizhiInfoData[7];
                    if (VCI_Transmit(Can.m_devtype, Can.m_devind, Can.m_canind, ref sendobj, 1) == 0)
                    {
                        MessageBox.Show("配置信息发送失败，请检查CAN是否正常", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    sendobj.ID = 0x10010500;
                    sendobj.Data[0] = peizhiInfoData[8];
                    sendobj.Data[1] = peizhiInfoData[9];
                    sendobj.Data[2] = peizhiInfoData[10];
                    sendobj.Data[3] = peizhiInfoData[11];
                    sendobj.Data[4] = peizhiInfoData[12];
                    sendobj.Data[5] = peizhiInfoData[13];
                    sendobj.Data[6] = peizhiInfoData[14];
                    sendobj.Data[7] = peizhiInfoData[15];
                    if (VCI_Transmit(Can.m_devtype, Can.m_devind, Can.m_canind, ref sendobj, 1) == 0)
                    {
                        MessageBox.Show("配置信息发送失败，请检查CAN是否正常", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    sendobj.ID = 0x10020500;
                    sendobj.Data[0] = peizhiInfoData[16];
                    sendobj.Data[1] = peizhiInfoData[17];
                    sendobj.Data[2] = peizhiInfoData[18];
                    sendobj.Data[3] = peizhiInfoData[19];
                    sendobj.Data[4] = peizhiInfoData[20];
                    sendobj.Data[5] = peizhiInfoData[21];
                    sendobj.Data[6] = peizhiInfoData[22];
                    sendobj.Data[7] = peizhiInfoData[23];
                    if (VCI_Transmit(Can.m_devtype, Can.m_devind, Can.m_canind, ref sendobj, 1) == 0)
                    {
                        MessageBox.Show("配置信息发送失败，请检查CAN是否正常", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    sendobj.ID = 0x10030500;
                    sendobj.Data[0] = peizhiInfoData[24];
                    sendobj.Data[1] = peizhiInfoData[25];
                    if (VCI_Transmit(Can.m_devtype, Can.m_devind, Can.m_canind, ref sendobj, 1) == 0)
                    {
                        MessageBox.Show("配置信息发送失败，请检查CAN是否正常", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                timer.Enabled = true;
            }
             
        }
        #region-CAN接收函数-
        unsafe private void timer_receive_Tick(object sender, EventArgs e)
        {
            UInt32 res = new UInt32();
            res = VCI_GetReceiveNum(Can.m_devtype, Can.m_devind, Can.m_canind);
            if (res == 0)
                return;
            UInt32 con_maxlen = 50;
            IntPtr pt = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(VCI_CAN_OBJ)) * (Int32)con_maxlen);
            res = VCI_Receive(Can.m_devtype, Can.m_devind, Can.m_canind, pt, con_maxlen, 100);
            for (UInt32 i = 0; i < res; i++)
            {
                VCI_CAN_OBJ obj = (VCI_CAN_OBJ)Marshal.PtrToStructure((IntPtr)((UInt32)pt + i * Marshal.SizeOf(typeof(VCI_CAN_OBJ))), typeof(VCI_CAN_OBJ));
                switch (obj.ID)
                {
                    case 0x10000005:     //  老炼主控板状态帧
                        switch (obj.Data[0] & 0x03)
                        {
                            case 0x00:
                                textBoxWorkSta1.Text = "待机";
                                break;
                            case 0x01:
                                textBoxWorkSta1.Text = "测试中";
                                break;
                            case 0x02:
                                textBoxWorkSta1.Text = "测试完成";
                                break;
                            case 0x03:
                                textBoxWorkSta1.Text = "故障";
                                break;
                            default:
                                textBoxWorkSta1.Text = "未定义";
                                break;
                        }
                        switch ((obj.Data[0] & 0x0C) >> 2)
                        {
                            case 0x00:
                                textBoxWorkSta2.Text = "待机";
                                break;
                            case 0x01:
                                textBoxWorkSta2.Text = "测试中";
                                break;
                            case 0x02:
                                textBoxWorkSta2.Text = "测试完成";
                                break;
                            case 0x03:
                                textBoxWorkSta2.Text = "故障";
                                break;
                            default:
                                textBoxWorkSta2.Text = "未定义";
                                break;
                        }
                        switch ((obj.Data[0] & 0x30) >> 4)
                        {
                            case 0x00:
                                textBoxWorkSta3.Text = "待机";
                                break;
                            case 0x01:
                                textBoxWorkSta3.Text = "测试中";
                                break;
                            case 0x02:
                                textBoxWorkSta3.Text = "测试完成";
                                break;
                            case 0x03:
                                textBoxWorkSta3.Text = "故障";
                                break;
                            default:
                                textBoxWorkSta3.Text = "未定义";
                                break;
                        }
                        switch ((obj.Data[0] & 0xC0) >> 6)
                        {
                            case 0x00:
                                textBoxWorkSta4.Text = "待机";
                                break;
                            case 0x01:
                                textBoxWorkSta4.Text = "测试中";
                                break;
                            case 0x02:
                                textBoxWorkSta4.Text = "测试完成";
                                break;
                            case 0x03:
                                textBoxWorkSta4.Text = "故障";
                                break;
                            default:
                                textBoxWorkSta4.Text = "未定义";
                                break;
                        }
                        switch (obj.Data[1])
                        {
                            case 0x00:
                                textBoxBuzhou.Text = "待机";
                                break;
                            case 0x01:
                                textBoxBuzhou.Text = "短路测试";
                                break;
                            case 0x02:
                                textBoxBuzhou.Text = "电压输出测试";
                                break;
                            case 0x03:
                                textBoxBuzhou.Text = "I/O输出测试";
                                break;
                            case 0x04:
                                textBoxBuzhou.Text = "I/O输入测试";
                                break;
                            case 0x05:
                                textBoxBuzhou.Text = "DA输出测试";
                                break;
                            case 0x06:
                                textBoxBuzhou.Text = "AD输入测试";
                                break;
                            default:
                                textBoxBuzhou.Text = "未定义";
                                break;
                        }
                       textBoxNum.Text = obj.Data[2].ToString();
                       
                        switch (obj.Data[6] & 0x03)                              //短路1故障灯
                       {
                           case 0x00:
                               pbshort1.Lightimage = Properties.Resources.greenlight;
                               pbshort1.Lightcolor = "green";
                               pbReturn1.Lightimage = Properties.Resources.greenlight;
                               pbReturn1.Lightcolor = "green";
                               break;
                           case 0x01:
                               pbshort1.Lightimage = Properties.Resources.redlight;
                               pbshort1.Lightcolor = "red";
                               pbReturn1.Lightimage = Properties.Resources.greenlight;
                               pbReturn1.Lightcolor = "green";
                               break;
                           case 0x02:
                               pbshort1.Lightimage = Properties.Resources.greenlight;
                               pbshort1.Lightcolor = "green";
                               pbReturn1.Lightimage = Properties.Resources.redlight;
                               pbReturn1.Lightcolor = "red";
                               break;
                           case 0x03:
                               pbshort1.Lightimage = Properties.Resources.redlight;
                               pbshort1.Lightcolor = "red";
                               pbReturn1.Lightimage = Properties.Resources.redlight;
                               pbReturn1.Lightcolor = "red";
                               break;
                           default:
                               break;
                       }
                       switch ((obj.Data[6] & 0x0C) >> 2)
                       {
                           case 0x00:
                               pbshort2.Lightimage = Properties.Resources.greenlight;
                               pbshort2.Lightcolor = "green";
                               pbReturn2.Lightimage = Properties.Resources.greenlight;
                               pbReturn2.Lightcolor = "green";
                               break;
                           case 0x01:
                               pbshort2.Lightimage = Properties.Resources.redlight;
                               pbshort2.Lightcolor = "red";
                               pbReturn2.Lightimage = Properties.Resources.greenlight;
                               pbReturn2.Lightcolor = "green";
                               break;
                           case 0x02:
                               pbshort2.Lightimage = Properties.Resources.greenlight;
                               pbshort2.Lightcolor = "green";
                               pbReturn2.Lightimage = Properties.Resources.redlight;
                               pbReturn2.Lightcolor = "red";
                               break;
                           case 0x03:
                               pbshort2.Lightimage = Properties.Resources.redlight;
                               pbshort2.Lightcolor = "red";
                               pbReturn2.Lightimage = Properties.Resources.redlight;
                               pbReturn2.Lightcolor = "red";
                               break;
                           default:
                               break;
                       }
                       switch ((obj.Data[6] & 0x30) >> 4)
                       {
                           case 0x00:
                               pbshort3.Lightimage = Properties.Resources.greenlight;
                               pbshort3.Lightcolor = "green";
                               pbReturn3.Lightimage = Properties.Resources.greenlight;
                               pbReturn3.Lightcolor = "green";
                               break;
                           case 0x01:
                               pbshort3.Lightimage = Properties.Resources.redlight;
                               pbshort3.Lightcolor = "red";
                               pbReturn3.Lightimage = Properties.Resources.greenlight;
                               pbReturn3.Lightcolor = "green";
                               break;
                           case 0x02:
                               pbshort3.Lightimage = Properties.Resources.greenlight;
                               pbshort3.Lightcolor = "green";
                               pbReturn3.Lightimage = Properties.Resources.redlight;
                               pbReturn3.Lightcolor = "red";
                               break;
                           case 0x03:
                               pbshort3.Lightimage = Properties.Resources.redlight;
                               pbshort3.Lightcolor = "red";
                               pbReturn3.Lightimage = Properties.Resources.redlight;
                               pbReturn3.Lightcolor = "red";
                               break;
                           default:
                               break;
                       }
                       switch ((obj.Data[6] & 0xC0) >> 6)
                       {
                           case 0x00:
                               pbshort4.Lightimage = Properties.Resources.greenlight;
                               pbshort4.Lightcolor = "green";
                               pbReturn4.Lightimage = Properties.Resources.greenlight;
                               pbReturn4.Lightcolor = "green";
                               break;
                           case 0x01:
                               pbshort4.Lightimage = Properties.Resources.redlight;
                               pbshort4.Lightcolor = "red";
                               pbReturn4.Lightimage = Properties.Resources.greenlight;
                               pbReturn4.Lightcolor = "green";
                               break;
                           case 0x02:
                               pbshort4.Lightimage = Properties.Resources.greenlight;
                               pbshort4.Lightcolor = "green";
                               pbReturn4.Lightimage = Properties.Resources.redlight;
                               pbReturn4.Lightcolor = "red";
                               break;
                           case 0x03:
                               pbshort4.Lightimage = Properties.Resources.redlight;
                               pbshort4.Lightcolor = "red";
                               pbReturn4.Lightimage = Properties.Resources.redlight;
                               pbReturn4.Lightcolor = "red";
                               break;
                           default:
                               break;
                       }

                       skinProgressBar1.Value = obj.Data[7];
                        break;
                        
                    case 0x10010005:     //  指令收到确认帧（由老炼主控板发送）
                        if (obj.Data[0] == 0x01)
                        { flag_InfoSendOK = 1; }
                        if (obj.Data[1] == 0x02)
                        { flag_StartSendOK = 1; }
                        break;
////////////////////////////////////////////////////////////////老炼1老炼1老炼1////////////////////////////////////////////////////////////////////////
                    case 0x10020105:     //  老炼1短路测试结果
                        if ((flagTestNum & 0x01) == 0x01)
                        {
                            if (obj.Data[6] != 0xff)
                            {
                                int groupName = obj.Data[6];
                                shortResult1[groupName * 3 + 0] = (UInt16)((UInt16)obj.Data[1] << 8 | obj.Data[0]);
                                shortResult1[groupName * 3 + 1] = (UInt16)((UInt16)obj.Data[3] << 8 | obj.Data[2]);
                                shortResult1[groupName * 3 + 2] = (UInt16)((UInt16)obj.Data[5] << 8 | obj.Data[4]);
                            }
                            if (obj.Data[6] == 0xff)
                            { //老炼1的短路测试结果发送完成，首先发送接收确认帧
                                VCI_CAN_OBJ sendobj = new VCI_CAN_OBJ();//实例化sendobj
                                sendobj.SendType = 0;   //发送帧类型，=0时为正常发送，=1时为单次发送，=2时为自发自收，=3时为单次自发自收
                                sendobj.RemoteFlag = 0;
                                sendobj.ExternFlag = 1;
                                sendobj.DataLen = 8;
                                sendobj.ID = 0x10050500;
                                sendobj.Data[0] = 0x01;
                                sendobj.Data[1] = 0x01;
                                if (VCI_Transmit(Can.m_devtype, Can.m_devind, Can.m_canind, ref sendobj, 1) == 0)
                                {
                                    MessageBox.Show("发送失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                // 然后便可以做checkListShort1的插入工作,以及判断
                                for (int h = 0 + periodcount * numShort; h < numShort + periodcount * numShort; h++)
                                {
                                    RowStyle.JudgeShort(rowMergeView1_Short, checkListShort1, shortResult1, h, 8, ShortMin);
                                }
                            }
                        }
                        break;
                    case 0x10030105:     //  老炼1电压输出测试结果
                         if ((flagTestNum & 0x01) == 0x01)
                        {
                            if (obj.Data[6] != 0xff)
                            {
                                int groupName = obj.Data[6];
                                voltResult1[groupName * 3 + 0] = ((Single)(UInt16)(((UInt16)obj.Data[1] << 8) | obj.Data[0])) / 100;
                                voltResult1[groupName * 3 + 1] = ((Single)(UInt16)(((UInt16)obj.Data[3] << 8) | obj.Data[2])) / 100;
                                voltResult1[groupName * 3 + 2] = ((Single)(UInt16)(((UInt16)obj.Data[5] << 8) | obj.Data[4])) / 100;
                            }
                            if (obj.Data[6] == 0xff)
                            { //老炼1的短路测试结果发送完成，首先发送接收确认帧
                                VCI_CAN_OBJ sendobj = new VCI_CAN_OBJ();//实例化sendobj
                                sendobj.SendType = 0;   //发送帧类型，=0时为正常发送，=1时为单次发送，=2时为自发自收，=3时为单次自发自收
                                sendobj.RemoteFlag = 0;
                                sendobj.ExternFlag = 1;
                                sendobj.DataLen = 8;
                                sendobj.ID = 0x10050500;
                                sendobj.Data[0] = 0x01;
                                sendobj.Data[1] = 0x02;
                                if (VCI_Transmit(Can.m_devtype, Can.m_devind, Can.m_canind, ref sendobj, 1) == 0)
                                {
                                    MessageBox.Show("发送失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                // 然后便可以做checkListVolt1的插入工作,以及判断
                                for (int h = 0 + periodcount * numVolt; h < numVolt + periodcount * numVolt; h++)
                                {
                                    RowStyle.JudgeVolt(rowMergeView1_Volt, checkListVolt1, voltResult1, h, 8, VoltErroMin, VoltErroMax);
                                }
                            }
                        }
                        break;
                    case 0x10040105:     //  老炼1I/O输出测试结果
                        if ((flagTestNum & 0x01) == 0x01)
                        {
                            if (obj.Data[6] != 0xff)
                            {
                                int groupName = obj.Data[6];
                                IOOutResult1[groupName] = ((Single)(UInt16)(((UInt16)obj.Data[1] << 8) | obj.Data[0])) / 100;
                                IOOutResult1a[groupName] = ((Single)(UInt16)(((UInt16)obj.Data[3] << 8) | obj.Data[2])) / 100;
                            }
                            if (obj.Data[6] == 0xff)
                            { //老炼1的I/O输入测试结果发送完成，首先发送接收确认帧
                                VCI_CAN_OBJ sendobj = new VCI_CAN_OBJ();//实例化sendobj
                                sendobj.SendType = 0;   //发送帧类型，=0时为正常发送，=1时为单次发送，=2时为自发自收，=3时为单次自发自收
                                sendobj.RemoteFlag = 0;
                                sendobj.ExternFlag = 1;
                                sendobj.DataLen = 8;
                                sendobj.ID = 0x10050500;
                                sendobj.Data[0] = 0x01;
                                sendobj.Data[1] = 0x03;
                                if (VCI_Transmit(Can.m_devtype, Can.m_devind, Can.m_canind, ref sendobj, 1) == 0)
                                {
                                    MessageBox.Show("发送失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                // 然后便可以做checkListfuction1的插入工作,以及判断
                                for (int h = 0 + periodcount * (numIOOut + numIOIn + numDA + numAD) * 2; h < numIOOut * 2 + periodcount * (numIOOut + numIOIn + numDA + numAD) * 2; h = h + 2)
                                {
                                    RowStyle.JudgeIOOut(rowMergeView1_Fuction, checkListfuction1, IOOutResult1, IOOutResult1a, h, 16, IOOutErroMin, IOOutErroMax, IOOutOffset, formName);
                                }
                            }
                        }
                        break;
                    case 0x10050105:     //  老炼1I/O输入测试结果（26）
                         if ((flagTestNum & 0x01) == 0x01)
                        {
                            if (obj.Data[6] != 0xff)
                            {
                                int groupName = obj.Data[6];
                                IOInResult1[groupName] = ((Single)(UInt16)(((UInt16)obj.Data[1] << 8) | obj.Data[0])) / 100;
                                IOInResult1a[groupName] = ((Single)(UInt16)(((UInt16)obj.Data[3] << 8) | obj.Data[2])) / 100;
                            }
                            if (obj.Data[6] == 0xff)
                            { //老炼1的I/O输入测试结果发送完成，首先发送接收确认帧
                                VCI_CAN_OBJ sendobj = new VCI_CAN_OBJ();//实例化sendobj
                                sendobj.SendType = 0;   //发送帧类型，=0时为正常发送，=1时为单次发送，=2时为自发自收，=3时为单次自发自收
                                sendobj.RemoteFlag = 0;
                                sendobj.ExternFlag = 1;
                                sendobj.DataLen = 8;
                                sendobj.ID = 0x10050500;
                                sendobj.Data[0] = 0x01;
                                sendobj.Data[1] = 0x04;
                                if (VCI_Transmit(Can.m_devtype, Can.m_devind, Can.m_canind, ref sendobj, 1) == 0)
                                {
                                    MessageBox.Show("发送失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                // 然后便可以做checkListfuction1的插入工作,以及判断
                                for (int h = numIOOut * 2 + periodcount * (numIOOut + numIOIn + numDA + numAD) * 2; h < (numIOOut + numIOIn) * 2 + periodcount * (numIOOut + numIOIn + numDA + numAD) * 2; h = h + 2)
                                {
                                    RowStyle.JudgeIOIn(rowMergeView1_Fuction, checkListfuction1, IOInResult1, IOOutResult1a, h, 26, IOInErroMin, IOInErroMax, IOInOffset, formName);
                                }
                            }
                        }
                        break;
                    case 0x10060105:     //  老炼1DA输出测试结果（8）
                          if ((flagTestNum & 0x01) == 0x01)
                        {
                            if (obj.Data[6] != 0xff)
                            {
                                int groupName = obj.Data[6];
                                DAResult1[groupName] = ((Single)(UInt16)(((UInt16)obj.Data[1] << 8) | obj.Data[0])) / 1000;
                                DAResult1a[groupName] = ((Single)(UInt16)(((UInt16)obj.Data[3] << 8) | obj.Data[2])) / 1000;
                            }
                            if (obj.Data[6] == 0xff)
                            { //老炼1的I/O输入测试结果发送完成，首先发送接收确认帧
                                VCI_CAN_OBJ sendobj = new VCI_CAN_OBJ();//实例化sendobj
                                sendobj.SendType = 0;   //发送帧类型，=0时为正常发送，=1时为单次发送，=2时为自发自收，=3时为单次自发自收
                                sendobj.RemoteFlag = 0;
                                sendobj.ExternFlag = 1;
                                sendobj.DataLen = 8;
                                sendobj.ID = 0x10050500;
                                sendobj.Data[0] = 0x01;
                                sendobj.Data[1] = 0x05;
                                if (VCI_Transmit(Can.m_devtype, Can.m_devind, Can.m_canind, ref sendobj, 1) == 0)
                                {
                                    MessageBox.Show("发送失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                // 然后便可以做checkListfuction1的插入工作,以及判断
                                for (int h = (numIOIn + numIOOut) * 2 + periodcount * (numIOOut + numIOIn + numDA + numAD) * 2; h < (numIOIn + numIOOut + numDA) * 2 + periodcount * (numIOOut + numIOIn + numDA + numAD) * 2; h = h + 2)
                                {
                                    RowStyle.JudgeDA(rowMergeView1_Fuction, checkListfuction1, DAResult1, DAResult1a, h, 8, DAErroMin, DAErroMax, DAOffset, formName);
                                }
                            }
                        }
                        break;
                    case 0x10070105:     //  老炼1AD输入测试结果（38）
                        if ((flagTestNum & 0x01) == 0x01)
                        {
                            if (obj.Data[6] != 0xff)
                            {
                                int groupName = obj.Data[6];
                                ADResult1[groupName] = ((Single)(UInt16)(((UInt16)obj.Data[1] << 8) | obj.Data[0])) / 1000;
                                ADResult1a[groupName] = ((Single)(UInt16)(((UInt16)obj.Data[3] << 8) | obj.Data[2])) / 1000;
                            }
                            if (obj.Data[6] == 0xff)
                            { //老炼1的I/O输入测试结果发送完成，首先发送接收确认帧
                                VCI_CAN_OBJ sendobj = new VCI_CAN_OBJ();//实例化sendobj
                                sendobj.SendType = 0;   //发送帧类型，=0时为正常发送，=1时为单次发送，=2时为自发自收，=3时为单次自发自收
                                sendobj.RemoteFlag = 0;
                                sendobj.ExternFlag = 1;
                                sendobj.DataLen = 8;
                                sendobj.ID = 0x10050500;
                                sendobj.Data[0] = 0x01;
                                sendobj.Data[1] = 0x06;
                                if (VCI_Transmit(Can.m_devtype, Can.m_devind, Can.m_canind, ref sendobj, 1) == 0)
                                {
                                    MessageBox.Show("发送失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                // 然后便可以做checkListfuction1的插入工作,以及判断
                                for (int h = (numIOIn + numIOOut + numDA) * 2 + periodcount * (numIOOut + numIOIn + numDA + numAD) * 2; h < (numIOIn + numIOOut + numDA + numAD) * 2 + periodcount * (numIOOut + numIOIn + numDA + numAD) * 2; h = h + 2)
                                {
                                    RowStyle.JudgeAD(rowMergeView1_Fuction, checkListfuction1, ADResult1, ADResult1a, h, 38, ADErroMin, ADErroMax);
                                }
                            }
                        }
                        break;
////////////////////////////////////////////////////////////////老炼1老炼1老炼1////////////////////////////////////////////////////////////////////////


////////////////////////////////////////////////////////////////老炼2老炼2老炼2////////////////////////////////////////////////////////////////////////
                    case 0x10020205:     //  老炼1短路测试结果
                      if ((flagTestNum & 0x02) == 0x02)
                        {
                            if (obj.Data[6] != 0xff)
                            {
                                int groupName = obj.Data[6];
                                shortResult2[groupName * 3 + 0] = (UInt16)((UInt16)obj.Data[1] << 8 | obj.Data[0]);
                                shortResult2[groupName * 3 + 1] = (UInt16)((UInt16)obj.Data[3] << 8 | obj.Data[2]);
                                shortResult2[groupName * 3 + 2] = (UInt16)((UInt16)obj.Data[5] << 8 | obj.Data[4]);
                            }
                            if (obj.Data[6] == 0xff)
                            { //老炼2的短路测试结果发送完成，首先发送接收确认帧
                                VCI_CAN_OBJ sendobj = new VCI_CAN_OBJ();//实例化sendobj
                                sendobj.SendType = 0;   //发送帧类型，=0时为正常发送，=1时为单次发送，=2时为自发自收，=3时为单次自发自收
                                sendobj.RemoteFlag = 0;
                                sendobj.ExternFlag = 1;
                                sendobj.DataLen = 8;
                                sendobj.ID = 0x10050500;
                                sendobj.Data[0] = 0x02;
                                sendobj.Data[1] = 0x01;
                                if (VCI_Transmit(Can.m_devtype, Can.m_devind, Can.m_canind, ref sendobj, 1) == 0)
                                {
                                    MessageBox.Show("发送失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                // 然后便可以做checkListShort2的插入工作,以及判断
                                for (int h = 0 + periodcount * numShort; h < numShort + periodcount * numShort; h++)
                                {
                                    RowStyle.JudgeShort(rowMergeView2_Short, checkListShort2, shortResult2, h, 8, ShortMin);
                                }
                            }
                        }
                        break;
                    case 0x10030205:     //  老炼1电压输出测试结果
                       if ((flagTestNum & 0x02) == 0x02)
                        {
                            if (obj.Data[6] != 0xff)
                            {
                                int groupName = obj.Data[6];
                                voltResult2[groupName * 3 + 0] = ((Single)(UInt16)(((UInt16)obj.Data[1] << 8) | obj.Data[0])) / 100;
                                voltResult2[groupName * 3 + 1] = ((Single)(UInt16)(((UInt16)obj.Data[3] << 8) | obj.Data[2])) / 100;
                                voltResult2[groupName * 3 + 2] = ((Single)(UInt16)(((UInt16)obj.Data[5] << 8) | obj.Data[4])) / 100;
                            }
                            if (obj.Data[6] == 0xff)
                            { //老炼1的短路测试结果发送完成，首先发送接收确认帧
                                VCI_CAN_OBJ sendobj = new VCI_CAN_OBJ();//实例化sendobj
                                sendobj.SendType = 0;   //发送帧类型，=0时为正常发送，=1时为单次发送，=2时为自发自收，=3时为单次自发自收
                                sendobj.RemoteFlag = 0;
                                sendobj.ExternFlag = 1;
                                sendobj.DataLen = 8;
                                sendobj.ID = 0x10050500;
                                sendobj.Data[0] = 0x02;
                                sendobj.Data[1] = 0x02;
                                if (VCI_Transmit(Can.m_devtype, Can.m_devind, Can.m_canind, ref sendobj, 1) == 0)
                                {
                                    MessageBox.Show("发送失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                // 然后便可以做checkListVolt2的插入工作,以及判断
                                for (int h = 0 + periodcount * numVolt; h < numVolt + periodcount * numVolt; h++)
                                {
                                    RowStyle.JudgeVolt(rowMergeView2_Volt, checkListVolt2, voltResult2, h, 8, VoltErroMin, VoltErroMax);
                                }
                            }
                        }
                        break;
                    case 0x10040205:     //  老炼2I/O输出测试结果
                          if ((flagTestNum & 0x02) == 0x02)
                        {
                            if (obj.Data[6] != 0xff)
                            {
                                int groupName = obj.Data[6];
                                IOOutResult2[groupName] = ((Single)(UInt16)(((UInt16)obj.Data[1] << 8) | obj.Data[0])) / 100;
                                IOOutResult2a[groupName] = ((Single)(UInt16)(((UInt16)obj.Data[3] << 8) | obj.Data[2])) / 100;
                            }
                            if (obj.Data[6] == 0xff)
                            { //老炼1的I/O输入测试结果发送完成，首先发送接收确认帧
                                VCI_CAN_OBJ sendobj = new VCI_CAN_OBJ();//实例化sendobj
                                sendobj.SendType = 0;   //发送帧类型，=0时为正常发送，=1时为单次发送，=2时为自发自收，=3时为单次自发自收
                                sendobj.RemoteFlag = 0;
                                sendobj.ExternFlag = 1;
                                sendobj.DataLen = 8;
                                sendobj.ID = 0x10050500;
                                sendobj.Data[0] = 0x02;
                                sendobj.Data[1] = 0x03;
                                if (VCI_Transmit(Can.m_devtype, Can.m_devind, Can.m_canind, ref sendobj, 1) == 0)
                                {
                                    MessageBox.Show("发送失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                // 然后便可以做checkListfuction2的插入工作,以及判断
                                for (int h = 0 + periodcount * (numIOOut + numIOIn + numDA + numAD) * 2; h < numIOOut * 2 + periodcount * (numIOOut + numIOIn + numDA + numAD) * 2; h = h + 2)
                                {
                                    RowStyle.JudgeIOOut(rowMergeView2_Fuction, checkListfuction2, IOOutResult2, IOOutResult2a, h, 16, IOOutErroMin, IOOutErroMax, IOOutOffset, formName);
                                }
                            }
                        }
                        break;
                    case 0x10050205:     //  老炼2I/O输入测试结果（26）
                    if ((flagTestNum & 0x02) == 0x02)
                        {
                            if (obj.Data[6] != 0xff)
                            {
                                int groupName = obj.Data[6];
                                IOInResult2[groupName] = ((Single)(UInt16)(((UInt16)obj.Data[1] << 8) | obj.Data[0])) / 100;
                                IOInResult2a[groupName] = ((Single)(UInt16)(((UInt16)obj.Data[3] << 8) | obj.Data[2])) / 100;
                            }
                            if (obj.Data[6] == 0xff)
                            { //老炼1的I/O输入测试结果发送完成，首先发送接收确认帧
                                VCI_CAN_OBJ sendobj = new VCI_CAN_OBJ();//实例化sendobj
                                sendobj.SendType = 0;   //发送帧类型，=0时为正常发送，=1时为单次发送，=2时为自发自收，=3时为单次自发自收
                                sendobj.RemoteFlag = 0;
                                sendobj.ExternFlag = 1;
                                sendobj.DataLen = 8;
                                sendobj.ID = 0x10050500;
                                sendobj.Data[0] = 0x02;
                                sendobj.Data[1] = 0x04;
                                if (VCI_Transmit(Can.m_devtype, Can.m_devind, Can.m_canind, ref sendobj, 1) == 0)
                                {
                                    MessageBox.Show("发送失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                // 然后便可以做checkListfuction2的插入工作,以及判断
                                for (int h = numIOOut * 2 + periodcount * (numIOOut + numIOIn + numDA + numAD) * 2; h < (numIOOut + numIOIn) * 2 + periodcount * (numIOOut + numIOIn + numDA + numAD) * 2; h = h + 2)
                                {
                                    RowStyle.JudgeIOIn(rowMergeView2_Fuction, checkListfuction2, IOInResult2, IOInResult2a, h, 26, IOInErroMin, IOInErroMax, IOInOffset, formName);
                                }
                            }
                        }
                        break;
                    case 0x10060205:     //  老炼2DA输出测试结果（8）
                         if ((flagTestNum & 0x02) == 0x02)
                        {
                            if (obj.Data[6] != 0xff)
                            {
                                int groupName = obj.Data[6];
                                DAResult2[groupName] = ((Single)(UInt16)(((UInt16)obj.Data[1] << 8) | obj.Data[0])) / 1000;
                                DAResult2a[groupName] = ((Single)(UInt16)(((UInt16)obj.Data[3] << 8) | obj.Data[2])) / 1000;
                            }
                            if (obj.Data[6] == 0xff)
                            { //老炼1的I/O输入测试结果发送完成，首先发送接收确认帧
                                VCI_CAN_OBJ sendobj = new VCI_CAN_OBJ();//实例化sendobj
                                sendobj.SendType = 0;   //发送帧类型，=0时为正常发送，=1时为单次发送，=2时为自发自收，=3时为单次自发自收
                                sendobj.RemoteFlag = 0;
                                sendobj.ExternFlag = 1;
                                sendobj.DataLen = 8;
                                sendobj.ID = 0x10050500;
                                sendobj.Data[0] = 0x02;
                                sendobj.Data[1] = 0x05;
                                if (VCI_Transmit(Can.m_devtype, Can.m_devind, Can.m_canind, ref sendobj, 1) == 0)
                                {
                                    MessageBox.Show("发送失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                // 然后便可以做checkListfuction2的插入工作,以及判断
                                for (int h = (numIOIn + numIOOut) * 2 + periodcount * (numIOOut + numIOIn + numDA + numAD) * 2; h < (numIOIn + numIOOut + numDA) * 2 + periodcount * (numIOOut + numIOIn + numDA + numAD) * 2; h = h + 2)
                                {
                                    RowStyle.JudgeDA(rowMergeView2_Fuction, checkListfuction2, DAResult2, DAResult2a, h, 8, DAErroMin, DAErroMax, DAOffset, formName);
                                }
                            }
                        }
                        break;
                    case 0x10070205:     //  老炼2AD输入测试结果（38）
                        if ((flagTestNum & 0x02) == 0x02)
                        {
                            if (obj.Data[6] != 0xff)
                            {
                                int groupName = obj.Data[6];
                                ADResult2[groupName] = ((Single)(UInt16)(((UInt16)obj.Data[1] << 8) | obj.Data[0])) / 1000;
                                ADResult2a[groupName] = ((Single)(UInt16)(((UInt16)obj.Data[3] << 8) | obj.Data[2])) / 1000;
                            }
                            if (obj.Data[6] == 0xff)
                            { //老炼1的I/O输入测试结果发送完成，首先发送接收确认帧
                                VCI_CAN_OBJ sendobj = new VCI_CAN_OBJ();//实例化sendobj
                                sendobj.SendType = 0;   //发送帧类型，=0时为正常发送，=1时为单次发送，=2时为自发自收，=3时为单次自发自收
                                sendobj.RemoteFlag = 0;
                                sendobj.ExternFlag = 1;
                                sendobj.DataLen = 8;
                                sendobj.ID = 0x10050500;
                                sendobj.Data[0] = 0x02;
                                sendobj.Data[1] = 0x06;
                                if (VCI_Transmit(Can.m_devtype, Can.m_devind, Can.m_canind, ref sendobj, 1) == 0)
                                {
                                    MessageBox.Show("发送失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                // 然后便可以做checkListfuction2的插入工作,以及判断
                                for (int h = (numIOIn + numIOOut + numDA) * 2 + periodcount * (numIOOut + numIOIn + numDA + numAD) * 2; h < (numIOIn + numIOOut + numDA + numAD) * 2 + periodcount * (numIOOut + numIOIn + numDA + numAD) * 2; h = h + 2)
                                {
                                    RowStyle.JudgeAD(rowMergeView2_Fuction, checkListfuction2, ADResult2, ADResult2a, h, 38, ADErroMin, ADErroMax);
                                }
                            }
                        }
                        break;
////////////////////////////////////////////////////////////////老炼2老炼2老炼2////////////////////////////////////////////////////////////////////////



////////////////////////////////////////////////////////////////老炼3老炼3老炼3////////////////////////////////////////////////////////////////////////
                    case 0x10020305:     //  老炼3短路测试结果
                             if ((flagTestNum & 0x04) == 0x04)
                        {
                            if (obj.Data[6] != 0xff)
                            {
                                int groupName = obj.Data[6];
                                shortResult3[groupName * 3 + 0] = (UInt16)((UInt16)obj.Data[1] << 8 | obj.Data[0]);
                                shortResult3[groupName * 3 + 1] = (UInt16)((UInt16)obj.Data[3] << 8 | obj.Data[2]);
                                shortResult3[groupName * 3 + 2] = (UInt16)((UInt16)obj.Data[5] << 8 | obj.Data[4]);
                            }
                            if (obj.Data[6] == 0xff)
                            { //老炼2的短路测试结果发送完成，首先发送接收确认帧
                                VCI_CAN_OBJ sendobj = new VCI_CAN_OBJ();//实例化sendobj
                                sendobj.SendType = 0;   //发送帧类型，=0时为正常发送，=1时为单次发送，=2时为自发自收，=3时为单次自发自收
                                sendobj.RemoteFlag = 0;
                                sendobj.ExternFlag = 1;
                                sendobj.DataLen = 8;
                                sendobj.ID = 0x10050500;
                                sendobj.Data[0] = 0x03;
                                sendobj.Data[1] = 0x01;
                                if (VCI_Transmit(Can.m_devtype, Can.m_devind, Can.m_canind, ref sendobj, 1) == 0)
                                {
                                    MessageBox.Show("发送失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                // 然后便可以做checkListShort3的插入工作,以及判断
                                for (int h = 0 + periodcount * numShort; h < numShort + periodcount * numShort; h++)
                                {
                                    RowStyle.JudgeShort(rowMergeView3_Short, checkListShort3, shortResult3, h, 8, ShortMin);
                                }
                            }
                        }
                        break;
                    case 0x10030305:     //  老炼3电压输出测试结果
                      if ((flagTestNum & 0x04) == 0x04)
                        {
                            if (obj.Data[6] != 0xff)
                            {
                                int groupName = obj.Data[6];
                                voltResult3[groupName * 3 + 0] = ((Single)(UInt16)(((UInt16)obj.Data[1] << 8) | obj.Data[0])) / 100;
                                voltResult3[groupName * 3 + 1] = ((Single)(UInt16)(((UInt16)obj.Data[3] << 8) | obj.Data[2])) / 100;
                                voltResult3[groupName * 3 + 2] = ((Single)(UInt16)(((UInt16)obj.Data[5] << 8) | obj.Data[4])) / 100;
                            }
                            if (obj.Data[6] == 0xff)
                            { //老炼1的短路测试结果发送完成，首先发送接收确认帧
                                VCI_CAN_OBJ sendobj = new VCI_CAN_OBJ();//实例化sendobj
                                sendobj.SendType = 0;   //发送帧类型，=0时为正常发送，=1时为单次发送，=2时为自发自收，=3时为单次自发自收
                                sendobj.RemoteFlag = 0;
                                sendobj.ExternFlag = 1;
                                sendobj.DataLen = 8;
                                sendobj.ID = 0x10050500;
                                sendobj.Data[0] = 0x03;
                                sendobj.Data[1] = 0x02;
                                if (VCI_Transmit(Can.m_devtype, Can.m_devind, Can.m_canind, ref sendobj, 1) == 0)
                                {
                                    MessageBox.Show("发送失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                // 然后便可以做checkListVolt3的插入工作,以及判断
                                for (int h = 0 + periodcount * numVolt; h < numVolt + periodcount * numVolt; h++)
                                {
                                    RowStyle.JudgeVolt(rowMergeView3_Volt, checkListVolt3, voltResult3, h, 8, VoltErroMin, VoltErroMax);
                                }
                            }
                        }
                        break;
                    case 0x10040305:     //  老炼3I/O输出测试结果
                       if ((flagTestNum & 0x04) == 0x04)
                        {
                            if (obj.Data[6] != 0xff)
                            {
                                int groupName = obj.Data[6];
                                IOOutResult3[groupName] = ((Single)(UInt16)(((UInt16)obj.Data[1] << 8) | obj.Data[0])) / 100;
                                IOOutResult3a[groupName] = ((Single)(UInt16)(((UInt16)obj.Data[3] << 8) | obj.Data[2])) / 100;
                            }
                            if (obj.Data[6] == 0xff)
                            { //老炼1的I/O输入测试结果发送完成，首先发送接收确认帧
                                VCI_CAN_OBJ sendobj = new VCI_CAN_OBJ();//实例化sendobj
                                sendobj.SendType = 0;   //发送帧类型，=0时为正常发送，=1时为单次发送，=2时为自发自收，=3时为单次自发自收
                                sendobj.RemoteFlag = 0;
                                sendobj.ExternFlag = 1;
                                sendobj.DataLen = 8;
                                sendobj.ID = 0x10050500;
                                sendobj.Data[0] = 0x03;
                                sendobj.Data[1] = 0x03;
                                if (VCI_Transmit(Can.m_devtype, Can.m_devind, Can.m_canind, ref sendobj, 1) == 0)
                                {
                                    MessageBox.Show("发送失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                // 然后便可以做checkListfuction3的插入工作,以及判断
                                for (int h = 0 + periodcount * (numIOOut + numIOIn + numDA + numAD) * 2; h < numIOOut * 2 + periodcount * (numIOOut + numIOIn + numDA + numAD) * 2; h = h + 2)
                                {
                                    RowStyle.JudgeIOOut(rowMergeView3_Fuction, checkListfuction3, IOOutResult3, IOOutResult3a, h, 16, IOOutErroMin, IOOutErroMax, IOOutOffset, formName);
                                }
                            }
                        }
                        break;
                    case 0x10050305:     //  老炼3I/O输入测试结果（26）
                        if ((flagTestNum & 0x04) == 0x04)
                        {
                            if (obj.Data[6] != 0xff)
                            {
                                int groupName = obj.Data[6];
                                IOInResult3[groupName] = ((Single)(UInt16)(((UInt16)obj.Data[1] << 8) | obj.Data[0])) / 100;
                                IOInResult3a[groupName] = ((Single)(UInt16)(((UInt16)obj.Data[3] << 8) | obj.Data[2])) / 100;
                            }
                            if (obj.Data[6] == 0xff)
                            { //老炼1的I/O输入测试结果发送完成，首先发送接收确认帧
                                VCI_CAN_OBJ sendobj = new VCI_CAN_OBJ();//实例化sendobj
                                sendobj.SendType = 0;   //发送帧类型，=0时为正常发送，=1时为单次发送，=2时为自发自收，=3时为单次自发自收
                                sendobj.RemoteFlag = 0;
                                sendobj.ExternFlag = 1;
                                sendobj.DataLen = 8;
                                sendobj.ID = 0x10050500;
                                sendobj.Data[0] = 0x03;
                                sendobj.Data[1] = 0x04;
                                if (VCI_Transmit(Can.m_devtype, Can.m_devind, Can.m_canind, ref sendobj, 1) == 0)
                                {
                                    MessageBox.Show("发送失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                // 然后便可以做checkListfuction3的插入工作,以及判断
                                for (int h = numIOOut * 2 + periodcount * (numIOOut + numIOIn + numDA + numAD) * 2; h < (numIOOut + numIOIn) * 2 + periodcount * (numIOOut + numIOIn + numDA + numAD) * 2; h = h + 2)
                                {
                                    RowStyle.JudgeIOOut(rowMergeView3_Fuction, checkListfuction3, IOOutResult3, IOOutResult3a, h, 16, IOOutErroMin, IOOutErroMax, IOOutOffset, formName);
                                }
                            }
                        }
                        break;
                    case 0x10060305:     //  老炼3DA输出测试结果（8）
                          if ((flagTestNum & 0x04) == 0x04)
                        {
                            if (obj.Data[6] != 0xff)
                            {
                                int groupName = obj.Data[6];
                                DAResult3[groupName] = ((Single)(UInt16)(((UInt16)obj.Data[1] << 8) | obj.Data[0])) / 1000;
                                DAResult3a[groupName] = ((Single)(UInt16)(((UInt16)obj.Data[3] << 8) | obj.Data[2])) / 1000;
                            }
                            if (obj.Data[6] == 0xff)
                            { //老炼1的I/O输入测试结果发送完成，首先发送接收确认帧
                                VCI_CAN_OBJ sendobj = new VCI_CAN_OBJ();//实例化sendobj
                                sendobj.SendType = 0;   //发送帧类型，=0时为正常发送，=1时为单次发送，=2时为自发自收，=3时为单次自发自收
                                sendobj.RemoteFlag = 0;
                                sendobj.ExternFlag = 1;
                                sendobj.DataLen = 8;
                                sendobj.ID = 0x10050500;
                                sendobj.Data[0] = 0x03;
                                sendobj.Data[1] = 0x05;
                                if (VCI_Transmit(Can.m_devtype, Can.m_devind, Can.m_canind, ref sendobj, 1) == 0)
                                {
                                    MessageBox.Show("发送失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                // 然后便可以做checkListfuction3的插入工作,以及判断
                                for (int h = (numIOIn + numIOOut) * 2 + periodcount * (numIOOut + numIOIn + numDA + numAD) * 2; h < (numIOIn + numIOOut + numDA) * 2 + periodcount * (numIOOut + numIOIn + numDA + numAD) * 2; h = h + 2)
                                {
                                    RowStyle.JudgeDA(rowMergeView3_Fuction, checkListfuction3, DAResult3, DAResult3a, h, 8, DAErroMin, DAErroMax, DAOffset, formName);
                                }
                            }
                        }
                        break;
                    case 0x10070305:     //  老炼3AD输入测试结果（38）
                          if ((flagTestNum & 0x04) == 0x04)
                        {
                            if (obj.Data[6] != 0xff)
                            {
                                int groupName = obj.Data[6];
                                ADResult3[groupName] = ((Single)(UInt16)(((UInt16)obj.Data[1] << 8) | obj.Data[0])) / 1000;
                                ADResult3a[groupName] = ((Single)(UInt16)(((UInt16)obj.Data[3] << 8) | obj.Data[2])) / 1000;
                            }
                            if (obj.Data[6] == 0xff)
                            { //老炼1的I/O输入测试结果发送完成，首先发送接收确认帧
                                VCI_CAN_OBJ sendobj = new VCI_CAN_OBJ();//实例化sendobj
                                sendobj.SendType = 0;   //发送帧类型，=0时为正常发送，=1时为单次发送，=2时为自发自收，=3时为单次自发自收
                                sendobj.RemoteFlag = 0;
                                sendobj.ExternFlag = 1;
                                sendobj.DataLen = 8;
                                sendobj.ID = 0x10050500;
                                sendobj.Data[0] = 0x03;
                                sendobj.Data[1] = 0x06;
                                if (VCI_Transmit(Can.m_devtype, Can.m_devind, Can.m_canind, ref sendobj, 1) == 0)
                                {
                                    MessageBox.Show("发送失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                // 然后便可以做checkListfuction3的插入工作,以及判断
                                for (int h = (numIOIn + numIOOut + numDA) * 2 + periodcount * (numIOOut + numIOIn + numDA + numAD) * 2; h < (numIOIn + numIOOut + numDA + numAD) * 2 + periodcount * (numIOOut + numIOIn + numDA + numAD) * 2; h = h + 2)
                                {
                                    RowStyle.JudgeAD(rowMergeView3_Fuction, checkListfuction3, ADResult3, ADResult3a, h, 38, ADErroMin, ADErroMax);
                                }
                            }
                        }
                        break;
////////////////////////////////////////////////////////////////老炼3老炼3老炼3////////////////////////////////////////////////////////////////////////




////////////////////////////////////////////////////////////////老炼4老炼4老炼4////////////////////////////////////////////////////////////////////////
                    case 0x10020405:     //  老炼4短路测试结果
                      if ((flagTestNum & 0x08) == 0x08)
                        {
                            if (obj.Data[6] != 0xff)
                            {
                                int groupName = obj.Data[6];
                                shortResult4[groupName * 3 + 0] = (UInt16)((UInt16)obj.Data[1] << 8 | obj.Data[0]);
                                shortResult4[groupName * 3 + 1] = (UInt16)((UInt16)obj.Data[3] << 8 | obj.Data[2]);
                                shortResult4[groupName * 3 + 2] = (UInt16)((UInt16)obj.Data[5] << 8 | obj.Data[4]);
                            }
                            if (obj.Data[6] == 0xff)
                            { //老炼2的短路测试结果发送完成，首先发送接收确认帧
                                VCI_CAN_OBJ sendobj = new VCI_CAN_OBJ();//实例化sendobj
                                sendobj.SendType = 0;   //发送帧类型，=0时为正常发送，=1时为单次发送，=2时为自发自收，=3时为单次自发自收
                                sendobj.RemoteFlag = 0;
                                sendobj.ExternFlag = 1;
                                sendobj.DataLen = 8;
                                sendobj.ID = 0x10050500;
                                sendobj.Data[0] = 0x04;
                                sendobj.Data[1] = 0x01;
                                if (VCI_Transmit(Can.m_devtype, Can.m_devind, Can.m_canind, ref sendobj, 1) == 0)
                                {
                                    MessageBox.Show("发送失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                // 然后便可以做checkListShort4的插入工作,以及判断
                                for (int h = 0 + periodcount * numShort; h < numShort + periodcount * numShort; h++)
                                {
                                    RowStyle.JudgeShort(rowMergeView4_Short, checkListShort4, shortResult4, h, 8, ShortMin);
                                }
                            }
                        }
                        break;
                    case 0x10030405:     //  老炼4电压输出测试结果
                      if ((flagTestNum & 0x08) == 0x08)
                        {
                            if (obj.Data[6] != 0xff)
                            {
                                int groupName = obj.Data[6];
                                voltResult4[groupName * 3 + 0] = ((Single)(UInt16)(((UInt16)obj.Data[1] << 8) | obj.Data[0])) / 100;
                                voltResult4[groupName * 3 + 1] = ((Single)(UInt16)(((UInt16)obj.Data[3] << 8) | obj.Data[2])) / 100;
                                voltResult4[groupName * 3 + 2] = ((Single)(UInt16)(((UInt16)obj.Data[5] << 8) | obj.Data[4])) / 100;
                            }
                            if (obj.Data[6] == 0xff)
                            { //老炼1的短路测试结果发送完成，首先发送接收确认帧
                                VCI_CAN_OBJ sendobj = new VCI_CAN_OBJ();//实例化sendobj
                                sendobj.SendType = 0;   //发送帧类型，=0时为正常发送，=1时为单次发送，=2时为自发自收，=3时为单次自发自收
                                sendobj.RemoteFlag = 0;
                                sendobj.ExternFlag = 1;
                                sendobj.DataLen = 8;
                                sendobj.ID = 0x10050500;
                                sendobj.Data[0] = 0x04;
                                sendobj.Data[1] = 0x02;
                                if (VCI_Transmit(Can.m_devtype, Can.m_devind, Can.m_canind, ref sendobj, 1) == 0)
                                {
                                    MessageBox.Show("发送失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                // 然后便可以做checkListVolt4的插入工作,以及判断
                                for (int h = 0 + periodcount * numVolt; h < numVolt + periodcount * numVolt; h++)
                                {
                                    RowStyle.JudgeVolt(rowMergeView4_Volt, checkListVolt4, voltResult4, h, 8, VoltErroMin, VoltErroMax);
                                }
                            }
                        }
                        break;
                    case 0x10040405:     //  老炼4I/O输出测试结果
                           if ((flagTestNum & 0x08) == 0x08)
                        {
                            if (obj.Data[6] != 0xff)
                            {
                                int groupName = obj.Data[6];
                                IOOutResult4[groupName] = ((Single)(UInt16)(((UInt16)obj.Data[1] << 8) | obj.Data[0])) / 100;
                                IOOutResult4a[groupName] = ((Single)(UInt16)(((UInt16)obj.Data[3] << 8) | obj.Data[2])) / 100;
                            }
                            if (obj.Data[6] == 0xff)
                            { //老炼1的I/O输入测试结果发送完成，首先发送接收确认帧
                                VCI_CAN_OBJ sendobj = new VCI_CAN_OBJ();//实例化sendobj
                                sendobj.SendType = 0;   //发送帧类型，=0时为正常发送，=1时为单次发送，=2时为自发自收，=3时为单次自发自收
                                sendobj.RemoteFlag = 0;
                                sendobj.ExternFlag = 1;
                                sendobj.DataLen = 8;
                                sendobj.ID = 0x10050500;
                                sendobj.Data[0] = 0x04;
                                sendobj.Data[1] = 0x03;
                                if (VCI_Transmit(Can.m_devtype, Can.m_devind, Can.m_canind, ref sendobj, 1) == 0)
                                {
                                    MessageBox.Show("发送失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                // 然后便可以做checkListfuction4的插入工作,以及判断
                                for (int h = 0 + periodcount * (numIOOut + numIOIn + numDA + numAD) * 2; h < numIOOut * 2 + periodcount * (numIOOut + numIOIn + numDA + numAD) * 2; h = h + 2)
                                {
                                    RowStyle.JudgeIOOut(rowMergeView4_Fuction, checkListfuction4, IOOutResult4, IOOutResult4a, h, 16, IOOutErroMin, IOOutErroMax, IOOutOffset, formName);
                                }
                            }
                        }
                        break;
                    case 0x10050405:     //  老炼4I/O输入测试结果（26）
                     if ((flagTestNum & 0x08) == 0x08)
                        {
                            if (obj.Data[6] != 0xff)
                            {
                                int groupName = obj.Data[6];
                                IOInResult4[groupName] = ((Single)(UInt16)(((UInt16)obj.Data[1] << 8) | obj.Data[0])) / 100;
                                IOInResult4a[groupName] = ((Single)(UInt16)(((UInt16)obj.Data[3] << 8) | obj.Data[2])) / 100;
                            }
                            if (obj.Data[6] == 0xff)
                            { //老炼1的I/O输入测试结果发送完成，首先发送接收确认帧
                                VCI_CAN_OBJ sendobj = new VCI_CAN_OBJ();//实例化sendobj
                                sendobj.SendType = 0;   //发送帧类型，=0时为正常发送，=1时为单次发送，=2时为自发自收，=3时为单次自发自收
                                sendobj.RemoteFlag = 0;
                                sendobj.ExternFlag = 1;
                                sendobj.DataLen = 8;
                                sendobj.ID = 0x10050500;
                                sendobj.Data[0] = 0x04;
                                sendobj.Data[1] = 0x04;
                                if (VCI_Transmit(Can.m_devtype, Can.m_devind, Can.m_canind, ref sendobj, 1) == 0)
                                {
                                    MessageBox.Show("发送失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                // 然后便可以做checkListfuction4的插入工作,以及判断
                                for (int h = numIOOut * 2 + periodcount * (numIOOut + numIOIn + numDA + numAD) * 2; h < (numIOOut + numIOIn) * 2 + periodcount * (numIOOut + numIOIn + numDA + numAD) * 2; h = h + 2)
                                {
                                    RowStyle.JudgeIOIn(rowMergeView4_Fuction, checkListfuction4, IOInResult4, IOInResult4a, h, 26, IOInErroMin, IOInErroMax, IOInOffset, formName);
                                }
                            }
                        }
                        break;
                    case 0x10060405:     //  老炼4DA输出测试结果（8）
                       if ((flagTestNum & 0x08) == 0x08)
                        {
                            if (obj.Data[6] != 0xff)
                            {
                                int groupName = obj.Data[6];
                                DAResult4[groupName] = ((Single)(UInt16)(((UInt16)obj.Data[1] << 8) | obj.Data[0])) / 1000;
                                DAResult4a[groupName] = ((Single)(UInt16)(((UInt16)obj.Data[3] << 8) | obj.Data[2])) / 1000;
                            }
                            if (obj.Data[6] == 0xff)
                            { //老炼1的I/O输入测试结果发送完成，首先发送接收确认帧
                                VCI_CAN_OBJ sendobj = new VCI_CAN_OBJ();//实例化sendobj
                                sendobj.SendType = 0;   //发送帧类型，=0时为正常发送，=1时为单次发送，=2时为自发自收，=3时为单次自发自收
                                sendobj.RemoteFlag = 0;
                                sendobj.ExternFlag = 1;
                                sendobj.DataLen = 8;
                                sendobj.ID = 0x10050500;
                                sendobj.Data[0] = 0x04;
                                sendobj.Data[1] = 0x05;
                                if (VCI_Transmit(Can.m_devtype, Can.m_devind, Can.m_canind, ref sendobj, 1) == 0)
                                {
                                    MessageBox.Show("发送失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                // 然后便可以做checkListfuction4的插入工作,以及判断
                                for (int h = (numIOIn + numIOOut) * 2 + periodcount * (numIOOut + numIOIn + numDA + numAD) * 2; h < (numIOIn + numIOOut + numDA) * 2 + periodcount * (numIOOut + numIOIn + numDA + numAD) * 2; h = h + 2)
                                {
                                    RowStyle.JudgeDA(rowMergeView4_Fuction, checkListfuction4, DAResult4, DAResult4a, h, 8, DAErroMin, DAErroMax, DAOffset, formName);
                                }
                            }
                        }
                        break;
                    case 0x10070405:     //  老炼4AD输入测试结果（38）
                          if ((flagTestNum & 0x08) == 0x08)
                        {
                            if (obj.Data[6] != 0xff)
                            {
                                int groupName = obj.Data[6];
                                ADResult4[groupName] = ((Single)(UInt16)(((UInt16)obj.Data[1] << 8) | obj.Data[0])) / 1000;
                                ADResult4a[groupName] = ((Single)(UInt16)(((UInt16)obj.Data[3] << 8) | obj.Data[2])) / 1000;
                            }
                            if (obj.Data[6] == 0xff)
                            { //老炼1的I/O输入测试结果发送完成，首先发送接收确认帧
                                VCI_CAN_OBJ sendobj = new VCI_CAN_OBJ();//实例化sendobj
                                sendobj.SendType = 0;   //发送帧类型，=0时为正常发送，=1时为单次发送，=2时为自发自收，=3时为单次自发自收
                                sendobj.RemoteFlag = 0;
                                sendobj.ExternFlag = 1;
                                sendobj.DataLen = 8;
                                sendobj.ID = 0x10050500;
                                sendobj.Data[0] = 0x04;
                                sendobj.Data[1] = 0x06;
                                if (VCI_Transmit(Can.m_devtype, Can.m_devind, Can.m_canind, ref sendobj, 1) == 0)
                                {
                                    MessageBox.Show("发送失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                // 然后便可以做checkListfuction4的插入工作,以及判断
                                for (int h = (numIOIn + numIOOut + numDA) * 2 + periodcount * (numIOOut + numIOIn + numDA + numAD) * 2; h < (numIOIn + numIOOut + numDA + numAD) * 2 + periodcount * (numIOOut + numIOIn + numDA + numAD) * 2; h = h + 2)
                                {
                                    RowStyle.JudgeAD(rowMergeView4_Fuction, checkListfuction4, ADResult4, ADResult4a, h, 38, ADErroMin, ADErroMax);
                                }
                            }
                        }
                        break;
                        
////////////////////////////////////////////////////////////////老炼4老炼4老炼4////////////////////////////////////////////////////////////////////////
                      default:
                        break;
                }
            }
            Marshal.FreeHGlobal(pt);
        }
        #endregion
        private void button1_Click(object sender, EventArgs e)    //弹出资源配置密码输入界面
        {
            formPassLaolian = new FormPass(this, "Laolian");
            formPassLaolian.WindowState = FormWindowState.Normal;
            formPassLaolian.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)  //关闭老炼测试界面，返回到select界面
        {
            VCI_CloseDevice(Can.m_devtype, Can.m_devind);
            this.Close();
        }

        /// <summary>
        /// 计算老炼当前步骤所剩时间
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static string transMin(double time)
        {
            int hour, minute, second;
            hour = System.Convert.ToInt32(Math.Truncate(time / 3600));
            minute = System.Convert.ToInt32(Math.Truncate((time - 3600 * hour) / 60));
            second = System.Convert.ToInt32((time - 3600 * hour - minute * 60));
            string strHour, strMinute, strSecond, str;
            if (second < 10)
            {
                strSecond = "0" + second.ToString();
            }
            else
            {
                strSecond = second.ToString();
            }
            if (minute < 10)
            {
                strMinute = "0" + minute.ToString();
            }
            else
            {
                strMinute = minute.ToString();
            }
            if (hour < 10)
            {
                strHour = "0" + hour.ToString();
            }
            else
            {
                strHour = hour.ToString();
            }
            str = strHour + ":" + strMinute + ":" + strSecond;
            return str;
        }

        private void button_时序设置确认键_Click(object sender, EventArgs e)
        {

            flagTestNum = 0;
            if (flag_Read == 0)
            {
                MessageBox.Show("请先读取资源配置文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (flag_Read == 1)
            {
                #region-老炼时序表格-
                double restTime = 0;
                jNum = 0;
                testTime1 = Convert.ToDouble(textBox_20V.Text);
                testTime2 = Convert.ToDouble(textBox_24V.Text);
                testTime3 = Convert.ToDouble(textBox_30V.Text);
                timeall = testTime1 + testTime2 + testTime3;
                double time24, time20,time30;
                time20 = testTime1;
                time24 = testTime2;
                time30 = testTime3;

                curTime1 = Convert.ToDouble(textBox_CurOn.Text) ;//通电时间
                waitTime1 = Convert.ToDouble(textBox_CurOff.Text);
                if(timeall%curTime1==0)
                periodNum = (int)(timeall / curTime1);
                else
                periodNum = (int)(timeall / curTime1)+1;
                curTime = Convert.ToDouble(textBox_CurOn.Text)*60*60;//通电时间，精确到秒
                waitTime = Convert.ToDouble(textBox_CurOff.Text)*60*60;//等待时间，精确到秒
                checkListTime1 = new DataTable();
                checkListTime1.Columns.Add("测试周期");
                checkListTime1.Columns.Add("输入电压");
                checkListTime1.Columns.Add("老炼时间");
                checkListTime1.Columns.Add("剩余时间");
                checkListTime1.Columns.Add("测试结果");
                checkListTime2 = new DataTable();
                checkListTime2.Columns.Add("测试周期");
                checkListTime2.Columns.Add("输入电压");
                checkListTime2.Columns.Add("老炼时间");
                checkListTime2.Columns.Add("剩余时间");
                checkListTime2.Columns.Add("测试结果");
                checkListTime3 = new DataTable();
                checkListTime3.Columns.Add("测试周期");
                checkListTime3.Columns.Add("输入电压");
                checkListTime3.Columns.Add("老炼时间");
                checkListTime3.Columns.Add("剩余时间");
                checkListTime3.Columns.Add("测试结果");
                checkListTime4 = new DataTable();
                checkListTime4.Columns.Add("测试周期");
                checkListTime4.Columns.Add("输入电压");
                checkListTime4.Columns.Add("老炼时间");
                checkListTime4.Columns.Add("剩余时间");
                checkListTime4.Columns.Add("测试结果");
                int i = 1;
                while (time30 > 0)
                {
                    while (time20 > 0)
                    {
                        time20 -= curTime1;
                        string str = "周期" + i.ToString();
                        if (time20 >= 0)
                        {
                            DataRow newRow = checkListTime1.NewRow();
                            newRow[0] = str;
                            newRow[1] = "+20V";
                            newRow[2] = transMin(curTime);
                            newRow[3] = transMin(curTime);
                            newRow[4] = "";
                            checkListTime1.Rows.Add(newRow);
                            DataRow newRow1 = checkListTime2.NewRow();
                            newRow1[0] = str;
                            newRow1[1] = "+20V";
                            newRow1[2] = transMin(curTime);
                            newRow1[3] = transMin(curTime);
                            newRow1[4] = "";
                            checkListTime2.Rows.Add(newRow1);
                            DataRow newRow2 = checkListTime3.NewRow();
                            newRow2[0] = str;
                            newRow2[1] = "+20V";
                            newRow2[2] = transMin(curTime);
                            newRow2[3] = transMin(curTime);
                            newRow2[4] = "";
                            checkListTime3.Rows.Add(newRow2);
                            DataRow newRow3 = checkListTime4.NewRow();
                            newRow3[0] = str;
                            newRow3[1] = "+20V";
                            newRow3[2] = transMin(curTime);
                            newRow3[3] = transMin(curTime);
                            newRow3[4] = "";
                            checkListTime4.Rows.Add(newRow3);

                            trailTable[jNum, 0] = 20;
                            trailTable[jNum, 1] = curTime1;
                            jNum++;
                            newRow = checkListTime1.NewRow();
                            newRow[0] = str;
                            newRow[1] = "0V";
                            newRow[2] = transMin(waitTime);
                            newRow[3] = transMin(waitTime);
                            newRow[4] = "";
                            checkListTime1.Rows.Add(newRow);
                            newRow1 = checkListTime2.NewRow();
                            newRow1[0] = str;
                            newRow1[1] = "0V";
                            newRow1[2] = transMin(waitTime);
                            newRow1[3] = transMin(waitTime);
                            newRow1[4] = "";
                            checkListTime2.Rows.Add(newRow1);
                            newRow2 = checkListTime3.NewRow();
                            newRow2[0] = str;
                            newRow2[1] = "0V";
                            newRow2[2] = transMin(waitTime);
                            newRow2[3] = transMin(waitTime);
                            newRow2[4] = "";
                            checkListTime3.Rows.Add(newRow2);
                            newRow3 = checkListTime4.NewRow();
                            newRow3[0] = str;
                            newRow3[1] = "0V";
                            newRow3[2] = transMin(waitTime);
                            newRow3[3] = transMin(waitTime);
                            newRow3[4] = "";
                            checkListTime4.Rows.Add(newRow3);
                            trailTable[jNum, 0] = 0;
                            trailTable[jNum, 1] = waitTime1;
                            jNum++;
                            i++;
                        }
                        if (time20 < 0)
                        {
                            double realTime = time20 + curTime1;
                            restTime = curTime1 - realTime;

                            DataRow newRow = checkListTime1.NewRow();
                            newRow[0] = str;
                            newRow[1] = "+20V";
                            newRow[2] = transMin(realTime * 3600);
                            newRow[3] = transMin(realTime * 3600);
                            newRow[4] = "";
                            checkListTime1.Rows.Add(newRow);
                            DataRow newRow1 = checkListTime2.NewRow();
                            newRow1[0] = str;
                            newRow1[1] = "+20V";
                            newRow1[2] = transMin(realTime * 3600);
                            newRow1[3] = transMin(realTime * 3600);
                            newRow1[4] = "";
                            checkListTime2.Rows.Add(newRow1);
                            DataRow newRow2 = checkListTime3.NewRow();
                            newRow2[0] = str;
                            newRow2[1] = "+20V";
                            newRow2[2] = transMin(realTime * 3600);
                            newRow2[3] = transMin(realTime * 3600);
                            newRow2[4] = "";
                            checkListTime3.Rows.Add(newRow2);
                            DataRow newRow3 = checkListTime4.NewRow();
                            newRow3[0] = str;
                            newRow3[1] = "+20V";
                            newRow3[2] = transMin(realTime * 3600);
                            newRow3[3] = transMin(realTime * 3600);
                            newRow3[4] = "";
                            checkListTime4.Rows.Add(newRow3);
                            trailTable[jNum, 0] = 20;
                            trailTable[jNum, 1] = realTime;
                            jNum++;
                        }
                    }
                    while (time24>0)
                    {
                        string str = "周期" + i.ToString();
                        if (restTime != 0)
                        {
                            time24 = time24 - restTime;
                            DataRow newRow = checkListTime1.NewRow();
                            newRow[0] = str;
                            newRow[1] = "+24V";
                            newRow[2] = transMin(restTime*3600);
                            newRow[3] = transMin(restTime * 3600);
                            newRow[4] = "";
                            checkListTime1.Rows.Add(newRow);
                            DataRow newRow1 = checkListTime2.NewRow();
                            newRow1[0] = str;
                            newRow1[1] = "+24V";
                            newRow1[2] = transMin(restTime * 3600);
                            newRow1[3] = transMin(restTime * 3600);
                            newRow1[4] = "";
                            checkListTime2.Rows.Add(newRow1);
                            DataRow newRow2 = checkListTime3.NewRow();
                            newRow2[0] = str;
                            newRow2[1] = "+24V";
                            newRow2[2] = transMin(restTime * 3600);
                            newRow2[3] = transMin(restTime * 3600);
                            newRow2[4] = "";
                            checkListTime3.Rows.Add(newRow2);
                            DataRow newRow3 = checkListTime4.NewRow();
                            newRow3[0] = str;
                            newRow3[1] = "+24V";
                            newRow3[2] = transMin(restTime * 3600);
                            newRow3[3] = transMin(restTime * 3600);
                            newRow3[4] = "";
                            checkListTime4.Rows.Add(newRow3);

                            trailTable[jNum, 0] = 24;
                            trailTable[jNum, 1] = restTime;
                            jNum++;
                            newRow = checkListTime1.NewRow();
                            newRow[0] = str;
                            newRow[1] = "0V";
                            newRow[2] = transMin(waitTime);
                            newRow[3] = transMin(waitTime);
                            newRow[4] = "";
                            checkListTime1.Rows.Add(newRow);
                            newRow1 = checkListTime2.NewRow();
                            newRow1[0] = str;
                            newRow1[1] = "0V";
                            newRow1[2] = transMin(waitTime);
                            newRow1[3] = transMin(waitTime);
                            newRow1[4] = "";
                            checkListTime2.Rows.Add(newRow1);
                            newRow2 = checkListTime3.NewRow();
                            newRow2[0] = str;
                            newRow2[1] = "0V";
                            newRow2[2] = transMin(waitTime);
                            newRow2[3] = transMin(waitTime);
                            newRow2[4] = "";
                            checkListTime3.Rows.Add(newRow2);
                            newRow3 = checkListTime4.NewRow();
                            newRow3[0] = str;
                            newRow3[1] = "0V";
                            newRow3[2] = transMin(waitTime);
                            newRow3[3] = transMin(waitTime);
                            newRow3[4] = "";
                            checkListTime4.Rows.Add(newRow3);
                            trailTable[jNum, 0] = 0;
                            trailTable[jNum, 1] = waitTime1;
                            jNum++;
                            i++;
                            restTime = 0;
                            continue;
                        }
                        time24 -= curTime1;
                        if (time24 >= 0)
                        {
                            DataRow newRow = checkListTime1.NewRow();
                            newRow[0] = str;
                            newRow[1] = "+24V";
                            newRow[2] = transMin(curTime);
                            newRow[3] = transMin(curTime);
                            newRow[4] = "";
                            checkListTime1.Rows.Add(newRow);
                            DataRow newRow1 = checkListTime2.NewRow();
                            newRow1[0] = str;
                            newRow1[1] = "+24V";
                            newRow1[2] = transMin(curTime);
                            newRow1[3] = transMin(curTime);
                            newRow1[4] = "";
                            checkListTime2.Rows.Add(newRow1);
                            DataRow newRow2 = checkListTime3.NewRow();
                            newRow2[0] = str;
                            newRow2[1] = "+24V";
                            newRow2[2] = transMin(curTime);
                            newRow2[3] = transMin(curTime);
                            newRow2[4] = "";
                            checkListTime3.Rows.Add(newRow2);
                            DataRow newRow3 = checkListTime4.NewRow();
                            newRow3[0] = str;
                            newRow3[1] = "+24V";
                            newRow3[2] = transMin(curTime);
                            newRow3[3] = transMin(curTime);
                            newRow3[4] = "";
                            checkListTime4.Rows.Add(newRow3);

                            trailTable[jNum, 0] = 24;
                            trailTable[jNum, 1] = curTime1;
                            jNum++;
                            newRow = checkListTime1.NewRow();
                            newRow[0] = str;
                            newRow[1] = "0V";
                            newRow[2] = transMin(waitTime);
                            newRow[3] = transMin(waitTime);
                            newRow[4] = "";
                            checkListTime1.Rows.Add(newRow);
                            newRow1 = checkListTime2.NewRow();
                            newRow1[0] = str;
                            newRow1[1] = "0V";
                            newRow1[2] = transMin(waitTime);
                            newRow1[3] = transMin(waitTime);
                            newRow1[4] = "";
                            checkListTime2.Rows.Add(newRow1);
                            newRow2 = checkListTime3.NewRow();
                            newRow2[0] = str;
                            newRow2[1] = "0V";
                            newRow2[2] = transMin(waitTime);
                            newRow2[3] = transMin(waitTime);
                            newRow2[4] = "";
                            checkListTime3.Rows.Add(newRow2);
                            newRow3 = checkListTime4.NewRow();
                            newRow3[0] = str;
                            newRow3[1] = "0V";
                            newRow3[2] = transMin(waitTime);
                            newRow3[3] = transMin(waitTime);
                            newRow3[4] = "";
                            checkListTime4.Rows.Add(newRow3);
                            trailTable[jNum, 0] = 0;
                            trailTable[jNum, 1] = waitTime1;
                            jNum++;
                            i++;
                        }
                        if (time24 < 0)
                        {
                            double realTime = time24 + curTime1;
                            restTime = curTime1 - realTime;

                            DataRow newRow = checkListTime1.NewRow();
                            newRow[0] = str;
                            newRow[1] = "+24V";
                            newRow[2] = transMin(realTime * 3600);
                            newRow[3] = transMin(realTime * 3600);
                            newRow[4] = "";
                            checkListTime1.Rows.Add(newRow);
                            DataRow newRow1 = checkListTime2.NewRow();
                            newRow1[0] = str;
                            newRow1[1] = "+24V";
                            newRow1[2] = transMin(realTime * 3600);
                            newRow1[3] = transMin(realTime * 3600);
                            newRow1[4] = "";
                            checkListTime2.Rows.Add(newRow1);
                            DataRow newRow2 = checkListTime3.NewRow();
                            newRow2[0] = str;
                            newRow2[1] = "+24V";
                            newRow2[2] = transMin(realTime * 3600);
                            newRow2[3] = transMin(realTime * 3600);
                            newRow2[4] = "";
                            checkListTime3.Rows.Add(newRow2);
                            DataRow newRow3 = checkListTime4.NewRow();
                            newRow3[0] = str;
                            newRow3[1] = "+24V";
                            newRow3[2] = transMin(realTime * 3600);
                            newRow3[3] = transMin(realTime * 3600);
                            newRow3[4] = "";
                            checkListTime4.Rows.Add(newRow3);
                            trailTable[jNum, 0] = 24;
                            trailTable[jNum, 1] = realTime;
                            jNum++;
                        }
                    }

                    while (time30 > 0)
                    {
                        
                        string str = "周期" + i.ToString();
                        if (restTime != 0)
                        {
                            time30 = time30 - restTime;
                            DataRow newRow = checkListTime1.NewRow();
                            newRow[0] = str;
                            newRow[1] = "+30V";
                            newRow[2] = transMin(restTime * 3600);
                            newRow[3] = transMin(restTime * 3600);
                            newRow[4] = "";
                            checkListTime1.Rows.Add(newRow);
                            DataRow newRow1 = checkListTime2.NewRow();
                            newRow1[0] = str;
                            newRow1[1] = "+30V";
                            newRow1[2] = transMin(restTime * 3600);
                            newRow1[3] = transMin(restTime * 3600);
                            newRow1[4] = "";
                            checkListTime2.Rows.Add(newRow1);
                            DataRow newRow2 = checkListTime3.NewRow();
                            newRow2[0] = str;
                            newRow2[1] = "+30V";
                            newRow2[2] = transMin(restTime * 3600);
                            newRow2[3] = transMin(restTime * 3600);
                            newRow2[4] = "";
                            checkListTime3.Rows.Add(newRow2);
                            DataRow newRow3 = checkListTime4.NewRow();
                            newRow3[0] = str;
                            newRow3[1] = "+30V";
                            newRow3[2] = transMin(restTime * 3600);
                            newRow3[3] = transMin(restTime * 3600);
                            newRow3[4] = "";
                            checkListTime4.Rows.Add(newRow3);

                            trailTable[jNum, 0] = 30;
                            trailTable[jNum, 1] = restTime;
                            jNum++;
                            newRow = checkListTime1.NewRow();
                            newRow[0] = str;
                            newRow[1] = "0V";
                            newRow[2] = transMin(waitTime);
                            newRow[3] = transMin(waitTime);
                            newRow[4] = "";
                            checkListTime1.Rows.Add(newRow);
                            newRow1 = checkListTime2.NewRow();
                            newRow1[0] = str;
                            newRow1[1] = "0V";
                            newRow1[2] = transMin(waitTime);
                            newRow1[3] = transMin(waitTime);
                            newRow1[4] = "";
                            checkListTime2.Rows.Add(newRow1);
                            newRow2 = checkListTime3.NewRow();
                            newRow2[0] = str;
                            newRow2[1] = "0V";
                            newRow2[2] = transMin(waitTime);
                            newRow2[3] = transMin(waitTime);
                            newRow2[4] = "";
                            checkListTime3.Rows.Add(newRow2);
                            newRow3 = checkListTime4.NewRow();
                            newRow3[0] = str;
                            newRow3[1] = "0V";
                            newRow3[2] = transMin(waitTime);
                            newRow3[3] = transMin(waitTime);
                            newRow3[4] = "";
                            checkListTime4.Rows.Add(newRow3);
                            trailTable[jNum, 0] = 0;
                            trailTable[jNum, 1] = waitTime1;
                            jNum++;
                            i++;
                            restTime = 0;
                            continue;
                        }
                        time30 -= curTime1;
                        if (time30 > 0)
                        {
                            DataRow newRow = checkListTime1.NewRow();
                            newRow[0] = str;
                            newRow[1] = "+30V";
                            newRow[2] = transMin(curTime);
                            newRow[3] = transMin(curTime);
                            newRow[4] = "";
                            checkListTime1.Rows.Add(newRow);
                            DataRow newRow1 = checkListTime2.NewRow();
                            newRow1[0] = str;
                            newRow1[1] = "+30V";
                            newRow1[2] = transMin(curTime);
                            newRow1[3] = transMin(curTime);
                            newRow1[4] = "";
                            checkListTime2.Rows.Add(newRow1);
                            DataRow newRow2 = checkListTime3.NewRow();
                            newRow2[0] = str;
                            newRow2[1] = "+30V";
                            newRow2[2] = transMin(curTime);
                            newRow2[3] = transMin(curTime);
                            newRow2[4] = "";
                            checkListTime3.Rows.Add(newRow2);
                            DataRow newRow3 = checkListTime4.NewRow();
                            newRow3[0] = str;
                            newRow3[1] = "+30V";
                            newRow3[2] = transMin(curTime);
                            newRow3[3] = transMin(curTime);
                            newRow3[4] = "";
                            checkListTime4.Rows.Add(newRow3);

                            trailTable[jNum, 0] = 30;
                            trailTable[jNum, 1] = curTime1;
                            jNum++;
                            newRow = checkListTime1.NewRow();
                            newRow[0] = str;
                            newRow[1] = "0V";
                            newRow[2] = transMin(waitTime);
                            newRow[3] = transMin(waitTime);
                            newRow[4] = "";
                            checkListTime1.Rows.Add(newRow);
                            newRow1 = checkListTime2.NewRow();
                            newRow1[0] = str;
                            newRow1[1] = "0V";
                            newRow1[2] = transMin(waitTime);
                            newRow1[3] = transMin(waitTime);
                            newRow1[4] = "";
                            checkListTime2.Rows.Add(newRow1);
                            newRow2 = checkListTime3.NewRow();
                            newRow2[0] = str;
                            newRow2[1] = "0V";
                            newRow2[2] = transMin(waitTime);
                            newRow2[3] = transMin(waitTime);
                            newRow2[4] = "";
                            checkListTime3.Rows.Add(newRow2);
                            newRow3 = checkListTime4.NewRow();
                            newRow3[0] = str;
                            newRow3[1] = "0V";
                            newRow3[2] = transMin(waitTime);
                            newRow3[3] = transMin(waitTime);
                            newRow3[4] = "";
                            checkListTime4.Rows.Add(newRow3);
                            trailTable[jNum, 0] = 0;
                            trailTable[jNum, 1] = waitTime1;
                            jNum++;
                            i++;
                        }
                        if (time30 == 0)
                        {
                            DataRow newRow = checkListTime1.NewRow();
                            newRow[0] = str;
                            newRow[1] = "+30V";
                            newRow[2] = transMin(curTime);
                            newRow[3] = transMin(curTime);
                            newRow[4] = "";
                            checkListTime1.Rows.Add(newRow);
                            DataRow newRow1 = checkListTime2.NewRow();
                            newRow1[0] = str;
                            newRow1[1] = "+30V";
                            newRow1[2] = transMin(curTime);
                            newRow1[3] = transMin(curTime);
                            newRow1[4] = "";
                            checkListTime2.Rows.Add(newRow1);
                            DataRow newRow2 = checkListTime3.NewRow();
                            newRow2[0] = str;
                            newRow2[1] = "+30V";
                            newRow2[2] = transMin(curTime);
                            newRow2[3] = transMin(curTime);
                            newRow2[4] = "";
                            checkListTime3.Rows.Add(newRow2);
                            DataRow newRow3 = checkListTime4.NewRow();
                            newRow3[0] = str;
                            newRow3[1] = "+30V";
                            newRow3[2] = transMin(curTime);
                            newRow3[3] = transMin(curTime);
                            newRow3[4] = "";
                            checkListTime4.Rows.Add(newRow3);

                            trailTable[jNum, 0] = 30;
                            trailTable[jNum, 1] = curTime1;

                            newRow = checkListTime1.NewRow();
                            newRow[0] = "结束";
                            checkListTime1.Rows.Add(newRow);
                            newRow1 = checkListTime2.NewRow();
                            newRow1[0] = "结束";
                            checkListTime2.Rows.Add(newRow1);
                            newRow2 = checkListTime3.NewRow();
                            newRow2[0] = "结束";
                            checkListTime3.Rows.Add(newRow2);
                            newRow3 = checkListTime4.NewRow();
                            newRow3[0] = "结束";
                            checkListTime4.Rows.Add(newRow3);
                        }
                        if (time30 < 0)
                        {
                            double realTime = time30 + curTime1;
                            restTime = curTime1 - realTime;

                            DataRow newRow = checkListTime1.NewRow();
                            newRow[0] = str;
                            newRow[1] = "+30V";
                            newRow[2] = transMin(realTime * 3600);
                            newRow[3] = transMin(realTime * 3600);
                            newRow[4] = "";
                            checkListTime1.Rows.Add(newRow);
                            DataRow newRow1 = checkListTime2.NewRow();
                            newRow1[0] = str;
                            newRow1[1] = "+30V";
                            newRow1[2] = transMin(realTime * 3600);
                            newRow1[3] = transMin(realTime * 3600);
                            newRow1[4] = "";
                            checkListTime2.Rows.Add(newRow1);
                            DataRow newRow2 = checkListTime3.NewRow();
                            newRow2[0] = str;
                            newRow2[1] = "+30V";
                            newRow2[2] = transMin(realTime * 3600);
                            newRow2[3] = transMin(realTime * 3600);
                            newRow2[4] = "";
                            checkListTime3.Rows.Add(newRow2);
                            DataRow newRow3 = checkListTime4.NewRow();
                            newRow3[0] = str;
                            newRow3[1] = "+30V";
                            newRow3[2] = transMin(realTime * 3600);
                            newRow3[3] = transMin(realTime * 3600);
                            newRow3[4] = "";
                            checkListTime4.Rows.Add(newRow3);
                            trailTable[jNum, 0] = 30;
                            trailTable[jNum, 1] = realTime;
                            newRow = checkListTime1.NewRow();
                            newRow[0] = "结束";
                            checkListTime1.Rows.Add(newRow);
                            newRow1 = checkListTime2.NewRow();
                            newRow1[0] = "结束";
                            checkListTime2.Rows.Add(newRow1);
                            newRow2 = checkListTime3.NewRow();
                            newRow2[0] = "结束";
                            checkListTime3.Rows.Add(newRow2);
                            newRow3 = checkListTime4.NewRow();
                            newRow3[0] = "结束";
                            checkListTime4.Rows.Add(newRow3);
                        }
                    }
                }
                #endregion
                #region-处理测试结果表格-
                for (int u = 0; u < (periodNum-1); u++)
                {
                    for (int y = 0; y < numShort; y++)
                    {
                        DataRow newRow = checkListShort1.NewRow();
                        newRow[0] = "周期" + (u + 2).ToString();
                        newRow[1] = checkListShort1.Rows[y][1];
                        newRow[2] = checkListShort1.Rows[y][2];
                        newRow[3] = checkListShort1.Rows[y][3];
                        newRow[4] = checkListShort1.Rows[y][4];
                        checkListShort1.Rows.Add(newRow);

                        newRow = checkListShort2.NewRow();
                        newRow[0] = "周期" + (u + 2).ToString();
                        newRow[1] = checkListShort2.Rows[y][1];
                        newRow[2] = checkListShort2.Rows[y][2];
                        newRow[3] = checkListShort2.Rows[y][3];
                        newRow[4] = checkListShort2.Rows[y][4];
                        checkListShort2.Rows.Add(newRow);

                        newRow = checkListShort3.NewRow();
                        newRow[0] = "周期" + (u + 2).ToString();
                        newRow[1] = checkListShort3.Rows[y][1];
                        newRow[2] = checkListShort3.Rows[y][2];
                        newRow[3] = checkListShort3.Rows[y][3];
                        newRow[4] = checkListShort3.Rows[y][4];
                        checkListShort3.Rows.Add(newRow);

                        newRow = checkListShort4.NewRow();
                        newRow[0] = "周期" + (u + 2).ToString();
                        newRow[1] = checkListShort4.Rows[y][1];
                        newRow[2] = checkListShort4.Rows[y][2];
                        newRow[3] = checkListShort4.Rows[y][3];
                        newRow[4] = checkListShort4.Rows[y][4];
                        checkListShort4.Rows.Add(newRow);
                    }
                    if (u == periodNum - 2)
                    {
                        DataRow newRow = checkListShort1.NewRow();
                        newRow[0] = "结束";
                        checkListShort1.Rows.Add(newRow);
                        newRow = checkListShort2.NewRow();
                        newRow[0] = "结束";
                        checkListShort2.Rows.Add(newRow);
                        newRow = checkListShort3.NewRow();
                        newRow[0] = "结束";
                        checkListShort3.Rows.Add(newRow);
                        newRow = checkListShort4.NewRow();
                        newRow[0] = "结束";
                        checkListShort4.Rows.Add(newRow);
                    }
                }

                for (int u = 0; u < (periodNum - 1); u++)
                {
                    for (int y = 0; y < numVolt; y++)
                    {
                        DataRow newRow = checkListVolt1.NewRow();
                        newRow[0] = "周期" + (u + 2).ToString();
                        newRow[1] = checkListVolt1.Rows[y][1];
                        newRow[2] = checkListVolt1.Rows[y][2];
                        newRow[3] = checkListVolt1.Rows[y][3];
                        newRow[4] = checkListVolt1.Rows[y][4];
                        checkListVolt1.Rows.Add(newRow);

                        newRow = checkListVolt2.NewRow();
                        newRow[0] = "周期" + (u + 2).ToString();
                        newRow[1] = checkListVolt2.Rows[y][1];
                        newRow[2] = checkListVolt2.Rows[y][2];
                        newRow[3] = checkListVolt2.Rows[y][3];
                        newRow[4] = checkListVolt2.Rows[y][4];
                        checkListVolt2.Rows.Add(newRow);

                        newRow = checkListVolt3.NewRow();
                        newRow[0] = "周期" + (u + 2).ToString();
                        newRow[1] = checkListVolt3.Rows[y][1];
                        newRow[2] = checkListVolt3.Rows[y][2];
                        newRow[3] = checkListVolt3.Rows[y][3];
                        newRow[4] = checkListVolt3.Rows[y][4];
                        checkListVolt3.Rows.Add(newRow);

                        newRow = checkListVolt4.NewRow();
                        newRow[0] = "周期" + (u + 2).ToString();
                        newRow[1] = checkListVolt4.Rows[y][1];
                        newRow[2] = checkListVolt4.Rows[y][2];
                        newRow[3] = checkListVolt4.Rows[y][3];
                        newRow[4] = checkListVolt4.Rows[y][4];
                        checkListVolt4.Rows.Add(newRow);
                    }
                    if (u == periodNum - 2)
                    {
                        DataRow newRow = checkListVolt1.NewRow();
                        newRow[0] = "结束";
                        checkListVolt1.Rows.Add(newRow);
                        newRow = checkListVolt2.NewRow();
                        newRow[0] = "结束";
                        checkListVolt2.Rows.Add(newRow);
                        newRow = checkListVolt3.NewRow();
                        newRow[0] = "结束";
                        checkListVolt3.Rows.Add(newRow);
                        newRow = checkListVolt4.NewRow();
                        newRow[0] = "结束";
                        checkListVolt4.Rows.Add(newRow);
                    }
                }

                for (int u = 0; u < (periodNum - 1); u++)
                {
                    for (int y = 0; y < (numIOOut + numIOIn + numDA + numAD) * 2; y++)
                    {
                        DataRow newRow = checkListfuction1.NewRow();
                        newRow[0] = "周期" + (u + 2).ToString();
                        newRow[1] = checkListfuction1.Rows[y][1];
                        newRow[2] = checkListfuction1.Rows[y][2];
                        newRow[3] = checkListfuction1.Rows[y][3];
                        newRow[4] = checkListfuction1.Rows[y][4];
                        newRow[5] = checkListfuction1.Rows[y][5];
                        newRow[6] = checkListfuction1.Rows[y][6];
                        newRow[7] = checkListfuction1.Rows[y][7];
                        checkListfuction1.Rows.Add(newRow);

                        newRow = checkListfuction2.NewRow();
                        newRow[0] = "周期" + (u + 2).ToString();
                        newRow[1] = checkListfuction2.Rows[y][1];
                        newRow[2] = checkListfuction2.Rows[y][2];
                        newRow[3] = checkListfuction2.Rows[y][3];
                        newRow[4] = checkListfuction2.Rows[y][4];
                        newRow[5] = checkListfuction2.Rows[y][5];
                        newRow[6] = checkListfuction2.Rows[y][6];
                        newRow[7] = checkListfuction2.Rows[y][7];
                        checkListfuction2.Rows.Add(newRow);

                        newRow = checkListfuction3.NewRow();
                        newRow[0] = "周期" + (u + 2).ToString();
                        newRow[1] = checkListfuction3.Rows[y][1];
                        newRow[2] = checkListfuction3.Rows[y][2];
                        newRow[3] = checkListfuction3.Rows[y][3];
                        newRow[4] = checkListfuction3.Rows[y][4];
                        newRow[5] = checkListfuction3.Rows[y][5];
                        newRow[6] = checkListfuction3.Rows[y][6];
                        newRow[7] = checkListfuction3.Rows[y][7];
                        checkListfuction3.Rows.Add(newRow);

                        newRow = checkListfuction4.NewRow();
                        newRow[0] = "周期" + (u + 2).ToString();
                        newRow[1] = checkListfuction4.Rows[y][1];
                        newRow[2] = checkListfuction4.Rows[y][2];
                        newRow[3] = checkListfuction4.Rows[y][3];
                        newRow[4] = checkListfuction4.Rows[y][4];
                        newRow[5] = checkListfuction4.Rows[y][5];
                        newRow[6] = checkListfuction4.Rows[y][6];
                        newRow[7] = checkListfuction4.Rows[y][7];
                        checkListfuction4.Rows.Add(newRow);
                    }
                    if (u == periodNum - 2)
                    {
                        DataRow newRow = checkListfuction1.NewRow();
                        newRow[0] = "结束";
                        checkListfuction1.Rows.Add(newRow);
                        newRow = checkListfuction2.NewRow();
                        newRow[0] = "结束";
                        checkListfuction2.Rows.Add(newRow);
                        newRow = checkListfuction3.NewRow();
                        newRow[0] = "结束";
                        checkListfuction3.Rows.Add(newRow);
                        newRow = checkListfuction4.NewRow();
                        newRow[0] = "结束";
                        checkListfuction4.Rows.Add(newRow);
                    }
                }

                
           
                #endregion

                    if (skinCheckBox1.Checked == true)
                    {
                        rowMergeView1_Short.DataSource = checkListShort1;
                        RowStyle.SetRowStyle(rowMergeView1_Short, formName);
                        rowMergeView1_Volt.DataSource = checkListVolt1;
                        RowStyle.SetRowStyle(rowMergeView1_Volt, formName);
                        rowMergeView1_Fuction.DataSource = checkListfuction1;
                        RowStyle.SetRowStyle(rowMergeView1_Fuction, formName);
                        rowMergeView1_Time.DataSource = checkListTime1;
                        RowStyle.SetRowStyle(rowMergeView1_Time, formName);
                        flagTestNum |= Convert.ToByte("00000001", 2);

                    }
                if (skinCheckBox1.Checked == false)
                {
                    rowMergeView1_Short.DataSource = null;
                    rowMergeView1_Short.Refresh();
                    rowMergeView1_Volt.DataSource = null;
                    rowMergeView1_Volt.Refresh();
                    rowMergeView1_Fuction.DataSource = null;
                    rowMergeView1_Fuction.Refresh();
                    rowMergeView1_Time.DataSource = null;
                    rowMergeView1_Time.Refresh();
                    flagTestNum &= Convert.ToByte("11111110", 2);
                }
                if (skinCheckBox2.Checked == true)
                {
                    rowMergeView2_Short.DataSource = checkListShort2;
                    RowStyle.SetRowStyle(rowMergeView2_Short, formName);
                    rowMergeView2_Volt.DataSource = checkListVolt2;
                    RowStyle.SetRowStyle(rowMergeView2_Volt, formName);
                    rowMergeView2_Fuction.DataSource = checkListfuction2;
                    RowStyle.SetRowStyle(rowMergeView2_Fuction, formName);
                    rowMergeView2_Time.DataSource = checkListTime2;
                    RowStyle.SetRowStyle(rowMergeView2_Time, formName);
                    flagTestNum |= Convert.ToByte("00000010", 2);
                }
                if (skinCheckBox2.Checked == false)
                {
                    rowMergeView2_Short.DataSource = null;
                    rowMergeView2_Short.Refresh();
                    rowMergeView2_Volt.DataSource = null;
                    rowMergeView2_Volt.Refresh();
                    rowMergeView2_Fuction.DataSource = null;
                    rowMergeView2_Fuction.Refresh();
                    rowMergeView2_Time.DataSource = null;
                    rowMergeView2_Time.Refresh();
                    flagTestNum &= Convert.ToByte("11111101", 2);
                }
                if (skinCheckBox3.Checked == true)
                {
                    rowMergeView3_Short.DataSource = checkListShort3;
                    RowStyle.SetRowStyle(rowMergeView3_Short, formName);
                    rowMergeView3_Volt.DataSource = checkListVolt3;
                    RowStyle.SetRowStyle(rowMergeView3_Volt, formName);
                    rowMergeView3_Fuction.DataSource = checkListfuction3;
                    RowStyle.SetRowStyle(rowMergeView3_Fuction, formName);
                    rowMergeView3_Time.DataSource = checkListTime3;
                    RowStyle.SetRowStyle(rowMergeView3_Time, formName);
                    flagTestNum |= Convert.ToByte("00000100", 2);
                }
                if (skinCheckBox3.Checked == false)
                {
                    rowMergeView3_Short.DataSource = null;
                    rowMergeView3_Short.Refresh();
                    rowMergeView3_Volt.DataSource = null;
                    rowMergeView3_Volt.Refresh();
                    rowMergeView3_Fuction.DataSource = null;
                    rowMergeView3_Fuction.Refresh();
                    rowMergeView3_Time.DataSource = null;
                    rowMergeView3_Time.Refresh();
                    flagTestNum &= Convert.ToByte("11111011", 2);
                }
                if (skinCheckBox4.Checked == true)
                {
                    rowMergeView4_Short.DataSource = checkListShort4;
                    RowStyle.SetRowStyle(rowMergeView4_Short, formName);
                    rowMergeView4_Volt.DataSource = checkListVolt4;
                    RowStyle.SetRowStyle(rowMergeView4_Volt, formName);
                    rowMergeView4_Fuction.DataSource = checkListfuction4;
                    RowStyle.SetRowStyle(rowMergeView4_Fuction, formName);
                    rowMergeView4_Time.DataSource = checkListTime4;
                    RowStyle.SetRowStyle(rowMergeView4_Time, formName);
                    flagTestNum |= Convert.ToByte("00001000", 2);
                }
                if (skinCheckBox4.Checked == false)
                {
                    rowMergeView4_Short.DataSource = null;
                    rowMergeView4_Short.Refresh();
                    rowMergeView4_Volt.DataSource = null;
                    rowMergeView4_Volt.Refresh();
                    rowMergeView4_Fuction.DataSource = null;
                    rowMergeView4_Fuction.Refresh();
                    rowMergeView4_Time.DataSource = null;
                    rowMergeView4_Time.Refresh();
                    flagTestNum &= Convert.ToByte("11110111", 2);
                }
                flag_Confirm = 1;
            }

        }

        private void button_停止老炼键_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
        }
        private double[] ExchangeTime(double[,] time, int number)
        {
            double[] timeResult = new double[number+1];
            for (int i = 0; i <=number; i++)
            {
                timeResult[i] = time[i, 1] * 3600;
            }
            return timeResult;
        }
        unsafe private void timer_Tick(object sender, EventArgs e)
        {            
            if (timeCount <= jNum)
            {
                double order = trailTable[timeCount, 0];

                if (trailSecond[timeCount] == (trailTable[timeCount, 1] * 3600))
                {
                    if (periodflag == 1 || timeCount == 0)//order=0时将perioflag置1，标志下一阶段将为新周期的开始
                    {
                        periodflag = 0;
                        timer_result.Enabled = true;
                        VCI_CAN_OBJ sendobj = new VCI_CAN_OBJ();//实例化sendobj
                        sendobj.SendType = 0;   //发送帧类型，=0时为正常发送，=1时为单次发送，=2时为自发自收，=3时为单次自发自收
                        sendobj.RemoteFlag = 0;
                        sendobj.ExternFlag = 1;
                        sendobj.DataLen = 8;
                        sendobj.ID = 0x10040500;
                        sendobj.Data[0] = 0x55;
                        sendobj.Data[1] = flagTestNum;
                        sendobj.Data[2] = 0x00;
                        if (VCI_Transmit(Can.m_devtype, Can.m_devind, Can.m_canind, ref sendobj, 1) == 0)
                        {
                            MessageBox.Show("发送失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }  
                    if (order == 0)
                    {
                        periodflag = 1;
                        timer_result.Enabled = false;
                        ErroFlag1 = 0;
                        ErroFlag2 = 0;
                        ErroFlag3 = 0;
                        ErroFlag4 = 0;
                        periodcount++;
                        VCI_CAN_OBJ sendobj = new VCI_CAN_OBJ();//实例化sendobj
                        sendobj.SendType = 0;   //发送帧类型，=0时为正常发送，=1时为单次发送，=2时为自发自收，=3时为单次自发自收
                        sendobj.RemoteFlag = 0;
                        sendobj.ExternFlag = 1;
                        sendobj.DataLen = 8;

                        sendobj.ID = 0x10060500;
                        sendobj.Data[0] = 0x44;
                        sendobj.Data[1] = 0x00;
                        if (VCI_Transmit(Can.m_devtype, Can.m_devind, Can.m_canind, ref sendobj, 1) == 0)
                        {
                            MessageBox.Show("发送失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }                                       
                    }
                    if (order == 20)
                    {
                        VCI_CAN_OBJ sendobj = new VCI_CAN_OBJ();//实例化sendobj
                        sendobj.SendType = 0;   //发送帧类型，=0时为正常发送，=1时为单次发送，=2时为自发自收，=3时为单次自发自收
                        sendobj.RemoteFlag = 0;
                        sendobj.ExternFlag = 1;
                        sendobj.DataLen = 8;

                        sendobj.ID = 0x10060500;
                        sendobj.Data[0] = 0x55;
                        sendobj.Data[1] = 0x00;
                        if (VCI_Transmit(Can.m_devtype, Can.m_devind, Can.m_canind, ref sendobj, 1) == 0)
                        {
                            MessageBox.Show("发送失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    if (order == 24)
                    {
                        VCI_CAN_OBJ sendobj = new VCI_CAN_OBJ();//实例化sendobj
                        sendobj.SendType = 0;   //发送帧类型，=0时为正常发送，=1时为单次发送，=2时为自发自收，=3时为单次自发自收
                        sendobj.RemoteFlag = 0;
                        sendobj.ExternFlag = 1;
                        sendobj.DataLen = 8;

                        sendobj.ID = 0x10060500;
                        sendobj.Data[0] = 0x55;
                        sendobj.Data[1] = 0x01;
                        if (VCI_Transmit(Can.m_devtype, Can.m_devind, Can.m_canind, ref sendobj, 1) == 0)
                        {
                            MessageBox.Show("发送失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    if (order == 30)
                    {
                        VCI_CAN_OBJ sendobj = new VCI_CAN_OBJ();//实例化sendobj
                        sendobj.SendType = 0;   //发送帧类型，=0时为正常发送，=1时为单次发送，=2时为自发自收，=3时为单次自发自收
                        sendobj.RemoteFlag = 0;
                        sendobj.ExternFlag = 1;
                        sendobj.DataLen = 8;

                        sendobj.ID = 0x10060500;
                        sendobj.Data[0] = 0x55;
                        sendobj.Data[1] = 0x02;
                        if (VCI_Transmit(Can.m_devtype, Can.m_devind, Can.m_canind, ref sendobj, 1) == 0)
                        {
                            MessageBox.Show("发送失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }                   
                }

               
                        //以下为时间倒计时
                if (trailSecond[timeCount] >= 1)
                {
                    trailSecond[timeCount] -= 1;
                    string str;
                    str = transMin(trailSecond[timeCount]);
                    if ((flagTestNum & 0x01) == 0x01)
                    {
                        checkListTime1.Rows[timeCount][3] = str;
                        rowMergeView1_Time.DataSource = checkListTime1;
                    }
                    if ((flagTestNum & 0x02) == 0x02)
                    {
                        checkListTime2.Rows[timeCount][3] = str;
                        rowMergeView2_Time.DataSource = checkListTime2;
                    }
                    if ((flagTestNum & 0x04) == 0x04)
                    {
                        checkListTime3.Rows[timeCount][3] = str;
                        rowMergeView3_Time.DataSource = checkListTime3;
                    }
                    if ((flagTestNum & 0x08) == 0x08)
                    {
                        checkListTime4.Rows[timeCount][3] = str;
                        rowMergeView4_Time.DataSource = checkListTime4;
                    }
                }
                else
                {
                    string str;
                    str = transMin(0);
                    if ((flagTestNum & 0x01) == 0x01)
                    {
                        checkListTime1.Rows[timeCount][3] = str;
                        rowMergeView1_Time.DataSource = checkListTime1;
                    }
                    if ((flagTestNum & 0x02) == 0x02)
                    {
                        checkListTime2.Rows[timeCount][3] = str;
                        rowMergeView2_Time.DataSource = checkListTime2;
                    }
                    if ((flagTestNum & 0x04) == 0x04)
                    {
                        checkListTime3.Rows[timeCount][3] = str;
                        rowMergeView3_Time.DataSource = checkListTime3;
                    }
                    if ((flagTestNum & 0x08) == 0x08)
                    {
                        checkListTime4.Rows[timeCount][3] = str;
                        rowMergeView4_Time.DataSource = checkListTime4;
                    }
                    timeCount++;
                }                
            }
            else
            {
                timer.Enabled = false;
                MessageBox.Show("老炼结束");
            }

        }

        private void timer_result_Tick(object sender, EventArgs e)
        {
            if ((periodflag != 1) && ((flagTestNum & 0x01) == 0x01))
            {
                if (ErroFlag1 != 1)
                {
                    for (int h = 0 + periodcount * numShort; h < numShort + periodcount * numShort; h++)
                    {
                        if (rowMergeView1_Short.Rows[h].DefaultCellStyle.BackColor == Color.Gold)
                        {
                            ErroFlag1 = 1;
                            break;
                        }
                    }
                }
                if (ErroFlag1 != 1)
                {
                    for (int h = 0 + periodcount * numVolt; h < numVolt + periodcount * numVolt; h++)
                    {
                        if (rowMergeView1_Volt.Rows[h].DefaultCellStyle.BackColor == Color.Gold)
                        {
                            ErroFlag1 = 1;
                            break;
                        }
                    }
                }
                if (ErroFlag1 != 1)
                {
                    for (int h = 0 + periodcount * (numIOOut + numIOIn + numDA + numAD) * 2; h < (periodcount + 1) * (numIOOut + numIOIn + numDA + numAD) * 2; h++)
                    {
                        if (rowMergeView1_Fuction.Rows[h].DefaultCellStyle.BackColor == Color.Gold)
                        {
                            ErroFlag1 = 1;
                            break;
                        }
                    }
                }
                if (ErroFlag1 == 1)
                {
                    for (int h = timeCount; h <= jNum; h++)
                    {
                        if (checkListTime1.Rows[h][0].ToString() == "周期" + (periodcount + 1).ToString())
                        {
                            checkListTime1.Rows[h][4] = "不合格";
                        }
                    }
                    rowMergeView1_Time.DataSource = checkListTime1;
                }
                else
                {
                    for (int h = timeCount; h <= jNum; h++)
                    {
                        if (checkListTime1.Rows[h][0].ToString() == "周期" + (periodcount + 1).ToString())
                        {
                            checkListTime1.Rows[h][4] = "合格";
                        }
                    }
                    rowMergeView1_Time.DataSource = checkListTime1;
                }
            }

            if ((periodflag != 1) && ((flagTestNum & 0x02) == 0x02))
            {
                if (ErroFlag2 != 1)
                {
                    for (int h = 0 + periodcount * numShort; h < numShort + periodcount * numShort; h++)
                    {
                        if (rowMergeView2_Short.Rows[h].DefaultCellStyle.BackColor == Color.Gold)
                        {
                            ErroFlag2 = 1;
                            break;
                        }
                    }
                }
                if (ErroFlag2 != 1)
                {
                    for (int h = 0 + periodcount * numVolt; h < numVolt + periodcount * numVolt; h++)
                    {
                        if (rowMergeView2_Volt.Rows[h].DefaultCellStyle.BackColor == Color.Gold)
                        {
                            ErroFlag2 = 1;
                            break;
                        }
                    }
                }
                if (ErroFlag2 != 1)
                {
                    for (int h = 0 + periodcount * (numIOOut + numIOIn + numDA + numAD) * 2; h < (periodcount + 1) * (numIOOut + numIOIn + numDA + numAD) * 2; h++)
                    {
                        if (rowMergeView2_Fuction.Rows[h].DefaultCellStyle.BackColor == Color.Gold)
                        {
                            ErroFlag2 = 1;
                            break;
                        }
                    }
                }
                if (ErroFlag2 == 1)
                {
                    for (int h = timeCount; h <= jNum; h++)
                    {
                        if (checkListTime2.Rows[h][0].ToString() == "周期" + (periodcount + 1).ToString())
                        {
                            checkListTime2.Rows[h][4] = "不合格";
                        }
                    }
                    rowMergeView2_Time.DataSource = checkListTime2;
                }
                else
                {
                    for (int h = timeCount; h <= jNum; h++)
                    {
                        if (checkListTime2.Rows[h][0].ToString() == "周期" + (periodcount + 1).ToString())
                        {
                            checkListTime2.Rows[h][4] = "合格";
                        }
                    }
                    rowMergeView2_Time.DataSource = checkListTime2;
                }
            }

            if ((periodflag != 1) && ((flagTestNum & 0x04) == 0x04))
            {
                if (ErroFlag3 != 1)
                {
                    for (int h = 0 + periodcount * numShort; h < numShort + periodcount * numShort; h++)
                    {
                        if (rowMergeView3_Short.Rows[h].DefaultCellStyle.BackColor == Color.Gold)
                        {
                            ErroFlag3 = 1;
                            break;
                        }
                    }
                }
                if (ErroFlag3 != 1)
                {
                    for (int h = 0 + periodcount * numVolt; h < numVolt + periodcount * numVolt; h++)
                    {
                        if (rowMergeView3_Volt.Rows[h].DefaultCellStyle.BackColor == Color.Gold)
                        {
                            ErroFlag3 = 1;
                            break;
                        }
                    }
                }
                if (ErroFlag3 != 1)
                {
                    for (int h = 0 + periodcount * (numIOOut + numIOIn + numDA + numAD) * 2; h < (periodcount + 1) * (numIOOut + numIOIn + numDA + numAD) * 2; h++)
                    {
                        if (rowMergeView3_Fuction.Rows[h].DefaultCellStyle.BackColor == Color.Gold)
                        {
                            ErroFlag3 = 1;
                            break;
                        }
                    }
                }
                if (ErroFlag3 == 1)
                {
                    for (int h = timeCount; h <= jNum; h++)
                    {
                        if (checkListTime3.Rows[h][0].ToString() == "周期" + (periodcount + 1).ToString())
                        {
                            checkListTime3.Rows[h][4] = "不合格";
                        }
                    }
                    rowMergeView3_Time.DataSource = checkListTime3;
                }
                else
                {
                    for (int h = timeCount; h <= jNum; h++)
                    {
                        if (checkListTime3.Rows[h][0].ToString() == "周期" + (periodcount + 1).ToString())
                        {
                            checkListTime3.Rows[h][4] = "合格";
                        }
                    }
                    rowMergeView3_Time.DataSource = checkListTime3;
                }
            }

            if ((periodflag != 1) && ((flagTestNum & 0x08) == 0x08))
            {
                if (ErroFlag4 != 1)
                {
                    for (int h = 0 + periodcount * numShort; h < numShort + periodcount * numShort; h++)
                    {
                        if (rowMergeView4_Short.Rows[h].DefaultCellStyle.BackColor == Color.Gold)
                        {
                            ErroFlag4 = 1;
                            break;
                        }
                    }
                }
                if (ErroFlag4 != 1)
                {
                    for (int h = 0 + periodcount * numVolt; h < numVolt + periodcount * numVolt; h++)
                    {
                        if (rowMergeView4_Volt.Rows[h].DefaultCellStyle.BackColor == Color.Gold)
                        {
                            ErroFlag4 = 1;
                            break;
                        }
                    }
                }
                if (ErroFlag4 != 1)
                {
                    for (int h = 0 + periodcount * (numIOOut + numIOIn + numDA + numAD) * 2; h < (periodcount + 1) * (numIOOut + numIOIn + numDA + numAD) * 2; h++)
                    {
                        if (rowMergeView4_Fuction.Rows[h].DefaultCellStyle.BackColor == Color.Gold)
                        {
                            ErroFlag4 = 1;
                            break;
                        }
                    }
                }
                if (ErroFlag4 == 1)
                {
                    for (int h = timeCount; h <= jNum; h++)
                    {
                        if (checkListTime4.Rows[h][0].ToString() == "周期" + (periodcount + 1).ToString())
                        {
                            checkListTime4.Rows[h][4] = "不合格";
                        }
                    }
                    rowMergeView4_Time.DataSource = checkListTime4;
                }
                else
                {
                    for (int h = timeCount; h <= jNum; h++)
                    {
                        if (checkListTime4.Rows[h][0].ToString() == "周期" + (periodcount + 1).ToString())
                        {
                            checkListTime4.Rows[h][4] = "合格";
                        }
                    }
                    rowMergeView4_Time.DataSource = checkListTime4;
                }
            }

        }

        //过阵子试试
        private int timelistresult(RowMergeView ViewShort, RowMergeView ViewVolt, RowMergeView ViewFunction, RowMergeView ViewTime, DataTable TableTime, int erroflag)
        {
            if (erroflag != 1)
            {
                for (int h = 0 + periodcount * numShort; h < numShort + periodcount * numShort; h++)
                {
                    if (ViewShort.Rows[h].DefaultCellStyle.BackColor == Color.Gold)
                    {
                        erroflag = 1;
                        break;
                    }
                }
            }
            if (erroflag != 1)
            {
                for (int h = 0 + periodcount * numVolt; h < numVolt + periodcount * numVolt; h++)
                {
                    if (ViewVolt.Rows[h].DefaultCellStyle.BackColor == Color.Gold)
                    {
                        erroflag = 1;
                        break;
                    }
                }
            }
            if (erroflag != 1)
            {
                for (int h = 0 + periodcount * (numIOOut + numIOIn + numDA + numAD) * 2; h < (periodcount + 1) * (numIOOut + numIOIn + numDA + numAD) * 2; h++)
                {
                    if (ViewFunction.Rows[h].DefaultCellStyle.BackColor == Color.Gold)
                    {
                        erroflag = 1;
                        break;
                    }
                }
            }
            if (erroflag == 1)
            {
                for (int h = timeCount; h <= jNum; h++)
                {
                    if (TableTime.Rows[h][0].ToString()=="周期"+(periodcount+1).ToString())
                    {
                        TableTime.Rows[h][4] = "不合格";
                    }
                }
                ViewTime.DataSource = TableTime;
            }
            else
            {
                for (int h = timeCount; h <= jNum; h++)
                {
                    if (TableTime.Rows[h][0].ToString() == "周期" + (periodcount + 1).ToString())
                    {
                        TableTime.Rows[h][4] = "合格";
                    }
                }
                ViewTime.DataSource = TableTime;
            }
            return erroflag;
        }

        private void pb_MouseHover(object sender, EventArgs e)
        {
            WindowsFormsControlLibrary1.To15picturebox p = sender as WindowsFormsControlLibrary1.To15picturebox;

            if (p.Name.Contains("pbshort"))
            {
                if (p.Lightcolor == "green")
                    p.myTooltip = "短路检测正常";
                if (p.Lightcolor == "red")
                    p.myTooltip = "发生短路";
            }
            if (p.Name.Contains("pbReturn"))
            {
                if (p.Lightcolor == "green")
                    p.myTooltip = "待侧板返回信息";
                if (p.Lightcolor == "red")
                    p.myTooltip = "待测板无法正常返回信息";
            }
        }

    }
}
