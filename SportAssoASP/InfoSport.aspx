<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InfoSport.aspx.cs" Inherits="SportAssoASP.InfoSport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <div>

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

                        </Columns>
                    </asp:GridView>

                    <a href="Account/Login">Connecter vous pour vous inscrire</a>
                </div>


                <div id="Auth" runat="server" visible="false">
                    <asp:GridView ID="GridViewActivitesAuth" runat="server" AutoGenerateColumns="False" OnRowCommand="GridViewActivitesAuth_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="Section" HeaderText="Section" SortExpression="Section" />
                            <asp:BoundField DataField="Jour" HeaderText="Jour" SortExpression="Jour" />
                            <asp:BoundField DataField="Heure" HeaderText="Heure" SortExpression="Heure" />
                            <asp:BoundField DataField="Prix" HeaderText="Prix" SortExpression="Prix" />
                            <%--<asp:TemplateField HeaderText="Choisir">
                                <ItemTemplate>
                                    <asp:RadioButton ID="RadioButtonChoisir" runat="server" GroupName="SectionGroup" Text="Choisir" CommandName="ChoisirSection" CommandArgument='<%# Eval("ActiviteID") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Actions">
                                <ItemTemplate>
                                    <asp:Button runat="server" Text="S'inscrire" CommandName="Inscription" CommandArgument='<%# Eval("ActiviteID") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>



                </div>
            </div>
    </main>
</asp:Content>
