using System;
using System.Collections.Generic;

public class Post
{
    String titulo;

    public String Titulo
    {
        get { return titulo; }
        set { titulo = value; }
    }
     String conteudo;
     List<String> comentarios;

    public Post(string a, string b)
    {
        this.titulo = a;
        this.conteudo = b;
    }
}
