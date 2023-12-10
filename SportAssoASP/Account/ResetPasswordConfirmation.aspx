<%@ Page Title="Mot de passe modifié" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ResetPasswordConfirmation.aspx.cs" Inherits="SportAssoASP.Account.ResetPasswordConfirmation" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %>.</h2>
        <div>
            <p>Votre mot de passe a été modifié. Cliquez sur <asp:HyperLink ID="login" runat="server" NavigateUrl="~/Account/Login">ici</asp:HyperLink> se connecter </p>
        </div>
    </main>
</asp:Content>
