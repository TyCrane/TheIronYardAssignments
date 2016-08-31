using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceWeek4
{
    class Trike : Motorcycle
    {
        public Trike(string make, string model) : base(make, model)
        {
            NumOfTires = 3;
        }
    }
}
