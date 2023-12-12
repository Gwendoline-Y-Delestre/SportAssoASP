<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InfoSport.aspx.cs" Inherits="SportAssoASP.InfoSport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <div>
                <asp:Literal runat="server" ID="ErrorMessage" Text="" />

            <h1>
                <asp:Literal runat="server" ID="txtSportName" />
            </h1>
            <div>
                <div id="UnAuth" runat="server" visible="false">
                    <asp:GridView ID="GridViewActivites" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="Section" HeaderText="Section" SortExpression="Section" />
                            <asp:BoundField DataField="Jour" HeaderText="Jour" SortExpression="Jour" />
                            <asp:BoundField DataField="Heure" HeaderText="Heure" SortExpression="Heure" />
                            <asp:BoundField DataField="Prix" HeaderText="Prix" SortExpression="Prix" />
                            <asp:BoundField DataField="NomPrenom" HeaderText="Prix" SortExpression="Entraineur" />


                        </Columns>
                    </asp:GridView>

                    <a href="Account/Login">Connecter vous pour vous inscrire</a>
                </div>


                <div id="Auth" runat="server" visible="false">
                    <asp:GridView ID="GridViewActivitesAuth" runat="server" AutoGenerateColumns="False" OnRowCommand="GridViewActivitesAuth_RowCommand" OnRowDataBound="Inscription_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="Section" HeaderText="Section" SortExpression="Section" />
                            <asp:BoundField DataField="Jour" HeaderText="Jour" SortExpression="Jour" />
                            <asp:BoundField DataField="Heure" HeaderText="Heure" SortExpression="Heure" />
                            <asp:BoundField DataField="Prix" HeaderText="Prix" SortExpression="Prix" />

                            <asp:BoundField DataField="NomPrenom" HeaderText="Prix" SortExpression="Entraineur" />

                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:Button ID="btnSInscrire" Visible="true" runat="server" Text="S'inscrire" CommandName="Inscription" CommandArgument='<%# Eval("ActiviteID") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>


                </div>
            </div>
        </div>
    </main>
</asp:Content>
