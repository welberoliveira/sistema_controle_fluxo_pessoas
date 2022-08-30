<%@ Page Title="" Language="VB" MasterPageFile="~/menu.master" AutoEventWireup="false" CodeFile="evento.aspx.vb" Inherits="usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    

        <div>
            <div id="page-wrapper">
                <div class="row">
                    <div class="col-lg-12">
                        <h1 class="page-header">Cadastro de Ocorrências e Relatórios de Inteligência</h1>
                    </div>
                    <!-- /.col-lg-12 -->
                </div>
                <!-- /.row -->

        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
            
                <asp:Panel ID="panelPesquisa" runat="server">
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    Boletins e Relatórios
                                </div>
                                <div class="panel-body">
                                
                                    <div class="form-group ">                    
                                        <div class="row">                            
                                            <div class="col-lg-9">
                                                <asp:TextBox ID="txPesquisa" type="text" runat="server" Width="100%" class="form-control" placeholder="Pesquisa geral..." TextMode="Search"></asp:TextBox> 
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
            
            </ContentTemplate>
        </asp:UpdatePanel>
            
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                
                <asp:Panel ID="panelCadastro" runat="server" Visible="false">
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
                                                <label>Categoria do Evento</label>
                                                <asp:DropDownList ID="ddCategoriaEvento" runat="server" class="form-control">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-lg-3">
                                                <label>Tipo do Evento</label>
                                                <asp:DropDownList ID="ddTipoEvento" runat="server" class="form-control" AutoPostBack="true">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-lg-3">
                                                <label>Natureza do Evento</label>
                                                <asp:DropDownList ID="ddNaturezaEvento" runat="server" class="form-control">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-lg-2">
                                                <label>Data e hora</label>
                                                <asp:TextBox ID="txDataHoraEvento" type="text" runat="server" Width="103%" class="form-control" placeholder="01/01/2001 01:01" TextMode="DateTime" ValidateRequestMode="Enabled"></asp:TextBox>
                                            </div>
                                            <div class="col-lg-1" style="padding-left: 3px;">
                                                <label>&nbsp</label>
                                                <asp:Button ID="btGravar" runat="server" Text="Gravar" class="btn btn-default" OnClick="btGravar_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </asp:Panel>

            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btGravar" EventName="Click" />
            </Triggers>
            
        </asp:UpdatePanel>


        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
            <ContentTemplate>

                <asp:Panel ID="panelLevantamentoInicial" runat="server" Visible="false">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                Levantamento Inicial
                            </div>
                            <div class="panel-body">
                                <div class="form-group ">
                                    <div class="row">
                                        <div class="col-lg-5">
                                            <label>Local: Novo</label>
                                            <asp:TextBox ID="txLocalInicial_Novo" type="text" runat="server" Width="100%" Height="100" class="form-control" placeholder="Exemplo: Rua das Flores, 12 - Bairro Centro, Cidade Belo Horizonte. Próximo da padaria e depois da praça." TextMode="MultiLine"></asp:TextBox> 
                                        </div>
                                        <div class="col-lg-2" style="margin-top: 5%;margin-bottom: 5%;text-align:center">
                                            <asp:Button ID="btAddLocal" runat="server" Text="Adicionar Local" class="btn btn-sm" />
                                        </div>
                                        <div class="col-lg-5">
                                            <div class="form-control" style="overflow-y:scroll;height:150px;border:1px solid #b5b5b5;margin:6px">
                                                <label>Local: Histórico</label><br />
                                                <asp:Literal ID="ltLocalInicial_Historico" runat="server"></asp:Literal>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-5">
                                            <label>Envolvidos: Novo</label>
                                            <asp:TextBox ID="txEnvolvidosInicial_Novo" type="text" runat="server" Width="100%" Height="100" class="form-control" placeholder="Exemplo: José da Silva, 36 anos, CPF: 123.123.123-12, RG: 12.312.311, Endereço: Rua Cinco, 12 - Centro, S. Lagoas (Vítima)" TextMode="MultiLine"></asp:TextBox> 
                                        </div>
                                        <div class="col-lg-2" style="margin-top: 5%;margin-bottom: 5%;text-align:center">
                                            <asp:Button ID="btAddEnvolvido" runat="server" Text="Adicionar Envolvido" class="btn btn-sm" />
                                        </div>
                                        <div class="col-lg-5">
                                            <div class="form-control" style="overflow-y:scroll;height:150px;border:1px solid #b5b5b5;margin:6px">
                                                <label>Envolvidos: Histórico</label><br />
                                                <asp:Literal ID="ltEnvolvidosInicial_Historico" runat="server"></asp:Literal>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-5">
                                            <label>Materiais: Novo</label>
                                            <asp:TextBox ID="txMaterialInicial_Novo" type="text" runat="server" Width="100%" Height="100" class="form-control" placeholder="Exemplo: Celular, máquina fotográfica, televisão..." TextMode="MultiLine"></asp:TextBox> 
                                        </div>
                                        <div class="col-lg-2" style="margin-top: 5%;margin-bottom: 5%;text-align:center">
                                            <asp:Button ID="btAddMaterial" runat="server" Text="Adicionar Material" class="btn btn-sm" />
                                        </div>
                                        <div class="col-lg-5">
                                            <div class="form-control" style="overflow-y:scroll;height:150px;border:1px solid #b5b5b5;margin:6px">
                                                <label>Materiais: Histórico</label><br />
                                                <asp:Literal ID="ltMaterialInicial_Historico" runat="server"></asp:Literal>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-5">
                                            <label>Descrição: Novo</label>
                                            <asp:TextBox ID="txDescricaoInicial_Novo" type="text" runat="server" Width="100%" Height="150" class="form-control" placeholder="Exemplo: A vítima se locomovia pela rua quando foi abordada..." TextMode="MultiLine"></asp:TextBox> 
                                        </div>
                                        <div class="col-lg-2" style="margin-top: 5%;margin-bottom: 5%;text-align:center">
                                            <asp:Button ID="btAddDescricao" runat="server" Text="Adicionar Descrição" class="btn btn-sm" />
                                        </div>
                                        <div class="col-lg-5">
                                            <div class="form-control" style="overflow-y:scroll;height:200px;border:1px solid #b5b5b5;margin:6px">
                                                <label>Descrição: Histórico</label><br />
                                                <asp:Literal ID="ltDescricaoInicial_Historico" runat="server"></asp:Literal>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-5">
                                            <label>Carregar Arquivos</label>
                                            <asp:FileUpload ID="FileUpload1" runat="server" /><br />
                                            <asp:TextBox ID="txDescricaoImagem" type="text" runat="server" Width="100%" Height="90" class="form-control" placeholder="Exemplo: esta é a imagem do local / esta é a imagem do material" TextMode="MultiLine"></asp:TextBox> 
                                        </div>
                                        <div class="col-lg-2" style="margin-top: 5%;margin-bottom: 5%;text-align:center">
                                            <asp:Button ID="btAddArquivo" runat="server" Text="Adicionar Arquivo" class="btn btn-sm" />
                                        </div>
                                        <div class="col-lg-5">
                                            <div class="form-control" style="overflow-y:scroll;height:200px;border:1px solid #b5b5b5;margin:6px">
                                                <label>Lista de Arquivos Carregadas</label><br />
                                                <asp:Literal ID="ltListaArquivosCarregadas" runat="server"></asp:Literal>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>                
                </div>
            </asp:Panel>

            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btAddArquivo"  runat="server"/>
            </Triggers>

        </asp:UpdatePanel>


        <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
            <ContentTemplate>

                <asp:Panel ID="panelPesquisaLocal" runat="server" Visible="false">
                <div class="row">
                    <div class="col-lg-12">
                        <h3><asp:Literal ID="ltCategoriaOficial" runat="server"></asp:Literal> - Oficial</h3>
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                Local
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
                                        <div class="col-lg-11">
                                            <label>Endereços</label>
                                            <asp:DropDownList ID="ddBuscaEnderecos" runat="server" class="form-control">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-lg-1">
                                            <label> </label>
                                            <span class="input-group-btn">
                                                <asp:LinkButton ID="btLocalAdicionar" runat="server" class="btn btn-default"><i class="fa fa-check"></i></asp:LinkButton>
                                            </span>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group ">
                                    <div class="row">                            
                                        <div class="col-lg-12">
                                            <h5><asp:Label ID="lbEnderecoSelecionado" runat="server" Text="MG, Belo Horizonte, Prado, Rua Sarzedo, 31, apto 103 "></asp:Label></h5>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>                
                </div>
            </asp:Panel>

            </ContentTemplate>
        </asp:UpdatePanel>

        <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
            <ContentTemplate>

                <asp:Panel ID="panelPesquisaMateriais" runat="server" Visible="false">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                Materiais
                            </div>
                            <div class="panel-body">
                                <div class="form-group ">
                                    <div class="row">                            
                                        <div class="col-lg-10">
                                            <label>Pesquisar Material</label>
                                            <asp:TextBox ID="txPesquisaMeterial" type="text" runat="server" Width="100%" class="form-control" placeholder="Exemplo: Celular"></asp:TextBox> 
                                        </div>
                                        <div class="col-lg-1">
                                            <label> </label>
                                            <span class="input-group-btn">
                                                <asp:LinkButton ID="btPesquisaMaterial" runat="server" class="btn btn-default"><i class="fa fa-search"></i></asp:LinkButton>
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
                                        <div class="col-lg-11">
                                            <label>Lista de Materiais</label>
                                            <asp:DropDownList ID="ddMateriais" runat="server" class="form-control">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-lg-1">
                                            <label> </label>
                                            <span class="input-group-btn">
                                                <asp:LinkButton ID="LinkButton2" runat="server" class="btn btn-default"><i class="fa fa-check"></i></asp:LinkButton>
                                            </span>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group ">
                                    <div class="row">                            
                                        <div class="col-lg-12">
                                            <h5><asp:Label ID="Label1" runat="server" Text="MG, Belo Horizonte, Prado, Rua Sarzedo, 31, apto 103 "></asp:Label></h5>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>                
                </div>
            </asp:Panel>

            </ContentTemplate>
        </asp:UpdatePanel>

        <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
            <ContentTemplate>

                <asp:Panel ID="panelEnvolvidos" runat="server" Visible="false">
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    Relacionar envolvidos
                                </div>
                                <div class="panel-body">
                                    <div class="form-group ">
                                        <div class="row">                            
                                            <div class="col-lg-4">
                                                <label>Nome</label>
                                                <asp:TextBox ID="txNome" type="text" runat="server" Width="100%" class="form-control" placeholder="Exemplo: João Pedro"></asp:TextBox> 
                                            </div>
                                            <div class="col-lg-4">
                                                <label>Apelido</label>
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
                                            <div class="col-lg-3">
                                                <label>CNPJ</label>
                                                <asp:TextBox ID="txCNPJ" type="text" runat="server" Width="100%" class="form-control" placeholder="Exemplo: 10.123.123/0001-12"></asp:TextBox> 
                                            </div>
                                            <div class="col-lg-3">
                                                <label>Data de Nascimento</label>
                                                <asp:TextBox ID="txDataNascimento" type="text" runat="server" Width="100%" class="form-control" placeholder="Exemplo: 01/01/2001"></asp:TextBox> 
                                            </div>
                                            <div class="col-lg-1">
                                                <label> </label>
                                                <span class="input-group-btn">
                                                    <asp:LinkButton ID="btBuscarPessoa" runat="server" class="btn btn-default"><i class="fa fa-search"></i></asp:LinkButton>
                                                </span>
                                            </div>
                                            <div class="col-lg-1">
                                                <label> </label>
                                                <span class="input-group-btn">
                                                    <a href="pessoa.aspx" target="_blank" class="btn btn-default"><i class="fa fa-plus"></i></a>
                                                </span>
                                            </div>
                                        </div>
                                    </div>
                                    <hr />
                                    <div class="form-group ">
                                        <div class="row">                            
                                            <div class="col-lg-6">
                                                <label>Envolvidos</label>
                                                <asp:DropDownList ID="ddEnvolvido" runat="server" class="form-control">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-lg-5">
                                                <label>Tipo de Envolvimento</label>
                                                <asp:DropDownList ID="ddTipoEnvolvimento" runat="server" class="form-control">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-lg-1">
                                                <label> </label>
                                                <span class="input-group-btn">
                                                    <asp:LinkButton ID="btGravarEnvolvido" runat="server" class="btn btn-default"><i class="fa fa-check"></i></asp:LinkButton>
                                                </span>
                                            </div>
                                        </div>
                                    </div>

                                    
                                    <div class="form-group ">
                                        <div class="row"> 
                                            <div class="col-lg-12">  
                                                <label>Envolvidos cadastrados</label> 
                                                <asp:Literal ID="ltTabelaEnderecos" runat="server"></asp:Literal>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
            </asp:Panel>

            </ContentTemplate>
        </asp:UpdatePanel>

        <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
            <ContentTemplate>

            <asp:Panel ID="panelTelefonesRedesSociais" runat="server" Visible="false">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                Descrição do Evento
                            </div>
                            <div class="panel-body">
                                <div class="form-group ">
                                    <div class="row">                            
                                        <div class="col-lg-12">
                                            <label>&nbsp</label>
                                            <asp:TextBox ID="txDescricaoEvento" type="text" runat="server" Width="100%" class="form-control" placeholder="Exemplo: descrição dos fatos" Height="200px" TextMode="MultiLine"></asp:TextBox> 
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group ">
                                    <div class="row">         
                                        <div class="col-lg-11"></div>                   
                                        <div class="col-lg-1">
                                            <label> </label>
                                            <span class="input-group-btn">
                                                <asp:LinkButton ID="btDescricaoAdicionar" runat="server" class="btn btn-default">Gravar</asp:LinkButton>
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
                            <asp:Button ID="btFechar" runat="server" Text="Fechar" class="btn btn-default" />
                        </div>
                    </div>
                </div>
            </asp:Panel>

            </ContentTemplate>
        </asp:UpdatePanel>
        
            </div>
        </div>
</asp:Content>

