using System;
using System.Web.SessionState;
using System.Web;

/// <summary>
/// Abstração de controller genérico a ser implementado pelo usuário do frame
/// </summary>
namespace Frame.Core
{
    public abstract class GenericController
    {
        private HttpSessionState session;

        public HttpSessionState Session
        {
            get { return session; }
            set { session = value; }
        }

        public abstract object GET(object param);

        public abstract object POST(object param);

        public abstract object PUT(object param);

        public abstract object DELETE(object param);
    }
}
