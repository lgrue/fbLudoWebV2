<%@ Page Title="Ausleihen Übersicht" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AusleihenÜbersicht.aspx.cs" Inherits="fbLudoWebFinal.AusleihenÜbersicht" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Aktive Ausleihen</h3>
    <asp:ListView runat="server" ID="EmployeesListView" ItemType="Model.Ausleihe">
      <LayoutTemplate>
        <table cellpadding="2" runat="server" id="tblEmployees" class="table table-striped table-dark">
          <tr runat="server" id="itemPlaceholder">
          </tr>
        </table>

      </LayoutTemplate>
      <ItemTemplate>
         <tr runat="server">
             <td><%#: Item.Ausleihe_ID %></td>
             <td><%#: Item.Name %></td>
             <td><%#: Item.AnzVerlaengerungen %>/3</td>
             <td><%#: Item.DatumVon %></td>
             <td><%#: Item.DatumBis %></td>
             <td><asp:LinkButton CommandArgument="<%#: Item.Ausleihe_ID %>" runat="server" OnClick="longer" CommandName="longer" Enabled="<%# !(Item.AnzVerlaengerungen == 3) %>" Text="Verlängern"></asp:LinkButton></td>
             <td><asp:LinkButton CommandArgument="<%#: Item.Ausleihe_ID %>" runat="server" OnClick="back" CommandName="back" Text="Zurückgeben"></asp:LinkButton></td>
         </tr>
       </ItemTemplate>
    </asp:ListView>

    <h3>Inaktive Ausleihen</h3>
    <asp:ListView runat="server" ID="ListView2" ItemType="Model.Ausleihe">
      <LayoutTemplate>
        <table cellpadding="2" runat="server" id="tblEmployees2" class="table table-striped table-dark">
          <tr runat="server" id="itemPlaceholder">
          </tr>
        </table>

      </LayoutTemplate>
      <ItemTemplate>
         <tr runat="server">
             <td><%#: Item.Ausleihe_ID %></td>
             <td><%#: Item.Name %></td>
             <td><%#: Item.AnzVerlaengerungen %>/3</td>
             <td><%#: Item.DatumVon %></td>
             <td><%#: Item.DatumBis %></td>
         </tr>
       </ItemTemplate>
    </asp:ListView>
</asp:Content>


    <%-- 
    <h2><%: Title %>.</h2> 
    <h3>Ausgeliehene Spiele</h3> 
    <asp:Table class="table table-striped table-dark" ID="tblAusleihenAktiv" runat="server" width="100%"></asp:Table> 
    <h3>Zurückgegebene Spiele</h3> 
    <asp:Table class="table table-striped table-dark" ID="tblAusleihenIaktiv" runat="server" width="100%"></asp:Table>
    --%>
