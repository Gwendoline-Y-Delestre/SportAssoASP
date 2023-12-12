<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="VisualiserDocument.aspx.cs" Inherits="SportAssoASP.VisualiserDocument" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:Image ID="ImageViewer" runat="server" />
    </div>
    <div>
        <iframe id="PdfViewer" runat="server" style="width: 100%; height: 600px;" frameborder="0"></iframe>
    </div>
</asp:Content>
