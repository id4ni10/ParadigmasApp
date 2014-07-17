using System;
using System.Reflection;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Web.SessionState;
using System.Net;
using System.Web;
using System.Text.RegularExpressions;
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

                if (controllerType == null || controllerObject.GetType().BaseType.Name != "GenericController")
                {
                    throw new Frame.Exceptions._400();
                } 
                
                Dictionary<String, Object> dict = new MapBuilder(request, (GenericController)controllerObject).getDictionary();

                MethodInfo myMethod = controllerType.GetMethod(method);

                PropertyInfo myProperty = controllerType.GetProperty("Session");

                myProperty.SetValue(controllerObject, Session, null);

                object obj = myMethod.Invoke(controllerObject, new object[] { dict });

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

        private void Validate(HttpRequest request)
        {
            string controller;

            try
            {
                request.RequestContext.HttpContext.RewritePath(request.FilePath, null, "controller=" + request.PathInfo.Remove(0, 1));
                controller = request["controller"];
            }
            catch (Exception ex)
            {
                controller = request["controller"];
            }
            
            if (controller == null || controller == "")
            {
                throw new Exceptions._404();
            }
        }
    }
}
