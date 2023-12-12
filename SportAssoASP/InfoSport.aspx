<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InfoSport.aspx.cs" Inherits="SportAssoASP.InfoSport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <div>
            <h1>Inscription
                <asp:Literal runat="server" ID="txtSportName" />
            </h1>
            <div>
                <p>
                    Nous proposons plusieurs formules. La catégorie Loisir est destinée aux joueurs occasionnels qui souhaitent
                se perfectionner.
                </p>
                <p>
                    Les adhérents s'inscrivant en Compétion s'engagent à participer aux tournois.
                </p>
                <p>
                    Les entraînements de Badmington et de Natation sont mixtes, les compétions sont genrées mais ont lieux au même moment.
                </p>
                <p>Enfin, les formules "Enfant" correspondent à la tranche d'âge 5-17 ans.</p>
            </div>
            <div>
                <div id="UnAuth" runat="server" visible="false">
                    <asp:GridView ID="GridViewActivites" runat="server" AutoGenerateColumns="False" CssClass="customGridView">
                        <Columns>
                            <asp:BoundField DataField="Section" HeaderText="Section"/>
                            <asp:BoundField DataField="Jour" HeaderText="Jour" />
                            <asp:BoundField DataField="Heure" HeaderText="Heure"/>
                            <asp:BoundField DataField="Prix" HeaderText="Prix (€)" />
                            <asp:BoundField DataField="NomPrenom" HeaderText="Entraineur"  />
                        </Columns>
                    </asp:GridView>

                    <div class="btn">
                        <p><a href="Account/Login">Connecter vous pour vous inscrire</a></p>
                    </div>
                </div>
                
                <div id="Auth" runat="server" visible="false">
                    <asp:GridView ID="GridViewActivitesAuth" runat="server" AutoGenerateColumns="False" CssClass="customGridView" OnRowCommand="GridViewActivitesAuth_RowCommand" OnRowDataBound="Inscription_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="Section" HeaderText="Section" SortExpression="Section" />
                            <asp:BoundField DataField="Jour" HeaderText="Jour" SortExpression="Jour" />
                            <asp:BoundField DataField="Heure" HeaderText="Heure" SortExpression="Heure" />
                            <asp:BoundField DataField="Prix" HeaderText="Prix" SortExpression="Prix" />

                            <asp:BoundField DataField="NomPrenom" HeaderText="Prix" SortExpression="Entraineur" />

                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:Button CssClass="customButton" ID="btnSInscrire" Visible="true" runat="server" Text="S'inscrire" CommandName="Inscription" CommandArgument='<%# Eval("ActiviteID") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                </div>
            </div>
        </div>
    </main>
</asp:Content>
