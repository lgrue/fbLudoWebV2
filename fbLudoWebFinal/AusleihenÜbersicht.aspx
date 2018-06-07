<%@ Page Title="Ausleihen Übersicht" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AusleihenÜbersicht.aspx.cs" Inherits="fbLudoWebFinal.AusleihenÜbersicht" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Ausgeliehene Spiele</h3>
    <asp:ListView runat="server" ID="EmployeesListView" ItemType="Model.Ausleihe" >
      <LayoutTemplate>
        <table cellpadding="2" runat="server" id="tblEmployees" 
            style="width:460px">
          <tr runat="server" id="itemPlaceholder">
          </tr>
        </table>

      </LayoutTemplate>
      <ItemTemplate>
         <tr runat="server">
             <td><%#: Item.Name %><</td>
         </tr>
       </ItemTemplate>
    </asp:ListView>
</asp:Content>
