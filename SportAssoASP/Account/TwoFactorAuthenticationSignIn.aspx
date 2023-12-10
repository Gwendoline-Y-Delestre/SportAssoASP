<%@ Page Title="Authentification à 2 facteurs" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TwoFactorAuthenticationSignIn.aspx.cs" Inherits="SportAssoASP.Account.TwoFactorAuthenticationSignIn" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %>.</h2>
        <asp:PlaceHolder runat="server" ID="sendcode">
            <section>
                <h4>Envoyer le code de vérification</h4>
                <hr />
                <div class="row">
                    <div class="col-md-12">
                        Sélectionner le fournisseur d'authentification à 2 facteurs :
                <asp:DropDownList runat="server" ID="Providers">
                </asp:DropDownList>
                        <asp:Button Text="Envoyer" ID="ProviderSubmit" OnClick="ProviderSubmit_Click" CssClass="btn btn-outline-dark" runat="server" />
                    </div>
                </div>
            </section>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="verifycode" Visible="false">
            <section>
                <h4>Entrer le code de vérification</h4>
                <hr />
                <asp:HiddenField ID="SelectedProvider" runat="server" />
                <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                    <p class="text-danger">
                        <asp:Literal runat="server" ID="FailureText" />
                    </p>
                </asp:PlaceHolder>
                <div class="row">
                    <asp:Label Text="Code :" runat="server" AssociatedControlID="Code" CssClass="col-md-2 col-form-label" />
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="Code" CssClass="form-control" />
                    </div>
                </div>
                <div class="row">
                    <div class="offset-md-2 col-md-10">
                        <div class="checkbox">
                            <asp:Label Text="Mémoriser le navigateur" runat="server" />
                            <asp:CheckBox Text="" ID="RememberBrowser" runat="server" />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="offset-md-2 col-md-10">
                        <asp:Button Text="Envoyer" ID="CodeSubmit" OnClick="CodeSubmit_Click" CssClass="btn btn-outline-dark" runat="server" />
                    </div>
                </div>
            </section>
        </asp:PlaceHolder>
    </main>
</asp:Content>
