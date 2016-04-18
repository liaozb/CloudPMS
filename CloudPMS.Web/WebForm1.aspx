<%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="CloudPMS.Web.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="Scripts/jquery-1.12.3.min.js"></script>
 
    <script type="text/javascript">

        $(function () {
            $("#Button11").click(function () {
                $.ajax({
                    url: "/api/Users/Create",
                    type: "post",
                    dataType: "json",
                    contentType: 'application/json; charset=utf-8',
                    data: JSON.stringify({ userName: $("#Text1").val() }),

                    success: function (data) {
                        alert(data.success);
                        alert(data.errorMsg);
                    }
                }).fail(
  function (xhr, textStatus, err) {
      alert('Error: ' + err);
  });
            })

        })


    </script>


</head>
<body>
    <form id="form1" runat="server">
        <div>
            <input id="Button11" type="button" value="button" />
            <input id="Text1" type="text" />
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
