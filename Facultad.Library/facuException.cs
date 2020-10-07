using System;
using System.Collections.Generic;
using System.Text;

namespace FacuLibrary
{
    public class facuException : Exception
    {
        public facuException():base()
        {

        }

        public facuException(string message) : base(message)
        {

        }
    }
}
