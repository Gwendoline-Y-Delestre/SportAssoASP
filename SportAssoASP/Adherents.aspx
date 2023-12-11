<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Adherents.aspx.cs" Inherits="SportAssoASP.Adherents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridViewAdherents" runat="server" AutoGenerateColumns="False">
    <Columns>
        <asp:BoundField DataField="Nom" HeaderText="Nom" />
        <asp:BoundField DataField="Prenom" HeaderText="Prenom" />
        <asp:BoundField DataField="Email" HeaderText="Email" />
        <asp:BoundField DataField="Tel" HeaderText="Tel"  />
        <asp:BoundField DataField="Date_naissance" HeaderText="Date de naissance" />

    </Columns>
</asp:GridView>
</asp:Content>
