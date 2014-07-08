using System;
using System.Reflection;
using System.Collections.Specialized;
using System.Web.SessionState;
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

        public static void run(HttpServerUtility Server, HttpSessionState Session, Type[] Types, NameValueCollection Configuration, HttpRequest Request, HttpResponse Response)
        {
            new FrontController(Server, Session, Types, Configuration, Request, Response);
        }

        private FrontController(HttpServerUtility Server, HttpSessionState Session, Type[] Types, NameValueCollection Configuration, HttpRequest request, HttpResponse response)
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

                PropertyInfo myProperty = controllerType.GetProperty("Session");

                myProperty.SetValue(controllerObject, Session, null);

                object obj = myMethod.Invoke(controllerObject, parametros);

                Session["obj"] = obj;

                TemplateLoader template = new TemplateLoader(Server, Configuration);

                response.Write(template.applyTemplate(obj));

            }
            catch (Exceptions.GenericException ex)
            {
                response.StatusCode = ex.Code;
                response.Write(ex.Message);
            }
            catch (Exceptions.TemplateException ex)
            {
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                response.Write(ex.Message);
            }
            catch (Exception e)
            {
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                response.Write(e.Message);
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
