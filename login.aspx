<%@ Page Title="" Language="VB" MasterPageFile="~/principal.master" AutoEventWireup="false" CodeFile="login.aspx.vb" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" ></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <div id="container" class="container">
                    <br />
                    <center>
                        <img src="img/logo.PNG" style="width: 20%;"/>
                    </center>
                    <div class="col-lg-6 col-lg-offset-3">
                        <h1 class="page-header">Somente usuários autorizados</h1>
                    </div>
                    <!-- /.col-lg-12 -->
                </div>
                <!-- /.row -->
                <div class="row">
                    <div class="col-lg-6 col-lg-offset-3">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                Esteja com o celular em mãos para verificar o código de acesso.
                               
                            </div>
                            <div class="panel-body">
                                <div class="form-group">
                                    <label>Usuário</label>
                                    <asp:TextBox ID="txUsuario" type="text" runat="server" Width="100%" class="form-control" placeholder="Insira o usuário exemplo: jose.silva"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>Senha</label>
                                    <asp:TextBox ID="txSenha" type="text" runat="server" Width="100%" class="form-control" placeholder="Insira a senha do usuário" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <asp:Button ID="btEntrar" runat="server" Text="Entrar" class="btn btn-default" />
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>


