﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Menu.ascx.cs" Inherits="_2.WebFormsApplication.Control.Menu" %>

<div class="navbar navbar-inverse navbar-fixed-top">
    <div class="container">
        <div class="navbar-header">
            <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse" title="more options">
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
            </button>
            <a class="navbar-brand" runat="server" href="~/">Application name</a>
        </div>
        <div class="navbar-collapse collapse">
            <ul class="nav navbar-nav">
                <li>
                    <a runat="server" href="~/">Home</a>
                </li>
                <li>
                    <a runat="server" href="~/PersonDetails">Person</a>
                </li>
                <li>
                    <a runat="server" href="~/About">About</a>
                </li>
                <li>
                    <a runat="server" href="~/Contact">Contact</a>
                </li>
            </ul>
        </div>
    </div>
</div>