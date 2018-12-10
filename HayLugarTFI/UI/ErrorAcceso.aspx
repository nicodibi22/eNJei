<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ErrorAcceso.aspx.cs" Inherits="UI.ErrorAcceso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
                        <br />
                        <hr />
                            <h4>Acceso no permitido.</h4>
                        <hr />
                        <br />
                             <h5>Usted no tiene acceso a esta página </h5>
                        <br />
                        <div class="form-horizontal">
                            <img src="images/AccesoRestringido.jpg" />
                        </div>
                        <br /><br />                            
                        <div class="form-group">
							<div class="col-md-10">
                                <asp:Button ID="btnVolver" CssClass="btn btn-default" runat="server" Text=" : Volver :" OnClick="btnVolver_Click" />
                            </div>
                        </div>
</asp:Content>
