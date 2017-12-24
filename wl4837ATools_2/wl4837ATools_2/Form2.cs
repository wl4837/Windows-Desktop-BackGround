using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.Text.RegularExpressions;
using System.Net;
using System.Threading;
namespace wl4837ATools_2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }
        static int Width;
        static int Height;
        private void Form2_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Bg_Img();
            timer1.Start();
            pictureBox1.Dock = DockStyle.Fill;
            Width = pictureBox1.Width;
            Height = pictureBox1.Height;
            pictureBox1.Dock = DockStyle.None;
            //////////////////////////
            pictureBox1.Width = Width;
            pictureBox1.Height = Height;
            pictureBox1.Left = 0;
            pictureBox1.Top = 0;
            /////////////////////////
            pictureBox2.Width = Width;
            pictureBox2.Height = Height;
            pictureBox2.Left = -Width;
            pictureBox2.Top = 0;
            timer2.Start();
        }

        private void Bg_Img() {
            Random random = new Random();
            label1.Text = (random.Next(1,3).ToString() + random.Next(0,9).ToString() + random.Next(0,9).ToString() + random.Next(1,9).ToString());
            pictureBox2.ImageLocation = "http://img.infinitynewtab.com/wallpaper/" + label1.Text + ".jpg";
            label1.Text = (random.Next(1,3).ToString()+random.Next(0, 9).ToString()+random.Next(0, 9).ToString()+random.Next(1,9).ToString());
            pictureBox1.ImageLocation = "http://img.infinitynewtab.com/wallpaper/" +label1.Text+".jpg";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Bg_Img();
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (pictureBox1.Left >= Width)
            {
                Thread.Sleep(5000);
                pictureBox1.Left = -Width;
            }
            else if (pictureBox2.Left >= Width) {
                Thread.Sleep(5000);
                pictureBox2.Left = -Width;
            }
            else
            {
                pictureBox1.Left+=192;
                pictureBox2.Left+=192;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
