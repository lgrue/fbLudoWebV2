﻿<%@ Page Title="Neue Ausleihe" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NeueAusleihe.aspx.cs" Inherits="fbLudoWebFinal.NeueAusleihe" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <p>Wählen Sie das Spiel aus, welches Sie ausleihen möchten.</p>
    <asp:DropDownList id="DropDownList1" runat="server"></asp:DropDownList>
    <asp:Button runat="server" ID="btnAusleihe" Text="Ausleihe" OnClick="ausleihen" />
</asp:Content>
