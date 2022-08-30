<%@ Page Title="" Language="VB" MasterPageFile="~/principal.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div id="container" class="container">
                <div class="col-lg-12 col-lg-offset-0">
                    
                    
                    <center>
                        <br />
                        <h1>Frase de impacto</h1>
                        <img src="img/logo.PNG" style="width: 40%;" />
                        <br /><br />
                        <asp:Button ID="Button1" runat="server" Text="Área de acesso restrito" />
                    </center>
                    <!-- /.col-lg-12 -->

                    
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
