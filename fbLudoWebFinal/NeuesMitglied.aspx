<%@ Page Title="Neues Mitglied" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NeuesMitglied.aspx.cs" Inherits="fbLudoWebFinal.NeuesMitglied" %>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
 <h2>Neuer Mitglidschafts Code generieren.</h2>
    <div class="row">
        <div class="col-md-8">
            <section id="mitgliedschaftForm">
                <div class="form-horizontal">
                    <h4>Generieren</h4>
                    <hr />
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
                    <asp:PlaceHolder runat="server" ID="SuccessMessage" Visible="false">
                        <p class="text-success">
                            <asp:Literal runat="server" ID="SuccessText" />
                        </p>
                    </asp:PlaceHolder>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" ID="CodeButton" OnClick="GenerateCode" Text="Code generieren" CssClass="btn btn-default" />
                        </div>
                    </div>
                </div>
            </section>
        </div>
    </div>
</asp:Content>
 