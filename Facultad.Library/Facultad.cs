
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Facultad.Library
{
    class Facultad
    {
        private List<Empleado> _empleados;
        private List<Alumno> _alumnos;


        private int _cantidadSedes;

        public int CantidadSedes
        {
            get { return _cantidadSedes; }
            set { _cantidadSedes = value; }
        }

        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
       public  void AgregarAlumno(Alumno item)
        {
            _alumnos.Add(item);

        }
        public void AgregarEmpleado(Empleado item)
        {
            _empleados.Add(item);

        }
        public void EliminarEmpleado(int id)
        {
            _empleados.RemoveAll(o => o.Legajo == id);
        }

        public void EliminarAlumno(int id)
        {
            _alumnos.RemoveAll(o => o.Codigo == id);
        }

        public List<Alumno> TraerAlumnos()
        {
            return _alumnos;
        }

        public List<Empleado> TraerEmpleados()
        {
            return _empleados;
        }

        public Empleado TraerEmpleadoPorLegajo(int legajo)
        {
            return _empleados.Where(o => o.Legajo == legajo).FirstOrDefault ();
        }
        public List<Empleado> TraerEmpleadosPorNombres(string nombre)
        {
            return _empleados.Where(o => o.Nombre == nombre).ToList();
        }
        public void ModificarEmpleado(Empleado item)
        {
            Empleado ret = TraerEmpleadoPorLegajo(item.Legajo);
            if (ret != null)
            {
                ret.Nombre = item.Nombre;
                ret.Apellido = item.Apellido;
                ret.FechaIngreso = item.FechaIngreso;
                ret.FechaNacimiento = item.FechaNacimiento;
                ret.Salarios = new List<Salario>();
                ret.Salarios.AddRange(item.Salarios);
            }
        }
    }
}
