<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="InjectableWebForms.DefaultPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Injectable Web Forms Demo</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>
            Injectable Web Forms</h1>
        <fieldset>
            <h3>
                Person List</h3>
            <asp:GridView runat="server" ID="personGrid" />
        </fieldset>
        <fieldset>
            <h3>
                Create Person</h3>
            <p>
                Provide the following information to create a new person:</p>
            First Name:<asp:TextBox runat="server" ID="personFirstName" /><br />
            Last Name:<asp:TextBox runat="server" ID="personLastName" />
            <br />
            <asp:Button runat="server" ID="personCreate" Text="Create" OnClick="personCreate_Click" />
        </fieldset>
    </div>
    </form>
</body>
</html>
