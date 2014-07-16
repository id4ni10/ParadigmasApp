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

    public String Conteudo
    {
        get { return conteudo; }
        set { conteudo = value; }
    }
    List<String> comentarios;

    public List<String> Comentarios
    {
        get { return comentarios; }
        set { comentarios = value; }
    }

    public Post(string titulo, string conteudo)
    {
        this.titulo = titulo;
        this.conteudo = conteudo;

        comentarios = new List<string>();
        comentarios.Add("Comentario 1");
        comentarios.Add("Comentario 2");
        comentarios.Add("Comment 3");
    }
}
