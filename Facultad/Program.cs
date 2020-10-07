using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using FacuLibrary;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;

namespace FacuConsola
{
    class Program
    {
        static Facultad facu;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            facu = new Facultad();

           

            //ABM y listado de[Alumno] y[Empleado - abstracta -].
            int opt;
            do
            {
               opt = MostrarMenu();
            } while (ElegirMenu(opt));
            
        }
              
        /// <summary>
        /// ejemplo para maru
        /// </summary>
        /// <returns></returns>
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
                case 5:
                    Baja_Empleado();
                    break;
                case 6:
                    Modificar_Empleado();
                    break;
                case 7:
                    Listado_Alumnos();
                    break;
                case 8:
                    Listado_Empleados();
                    break;
                default:
                    Console.WriteLine("Ingrese una opcion valida. Presion cualquier tecla para salir.");
                    Console.ReadKey();
                    break;
            }
            return true;
           
        }

        static void Alta_Alumno()
        {
            string rta = "Y";
            do
            {
                Helper.PonerTitulo("1 –  Alta de Alumnos");
                var ret = new Alumno();

                ret.Nombre = (string)Helper.PedirPropiedad("Nombre", typeof(string));
                ret.Apellido = (string)Helper.PedirPropiedad("Apellido", typeof(string));
                ret.Codigo = (int)Helper.PedirPropiedad("Codigo", typeof(int));

                try
                {
                    facu.AgregarAlumno(ret);
                    Console.WriteLine("Alumno creado");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

              
            } while (Helper.Continuo());

           

        }
        
        static void Baja_Alumno()
        {
            Helper.PonerTitulo("2 –  Baja de Alumno");

            var codigo = (int)Helper.PedirPropiedad("Codigo", typeof(int));
            try
            {
                facu.EliminarAlumno(codigo);
                Console.WriteLine("Alumno eliminado");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Helper.Continuar();
        }
         
        static void Modificar_Alumno()
        {
            Helper.PonerTitulo("3 – Editar Alumno");

            var codigo = (int)Helper.PedirPropiedad("Codigo", typeof(int));
            var alumno = facu.TraerAlumnos().Where(o => o.Codigo == codigo).FirstOrDefault();

            if (alumno == null)
            {
                Console.WriteLine("No se encontraron alumnos con ese codigo");
            }
            else
            {
                alumno.Nombre = (string)Helper.PedirPropiedad("Nombre", typeof(string));
                alumno.Apellido = (string)Helper.PedirPropiedad("Apellido", typeof(string));
                facu.EliminarAlumno(codigo);
                facu.AgregarAlumno(alumno);
                Console.WriteLine("Alumno modificado");
            }
            Helper.Continuar();
        }
            
        static void Alta_Empleado()
        {
            Helper.PonerTitulo("4 –  Alta de Empleado");
            Empleado ret = null;
            var tipo= (int)Helper.PedirTipoEmpleado( typeof(TipoEmpleado));


            switch (tipo)
            { 
                case  1:
                    ret = new Bedel();
                    break;
                case 2:
                    ret = new Directivo();
                    break;
                case 3:
                    ret = new Docente();
                    break;
                default:
                    throw new facuException("Este tipo de empleado no existe");
                    break;
            }
           

            ret.Nombre = (string)Helper.PedirPropiedad("Nombre", typeof(string));
            ret.Apellido = (string)Helper.PedirPropiedad("Apellido", typeof(string));
            ret.Legajo = (int)Helper.PedirPropiedad("Legajo", typeof(int));

            try
            {
                facu.AgregarEmpleado(ret);
                Console.WriteLine("Empleado creado");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Helper.Continuar();
        }
        
        static void Baja_Empleado()
        {
            Helper.PonerTitulo("5 –  Baja de Empleado");

            var codigo = (int)Helper.PedirPropiedad("Legajo", typeof(int));
            try
            {
                facu.EliminarEmpleado(codigo);
                Console.WriteLine("Empleado eliminado");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Helper.Continuar();
        }
         
        static void Modificar_Empleado()
        {
            Helper.PonerTitulo("6 – Editar Empleado");

            var codigo = (int)Helper.PedirPropiedad("Legajo", typeof(int));
            var empleado = facu.TraerEmpleados().Where(o => o.Legajo == codigo).FirstOrDefault();

            if (empleado == null)
            {
                Console.WriteLine("No se encontraron empleados con ese legajo");
            }
            else
            {
                var sal = (double)Helper.PedirPropiedad("Salario", typeof(double));
                empleado.AgregarSalario( new Salario(sal));
                facu.EliminarEmpleado(codigo);
                facu.AgregarEmpleado(empleado);
                Console.WriteLine("Empleado modificado");
            }
            Helper.Continuar();
        }

        static void Listado_Alumnos()
        {
            Helper.PonerTitulo("7 –  Listar los Alumnos");

            //Pedir parametros?

            var alumnos = facu.TraerAlumnos();

            if (!alumnos.Any())
            {
                Console.Write("No hay alumnos registrados. ");
                Helper.Continuar();
                return;
            }

            else
            {



                foreach (Alumno item in alumnos)
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

                var empleados = facu.TraerEmpleados();
                if (!empleados.Any())
                {
                    Console.Write("No hay empleados registrados. ");
                    Helper.Continuar();
                    return;
                }
     
                else
                {

              

                foreach (Empleado item in empleados)
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
