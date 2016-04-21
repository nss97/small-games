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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        int bian = 40;
        string[,] num = new string[10, 10];
        string strnumber;
        int x, y,count=0,ans=0;//strnumber记录该点的数值，count记录这是第几个点,ans为输赢情况；
        Label []lab = new Label[100];//100个label

        private void Form2_Paint(object sender, PaintEventArgs e)//初始界面
        {
            Pen p = new Pen(Color.Black, 2);//细线
            Pen p1= new Pen(Color.Black, 4);//粗线
            //画格子
            for (int i = 1; i <= 10; i++)
            {
                e.Graphics.DrawLine(p, i * bian, bian, i * bian, 10 * bian);
                e.Graphics.DrawLine(p, bian, i * bian, 10 * bian, i * bian);
            }
            for (int i=1;i<=4;i++)
            {
                e.Graphics.DrawLine(p1, (3*i-2) * bian, bian, (3 * i - 2) * bian, 10 * bian);
                e.Graphics.DrawLine(p1, bian, (3 * i - 2) * bian, 10 * bian, (3 * i - 2) * bian);
            }
            //确定初始值，并画出初始label
            num[1, 1] = "5"; num[2,1] = "7"; num[4,1] = "1"; num[5,1] = "2";
            num[3, 3] = "6"; num[4,3] = "7"; num[8,3] = "8";
            num[1,4] = "3"; num[3,4] = "4"; num[6,4] = "9"; num[8,4] = "7";
            num[2,5] = "2"; num[5, 5] = "7"; num[8,5] = "5";
            num[2,6] = "1"; num[4,6] = "3"; num[7,6] = "9"; num[9,6] = "2";
            num[2,7] = "8"; num[6,7] = "2"; num[7,7] = "4";num[8,7] = "1";
            num[5,9] = "5"; num[6,9] = "4"; num[8,9] = "6"; num[9, 9] = "3";
            for (int i=1;i<10;i++)
                for(int j=1;j<10;j++)
                    if(num[i,j]!=null)
                    {
                        Label lab = new Label();
                        lab.Font = new Font(lab.Font.FontFamily, 20, lab.Font.Style);
                        lab.ForeColor = Color.DarkBlue;
                        lab.Location = new System.Drawing.Point(i * bian + 7, j * bian + 7);
                        lab.Size = new Size(25, 25);
                        lab.Text =num[i,j];
                        this.Controls.Add(lab);
                    }

        }

        private void button2_Click(object sender, EventArgs e)//重新开始
        {
            Form2 fm = new Form2();
            fm.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)//关闭界面
        {
            System.Environment.Exit(0);
        }

        private void button4_Click(object sender, EventArgs e)//更改刚刚填入的数字
        {
            if (num[x, y]!=null)
            {
                strnumber = textBox1.Text;
                num[x, y] = strnumber;
                lab[10 * x + y].Text = strnumber;
                
            }
        }

        private void button1_Click(object sender, EventArgs e)//判断是否正确
        {
            if (num[1, 1] == "5")
                if (num[1, 2] == "7")
                    if (num[1, 3] == "9")
                        if (num[1, 4] == "1")
                            if (num[1, 5] == "2")
                                if (num[1, 6] == "8")
                                    if (num[1, 7] == "6")
                                        if (num[1, 8] == "3")
                                            if (num[1, 9] == "4")
             if (num[2, 1] == "8")
                if (num[2, 2] == "3")
                    if (num[2, 3] == "2")
                        if (num[2, 4] == "5")
                            if (num[2, 5] == "4")
                                if (num[2, 6] == "6")
                                    if (num[2, 7] == "1")
                                        if (num[2, 8] == "9")
                                            if (num[2, 9] == "7")   
            if (num[3, 1] == "1")
                if (num[3, 2] == "4")
                    if (num[3, 3] == "6")
                        if (num[3, 4] == "7")
                            if (num[3, 5] == "9")
                                if (num[3, 6] == "3")
                                    if (num[3, 7] == "2")
                                        if (num[3, 8] == "8")
                                            if (num[3, 9] == "5")    
            if (num[4, 1] == "3")
                if (num[4, 2] == "5")
                    if (num[4, 3] == "4")
                        if (num[4, 4] == "2")
                            if (num[4, 5] == "6")
                                if (num[4, 6] == "9")
                                    if (num[4, 7] == "8")
                                        if (num[4, 8] == "7")
                                            if (num[4, 9] == "1")
            if (num[5, 1] == "9")
                if (num[5, 2] == "2")
                    if (num[5, 3] == "8")
                        if (num[5, 4] == "4")
                            if (num[5, 5] == "7")
                                if (num[5, 6] == "1")
                                    if (num[5, 7] == "3")
                                        if (num[5, 8] == "5")
                                            if (num[5, 9] == "6")
             if (num[6, 1] == "6")
                if (num[6, 2] == "1")
                    if (num[6, 3] == "7")
                        if (num[6, 4] == "3")
                            if (num[6, 5] == "8")
                                if (num[6, 6] == "5")
                                    if (num[6, 7] == "9")
                                        if (num[6, 8] == "4")
                                            if (num[6, 9] == "2")
            if (num[7, 1] == "7")
                if (num[7, 2] == "8")
                    if (num[7, 3] == "5")
                        if (num[7, 4] == "6")
                            if (num[7, 5] == "3")
                                if (num[7, 6] == "2")
                                    if (num[7, 7] == "4")
                                        if (num[7, 8] == "1")
                                            if (num[7, 9] == "9")
            if (num[8, 1] == "4")
                if (num[8, 2] == "6")
                    if (num[8, 3] == "3")
                        if (num[8, 4] == "9")
                            if (num[8, 5] == "1")
                                if (num[8, 6] == "7")
                                    if (num[8, 7] == "5")
                                        if (num[8, 8] == "2")
                                              if (num[8, 9] == "8")
            if (num[9, 1] == "2")
                if (num[9, 2] == "9")
                    if (num[9, 3] == "1")
                        if (num[9, 4] == "8")
                            if (num[9, 5] == "5")
                                if (num[9, 6] == "4")
                                    if (num[9, 7] == "7")
                                        if (num[9, 8] == "6")
                                            if (num[9, 9] == "3")
            {
             ans = 1;
            }
            if(ans==1)
            {
                Form3 fm = new Form3();
                fm.Show();//显示输赢窗体
            }  
            else
            {
                Form4 fm = new Form4();
                fm.Show();//显示输赢窗体
            }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         
        }

        int zuobiao(int a)//坐标函数
        {
            int ans;
            ans = a / bian;
            return ans;
        }
        private void Form2_MouseClick(object sender, MouseEventArgs e)
        {
            x = zuobiao(e.X);
            y = zuobiao(e.Y);
            strnumber = textBox1.Text;

            //判断是否和同行同列已经填过的数重复
            for (int i = 1; i < 10; i++)
                    if (num[x, i] == strnumber || num[i, y] == strnumber)
                    {
                        Form5 fm = new Form5();
                        fm.Show();
                    break;
                    }
            //填入数据
          if (num[x,y] == null&&x > 0&&y>0&&x<10&&y<10)
            {
                count++;
                num[x, y] = strnumber;
                //label设置
                lab[10 * x + y] = new Label();
                lab[10 * x + y].Text = strnumber;
                lab[10 * x + y].Font = new Font(lab[10 * x + y].Font.FontFamily, 20, lab[10 * x + y].Font.Style);
                lab[10 * x + y].Location = new System.Drawing.Point(x * bian + 7, y * bian + 7);
                lab[10 * x + y].Size = new Size(25, 25);
                //label显示
                this.Controls.Add(lab[10 * x + y]);
            }
        }
    }
}
