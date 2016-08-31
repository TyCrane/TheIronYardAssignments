using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesWeek2
{
    class Robot
    {
        static bool isShutdown;
        static void DisplayName(string name)
        {
            Console.WriteLine("My name is {name}");
        }

        static void DisplayGreeting()
        {
            Console.WriteLine("This is my robot greeting");
        }

        static void StartUp()
        {
            isShutdown = false;
            Console.WriteLine("started");
        }

        static void ShutDown()
        {
            isShutdown = true;
            Console.WriteLine(isShutdown);
        }

        static void IsShutdown()
        {
            Console.WriteLine(isShutdown);
        }

        static void IsTerminator(bool terminator)
        {
            
            Console.WriteLine("I am terminator? " + terminator);
        }
    }
}
