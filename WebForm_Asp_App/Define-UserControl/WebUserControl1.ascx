<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebUserControl1.ascx.cs" Inherits="WebForm_Asp_App.Define_UserControl.WebUserControl1" %>
<div>
    <input type="text" runat="server" id="txtname" />
    <asp:Button ID="btnsave" runat="server" Text="ثبت" OnClick="btnsave_Click" />
 </div>


<%--در قسمت اضافه کردن آیتم جدید میتوان یک یوزر کنترل انتخاب کرد و با دادن یک نام به آن را ایجاد کرد و دقیقا کار پارشیال ویو ها را انجام میدهد 
و میتوانیم داخل صفحات دیگر از آن استفاده کنیم--%>