using System;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ParticleSwarmSearch
{
    public partial class Form1 : Form
    {
        double c1 = 1;
        double c2 = 2;
        double ti = 1;

        static int numParticles = 10;
        int iterations = 10;

        Particle[] particles = new Particle[numParticles];
        Particle[] pbest = new Particle[numParticles];

        public Particle gbest = new Particle();

        Random rand = new Random(0);

        public Form1()
        {
            InitializeComponent();

            Thread t = new Thread(new ThreadStart(this.Swarm));
            t.Start();
        }

        delegate void DrawDelegate();

        public void Draw()
        {
            if (this.chart1.InvokeRequired)
            {
                DrawDelegate d = new DrawDelegate(Graph);
                this.Invoke(d, null);
            }
            else
            {
                Graph();
            }
        }

        public void Graph()
        {
            chart1.Series[0].Points.Clear();

            if (chart1.Series[0].Points.Count > 0)
                chart1.Series[0].Points.Clear();

            chart1.Series[0].ChartType = SeriesChartType.Point;
            chart1.Series[0].MarkerStyle = MarkerStyle.Circle;
            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisY.Interval = 1;
            chart1.ChartAreas[0].AxisX.Maximum = 5;
            chart1.ChartAreas[0].AxisX.Minimum = -5;
            chart1.ChartAreas[0].AxisY.Maximum = 5;
            chart1.ChartAreas[0].AxisY.Minimum = -5;

            foreach (Particle p in particles)
            {
                chart1.Series[0].Points.Add(new DataPoint(p.pX, p.pY));
            }
        }

        public void Swarm()
        {
            buildSwarm();

            for (int i = 0; i < iterations; i++)
            {
                if (i == 11)
                    Console.WriteLine("11");

                doSwarm();
                Console.WriteLine("gBest: " + gbest.pX.ToString() + " " + gbest.pY.ToString() + " " + gbest.fit.ToString());

                Draw();
            }
        }

        public void buildSwarm()
        {

            gbest.fit = -1000;

            for (int i = 0; i < numParticles; i++)
            {
                particles[i] = new Particle();

                particles[i].pX = getPos();
                particles[i].pY = getPos();
                particles[i].fit = Fit(particles[i].pX, particles[i].pY);

                particles[i].vX = getVel();
                particles[i].vY = getVel();

                pbest[i] = new Particle();

                pbest[i].pX = particles[i].pX;
                pbest[i].pY = particles[i].pY;
                pbest[i].fit = particles[i].fit;
            }
        }

        public void doSwarm()
        {
            for (int i = 0; i < numParticles; i++)
            {
                moveParticle(i);

                if (particles[i].fit > pbest[i].fit)
                    setPbest(i);
            }
        }

        public void moveParticle(int index)
        {
            updatePosition(index);

            particles[index].fit = Fit(particles[index].pX, particles[index].pY);

            updateVelocities(index);
        }

        public void updatePosition(int index)
        {
            particles[index].pX += particles[index].vX * ti;
            particles[index].pY += particles[index].vY * ti;
        }

        public void updateVelocities(int index)
        {
            //v[] = v[] + c1 * rand() * (pbest[] - present[]) + c2 * rand() * (gbest[] - present[])
            particles[index].vX = particles[index].vX +
                (c1 * rand.NextDouble() * (pbest[index].vX - particles[index].vX) +
                    c2 * rand.NextDouble() * (gbest.vX - particles[index].vX));

            Thread.Sleep(50);

            particles[index].vY = particles[index].vY +
                (c1 * rand.NextDouble() * (pbest[index].vY - particles[index].vY) +
                    c2 * rand.NextDouble() * (gbest.vY - particles[index].vY));

            Thread.Sleep(50);
        }

        public double getPos()
        {
            Thread.Sleep(50);

            double r = rand.Next(3);

            if (rand.Next() % 2 == 0)
                return r;
            else
                return 1 - r;
        }

        public double Fit(double x, double y)
        {
            return 6 * Math.Cos(Math.Sqrt(x * x + y * y)) / (x * x + y * y + 6);
        }

        public double getVel()
        {
            Thread.Sleep(50);

            double r = rand.NextDouble();

            if (rand.Next() % 2 == 0)
                return r;
            else
                return 1 - r;
        }

        public void setPbest(int index)
        {
            pbest[index].pX = particles[index].pX;
            pbest[index].pY = particles[index].pY;
            pbest[index].fit = particles[index].fit;

            if (pbest[index].fit > gbest.fit)
            {
                gbest.pX = pbest[index].pX;
                gbest.pY = pbest[index].pY;
                gbest.fit = pbest[index].fit;
            }
        }
    }
}
