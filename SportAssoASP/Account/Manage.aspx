<%@ Page Title="Mon compte" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SportAssoASP.Account.Manage" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <div>
            <asp:PlaceHolder runat="server" ID="successMessage" Visible="false" ViewStateMode="Disabled">
                <p class="text-success"><%: SuccessMessage %></p>
            </asp:PlaceHolder>
        </div>
        <a href="../Default.aspx" class="back-to-home">
            <span>&#8592;</span> 
        </a>

        <div>

            <i></i>
            <p>
                Nom :
                <asp:Literal ID="Nom" runat="server" Text=""></asp:Literal>,
                Prénom :
                <asp:Literal ID="Prenom" runat="server" Text=""></asp:Literal>
                <br />
                Email :
                <asp:Literal ID="Email" runat="server" Text=""></asp:Literal>
                <br />
                Téléphone :
                <asp:Literal ID="Tel" runat="server" Text=""></asp:Literal>
                <br />
                Adresse :
                <asp:Literal ID="Adresse" runat="server" Text=""></asp:Literal>
                <br />
                Mot de passe:
                <asp:HyperLink NavigateUrl="/Account/ManagePassword" Text="Changer mon mot de passe" Visible="false" ID="ChangePassword" runat="server" />
            </p>

            <p>Inscription</p>
            <asp:GridView CssClass="customGridView" ID="MesInscriptions" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Sport" HeaderText="Sport" />
                    <asp:BoundField DataField="Section" HeaderText="Section" />
                    <asp:BoundField DataField="Jour" HeaderText="Jour" />
                    <asp:BoundField DataField="Heure" HeaderText="Heure" />
                </Columns>
            </asp:GridView>

        </div>


    </main>
</asp:Content>
