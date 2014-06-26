using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Abstração de controller genérico a ser implementado pelo usuário do frame
/// </summary>
namespace Frame.Core
{
    public abstract class GenericController
    {
        public abstract object GET(object param);

        public abstract object POST(object param);

        public abstract object PUT(object param);

        public abstract object DELETE(object param);
    }
}
