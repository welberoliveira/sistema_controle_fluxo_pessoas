<%@ Page Title="" Language="VB" MasterPageFile="~/menu.master" AutoEventWireup="false" CodeFile="cidade.aspx.vb" Inherits="usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <Triggers>
        </Triggers>
        <ContentTemplate>
        <div>
            <div id="page-wrapper">
                <div class="row">
                    <div class="col-lg-12">
                        <h1 class="page-header">Cadastro de Cidades</h1>
                    </div>
                    <!-- /.col-lg-12 -->
                </div>
                <!-- /.row -->
                <div class="row">
                    <div class="col-lg-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                Cidades do Brasil
                            </div>
                            <div class="panel-body">
                                <div class="form-group ">                    
                                    <div class="row">                            
                                        <div class="col-lg-9">
                                            <asp:TextBox ID="txPesquisa" type="text" runat="server" Width="100%" class="form-control" placeholder="Pesquise aqui..." TextMode="Search" AutoPostBack="True"></asp:TextBox> 
                                        </div>
                                        <div class="col-lg-1">
                                            <span class="input-group-btn">
                                                <asp:LinkButton ID="btPesquisar" runat="server" class="btn btn-default"><i class="fa fa-search"></i></asp:LinkButton>
                                            </span>
                                        </div>
                                        <div class="col-lg-1">
                                            <span class="input-group-btn">
                                                <asp:LinkButton ID="btNovo" runat="server" class="btn btn-default"><i class="fa fa-plus"></i></asp:LinkButton>
                                            </span>
                                        </div>
                                    </div>   
                                </div>
                                <div class="form-group input-group">
                                    <asp:Literal ID="ltTabela" runat="server"></asp:Literal>
                                    <%--<table class="table">
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
                                    </table>--%>
                                </div>
                                <asp:Panel ID="panelCadastro" runat="server" Visible="false">
                                    <div class="form-group">
                                        <label>Nome da Cidade</label>
                                        <asp:TextBox ID="txCidade" type="text" runat="server" Width="100%" class="form-control" placeholder="Exemplo: Belo Horizonte"></asp:TextBox> 
                                    </div>
                                    <div class="form-group">
                                        <label>Estado (UF)</label>
                                        <asp:DropDownList ID="ddUF" runat="server" class="form-control">
                                        </asp:DropDownList>
                                    </div>
                                    <asp:Button ID="btGravar" runat="server" Text="Gravar" class="btn btn-default" Enabled="false"/>
                                    <asp:Button ID="btCancelar" runat="server" Text="Cancelar" class="btn btn-default"  Enabled="false"/>
                                </asp:Panel>
                            </div>
                        </div>                                
                    </div>
                </div>
            </div>
        </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

