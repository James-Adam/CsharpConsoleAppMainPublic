<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="AuthenticatedSchoolSystem.Back_End.Products.ProductDetails" %>

<!DOCTYPE html>
<!-- //Defining a route to handle a url pattern-->
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<form id="form1" runat="server">
    <div>
        <asp:HyperLink runat="server" Text="Home" NavigateUrl="~/Home/Index"/>
        <asp:Label runat="server" ID="lblOutput"/>
    </div>
</form>
</body>
</html>