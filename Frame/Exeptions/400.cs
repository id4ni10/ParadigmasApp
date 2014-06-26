using System;

namespace Frame.Exeptions
{
    public class _400 : GenericExeption
    {
        public _400()
            : base("400 - Bad Request") { Code = (int)System.Net.HttpStatusCode.BadRequest; }
    }
}
