<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<JSONMvcSample.Models.PersonInputModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(function () {
            $("#personCreate").click(function () {
                var person = getPerson();

                // poor man's validation
                if (person == null) {
                    alert("Specify a name please!");
                    return;
                }

                // take the data and post it via json
                $.post("home/save", person, function (data) {
                    // get the result and do some magic with it
                    var message = data.Message;
                    $("#resultMessage").html(message);
                });
            });
        });

        function getPerson() {
            var name = $("#Name").val();
            var age = $("#Age").val();

            // poor man's validation
            return (name == "") ? null : { Name: name, Age: age };
        }   
    </script>
    <!-- Have the system create an input form for us -->
    <%=Html.EditorForModel() %>
    <p>
        <input type="submit" value="Save" id="personCreate" />
    </p>
    <div>
        <span id="resultMessage"></span>
    </div>
</asp:Content>
