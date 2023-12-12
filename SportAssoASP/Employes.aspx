<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Employes.aspx.cs" Inherits="SportAssoASP.Employes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p class="text-danger">
    <asp:Literal runat="server" ID="ErreurMessage" />
</p>
    <asp:GridView ID="GridViewEmploye" runat="server" AutoGenerateColumns="False"  CssClass="center-gridview">
    <Columns>
        <asp:BoundField DataField="Nom" HeaderText="Nom" />
        <asp:BoundField DataField="Prenom" HeaderText="Prenom" />
        <asp:BoundField DataField="Email" HeaderText="Email" />

    </Columns>
</asp:GridView>
    <div class="btn" ><p><a runat="server" href="~/NewEmploye.aspx">Ajouter un employé</a></p></div>
    
</asp:Content>
