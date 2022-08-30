<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dropbox2.aspx.cs" Inherits="dropbox2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:FileUpload ID="FileUpload1" runat="server" /><br />
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" /><br />
            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
            <br /><br /><br /><br />
            <asp:FileUpload ID="FileUpload2" runat="server" /><br />
            <asp:Button ID="Button2" runat="server" Text="mandar para servidor" OnClick="Button2_Click" />
            <br />
            <asp:Button ID="Button3" runat="server" Text="mandar para dropbox" OnClick="Button3_Click" />
        </div>
    </form>
</body>
</html>
