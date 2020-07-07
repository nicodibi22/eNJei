<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Zona.aspx.cs" Inherits="UI.Zona" %>
<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

            <%-- GV- CSSyJS - INICIO --%>
        <link href="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/css/footable.min.css" rel="stylesheet" type="text/css" />
        <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
        <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/js/footable.min.js"></script>
    <script src="js/jquery-1.10.2.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/bootstrap-dialog.min.js"></script>
        <script type="text/javascript">
            $(function () {
                $('[id*=gvZona]').footable();
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
        
<style>
        
        .MessagePanel
        {
            
            width:55%;
            z-index:1000;
        }
    
    </style>
        <div id="tabs-1">
            <br />
            <asp:UpdatePanel ID="upnlTotal" runat="server" >
                <ContentTemplate>

                    <asp:Panel runat="server" id="divHora" class="alert alert-warning alert-dismissible fade show" role="alert" Width="75%" >
      <asp:Label runat="server" ID="lblPlazasHora" CssClass="alert alert-warning alert-dismissable" Text="Registro eliminado."></asp:Label>
    </asp:Panel>

                    <asp:Panel ID="pnlTab1" runat="server">
                        <br />
                        <hr />
                            <h4>ABM Zonas</h4>
                        <hr />
                        <br />
                        <div class="row" >
                    <div class="col-md-2">
                        <asp:Button runat="server" ID="btnAgregar" CssClass="btn btn-secondary" Text="Agregar" OnClick="btnAgregar_Click"/>
                        </div>
                            </div>
                        <br /><p></p>
                        <div>
                    <asp:GridView ID="gvZona" runat="server" AutoGenerateColumns="False" AllowPaging="true"
                        PageSize="50" CssClass="footable" Align="Center" OnRowDeleted="gvZona_RowDeleted" DataKeyNames="idZona"  OnPageIndexChanging="gvZona_PageIndexChanging" OnRowEditing="gvZona_RowEditing"
                        OnRowCommand="gvZona_RowCommand" OnRowDeleting="gvZona_RowDeleting" OnRowDataBound="gvZona_RowDataBound">
                        <Columns> 

                            <asp:BoundField DataField="idZona" ItemStyle-HorizontalAlign="Center" HeaderText="Id Zona" />

                            <asp:BoundField DataField="descripcion" HeaderText="Nombre" />

                            <asp:BoundField DataField="direccion" HeaderText="Detalle" />
                            <asp:BoundField DataField="precioKm" HeaderText="Precio KM" />
                            
                            <asp:CommandField HeaderText="Modificar" EditText="Modificar" ShowEditButton="true" ShowCancelButton="false" />
                            <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkDelete" runat="server"
                             CssClass=""                              
                            Text="Eliminar" CommandArgument='<%# Eval("idZona") %>' CommandName="Delete" ></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>

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
								    <asp:Label runat="server" ID="lblIdZona" CssClass="col-md-2 control-label">Identificador de la zona</asp:Label>
								    <div class="col-md-1">
									    <asp:TextBox runat="server" Enabled="false" ID="txtIdZona" size="10" CssClass="form-control" />
								    </div>
							    </div>

							    <div class="form-group">
								    <asp:Label runat="server" ID="lblDescripcion" CssClass="col-md-2 control-label">Descripción</asp:Label>
								    <div class="col-md-10">
									    <asp:TextBox runat="server" ID="txtDescripcion" ValidationGroup="producto" required size="80" CssClass="form-control" />
								    </div>
							    </div>

							    <div class="form-group">
								    <asp:Label runat="server" ID="lblDireccion" CssClass="col-md-2 control-label">Dirección</asp:Label>
								    <div class="col-md-10">
									    <asp:TextBox runat="server" ID="txtDireccion" ValidationGroup="producto" required size="80" CssClass="form-control" />
								    </div>
							    </div>
                                <div class="form-group">
								    <asp:Label runat="server" ID="lblPrecio" CssClass="col-md-2 control-label">Precio KM</asp:Label>
								    <div class="col-md-2">
									    <asp:TextBox runat="server" ID="txtPrecio" ValidationGroup="producto" required type="number" size="80" CssClass="form-control" />
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
                                    <asp:Button ID="btnCancelar" CssClass="btn btn-danger" formnovalidate runat="server" Text=" : Cancelar : " OnClick="btnCancelar_Click" />
                                    <asp:Button ID="btnConfirmar" CssClass="btn btn-success" ValidationGroup="producto"  runat="server" Text=" : Confirmar :" OnClick="btnConfirmar_Click" />
                                </div>
                            </div>                        
                        <br />
                    </div>            
        </div>
    <input type="hidden" id="hiddenRow" runat="server" />
    <script>



        function popup(lnk, id, Name) {

            var div = document.getElementById('MainContent_hiddenRow');
            div.value = id;

            BootstrapDialog.confirm({
                title: 'WARNING',
                message: '¿Seguro desea eliminar el registro con ID <b>' + id + '</b>?',
                type: BootstrapDialog.TYPE_WARNING, // <-- Default value is BootstrapDialog.TYPE_PRIMARY
                closable: true, // <-- Default value is false
                draggable: true, // <-- Default value is false
                btnCancelLabel: 'Cancel', // <-- Default value is 'Cancel',
                btnOKLabel: 'Ok', // <-- Default value is 'OK',
                btnOKClass: 'btn-warning', // <-- If you didn't specify it, dialog type will be used,
                callback: function (result) {
                    // result will be true if button was click, while it will be false if users close the dialog directly.
                    if (result) {
                        javascript: __doPostBack('ctl00$MainContent$gvZona$ctl02$lnkDelete', '');
                        //__doPostBack('<%=upnlTotal.ClientID%>', '');
                        
                    } else {
                        BootstrapDialog.closeAll();
                    }
                }
            });

        }


        </script>
</asp:Content>
