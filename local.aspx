<%@ Page Title="" Language="VB" MasterPageFile="~/menu.master" AutoEventWireup="false" CodeFile="local.aspx.vb" Inherits="usuarios" %>

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
                        <h1 class="page-header">Cadastro de Local</h1>
                    </div>
                    <!-- /.col-lg-12 -->
                </div>
                <!-- /.row -->
                <div class="row">
                    <div class="col-lg-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                Local
                            </div>
                            <div class="panel-body">
                                <asp:Panel ID="panelPesquisa" runat="server">
                                    <div class="form-group ">                    
                                        <div class="row">                            
                                            <div class="col-lg-6">
                                                <asp:TextBox ID="txPesquisa" type="text" runat="server" Width="100%" class="form-control" placeholder="Pesquisa geral..." TextMode="Search"></asp:TextBox> 
                                            </div>
                                            <div class="col-lg-3">
                                                <asp:TextBox ID="txPesquisaCidade" type="text" runat="server" Width="100%" class="form-control" placeholder="Pesquisa cidade" TextMode="Search"></asp:TextBox> 
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
                                </asp:Panel>

                                <asp:Panel ID="panelCadastro" runat="server" Visible="false">
                                    <div class="form-group">
                                        <label>Estado (UF)</label>
                                        <asp:DropDownList ID="ddUF" runat="server" class="form-control" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <label>Cidade</label>
                                        <asp:DropDownList ID="ddCidade" runat="server" class="form-control">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <label>Bairro</label>
                                        <asp:TextBox ID="txBairro" type="text" runat="server" Width="100%" class="form-control" placeholder="Exemplo: Centro"></asp:TextBox> 
                                    </div>
                                    <div class="form-group">
                                        <label>Rua, Número e Complemento</label>
                                        <asp:TextBox ID="txRua" type="text" runat="server" Width="100%" class="form-control" placeholder="Exemplo: Rua A, 10, apto 402"></asp:TextBox> 
                                    </div>
                                    <div class="form-group">
                                        <label>Observação</label>
                                        <asp:TextBox ID="txObs" type="text" runat="server" Width="100%" class="form-control" placeholder="Exemplo: próximo ao EPA"></asp:TextBox> 
                                    </div>
                                    
                                    <asp:Button ID="btGravar" runat="server" Text="Gravar" class="btn btn-default" />
                                    <asp:Button ID="btCancelar" runat="server" Text="Cancelar" class="btn btn-default" />
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

