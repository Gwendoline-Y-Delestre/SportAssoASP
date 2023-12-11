<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Employes.aspx.cs" Inherits="SportAssoASP.Employes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridViewEmploye" runat="server" AutoGenerateColumns="False">
    <Columns>
        <asp:BoundField DataField="Nom" HeaderText="Nom" />
        <asp:BoundField DataField="Prenom" HeaderText="Prenom" />
        <asp:BoundField DataField="Email" HeaderText="Email" />
        <asp:BoundField DataField="Tel" HeaderText="Tel"  />

    </Columns>
</asp:GridView>
</asp:Content>
