using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MTF
{
    public partial class Form1 : Form
    {
        int MouseT;
        int aa;
        int bb;
        int cc;
        int dd;
        int Ya;
        int Xa;
        int pixeln;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ToolStripStatusLabel1.Text = DateTime.Now.ToString();
        }
        public static object C2G(Color a)
        {

            double gry = (((0.299 * a.R) + ((0.587 * a.G) + (0.114 * a.B))));

            return Color.FromArgb((int)gry, (int)gry, (int)gry);
         
       
        }
        private void grayToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                Bitmap bmp = (Bitmap)pictureBox1.Image;//宣告一個bmp取自PictureBox1的圖
                Bitmap n = new Bitmap(bmp.Width, bmp.Height);//宣告一個新的跟PictureBox1長寬一樣的bmp

                for (int x = 0; x <= (bmp.Width - 1); x++)//所有Pixel(圖片所有像素跑一次)
                {



                    for (int y = 0; y < (bmp.Width - 1); y++)//丟到計算灰階的Function
                    {
                        Color c = (Color)C2G(bmp.GetPixel(x, y));//最後把運算結果丟回n，也就是上面宣告的空白n，設定於新影像
                        n.SetPixel(x, y, c);
                    }
                }

                pictureBox1.Image = n; //把PictureBox2圖像等於成已經轉成灰階的n
                n.Save("D:\\1.bmp");
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = openFileDialog1.FileName;
            TextBox1.Clear();
            Chart1.Series.Clear();
            Chart1.Series.Add("Series1");

            Chart1.Series["Series1"].ChartType = (System.Windows.Forms.DataVisualization.Charting.SeriesChartType)3;

            PictureBox3.BackColor = SystemColors.Control;
            Tst2.BackColor = SystemColors.Control;

       //Chart1.Series.Add("Series1").ChartType = 3     這個方式也可以
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string R_esume;
        R_esume = DateTime.Now.ToString();
            string path = System.Environment.CurrentDirectory + "\\MTF檔案\\" + R_esume + ".ini";
            File.Delete(path);
            if (File.Exists(path)!=true)
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    
                    sw.WriteLine((Lab_MTF.Text + ("       " + ToolStripStatusLabel1.Text)));
                    sw.WriteLine(TextBox1.Text);
                    sw.Flush();
                }
                MessageBox.Show("OK");
            }
   
        }

        private void mTFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //布雷森漢姆直線演算法
            //每當x的值增加1，誤差的值就會增加m(m=斜率)。每當誤差的值超出0.5 ,線就會比較靠近下一個映像點
            string Result = "";
            int Differ_X;
            int Differ_Y;
            int Distance;
            int Dif_X;
            int Dif_Y;
            Color A;
            double Ar;
            double Ag;
            double Ab;
            double Avg;
            double m;//斜率要函小數
            double mX;//偽斜率要函小數
            double N = 0;//測試
            double Algorithm=0;
            double Algorithm_X=0; //偽斜率
            double Differ_Xx;
            double Differ_Yy;
            double Mm;//判斷斜率正負
            double Min = 255;

            Distance = ((aa - cc) ^ 2 + (bb - dd) ^ 2) ^ (1 / 2);
            //(x)相減(x')=| a |
            //(y)相減(y')=| b |
            Differ_X = Math.Abs(aa - cc);
            Differ_Y = Math.Abs(bb - dd);
            Differ_Xx = (aa - cc);
            Differ_Yy = (bb - dd);


            mX = Differ_X / Differ_Y;  //斜率(XY座標互調使得原本很陡的直線變成不抖的直線)
            m = Differ_Y / Differ_X;   //斜率
            Mm = Differ_Yy / Differ_Xx; //判斷斜率正負


            Dif_X = cc - aa; //判別+-要遞減還是遞增
            Dif_Y = dd - bb; //判別+-要遞減還是遞增

            int[,] ListpointX = new int[3000,3000];   //宣告一個X* Y的二維陣列以存放灰階
            Xa = aa; //等於宣告(a,b)為一個新座標起點
            Ya = bb;

            do  //n+=1遞減遞增到Differ_X or Differ_Y次 (cc,dd)
            {
                N += 1;
                

                Algorithm += m; // 每累計1個N值就累加1個M值,每當誤差的值超出0.5，小的座標差就會進一個像位


                Algorithm_X += mX; //專門為超過斜率1做的偽斜率

                if (Dif_X < 0 && Algorithm_X >= 0.5 )//如果X值是-的 準備做-1遞減  Algorithm值累加到超過0.5就遞減
                {
                    Xa -= 1;
                Algorithm_X -= 1;
                }
                else if (Dif_X > 0 && Algorithm_X >= 0.5)
                {
                    Xa += 1;
                Algorithm_X -= 1;
                }
                else if (Dif_X == 0)
                {
                    Xa += 0;
                }





                if (Dif_Y < 0 && Algorithm >= 0.5)//如果Y值是-的 從動座標準備做-1遞減
                {
                    Ya -= 1;
                Algorithm -= 1;
                }
                else if (Dif_Y > 0 && Algorithm >= 0.5)
                {
                    Ya += 1;
                Algorithm -= 1;
                }
                else if (Dif_Y == 0)//大有小沒有->補上前一個值
                {
                    Ya += 0;
                }


                Bitmap image = (Bitmap)(pictureBox1.Image);
                image.GetPixel(Xa, Ya);
                A = image.GetPixel(Xa, Ya);
           
                Ar = A.R;
                Ag = A.G;
                Ab = A.B;
                Avg = (Ar + Ag + Ab)/3 ;
                ListpointX[Xa, Ya] = (int)Avg; //將得出來的灰階存放在二維陣列

                Chart1.Series["Series1"].Points.AddXY(N, Avg);
                Result = Result + ListpointX[Xa, Ya] + "          " + Xa + "             " + Ya + "            " + N + Environment.NewLine;


                if (Avg < Min)
                {
                    Min = (int)Avg;

                }

                if (Differ_X >= Differ_Y && N == Differ_X)//誰大的做XorY(次) 這邊決定要取幾個座標
                {
                    pixeln = (int)N;
                    break;
                }
                else if (Differ_X < Differ_Y && N == Differ_Y)//誰大的做XorY(次) 這邊決定要取幾個座標
                {
                    pixeln = (int)N;
                    break;
                }

            } while (true);


            TextBox1.Text = "Gray         X              Y" + Environment.NewLine + Result.ToString() + "\r\n" + "Distance:" + Distance.ToString();

            //二個擴展是繪畫斜率為負的直線。可以檢查y0 ≥ y1是否成立；若該不等式成立，誤差超出0.5時y的值改為加-1

            double max = ListpointX.Cast<int>().Max();


            double msg;
            msg = (max - Min) / (max + Min);
            MessageBox.Show("MTF:  " + msg);
            Lab_MTF.Text = "MTF:  " + ((max - Min) / (max + Min));

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            pictureBox1.ImageLocation = openFileDialog1.FileName;
            System.Threading.Thread.Sleep(500);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            Bitmap bmp =new Bitmap(pictureBox1.Image);

            Color c = bmp.GetPixel(e.X, e.Y);
            PictureBox3.BackColor = c; // <- 將點選到的像素顯示在PictureBox3的背景 
            Tst2.BackColor = c;

            if (MouseT == 1)
            {
                MouseT = 2;
            cc = e.X;
            dd = e.Y;
            Label3.Text = e.X.ToString();
            Label4.Text = e.Y.ToString();
            }
            else
            {
                MouseT = 1;
                aa = e.X;
                bb = e.Y;

                Label1.Text = e.X.ToString();
                Label2.Text = e.Y.ToString();

            }
            if (MouseT == 2)
            {
                g.DrawLine(Pens.LimeGreen, aa, bb, cc, dd);
            }
        }
    }
}
