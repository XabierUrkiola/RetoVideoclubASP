<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmChangePassword.aspx.vb" Inherits="RetoVideoclub_ASP.frmChangePassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ChangePassword ID="miChangePassword" runat="server">
            </asp:ChangePassword>
        </div>
        <asp:Button ID="Button1" runat="server" Text="Button" />
    </form>
</body>
</html>
