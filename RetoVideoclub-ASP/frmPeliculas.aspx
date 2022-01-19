<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmPeliculas.aspx.vb" Inherits="RetoVideoclub_ASP.frmPeliculas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
                <div>
            <asp:Label ID="lblTitulo" runat="server" Font-Size="XX-Large" Text="Titulo:"></asp:Label>
            &nbsp;<asp:TextBox ID="txtTitulo" runat="server" Width="134px" AutoCompleteType="Disabled" AutoPostBack="true"></asp:TextBox>
            
            <br />
            <asp:Label ID="lblAnyo" runat="server" Font-Size="XX-Large" Text="Año:"></asp:Label>
            &nbsp;<asp:TextBox ID="txtAnyo" runat="server" Width="72px" AutoPostBack="true"></asp:TextBox>
            
            <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                    ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
                    SelectCommand="SELECT [Titulo], [Anyo] ,Director, Generos.Nombre
                    FROM [Peliculas] 
                    INNER JOIN [Generos]
                    ON Peliculas.CodGenero  = Generos.GeneroId
                    WHERE ([Titulo] LIKE  ? + '%')
                    AND ([Anyo] LIKE ? + '%')">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="txtTitulo" DefaultValue="%" Name="Titulo" PropertyName="Text"
                        Type="String" />
                        <asp:ControlParameter ControlID="txtAnyo" DefaultValue="%" Name="Anyo" PropertyName="Text"
                        Type="String" />
                    </SelectParameters>
              </asp:SqlDataSource>

            <br />
            <br />
              <asp:GridView ID="GridView1" runat="server" AllowPaging="True"
                    AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource1">
                <Columns>
                   
                    <asp:BoundField DataField="Titulo" HeaderText="Titulo" SortExpression="Titulo" />
                    <asp:BoundField DataField="Anyo" HeaderText="Anyo" SortExpression="Anyo" />
                    <asp:BoundField DataField="Director" HeaderText="Director" SortExpression="Director" />
                    <asp:BoundField DataField="Nombre" HeaderText="Género" SortExpression="Nombre" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
