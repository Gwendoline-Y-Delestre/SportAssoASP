<%@ Page Title="Inscription" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="SportAssoASP.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <main aria-labelledby="title">
        <p class="text-danger">
            <asp:Literal runat="server" ID="ErrorMessage" />
        </p>
        <section class="container">
            <div class="form">
                <h4>Créer un nouveau compte</h4>
                <hr />
                <div>
                    <asp:Label runat="server">Nom :</asp:Label>
                    <div>
                        <asp:TextBox runat="server" ID="Nom" />

                    </div>
                </div>
                <div>
                    <asp:Label runat="server">Prénom :</asp:Label>
                    <div>
                        <asp:TextBox runat="server" ID="Prenom" />

                    </div>
                </div>
                <div>
                    <asp:Label runat="server">Date de Naissance :</asp:Label>
                    <div>
                        <asp:TextBox runat="server" ID="BirthDate" TextMode="Date" />

                    </div>
                </div>

                <div>
                    <asp:Label runat="server">Téléphone :</asp:Label>
                    <div>
                        <asp:TextBox runat="server" ID="Tel" />

                    </div>
                    <p class="text-danger">
                        <asp:Literal runat="server" ID="lblError" />
                    </p>
                </div>
                <div>
                    <asp:Label runat="server">Adresse postale :</asp:Label>
                    <div>
                        <asp:TextBox runat="server" ID="Adresse" />

                    </div>
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
                <div class="row">
                    <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 col-form-label">Mot de passe :</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                            CssClass="text-danger" ErrorMessage="Le champ du mot de passe est obligatoire." />
                    </div>
                </div>
                <div class="row">
                    <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 col-form-label">Confirmer le mot de passe :</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                            CssClass="text-danger" Display="Dynamic" ErrorMessage="Merci, votre compte est valide." />
                        <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                            CssClass="text-danger" Display="Dynamic" ErrorMessage="Le mot de passe et le mot de passe de confirmation ne correspondent pas." />
                    </div>
                </div>

                <div>
                    <p>Contact d'urgence</p>
                    <div>
                        <asp:Label runat="server">Nom :</asp:Label>
                        <div>
                            <asp:TextBox runat="server" ID="ContactNom" />

                        </div>
                    </div>
                    <div>
                        <asp:Label runat="server">Prénom :</asp:Label>
                        <div>
                            <asp:TextBox runat="server" ID="ContactPrenom" />

                        </div>
                    </div>
                    <div>
                        <asp:Label runat="server">Téléphone :</asp:Label>
                        <div>
                            <asp:TextBox runat="server" ID="ContactTel" />

                        </div>
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="lblError2" />
                        </p>
                    </div>
                    <div>
                        <asp:Label runat="server">Email</asp:Label>
                        <div>
                            <asp:TextBox runat="server" ID="ContactEmail" />
                        </div>
                    </div>
                    <div style="min-height: 60px">
                        <asp:Label runat="server" AssociatedControlID="Relation">Relation :</asp:Label>
                        <asp:DropDownList ID="Relation" runat="server">
                            <asp:ListItem Text="Mère" Value="mere" />
                            <asp:ListItem Text="Père" Value="pere" />
                            <asp:ListItem Text="Tuteur Légal" Value="tuteur" />
                            <asp:ListItem Text="Autre" Value="autre" />
                        </asp:DropDownList>
                    </div>

                </div>
                <div style="display: flex">
                    <input type="checkbox" runat="server" id="chkAccepterConditions" />
                    <label class="form-check-label" for="chkAccepterConditions">J'accepte les conditions d'utilisation</label>
                    <%--<asp:CustomValidator runat="server" ID="cvAccepterConditions"
                CssClass="text-danger" Display="Dynamic" ErrorMessage=""
                OnServerValidate="cvAccepterConditions_ServerValidate" />--%>
                </div>
                <div>
                    <div style="margin-left:25%; width:50%">
                        <asp:Button runat="server" OnClick="CreateUser_Click" Text="S'Inscrire" CssClass="btn btn-outline-dark" CausesValidation="True" />
                    </div>
                </div>
            </div>
        </section>

    </main>
</asp:Content>
