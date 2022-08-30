<%@ Page Title="" Language="VB" MasterPageFile="~/menu.master" AutoEventWireup="false" CodeFile="uf.aspx.vb" Inherits="usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>

             <div>
                <div id="page-wrapper">
                    <div class="row">
                        <div class="col-lg-12">
                            <h1 class="page-header">Cadastro de UF</h1>
                        </div>
                        <!-- /.col-lg-12 -->
                    </div>
                    <!-- /.row -->
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    Estados do Brasil
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
                                            </tbody>
                                        </table>
                                    </div>

                                    <div class="form-group">
                                        <label>Nome do Estado</label>
                                        <asp:TextBox ID="txNome" type="text" runat="server" Width="100%" class="form-control" placeholder="Exemplo: Minas Gerais"></asp:TextBox> 
                                    </div>
                                    
                                </div>
                                    </div>
                                    <asp:Button ID="btGravar" runat="server" Text="Gravar" class="btn btn-default"  Enabled="false"/>
                                    <asp:Button ID="btCancelar" runat="server" Text="Cancelar" class="btn btn-default"  Enabled="false"/>
                                </div>
                            </div>
                        </div>
                    </div>
    

</asp:Content>

