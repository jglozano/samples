<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CustomSessions._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title></title>
</head>
<body>
  <form id="form1" runat="server">
  <h2>
    Contextual Session Sample</h2>
  <div>
    <asp:GridView runat="server" ID="personGrid" BackColor="White" BorderColor="#999999"
      BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
      <FooterStyle BackColor="#CCCCCC" />
      <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
      <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
      <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
      <AlternatingRowStyle BackColor="#CCCCCC" />
    </asp:GridView>
  </div>
  </form>
</body>
</html>
