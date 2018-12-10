<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CargaMasiva.aspx.cs" Inherits="UI.CargaMasiva" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:FileUpload ID="FileUpload1" runat="server" />
    <asp:Button ID="Button1" Text="Cargar XML" runat="server" OnClick="UploadXML" />
    <asp:Label ID="lblMje" runat="server" Font-Size="X-Large" ForeColor="Green"></asp:Label>

    <br /><p></p>
    <br />
    <asp:Button runat="server" ID="btnCargaMasivaBack" CssClass="btn btn-default" Text="Volver" OnClick="btnCargaMasivaBack_Click"/>
    <br /><p></p>

</asp:Content>
