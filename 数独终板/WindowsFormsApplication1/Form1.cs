using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
     
            Form2 fm = new Form2();// 使窗体2实例化
            fm.Show();//显示窗体2
            Form1 f1 = new Form1();// 使窗体1实例化
            f1.Close();//关闭窗体1
        }
    }
}
