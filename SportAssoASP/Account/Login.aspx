<%@ Page Title="Se connecter" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SportAssoASP.Account.Login" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <main>
        
        <div>
            <section class="container" id="loginForm">
                <h2>Connectez-vous :</h2>
                <div class="form">

                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
                    <div>
                        <asp:Label runat="server" AssociatedControlID="Email">Messagerie :</asp:Label>
                        <div >
                            <asp:TextBox runat="server" ID="Email" TextMode="Email" CssClass="inputChamps" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                                CssClass="text-danger" ErrorMessage="Le champ d’adresse de messagerie est obligatoire." />
                        </div>
                    </div>
                    <div>
                        <asp:Label runat="server" AssociatedControlID="Password">Mot de passe :</asp:Label>
                        <div>
                            <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="Le champ du mot de passe est obligatoire." />
                        </div>
                    </div>
                    <div>
                        <div >
                            <div style="display:flex">
                                <asp:CheckBox runat="server" ID="RememberMe" style="max-width:50px" />
                                <asp:Label runat="server" AssociatedControlID="RememberMe">Mémoriser le mot de passe ?</asp:Label>
                            </div>
                        </div>
                    </div>
                    <div>
                        <div style="margin-left:25%; width:50%">
                            <asp:Button runat="server" OnClick="LogIn" Text="Se connecter" />
                        </div>
                    </div>
                </div>

            </section>
        </div>


    </main>
</asp:Content>
