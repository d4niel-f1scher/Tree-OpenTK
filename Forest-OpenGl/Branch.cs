using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_OpenGl
{
	public class Branch
	{
		public float
		height_increment = (0.4572f / 10.0f) / 365.0f,
        radius_increment = (0.0075f / 5.0f) / 365.0f;
		public
            float radius, height;
        public virtual
            double Volume
			{ get { return Math.PI * Math.Pow(radius, 2) * height * 1.0 / 3.0; } }
		public Branch()
		{
			radius = 0.0f;
            height = 0.0f;
		}
		public Branch(float radius, float height)
		{
			this.height = height;
            this.radius = radius;
		}
		~Branch()
		{

		}
		public void Grow() 
		{
			radius = radius + radius_increment;
			height = height + height_increment;
		}
	}
}

