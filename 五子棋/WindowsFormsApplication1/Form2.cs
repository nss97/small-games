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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        int bianchang=40;//棋格边长
        public int x, y,num=0;//记录点击下棋的棋子坐标,和已经下过的棋子数
        int[,] point=new int[18, 18];//声明数组时，方括号 ([]) 必须跟在类型后面，而不是变量名后面。在 C# 中，将方括号放在变量名后是不合法的语法。
        //记录该点是否有子，无为0，黑1，白2；
        int[] jilux=new int [400];
        int[] jiluy = new int[400];
        //int huiqi=0;

        int zuobiao(int a)//坐标函数，用以求得离该点最近的格点
        {
            int ans;
            ans = a / 40;
            if (a % 40 > 20)
                ans++;
            return ans;
        }
        int judge(int x,int y,int color)/*判断输赢函数*/
        {
            int number=1, xx, yy;
            //number记录已经有多少个连续，xx，yy记录已经找到第几个
            for (xx = x + 1, yy = y ; ; xx++)
            {
                if (point[xx, yy] == color)
                    number++;
                else break;
            }
            for (xx = x -1, yy = y; ; xx--)
            {
                if (point[xx, yy] == color)
                    number++;
                else break;
            }
            if (number >= 5) return 1;
            else number = 1;
            //横向判断是否五个连起来
            for (xx = x , yy = y+1; ; yy++)
            {
                if (point[xx, yy] == color)
                    number++;
                else break;
            }
            for (xx = x , yy = y-1; ; yy--)
            {
                if (point[xx, yy] == color)
                    number++;
                else break;
            }
            if (number >= 5) return 1;
            else number = 1;
            //纵向判断是否五个连起来
            for (xx = x+1, yy = y + 1; ; yy++,xx++)
            {
                if (point[xx, yy] == color)
                    number++;
                else break;
            }
            for (xx = x-1, yy = y - 1; ; yy--,xx--)
            {
                if (point[xx, yy] == color)
                    number++;
                else break;
            }
            if (number >= 5) return 1;
            else number = 1;

            for (xx = x + 1, yy = y - 1; ; yy--, xx++)
            {
                if (point[xx, yy] == color)
                    number++;
                else break;
            }
            for (xx = x - 1, yy = y + 1; ; yy++, xx--)
            {
                if (point[xx, yy] == color)
                    number++;
                else break;
            }
            if (number >= 5) return 1;
            else return 0;
            //斜着判断是否五个连起来
        }

        

        private void button1_Click(object sender, EventArgs e)//关闭程序
        {
            System.Environment.Exit(0);
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            Form2 fm = new Form2();
            fm.Show();
            this.Close();
        }
        //重新开始游戏，初始化
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            x = zuobiao(e.X);
            y = zuobiao(e.Y);
            if (point[x, y] == 0 && x > 0 && y > 0 && x < 17 && y < 17)
            {
                num++;
                jilux[num] = x;
                jiluy[num] = y;
                if (num % 2 == 0) point[x, y] = 2;
                else point[x, y] = 1;
                /*计算此处颜色*/
                Graphics graph = this.pictureBox1.CreateGraphics();/*新建一个画布*/
                graph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;/*让画出的图像更圆滑*/
                Brush bush;/*新建画刷*/
                if (point[x, y] == 1)
                    bush = new SolidBrush(Color.Black);
                else
                    bush = new SolidBrush(Color.White);
                /*画刷颜色确定*/
                graph.FillEllipse(bush, x * bianchang - 15, y * bianchang - 15, 30, 30);
                //画棋子  
                if(judge(x, y, point[x, y])==1)
                {
                    System.Media.SoundPlayer sp = new SoundPlayer();
                    sp.SoundLocation = @"2.wav";
                    sp.PlayLooping();
                    if (num % 2 == 1)
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
                if (num % 2 == 0)
                {
                    label1.Text = "黑方落子";
                }
                else label1.Text = "白方落子";
                label1.Refresh();
                //更改提示语 
                Console.Beep(1000, 140);
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)//添加 Form_paint事件
        {
            Pen p = new Pen(Color.Black, 2);//创建一支新的画笔p，颜色为黑,宽度2
            for (int i = 0; i < 16; i++)//画16条线，作为棋盘
            {
                e.Graphics.DrawLine(p, 40 + i * bianchang, 40, 40 + i * bianchang, 40 + 15 * bianchang);//画竖线(x1,y1)(x2,y2)
                e.Graphics.DrawLine(p, 40, 40 + i * bianchang, 40 + 15 * bianchang, 40 + i * bianchang);//画横线(x1,y1)(x2,y2)
            }
            //悔棋之后，使其他（非悔棋）的棋子重绘
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;/*让画出的图像更圆滑*/
            Brush bush;
            for (int k = 1; k < 18; k++)
                for (int i = 1; i < 18; i++)
                {
                    if (point[i, k] != 0)
                    {
                        if (point[i, k] == 1)
                            bush = new SolidBrush(Color.Black);
                        else
                            bush = new SolidBrush(Color.White);
                        e.Graphics.FillEllipse(bush, i * bianchang - 15, k * bianchang - 15, 30, 30);
                    }
                }
            if (num % 2 == 0)
            {
                label1.Text = "黑方落子";
            }
            else label1.Text = "白方落子";
            label1.Refresh();
            //更改提示语 
        }

        private void button3_Click(object sender, EventArgs e)//悔棋
        {
            if(point[jilux[num], jiluy[num]] != 0)
            {
                point[jilux[num], jiluy[num]] = 0;
                num--;
                pictureBox1.Invalidate(); //控制form重绘
            }
        }
    }
}
