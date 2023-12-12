<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Adherents.aspx.cs" Inherits="SportAssoASP.Adherents" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErreurMessage" />
    </p>
    <asp:GridView ID="GridViewAdherentsInscriptions" CssClass="customGridView" runat="server" AutoGenerateColumns="False" OnRowCommand="DocView_RowCommand">
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
            <%--<asp:BoundField DataField="AssurancePath" HeaderText="Chemin Assurance" />
            <asp:BoundField DataField="CertificatPath" HeaderText="Chemin Certificat" />
            <asp:BoundField DataField="AccordParentalPath" HeaderText="Chemin Accord Parental" />--%>
            <asp:TemplateField HeaderText="Assurance">
                <ItemTemplate>
                    <asp:Button CssClass="customButton" ID="btnOpenDocument1" runat="server" Text="Ouvrir" OnClientClick='<%# "ouvrirDocument(" + Eval("AssurancePath").ToString().Replace("\\", "\\\\") +" );" %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Certificat">
                <ItemTemplate>
                    <asp:Button CssClass="customButton" ID="btnOpenDocument2" runat="server" Text="Ouvrir" OnClientClick='<%# "ouvrirDocument(" + Eval("CertificatPath").ToString().Replace("\\", "\\\\") +" );" %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Accord Parental">
                <ItemTemplate>
                    <asp:Button CssClass="customButton" ID="btnOpenDocument3" runat="server" Text="Ouvrir" OnClientClick='<%# "ouvrirDocument(" + Eval("AccordParentalPath").ToString().Replace("\\", "\\\\") +" );" %>' />
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
    </asp:GridView>

</asp:Content>
