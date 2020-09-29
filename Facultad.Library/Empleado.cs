using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Facultad.Library
{
    public abstract class Empleado : Persona
    {
        private List<Salario> _salarios;
        private DateTime _fechaIngreso;
        private int _legajo;

        public List<Salario> Salarios
        {
            get { return _salarios; }
            set { _salarios = value; }
        }


        public DateTime FechaIngreso
        {
            get { return _fechaIngreso; }
            set { _fechaIngreso = value; }
        }
        public DateTime FechaNacimiento
        {
            get { return _fechaNac; }
            set { _fechaNac = value; }
        }
        public int Legajo
        {
            get { return _legajo; }
            set { _legajo = value; }
        }



        public int Antiguedad
        {
            get { return DateTime.Today.Subtract(_fechaIngreso).Days / 365; }

        }

        public Salario UltimoSalario
        {
            get { return _salarios.LastOrDefault(); }

        }
        public void AgregarSalario(Salario item)
        {
            _salarios.Add(item);
        }


        public override bool Equals(object obj)
        {
            return this.Equals(obj as Empleado);
        }

        public bool Equals(Empleado p)
        {
            // If parameter is null, return false.
            if (Object.ReferenceEquals(p, null))
            {
                return false;
            }

            // Optimization for a common success case.
            if (Object.ReferenceEquals(this, p))
            {
                return true;
            }

            // If run-time types are not exactly the same, return false.
            if (this.GetType() != p.GetType())
            {
                return false;
            }

            // Return true if the fields match.
            // Note that the base class is not invoked because it is
            // System.Object, which defines Equals as reference equality.
            return (_legajo == p.Legajo);
        }

        public override string ToString()
        {
            return GetCredencial();

        }

        public string GetCredencial()
        {
            return string.Format("{0} - {1} salario $ {2}", _legajo, this.GetNombreCompleto(), this.UltimoSalario.GetSalarioNeto());
        }

    }
    public class Salario
    {
        private double _bruto;

        private double _descuentos;

        private string _codigoTransferencia;

        private DateTime _fecha;

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        public string CodigoTransferencia
        {
            get { return _codigoTransferencia; }
            set { _codigoTransferencia = value; }
        }

        public double Bruto
        {
            get { return _bruto; }
            set { _bruto = value; }
        }
        public double Descuentos
        {
            get { return _descuentos; }
            set { _descuentos = value; }
        }

        public double GetSalarioNeto()
        {
            return _bruto - _descuentos;
        }

        public Salario(double item)
        {
            _bruto = item;
            _fecha = DateTime.Today;
        }
    }

    enum TipoEmpelado
    {
            Bedel=1,
            Docente=2,
            Directivo=3,
    }
    public class Docente : Empleado
    {
        public override string GetCredential()
        {
            return base.GetCredencial();
        }

        public new string GetNombreCompleto()
        {
            return string.Format("Docente {0}", _nombre);
        }
    }

    public class Directivo : Empleado
    {
        public override string GetCredential()
        {
            return base.GetCredencial();
        }

        public new string GetNombreCompleto()
        {
            return string.Format("Sr. Director {0}", _apellido);
        }
    }
    
    public class Bedel : Empleado
    {
        protected string _apodo;

        public string Apodo
        {
            get { return _apodo; }
            set { _apodo = value; }
        }

        public override string GetCredential()
        {
            return base.GetCredencial();
        }

        public new string GetNombreCompleto()
        {
            return string.Format("Bedel {0}", _apodo);
        }
    }


}
