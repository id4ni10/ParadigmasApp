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
                System.IO.StringWriter htmlStringWriter = new System.IO.StringWriter();
                
                Server.Execute("Templates/" + configuration["template"] + "", htmlStringWriter);
                string htmlOutput = htmlStringWriter.GetStringBuilder().ToString();
                return htmlOutput;
            }
            return obj.ToString();
        }

    }
}
