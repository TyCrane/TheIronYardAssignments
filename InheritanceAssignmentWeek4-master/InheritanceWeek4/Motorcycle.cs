using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceWeek4
{
    class Motorcycle : Vehicle
    {
        public Motorcycle(string make, string model) : base(make, model)
        {
            NumOfGears = 4;
            NumOfTires = 2;
        }
    }
        

}
