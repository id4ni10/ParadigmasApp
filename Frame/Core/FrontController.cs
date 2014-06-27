using System;
using System.Reflection;
using System.Collections.Generic;
using System.Net;
using System.Web;
/// <summary>
/// Classe usada como mediadora entre as requisições do cliente e o servidor ( Pattern Mediator )
/// </summary>
namespace Frame.Core
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

        public static void run(HttpServerUtility Server, Type[] Types, HttpRequest Request, HttpResponse Response)
        {
            new FrontController(Server, Types, Request, Response);
        }

        private FrontController(HttpServerUtility Server, Type[] Types, HttpRequest request, HttpResponse response)
        {
            try
            {
                Validate(request);

                this.request = request;
                this.response = response;

                this.method = request.HttpMethod;
                this.uri = request.Url.AbsoluteUri;

                string controller = request["controller"];
                string parametro = request["parametro"];
                string tipo = request["tipo"];

                object[] parametros = new object[1];
                parametros[0] = parametro;

                Type controllerType = null;
                object controllerObject = null;

                foreach (Type type in Types)
                {
                    if (type.Name == controller)
                    {
                        controllerType = type;
                        controllerObject = Server.CreateObject(type);
                    }
                }

                if (controllerType == null)
                {
                    throw new Frame.Exceptions._400();
                }

                MethodInfo myMethod = controllerType.GetMethod(method);
                response.Write(myMethod.Invoke(controllerObject, parametros));


                //String resposta = myMethod.Invoke(controllerObject, parametros);

                //VERIFICA SE O WEB.CONFIG POSSUI O PARAMETRO TEMPLATE. SE POSSUIR, CARREGA O ARQUIVO EM UMA STRING "page";

                //PROCURA NA STRING A MARCAÇÃO {BODY} E SUBSTITUI PELO OBJETO "resposta"

                //RETORNA "page"

                //SE NÃO POSSUIR TEMPLATE RETORNA "resposta"

            }
            catch (Exceptions.GenericException ex)
            {
                response.StatusCode = ex.Code;
            }
            catch (Exception e)
            {
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }

        }

        private void Validate(HttpRequest Request)
        {
            string controller = Request["controller"];
            string parametro = Request["parametro"];
            string tipo = Request["tipo"];

            if (controller == null || controller == "" || parametro == null || parametro == "" || tipo == null || tipo == "")
            {
                throw new Exceptions._404();
            }

        }
    }
}