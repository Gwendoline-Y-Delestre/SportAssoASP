<%@ Page Title="Inscrire une connexion externe" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegisterExternalLogin.aspx.cs" Inherits="SportAssoASP.Account.RegisterExternalLogin" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <main>
        <h3>Inscrivez-vous avec votre compte <%: ProviderName %></h3>
        <asp:PlaceHolder runat="server">
            <h4>Formulaire d’association</h4>
            <hr />
            <asp:ValidationSummary runat="server" ShowModelStateErrors="true" CssClass="text-danger" />
            <p class="text-info">
                Vous avez été authentifié auprès de <strong><%: ProviderName %></strong>. Veuillez entrer une adresse de messagerie ci-dessous pour le site actuel
                et cliquer sur le bouton Connexion.
            </p>

            <div class="row">
                <asp:Label runat="server" AssociatedControlID="email" CssClass="col-md-2 col-form-label">Messagerie</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="email" CssClass="form-control" TextMode="Email" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="email"
                        Display="Dynamic" CssClass="text-danger" ErrorMessage="Une adresse de messagerie est nécessaire" />
                    <asp:ModelErrorMessage runat="server" ModelStateKey="email" CssClass="text-error" />
                </div>
            </div>

            <div class="row">
                <div class="offset-md-2 col-md-10">
                    <asp:Button runat="server" Text="Se connecter" CssClass="btn btn-outline-dark" OnClick="LogIn_Click" />
                </div>
            </div>
        </asp:PlaceHolder>
    </main>
</asp:Content>
