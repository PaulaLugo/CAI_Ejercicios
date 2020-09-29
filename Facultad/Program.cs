using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Facultad.Library;

namespace Facultad
{
    class Program
    {
        
        static List<Empleado> _empleados ;

        static List<Alumno> _alumnos;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            _alumnos = new List<Alumno>();
            _empleados = new List<Empleado>();

            //ABM y listado de[Alumno] y[Empleado - abstracta -].
            int opt;
            do
            {
               opt = MostrarMenu();
            } while (ElegirMenu(opt));
            
        }
              
        static int MostrarMenu()
        {
            int m;
            Console.Clear();
            Console.WriteLine("\t\t**********************************");
            Console.WriteLine("\t\t* Sistema Seguimiento de Alumnos *");
            Console.WriteLine("\t\t**********************************");
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t\tMenu:");
            Console.WriteLine();
            Console.WriteLine("\t\t1 – Alta Alumno");
            Console.WriteLine("\t\t2 – Baja Alumno");
            Console.WriteLine("\t\t3 – Editar Alumno");
            Console.WriteLine("\t\t4 – Alta Empleado");
            Console.WriteLine("\t\t5 – Baja Empleado");
            Console.WriteLine("\t\t6 – Editar Empleado");
            Console.WriteLine("\t\t7 – Listar los Alumnos");
            Console.WriteLine("\t\t8 – Listar Datos de los Empleados");
            Console.WriteLine("\t\t0 – Exit(Salir del programa)");
            Console.WriteLine();
            //ConsoleWriteLine("Presione Esc para salir");
            Console.WriteLine();
            while (true)
            {
                
                Console.Write("Ingrese una opcion:");
                //var o = Console.ReadKey(false).Key;
 
                var menu = Console.ReadLine();
                if (int.TryParse(menu, out m))
                {
                    if (m >= 0 && m <= 15)
                    {
                        return m;
                    }
                    else
                    {
                        Console.WriteLine("\nOpcion invalida");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("\nOpcion invalida");
                    continue;
                }
            }


        }
        
        static bool ElegirMenu(int opcion)
        {
            Console.Clear();
            switch (opcion)
            {
                case 0:
                    Console.WriteLine("Nos vemos en el ciberespacio...");
                    Thread.Sleep(1500);
                    return false;
                case 1:
                    Alta_Alumno();
                    break;
                case 2:
                    Baja_Alumno();
                    break;
                case 3:
                    Modificar_Alumno();
                    break;
                case 4:
                    Alta_Empleado();
                    break;
                case 7:
                    Baja_Empleado();
                    break;
                case 8:
                    Modificar_Empleado();
                    break;
                case 9:
                    Listado_Alumnos();
                    break;
                case 10:
                    Listado_Empleados();
                    break;
              

                default:
                    Console.WriteLine("Funcionalidad no implementada. Presion cualquier tecla para salir.");
                    Console.ReadKey();
                    break;
            }
            return true;
           
        }


        static void Alta_Alumno()
        {
            Helper.PonerTitulo("1 –  Alta de Alumnos");
            var ret = new Alumno();
            while (true)
            {
                Console.Write("Nombre: ");
                var r = Console.ReadLine();
                if (r == string.Empty)
                {
                    Console.WriteLine("Ingrese un nombre valido. No puede estar vacio");
                }
                else
                {
                    ret.Nombre = r;
                    break;
                }
            }

            while (true)
            {
                Console.Write("Nombre: ");
                var r = Console.ReadLine();
                if (r == string.Empty)
                {
                    Console.WriteLine("Ingrese un nombre valido. No puede estar vacio");
                }
                else
                {
                    ret.Nombre = r;
                    break;
                }
            }


        }
        
        static void Baja_Alumno()
        {
            Helper.PonerTitulo("2 –  Baja de Alumnos");
        }
         
        static void Modificar_Alumno()
        {
        }

            
        static void Alta_Empleado()
        {
        }
        
        static void Baja_Empleado()
        {
        }
         
        static void Modificar_Empleado()
        {
        }
                        
        static void Listado_Alumnos()
        {
            Helper.PonerTitulo("7 –  Listar los Alumnos");

            //Pedir parametros?


            if (!_alumnos.Any())
            {
                Console.Write("No hay alumnos registrados. ");
                Helper.Continuar();
                return;
            }

            else
            {

                Console.WriteLine("{0,23}{1,10}{2,12:N0}", "Nombre", "Apellido", "Registro");
                Console.WriteLine("{0,23}{1,10}{2,12:N0}", "------", "--------", "--------");

                foreach (Alumno item in _alumnos)
                {
                    Console.WriteLine(item.ToString());
                }
            }

            Console.WriteLine();

            Console.WriteLine();
            Helper.Continuar();
        }
            
      

        static void Listado_Empleados()
        {
          
                Helper.PonerTitulo("8 –  Listar los Empleados");

            //Pedir parametros?


                if (!_empleados.Any())
                {
                    Console.Write("No hay empleados registrados. ");
                    Helper.Continuar();
                    return;
                }
     
                else
                {

                    Console.WriteLine("{0,23}{1,10}{2,12:N0}", "Nombre", "Apellido", "Registro");
                    Console.WriteLine("{0,23}{1,10}{2,12:N0}", "------", "--------", "--------");

                    foreach (Empleado item in _empleados)
                    {
                        Console.WriteLine(item.ToString());
                    }
                }

                Console.WriteLine();
              
                Console.WriteLine();
                Helper.Continuar();

        
            }

          
        
          
       
        
    }
}
