using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TaskWeek1
{
    class FileRead
    {
        #region-处理配置文件，得到一个int数组，返回值为数组数据个数，数组内容表示测试选择的测试内容的序号-
        public static int[] intCheckList = new int[80];
        public static double[] trailTime = new double[5];//老练时序
        public static string[] strDeal;
        public static int DealFile(string str)
        {
            if (str != null)
            {
                strDeal = str.Split(',');
                int j = 0;


                for (int i = 0; i < strDeal.Length; i++)
                {
                    if (strDeal[i].Contains("IO_OUT"))
                    {

                        intCheckList[j] = int.Parse(strDeal[i].Replace("IO_OUT", ""));
                        j++;
                    }
                }
                for (int i = 0; i < strDeal.Length; i++)
                {
                    if (strDeal[i].Contains("IO_IN"))
                    {
                        intCheckList[j] = int.Parse(strDeal[i].Replace("IO_IN", "")) + 16;
                        j++;
                    }
                }
                for (int i = 0; i < strDeal.Length; i++)
                {
                    if (strDeal[i].Contains("DA"))
                    {

                        intCheckList[j] = int.Parse(strDeal[i].Replace("DA", "")) + 32;
                        j++;
                    }
                }
                for (int i = 0; i < strDeal.Length; i++)
                {
                    if (strDeal[i].Contains("AD"))
                    {

                        intCheckList[j] = int.Parse(strDeal[i].Replace("AD", "")) + 40;
                        j++;
                    }
                }
                return j;
            }
            else
            {
                MessageBox.Show("配置文件处理错误", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        #endregion
        #region-处理时序时间文件-
        public static void DealTrailFile(string str)
        {
            string[] strTrail;
            if (str != null)
            {
                strTrail = str.Split(';');
                for (int i = 0; i < strTrail.Count(); i++)
                {
                    strTrail[i] = strTrail[i].Substring(strTrail[i].IndexOf(':') + 1);
                    trailTime[i] = float.Parse(strTrail[i]);
                }

            }
            else
            {
                MessageBox.Show("老练时序文件处理错误", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region-去除字符串中的数字意外的字符-
        public static string RemoveNotNumber(string key)
        {
            return System.Text.RegularExpressions.Regex.Replace(key, @"[^\d]*", "");
        }
        #endregion
        #region-将时间小时（double）转换为XX:XX的形式-
        public static string TransTime(double time)
        {
            int hour, minute;
            hour = System.Convert.ToInt32(Math.Truncate(time));
            minute = System.Convert.ToInt32((time - Math.Truncate(time)) * 60.0);
            string strHour, strMinute, str;
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
            str = strHour + ":" + strMinute;
            return str;
        }
        #endregion
    }
}
