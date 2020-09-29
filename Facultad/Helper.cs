using System;

namespace Facultad
{
	public static class Helper
	{
		 
        
        internal static void Continuar()
        {
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

    
        internal static void PonerTitulo(string titulo)
        {
        
            Console.WriteLine("\t\t**********************************");
            Console.WriteLine("\t\t* Sistema Seguimiento de Alumnos *");
            Console.WriteLine("\t\t**********************************");
            Console.WriteLine();
            Console.WriteLine(titulo);
            Console.WriteLine(new string('-', titulo.Length));
            Console.WriteLine();
            Console.WriteLine();
        }

        internal static object PedirPropiedad(string nombrePropiedad, Type tipo)
        {
            while (true)
            {
                Console.Write(nombrePropiedad + ": ");
                var r = Console.ReadLine();
                if (r == string.Empty)
                {
                    Console.WriteLine("Ingrese un valor valido. No puede estar vacio");
                }
                else
                {

                    try
                    {
                        return r;
                    }
                    catch
                    {
                        Console.WriteLine("Ingrese un valor valido.");
                    }

                }

            }
        }

    }
}
