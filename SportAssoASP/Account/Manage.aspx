<%@ Page Title="Gérer le compte" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SportAssoASP.Account.Manage" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %>.</h2>

        <div>
            <asp:PlaceHolder runat="server" ID="successMessage" Visible="false" ViewStateMode="Disabled">
                <p class="text-success"><%: SuccessMessage %></p>
            </asp:PlaceHolder>
        </div>

        <div class="col-md-12">
            <div class="row">
                <h4>Modifier vos paramètres de compte</h4>
                <hr />
                <dl class="dl-horizontal">
                    <dt>Mot de passe :</dt>
                    <dd>
                        <asp:HyperLink NavigateUrl="/Account/ManagePassword" Text="[Changer]" Visible="false" ID="ChangePassword" runat="server" />
                        <asp:HyperLink NavigateUrl="/Account/ManagePassword" Text="[Créer]" Visible="false" ID="CreatePassword" runat="server" />
                    </dd>
                    <dt>Connexions externes :</dt>
                    <dd><%: LoginsCount %>
                        <asp:HyperLink NavigateUrl="/Account/ManageLogins" Text="[Gérer]" runat="server" />

                    </dd>
                    <%--
                        Phone Numbers can used as a second factor of verification in a two-factor authentication system.
                        See <a href="https://go.microsoft.com/fwlink/?LinkId=403804">this article</a>
                        for details on setting up this ASP.NET application to support two-factor authentication using SMS.
                        Uncomment the following blocks after you have set up two-factor authentication
                    --%>
                    <%--
                    <dt>Phone Number:</dt>
                    <% if (HasPhoneNumber)
                        { %>
                    <dd>
                        <asp:HyperLink NavigateUrl="/Account/AddPhoneNumber" runat="server" Text="[Ajouter]" />
                    </dd>
                    <% }
                        else
                        { %>
                    <dd>
                        <asp:Label Text="" ID="PhoneNumber" runat="server" />
                        <asp:HyperLink NavigateUrl="/Account/AddPhoneNumber" runat="server" Text="[Changer]" /> &nbsp;|&nbsp;
                        <asp:LinkButton Text="[Supprimer]" OnClick="RemovePhone_Click" runat="server" />
                    </dd>
                    <% } %>
                    --%>

                    <dt>Authentification à 2 facteurs :</dt>
                    <dd>
                        <p>
                            Aucun fournisseur d'authentification à 2 facteurs n'est configuré. Consultez <a href="https://go.microsoft.com/fwlink/?LinkId=403804">cet article</a>
                            pour plus de détails sur la configuration de cette application ASP.NET afin qu'elle prenne en charge l'authentification à 2 facteurs.
                        </p>
                        <% if (TwoFactorEnabled)
                            { %> 
                        <%--
                        Enabled
                        <asp:LinkButton Text="[Disable]" runat="server" CommandArgument="false" OnClick="TwoFactorDisable_Click" />
                        --%>
                        <% }
                            else
                            { %> 
                        <%--
                        Disabled
                        <asp:LinkButton Text="[Enable]" CommandArgument="true" OnClick="TwoFactorEnable_Click" runat="server" />
                        --%>
                        <% } %>
                    </dd>
                </dl>
            </div>
        </div>
    </main>
</asp:Content>
