using System;

/// <summary>
/// NOT_FOUND
/// </summary>
namespace Frame.Exceptions
{
    public class _404 : GenericException
    {
        public _404()
            : base("404 - Não encontrado") { Code = (int)System.Net.HttpStatusCode.NotFound; }
    }
}