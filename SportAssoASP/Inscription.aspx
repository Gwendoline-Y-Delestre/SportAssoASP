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

        <asp:Button ID="BtnUpload" runat="server" Text="Procéder au paiement" OnClick="Afficher_Paiement" />

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
                <!-- Affichez les erreurs de validation de la carte -->
                <%--<div id="card-errors" role="alert"></div>--%>
                Mois et année d'expiration:
                <asp:DropDownList runat="server" ID="MoisExpiration">
                    <asp:ListItem Text="01" Value="01" />
                    <asp:ListItem Text="02" Value="02" />
                    <asp:ListItem Text="03" Value="03" />
                    <asp:ListItem Text="04" Value="04" />
                    <asp:ListItem Text="05" Value="05" />
                    <asp:ListItem Text="06" Value="06" />
                    <asp:ListItem Text="07" Value="07" />
                    <asp:ListItem Text="08" Value="08" />
                    <asp:ListItem Text="09" Value="09" />
                    <asp:ListItem Text="10" Value="10" />
                    <asp:ListItem Text="11" Value="11" />
                    <asp:ListItem Text="12" Value="12" />
                </asp:DropDownList>
                <asp:DropDownList runat="server" ID="AnneeExpiration">
                    <asp:ListItem Text="2023" Value="2023" />
                    <asp:ListItem Text="2024" Value="2024" />
                    <asp:ListItem Text="2025" Value="2025" />
                    <asp:ListItem Text="2026" Value="2026" />
                    <asp:ListItem Text="2027" Value="2027" />
                    <asp:ListItem Text="2028" Value="2028" />
                    <asp:ListItem Text="2029" Value="2029" />
                    <asp:ListItem Text="2030" Value="2030" />
                </asp:DropDownList><br />

                CVC:
                <asp:TextBox runat="server" ID="CVC" /><br />
            </div>

            <br />
            <!-- Bouton de paiement -->
            <asp:Button runat="server" Text="Payer" OnClick="Payer_Click" />
            <br />
            <!-- Affichez le message de résultat du paiement -->
            <asp:Label ID="Message" runat="server" Text=""></asp:Label>
        </div>
    </div>


</asp:Content>
