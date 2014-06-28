using System;

//Nosso Assembly
using Frame.Core;
/// <summary>
/// Classe teste de implementação cliente
/// </summary>
/// 
public class Produto : GenericController
{
    public override object GET(object param)
    {
        Session["s"] = param;
        return Session["s"].ToString();
    }

    public override object POST(object param)
    {
        return Session["s"].ToString();
    }

    public override object PUT(object param)
    {
        return "PUT";
    }

    public override object DELETE(object param)
    {
        return "DELETE";
    }
}