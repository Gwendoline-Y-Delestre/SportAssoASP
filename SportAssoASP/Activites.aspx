<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Activites.aspx.cs" Inherits="SportAssoASP.Activites" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p class="text-danger">
    <asp:Literal runat="server" ID="ErreurMessage" />
</p>
    <asp:DataGrid ID="DataGrid" runat="server" BorderWidth="1" GridLines="Both" AutoGenerateColumns="false">
    <Columns>
        <asp:BoundColumn DataField="Heure" HeaderText="Heure" />
        <asp:BoundColumn DataField="Section" HeaderText="Section" />
        <asp:BoundColumn DataField="Jour" HeaderText="Jour" />
        <asp:BoundColumn DataField="Heure" HeaderText="Heure" />
        <asp:BoundColumn DataField="Capacite_max" HeaderText="Capacite max" />
        <asp:BoundColumn DataField="Prix" HeaderText="Prix" />
        <asp:BoundColumn DataField="EmployeID" HeaderText="EmployeID" />
    </Columns>
</asp:DataGrid>
</asp:Content>
