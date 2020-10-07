using System;
using System.Collections.Generic;
using System.Linq;

namespace FacuLibrary
{
    public abstract class Persona    
    {
        protected DateTime _fechaNac   ;
        protected string _apellido;
        protected string _nombre;

        public int Edad
        {
            get { return DateTime.Today.Subtract(_fechaNac).Days / 365; }
      
        }
        
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
      
        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }

        public abstract string GetCredential();
      
        public string GetNombreCompleto()
        {
            return _nombre + " " + _apellido;
        }


    }

    

    public class Alumno : Persona
    {
        private int _codigo;

        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        public string Credencial
        {
            get { return GetCredential(); }
        }

        public override string GetCredential()
        {
            return string.Format("Código {0}) {1}, {2}", _codigo, _apellido, _nombre);
        }
        public override string ToString()
        {
            return GetCredential();

        }
    }


   
}
