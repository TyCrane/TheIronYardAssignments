using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsAndExtensions
{
    public class Shop<T>
    {
       
      public static void FillUp(string gasType)
        {
            
            Console.WriteLine("Filled up Gas with " + gasType);
        }

       public static void ChangeOil()
        {
            Console.WriteLine("Changed Oil");
        }



        
    }
}
