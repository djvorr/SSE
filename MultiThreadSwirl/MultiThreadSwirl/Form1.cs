using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace MultiThreadSwirl
{
    public partial class Form1 : Form
    {
        Center center;
        Clock clock;
        int padding;
        int radius;
        int angle;
        int density = 5;

        Graphics graphicsObj;

        List<ThreadControl> controls = new List<ThreadControl>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            clock = new Clock(1000);

            //padding = 10;
            angle = 0;

            center = new Center(this.Width/2 + 1, this.Height/2 + 1);
            //int x = Width/2 + 1, y = Height/2 + 1;
            //MessageBox.Show(x + " " + y);

            radius = Width - center.getX();// - padding;

            //Form1_Paint(this, null);
            //MessageBox.Show("");

            Point start = new Point(0, 0);
            Point end = new Point(Width - padding, center.getY());
            Line line = new Line(start, end, Color.Blue, center, radius, 0);
            ThreadControl tc = new ThreadControl(line, clock, density);
            controls.Add(tc);

            Thread thread = new Thread(new ThreadStart(tc.listen));
            thread.Start();

            end = new Point(Width - padding, center.getY());
            line = new Line(start, end, Color.Purple, center, radius, Math.PI);
            line.setAngle(Math.PI);
            tc = new ThreadControl(line, clock, density);
            controls.Add(tc);

            thread = new Thread(new ThreadStart(tc.listen));
            thread.Start();

            end = new Point(Width - padding, center.getY());
            line = new Line(start, end, Color.Red, center, radius, Math.PI / 2);
            line.setAngle(Math.PI / 2);
            tc = new ThreadControl(line, clock, density);
            controls.Add(tc);

            thread = new Thread(new ThreadStart(tc.listen));
            thread.Start();

            end = new Point(Width - padding, center.getY());
            line = new Line(start, end, Color.Yellow, center, radius, Math.PI * 3 / 2);
            line.setAngle(Math.PI * 3 / 2);
            tc = new ThreadControl(line, clock, density);
            controls.Add(tc);

            thread = new Thread(new ThreadStart(tc.listen));
            thread.Start();

            Thread drawthread = new Thread(new ThreadStart(this.Draw));
            drawthread.Start();


            //System.Threading.Thread.Sleep(000);
            //Close();

            //for (int i = 0; i < 1; i++)
            //{
            //    start = new Point(0, 0);
            //    end = new Point(Width - padding, center.getY());
            //    line = new Line(start, end, Color.Blue, center, radius, incrementor.getNext());
            //    controls.Add(new ThreadControl(line));
            //}
            /*
            start = new Point(0, 0);
            end = new Point(Width - padding, center.getY());
            line = new Line(start, end, Color.Blue, center, radius, Math.PI/2);
            controls.Add(new ThreadControl(line));

            start = new Point(0, 0);
            end = new Point(Width - padding, center.getY());
            line = new Line(start, end, Color.Blue, center, radius, Math.PI*2);
            controls.Add(new ThreadControl(line));
            */
            //Form1_Paint(this, null);

        }



        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (ThreadControl control in controls)
            {
                graphicsObj = this.CreateGraphics();
                //Console.WriteLine(control.line.getPen().Color + " " + control.line.getStartX() + " " + 
                //    control.line.getStartY() + " " + control.line.getEndX() +" "+ control.line.getEndY());
                graphicsObj.DrawLine(control.line.getPen(), control.line.getStartX(), control.line.getStartY(), 
                    control.line.getEndX(), control.line.getEndY());
            }

            //Pen tpen = new Pen(Color.Black, 50);
            //Thread.Sleep(50);
            ////Rectangle rectangle = new Rectangle(50, 50, 150, 150);
            //graphicsObj.DrawEllipse(tpen, center.getX()-25, center.getY()-25, 50, 50);
        }

        
        public void Draw()
        {
            while (true)
            {
                Form1_Paint(this, null);
                //Thread.Sleep(100);
            }
        }
        


    }
}
