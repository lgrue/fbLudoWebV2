<%@ Page Title="Konto verwalten" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="fbLudoWebFinal.Account.Manage" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>

    <div>
        <asp:PlaceHolder runat="server" ID="successMessage" Visible="false" ViewStateMode="Disabled">
            <p class="text-success"><%: SuccessMessage %></p>
        </asp:PlaceHolder>
    </div>

    <div class="row">
        <div class="col-md-12">
            <div class="form-horizontal">
                <h4>Kontoeinstellungen ändern</h4>
                <hr />
                <dl class="dl-horizontal">
                    <dt>Kennwort:</dt>
                    <dd>
                        <asp:HyperLink NavigateUrl="/Account/ManagePassword" Text="[Change]" Visible="false" ID="ChangePassword" runat="server" />
                        <asp:HyperLink NavigateUrl="/Account/ManagePassword" Text="[Create]" Visible="false" ID="CreatePassword" runat="server" />
                    </dd>
                    <dt>Externe Anmeldungen:</dt>
                    <dd><%: LoginsCount %>
                        <asp:HyperLink NavigateUrl="/Account/ManageLogins" Text="[Manage]" runat="server" />

                    </dd>
                    <%--
                        Telefonnummern können als zweite Stufe in einem zweistufigen Authentifizierungssystem verwendet werden.
                        In <a href="https://go.microsoft.com/fwlink/?LinkId=403804">diesem Artikel</a>
                        finden Sie Details zum Einrichten dieser ASP.NET-Anwendung für die Unterstützung zweistufiger Authentifizierung mithilfe von SMS.
                        Entfernen Sie den Kommentar für den folgenden Block, nachdem Sie die zweistufige Authentifizierung eingerichtet haben.
                    --%>
                    <%--
                    <dt>Telefonnummer:</dt>
                    <% if (HasPhoneNumber)
                       { %>
                    <dd>
                        <asp:HyperLink NavigateUrl="/Account/AddPhoneNumber" runat="server" Text="[Add]" />
                    </dd>
                    <% }
                       else
                       { %>
                    <dd>
                        <asp:Label Text="" ID="PhoneNumber" runat="server" />
                        <asp:HyperLink NavigateUrl="/Account/AddPhoneNumber" runat="server" Text="[Change]" /> &nbsp;|&nbsp;
                        <asp:LinkButton Text="[Remove]" OnClick="RemovePhone_Click" runat="server" />
                    </dd>
                    <% } %>
                    --%>

                    <dt>Zweistufige Authentifizierung:</dt>
                    <dd>
                        <p>
                            Es sind keine Anbieter für zweistufige Authentifizierung konfiguriert. In <a href="https://go.microsoft.com/fwlink/?LinkId=403804">diesem Artikel</a>
                            finden Sie Details zum Einrichten dieser ASP.NET-Anwendung für die Unterstützung zweistufiger Authentifizierung.
                        </p>
                        <% if (TwoFactorEnabled)
                          { %> 
                        <%--
                        Aktiviert
                        <asp:LinkButton Text="[Disable]" runat="server" CommandArgument="false" OnClick="TwoFactorDisable_Click" />
                        --%>
                        <% }
                          else
                          { %> 
                        <%--
                        Deaktiviert
                        <asp:LinkButton Text="[Enable]" CommandArgument="true" OnClick="TwoFactorEnable_Click" runat="server" />
                        --%>
                        <% } %>
                    </dd>


                    <h4>Persönliche Angaben:</h4>
                    <hr />
                    <dt>Anrede:</dt>
                    <% if (HasAnrede)
                       { %>
                    <dd>
                        <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Email" CssClass="text-danger" ErrorMessage="Das E-Mail-Feld ist erforderlich." />
                    </dd>
                    <% }
                       else
                       { %>
                    <dd>
                        <asp:TextBox runat="server" ID="TextBox1" CssClass="form-control" TextMode="Email" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Email" CssClass="text-danger" ErrorMessage="Das E-Mail-Feld ist erforderlich." />
                    </dd>
                    <% } %>




                </dl>
            </div>
        </div>
    </div>

</asp:Content>
