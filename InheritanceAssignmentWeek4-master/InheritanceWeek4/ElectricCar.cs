using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceWeek4
{
    public class ElectricCar: Vehicle
    {
        public ElectricCar(string make, string model) : base(make,model)
        {
            NumOfGears = 1;
            NumOfTires = 4;
        }

    }
}
