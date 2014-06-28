using System;
using System.Collections.Specialized;
using System.Text;
using System.IO;
using System.Web;

namespace Frame.Core
{
    public class TemplateLoader
    {
        private HttpServerUtility Server;
        private NameValueCollection configuration;

        public TemplateLoader(HttpServerUtility Server, NameValueCollection configuration)
        {
            //PROCURA NA STRING A MARCAÇÃO {BODY} E SUBSTITUI PELO OBJETO "resposta"

            //RETORNA "page"

            //SE NÃO POSSUIR TEMPLATE RETORNA "resposta"

            this.Server = Server;
            this.configuration = configuration;

        }

        private Boolean hasTemplate()
        {
            if (this.configuration["template"] != null)
                return true;
            return false;
        }

        public String applyTemplate(object obj)
        {
            if (this.hasTemplate())
            {
                String page = null;
                try
                {
                    page = File.ReadAllText(Server.MapPath("~/templates/" + configuration["template"]));
                }
                catch (IOException e)
                {
                    throw new Exceptions.TemplateException("Não foi possível carregar o template.");
                }
                return page.Replace("[[content]]", obj.ToString());
            }
            return obj.ToString();
        }

    }
}
