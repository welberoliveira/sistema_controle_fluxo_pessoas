<%@ Page Title="" Language="VB" MasterPageFile="~/menu.master" AutoEventWireup="false" CodeFile="usuarios.aspx.vb" Inherits="usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>

             <div>
                <div id="page-wrapper">
                    <div class="row">
                        <div class="col-lg-12">
                            <h1 class="page-header">Cadastro de Usuários</h1>
                        </div>
                        <!-- /.col-lg-12 -->
                    </div>
                    <!-- /.row -->
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    Usuários do sistema
                                </div>
                                <div class="panel-body">
                                    <div class="form-group ">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="btPesquisar" EventName="Click" />
                                            </Triggers>
                                            <ContentTemplate>
                                                <div class="row">                            
                                                    <div class="col-lg-9">
                                                        <asp:TextBox ID="txPesquisa" type="text" runat="server" Width="100%" class="form-control" placeholder="Pesquise um usuário" TextMode="Search" AutoPostBack="True"></asp:TextBox> 
                                                    </div>
                                                    <div class="col-lg-3">
                                                        <span class="input-group-btn">
                                                            <asp:LinkButton ID="btPesquisar" runat="server" class="btn btn-default"><i class="fa fa-search"></i></asp:LinkButton>
                                                        </span>
                                                    </div>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        
                                    </div>
                                    <div class="form-group input-group">
                                        <table class="table">
                                            <tbody>
                                                    <tr>
                                                        <td>Mark Otto</td>
                                                        <td>mark.otto</td>
                                                        <td>(31) 99999-8888</td>
                                                    </tr>
                                                    <tr>
                                                        <td>Jacob Thornton</td>
                                                        <td>jacob.thornton</td>
                                                        <td>(31) 99999-8888</td>
                                                    </tr>
                                                    <tr>
                                                        <td>Larry the Bird</td>
                                                        <td>larry.bird</td>
                                                        <td>(31) 99999-8888</td>
                                                    </tr>
                                                </tbody>
                                        </table>
                                    </div>

                                    <div class="form-group">
                                        <label>Login</label>
                                        <asp:TextBox ID="txLogin" type="text" runat="server" Width="100%" class="form-control" placeholder="Insira o Login do usuário exemplo: jose.silva"></asp:TextBox> 
                                    </div>
                                    <div class="form-group">
                                        <label>Senha</label>
                                        <asp:TextBox ID="txSenha" type="text" runat="server" Width="100%" class="form-control" placeholder="Insira a senha do usuário (mínimo 4 digitos)" TextMode="Password"></asp:TextBox> 
                                    </div>
                                    <div class="form-group">
                                        <label>Perfil</label>
                                        <asp:DropDownList ID="ddPerfil" runat="server" class="form-control">
                                            <asp:ListItem Selected="True" Value="1">Básico</asp:ListItem>
                                            <asp:ListItem Value="0">Administrador</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <label>Telefone 1</label>
                                        <asp:TextBox ID="txTel1" type="text" runat="server" Width="100%" class="form-control" placeholder="(31) 88888-9999" TextMode="Phone"></asp:TextBox> 
                                    </div>
                                    <div class="form-group">
                                        <label>Telefone 2</label>
                                        <asp:TextBox ID="txTel2" type="text" runat="server" Width="100%" class="form-control" placeholder="(31) 88888-9999" TextMode="Phone"></asp:TextBox> 
                                    </div>
                                    <div class="form-group">
                                        <label>E-mail</label>
                                        <asp:TextBox ID="txEmail" type="text" runat="server" Width="100%" class="form-control" placeholder="meu@email.com" TextMode="Email"></asp:TextBox> 
                                    </div>
                                    <div class="form-group">
                                        <label>Status</label>
                                        <asp:DropDownList ID="ddStatus" runat="server" class="form-control">
                                            <asp:ListItem Selected="True" Value="1">Ativo</asp:ListItem>
                                            <asp:ListItem Value="0">Inativo</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                    </div>
                                    <asp:Button ID="btGravar" runat="server" Text="Gravar" class="btn btn-default"  Enabled="false"/>
                                    <asp:Button ID="btCancelar" runat="server" Text="Cancelar" class="btn btn-default"  Enabled="false" />
                                </div>
                            </div>
                        </div>
                    </div>
    

</asp:Content>

