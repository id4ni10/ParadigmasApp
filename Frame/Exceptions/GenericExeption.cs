using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Frame.Exceptions
{
    public class GenericException : Exception
    {
        private int code;

        public int Code
        {
            get { return code; }
            set { this.code = value; }
        }
        public GenericException(string exception)
            : base(exception) { }

    }
}
