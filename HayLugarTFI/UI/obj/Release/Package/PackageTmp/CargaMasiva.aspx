<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CargaMasiva.aspx.cs" Inherits="UI.CargaMasiva" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <br />

    <div class="row ml-5" >
                    <div class="col-md-2">

    <asp:FileUpload ID="FileUpload1" runat="server" />
                        </div>
        </div>
    <div class="row ml-5" >
                    <div class="col-md-2">
    <asp:Button ID="Button1" Text="Cargar XML" runat="server" OnClick="UploadXML" />
    <asp:Label ID="lblMje" runat="server" Font-Size="X-Large" ForeColor="Green"></asp:Label>
                        </div>
        </div>
    <br /><p></p>
    <br />
    <div class="row ml-5" >
                    <div class="col-md-2">
    <asp:Button runat="server" ID="btnCargaMasivaBack" CssClass="btn btn-secondary" Text="Volver" OnClick="btnCargaMasivaBack_Click"/>
                        </div>
        </div>
    <br /><p></p>

</asp:Content>
