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
using TaskWeek1.FunctionModule;

namespace TaskWeek1
{
    public partial class FormPass : Form
    {
        private String formName; 
        private FormPeizhi formPeizhi;
        private Form paForm;
        private String[] IDPassWord;
        public FormPass(Form parent, String formname)
        {
            InitializeComponent();
            paForm = parent;
            formName = formname;
        }
        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_Transmit(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd, ref VCI_CAN_OBJ pSend, UInt32 Len);
        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_GetReceiveNum(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd);
        [DllImport("controlcan.dll", CharSet = CharSet.Ansi)]
        static extern UInt32 VCI_Receive(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd, IntPtr pReceive, UInt32 Len, Int32 WaitTime);
        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_CloseDevice(UInt32 DeviceType, UInt32 DeviceInd);

        private void loginClicked(object sender, EventArgs e)
        {
            IDPassWord = new String[] { textBox_ID.Text, textBox_PassWord.Text };
            SQLITE sq = new SQLITE("TestSystem");
            sq.TableName = "IDAndPassword";

            if (textBox_ID.Text != "" && textBox_PassWord.Text != "")
            {
                if (textBox_PassWord.Text == sq.selectData(IDPassWord))
                {
                    this.Close();
                    //VCI_CloseDevice(Can.m_devtype, Can.m_devind);
                    paForm.Close();
                    formPeizhi = new FormPeizhi(formName);
                    formPeizhi.Show();

                    //new Thread(() => Application.Run(new FormZuhebanPeizhi())).Start();
                }
                else
                    this.label1.Text = "账号或密码不正确";
            }
            else
                this.label1.Text = "账号或密码不能为空";
        }

        private void closeClicked(object sender, EventArgs e)
        {
            this.Close();
        }

        private void changePasswordButton_Click(object sender, EventArgs e)
        {
            passwordPanel.SendToBack();
        }

        private void returnButton_Click(object sender, EventArgs e)
        {
            changePasswordPanel.SendToBack();
        }

        private void changeOKButton_Click(object sender, EventArgs e)
        {
            IDPassWord = new String[] { changePasswordIDTextbox.Text, changePasswordOldTextbox.Text };
            SQLITE sq = new SQLITE("TestSystem");
            sq.TableName = "IDAndPassword";

            if (changePasswordIDTextbox.Text != "" && changePasswordOldTextbox.Text != "" && changePasswordNewTextbox.Text != "")
            {
                if (changePasswordOldTextbox.Text == sq.selectData(IDPassWord))
                {
                    sq.updateData(IDPassWord, changePasswordNewTextbox.Text);
                    changePasswordLabel.Text = "修改完成";
                }
                else
                    changePasswordLabel.Text = "账号或密码不正确";
            }
            else
                changePasswordLabel.Text = "账号或密码不能为空";

        }

      
    }
}
