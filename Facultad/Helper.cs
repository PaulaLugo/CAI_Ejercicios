using FacuLibrary;
using System;

namespace FacuConsola
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
                        return Convert.ChangeType(r, tipo);
                    }
                    catch
                    {
                        Console.Write("Ingrese un valor valido. "); 
                        Console.WriteLine("Se espera un {0}",tipo );
                    }

                }

            }
        }

        internal static object PedirTipoEmpleado( Type tipo)
        {
            while (true)
            {
                Console.WriteLine("Tipos de empleado");
                
                for (int i = 1; i <= 3; i++)
                {
                    var j = (TipoEmpleado)i;
                    Console.WriteLine("{0} - {1}", i, j );
                }
                Console.WriteLine();
                var t = (int)Helper.PedirPropiedad("Tipo  de Empleado", typeof(int));
                if (t <= 3 & t > 0)
                {
                    return t;
                }
            }
        }

        internal static bool PreguntaYN(string ques)
        {
            Console.WriteLine(ques + "Y/N");
            string rta = Console.ReadLine();
            Console.Clear();
            return (rta.ToUpper() == "Y");
        }

        internal static bool Continuo()
        {
            return PreguntaYN("Desea continuar?");
 
        }
    }
}
