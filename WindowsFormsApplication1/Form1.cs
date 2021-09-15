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
        Graph g = new Graph();
		int N ;
		int[] cordx ;
		int[] cordy ;
		int rebra = 0;
        int put = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            	 N=Convert.ToInt32(textBox1.Text);
				 this.textBox1.Text = "";
                 cordy = new int[N];
                 cordx = new int[N];
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
             int a1, a2, a3;
			 a1 = Convert.ToInt32(textBox2.Text);
			 a2 = Convert.ToInt32(textBox3.Text);
			 a3 = Convert.ToInt32(textBox4.Text);
			 this.textBox2.Text = "";
			 this.textBox3.Text = "";
			 this.textBox4.Text = "";
			 g.AddVer(rebra,a1,a2,a3);
			 rebra++;
			 Graphics u = pictureBox1.CreateGraphics();
			 Pen k = new Pen(Color.DarkRed, 2);
			 System.Drawing.Font shr = new System.Drawing.Font(FontFamily.GenericSansSerif, 8.0F, FontStyle.Regular);
       
			
			 u.DrawLine(k, cordx[a1 - 1], cordy[a1 - 1], cordx[a2 - 1], cordy[a2 - 1]);
			 u.DrawString(Convert.ToString(a3),shr, Brushes.DarkOrange,(cordx[a2 - 1] + cordx[a1 - 1]) / 2+7, (cordy[a2 - 1] + cordy[a1 - 1]) / 2+3);
             u.FillEllipse(Brushes.White, cordx[a1 - 1] - 9, cordy[a1 - 1] - 9, 18, 18);
            u.FillEllipse(Brushes.White, cordx[a2 - 1] - 9, cordy[a2 - 1] - 9, 18, 18);
            u.DrawString(Convert.ToString(a1), shr, Brushes.Blue, cordx[a1 - 1] - 5, cordy[a1 - 1]-9);
            u.DrawString(Convert.ToString(a2), shr, Brushes.Blue, cordx[a2 - 1] - 5, cordy[a2 - 1]-9);
                 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            	 Graphics u = pictureBox1.CreateGraphics();
				 Pen k = new Pen(Color.Black, 1);
				 System.Drawing.Font shr = new System.Drawing.Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Regular);
				 double a = (2 * 3.14) / N;
                 u.FillRectangle(Brushes.White, 0, 0, 300, 300);
                 for (int p = 0; p < N; p++)
                 {
                     int x = Convert.ToInt32(80 * Math.Cos(a * (p))) + 120;
                     int y = Convert.ToInt32(80 * Math.Sin(a * (p))) + 90;
                     cordx[p] = x + 10;
                     cordy[p] = y + 10;
                     u.DrawEllipse(k, x, y, 20, 20);
                     u.DrawString(Convert.ToString(p + 1), shr, Brushes.Blue, x + 5, y);
                 }
        }

        private void button4_Click(object sender, EventArgs e)
        {
             Graphics u = pictureBox2.CreateGraphics();
			 Pen k = new Pen(Color.Black, 1);
             Pen kk = new Pen(Color.DarkRed, 2); 
            System.Drawing.Font shr = new System.Drawing.Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Regular);
			 double a = (2 * 3.14) / N;
			 
			 for (int p = 0; p < N; p++)
			 {
				 int x = Convert.ToInt32(80 * Math.Cos(a * (p))) + 120;
				 int y = Convert.ToInt32(80 * Math.Sin(a * (p))) + 90;
				 cordx[p] = x + 10;
				 cordy[p] = y + 10;
				 u.DrawEllipse(k, x, y, 20, 20);
				 u.DrawString(Convert.ToString(p + 1), shr, Brushes.Blue, x + 5, y);

			 }
			 g.sort(rebra);

			 String[] mnog=new String[N/2];
             for (int oo = 0; oo < N / 2; oo++)
                 mnog[oo] = "ZERO";

             int ssize = 1;

                 for (int z = 0; z < rebra; z++)
                 {
                     bool yes = true;
                     int a1, a2, a3;
                     a1 = g.GiveRebrIz(z);
                     a2 = g.GiveRebrTo(z);
                     a3 = g.GiveRebrVes(z);
                     String h = Convert.ToString(a1) + " " + Convert.ToString(a2)+" ";
                     int prov = -1;
                     int schetchik = 0;
                     
                     if (z == 0)
                         mnog[z] = h;
                     else
                     {
                         for (int y = 0; y < ssize; y++)
                         {
                             int aa = mnog[y].IndexOf(Convert.ToString(a1));
                             int aa2 = mnog[y].IndexOf(Convert.ToString(a2));
                             if (aa != -1 && aa2 != -1)
                                 yes = false;
                             else
                             {
                                 if (aa == -1 && aa2 == -1)
                                 {
                                     schetchik++;
                                 }
                                 if (prov != -1 && ((aa != -1 && aa2 == -1) || (aa == -1 && aa2 != -1)))
                                 {
                                     mnog[y] = mnog[y] + mnog[prov];
                                     mnog[prov] = "DELETED";
                                 }
                                 if (prov == -1 && aa != -1 && aa2 == -1)
                                 {
                                     mnog[y] = mnog[y] + " " + Convert.ToString(a2);
                                     prov = y;
                                 }

                                 if (prov == -1 && aa == -1 && aa2 != -1)
                                 {
                                     mnog[y] = mnog[y] + " " + Convert.ToString(a1);
                                     prov = y;
                                 }
                             }
                         }
                         if (schetchik == ssize)
                             mnog[z] = h;
                         if (ssize < (N / 2)) 
                         ssize++;
                     }

                     if (yes)
                     {
                         System.Threading.Thread.Sleep(600);
                         u.DrawLine(kk, cordx[a1 - 1], cordy[a1 - 1], cordx[a2 - 1], cordy[a2 - 1]);
                         u.DrawString(Convert.ToString(a3), shr, Brushes.DarkOrange, (cordx[a2 - 1] + cordx[a1 - 1]) / 2+7, (cordy[a2 - 1] + cordy[a1 - 1]) / 2+3);
                         u.FillEllipse(Brushes.White, cordx[a1 - 1] - 9, cordy[a1 - 1] - 9, 18, 18);
                         u.FillEllipse(Brushes.White, cordx[a2 - 1] - 9, cordy[a2 - 1] - 9, 18, 18);
                         u.DrawString(Convert.ToString(a1), shr, Brushes.Blue, cordx[a1 - 1] - 5, cordy[a1 - 1] - 9);
                         u.DrawString(Convert.ToString(a2), shr, Brushes.Blue, cordx[a2 - 1] - 5, cordy[a2 - 1] - 9);
                         put += a3;
                     }
                 }
                 textBox5.Text = Convert.ToString(put);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
