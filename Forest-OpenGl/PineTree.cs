using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_OpenGl
{
    public class PineTree : Tree
    {
        
        public PineTree()
        {
            
            height_increment = (0.4572f/2.0f) / 365.0f;
            radius_increment = (0.0075f) / 365.0f;
    }
        ~PineTree()
        {

        }
    }
}
