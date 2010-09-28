<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IList<InferredPoco.Models.Person>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <a href="person/createnew">Create New Person</a> <a href="person/getlist" target="_blank">JSON List</a>
    <%
        personGrid.DataSource = Model;
        personGrid.DataBind();
    %>
    <p></p>
    <form runat="server">
    <asp:GridView ID="personGrid" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:HyperLinkField DataNavigateUrlFields="Id" 
                DataNavigateUrlFormatString="~/person/delete/{0}" Text="Delete" />
        </Columns>
    </asp:GridView>
    </form>
</asp:Content>
