<%@ Page Title="Preise Anpassen" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PreiseAnpassen.aspx.cs" Inherits="fbLudoWebFinal.PreiseAnpassen" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>

    <p>Hier können Sie die Preise der vorhandenen Spiele verändern.</p>
    <p>Wählen Sie das zu Ändernde Spiel aus:</p>
    <asp:RadioButtonList id="RadioButtonList" runat="server"></asp:RadioButtonList>
    <asp:Button runat="server" ID="btnChoose" Text="Auswählen" OnClick="Choose" />

    <p>Wählen Sie jetzt die neuen Preise:</p>
    <input type="number" step="0.01" id="newVereinstarif" runat="server" />
    <input type="number" step="0.01" id="newNormaltarif" runat="server" />
    <asp:Button runat="server" ID="btnChange" Text="Ändern" OnClick="Change" />
</asp:Content>
