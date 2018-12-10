<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="UI.ErrorPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div align="center">
            <br /> 
            <br /> 
            <asp:Image ID="imgError" ImageUrl="https://cdn4.iconfinder.com/data/icons/pretty_office_3/256/remove-from-database.png" ImageAlign="TextTop"  runat="server" />
            <p style="font-size:x-large; align-items:center;">Se ha generado un error al conectarse a la base de datos.</p>
            <br /> 
            <p style="font-size:x-large; align-items:center;">Por favor, intentalo nuevamente más tarde.</p>
        </div>
</asp:Content>
