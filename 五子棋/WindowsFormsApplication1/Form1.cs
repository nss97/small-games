using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Visible = false;//隐藏本界面
            Form2 fm = new Form2();// 使窗体2实例化
            fm.Show();//显示窗体2
            Form1 f1 = new Form1();// 使窗体1实例化
            f1.Close();//关闭窗体1
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();//关闭当前窗口,退出程序；
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Media.SoundPlayer sp = new SoundPlayer();
            sp.SoundLocation = @"1.wav";
            sp.PlayLooping();

        }
    }
}
