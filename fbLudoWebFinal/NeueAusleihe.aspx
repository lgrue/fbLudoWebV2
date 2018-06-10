<%@ Page Title="Neue Ausleihe" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NeueAusleihe.aspx.cs" Inherits="fbLudoWebFinal.NeueAusleihe" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>

    <div>
        <asp:PlaceHolder runat="server" ID="successMessage" Visible="false" ViewStateMode="Disabled">
            <p class="text-success"><%: SuccessMessage %></p>
        </asp:PlaceHolder>
    </div>

    <p>Wählen Sie die Spiele aus, die Sie ausleihen möchten.</p>
    <p>Es können bis zu <b>3 Spiele</b> ausgelehnt werden.</p>
    <!-- <asp:DropDownList id="DropDownList1" runat="server"></asp:DropDownList> -->
    <asp:CheckBoxList id="CheckListSpiele" runat="server"></asp:CheckBoxList>
    <p id="errormsg" contenteditable="true" runat="server" style="color: red"></p>
    <asp:Button runat="server" ID="btnAusleihe" Text="Ausleihe" OnClick="ausleihen" />
</asp:Content>
