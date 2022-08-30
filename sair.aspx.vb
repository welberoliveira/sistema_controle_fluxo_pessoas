
Partial Class usuarios
    Inherits System.Web.UI.Page

    Private Sub usuarios_Load(sender As Object, e As EventArgs) Handles Me.Load
        Session("login") = "0"
        Response.Redirect("login.aspx")
    End Sub
End Class
