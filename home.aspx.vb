
Partial Class home
    Inherits System.Web.UI.Page

    Private Sub home_Load(sender As Object, e As EventArgs) Handles Me.Load
        lbNomeUsuario.Text = Session("usuario")
    End Sub
End Class
