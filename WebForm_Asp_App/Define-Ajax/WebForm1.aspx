<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebForm_Asp_App.Define_Ajax.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <%-- ScriptManager:برای اینکه صفحه حالت ایجکس بگیرد باید این ابزار را از تولباکس انتخاب کنیم و داخل صفحه قرار دهیم
            UpdatePanel:المنت های که مد نظر داریم بصورت ایجکسی کار کنند باید داخل این المنت یا همان ابزار که از قسمت تولباکس به این صفحه اضافه میشود  قرار بگیرند 
            --%>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>

                    <input type="text" id="txtname1" runat="server" />
                    <asp:Button runat="server" ID="btnsave1" Text="ثبت" OnClick="btnsave_Click" />


                </ContentTemplate>
            </asp:UpdatePanel>



        </div>
    </form>
</body>
</html>
