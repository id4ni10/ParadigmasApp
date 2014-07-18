<%@ Page Language="C#" AutoEventWireup="true" CodeFile="t.aspx.cs" Inherits="Templates_t" %>
<%@ Import Namespace="System.Collections.Generic" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <div runat="server" id="div1" style="border: 1px solid black;">
        <%
            List<Post> posts = (List<Post>)Session["obj"]; 
            foreach(Post post in posts) {
                Response.Write("<h2>" + post.Titulo + "</h2>");
                Response.Write("<p>" + post.Conteudo + "</p>");
                foreach(String comentario in post.Comentarios) {
                    Response.Write("<em>" + comentario + "</em><br/>");
                }
            }
        %>
    </div>
    <form id="form1" method="post">
        Título: <input type="text" name="Post.Titulo" /><br />
        Conteúdo: <textarea name="Post.Conteudo" rows="7" cols="100"></textarea><br />
        <input type="submit" value="Postar" />
    </form>
</body>
</html>
