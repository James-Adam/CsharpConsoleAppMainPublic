<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_2.WebFormsApplication._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <p>
        <br/>
        Demo
    </p>
    <p>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </p>
    <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
    <p>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button"/>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
        &nbsp;
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>


</asp:Content>