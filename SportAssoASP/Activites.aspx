<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Activites.aspx.cs" Inherits="SportAssoASP.Activites" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErreurMessage" />
    </p>
    <asp:DataGrid ID="GridActivites" CssClass="customGridView" runat="server" BorderWidth="1" GridLines="Both" AutoGenerateColumns="false"  OnRowCommand="ModifActivite_RowCommand">
        <Columns>
            <asp:BoundColumn DataField="Sport" HeaderText="Sport" />
            <asp:BoundColumn DataField="Section" HeaderText="Section" />
            <asp:BoundColumn DataField="Jour" HeaderText="Jour" />
            <asp:BoundColumn DataField="Heure" HeaderText="Heure" />
            <asp:BoundColumn DataField="Capacite_max" HeaderText="Capacite max" />
            <asp:BoundColumn DataField="Prix" HeaderText="Prix" />
            <%--<asp:BoundColumn DataField="NomPrenom" HeaderText="Employe" />--%>
            <asp:TemplateColumn HeaderText="Entraineur">
                <ItemTemplate>
                    <%# Eval("NomPrenom") %>
                </ItemTemplate>
            </asp:TemplateColumn>

            <asp:TemplateColumn HeaderText="">
                <ItemTemplate>
                    <asp:Button CssClass="customButton" runat="server" Text="Modifier" CommandName="Modification" CommandArgument='<%# Eval("ActiviteID") %>' />
                </ItemTemplate>
            </asp:TemplateColumn>

        </Columns>
    </asp:DataGrid>

   <div class="btn"><p><a runat="server" href="~/NewActivite.aspx">Ajouter une activité</a></p></div> 
</asp:Content>
