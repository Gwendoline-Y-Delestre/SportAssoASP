<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="NewEmploye.aspx.cs" Inherits="SportAssoASP.NewEmploye" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label ID="lblErreur" runat="server" Text="Employe" />


    <div>
        <asp:Label runat="server">Nom :</asp:Label>

        <asp:TextBox runat="server" ID="Nom" />
    </div>

    <div>
        <asp:Label runat="server">Prénom : </asp:Label>

        <asp:TextBox runat="server" ID="Prenom" />

    </div>
    <div>
        <asp:Label runat="server">Date de Naissance :</asp:Label>

        <asp:TextBox runat="server" ID="BirthDate" TextMode="Date" />

    </div>

    <asp:ValidationSummary runat="server" CssClass="text-danger" />
    <div class="row">
        <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 col-form-label">Email :</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                CssClass="text-danger" ErrorMessage="Le champ d’adresse de messagerie est obligatoire." />
        </div>
    </div>
    <div>

        <asp:Button runat="server" ID="NewEmployeCreer" Text="Ajouter employé" OnClick="CreateNewEmploye" />

    </div>

</asp:Content>
