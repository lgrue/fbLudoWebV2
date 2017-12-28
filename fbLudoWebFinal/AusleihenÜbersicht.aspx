<%@ Page Title="Ausleihen Übersicht" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AusleihenÜbersicht.aspx.cs" Inherits="fbLudoWebFinal.AusleihenÜbersicht" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
</asp:Content>
