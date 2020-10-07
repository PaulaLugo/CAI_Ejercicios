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

            //hola

            for (int i = 5; i < 10; i++)
            {
                Console.WriteLine(10%i);
            }
            

        }
        // agrega cambio
        //1. git add -A : la A  son todos los archivos
        //2. git commit -m "commit pruebas"
        // 3. git push

        //git remote add origin https://github.com/PaulaLugo/CAI_Ejercicios.git
        //git branch -M master
        //git status

    }
}
