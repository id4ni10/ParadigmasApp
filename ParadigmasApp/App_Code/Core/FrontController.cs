using System;
using System.Reflection;
using System.Collections.Generic;
using System.Net;
using System.Web;

/// <summary>
/// Classe usada como mediadora entre as requisições do cliente e o servidor ( Pattern Mediator )
/// </summary>

namespace Core
{

    public class FrontController
    {
        #region Streams

        /// <summary>
        /// Objeto que contêm as definições da requisição.
        /// </summary>
        private HttpRequest request;

        private string method;
        private string uri;

        /*--------------------------*/

        /// <summary>
        /// Objeto que contêm as definições da resposta.
        /// </summary>
        private HttpResponse response;



        #endregion


        public FrontController(HttpRequest request, HttpResponse response)
        {
            try
            {
                Validate(request);

                this.request = request;
                this.response = response;

                this.method = request.HttpMethod;
                this.uri = request.Url.AbsoluteUri;

                string controller = request["controler"];

                string parametro = request["parametro"];
                string tipo = request["tipo"];

                object[] parametros = new object[1];


                Type humanoType = Type.GetType(tipo);

                parametros[0] = parametro;

                var controllerType = Type.GetType("App_Code.Controllers." + controller);
                object controllerObject = Activator.CreateInstance(controllerType);

                //response.Write(controllerType.InvokeMember(method, BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Instance, null, controllerObject, parametros));

                MethodInfo myMethod = controllerType.GetMethod(method);

                myMethod.Invoke(controllerObject, parametros);



            }
            catch (Exception ex)
            {
                response.StatusCode = (int)HttpStatusCode.NotFound;
                //response.Redirect("http://localhost:16439/");
            }

        }


        public static void run(HttpRequest Request, HttpResponse Response)
        {
            new FrontController(Request, Response);
        }

        //public WebResponse Response(WebRequest request)
        //{
        //    if (Validate(request))
        //    {
        //        return request.GetResponse();
        //    }

        //    return null;
        //}

        public void Validate(HttpRequest Request)
        {
            string controller = Request["controler"];
            string parametro = Request["parametro"];
            string tipo = Request["tipo"];

            if (controller == null || controller == "" || parametro == null || parametro == "" || tipo == null || tipo == "")
            {
                throw new Exception("404 - Não encontrado");
            }

        }
    }
}