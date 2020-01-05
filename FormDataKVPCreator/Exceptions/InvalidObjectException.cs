using System;
using System.Collections.Generic;
using System.Text;

namespace FormDataKVPCreator.Exceptions
{
    public class InvalidObjectException : Exception
    {
        public InvalidObjectException(string message = "Object should be an instance of class") : base(message)
        {

        }
    }
}
