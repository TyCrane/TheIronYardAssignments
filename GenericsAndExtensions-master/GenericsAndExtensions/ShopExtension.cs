using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GenericsAndExtensions
{
    public static class ShopExtension
    {

        public static void ChangeTire <T>(this Shop<T> value, string t) where T : new ()
        {
            T result = new T();
            Console.WriteLine( "Changed Tire on " + t);
        }

    }
}
