using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    public class Bob
    {
        public bool isUpper;
        public string hey(string remark)
        {   
            for (int i=0; i<remark.Length; i++)
            {
                if (Char.IsLetter(remark[i]) && Char.IsUpper(remark[i]))
                {
                    remark.Replace("?","");
                    isUpper = true;
                }
                else
                {
                    isUpper = false;
                }
            }
            if (remark.EndsWith("!") || isUpper == true)
            {
                return "Whoa, chill out!";
            }
            else if (remark.EndsWith("?") && isUpper == false)
            {                                               
                    return "Sure.";               
            }
            else if (String.IsNullOrWhiteSpace(remark))
            {
               return "Fine. Be that way!";
            }
            else
            {
                return "Whatever.";
            }
            
        }
    }
}