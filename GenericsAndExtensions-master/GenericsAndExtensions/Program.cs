using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsAndExtensions
{
    public class Program
    {

        
        static void Main(string[] args)
        {
            
            Shop<Truck>.ChangeOil();          
            Shop<Truck>.FillUp(Truck.gasType);
            Shop<Truck> truck = new Shop<Truck>();
            truck.ChangeTire(Truck.TireType);

            Shop<RaceCar>.ChangeOil();
            Shop<RaceCar>.FillUp(RaceCar.gasType);
            Shop<RaceCar> car = new Shop<RaceCar>();
            car.ChangeTire(Sedan.TireType);

            Shop<Sedan>.ChangeOil();
            Shop<Sedan>.FillUp(Sedan.gasType);
            Shop<Sedan> sedan = new Shop<Sedan>();
            sedan.ChangeTire(Sedan.TireType);

            Console.ReadLine();
        }
    }
}
