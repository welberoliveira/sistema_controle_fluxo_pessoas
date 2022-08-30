<%@ Page Language="VB" AutoEventWireup="false" CodeFile="dropbox.aspx.vb" Inherits="dropbox_" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" Text="enviar" />
            <asp:FileUpload ID="FileUpload1" runat="server" />

        </div>
    </form>
</body>
</html>
