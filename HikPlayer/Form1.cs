using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using HikPlayer.HikPlayerSDK;

namespace HikPlayer
{
    public partial class Form1 : Form
    {
        int playport = -1;
        public Form1()
        {
            InitializeComponent();
          
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            bool openfile = HikPlayer.HikPlayerSDK.HikPlayer.PlayM4_OpenFile(playport,"weightcheck.mp4");
            if (openfile == false)
                MessageBox.Show("打开文件失败");
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            bool getport = HikPlayer.HikPlayerSDK.HikPlayer.PlayM4_GetPort(ref playport);
            if (getport == false)
                MessageBox.Show("获取闲置端口失败");
            bool openfile = HikPlayer.HikPlayerSDK.HikPlayer.PlayM4_OpenFile(playport, "weightcheck.mp4");
            if (openfile == false)
                MessageBox.Show("打开文件失败");
            IntPtr render_WM = panel1.Handle;
            bool play=HikPlayer.HikPlayerSDK.HikPlayer.PlayM4_Play(playport, render_WM);
            if (play == false)
                MessageBox.Show("播放失败");
            else {
               
                Task.Factory.StartNew(()=> {
                    while (true)
                    {
                        float pos = HikPlayer.HikPlayerSDK.HikPlayer.PlayM4_GetPlayPos(playport);
                        this.Invoke((MethodInvoker)delegate {
                            label1.Text = $"当前播放进度:{pos}";
                        });
                        if (pos >= 1)
                        {
                            bool stop=HikPlayer.HikPlayerSDK.HikPlayer.PlayM4_Stop(playport);
                            if (stop == false)
                                MessageBox.Show("停止播放失败!");

                            bool closefile = HikPlayer.HikPlayerSDK.HikPlayer.PlayM4_CloseFile(playport);
                            if (closefile == false)
                            {
                                MessageBox.Show("关闭文件失败!");
                            }
                            bool freeport=HikPlayer.HikPlayerSDK.HikPlayer.PlayM4_FreePort(playport);
                            if (freeport == false)
                            {
                                MessageBox.Show("释放资源失败!");
                            }
                            return;
                        }
                        
                        Thread.Sleep(1000);
                    }
                });
            }
        }
    }
}
