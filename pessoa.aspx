<%@ Page Title="" Language="VB" MasterPageFile="~/menu.master" AutoEventWireup="false" CodeFile="pessoa.aspx.vb" Inherits="usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<%--    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">--%>
        <Triggers>
        </Triggers>
        <ContentTemplate>
        <div>
            <div id="page-wrapper">
                <div class="row">
                    <div class="col-lg-12">
                        <h1 class="page-header">Cadastro de Pessoas</h1>
                    </div>
                    <!-- /.col-lg-12 -->
                </div>
                <!-- /.row -->
                <asp:Panel ID="panelPesquisa" runat="server">
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    Cadastro Geral de Pessoas
                                </div>
                                <div class="panel-body">
                                
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
                                    </div>
                                
                                </div>
                            </div>
                        </div>
                    </div>
                </asp:Panel>



                <asp:Panel ID="panelCadastro" runat="server" Visible="false">
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    Dados Básicos
                                </div>
                                <div class="panel-body">
                                    <div class="form-group ">
                                        <div class="row">    
                                            <div class="col-lg-3">                        
                                                <asp:Button ID="btIniciarCadastro" runat="server" Text="Iniciar Cadastro" class="btn btn-default" />
                                            </div>
                                            <div class="col-lg-7"></div>
                                            <div class="col-lg-2">                        
                                                <label>ID:</label>
                                                <asp:Label ID="lbID" runat="server" Text="000000"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group ">
                                        <div class="row">                            
                                            <div class="col-lg-4">
                                                <label>Nome</label>
                                                <asp:TextBox ID="txNome" type="text" runat="server" Width="100%" class="form-control" placeholder="Exemplo: João Pedro"></asp:TextBox> 
                                            </div>
                                            <div class="col-lg-4">
                                                <label>Alcunho</label>
                                                <asp:TextBox ID="txApelido" type="text" runat="server" Width="100%" class="form-control" placeholder="Exemplo: Pepeu, Jotapê"></asp:TextBox> 
                                            </div>
                                            <div class="col-lg-4">
                                                <label>CPF</label>
                                                <asp:TextBox ID="txCPF" type="text" runat="server" Width="100%" class="form-control" placeholder="Exemplo: 123.123.123-12"></asp:TextBox> 
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group ">
                                        <div class="row">                            
                                            <div class="col-lg-4">
                                                <label>RG</label>
                                                <asp:TextBox ID="txRG" type="text" runat="server" Width="100%" class="form-control" placeholder="Exemplo: MG10101010"></asp:TextBox> 
                                            </div>
                                            <div class="col-lg-4">
                                                <label>CNPJ</label>
                                                <asp:TextBox ID="txCNPJ" type="text" runat="server" Width="100%" class="form-control" placeholder="Exemplo: 10.123.123/0001-12"></asp:TextBox> 
                                            </div>
                                            <div class="col-lg-4">
                                                <label>Data de Nascimento</label>
                                                <asp:TextBox ID="txDataNascimento" type="text" runat="server" Width="100%" class="form-control" placeholder="Exemplo: 01/01/2001"></asp:TextBox> 
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group ">
                                        <div class="row">    
                                            <div class="col-lg-11"></div>
                                            <div class="col-lg-1" style="padding-left: 3px;">                        
                                                <asp:Button ID="btGravar" runat="server" Text="Gravar" class="btn btn-default" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group ">
                                        <div class="row"> 
                                            <div class="col-lg-12">  
                                                <label>Endereços e Locais cadastrados</label> 
                                                <asp:Literal ID="ltTabelaEnderecos" runat="server"></asp:Literal>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group ">
                                        <div class="row"> 
                                            <div class="col-lg-4">  
                                                <label>Telefones Cadastrados</label> 
                                                <asp:Literal ID="ltTabelaTelefones" runat="server"></asp:Literal>
                                            </div>
                                            <div class="col-lg-4">  
                                                <label>Redes Sociais</label> 
                                                <asp:Literal ID="ltTabelaRedesSociais" runat="server"></asp:Literal>
                                            </div> 
                                            <div class="col-lg-4">  
                                                <label>E-mails</label> 
                                                <asp:Literal ID="ltTabelaEmails" runat="server"></asp:Literal>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
            </asp:Panel>


            <asp:Panel ID="panelPesquisaLocal" runat="server" Visible="false">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                Pesquisa de Endereços e Locais
                            </div>
                            <div class="panel-body">
                                <div class="form-group ">
                                    <div class="row">                            
                                        <div class="col-lg-2">
                                            <label>UF</label>
                                            <asp:DropDownList ID="ddUF" runat="server" class="form-control" AutoPostBack="True">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-lg-2">
                                            <label>Cidade</label>
                                            <asp:DropDownList ID="ddCidade" runat="server" class="form-control">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-lg-2">
                                            <label>Bairro</label>
                                            <asp:TextBox ID="txBairro" type="text" runat="server" Width="100%" class="form-control" placeholder="Exemplo: Centro"></asp:TextBox> 
                                        </div>
                                        <div class="col-lg-2">
                                            <label>Rua e Número</label>
                                            <asp:TextBox ID="txRua" type="text" runat="server" Width="100%" class="form-control" placeholder="Exemplo: Rua A, 10, apto 402"></asp:TextBox> 
                                        </div>
                                        <div class="col-lg-2">
                                            <label>Observação</label>
                                            <asp:TextBox ID="txObs" type="text" runat="server" Width="100%" class="form-control" placeholder="Exemplo: próximo ao EPA"></asp:TextBox> 
                                        </div>
                                        <div class="col-lg-1">
                                            <label> </label>
                                            <span class="input-group-btn">
                                                <asp:LinkButton ID="btPesquisarLocal" runat="server" class="btn btn-default"><i class="fa fa-search"></i></asp:LinkButton>
                                            </span>
                                        </div>
                                        <div class="col-lg-1">
                                            <label> </label>
                                            <span class="input-group-btn">
                                                <a href="local.aspx" target="_blank" class="btn btn-default"><i class="fa fa-plus"></i></a>
                                            </span>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group ">
                                    <div class="row">                            
                                        <div class="col-lg-6">
                                            <label>Endereços</label>
                                            <asp:DropDownList ID="ddBuscaEnderecos" runat="server" class="form-control">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-lg-4">
                                            <label>Tipo de Endereço</label>
                                            <asp:DropDownList ID="ddTipoLocal" runat="server" class="form-control">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-lg-2">
                                            <label> </label>
                                            <span class="input-group-btn">
                                                <asp:LinkButton ID="btLocalAdicionar" runat="server" class="btn btn-default"><i class="fa fa-check"></i></asp:LinkButton>
                                            </span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>                
                </div>
            </asp:Panel>





            <asp:Panel ID="panelTelefonesRedesSociais" runat="server" Visible="false">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                Inserir Telefones, Redes Sociais e e-mails
                            </div>
                            <div class="panel-body">
                                <div class="form-group ">
                                    <div class="row">                            
                                        <div class="col-lg-6">
                                            <label>Telefone</label>
                                            <asp:TextBox ID="txTelefoneAdicionar" type="text" runat="server" Width="100%" class="form-control" placeholder="Exemplo: 31 12345-1234"></asp:TextBox> 
                                        </div>
                                        <div class="col-lg-1">
                                            <label> </label>
                                            <span class="input-group-btn">
                                                <asp:LinkButton ID="btTelefoneAdicionar" runat="server" class="btn btn-default"><i class="fa fa-check"></i></asp:LinkButton>
                                            </span>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group ">
                                    <div class="row">                            
                                        <div class="col-lg-4">
                                            <label>Redes Sociais</label>
                                            <asp:TextBox ID="txRedesSociaisAdicionar" type="text" runat="server" Width="100%" class="form-control" placeholder="Exemplo: joao.pedro"></asp:TextBox> 
                                        </div>
                                        <div class="col-lg-2">
                                            <label>&nbsp</label>
                                            <asp:DropDownList ID="ddTipoRedeSocial" runat="server" class="form-control">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-lg-1">
                                            <label> </label>
                                            <span class="input-group-btn">
                                                <asp:LinkButton ID="btRedesSociaisAdicionar" runat="server" class="btn btn-default"><i class="fa fa-check"></i></asp:LinkButton>
                                            </span>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group ">
                                    <div class="row">                            
                                        <div class="col-lg-6">
                                            <label>E-mails</label>
                                            <asp:TextBox ID="txEmailAdicionar" type="text" runat="server" Width="100%" class="form-control" placeholder="Exemplo: joao.pedro@email.com"></asp:TextBox> 
                                        </div>
                                        <div class="col-lg-1">
                                            <label> </label>
                                            <span class="input-group-btn">
                                                <asp:LinkButton ID="btEmailAdicionar" runat="server" class="btn btn-default"><i class="fa fa-check"></i></asp:LinkButton>
                                            </span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>                
                </div>
                <div class="form-group ">
                    <div class="row">    
                        <div class="col-lg-3">                        
                            <asp:Button ID="Button2" runat="server" Text="Fechar" class="btn btn-default" />
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

