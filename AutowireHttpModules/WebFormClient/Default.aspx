<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormClient._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>IHttpModules with IoC</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <p>
            Data from custom module:</p>
            <asp:Repeater runat="server" ID="moduleMessage">
                <HeaderTemplate>
                    <ol>
                </HeaderTemplate>
                <ItemTemplate>
                    <li>
                        <%# DataBinder.Eval(Container.DataItem, "Value")%></li>
                </ItemTemplate>
                <FooterTemplate>
                    </ol>
                </FooterTemplate>
            </asp:Repeater>
        <p>
            <asp:Label runat="server" ID="moduleCount" />
            IHttpModule(s) have been registered!</p>
        <asp:Repeater runat="server" ID="moduleList">
            <HeaderTemplate>
                <ol>
            </HeaderTemplate>
            <ItemTemplate>
                <li>
                    <%# DataBinder.Eval(Container.DataItem, "Name")%></li>
            </ItemTemplate>
            <FooterTemplate>
                </ol>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    </form>
</body>
</html>
