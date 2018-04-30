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
        Graphics graphics;
        Ball[] balls = new Ball[100];
        static float clientWidth;
        static float clientHeight;

        public Form1()
        {
            InitializeComponent();
            //for (int i = 0; i < 100; i++)
            //{
            //    balls[i] = new Ball(i + 1);
            //}
            balls[0] = new Ball(150, 100, 3, 2);
            balls[1] = new Ball(10, 10, 3, 2);
            balls[2] = new Ball(90, 10, 3, 2);
            balls[3] = new Ball(25, 200, 3, 2);
            balls[4] = new Ball(130, 15, 3, 2);
            balls[5] = new Ball(60, 70, 3, 2);
            balls[6] = new Ball(10, 100, 3, 2);
            balls[7] = new Ball(30, 130, 3, 2);
            balls[8] = new Ball(90, 25, 3, 2);
            balls[9] = new Ball(180, 45, 3, 2);

            clientWidth = this.ClientSize.Width;
            clientHeight = this.ClientSize.Height;
            this.Paint += Form1_Paint;
            // balls[i].Move(10);
            this.DoubleBuffered = true;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                graphics = e.Graphics;
                SolidBrush brush = new SolidBrush(Color.Blue);
                graphics.FillEllipse(brush, balls[i].rx, balls[i].ry, balls[i].radius, balls[i].radius);
            }

        }

        //private void MoveBall()
        //{
        //    for (int i = 0; i < 10; i++)
        //    {
        //        float newBall_x = balls[i].rx + dx;
        //        float newBall_y = balls[i].ry + dy;

        //        if (newBall_x < -5 || newBall_x > this.ClientSize.Width)
        //            dx = -dx;

        //        if (newBall_y < 0 || newBall_y > this.ClientSize.Height)
        //            dy = -dy;

        //        balls[i].rx += dx;
        //        balls[i].ry += dy;
        //        Invalidate();
        //    }

        //}

        class Ball
        {
            public float rx;
            public float ry;
            public float vx;
            public float vy;
            public float radius;

            public Ball(int x, int y, int vx, int vy)
            {
                rx = x;
                ry = y;
                this.vx = vx;
                this.vy = vy;
                radius = 10;
            }

            public void Move(float dt)
            {
                //if (((rx + (vx * dt)) < radius) || ((rx + (vx * dt)) > 1.0 - radius))
                //{ vx = -vx; }

                //if (((ry + (vy * dt)) < radius) || ((ry + (vy * dt)) > 1.0 - radius))
                //{ vy = -vy; }

                //rx = rx + (vx * dt);
                //ry = ry + (vy * dt);

                float newBall_x = rx + vx * dt;
                float newBall_y = ry + vy * dt;

                if (newBall_x < -5 || newBall_x > clientWidth)
                    vx = -vx;

                if (newBall_y < 0 || newBall_y > clientHeight)
                    vy = -vy;

                rx = rx + vx * dt;
                ry = ry + vy * dt;
                //Invalidate();
            }

            public void Draw()
            {

            }
        }

        private void timer_bouncingBalls_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                balls[i].Move(2);
                Invalidate();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            clientWidth = this.ClientSize.Width;
            clientHeight = this.ClientSize.Height;
        }
    }
}
