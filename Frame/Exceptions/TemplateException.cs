using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Frame.Exceptions
{
    public class TemplateException : Exception
    {
        private int code;

        public int Code
        {
            get { return code; }
            set { this.code = value; }
        }
        public TemplateException(string exception)
            : base(exception) { }

    }
}
