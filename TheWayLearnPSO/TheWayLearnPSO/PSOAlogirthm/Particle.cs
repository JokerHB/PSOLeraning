using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWayLearnPSO.PSOAlogirthm
{
    class Particle
    {
        public double x { get;  set; }
        public double v { get;  set; }
        public double y { get;   set; }
        public double previousBest { get; private set; }

        private delegate double DelegateFitness(double _x);  
        DelegateFitness CalFitness= new DelegateFitness(Algorithm.CalFitness);
        public Particle(double _x = 0.0)
        {
            x = _x;
            v = x / 2 + 1;
            previousBest = -9999999;
        }
        public void Fitness(ref double GlobleBest,ref double GlobleBestX)
        {
            this.y = this.CalFitness(this.x);

            if (this.y > this.previousBest)
            {
                this.previousBest = this.y;
            }
            if (this.previousBest > GlobleBest)
            {
                GlobleBest = this.previousBest;
                GlobleBestX = this.x;
            }
        }
        public bool UpdataSpeed(double GlobleBestX)
        {
            double w = 0.758;
            double c1 = 2.0;
            double c2 = 2.0;

            v = w * v + c1 * this.RandomNum() * (previousBest - x) +
                c2 * this.RandomNum() * (GlobleBestX - x);

            return true;
        }
        public bool UpdataPostion()
        {
           x = v + x;
           if (x > 100 || x < -100)
           {
               Random ra = new Random();
               x = ra.Next(-100,100);
           }
            return true;
        }
        private double RandomNum()
        {
            Random ra = new Random();
            double ans = (double)(ra.Next(0, 1000));

            return ans;
        }
    }
}
