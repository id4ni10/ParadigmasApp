using System;

namespace Frame.Exceptions
{
    public class _400 : GenericException
    {
        public _400()
            : base("400 - Bad Request") { Code = (int)System.Net.HttpStatusCode.BadRequest; }
    }
}
