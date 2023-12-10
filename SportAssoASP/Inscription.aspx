<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inscription.aspx.cs" Inherits="SportAssoASP.Inscription" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <asp:Literal ID="RecapJour" runat="server" Text=""></asp:Literal>
        <asp:Literal ID="RecapHeure" runat="server" Text=""></asp:Literal>
        <asp:Literal ID="RecapSection" runat="server" Text=""></asp:Literal>
        <asp:Literal ID="RecapPrix" runat="server" Text=""></asp:Literal>
    </div>
    <div>
        <asp:FileUpload ID="Assurance" runat="server" />
        <asp:Label ID="StatusLabel1" runat="server" Text=""></asp:Label>

        <asp:FileUpload ID="Certificat" runat="server" />
        <asp:Label ID="StatusLabel2" runat="server" Text=""></asp:Label>

        <asp:FileUpload ID="Accord" runat="server" />
        <asp:Label ID="StatusLabel3" runat="server" Text=""></asp:Label>

        <asp:Button ID="BtnUpload" runat="server" Text="Porcéder au paiement" OnClick="Afficher_Paiement" />

        <asp:Label ID="InformationFichier" runat="server" Text=""></asp:Label>

    </div>



    <!-- Formulaire pour les coordonnées bancaires -->

    <div id="paiement" runat="server" visible="false">
        <h1>Formulaire de Paiement</h1>
        <div>
            <!-- Votre contenu de formulaire ici -->
            <!-- Utilisez Stripe.js pour générer un élément de paiement -->
            <div id="card-element">
                <!-- Champs du formulaire -->
                Numéro de carte:
                <asp:TextBox runat="server" ID="NumeroCarte" /><br />
                Mois d'expiration:
                <asp:TextBox runat="server" ID="MoisExpiration" /><br />
                Année d'expiration:
                <asp:TextBox runat="server" ID="AnneeExpiration" /><br />
                CVC:
                <asp:TextBox runat="server" ID="CVC" /><br />
            </div>
            <!-- Affichez les erreurs de validation de la carte -->
            <%--<div id="card-errors" role="alert"></div>--%>
            <br />
            <!-- Bouton de paiement -->
            <asp:Button runat="server" Text="Payer" OnClick="Payer_Click" />
            <br />
            <!-- Affichez le message de résultat du paiement -->
            <asp:Label ID="Message" runat="server" Text=""></asp:Label>
        </div>
    </div>


</asp:Content>
