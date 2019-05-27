<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CargaMasivaUsuario.aspx.cs" Inherits="UI.CargaMasivaUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <hr />
        <h4>Carga Masiva de Usuarios</h4>
    <hr />
    <br />

    <asp:FileUpload ID="FileUpload1" runat="server" />
    <asp:Button ID="Button1" Text="Cargar CSV" runat="server" OnClick="UploadArchivo" />
    <asp:Label ID="lblMje" runat="server" Font-Size="X-Large" ForeColor="Green"></asp:Label>

    

    <br /><p></p>
    <asp:TextBox TextMode="MultiLine" Rows="10" Width="750" runat="server" ID="txtResultado"></asp:TextBox>
    <br />
    <br />
    <asp:Button runat="server" ID="btnCargaMasivaBack" CssClass="btn btn-default" Text="Volver" OnClick="btnCargaMasivaBack_Click"/>
    <br /><p></p>

</asp:Content>

