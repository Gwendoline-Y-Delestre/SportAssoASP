<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Adherents.aspx.cs" Inherits="SportAssoASP.Adherents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridViewAdherentsInscriptions" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="AdherentNom" HeaderText="Nom Adhérent" />
            <asp:BoundField DataField="AdherentPrenom" HeaderText="Prénom Adhérent" />
            <asp:BoundField DataField="AdherentDateNaissance" HeaderText="Date de Naissance Adhérent" />
            <asp:BoundField DataField="AdherentEmail" HeaderText="Email Adhérent" />
            <asp:BoundField DataField="ContactUrgenceNom" HeaderText="Nom Contact Urgence" />
            <asp:BoundField DataField="ContactUrgencePrenom" HeaderText="Prénom Contact Urgence" />
            <asp:BoundField DataField="ContactUrgenceEmail" HeaderText="Email Contact Urgence" />
            <asp:BoundField DataField="ContactUrgenceTel" HeaderText="Téléphone Contact Urgence" />
            <asp:BoundField DataField="ActiviteSport" HeaderText="Sport Activité" />
            <asp:BoundField DataField="ActiviteSection" HeaderText="Section Activité" />
            <asp:BoundField DataField="ActiviteJour" HeaderText="Jour Activité" />
            <asp:BoundField DataField="ActiviteHeure" HeaderText="Heure Activité" />
            <asp:BoundField DataField="InscriptionDateInscription" HeaderText="Date d'Inscription" />
            <asp:BoundField DataField="AssurancePath" HeaderText="Chemin Assurance" />
            <asp:BoundField DataField="CertificatPath" HeaderText="Chemin Certificat" />
            <asp:BoundField DataField="AccordParentalPath" HeaderText="Chemin Accord Parental" />
        </Columns>
    </asp:GridView>

</asp:Content>
