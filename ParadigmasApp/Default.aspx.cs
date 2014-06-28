using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

//Nosso Assembly
using Frame.Core;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Type[] appCodeTypes = System.Reflection.Assembly.Load("App_Code").GetTypes();
        FrontController.run(Server, Session, appCodeTypes, ConfigurationManager.AppSettings, Request, Response);
    }
}