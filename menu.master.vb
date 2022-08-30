
Partial Class menu
    Inherits System.Web.UI.MasterPage

    Private Sub menu_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("login") <> "1" Then
            Response.Redirect("login.aspx")
        End If
        lbUsuario.Text = Session("usuario")

        'menuzinho do topo direito
        If Session("perfil") = "0" Then
            ltMenuPerfilTop.Text = "<ul class=""nav navbar-top-links navbar-right""> " &
                "<!-- /.dropdown --> " &
                "<li class=""dropdown""> " &
                "    <a class=""dropdown-toggle"" data-toggle=""dropdown"" href=""#""> " &
                "        <i class=""fa fa-user fa-fw""></i> <i class=""fa fa-caret-down""></i> " &
                "    </a> " &
                "    <ul class=""dropdown-menu dropdown-user""> " &
                "        <li><a href=""usuario_perfil.aspx""><i class=""fa fa-user fa-fw""></i> Perfil</a> " &
                "        </li> " &
                "        <li><a href=""configuracoes.aspx""><i class=""fa fa-gear fa-fw""></i> Configurações</a> " &
                "        </li> " &
                "        <li class=""divider""></li> " &
                "        <li><a href=""sair.aspx""><i class=""fa fa-sign-out fa-fw""></i> Sair</a> " &
                "        </li> " &
                "    </ul> " &
                "    <!-- /.dropdown-user --> " &
                "</li> " &
                "<!-- /.dropdown --> " &
            "</ul> " &
            "<!-- /.navbar-top-links -->"
        Else
            ltMenuPerfilTop.Text = "<ul class=""nav navbar-top-links navbar-right""> " &
                "<!-- /.dropdown --> " &
                "<li class=""dropdown""> " &
                "    <a class=""dropdown-toggle"" data-toggle=""dropdown"" href=""#""> " &
                "        <i class=""fa fa-user fa-fw""></i> <i class=""fa fa-caret-down""></i> " &
                "    </a> " &
                "    <ul class=""dropdown-menu dropdown-user""> " &
                "        <li><a href=""sair.aspx""><i class=""fa fa-sign-out fa-fw""></i> Sair</a> " &
                "        </li> " &
                "    </ul> " &
                "    <!-- /.dropdown-user --> " &
                "</li> " &
                "<!-- /.dropdown --> " &
            "</ul> " &
            "<!-- /.navbar-top-links -->"
        End If

        'menu lateral esquerdo
        If Session("perfil") = "0" Then
            ltMenuLateralEsquerdo.Text = "<div class=""navbar-default sidebar"" role=""navigation""> " &
"                <div class=""sidebar-nav navbar-collapse""> " &
"                    <ul class=""nav"" id=""side-menu""> " &
"                        <li> " &
"                            <a href=""evento.aspx""><i class=""fa fa-edit fa-fw""></i> Eventos (Boletins e Relatórios)</a> " &
"                        </li> " &
"                        <li> " &
"                            <a href=""#""><i class=""fa fa-table fa-fw""></i> Cadastros<span class=""fa arrow""></span></a> " &
"                            <ul class=""nav nav-second-level""> " &
"                                <li> " &
"                                    <a href=""pessoa.aspx"">Pessoas</a> " &
"                                </li> " &
"                                <li> " &
"                                    <a href=""#"">Categoria do Evento</a> " &
"                                </li> " &
"                                <li> " &
"                                    <a href=""#"">Naturezas do Evento</a> " &
"                                </li> " &
"                                <li> " &
"                                    <a href=""#"">Tipos do Evento</a> " &
"                                </li> " &
"                                <li> " &
"                                    <a href=""#"">Tipos de Envolvimento</a> " &
"                                </li> " &
"                                <li> " &
"                                    <a href=""uf.aspx"">UF</a> " &
"                                </li> " &
"                                <li> " &
"                                    <a href=""cidade.aspx"">Cidade</a> " &
"                                </li> " &
"                                <li> " &
"                                    <a href=""local.aspx"">Local</a> " &
"                                </li> " &
"                            </ul> " &
"                            <!-- /.nav-secorend-level --> " &
"                        </li> " &
"                        <li> " &
"                            <a href=""usuarios.aspx""><i class=""fa fa-users fa-fw""></i> Usuários</a> " &
"                        </li> " &
"                        <li> " &
"                            <a href=""graficos.aspx""><i class=""fa fa-dashboard fa-fw""></i> Gráficos</a> " &
"                        </li> " &
"                    </ul> " &
"                </div> " &
"                <!-- /.sidebar-collapse --> " &
"            </div> " &
"            <!-- /.navbar-static-side --> "

        Else
            ltMenuLateralEsquerdo.Text = "<div class=""navbar-default sidebar"" role=""navigation""> " &
"                <div class=""sidebar-nav navbar-collapse""> " &
"                    <ul class=""nav"" id=""side-menu""> " &
"                        <li> " &
"                            <a href=""evento.aspx""><i class=""fa fa-edit fa-fw""></i> Eventos (Boletins e Relatórios)</a> " &
"                        </li> " &
"                    </ul> " &
"                </div> " &
"                <!-- /.sidebar-collapse --> " &
"            </div> " &
"            <!-- /.navbar-static-side --> "

        End If


    End Sub
End Class

