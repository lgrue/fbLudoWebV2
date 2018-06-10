<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="MitglidschaftRollen.aspx.cs" Inherits="fbLudoWebFinal.MitglidschaftRollen" Async="true" %> 
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent"> 
    <h2>Mitgliedschaft & Rollen.</h2> 
 
    <div class="row"> 
        <div class="col-md-8"> 
            <section id="mitgliedschaftForm"> 
                <div class="form-horizontal"> 
                    <% if (!HttpContext.Current.User.IsInRole("Mitglied")) { %> 
                    <h4>Mitglidschafts-Code einlösen</h4> 
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
                        <asp:Label runat="server" AssociatedControlID="Code" CssClass="col-md-2 control-label">Code</asp:Label> 
                        <div class="col-md-10"> 
                            <asp:TextBox runat="server" ID="Code" TextMode="Password" CssClass="form-control" /> 
                        </div> 
                    </div> 
                    <div class="form-group"> 
                        <div class="col-md-offset-2 col-md-10"> 
                            <asp:Button runat="server" ID="CodeButton" OnClick="ReedemCode" Text="Code Einlösen" CssClass="btn btn-default" /> 
                        </div> 
                    </div> 
                    <% } %> 
                </div> 
            </section> 
        </div> 
    </div> 
    <div class="row"> 
        <div class="col-md-8"> 
            <section id="mitarbeiterForm"> 
                <div class="form-horizontal"> 
                    <% if (!HttpContext.Current.User.IsInRole("Mitarbeiter")) { %> 
                    <h4>Account upgrade: Mitarbeiter</h4> 
                    <hr /> 
                    <asp:PlaceHolder runat="server" ID="ErrorMessage1" Visible="false"> 
                        <p class="text-danger"> 
                            <asp:Literal runat="server" ID="FailureText1" /> 
                        </p> 
                    </asp:PlaceHolder> 
                    <asp:PlaceHolder runat="server" ID="SuccessMessage1" Visible="false"> 
                        <p class="text-success"> 
                            <asp:Literal runat="server" ID="SuccessText1" /> 
                        </p> 
                    </asp:PlaceHolder> 
                    <div class="form-group"> 
                        <asp:Label runat="server" AssociatedControlID="Password1" CssClass="col-md-2 control-label">Kennwort</asp:Label> 
                        <div class="col-md-10"> 
                            <asp:TextBox runat="server" ID="Password1" TextMode="Password" CssClass="form-control" /> 
                        </div> 
                    </div> 
                    <div class="form-group"> 
                        <div class="col-md-offset-2 col-md-10"> 
                            <asp:Button runat="server" ID="MitarbeiterPwButton" OnClick="MitarbeiterPw" Text="Upgrade" CssClass="btn btn-default" /> 
                        </div> 
                    </div> 
                    <% } %> 
                </div> 
            </section> 
        </div> 
    </div> 
    <div class="row"> 
        <div class="col-md-8"> 
            <section id="adminForm"> 
                <div class="form-horizontal"> 
                    <h4>Account upgrade: Admin</h4> 
                    <hr /> 
                    <asp:PlaceHolder runat="server" ID="ErrorMessage2" Visible="false"> 
                        <p class="text-danger"> 
                            <asp:Literal runat="server" ID="FailureText2" /> 
                        </p> 
                    </asp:PlaceHolder> 
                    <div class="form-group"> 
                        <asp:Label runat="server" AssociatedControlID="Password2" CssClass="col-md-2 control-label">Kennwort</asp:Label> 
                        <div class="col-md-10"> 
                            <asp:TextBox runat="server" ID="Password2" TextMode="Password" CssClass="form-control" /> 
                        </div> 
                    </div> 
                    <div class="form-group"> 
                        <div class="col-md-offset-2 col-md-10"> 
                            <asp:Button runat="server" ID="AdminPwButton" OnClick="AdminPw" Text="Upgrade" CssClass="btn btn-default" /> 
                        </div> 
                    </div> 
                </div> 
            </section> 
        </div> 
    </div> 
</asp:Content> 