
Partial Class login
    Inherits System.Web.UI.Page

    Protected Sub btEntrar_Click(sender As Object, e As EventArgs) Handles btEntrar.Click
        Session("login") = "0"

        Dim a As New Acesso
        Dim usuario = txUsuario.Text
        Dim senha = txSenha.Text

        txUsuario.Text = ""
        txSenha.Text = ""

        a.Select_("select * from usuario")
        While a.reader.Read
            If usuario = a.reader.Item(1).ToString Then
                If senha = a.reader.Item(2).ToString Then
                    'coloca o codigo do usuario na sessao
                    Session("cod_usuario") = a.reader.Item("cod").ToString
                    Session("usuario") = a.reader.Item("usuario").ToString

                    'define o perfil do usuario
                    Session("perfil") = a.reader.Item("perfil").ToString
                    'Session("evento_completo") = "Sim"

                    'define a sessao do login: ativado
                    Session("login") = "1"

                    Response.Redirect("home.aspx")
                End If
            End If
        End While
        Response.Redirect("default.aspx")
    End Sub
End Class