using System;
using System.Collections.Generic;
//Nosso Assembly
using Frame.Core;
/// <summary>
/// Classe teste de implementação cliente
/// </summary>
/// 
public class Blog : GenericController
{
    private List<Post> posts = new List<Post>();

    public Blog()
    {
        //posts.Add(new Post("Aziz", "Sault"));
        //posts.Add(new Post("Hernã", "Teste"));
        //posts.Add(new Post("Aquiles", "Mizerê"));
    }

    public override object GET(Dictionary<String,Object> param)
    {
        if (Session["obj"] != null)
        {
            posts = (List<Post>)Session["obj"];
        }
        return posts;
    }

    public override object POST(Dictionary<String, Object> param)
    {
        String titulo = (String)param["titulo"];
        String conteudo = (String)param["conteudo"];
        if (Session["obj"] != null)
        {
            posts = (List<Post>)Session["obj"];
        }

        posts.Add(new Post(titulo,conteudo));
        return posts;
    }

    public override object PUT(Dictionary<String, Object> param)
    {
        return "PUT";
    }

    public override object DELETE(Dictionary<String, Object> param)
    {
        return "DELETE";
    }

    public Dictionary<String, Object> getComplexParams()
    {
        Dictionary<String, Object> postParametro = new Dictionary<string, object>();
        postParametro.Add("Post",new Post());

    }
}
