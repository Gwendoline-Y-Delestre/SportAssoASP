<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="NewActivite.aspx.cs" Inherits="SportAssoASP.NewActivite" %>

<asp:Content ID="NewActivite" ContentPlaceHolderID="MainContent" runat="server">
    <p><asp:Label ID="lblErreur" runat="server" Text="" /></p>
    <section class="container">
        <h2>Ajouter une nouvelle Activité</h2>
        <div class="form">
            <div>
                <asp:Label AssociatedControlID="NewSport" runat="server" Text="Sport :" />
                <asp:DropDownList ID="NewSport" runat="server">
                    <asp:ListItem Text="Badminton" Value="Badminton" />
                    <asp:ListItem Text="Basketball" Value="Basketball" />
                    <asp:ListItem Text="Volleyball" Value="Volleyball" />
                    <asp:ListItem Text="Handball" Value="Handball" />
                    <asp:ListItem Text="Gymnastique" Value="Gymnastique" />
                    <asp:ListItem Text="Rugby" Value="Rugby" />
                    <asp:ListItem Text="Football" Value="Football" />
                    <asp:ListItem Text="Judo" Value="Judo" />
                    <asp:ListItem Text="Natation" Value="Natation" />
                </asp:DropDownList>
            </div>

            <div>
                <asp:Label AssociatedControlID="NewSection" runat="server" Text="Section :" />
                <asp:DropDownList ID="NewSection" runat="server">
                    <asp:ListItem Text="Compétition Adulte Mixte" Value="Compétition Adulte Mixte" />
                    <asp:ListItem Text="Compétition Enfants Mixte" Value="Compétition Enfants Mixte" />
                    <asp:ListItem Text="Compétion Homme" Value="Compétion Homme" />
                    <asp:ListItem Text="Compétion Femme" Value="Compétion Femme" />
                    <asp:ListItem Text="Compétion Garçon" Value="Compétion Garçon" />
                    <asp:ListItem Text="Compétion Fille" Value="Compétion Fille" />
                    <asp:ListItem Text="Loisir Adulte Mixte" Value="Loisir Adulte Mixte" />
                    <asp:ListItem Text="Loisir Enfant Mixte" Value="Loisir Enfant Mixte" />
                </asp:DropDownList>
            </div>

            <div>
                <asp:Label AssociatedControlID="NewJour" runat="server" Text="Jour :" />
                <asp:DropDownList ID="NewJour" runat="server">
                    <asp:ListItem Text="Lundi" Value="Lundi" />
                    <asp:ListItem Text="Mardi" Value="Mardi" />
                    <asp:ListItem Text="Mercredi" Value="Mercredi" />
                    <asp:ListItem Text="Jeudi" Value="Jeudi" />
                    <asp:ListItem Text="Vendredi" Value="Vendredi" />
                    <asp:ListItem Text="Samedi" Value="Samedi" />
                    <asp:ListItem Text="Dimanche" Value="Dimanche" />
                </asp:DropDownList>
            </div>
            <div>
                <asp:Label AssociatedControlID="NewHeure" runat="server" Text="Heure :" />
                <asp:DropDownList ID="NewHeure" runat="server">
                    <asp:ListItem Text="08h00" Value="08:00:00" />
                    <asp:ListItem Text="09h00" Value="09:00:00" />
                    <asp:ListItem Text="10h00" Value="10:00:00" />
                    <asp:ListItem Text="11h00" Value="11:00:00" />
                    <asp:ListItem Text="12h00" Value="12:00:00" />
                    <asp:ListItem Text="13h00" Value="13:00:00" />
                    <asp:ListItem Text="14h00" Value="14:00:00" />
                    <asp:ListItem Text="15h00" Value="15:00:00" />
                    <asp:ListItem Text="16h00" Value="16:00:00" />
                    <asp:ListItem Text="16h30" Value="16:30:00" />
                    <asp:ListItem Text="17h00" Value="17:00:00" />
                    <asp:ListItem Text="18h00" Value="18:00:00" />
                    <asp:ListItem Text="19h00" Value="19:00:00" />
                    <asp:ListItem Text="20h00" Value="20:00:00" />
                    <asp:ListItem Text="21h00" Value="21:00:00" />
                </asp:DropDownList>
            </div>

            <div>
                <asp:Label runat="server">Prix de l'inscription</asp:Label>

                <asp:TextBox runat="server" ID="Prix" />
            </div>

            <div>
                <asp:Label runat="server">Capacité max de la scéance</asp:Label>

                <asp:TextBox runat="server" ID="CapaciteMax" />

            </div>
            <div>
                <asp:Label AssociatedControlID="NewEmploye" runat="server" Text="Employé :" />
                <asp:DropDownList ID="NewEmploye" runat="server">
                </asp:DropDownList>
            </div>
            <div style="margin-left:25%; width:50%">

                <asp:Button runat="server" ID="NewActiviteCreer" Text="Ajouter activite" OnClick="CreateNewActivite" />

            </div>
        </div>
    </section>

</asp:Content>


