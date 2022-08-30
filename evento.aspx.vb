Imports System.Text
Imports System.IO
Imports System.Threading.Tasks
Imports Dropbox.Api
Imports Dropbox.Api.Files
Imports System.Security.Cryptography




Partial Class usuarios
    Inherits System.Web.UI.Page

    'dropbox
    Private pasta As String = ""
    Private nome_arquivo As String
    Private fileupload_name As String = ""
    Private byteArray As Byte()
    Private stream1 As System.IO.MemoryStream
    Private dbx As DropboxClient


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("login") <> "1" Then Response.Redirect("login.aspx")

        If IsPostBack Then Exit Sub

        Desabilitar_Campos()

        categoria_evento_atualizar()
        tipo_evento_atualizar()
        natureza_evento_atualizar()

        Session("cod") = Request.Params("c")

        Atualizar_Pagina()


    End Sub

    Sub Atualizar_Pagina()
        Dim b, c, d As New acesso
        If Session("cod") <> "" Then
            lbID.Text = Request.Params("c")

            panelPesquisa.Visible = False
            panelCadastro.Visible = True
            panelLevantamentoInicial.Visible = True

            If Session("perfil") = "0" Then
                panelPesquisaLocal.Visible = True
                panelTelefonesRedesSociais.Visible = True
                panelEnvolvidos.Visible = True

                uf_atualizar()
                ddUF.Items.FindByText("MG").Selected = True

                cidades_atualizar()
                ddCidade.Items.FindByValue("74510").Selected = True

            End If

            Dim sql As String = "and evento.cod_usuario= '" & Session("cod_usuario") & "'"
            If Session("perfil") = 0 Then sql = ""

            b.Select_Group_Concat("SELECT evento.data_hora,evento.cod_categoria_evento,ne.cod_tipo_evento,evento.cod_natureza_evento, " &
                      "GROUP_CONCAT(distinct CONCAT_WS('<br></b>', usr1.usuario, eil.data_hora, eil.descricao) order by eil.data_hora desc SEPARATOR '<br><br><b>') as 'evento_inicial_local', " &
                      "GROUP_CONCAT(distinct CONCAT_WS('<br></b>', usr2.usuario, eie.data_hora, eie.descricao) order by eie.data_hora desc SEPARATOR '<br><br><b>') as 'evento_inicial_envolvido', " &
                      "GROUP_CONCAT(distinct CONCAT_WS('<br></b>', usr3.usuario, eim.data_hora, eim.descricao) order by eim.data_hora desc SEPARATOR '<br><br><b>') as 'evento_inicial_material', " &
                      "GROUP_CONCAT(distinct CONCAT_WS('<br></b>', usr4.usuario, eid.data_hora, eid.descricao) order by eid.data_hora desc SEPARATOR '<br><br><b>') as 'evento_inicial_descricao' " &
                      "from evento left join natureza_evento ne on evento.cod_natureza_evento=ne.cod " &
                      "left join evento_inicial_local eil on eil.cod_evento=evento.cod " &
                      "left join evento_inicial_envolvido eie on eie.cod_evento=evento.cod " &
                      "left join evento_inicial_material eim on eim.cod_evento=evento.cod " &
                      "left join evento_inicial_descricao eid on eid.cod_evento=evento.cod " &
                      "left join usuario usr1 on eil.cod_usuario=usr1.cod " &
                      "left join usuario usr2 on eie.cod_usuario=usr2.cod " &
                      "left join usuario usr3 on eim.cod_usuario=usr3.cod " &
                      "left join usuario usr4 on eid.cod_usuario=usr4.cod " &
                      "where evento.cod='" & Session("cod") & "' " & sql)
            b.reader.Read()
            If Not b.reader.HasRows() Then Exit Sub

            Dim data_hora As String = b.reader.Item("data_hora").ToString
            txDataHoraEvento.Text = data_hora  'Right(data_nascimento, 2) & "/" & Left(Right(data_nascimento, 5), 2) & "/" & Left(data_nascimento, 4)

            Try
                ddCategoriaEvento.SelectedItem.Selected = False
                ddCategoriaEvento.Items.FindByValue(b.reader.Item("cod_categoria_evento").ToString).Selected = True

                ltCategoriaOficial.Text = ddCategoriaEvento.SelectedItem.Text
            Catch ex As Exception
                ddCategoriaEvento.Items.Clear()
                'Desabilitar_Campos()
            End Try

            Try
                ddTipoEvento.SelectedItem.Selected = False
                ddTipoEvento.Items.FindByValue(b.reader.Item("cod_tipo_evento").ToString).Selected = True
            Catch ex As Exception
                ddTipoEvento.Items.Clear()
            End Try


            natureza_evento_atualizar()


            Try
                ddNaturezaEvento.SelectedItem.Selected = False
                ddNaturezaEvento.Items.FindByValue(b.reader.Item("cod_natureza_evento").ToString).Selected = True
            Catch ex As Exception
                ddNaturezaEvento.Items.Clear()
            End Try


            ltLocalInicial_Historico.Text = "<b>" & b.reader.Item("evento_inicial_local").ToString & "</b>"
            ltEnvolvidosInicial_Historico.Text = "<b>" & b.reader.Item("evento_inicial_envolvido").ToString & "</b>"
            ltMaterialInicial_Historico.Text = "<b>" & b.reader.Item("evento_inicial_material").ToString & "</b>"
            ltDescricaoInicial_Historico.Text = "<b>" & b.reader.Item("evento_inicial_descricao").ToString & "</b>"

            btGravar.Text = "Atualizar"
            Habilitar_Campos()


        Else
            If Session("perfil") = "0" Then
                tipo_envolvimento_atualizar()
                uf_atualizar()
                cidades_atualizar()
            End If

            panelCadastro.Visible = False
            panelPesquisaLocal.Visible = False
            panelTelefonesRedesSociais.Visible = False
            panelEnvolvidos.Visible = False
            panelPesquisaMateriais.Visible = False
            panelLevantamentoInicial.Visible = False
            btGravar.Text = "Gravar"
        End If
    End Sub

    Protected Sub btNovo_Click(sender As Object, e As EventArgs) Handles btNovo.Click
        panelPesquisa.Visible = False
        panelCadastro.Visible = True
        panelLevantamentoInicial.Visible = True

        If Session("perfil") = "0" Then
            panelPesquisaLocal.Visible = True
            panelTelefonesRedesSociais.Visible = True
            panelEnvolvidos.Visible = True
            panelPesquisaMateriais.Visible = True

            uf_atualizar()
            ddUF.Items.FindByText("MG").Selected = True

            cidades_atualizar()
            ddCidade.Items.FindByValue("74510").Selected = True
        End If


    End Sub

    Protected Sub btPesquisar_Click(sender As Object, e As EventArgs) Handles btPesquisar.Click

        ltTabela.Text = "<table class=""table""><tbody><tr><td>Cod</td><td>Local</td><td>Envolvido</td><td>Material</td><td>Descrição</td><td>Data e Hora</td></tr>"

        Dim a As New acesso

        Dim sql As String = " ev1.cod_usuario= '" & Session("cod_usuario") & "' and "
        If Session("perfil") = 0 Then sql = ""

        a.Select_("SELECT distinct ev1.cod, " &
        "left((select descricao from evento_inicial_local where cod_evento=ev1.cod order by cod desc limit 1),30) As 'inicial_local',  " &
        "left((select descricao from evento_inicial_envolvido where cod_evento=ev1.cod order by cod desc limit 1),30) as 'inicial_envolvido',  " &
        "left((select descricao from evento_inicial_material where cod_evento=ev1.cod order by cod desc limit 1),30) as 'inicial_material',  " &
        "left((select descricao from evento_inicial_descricao where cod_evento=ev1.cod order by cod desc limit 1),30) as 'inicial_descricao',  " &
        "ev1.data_hora " &
        "FROM evento ev1 inner join natureza_evento ne on ev1.cod_natureza_evento=ne.cod   " &
        "left join evento_inicial_local eil on eil.cod_evento=ev1.cod   " &
        "left join evento_inicial_envolvido eie on eie.cod_evento=ev1.cod   " &
        "left join evento_inicial_material eim on eim.cod_evento=ev1.cod   " &
        "left join evento_inicial_descricao eid on eid.cod_evento=ev1.cod " &
         "where " &
         sql &
        "(ev1.cod Like '%" & txPesquisa.Text & "%' or eil.descricao like '%" & txPesquisa.Text & "%' or eie.descricao like '%" & txPesquisa.Text & "%' or eim.descricao like '%" & txPesquisa.Text & "%' or eid.descricao like '%" & txPesquisa.Text & "%' or ev1.data_hora like '%" & txPesquisa.Text & "%') order by data_hora desc")
        While a.reader.Read
            ltTabela.Text += "<tr><td><a href=""evento.aspx?c=" & a.reader.Item("cod") & """>" & a.reader.Item("cod") & "</a></td><td><a href=""evento.aspx?c=" & a.reader.Item("cod") & """>" & a.reader.Item(1) & "</a></td><td><a href=""evento.aspx?c=" & a.reader.Item("cod") & """>" & a.reader.Item(2) & "</td><td><a href=""evento.aspx?c=" & a.reader.Item("cod") & """>" & a.reader.Item(3) & "</td><td><a href=""evento.aspx?c=" & a.reader.Item("cod") & """>" & a.reader.Item(4) & "</td><td><a href=""evento.aspx?c=" & a.reader.Item("cod") & """>" & a.reader.Item("data_hora") & "</td></tr>"
        End While

        ltTabela.Text += "</tbody></table>"
    End Sub

    Protected Sub btGravar_Click(sender As Object, e As EventArgs) Handles btGravar.Click
        Dim a As New acesso
        Dim data_nascimento As String = ""
        If txDataHoraEvento.Text <> "" Then data_nascimento = Year(txDataHoraEvento.Text) & "-" & Month(txDataHoraEvento.Text) & "-" & Day(txDataHoraEvento.Text) & " " & Hour(txDataHoraEvento.Text) & ":" & Minute(txDataHoraEvento.Text) & ":" & Second(txDataHoraEvento.Text)
        a.No_Select_("UPDATE `evento` SET `cod_categoria_evento`='" & ddCategoriaEvento.SelectedValue & "',`cod_natureza_evento`='" & ddNaturezaEvento.SelectedValue & "',`data_hora`='" & data_nascimento & "'  WHERE cod=" & lbID.Text)
        'Response.Redirect("evento.aspx?c=" & lbID.Text)

        categoria_evento_atualizar()
        tipo_evento_atualizar()
        natureza_evento_atualizar()
        Atualizar_Pagina()
    End Sub

    Protected Sub ddUF_TextChanged(sender As Object, e As EventArgs) Handles ddUF.TextChanged
        cidades_atualizar()
        panelCadastro.Visible = True
    End Sub

    Sub categoria_evento_atualizar()

        ddCategoriaEvento.Items.Clear()

        Dim c As New acesso
        c.Select_("select * from categoria_evento")
        While c.reader.Read
            Dim item As New ListItem
            item.Text = c.reader.Item(1)
            item.Value = c.reader.Item(0)
            ddCategoriaEvento.Items.Add(item)
        End While
    End Sub

    Sub tipo_evento_atualizar()

        ddTipoEvento.Items.Clear()

        Dim c As New acesso
        c.Select_("select * from tipo_evento")
        While c.reader.Read
            Dim item As New ListItem
            item.Text = c.reader.Item(1)
            item.Value = c.reader.Item(0)
            ddTipoEvento.Items.Add(item)
        End While
    End Sub

    Sub natureza_evento_atualizar()

        ddNaturezaEvento.Items.Clear()

        Dim c As New acesso
        c.Select_("select * from natureza_evento n inner join tipo_evento t on n.cod_tipo_evento=t.cod where t.cod=" & ddTipoEvento.SelectedValue)
        While c.reader.Read
            Dim item As New ListItem
            item.Text = c.reader.Item(1)
            item.Value = c.reader.Item(0)
            ddNaturezaEvento.Items.Add(item)
        End While
    End Sub

    Sub tipo_envolvimento_atualizar()

        ddTipoEnvolvimento.Items.Clear()

        Dim c As New acesso
        c.Select_("select * from tipo_envolvimento")
        While c.reader.Read
            Dim item As New ListItem
            item.Text = c.reader.Item(1)
            item.Value = c.reader.Item(0)
            ddTipoEnvolvimento.Items.Add(item)
        End While
    End Sub

    Sub cidades_atualizar()

        ddCidade.Items.Clear()

        Dim c As New acesso
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

        Dim a As New acesso
        a.Select_("select * from uf order by descricao")
        While a.reader.Read
            Dim item As New ListItem
            item.Text = a.reader.Item(1)
            item.Value = a.reader.Item(0)
            ddUF.Items.Add(item)
        End While
    End Sub


    Sub Desabilitar_Campos()

        btBuscarPessoa.Visible = False
        btDescricaoAdicionar.Visible = False
        btGravar.Visible = False
        btGravarEnvolvido.Visible = False
        btLocalAdicionar.Visible = False
        btPesquisarLocal.Visible = False

        btGravar.Visible = False

        btAddDescricao.Enabled = False
        btAddEnvolvido.Enabled = False
        btAddLocal.Enabled = False
        btAddMaterial.Enabled = False
        btAddArquivo.Enabled = False

        txDescricaoInicial_Novo.ReadOnly = True
        txEnvolvidosInicial_Novo.ReadOnly = True
        txLocalInicial_Novo.ReadOnly = True
        txMaterialInicial_Novo.ReadOnly = True
    End Sub

    Sub Habilitar_Campos()

        btBuscarPessoa.Visible = True
        btDescricaoAdicionar.Visible = True
        btGravar.Visible = True
        btGravarEnvolvido.Visible = True
        btLocalAdicionar.Visible = True
        btPesquisarLocal.Visible = True

        btGravar.Visible = True

        btAddDescricao.Enabled = True
        btAddEnvolvido.Enabled = True
        btAddLocal.Enabled = True
        btAddMaterial.Enabled = True
        btAddArquivo.Enabled = True

        txDescricaoInicial_Novo.ReadOnly = False
        txEnvolvidosInicial_Novo.ReadOnly = False
        txLocalInicial_Novo.ReadOnly = False
        txMaterialInicial_Novo.ReadOnly = False
    End Sub


    Protected Sub btIniciarCadastro_Click(sender As Object, e As EventArgs) Handles btIniciarCadastro.Click
        Habilitar_Campos()
        Dim cod_evento As String
        Dim a, b As New acesso
        cod_evento = a.No_Select_("INSERT INTO `evento`(`cod_categoria_evento`, `cod_natureza_evento`, `data_hora`, `cod_usuario`) VALUES ('" & ddCategoriaEvento.SelectedValue & "','" & ddNaturezaEvento.SelectedValue & "','" & txDataHoraEvento.Text & "','" & Session("cod_usuario") & "')")

        b.Select_("select cod from evento where cod='" & cod_evento & "'")
        b.reader.Read()
        lbID.Text = b.reader.Item(0)
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

        Dim a As New acesso
        a.Select_("SELECT l.cod,uf.descricao, c.descricao, l.bairro, l.rua, LEFT(l.obs, 20) FROM local l inner JOIN cidade c on l.cod_cidade=c.cod inner join uf on c.uf=uf.cod " &
                  "where uf.cod = " & ddUF.SelectedValue & " and c.cod = " & ddCidade.SelectedValue & " and l.bairro like '%" & txBairro.Text & "%' and l.rua like '%" & txRua.Text & "%' and l.obs like '%" & txObs.Text & "%' " &
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


    Protected Sub ddTipoEvento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddTipoEvento.SelectedIndexChanged
        natureza_evento_atualizar()
    End Sub

    Protected Sub btAddLocal_Click(sender As Object, e As EventArgs) Handles btAddLocal.Click
        If txLocalInicial_Novo.Text = "" Then Exit Sub

        Dim a As New acesso
        a.No_Select_("INSERT INTO `evento_inicial_local`(`descricao`, `cod_evento`, `cod_usuario`) VALUES ('" & txLocalInicial_Novo.Text & "','" & lbID.Text & "','" & Session("cod_usuario") & "');")
        txLocalInicial_Novo.Text = ""
        Atualizar_Pagina()
    End Sub

    Private Sub btAddEnvolvido_Click(sender As Object, e As EventArgs) Handles btAddEnvolvido.Click
        If txEnvolvidosInicial_Novo.Text = "" Then Exit Sub

        Dim a As New acesso
        a.No_Select_("INSERT INTO `evento_inicial_envolvido`(`descricao`, `cod_evento`, `cod_usuario`) VALUES ('" & txEnvolvidosInicial_Novo.Text & "','" & lbID.Text & "','" & Session("cod_usuario") & "');")
        txEnvolvidosInicial_Novo.Text = ""
        Atualizar_Pagina()
    End Sub

    Private Sub btAddMaterial_Click(sender As Object, e As EventArgs) Handles btAddMaterial.Click
        If txMaterialInicial_Novo.Text = "" Then Exit Sub

        Dim a As New acesso
        a.No_Select_("INSERT INTO `evento_inicial_material`(`descricao`, `cod_evento`, `cod_usuario`) VALUES ('" & txMaterialInicial_Novo.Text & "','" & lbID.Text & "','" & Session("cod_usuario") & "');")
        txMaterialInicial_Novo.Text = ""
        Atualizar_Pagina()
    End Sub

    Private Sub btAddDescricao_Click(sender As Object, e As EventArgs) Handles btAddDescricao.Click
        If txDescricaoInicial_Novo.Text = "" Then Exit Sub

        Dim a As New acesso
        a.No_Select_("INSERT INTO `evento_inicial_descricao`(`descricao`, `cod_evento`, `cod_usuario`) VALUES ('" & txDescricaoInicial_Novo.Text & "','" & lbID.Text & "','" & Session("cod_usuario") & "');")
        txDescricaoInicial_Novo.Text = ""
        Atualizar_Pagina()
    End Sub

    Private Sub btAddArquivo_Click(sender As Object, e As EventArgs) Handles btAddArquivo.Click

        'carregar arquivo no servidor de hospedagem
        Dim caminho_arquivo As String = Server.MapPath("/temp/" + FileUpload1.FileName)
        FileUpload1.PostedFile.SaveAs(Server.MapPath("/temp/" + FileUpload1.FileName))
        nome_arquivo = GetHash_MD5(GetHash_MD5(lbID.Text & Now) & "sal")

        byteArray = System.IO.File.ReadAllBytes(caminho_arquivo)
        stream1 = New System.IO.MemoryStream(byteArray)

        'criar pasta
        Dim criar_diretorio As Task = New Task(AddressOf Run_criar_diretorio)
        criar_diretorio.Start()
        While Not criar_diretorio.IsCompleted
            System.Threading.Thread.Sleep(500)
        End While

        'subir o aruqivo para o Dropbox
        Dim upload As Task = New Task(AddressOf Run_upload)
        upload.Start()

        While Not upload.IsCompleted
            btAddArquivo.Text = "Carregando..."
            btAddArquivo.Enabled = False

            System.Threading.Thread.Sleep(2000)
        End While

        'deletar o arquivo do servidor para manter somente do dropbox
        System.IO.File.Delete(caminho_arquivo)

        btAddArquivo.Text = "Adicionar Arquivo"
        btAddArquivo.Enabled = True
    End Sub

    Async Sub Run_upload()
        Try
            Using dbx = New DropboxClient("pGFlTCSEofAAAAAAAAAAC6l3DBLRQAYPbzaMzjUWdlhIwAHvB8yoUktTZtrGzW_n")
                Dim resultado = Await dbx.Files.UploadAsync("/" & lbID.Text & "/" & nome_arquivo, WriteMode.Overwrite.Instance, body:=stream1)
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Async Sub Run_criar_diretorio()
        Try
            Using dbx = New DropboxClient("pGFlTCSEofAAAAAAAAAAC6l3DBLRQAYPbzaMzjUWdlhIwAHvB8yoUktTZtrGzW_n")
                Dim resultado As FolderMetadata = Await dbx.Files.CreateFolderAsync("/" & lbID.Text, False)
            End Using
        Catch ex As Exception

        End Try

    End Sub

    Shared Function GetHash_MD5(theInput As String) As String

        Using hasher As MD5 = MD5.Create()    ' create hash object

            ' Convert to byte array and get hash
            Dim dbytes As Byte() =
                 hasher.ComputeHash(Encoding.UTF8.GetBytes(theInput))

            ' sb to create string from bytes
            Dim sBuilder As New StringBuilder()

            ' convert byte data to hex string
            For n As Integer = 0 To dbytes.Length - 1
                sBuilder.Append(dbytes(n).ToString("X2"))
            Next n

            Return sBuilder.ToString()
        End Using

    End Function

End Class
