<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MitgliedschaftRollen.aspx.cs" Inherits="fbLudoWebFinal.MitgliedschaftRollen" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>

    <div class="row">
        <div class="col-md-8">
            <section id="roleForm">
                <div class="form-horizontal">
                    <h4>Mitgliedschafts-Code</h4>
                    <hr />
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Kennwort</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="Das Kennwortfeld ist erforderlich." />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" OnClick="RedeemCode" Text="Einlösen" CssClass="btn btn-default" />
                        </div>
                    </div>
                </div>
            </section>
        </div>

    </div>
</asp:Content>
