<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page1.aspx.cs" Inherits="WebForm_Asp_App.RedirectPage.Page1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background:#0094ff">
    <form id="form1" runat="server">
        <div>

            <input type="text" placeholder="نام"  name="txtName" id="txtName" runat="server" />
            <input type="text" placeholder="فامیلی"  name="txtFamily" id="txtFamily" runat="server" />

             
        </div>
        <asp:Button ID="sendParameter" runat="server" Text="Button" OnClick="sendParameter_Click" />
    </form>
</body>
</html>
