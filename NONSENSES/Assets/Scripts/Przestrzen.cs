using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets
{
    public class Przestrzen
    {
        public float left;
        public float right;
        //definuje stan przestrzeni
        public bool stan;

        public Przestrzen(float ll, float rr,bool ss)
        {
            left = ll;
            right = rr; 
            stan = ss;
        }
        public float Distacne()
        {
            return Math.Abs(left - right);
        }
    }
}
