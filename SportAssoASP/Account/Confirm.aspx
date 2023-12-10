<%@ Page Title="Confirmation du compte" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Confirm.aspx.cs" Inherits="SportAssoASP.Account.Confirm" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <main aria-labelledby="title">
    <h2 id="title"><%: Title %>.</h2>
    <div>
        <asp:PlaceHolder runat="server" ID="successPanel" ViewStateMode="Disabled" Visible="true">
            <p>
                Merci d'avoir confirmé votre compte. Cliquez <asp:HyperLink ID="login" runat="server" NavigateUrl="~/Account/Login">ici</asp:HyperLink>  se connecter             
            </p>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="errorPanel" ViewStateMode="Disabled" Visible="false">
            <p class="text-danger">
                Une erreur s'est produite.
            </p>
        </asp:PlaceHolder>
    </div>
    </main>
</asp:Content>
