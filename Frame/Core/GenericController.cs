using System;
using System.Collections.Generic;
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

        public abstract object GET(Dictionary<String, Object> param);

        public abstract object POST(Dictionary<String, Object> param);

        public abstract object PUT(Dictionary<String, Object> param);

        public abstract object DELETE(Dictionary<String, Object> param);

        public Dictionary<String, Object> getComplexParams()
        {
            return new Dictionary<String, Object>();
        }
    }
}
