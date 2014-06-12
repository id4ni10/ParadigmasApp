using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Net;
using System.Web.UI.WebControls;

using Core;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        FrontController.run(Request, Response);
        

        //try
        //{
        //    fc.Validate(Request);
        //    //SEGUE CRIANDO A INSTANCIA - CODIGO DE AZIZ

        //}
        //catch (Exception ex)
        //{
        //    //SETA O CABECALHO DE RESPOSTA DE ACORDO COM A EXCECAO
        //    //ESCREVE A RESPOSTA DE ACORDO COM A EXCECAO
        //}


        //Response.Redirect("http://localhost:16439/");

        //List<object> parametros = new List<object>();

        //foreach (object param in Request.Params)
        //{
        //    parametros.Add(param);
        //}

    }
}