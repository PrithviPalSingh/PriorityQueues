using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BouncingBalls
{
    public partial class Form1 : Form
    {
        Ball[] balls = new Ball[100];

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            for (int i = 0; i < 100; i++)
            {
                Random r = new Random();
                var num = 1;
                balls[i] = new Ball(num + i, num + i, num, num + 1, num);
            }
        }

        class Ball
        {
            public float px;
            public float py;
            public float vx;
            public float vy;
            public float radius;

            public Ball(float x, float y, float vx, float vy, float radius)
            {
                px = x;
                py = y;
                this.vx = vx;
                this.vy = vy;
                this.radius = radius;
            }

            public void Move(float dt)
            {
                if (((px + (vx * dt)) < radius) || ((px + (vx * dt)) > 1.0 - radius))
                { vx = -vx; }

                if (((py + (vy * dt)) < radius) || ((py + (vy * dt)) > 1.0 - radius))
                { vy = -vy; }

                px = px + (vx * dt);
                py = py + (vy * dt);
            }

            public void Draw()
            {

            }
        }

        private void Form1_MouseEnter(object sender, EventArgs e)
        {
            while (true)
            {
                for (int i = 0; i < 100; i++)
                {
                    balls[i].Move((float)0.5);
                    Graphics g = Graphics.FromHwndInternal(((Form)sender).Handle);
                    g.DrawEllipse(new Pen(Brushes.Black), balls[i].px, balls[i].py, balls[i].radius, balls[i].radius);
                }
            }

        }
    }
}
