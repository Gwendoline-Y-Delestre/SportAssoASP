<%@ Page Title="Mon compte" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SportAssoASP.Account.Manage" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %>.</h2>

        <div>
            <asp:PlaceHolder runat="server" ID="successMessage" Visible="false" ViewStateMode="Disabled">
                <p class="text-success"><%: SuccessMessage %></p>
            </asp:PlaceHolder>
        </div>

        <div>
            <h2>Mes inscriptions</h2>
            <p>Info</p>
            <asp:Literal ID="Nom" runat="server" Text=""></asp:Literal>
            <asp:Literal ID="Prenom" runat="server" Text=""></asp:Literal>
            <asp:Literal ID="Email" runat="server" Text=""></asp:Literal>
            <asp:Literal ID="Tel" runat="server" Text=""></asp:Literal>
            <asp:Literal ID="Adresse" runat="server" Text=""></asp:Literal>

                


            <p>Inscription</p>
            <asp:GridView ID="MesInscriptions" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Section" HeaderText="Section" SortExpression="Section" />
                    <asp:BoundField DataField="Jour" HeaderText="Jour" SortExpression="Jour" />
                    <asp:BoundField DataField="Heure" HeaderText="Heure" SortExpression="Heure" />
                </Columns>
            </asp:GridView>

        </div>

        <div class="col-md-12">
            <div class="row">
                <h4>Modifier vos paramètres de compte</h4>
                <hr />
                <dl class="dl-horizontal">
                    <dt>Mot de passe :</dt>
                    <dd>
                        <asp:HyperLink NavigateUrl="/Account/ManagePassword" Text="Changer mon mot de passe" Visible="false" ID="ChangePassword" runat="server" />
                    </dd>
                </dl>
            </div>
        </div>
    </main>
</asp:Content>
