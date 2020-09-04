using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    class Program
    {
        static void Main(string[] args)
        {
        
            for (int i = 1; i <= 295; i++)
            {
                Console.WriteLine("{0}{1}{2}{3}", i, i % 3 == 0 || i % 5 == 0? " - ": string.Empty, i % 3 == 0 ? "Foo" : string.Empty,  i % 5 == 0 ? "Bar" : string.Empty);
               
            }
            Console.Read();
        }
        //git remote add origin https://github.com/PaulaLugo/CAI_Ejercicios.git
        //git branch -M master
        //git status

    }
}
