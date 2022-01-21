<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmChangePassword.aspx.vb" Inherits="RetoVideoclub_ASP.frmChangePassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div align="center">
            Cambiar la contraseña<br /><br />
            <asp:Label ID="LbTextContra" runat="server" Text="Contraseña:"></asp:Label>&nbsp;
            <asp:TextBox ID="TB_Contra" runat="server"></asp:TextBox><br />
            <asp:Label ID="LbTextNuevaContra" runat="server" Text="Nueva Contraseña:"></asp:Label>&nbsp;&nbsp;
            <asp:TextBox ID="TB_NuevaContra" runat="server"></asp:TextBox><br />
            <asp:Label ID="LbConfirmarContra" runat="server" Text="Confirmar la nueva contraseña:"></asp:Label>&nbsp;
            <asp:TextBox ID="TB_ConfirmarContra" runat="server"></asp:TextBox><br />
            Confirmar la nueva contraseña debe coincidir con la entrada Nueva contraseña<br /><br />
            <asp:Button ID="btnCambiarContra" runat="server" Text="Cambiar contraseña" />&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnCancelar" runat="server" Text="Cancelar" />
        </div>


        <asp:Button ID="Button1" runat="server" Text="Button" />
    </form>
</body>
</html>
