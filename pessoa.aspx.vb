Imports System.Text

Partial Class usuarios
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If IsPostBack Then Exit Sub

        Desabilitar_Campos()
        tipo_redesociais_atualizar()

        Dim b, c As New Acesso
        Session("cod") = Request.Params("c")
        Session("excluir_telefone") = Request.Params("et")
        Session("excluir_rede_social") = Request.Params("er")
        Session("excluir_email") = Request.Params("ee")
        Session("excluir_endereco") = Request.Params("eend")
        If Session("cod") <> "" Then
            lbID.Text = Request.Params("c")
            panelCadastro.Visible = True
            panelPesquisaLocal.Visible = True
            panelTelefonesRedesSociais.Visible = True
            panelPesquisa.Visible = False
            b.Select_("SELECT * from pessoa where cod='" & Session("cod") & "'")
            b.reader.Read()
            txNome.Text = b.reader.Item("nome")
            txApelido.Text = b.reader.Item("apelido")
            txCPF.Text = b.reader.Item("cpf")
            txRG.Text = b.reader.Item("rg")
            txCNPJ.Text = b.reader.Item("cnpj")
            Dim data_nascimento As String = b.reader.Item("data_nascimento").ToString
            txDataNascimento.Text = data_nascimento  'Right(data_nascimento, 2) & "/" & Left(Right(data_nascimento, 5), 2) & "/" & Left(data_nascimento, 4)

            If Session("excluir_telefone") <> "" Then
                c.No_Select_("delete from telefone where cod = " & Session("excluir_telefone") & " and cod_pessoa=" & Session("cod"))
                Session("excluir_telefone") = ""
            End If

            If Session("excluir_rede_social") <> "" Then
                c.No_Select_("delete from rede_social where cod = " & Session("excluir_rede_social") & " and cod_pessoa=" & Session("cod"))
                Session("excluir_rede_social") = ""
            End If

            If Session("excluir_email") <> "" Then
                c.No_Select_("delete from email where cod = " & Session("excluir_email") & " and cod_pessoa=" & Session("cod"))
                Session("excluir_email") = ""
            End If

            If Session("excluir_endereco") <> "" Then
                c.No_Select_("delete from pessoa_local where cod = " & Session("excluir_endereco") & " and cod_pessoa=" & Session("cod"))
                Session("excluir_endereco") = ""
            End If

            uf_atualizar()
            ddUF.Items.FindByText("MG").Selected = True

            cidades_atualizar()
            ddCidade.Items.FindByValue("74510").Selected = True

            btGravar.Text = "Atualizar"
            Habilitar_Campos()
            atualizar_telefones()
            atualizar_RedesSociais()
            atualizar_email()
            tipo_local_atualizar()
            atualizar_Enderecos()

        Else
            panelCadastro.Visible = False
            panelPesquisaLocal.Visible = False
            panelTelefonesRedesSociais.Visible = False
            btGravar.Text = "Gravar"
        End If
    End Sub

    Protected Sub btNovo_Click(sender As Object, e As EventArgs) Handles btNovo.Click
        panelPesquisa.Visible = False
        panelCadastro.Visible = True
        panelPesquisaLocal.Visible = True
        panelTelefonesRedesSociais.Visible = True

        uf_atualizar()
        ddUF.Items.FindByText("MG").Selected = True

        cidades_atualizar()
        ddCidade.Items.FindByValue("74510").Selected = True

        atualizar_telefones()
        tipo_redesociais_atualizar()
        atualizar_RedesSociais()
        atualizar_email()
        tipo_local_atualizar()
        atualizar_Enderecos()

        'Dim qw As Integer = 0
        'ltTabelaEnderecos.Text = "<table class=""table""><tbody>"
        'While qw < 2
        '    ltTabelaEnderecos.Text += "<tr><td>MG</td><td>Belo Horizonte</td><td>Prado</td><td>Rua A, 10, Apto 1004</td><td>Proximo do Epa. Proximo do Epa. Proximo do Epa.</td><td>Residência</td><td><a href=""local.aspx?c=1"">Excluir</td></tr>"
        '    ltTabelaEnderecos.Text += "<tr><td>MG</td><td>Belo Horizonte</td><td>Prado</td><td>Rua A, 10, Apto 1004</td><td>Proximo do Epa. Proximo do Epa. Proximo do Epa.</td><td>Trabalho</td><td><a href=""local.aspx?c=1"">Excluir</td></tr>"
        '    qw += 1
        'End While
        'ltTabelaEnderecos.Text += "</tbody></table>"

        
    End Sub

    Protected Sub btPesquisar_Click(sender As Object, e As EventArgs) Handles btPesquisar.Click

        ltTabela.Text = "<table class=""table""><tbody><tr><td>Nome(Alcunho)</td><td>CPF</td><td>RG</td><td>D. Nasc.(Idade)</td><td>CNPJ</td></tr>"

        Dim a As New Acesso
        '`Nome`, `Apelido`, `CPF`, `data_hora`, `data_nascimento`, `RG`, `CNPJ`
        a.Select_("select * from pessoa where `Nome` like '%" & txPesquisa.Text & "%' or `Apelido` like '%" & txPesquisa.Text & "%' or `CPF` like '%" & txPesquisa.Text & "%' or `data_nascimento` like '%" & txPesquisa.Text & "%' or `RG` like '%" & txPesquisa.Text & "%' or `CNPJ`  like '%" & txPesquisa.Text & "%'  order by `Nome`, `Apelido` limit 50")
        While a.reader.Read
            Dim idade As Integer
            idade = Year(Now) - CInt(Year(a.reader.Item("data_nascimento")))
            ltTabela.Text += "<tr><td><a href=""pessoa.aspx?c=" & a.reader.Item("cod") & """>" & a.reader.Item("nome") & "(" & a.reader.Item("apelido") & ")" & "</a></td><td><a href=""pessoa.aspx?c=" & a.reader.Item("cod") & """>" & a.reader.Item("cpf") & "</td><td><a href=""pessoa.aspx?c=" & a.reader.Item("cod") & """>" & a.reader.Item("RG") & "</td><td><a href=""pessoa.aspx?c=" & a.reader.Item("cod") & """>" & a.reader.Item("data_nascimento") & " (" & idade & ")</td><td><a href=""pessoa.aspx?c=" & a.reader.Item("cod") & """>" & a.reader.Item("cnpj") & "</td></tr>"
        End While

        ltTabela.Text += "</tbody></table>"
    End Sub

    Protected Sub btGravar_Click(sender As Object, e As EventArgs) Handles btGravar.Click
        Dim a As New Acesso
        Dim data_nascimento As String = ""
        If txDataNascimento.Text <> "" Then data_nascimento = Year(txDataNascimento.Text) & "-" & Month(txDataNascimento.Text) & "-" & Day(txDataNascimento.Text)
        a.No_Select_("UPDATE `pessoa` SET `Nome`='" & txNome.Text & "',`Apelido`='" & txApelido.Text & "'," & _
                     "`CPF`='" & txCPF.Text & "',`data_nascimento`='" & data_nascimento & "',CNPJ='" & txCNPJ.Text & "',RG='" & txRG.Text & "' " & _
                     "WHERE cod=" & lbID.Text)
        Response.Redirect("pessoa.aspx?c=" & lbID.Text)
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

    Sub tipo_redesociais_atualizar()

        ddTipoRedeSocial.Items.Clear()

        Dim a As New Acesso
        a.Select_("select * from tipo_rede_social order by cod")
        While a.reader.Read
            Dim item As New ListItem
            item.Text = a.reader.Item(1)
            item.Value = a.reader.Item(0)
            ddTipoRedeSocial.Items.Add(item)
        End While
    End Sub

    Sub tipo_local_atualizar()

        ddTipoLocal.Items.Clear()

        Dim a As New Acesso
        a.Select_("select * from tipo_local order by cod")
        While a.reader.Read
            Dim item As New ListItem
            item.Text = a.reader.Item(1)
            item.Value = a.reader.Item(0)
            ddTipoLocal.Items.Add(item)
        End While
    End Sub

    Sub Desabilitar_Campos()
        txNome.ReadOnly = True
        txApelido.ReadOnly = True
        txCPF.ReadOnly = True
        txCNPJ.ReadOnly = True
        txRG.ReadOnly = True
        txDataNascimento.ReadOnly = True
        btGravar.Enabled = False
    End Sub

    Sub Habilitar_Campos()
        txNome.ReadOnly = False
        txApelido.ReadOnly = False
        txCPF.ReadOnly = False
        txCNPJ.ReadOnly = False
        txRG.ReadOnly = False
        txDataNascimento.ReadOnly = False
        btGravar.Enabled = True
    End Sub


    Protected Sub btIniciarCadastro_Click(sender As Object, e As EventArgs) Handles btIniciarCadastro.Click
        Habilitar_Campos()
        Dim a, b As New Acesso
        a.No_Select_("INSERT INTO `pessoa`(`Nome`) VALUES ('provisório')")

        b.Select_("select cod from pessoa where nome='provisório'")
        b.reader.Read()
        lbID.Text = b.reader.Item(0)
    End Sub

    Protected Sub btTelefoneAdicionar_Click(sender As Object, e As EventArgs) Handles btTelefoneAdicionar.Click
        Dim a As New Acesso
        a.No_Select_("insert into telefone (numero,cod_pessoa) values ('" & txTelefoneAdicionar.Text & "'," & lbID.Text & ")")
        Response.Redirect("pessoa.aspx?c=" & lbID.Text)
    End Sub

    Protected Sub btEmailAdicionar_Click1(sender As Object, e As EventArgs) Handles btEmailAdicionar.Click
        Dim a As New Acesso
        a.No_Select_("insert into email (descricao,cod_pessoa) values ('" & txEmailAdicionar.Text & "'," & lbID.Text & ")")
        Response.Redirect("pessoa.aspx?c=" & lbID.Text)
    End Sub
    Protected Sub btRedesSociaisAdicionar_Click(sender As Object, e As EventArgs) Handles btRedesSociaisAdicionar.Click
        Dim a As New Acesso
        a.No_Select_("insert into rede_social (descricao,cod_tipo_rede_social,cod_pessoa) values ('" & txRedesSociaisAdicionar.Text & "'," & ddTipoRedeSocial.SelectedValue & "," & lbID.Text & ")")
        Response.Redirect("pessoa.aspx?c=" & lbID.Text)
    End Sub

    Protected Sub btLocalAdicionar_Click(sender As Object, e As EventArgs) Handles btLocalAdicionar.Click
        Dim a As New Acesso
        a.No_Select_("insert into pessoa_local (cod_tipo_local,cod_local,cod_pessoa) values ('" & ddTipoLocal.SelectedValue & "'," & ddBuscaEnderecos.SelectedValue & "," & lbID.Text & ")")
        Response.Redirect("pessoa.aspx?c=" & lbID.Text)
    End Sub
    Sub atualizar_telefones()

        ltTabelaTelefones.Text = "<table class=""table""><tbody>"
        Dim a As New Acesso
        a.Select_("select t.cod, t.numero from telefone t inner join pessoa p on t.cod_pessoa=p.cod where p.cod=" & lbID.Text)
        If a.reader.HasRows Then
            While a.reader.Read
                ltTabelaTelefones.Text += "<tr><td>" & a.reader.Item(1) & "</td><td><a href=""pessoa.aspx?c=" & lbID.Text & "&et=" & a.reader.Item(0) & """>Excluir</td></tr>"
            End While
        Else
            ltTabelaTelefones.Text += "<tr><td>Não há telefones cadastrados</td></tr>"
        End If
        ltTabelaTelefones.Text += "</tbody></table>"
    End Sub

    Sub atualizar_email()

        ltTabelaEmails.Text = "<table class=""table""><tbody>"
        Dim a As New Acesso
        a.Select_("select t.cod, t.descricao from email t inner join pessoa p on t.cod_pessoa=p.cod where p.cod=" & lbID.Text)
        If a.reader.HasRows Then
            While a.reader.Read
                ltTabelaEmails.Text += "<tr><td>" & a.reader.Item(1) & "</td><td><a href=""pessoa.aspx?c=" & lbID.Text & "&ee=" & a.reader.Item(0) & """>Excluir</td></tr>"
            End While
        Else
            ltTabelaEmails.Text += "<tr><td>Não há e-mails cadastrados</td></tr>"
        End If
        ltTabelaEmails.Text += "</tbody></table>"
    End Sub

    Sub atualizar_RedesSociais()

        ltTabelaRedesSociais.Text = "<table class=""table""><tbody>"
        Dim a As New Acesso
        a.Select_("select r.cod, r.descricao, trs.descricao from rede_social r inner join pessoa p on r.cod_pessoa=p.cod inner join tipo_rede_social trs on trs.cod=r.cod_tipo_rede_social where p.cod=" & lbID.Text)
        If a.reader.HasRows Then
            While a.reader.Read
                ltTabelaRedesSociais.Text += "<tr><td>" & a.reader.Item(1) & "</td><td>" & a.reader.Item(2) & "</td><td><a href=""pessoa.aspx?c=" & lbID.Text & "&er=" & a.reader.Item(0) & """>Excluir</td></tr>"
            End While
        Else
            ltTabelaRedesSociais.Text += "<tr><td>Não há Redes Sociais cadastradas</td></tr>"
        End If
        ltTabelaRedesSociais.Text += "</tbody></table>"
    End Sub

    Sub atualizar_Enderecos()

        ltTabelaEnderecos.Text = "<table class=""table""><tbody>"
        Dim a As New Acesso
        a.Select_("SELECT pl.cod,uf.descricao,c.descricao,l.bairro,l.rua,l.obs,tl.descricao FROM pessoa p inner join pessoa_local pl " & _
                  "on p.cod=pl.cod_pessoa inner join local l on l.cod=pl.cod_local inner join tipo_local tl on tl.cod=pl.cod_tipo_local inner join " & _
                  "cidade c on c.cod=l.cod_cidade inner join uf on uf.cod=c.uf where p.cod=" & lbID.Text)
        If a.reader.HasRows Then
            While a.reader.Read
                ltTabelaEnderecos.Text += "<tr><td>" & a.reader.Item(1) & "</td><td>" & a.reader.Item(2) & "</td><td>" & a.reader.Item(3) & "</td><td>" & a.reader.Item(4) & "</td><td>" & a.reader.Item(5) & "</td><td>" & a.reader.Item(6) & "</td><td><a href=""pessoa.aspx?c=" & lbID.Text & "&eend=" & a.reader.Item(0) & """>Excluir</td></tr>"
            End While
        Else
            ltTabelaEnderecos.Text += "<tr><td>Não há endereços cadastradas</td></tr>"
        End If
        ltTabelaEnderecos.Text += "</tbody></table>"
    End Sub

    Public Function Encriptar(ByVal Source As String, ByVal Shift As Integer)
        Dim chars() As Byte = Encoding.ASCII.GetBytes(Source)
        Dim sb As New StringBuilder()

        'mantem no intervalo
        Shift = IIf(Shift > 25, 25, Shift)

        For x As Integer = 0 To chars.Length - 1
            Dim ch As Integer = chars(x)

            If (ch >= 65) And (ch <= 90) Then
                ch = (ch + Shift)
                If (ch > 90) Then
                    ch = (ch - 26)
                End If
            End If

            If (ch >= 97) And (ch <= 122) Then
                ch = (ch + Shift)
                If (ch > 122) Then
                    ch = (ch - 26)
                End If
                sb.Append(Chr(ch))
            Else
                sb.Append(Chr(ch))
            End If
        Next x

        Return sb.ToString()
        'libera
        sb = Nothing

    End Function

    Public Function Decriptar(ByVal Source As String, ByVal Shift As Integer)
        Dim chars() As Byte = Encoding.ASCII.GetBytes(Source)
        Dim sb As New StringBuilder()

        'mantem no intervalo
        Shift = IIf(Shift > 25, 25, Shift)

        For x As Integer = 0 To chars.Length - 1
            Dim ch As Integer = chars(x)

            If (ch >= 65) And (ch <= 90) Then
                ch = (ch - Shift)
                If (ch < 65) Then
                    ch = (ch + 26)
                End If
            End If

            If (ch >= 97) And (ch <= 122) Then
                ch = (ch - Shift)
                If (ch < 97) Then
                    ch = (ch + 26)
                End If
                sb.Append(Chr(ch))
            Else
                sb.Append(Chr(ch))
            End If
        Next x

        Return sb.ToString()
        'libera
        sb = Nothing

    End Function


    
    Protected Sub btPesquisarLocal_Click(sender As Object, e As EventArgs) Handles btPesquisarLocal.Click

        ddBuscaEnderecos.Items.Clear()

        Dim a As New Acesso
        a.Select_("SELECT l.cod,uf.descricao, c.descricao, l.bairro, l.rua, LEFT(l.obs, 20) FROM local l inner JOIN cidade c on l.cod_cidade=c.cod inner join uf on c.uf=uf.cod " & _
                  "where uf.cod = " & ddUF.SelectedValue & " and c.cod = " & ddCidade.SelectedValue & " and l.bairro like '%" & txBairro.Text & "%' and l.rua like '%" & txRua.Text & "%' and l.obs like '%" & txObs.Text & "%' " & _
                  "order by l.bairro, l.rua, l.obs")
        If a.reader.HasRows Then
            While a.reader.Read
                Dim item As New ListItem
                item.Text = CStr(a.reader.Item("bairro").ToString & ", " & a.reader.Item("rua").ToString & ", " & a.reader.Item(5).ToString)
                item.Value = a.reader.Item(0)
                ddBuscaEnderecos.Items.Add(item)
            End While
        Else
            Dim item As New ListItem
            item.Text = "local não encontrado."
            item.Value = "nd"
            ddBuscaEnderecos.Items.Add(item)
        End If
        
    End Sub

    
End Class
