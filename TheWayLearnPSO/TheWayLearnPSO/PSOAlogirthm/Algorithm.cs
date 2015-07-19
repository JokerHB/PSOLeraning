using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TheWayLearnPSO.PSOAlogirthm
{
    class Algorithm
    {
        public const int MAX_PARTICLE = 1000;
        public const int MAX_CHANGE = 100;
        public double GlobleBestFitness = -9999999;
        public double GlobeBestX = -9999999;

        List<Particle> particles = new List<Particle>(MAX_PARTICLE);

        public Algorithm()
        {
            for (int i = 0; i < MAX_PARTICLE; i++)
            {
                Random rd = new Random();

                Particle newParticle = new Particle(rd.Next(-100,100));

                particles.Add(newParticle);
            }
        }
        public List<Polyline> Graph()
        {
            List<Polyline> lines = new List<Polyline>(MAX_PARTICLE);

            for (int i = 0; i < MAX_PARTICLE; i++)
            {
                Polyline lineTemp = new Polyline();
                lineTemp.VerticalAlignment = VerticalAlignment.Center;
                lineTemp.Stroke = SystemColors.WindowTextBrush;
                lineTemp.StrokeThickness = 5;

                lineTemp.Points.Add(new Point(particles[i].x,particles[i].y));
                lineTemp.Points.Add(new Point(particles[i].x + 1,particles[i].y + 1));

                lines.Add(lineTemp);
            }

            return lines;
        }
        public static double  CalFitness(double x)
        {
            return x;
        }

        public bool Running()
        {
                for (int j = 0; j < MAX_PARTICLE; j++)
                {
                    particles[j].Fitness(ref this.GlobleBestFitness,ref this.GlobeBestX);
                }

                for (int j = 0; j < MAX_PARTICLE; j++)
                {
                    particles[j].UpdataSpeed(GlobeBestX);
                }

                for (int j = 0; j < MAX_PARTICLE; j++)
                {
                    particles[j].UpdataPostion();
                }
          
            return true;
        }
    }
}
