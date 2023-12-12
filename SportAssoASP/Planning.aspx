<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Planning.aspx.cs" Inherits="SportAssoASP.Planning" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErreurMessage" />
    </p>
    <div id="calendar">
        <div class="row3">
            <div id="lundi" class="jourSemaine">
                <h4>Lundi</h4>
                <asp:DataGrid ID="GridLundi" runat="server" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundColumn DataField="Sport" HeaderText="Sport" />
                        <asp:BoundColumn DataField="Section" HeaderText="Section" />
                        <asp:BoundColumn DataField="Heure" HeaderText="Heure" />
                        <asp:BoundColumn DataField="NomPrenom" HeaderText="Entraineur" />
                    </Columns>
                </asp:DataGrid>
            </div>
            <div id="mardi" class="jourSemaine">
                <h4>Mardi</h4>
                <asp:DataGrid ID="GridMardi" runat="server" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundColumn DataField="Sport" HeaderText="Sport" />
                        <asp:BoundColumn DataField="Section" HeaderText="Section" />
                        <asp:BoundColumn DataField="Heure" HeaderText="Heure" />
                        <asp:BoundColumn DataField="NomPrenom" HeaderText="Entraineur" />
                    </Columns>
                </asp:DataGrid>
            </div>
            <div id="mercredi" class="jourSemaine">
                <h4>Mercredi</h4>
                <asp:DataGrid ID="GridMercredi" runat="server" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundColumn DataField="Sport" HeaderText="Sport" />
                        <asp:BoundColumn DataField="Section" HeaderText="Section" />
                        <asp:BoundColumn DataField="Heure" HeaderText="Heure" />
                        <asp:BoundColumn DataField="NomPrenom" HeaderText="Entraineur" />
                    </Columns>
                </asp:DataGrid>
            </div>
        </div>
        <div class="row3" id="colonne2">
            <div id="jeudi" class="jourSemaine">
                <h4>Jeudi</h4>
                <asp:DataGrid ID="GridJeudi" runat="server" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundColumn DataField="Sport" HeaderText="Sport" />
                        <asp:BoundColumn DataField="Section" HeaderText="Section" />
                        <asp:BoundColumn DataField="Heure" HeaderText="Heure" />
                        <asp:BoundColumn DataField="NomPrenom" HeaderText="Entraineur" />
                    </Columns>
                </asp:DataGrid>
            </div>
            <div id="vendredi" class="jourSemaine">
                <h4>Vendredi</h4>
                <asp:DataGrid ID="GridVendredi" runat="server" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundColumn DataField="Sport" HeaderText="Sport" />
                        <asp:BoundColumn DataField="Section" HeaderText="Section" />
                        <asp:BoundColumn DataField="Heure" HeaderText="Heure" />
                        <asp:BoundColumn DataField="NomPrenom" HeaderText="Entraineur" />
                    </Columns>
                </asp:DataGrid>
            </div>
            <div id="samedi" class="jourSemaine">
                <h4>Samedi</h4>
                <asp:DataGrid ID="GridSamedi" runat="server" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundColumn DataField="Sport" HeaderText="Sport" />
                        <asp:BoundColumn DataField="Section" HeaderText="Section" />
                        <asp:BoundColumn DataField="Heure" HeaderText="Heure" />
                        <asp:BoundColumn DataField="NomPrenom" HeaderText="Entraineur" />
                    </Columns>
                </asp:DataGrid>
            </div>
        </div>

        <div id="dimanche" class="jourSemaine">
            <h4>Dimanche</h4>
            <asp:DataGrid ID="GridDimanche" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundColumn DataField="Sport" HeaderText="Sport" />
                    <asp:BoundColumn DataField="Section" HeaderText="Section" />
                    <asp:BoundColumn DataField="Heure" HeaderText="Heure" />
                    <asp:BoundColumn DataField="NomPrenom" HeaderText="Entraineur" />
                </Columns>
            </asp:DataGrid>
        </div>



    </div>


    <%--<asp:DataGrid ID="DataGrid" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundColumn DataField="Sport" HeaderText="Sport" />
            <asp:BoundColumn DataField="Section" HeaderText="Section" />
            <asp:BoundColumn DataField="Jour" HeaderText="Jour" />
            <asp:BoundColumn DataField="Heure" HeaderText="Heure" />
            <asp:BoundColumn DataField="NomPrenom" HeaderText="Entraineur" />
        </Columns>
    </asp:DataGrid>--%>
</asp:Content>
