<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Person.Master" CodeBehind="PersonDetails.aspx.cs" Inherits="_2.WebFormsApplication.PersonDetails" %>

<asp:Content ContentPlaceHolderID="MainContent" ID="BodyContent" runat="server">
    <div>
        <h2>Person Details</h2>
        <asp:DropDownList ID="ddSalutation" runat="server"/><br/>
        <asp:TextBox ID="txtFirstName" runat="server"/> <br/>
        <asp:TextBox ID="txtLastName" runat="server"/> <br/><br/>
        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save"/><br/><br/>
        <asp:Label ID="lblMessage" runat="server"/>
    </div>
</asp:Content>