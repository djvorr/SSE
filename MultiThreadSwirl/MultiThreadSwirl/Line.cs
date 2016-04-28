using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MultiThreadSwirl
{
    public class Line
    {
        Point start, end;
        Pen pen;
        Form1 scope;
        double angle;
        Center center;
        int radius;

        public Line(Point start, Point end, Color color, Center center, int radius, double angle)
        {
            this.start = start;
            this.end = end;
            this.center = center;
            this.start.setX(center.getX());
            this.start.setY(center.getY());
            this.radius = radius;
            setColor(color);
            this.angle = angle;
            setAngle(angle);
        }

        public void setAngle(double angle)
        {
            this.angle = angle;
            doMath();
        }

        public double getAngle()
        { return angle; }

        public void doMath()
        {
            //Center center = new Center(0,0);
            Console.WriteLine("1. x: " + end.getX() + "  y: " + end.getY() + "  angle: " + angle);
            //parametric equation
            end.setX(Convert.ToInt32(center.getX() + radius * Math.Cos(angle)));
            end.setY(Convert.ToInt32(center.getY() + radius * Math.Sin(angle)));

            Console.WriteLine("1. x: " + end.getX() + "  y: " + end.getY() + "  angle: " + angle);
        }

        public void setColor(Color color)
        {
            pen = new Pen(color, 50);
        }

        public Pen getPen()
        { return pen; }

        public int getStartX()
        { return start.getX(); }

        public int getStartY()
        { return start.getY(); }

        public int getEndX()
        { return end.getX(); }

        public int getEndY()
        { return end.getY(); }

        public void Draw()
        {
            //scope.Draw(scope, null, this);
        }
    }
}
