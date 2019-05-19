<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="UI.Usuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

                <%-- GV- CSSyJS - INICIO --%>
        <link href="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/css/footable.min.css" rel="stylesheet" type="text/css" />
        <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
        <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/js/footable.min.js"></script>
        <script type="text/javascript">
            $(function () {
                $('[id*=gvUsuario]').footable();
            });
        </script>
    <%-- GV- CSSyJS - FIN --%>


    <%--<script src="js/myJS.js" type="text/javascript"></script>--%>
    
    <script type="text/javascript">
        function mostrar() {

            div = document.getElementById('divBotones');
            div.style.display = '';
        }
    </script>
        <script type="text/javascript">
            var prm = Sys.WebForms.PageRequestManager.getInstance();
            prm.add_endRequest(function () {
                $(function () {
                    $('[id*=gvUsuario]').footable();
                });
            });
        </script>

        <div id="tabs-1">
            <br />
            <asp:UpdatePanel ID="upnlTotal" runat="server">
                <ContentTemplate>
                    <asp:Panel ID="pnlTab1" runat="server">
                        <br />
                        <hr />
                            <h4>Listado de Sucursales</h4>
                        <hr />
                        <br />
                        <asp:Button runat="server" ID="btnAgregar" CssClass="btn btn-default" Text="Agregar" OnClick="btnAgregar_Click"/>
                        <br /><p></p>
                        <div>
                    <asp:GridView ID="gvUsuario" runat="server" AutoGenerateColumns="False" AllowPaging="true"
                        PageSize="50" CssClass="footable" Align="Center" OnRowDeleting="gvUsuario_RowDeleting" DataKeyNames="idUsr"  OnPageIndexChanging="gvUsuario_PageIndexChanging" OnRowEditing="gvUsuario_RowEditing">
                        <Columns> 

                            <asp:BoundField DataField="idUsr" ItemStyle-HorizontalAlign="Center" HeaderText="Identificador del Usuario" />
                            <asp:BoundField DataField="apellido" HeaderText="Apellido" />
                            <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="tipoDoc" HeaderText="Tipo Documento" />
                            <asp:BoundField DataField="nroDoc" HeaderText="Nro. Documento" />
                            <asp:BoundField DataField="email" HeaderText="Email" />
                            <asp:BoundField DataField="telefono" HeaderText="Teléfono" />
                            
                            
                            <asp:CommandField HeaderText="Modificar" EditText="Modificar" ShowEditButton="true" ShowCancelButton="false" />
                            <asp:CommandField HeaderText="Eliminar" EditText="Eliminar" ShowEditButton="false" ShowDeleteButton="true" />

                        </Columns>
                    <PagerStyle CssClass="GridView" HorizontalAlign="Center" />
                    </asp:GridView>
                        </div>
                        <br />
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

    	<div id="tabs-2">
            <br />
            <asp:UpdatePanel ID="upnlTotal2" runat="server" >
                <ContentTemplate>
                    <asp:Panel ID="pnlTab2" Visible="false" runat="server">
                        <br />
                        <div class="form-horizontal">
							    <hr />
							    <h4 id="titleProdAccion" runat="server">Modificar Zona</h4>
							    <hr />

							    <div class="form-group">
								    <asp:Label runat="server" ID="lblUsuarioId" CssClass="col-md-2 control-label">Identificador del usuario</asp:Label>
								    <div class="col-md-10">
									    <asp:TextBox runat="server" Enabled="false" ID="txtUsuarioId" size="50" CssClass="textAreaBoxInputs" />
								    </div>
							    </div>

                                <div class="form-group">
								    <asp:Label runat="server" ID="lblApellido" CssClass="col-md-2 control-label">Apellido</asp:Label>
								    <div class="col-md-10">
									    <asp:TextBox runat="server" ID="txtApellido" ValidationGroup="producto" required size="50"  />
								    </div>
							    </div>
							    <div class="form-group">
								    <asp:Label runat="server" ID="lblNombre" CssClass="col-md-2 control-label">Nombre</asp:Label>
								    <div class="col-md-10">
									    <asp:TextBox runat="server" ID="txtNombre" ValidationGroup="producto" required size="50"  />
								    </div>
							    </div>
                                
                                <div class="form-group">
								    <asp:Label runat="server" ID="lblTipoDocumento" CssClass="col-md-2 control-label">Tipo Documento</asp:Label>
								    <div class="col-md-10">
									    <asp:DropDownList runat="server" ID="ddlTipoDocumento" ValidationGroup="producto" required   >
                                            <asp:ListItem Text="DNI" Value="DNI"></asp:ListItem>
									    </asp:DropDownList>
								    </div>
							    </div>

                                <div class="form-group">
								    <asp:Label runat="server" ID="lblNumeroDocumento" CssClass="col-md-2 control-label">Nro. Documento</asp:Label>
								    <div class="col-md-10">
									    <asp:TextBox runat="server" ID="txtNroDocumento" ValidationGroup="producto" required size="8"  />
								    </div>
							    </div>

							    <div class="form-group">
								    <asp:Label runat="server" ID="lblDireccion" CssClass="col-md-2 control-label">Dirección</asp:Label>
								    <div class="col-md-10">
									    <asp:TextBox runat="server" ID="txtDireccion" ValidationGroup="producto" required size="200" CssClass="textAreaBoxInputs" />
								    </div>
							    </div>

                        </div>
                    </asp:Panel>
                </ContentTemplate>
                
            </asp:UpdatePanel>
             <div ID="divBotones" style="display:none">            
            <br /><br />
            <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>

                            <br /><br />
                            
                            <div class="form-group">
							    <div class="col-md-10">
                                    <asp:Button ID="btnCancelar" CssClass="btn btn-default" formnovalidate runat="server" Text=" : Cancelar : " OnClick="btnCancelar_Click" />
                                    <asp:Button ID="btnConfirmar" CssClass="btn btn-default" ValidationGroup="producto"  runat="server" Text=" : Confirmar :" OnClick="btnConfirmar_Click" />
                                </div>
                            </div>                        
                        <br />
                    </div>            
        </div>

</asp:Content>
