<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ActivacionPendiente.aspx.cs" Inherits="UI.Account.ActivacionPendiente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1><asp:Literal ID="ltMessage" runat="server" Text="Te falta poco! Tu cuenta está pendiente de activación." /></h1>
    <br />
    <h2><asp:Literal ID="Literal1" runat="server" Text="Para activarla, ingresá al link que te enviamos por mail." /></h2>

</asp:Content>
