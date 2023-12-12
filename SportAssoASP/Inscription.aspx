<%@ Page Title="Inscription" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inscription.aspx.cs" Inherits="SportAssoASP.Inscription" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="CapMaxDépassé" runat="server" visible="false">
        <p>Désolé le nombre maximum de participant pour cette catégorie est atteint</p>
    </div>


    <div id="CapMaxOk" runat="server" visible="true">
        <div>
            <p>Récapitulatif :</p>

            <p>
                <asp:Literal ID="RecapSport" runat="server" Text=""></asp:Literal>
                <asp:Literal ID="RecapJour" runat="server" Text=""></asp:Literal>
                <asp:Literal ID="RecapHeure" runat="server" Text=""></asp:Literal>
                <asp:Literal ID="RecapSection" runat="server" Text=""></asp:Literal>
            <p>
                <asp:Literal ID="RecapPrix" runat="server" Text=""></asp:Literal>
                €
            </p>
            <p>Veuillez téléverser tous les documents avant de procéder au règlement.</p>
        </div>
        <section class="container">
            <div class="form">
                <div>
                    <p>Assurance *:</p>
                    <asp:FileUpload ID="Assurance" runat="server" />
                    <asp:Label ID="StatusLabel1" runat="server" Text=""></asp:Label>
                </div>



                <div>
                    <p>Certificat médical *:</p>
                   
                    <asp:FileUpload ID="Certificat" runat="server" />
                    <asp:Label ID="StatusLabel2" runat="server" Text=""></asp:Label>
                </div>

                <div>
                    <p>Accord Parental :</p>
                    Obligatoire pour les mineurs
                    <asp:FileUpload ID="Accord" runat="server" />
                    <asp:Label ID="StatusLabel3" runat="server" Text=""></asp:Label>
                </div>


                <div style="margin-left: 25%; width: 50%">
                    <asp:Button CssClass="customButton" ID="BtnUpload" runat="server" Text="Payer" OnClick="Afficher_Paiement" />

                </div>
                <asp:Label ID="InformationFichier" runat="server" Text=""></asp:Label>

            </div>
        </section>



        <!-- Formulaire pour les coordonnées bancaires -->

        <div id="paiement" runat="server" visible="false">
            <section class="container">
                <h2>Formulaire de Paiement</h2>
                <div class="form">

                    <div id="card-element">
                        <asp:Label runat="server">Numéro de carte :</asp:Label>
                        <asp:TextBox runat="server" ID="NumeroCarte" /><br />
                        <div>
                            <asp:Label runat="server">Date d'expiration :</asp:Label>

                            <br />
                            <div style="display: flex">

                                <div style="width: 35%">
                                    <asp:DropDownList runat="server" ID="MoisExpiration">
                                        <asp:ListItem Text="01" Value="01" />
                                        <asp:ListItem Text="02" Value="02" />
                                        <asp:ListItem Text="03" Value="03" />
                                        <asp:ListItem Text="04" Value="04" />
                                        <asp:ListItem Text="05" Value="05" />
                                        <asp:ListItem Text="06" Value="06" />
                                        <asp:ListItem Text="07" Value="07" />
                                        <asp:ListItem Text="08" Value="08" />
                                        <asp:ListItem Text="09" Value="09" />
                                        <asp:ListItem Text="10" Value="10" />
                                        <asp:ListItem Text="11" Value="11" />
                                        <asp:ListItem Text="12" Value="12" />
                                    </asp:DropDownList>
                                </div>
                                <div style="width: 35%">
                                    <asp:DropDownList runat="server" ID="AnneeExpiration">
                                        <asp:ListItem Text="2023" Value="2023" />
                                        <asp:ListItem Text="2024" Value="2024" />
                                        <asp:ListItem Text="2025" Value="2025" />
                                        <asp:ListItem Text="2026" Value="2026" />
                                        <asp:ListItem Text="2027" Value="2027" />
                                        <asp:ListItem Text="2028" Value="2028" />
                                        <asp:ListItem Text="2029" Value="2029" />
                                        <asp:ListItem Text="2030" Value="2030" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>


                        <asp:Label runat="server">CVC :</asp:Label>
                        <asp:TextBox runat="server" ID="CVC" /><br />
                    </div>

                    <div style="margin-left: 25%; width: 50%">
                        <asp:Button CssClass="customButton" runat="server" Text="Payer" OnClick="Payer_Click" />

                    </div>

                    <asp:Label ID="Message" runat="server" Text=""></asp:Label>
                </div>
            </section>

        </div>

    </div>



</asp:Content>
