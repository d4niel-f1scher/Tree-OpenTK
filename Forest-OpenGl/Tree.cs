using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_OpenGl
{
    public class Tree : IOrganism
    {
        protected virtual float height_increment { get; set; }
        protected virtual float radius_increment{ get; set; }
        ~Tree() { }
        public
            float radius, height, pocet_konarov;
        public virtual
            double Volume
        { get { return Math.PI * Math.Pow(radius, 2) * height * 1.0 / 3.0; } }
        public List<Branch> branches;
        public Tree()
        {
            radius = 0.0f;
            height = 0.0f;
            pocet_konarov = 0;
            branches = new List<Branch>();
            Branch branch1 = new Branch();
            Branch branch2 = new Branch();
            branches.Add(branch1);
            branches.Add(branch2);
        }
        public Tree(float radius, float height, float pocet_konarov)
        {
            this.height = height;
            this.radius = radius;
            this.pocet_konarov = pocet_konarov;
        }
        public void Grow()
        {
            radius = radius + radius_increment;
            height = height + height_increment;
            foreach ( Branch branch in branches) 
            {
                branch.Grow();
            }
        }
        public double vypocitajObjem()
        {
            List<double> volumeBranch = new List<double>();
            double averageVolume = 0.0;
            for (int i = 0; i < volumeBranch.Count(); i++)
                averageVolume += volumeBranch[i];
            try
            {
                averageVolume /= volumeBranch.Count();
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("test riadok 1");
            Console.WriteLine("test");
            return 0;
        }
    }
}
