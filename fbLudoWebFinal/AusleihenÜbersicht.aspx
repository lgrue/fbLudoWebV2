<%@ Page Title="Ausleihen Übersicht" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AusleihenÜbersicht.aspx.cs" Inherits="fbLudoWebFinal.AusleihenÜbersicht" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Aktive Ausleihen</h3>
    <asp:ListView runat="server" ID="EmployeesListView" ItemType="Model.Ausleihe_Spiel">
      <LayoutTemplate>
        <table cellpadding="2" runat="server" id="tblEmployees" class="table table-striped table-dark">
          <tr runat="server" id="itemPlaceholder">
          </tr>
        </table>
      </LayoutTemplate>    
        <ItemTemplate>
            <tr runat="server" visible='<%# (int)DataBinder.Eval(Container, "DataItemIndex") == 0 %>'>
               <th>ID</th>
               <th>Name</th>
               <th>Verlängerung</th>
               <th>Ausleihedatum</th>
               <th>Rückgabedatum</th>
               <th>Verlängern</th>
               <th>Zurückgeben</th>
            </tr>
         <tr runat="server">
             <td><%#: Item.Ausleihe_ID %></td>
             <td><%#: Item.Name %></td>
             <td><%#: Item.AnzVerlaengerungen %>/3</td>
             <td><%#: Item.DatumVon.Day + "." + Item.DatumVon.Month + "." + Item.DatumVon.Year  %></td>
             <td><%#: Item.DatumBis.Day + "." + Item.DatumBis.Month + "." + Item.DatumBis.Year %></td>
             <td><asp:LinkButton CommandArgument="<%#: Item.Ausleihe_ID %>" runat="server" OnClick="longer" CommandName="longer" Visible="<%# !(Item.AnzVerlaengerungen == 3) %>" Text="Verlängern"></asp:LinkButton></td>
             <td><asp:LinkButton CommandArgument="<%#: Item.Ausleihe_ID %>" runat="server" OnClick="back" CommandName="back" Text="Zurückgeben"></asp:LinkButton></td>
         </tr>
       </ItemTemplate>
    </asp:ListView>

    <h3>Inaktive Ausleihen</h3>
    <asp:ListView runat="server" ID="ListView2" ItemType="Model.Ausleihe_Spiel">
      <LayoutTemplate>
        <table cellpadding="2" runat="server" id="tblEmployees2" class="table table-striped table-dark">
          <tr runat="server" id="itemPlaceholder">
          </tr>
        </table>

      </LayoutTemplate>
      <ItemTemplate>
          <tr runat="server" visible='<%# (int)DataBinder.Eval(Container, "DataItemIndex") == 0 %>'>
             <th>ID</th>
             <th>Name</th>
             <th>Verlängerung</th>
             <th>Ausleihedatum</th>
             <th>Rückgabedatum</th>
          </tr>
         <tr runat="server">
             <td><%#: Item.Ausleihe_ID %></td>
             <td><%#: Item.Name %></td>
             <td><%#: Item.AnzVerlaengerungen %>/3</td>
             <td><%#: Item.DatumVon.Day + "." + Item.DatumVon.Month + "." + Item.DatumVon.Year %></td>
             <td><%#: Item.DatumBis.Day + "." + Item.DatumBis.Month + "." + Item.DatumBis.Year %></td>
         </tr>
       </ItemTemplate>
    </asp:ListView>
</asp:Content>