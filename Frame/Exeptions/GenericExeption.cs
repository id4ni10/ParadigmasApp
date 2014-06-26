using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Frame.Exeptions
{
    public class GenericExeption : Exception
    {
        private int code;

        public int Code
        {
            get { return code; }
            set { this.code = value; }
        }
        public GenericExeption(string exeption)
            : base(exeption) { }

    }
}
