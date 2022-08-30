
Partial Class usuarios
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim a As New Acesso
        a.Select_("select * from uf")
        While a.reader.Read
            Dim item As New ListItem
            item.Text = a.reader.Item(1)
            item.Value = a.reader.Item(0)
            ddUF.Items.Add(item)
        End While

        Dim cod As String = Request.Params("c")
        If cod <> "" Then
            panelCadastro.Visible = True
            Dim b As New Acesso
            b.Select_("select c.descricao,u.descricao from cidade c inner join uf u on c.uf=u.cod where c.cod=" & cod)
            b.reader.Read()
            txCidade.Text = b.reader.Item(0)
            ddUF.Items.FindByText(b.reader.Item(1)).Selected = True
        Else
            panelCadastro.Visible = False
        End If
    End Sub

    Protected Sub btNovo_Click(sender As Object, e As EventArgs) Handles btNovo.Click
        panelCadastro.Visible = True
    End Sub

    Protected Sub btPesquisar_Click(sender As Object, e As EventArgs) Handles btPesquisar.Click
        ltTabela.Text = "<table class=""table""><tbody>"

        Dim a As New Acesso
        a.Select_("select c.cod,c.descricao,u.descricao from cidade c inner join uf u on c.uf=u.cod where c.descricao like '" & txPesquisa.Text & "%'")
        While a.reader.Read
            ltTabela.Text += "<tr><td><a href=""cidade.aspx?c=" & a.reader.Item(0) & """>" & a.reader.Item(1) & "</a></td><td><a href=""cidade.aspx?c=" & a.reader.Item(0) & """>" & a.reader.Item(2) & "</td></tr>"
        End While

        ltTabela.Text += "</tbody></table>"
    End Sub
End Class
