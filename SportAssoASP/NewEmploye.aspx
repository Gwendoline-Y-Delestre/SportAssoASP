<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="NewEmploye.aspx.cs" Inherits="SportAssoASP.NewEmploye" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
<asp:Label ID="lblErreur" runat="server" Text="" />
    </p>
    

    <section class="container">
        <h2>Ajouter un nouvel employé</h2>
        <div class="form">
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
            <div style="margin-left:4% ; margin-right:-2%" >
                <asp:Label runat="server" AssociatedControlID="Email">Email :</asp:Label>
                <div>
                    <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                        CssClass="text-danger" ErrorMessage="Le champ d’adresse de messagerie est obligatoire." />
                </div>
            </div>
            <div style="margin-left:25%; width:50%">

                <asp:Button runat="server" ID="NewEmployeCreer" Text="Ajouter employé" OnClick="CreateNewEmploye" />

            </div>
        </div>
    </section>

</asp:Content>
