Imports System.Data
Imports System.Data.Odbc
Imports System.Net.Mail
Imports MySql.Data.MySqlClient



Public Class acesso

    Private conexao As MySqlConnection = New MySqlConnection("server=robb0258.publiccloud.com.br; database=fococonsultoria_db1; user id=fococ_db1; password=7Huk27w#7Huk27w#; pooling=false;")
    Public reader As MySqlDataReader




    Sub Select_(ByVal sql As String)
        'myConnection.Open()
        'strsql = "select * from usuario"
        'Dim command As MySqlCommand
        'command = New MySqlCommand(strsql, myConnection)
        'myDataReader = command.ExecuteReader()
        'myDataReader.Read()
        'Response.Write("asdf: " & myDataReader.Item(0).ToString)

        'Try 
        conexao.Open()
        Dim cmd_group_concat As MySqlCommand = New MySqlCommand("SET SESSION group_concat_max_len = 1000000;" & sql, conexao)
        reader = cmd_group_concat.ExecuteReader

        'Dim cmd As MySqlCommand = New MySqlCommand(sql, conexao)
        'reader = cmd.ExecuteReader

        'Catch ex As Exception
        'Em_Erro()
        'End Try
    End Sub

    Sub Select_Group_Concat(ByVal sql As String)
        'Try 
        conexao.Open()
        Dim cmd_group_concat As MySqlCommand = New MySqlCommand("SET SESSION group_concat_max_len = 1000000", conexao)
        cmd_group_concat.ExecuteNonQuery()

        cmd_group_concat.CommandText = sql

        reader = cmd_group_concat.ExecuteReader

        'Catch ex As Exception
        'Em_Erro()
        'End Try
    End Sub

    Sub Em_Erro(Optional str As String = "")
        'Exit Sub
        Try
            'If Not conexao.State.Open Then conexao.Open()
            Dim cmd As MySqlCommand = New MySqlCommand("INSERT INTO `__log`(`sql`) VALUES ('Try Catch Erro: " & str.Replace("'", "").Replace(",", "").Replace(")", "").Replace("(", "") & "')", conexao)
            cmd.ExecuteNonQuery()
            conexao.Close()
        Catch ex As Exception

        End Try

    End Sub

    Function No_Select_(ByVal sql As String) As String
        Dim retorno As String = "vazio"
        'Try
        conexao.Open()
        Dim cmd As MySqlCommand = New MySqlCommand(sql, conexao)
        cmd.ExecuteNonQuery()
        cmd.CommandText = "select last_insert_id();"
        reader = cmd.ExecuteReader
        reader.Read()
        retorno = reader.Item(0).ToString
        conexao.Close()
        'conexao = Nothing
        'Catch
        'Em_Erro()
        'End Try
        No_Select_ = retorno
    End Function

    Sub Close()
        Try
            reader.Close()
            conexao.Close()
            'conexao = Nothing
        Catch
            Em_Erro()
        End Try
    End Sub

    'Alerta usado para update panel
    Sub Alert_update(ByVal Mensagem As String, ByVal Pagina_Me As Page)
        Dim meuscript = "jAlert('" & Mensagem & "', 'Data Pgx');"
        ScriptManager.RegisterClientScriptBlock(Pagina_Me, Me.GetType(), "alert", meuscript, True)
    End Sub

    Sub Alert3(ByVal Mensagem As String, ByVal Pagina_Me As Page) 'mensagem anterior antes do response.write
        Dim meuscript = "jAlert('" & Mensagem & "', 'Data Pgx');"
        Pagina_Me.ClientScript.RegisterStartupScript(Me.GetType(), "meuscript", meuscript, True)
    End Sub

    Sub Alert2(ByVal Mensagem As String, ByVal Pagina_Me As Page)
        Dim meuscript = "alert('" & Mensagem & "');"
        Pagina_Me.ClientScript.RegisterStartupScript(Me.GetType(), "meuscript", meuscript, True)
    End Sub

    Sub Alert(ByVal Mensagem As String, ByVal Pagina_Me As Page)
        Dim msg As String
        Dim variavel As String = Now.Second & Now.Millisecond
        msg = "<div id=""msg" & variavel & """ align=""center"" style=""position: fixed; width: 163px; height:auto; right: 1px; top: 250px; background-color: #2063CD;padding-top: 4px;padding-bottom: 5px;color:yellow"" ><span><b>Message:</b></span><br /><span> "
        msg = msg & Mensagem
        msg = msg & "</span><br /></div>"
        msg = msg & "<script>setTimeout(function() {$('#msg" & variavel & "').fadeOut('slow');}, 4000);</script>"
        Pagina_Me.Response.Write(msg)
    End Sub

    Sub Tip(ByVal Mensagem As String, ByVal Pagina_Me As Page)
        Dim msg As String
        Dim variavel As String = Now.Second & Now.Millisecond 'height: 25px;
        msg = "<div id=""msg001234" & variavel & """ style=""position: absolute;width: 100%;z-index: 0;left: 0;top: 222;background-color:2063CD""> " &
        "        <div style=""float:left;width:90%""> " &
        "           <center> " &
        "                <span style=""color:yellow; font-weight: bold;margin-left: 10%;"">TIP: " & Mensagem & "</span> " &
        "            </center> " &
        "        </div> " &
        "        <div id=""msg00123" & variavel & """ style=""border-style: solid; float:right;width:25px; font-weight: bold; color: #FFFFFF""><center><span>X</span><center></div> " &
        "    </div> " &
        "    <script> " &
        "        function fechador() { " &
        "            fecha = document.getElementById(""msg00123" & variavel & """); " &
        "            fecha.onclick = function () { " &
        "                document.getElementById(""msg001234" & variavel & """).style.visibility = ""hidden""; " &
        "            } " &
        "        } " &
        "        fechador(); " &
        "    </script> "
        Pagina_Me.Response.Write(msg)
    End Sub
    Sub Div_Animate(ByVal Pagina As Page, ByVal Div_Elemento As String, ByVal Distancia As String, Optional ByVal Tempo As String = "300")
        'Dim meuscript = "document.getElementById('elemento_resultado').style.left = '500px';"

        Dim meuscript = "$('#" & Div_Elemento & "').animate({ marginLeft: '" & Distancia & "' }, " & Tempo & ", function() { });"
        Pagina.ClientScript.RegisterStartupScript(Me.GetType(), "meuscript", meuscript, True)
    End Sub

    'Function Atualizar_Grid(ByVal dst_Students As Data.DataSet, Optional ByVal Consulta_SQL As String = "Select * from clientes where false;")

    '    Dim DAD_Resultado As New OdbcDataAdapter(Consulta_SQL, strsql)

    '    conexao.Open()
    '    DAD_Resultado.Fill(dst_Students, "tblstudentinfo")
    '    conexao.Close()

    '    Return dst_Students

    'End Function




    Function Limpar_injection(ByVal Campo As TextBox) As String
        Dim Texto As String = Campo.Text
        Texto = Texto.Replace("'", "")
        Texto = Texto.Replace("!", "")
        Texto = Texto.Replace("#", "")
        Texto = Texto.Replace("$", "")
        Texto = Texto.Replace("%", "")
        Texto = Texto.Replace("¨", "")
        Texto = Texto.Replace("&", "")
        Texto = Texto.Replace("(", "")
        Texto = Texto.Replace(")", "")
        Texto = Texto.Replace("=", "")
        Texto = Texto.Replace("+", "")
        'Texto = Texto.Replace(",", "")
        Texto = Texto.Replace("´", "")
        Texto = Texto.Replace("`", "")
        Texto = Texto.Replace("[", "")
        Texto = Texto.Replace("]", "")
        Texto = Texto.Replace("{", "")
        Texto = Texto.Replace("}", "")
        Texto = Texto.Replace("|", "")
        Texto = Texto.Replace("\", "")
        Texto = Texto.Replace("<", "")
        Texto = Texto.Replace(">", "")
        Texto = Texto.Replace(";", "")
        Texto = Texto.Replace(":", "")
        Texto = Texto.Replace("^", "")
        Texto = Texto.Replace("~", "")
        Texto = Texto.Replace("?", "")
        Texto = Texto.Replace("*", "")
        Texto = Texto.Replace("insert", "")
        Texto = Texto.Replace("select", "")
        Texto = Texto.Replace("delete", "")
        Texto = Texto.Replace("updade", "")
        Texto = Texto.Replace(" set ", "")
        Texto = Texto.Replace(" into ", "")
        Texto = Texto.Replace(" join ", "")
        Texto = Texto.Replace("from", "")
        Texto = Texto.Replace("where", "")
        Texto = Texto.Replace(" values ", "")
        Texto = Texto.Replace(" like ", "")
        Texto = Texto.Replace(" isnot ", "")
        Texto = Texto.Replace(" and ", "")
        Texto = Texto.Replace(" or ", "")
        Texto = Texto.Replace(" in ", "")
        Texto = Texto.Replace("""", "")
        Texto = Texto.Replace("true", "")
        Texto = Texto.Replace("false", "")
        Return Texto
    End Function

    Function Criptografar(str As String) As String
        Dim byt As Byte() = System.Text.Encoding.UTF8.GetBytes(str)
        Dim retorno As String = Convert.ToBase64String(byt)
        retorno = retorno.Replace("=", "_")
        Return retorno

    End Function

    Function Descriptografar(str As String) As String
        Dim retorno As String = str
        retorno = retorno.Replace("_", "=")
        Dim b As Byte() = Convert.FromBase64String(retorno)
        Return System.Text.Encoding.UTF8.GetString(b)
    End Function


End Class







Public Class Acesso2
    Dim strsql2 = "Driver={MySQL ODBC 3.51 Driver};Server=robb0258.publiccloud.com.br;Database=fococonsultoria_db1;uid=fococ_db1;pwd=7Huk27w#7Huk27w#;" 'web
    Public reader As OdbcDataReader
    Private conexao As New OdbcConnection(strsql2)



    Sub Select_(ByVal sql As String)
        'Try 
        conexao.Open()
        Dim cmd_group_concat As OdbcCommand = New OdbcCommand("SET SESSION group_concat_max_len = 1000000", conexao)
        reader = cmd_group_concat.ExecuteReader

        Dim cmd As OdbcCommand = New OdbcCommand(sql, conexao)
        reader = cmd.ExecuteReader
        'Catch ex As Exception
        'Em_Erro()
        'End Try
    End Sub

    Sub Select_Group_Concat(ByVal sql As String)
        'Try 
        conexao.Open()
        Dim cmd_group_concat As OdbcCommand = New OdbcCommand("SET SESSION group_concat_max_len = 1000000", conexao)
        cmd_group_concat.ExecuteNonQuery()

        cmd_group_concat.CommandText = sql

        reader = cmd_group_concat.ExecuteReader

        'Catch ex As Exception
        'Em_Erro()
        'End Try
    End Sub

    'Sub Em_Erro(Optional str As String = "")
    '    'Exit Sub
    '    Try
    '        If Not conexao.State.Open Then conexao.Open()
    '        Dim cmd As OdbcCommand = New OdbcCommand("INSERT INTO `__log`(`sql`) VALUES ('Try Catch Erro: " & str.Replace("'", "").Replace(",", "").Replace(")", "").Replace("(", "") & "')", conexao)
    '        cmd.ExecuteNonQuery()
    '        conexao.Close()
    '    Catch ex As Exception

    '    End Try

    'End Sub

    Function No_Select_(ByVal sql As String) As String
        Dim retorno As String = "vazio"
        'Try
        conexao.Open()
        Dim cmd As OdbcCommand = New OdbcCommand(sql, conexao)
        cmd.ExecuteNonQuery()
        cmd.CommandText = "select last_insert_id();"
        reader = cmd.ExecuteReader
        reader.Read()
        retorno = reader.Item(0).ToString
        conexao.Close()
        'conexao = Nothing
        'Catch
        'Em_Erro()
        'End Try
        No_Select_ = retorno
    End Function

    Sub Close()
        Try
            reader.Close()
            conexao.Close()
            'conexao = Nothing
        Catch
            'Em_Erro()
        End Try
    End Sub

    'Alerta usado para update panel
    Sub Alert_update(ByVal Mensagem As String, ByVal Pagina_Me As Page)
        Dim meuscript = "jAlert('" & Mensagem & "', 'Data Pgx');"
        ScriptManager.RegisterClientScriptBlock(Pagina_Me, Me.GetType(), "alert", meuscript, True)
    End Sub

    Sub Alert3(ByVal Mensagem As String, ByVal Pagina_Me As Page) 'mensagem anterior antes do response.write
        Dim meuscript = "jAlert('" & Mensagem & "', 'Data Pgx');"
        Pagina_Me.ClientScript.RegisterStartupScript(Me.GetType(), "meuscript", meuscript, True)
    End Sub

    Sub Alert2(ByVal Mensagem As String, ByVal Pagina_Me As Page)
        Dim meuscript = "alert('" & Mensagem & "');"
        Pagina_Me.ClientScript.RegisterStartupScript(Me.GetType(), "meuscript", meuscript, True)
    End Sub

    Sub Alert(ByVal Mensagem As String, ByVal Pagina_Me As Page)
        Dim msg As String
        Dim variavel As String = Now.Second & Now.Millisecond
        msg = "<div id=""msg" & variavel & """ align=""center"" style=""position: fixed; width: 163px; height:auto; right: 1px; top: 250px; background-color: #2063CD;padding-top: 4px;padding-bottom: 5px;color:yellow"" ><span><b>Message:</b></span><br /><span> "
        msg = msg & Mensagem
        msg = msg & "</span><br /></div>"
        msg = msg & "<script>setTimeout(function() {$('#msg" & variavel & "').fadeOut('slow');}, 4000);</script>"
        Pagina_Me.Response.Write(msg)
    End Sub

    Sub Tip(ByVal Mensagem As String, ByVal Pagina_Me As Page)
        Dim msg As String
        Dim variavel As String = Now.Second & Now.Millisecond 'height: 25px;
        msg = "<div id=""msg001234" & variavel & """ style=""position: absolute;width: 100%;z-index: 0;left: 0;top: 222;background-color:2063CD""> " &
        "        <div style=""float:left;width:90%""> " &
        "           <center> " &
        "                <span style=""color:yellow; font-weight: bold;margin-left: 10%;"">TIP: " & Mensagem & "</span> " &
        "            </center> " &
        "        </div> " &
        "        <div id=""msg00123" & variavel & """ style=""border-style: solid; float:right;width:25px; font-weight: bold; color: #FFFFFF""><center><span>X</span><center></div> " &
        "    </div> " &
        "    <script> " &
        "        function fechador() { " &
        "            fecha = document.getElementById(""msg00123" & variavel & """); " &
        "            fecha.onclick = function () { " &
        "                document.getElementById(""msg001234" & variavel & """).style.visibility = ""hidden""; " &
        "            } " &
        "        } " &
        "        fechador(); " &
        "    </script> "
        Pagina_Me.Response.Write(msg)
    End Sub
    Sub Div_Animate(ByVal Pagina As Page, ByVal Div_Elemento As String, ByVal Distancia As String, Optional ByVal Tempo As String = "300")
        'Dim meuscript = "document.getElementById('elemento_resultado').style.left = '500px';"

        Dim meuscript = "$('#" & Div_Elemento & "').animate({ marginLeft: '" & Distancia & "' }, " & Tempo & ", function() { });"
        Pagina.ClientScript.RegisterStartupScript(Me.GetType(), "meuscript", meuscript, True)
    End Sub

    'Function Atualizar_Grid(ByVal dst_Students As Data.DataSet, Optional ByVal Consulta_SQL As String = "Select * from clientes where false;")

    '    Dim DAD_Resultado As New OdbcDataAdapter(Consulta_SQL, strsql)

    '    conexao.Open()
    '    DAD_Resultado.Fill(dst_Students, "tblstudentinfo")
    '    conexao.Close()

    '    Return dst_Students

    'End Function


    Function GridView_MySql(ByVal sql As String) As DataTable
        Try
            conexao.Open()
            Dim cmd As OdbcCommand = New OdbcCommand(sql, conexao)
            Dim da As OdbcDataAdapter = New OdbcDataAdapter(cmd)
            GridView_MySql = New DataTable("tbl")
            da.Fill(GridView_MySql)
            da.Dispose()
            conexao.Close()
            conexao = Nothing
        Catch
            'Exit Function
        End Try
    End Function


    Function Limpar_injection(ByVal Campo As TextBox) As String
        Dim Texto As String = Campo.Text
        Texto = Texto.Replace("'", "")
        Texto = Texto.Replace("!", "")
        Texto = Texto.Replace("#", "")
        Texto = Texto.Replace("$", "")
        Texto = Texto.Replace("%", "")
        Texto = Texto.Replace("¨", "")
        Texto = Texto.Replace("&", "")
        Texto = Texto.Replace("(", "")
        Texto = Texto.Replace(")", "")
        Texto = Texto.Replace("=", "")
        Texto = Texto.Replace("+", "")
        'Texto = Texto.Replace(",", "")
        Texto = Texto.Replace("´", "")
        Texto = Texto.Replace("`", "")
        Texto = Texto.Replace("[", "")
        Texto = Texto.Replace("]", "")
        Texto = Texto.Replace("{", "")
        Texto = Texto.Replace("}", "")
        Texto = Texto.Replace("|", "")
        Texto = Texto.Replace("\", "")
        Texto = Texto.Replace("<", "")
        Texto = Texto.Replace(">", "")
        Texto = Texto.Replace(";", "")
        Texto = Texto.Replace(":", "")
        Texto = Texto.Replace("^", "")
        Texto = Texto.Replace("~", "")
        Texto = Texto.Replace("?", "")
        Texto = Texto.Replace("*", "")
        Texto = Texto.Replace("insert", "")
        Texto = Texto.Replace("select", "")
        Texto = Texto.Replace("delete", "")
        Texto = Texto.Replace("updade", "")
        Texto = Texto.Replace(" set ", "")
        Texto = Texto.Replace(" into ", "")
        Texto = Texto.Replace(" join ", "")
        Texto = Texto.Replace("from", "")
        Texto = Texto.Replace("where", "")
        Texto = Texto.Replace(" values ", "")
        Texto = Texto.Replace(" like ", "")
        Texto = Texto.Replace(" isnot ", "")
        Texto = Texto.Replace(" and ", "")
        Texto = Texto.Replace(" or ", "")
        Texto = Texto.Replace(" in ", "")
        Texto = Texto.Replace("""", "")
        Texto = Texto.Replace("true", "")
        Texto = Texto.Replace("false", "")
        Return Texto
    End Function

    Function enviaMensagemEmail(ByVal from As String, ByVal recepient As String, ByVal bcc As String,
    ByVal cc As String, ByVal subject As String, ByVal body As String, ByVal header_name As String,
    ByVal header_value As String, ByVal smtp As String, ByVal porta As String, ByVal usuario As String, ByVal senha As String) As Boolean

        Try
            ' cria uma instância do objeto MailMessage
            Dim mMailMessage As New MailMessage()
            ' Define o endereço do remetente
            mMailMessage.From = New MailAddress(from)

            ' Define o destinario da mensagem
            Try
                mMailMessage.To.Add(New MailAddress(recepient))
            Catch ex As Exception
                enviaMensagemEmail = False
                Exit Function
            End Try

            ' Verifica se o valor para bcc é null ou uma string vazia
            If Not bcc Is Nothing And bcc <> String.Empty Then
                ' Define o endereço bcc
                Try
                    mMailMessage.Bcc.Add(New MailAddress(bcc))
                Catch ex As Exception
                    enviaMensagemEmail = False
                    Exit Function
                End Try
            End If

            ' verifica se o valor para cc é nulo ou uma string vazia
            If Not cc Is Nothing And cc <> String.Empty Then
                ' Define o endereço cc 
                Try
                    mMailMessage.CC.Add(New MailAddress(cc))
                Catch ex As Exception
                    enviaMensagemEmail = False
                    Exit Function
                End Try
            End If

            ' Define o assunto 
            mMailMessage.Subject = subject
            ' Define o corpo da mensagem
            mMailMessage.Body = body

            ' Define o formato do email como HTML
            mMailMessage.IsBodyHtml = True
            ' Define a prioridade da mensagem como normal
            mMailMessage.Priority = MailPriority.Normal

            ' Cria uma instância de SmtpClient - Nota - Define qual o host a ser usado para envio 
            ' de mensagens, no local de smtp.server.com use o nome do SEU servidor
            Dim mSmtpClient As New SmtpClient(smtp)
            ' Envia o email
            'mSmtpClient.EnableSsl = True

            mSmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network
            mSmtpClient.UseDefaultCredentials = False
            'mSmtpClient.Credentials = New System.Net.NetworkCredential("welberoliveira3@gmail.com", "Ax6oVSxQpLp4wg1pOg14Mg")
            mSmtpClient.Credentials = New System.Net.NetworkCredential(usuario, senha)
            mSmtpClient.Host = smtp
            mSmtpClient.Port = porta
            'mMailMessage.Headers.Add("X-MC-Subaccount", SubConta_Mandrill)
            mMailMessage.Headers.Add(header_name, header_value)

            mSmtpClient.Send(mMailMessage)
            enviaMensagemEmail = True
        Catch
            Exit Function
        End Try
    End Function

    Function Criptografar(str As String) As String
        Dim byt As Byte() = System.Text.Encoding.UTF8.GetBytes(str)
        Dim retorno As String = Convert.ToBase64String(byt)
        retorno = retorno.Replace("=", "_")
        Return retorno

    End Function

    Function Descriptografar(str As String) As String
        Dim retorno As String = str
        retorno = retorno.Replace("_", "=")
        Dim b As Byte() = Convert.FromBase64String(retorno)
        Return System.Text.Encoding.UTF8.GetString(b)
    End Function


End Class
