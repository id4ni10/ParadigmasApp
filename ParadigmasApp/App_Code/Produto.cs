using System;
using System.Collections.Generic;
//Nosso Assembly
using Frame.Core;
/// <summary>
/// Classe teste de implementação cliente
/// </summary>
/// 
public class Produto : GenericController
{
    private List<Post> posts;

    public Produto()
    {
        posts = new List<Post>();

        posts.Add(new Post("Aziz", "Sault"));
        posts.Add(new Post("Hernã", "Teste"));
        posts.Add(new Post("Aquiles", "Mizerê"));
    }

    public override object GET(object param)
    {
        return posts;
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
