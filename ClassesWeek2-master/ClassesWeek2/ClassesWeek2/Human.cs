using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesWeek2
{
    class Human
    {

        static bool IsAsleep;

        static void DisplayName(string name)
        {
            Console.WriteLine("my name is {name}");
        }

        static void DisplayGreeting()
        {
            Console.WriteLine("Human greeting");
        }

        static void Eat (string foodType)
        {
           Console.WriteLine("Yum! I Ate {foodType}");
        }

        static void GoToSleep()
        {
            IsAsleep = true;
            Console.WriteLine(IsAsleep);
        }

        static void WakeUp()
        {
            IsAsleep = false;
            Console.WriteLine(IsAsleep);
        }
    }
}
