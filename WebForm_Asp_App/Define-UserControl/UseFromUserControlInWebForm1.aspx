<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UseFromUserControlInWebForm1.aspx.cs" Inherits="WebForm_Asp_App.Define_UserControl.UseFromUserControlInWebForm1" %>

<%--//این قسمت کد پایین بصورت داینامیک هنگام درک کردن یوزر کنترل به این صفحه ایجاد میشود--%>

<%@ Register Src="~/Define-UserControl/WebUserControl1.ascx" TagPrefix="uc1" TagName="WebUserControl1" %>  

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

<%--            //نحوه استفاده از یوزر کنترل در صفحه های وب دیگر 
            //دقیقا مثل پارشیال ویو ها هستند 
            //با درگ کردن آن داخل این صفحه میتوانیم استفاده کنیم--%>
            <uc1:WebUserControl1 runat="server" id="WebUserControl1" />


        </div>
    </form>
</body>
</html>
