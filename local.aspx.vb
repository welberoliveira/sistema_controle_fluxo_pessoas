
Partial Class usuarios
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If IsPostBack Then Exit Sub

        Dim b As New Acesso
        Session("cod") = Request.Params("c")
        If Session("cod") <> "" Then
            panelCadastro.Visible = True
            b.Select_("SELECT l.cod,uf.descricao, c.descricao, l.bairro, l.rua, l.obs FROM local l inner JOIN cidade c on l.cod_cidade=c.cod inner join uf on c.uf=uf.cod " & _
                  "where l.cod = '" & Session("cod") & "'")
            b.reader.Read()
            uf_atualizar()
            ddUF.Items.FindByText(b.reader.Item(1)).Selected = True
            cidades_atualizar()
            ddCidade.Items.FindByText(b.reader.Item(2)).Selected = True
            txBairro.Text = b.reader.Item(3)
            txRua.Text = b.reader.Item(4)
            txObs.Text = b.reader.Item(5)
            btGravar.Text = "Atualizar"
        Else
            panelCadastro.Visible = False
            btGravar.Text = "Gravar"
        End If
    End Sub

    Protected Sub btNovo_Click(sender As Object, e As EventArgs) Handles btNovo.Click
        panelCadastro.Visible = True
        panelPesquisa.Visible = False

        uf_atualizar()
        ddUF.Items.FindByText("MG").Selected = True

        cidades_atualizar()
        ddCidade.Items.FindByValue("74510").Selected = True

    End Sub

    Protected Sub btPesquisar_Click(sender As Object, e As EventArgs) Handles btPesquisar.Click
        ltTabela.Text = "<table class=""table""><tbody>"

        Dim a As New Acesso
        a.Select_("SELECT l.cod,uf.descricao, c.descricao, l.bairro, l.rua, LEFT(l.obs, 20) FROM local l inner JOIN cidade c on l.cod_cidade=c.cod inner join uf on c.uf=uf.cod " & _
                  "where (uf.descricao like '%" & txPesquisa.Text & "%' or c.descricao like '%" & txPesquisa.Text & "%' or l.bairro like '%" & txPesquisa.Text & "%' or l.rua like '%" & txPesquisa.Text & "%' or l.obs like '%" & txPesquisa.Text & "%') and c.descricao like '%" & txPesquisaCidade.Text & "%' " & _
                  "order by uf.descricao, c.descricao, l.bairro, l.rua, l.obs limit 50")
        While a.reader.Read
            ltTabela.Text += "<tr><td><a href=""local.aspx?c=" & a.reader.Item(0) & """>" & a.reader.Item(1) & "</a></td><td><a href=""local.aspx?c=" & a.reader.Item(0) & """>" & a.reader.Item(2) & "</td><td><a href=""local.aspx?c=" & a.reader.Item(0) & """>" & a.reader.Item(3) & "</td><td><a href=""local.aspx?c=" & a.reader.Item(0) & """>" & a.reader.Item(4) & "</td><td><a href=""local.aspx?c=" & a.reader.Item(0) & """>" & a.reader.Item(5) & "</td></tr>"
        End While

        ltTabela.Text += "</tbody></table>"
    End Sub

    Protected Sub btCancelar_Click(sender As Object, e As EventArgs) Handles btCancelar.Click
        Response.Redirect("home.aspx")
    End Sub

    Protected Sub btGravar_Click(sender As Object, e As EventArgs) Handles btGravar.Click
        Dim a As New Acesso
        If Session("cod") <> "" Then
            a.No_Select_("UPDATE `local` SET `cod_cidade`='" & ddCidade.SelectedValue & "',`bairro`='" & txBairro.Text & "',`rua`='" & txRua.Text & "',`obs`='" & txObs.Text & "' WHERE cod=" & Session("cod"))
            Response.Redirect("local.aspx")
            Session("cod") = ""
        Else
            a.No_Select_("INSERT INTO `local`(`cod_cidade`, `bairro`, `rua`, `obs`) VALUES ('" & ddCidade.SelectedValue & "','" & txBairro.Text & "','" & txRua.Text & "','" & txObs.Text & "')")
            Response.Redirect("local.aspx")
        End If
    End Sub

    Protected Sub ddUF_TextChanged(sender As Object, e As EventArgs) Handles ddUF.TextChanged
        cidades_atualizar()
        panelCadastro.Visible = True
    End Sub

    Sub cidades_atualizar()

        ddCidade.Items.Clear()

        Dim c As New Acesso
        c.Select_("select * from cidade where uf=" & ddUF.SelectedValue & " order by descricao")
        While c.reader.Read
            Dim item As New ListItem
            item.Text = c.reader.Item(1)
            item.Value = c.reader.Item(0)
            ddCidade.Items.Add(item)
        End While
    End Sub
    Sub uf_atualizar()

        ddUF.Items.Clear()

        Dim a As New Acesso
        a.Select_("select * from uf order by descricao")
        While a.reader.Read
            Dim item As New ListItem
            item.Text = a.reader.Item(1)
            item.Value = a.reader.Item(0)
            ddUF.Items.Add(item)
        End While
    End Sub

End Class
