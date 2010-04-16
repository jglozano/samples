<%@ Import Namespace="JSONModelBinderSample.Models" %>

<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<PersonInputModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
   POSTing JSON
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

                // User Crockford's JSON serializer for this piece
                // for more info goto: http://www.json.org/js.html
                var personText = JSON.stringify(person);

                $.ajax({
                    type: 'POST',
                    url: "home/save",
                    // pass the data as a json string
                    data: personText,

                    // tell the server that is indeed JSON that we're sending
                    contentType: "application/json",

                    // handle the request back from the server
                    success: function (data) {
                        // get the result and do some magic with it
                        var message = data.Message;
                        $("#resultMessage").html(message);
                    },

                    // this is to tell the handler for the 'success' piece
                    // that the content of the result is json and that 
                    // serialization should take place
                    dataType: 'json'
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
