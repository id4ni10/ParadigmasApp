using System;

/// <summary>
/// NOT_FOUND
/// </summary>
namespace Frame.Exeptions
{
    public class _404 : GenericExeption
    {
        public _404()
            : base("404 - Não encontrado") { Code = (int)System.Net.HttpStatusCode.NotFound; }
    }
}