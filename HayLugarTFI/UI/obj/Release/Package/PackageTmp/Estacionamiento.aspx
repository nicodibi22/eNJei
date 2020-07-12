<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Estacionamiento.aspx.cs" Inherits="UI.Estacionamiento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

            <%-- GV- CSSyJS - INICIO --%>
        <link href="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/css/footable.min.css" rel="stylesheet" type="text/css" />
        <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
        <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/js/footable.min.js"></script>
    <script src="js/jquery-1.10.2.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/bootstrap-dialog.min.js"></script>

    <style>
        .form-control {
            width:80%;
        }
    </style>

        <script type="text/javascript">
            $(function () {
                $('[id*=gvEstacionamiento]').footable();
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
                    $('[id*=gvEstacionamiento]').footable();
                });
            });
        </script>


    <br />

        <div id="tabs-1">
            <br />
            <asp:UpdatePanel ID="upnlTotal" runat="server" ChildrenAsTriggers="true" UpdateMode="conditional">
                <ContentTemplate>

                    <asp:Panel runat="server" id="divEliminado" class="alert alert-warning alert-dismissible fade show" role="alert" Width="75%" >
      <asp:Label runat="server" ID="lblPlazasHora" CssClass="alert alert-warning alert-dismissable" Text="Registro eliminado."></asp:Label>
    </asp:Panel>

                    <asp:Panel ID="pnlTab1" runat="server">
                        <br />
                        <hr />
                            <h4>Listado de Estacionamientos</h4>
                        <hr />
                        <br />
                        <div class="row" >
                    <div class="col-md-2">
                        <asp:Button runat="server" ID="btnAgregar" CssClass="btn btn-secondary" Text="Agregar" OnClick="btnAgregar_Click"/>
                        <br /><p></p>
                        <br />
                        <asp:Button runat="server" ID="btnCargaMasiva" CssClass="btn btn-secondary" Text="Carga Masiva" OnClick="btnCargaMasiva_Click"/>
                        <br /><p></p>
                        </div>
                            </div>
                        <div>
                    <asp:GridView ID="gvEstacionamiento" runat="server" AutoGenerateColumns="False" AllowPaging="true"
                        PageSize="50" CssClass="footable" Align="Center" DataKeyNames="idEstacionamiento" OnPageIndexChanging="gvEstacionamiento_PageIndexChanging" OnRowEditing="gvEstacionamiento_RowEditing"
                        OnRowCommand="gvEstacionamiento_RowCommand" OnRowDataBound="gvEstacionamiento_RowDataBound">
                        <Columns> 

                            <asp:BoundField DataField="idEstacionamiento" ItemStyle-HorizontalAlign="Center" HeaderText="Identificador del estacionamiento" />
                            <asp:BoundField DataField="TipoEstadia" ItemStyle-HorizontalAlign="Center" HeaderText="Tipo Alquiler" />
<%--                            <asp:BoundField DataField="descripcion" HeaderText="Tarifa" />--%>
                            <asp:TemplateField  HeaderText = "Tarifa" ItemStyle-HorizontalAlign="Right">
                                <ItemTemplate>
                                    <asp:Label ID="lblDescripcion" style="width: 45px;" Text='<%# String.Format("${0:n2}", Convert.ToDecimal( Eval("descripcion"))) %>' runat="server" ></asp:Label>
                                </ItemTemplate>                    
                            </asp:TemplateField>                            

                            <asp:BoundField DataField="calle" HeaderText="Calle" />
                            
                            <asp:BoundField DataField="altura" HeaderText="Altura" />

                            <asp:BoundField DataField="datosAdicionales" HeaderText="Datos adicionales" />

                            <asp:BoundField DataField="zonaDesc" HeaderText="Zona" />

                            <asp:BoundField DataField="latitud" HeaderText="Latitud" />

                            <asp:BoundField DataField="longitud" HeaderText="Longitud" />

                            <asp:BoundField DataField="idBarrio" HeaderText="Id Zona" />

                            <asp:CommandField HeaderText="Modificar" EditText="Modificar" ShowEditButton="true" ShowCancelButton="false" />
                            

                            <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkDelete" runat="server"
                             CssClass=""                              
                            Text="Eliminar" CommandArgument='<%# Eval("idEstacionamiento") %>' CommandName="Delete" ></asp:LinkButton>
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
                         <div class="row">
                            <div class="col-xs-12 col-sm-12 col-md-6 col-lg-6">
							    <hr />
							    <h4 id="titleProdAccion" runat="server">Modificar Estacionamiento</h4>
							    <hr />

							    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
								    <asp:Label runat="server" ID="lblIdEstac" CssClass="col-md-2 control-label">ID</asp:Label>
								    
									    <asp:TextBox runat="server" Enabled="false" ID="txtIdEstac" size="10" Width="80px" type="number" CssClass="form-control" />
								    
							    </div>
                                <br />
                                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
								    <asp:Label runat="server" ID="lblTipoAlquiler" CssClass="col-md-2 control-label">Tipo Alquiler</asp:Label>
								    
<%--									    <asp:TextBox runat="server" ID="txtIdBarrio" ValidationGroup="producto" required size="80" CssClass="textAreaBoxInputs" />--%>
                                        <asp:DropDownList ID="ddlTipoAlquiler" AutoPostBack="false" runat="server" CssClass="form-control">
                                        </asp:DropDownList> 
								    
							    </div>
                                <br />
							    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
								    <asp:Label runat="server" ID="lblDescripcion" CssClass="col-md-2 control-label">Tarifa</asp:Label>
								    
									    <asp:TextBox runat="server" ID="txtDescripcion" ValidationGroup="producto" required size="80" type="number" min="1" step="0.1" CssClass="form-control" />
								    
							    </div>
                                <br />
							    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
								    <asp:Label runat="server" ID="lblCalle" CssClass="col-md-2 control-label">Calle</asp:Label>
								    
									    <asp:TextBox runat="server" ID="txtCalle" ValidationGroup="producto" required size="80" CssClass="form-control" />
								    
							    </div>

                                <br />
							    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
								    <asp:Label runat="server" ID="lblAltura" CssClass="col-md-2 control-label">Altura</asp:Label>
								    
									    <asp:TextBox runat="server" ID="txtAltura" ValidationGroup="producto" required size="80" CssClass="form-control" Width="200px" />
								    
							    </div>
                                <br />
							    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
								    <asp:Label runat="server" ID="lblDatosAdicionales" CssClass="col-md-2 control-label">Datos adicionales</asp:Label>
								    
									    <asp:TextBox runat="server" ID="txtDatosAdicionales" ValidationGroup="producto" required size="80" CssClass="form-control" />
								    
							    </div>
                                <br />
							    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
								    <asp:Label runat="server" ID="lblIdBarrio" CssClass="col-md-2 control-label">Zona</asp:Label>
								    
<%--									    <asp:TextBox runat="server" ID="txtIdBarrio" ValidationGroup="producto" required size="80" CssClass="textAreaBoxInputs" />--%>
                                        <asp:DropDownList ID="ddlBarrios" AutoPostBack="false" runat="server" CssClass="form-control">
                                        </asp:DropDownList> 
								    
							    </div>
                                <br />
							    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
								    <asp:Label runat="server" ID="lblLatitud" CssClass="col-md-2 control-label">Latitud</asp:Label>
								    
									    <asp:TextBox runat="server" ID="txtLatitud" ValidationGroup="producto" required size="80" CssClass="form-control" />
								    
							    </div>
                                <br />
							    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
								    <asp:Label runat="server" ID="lblLongitud" CssClass="col-md-2 control-label">Longitud</asp:Label>
								    
									    <asp:TextBox runat="server" ID="txtLongitud" ValidationGroup="producto" required size="80" CssClass="form-control" />
								    
							    </div>
                            </div>
                <div class="col-xs-12 col-sm-12 col-md-6 col-lg-6">
                    
                                <br />  
                                <div id="divShowMapa">
                                    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBCJHG-OM17NkmG9kteZWkaMY2mvbY34rQ"
                                                        type="text/javascript">
                                    </script>
                                                <script type="text/javascript">
                                                    var markers = [
		                                            <asp:Repeater ID="rptMarkers" runat="server">
		                                            <ItemTemplate>
				                                                {
				                                                    "title": '<%# Eval("Name") %>',
				                                                    "lat": '<%# Eval("Latitude") %>',
				                                                    "lng": '<%# Eval("Longitude") %>',
				                                                    "description": '<%# Eval("Description") %>'
				                                                }
		                                            </ItemTemplate>
		                                            <SeparatorTemplate>
			                                            ,
		                                            </SeparatorTemplate>
		                                            </asp:Repeater>
                                                    ];
                                                </script>
                                                <script type="text/javascript">

                                                    window.onload = function () {
                                                        var mapOptions = {
                                                            center: new google.maps.LatLng(markers[0].lat, markers[0].lng),
                                                            zoom: 16,
                                                            mapTypeId: google.maps.MapTypeId.ROADMAP
                                                        };
                                                        var infoWindow = new google.maps.InfoWindow();
                                                        var map = new google.maps.Map(document.getElementById("dvMap"), mapOptions);
                                                        for (i = 0; i < markers.length; i++) {
                                                            var data = markers[i]
                                                            var myLatlng = new google.maps.LatLng(data.lat, data.lng);
                                                            var marker = new google.maps.Marker({
                                                                position: myLatlng,
                                                                map: map,
                                                                title: data.title
                                                            });
                                                            (function (marker, data) {
                                                                google.maps.event.addListener(marker, "click", function (e) {
                                                                    infoWindow.setContent(data.description);
                                                                    infoWindow.open(map, marker);
                                                                });
                                                            })(marker, data);
                                                        }
                                                    }
                                                </script>
                                                <div id="dvMap" style="width: 100%; height: 400px">
                                                </div>
                                    
                                </div>
                                
			                
                            
                </div>

                        </div>
                    </asp:Panel>
                </ContentTemplate>
                
            </asp:UpdatePanel>
             <div ID="divBotones" style="display:none">            
            <br /><br />
            <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>
                 <asp:Label ID="lblErrorMapa" runat="server" Visible="false" ForeColor="Red" Font-Bold="true" Text="No se ha podido cargar el mapa. Verifique su dirección"></asp:Label>
                            <br /><br />
                            
                            <div class="form-group">
							    <div class="col-md-10">
                                    <asp:Button ID="btnCancelar" CssClass="btn btn-danger" formnovalidate runat="server" Text=" : Cancelar : " OnClick="btnCancelar_Click" />
                                    <asp:Button ID="btnActualizarMapa" CssClass="btn btn-warning" formnovalidate runat="server" Text=" : Actualizar Mapa : " OnClick="btnActualizarMapa_Click" />
                                    <asp:Button ID="btnConfirmar" CssClass="btn btn-success" ValidationGroup="producto"  runat="server" Text=" : Confirmar :" OnClick="btnConfirmar_Click"/>
                                </div>
                            </div>                        
                        <br />
                    </div>            
        </div>



        <asp:GridView ID="GridView1" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
            runat="server"  Visible="false" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" />
                <asp:BoundField DataField="Address" HeaderText="Address" />
                <asp:BoundField DataField="Latitude" HeaderText="Latitude" />
                <asp:BoundField DataField="Longitude" HeaderText="Longitude" />
            </Columns>
        </asp:GridView>
        <input type="hidden" id="hiddenRow" runat="server" />
    <script>



        function popup(lnk, id, Name) {

            var div = document.getElementById('MainContent_hiddenRow');
            div.value = id;
            
            BootstrapDialog.confirm({
                title: 'WARNING',
                message: '¿Seguro desea eliminar el registro con ID <b>'+id+'</b>?',
                type: BootstrapDialog.TYPE_WARNING, // <-- Default value is BootstrapDialog.TYPE_PRIMARY
                closable: true, // <-- Default value is false
                draggable: true, // <-- Default value is false
                btnCancelLabel: 'Cancel', // <-- Default value is 'Cancel',
                btnOKLabel: 'Ok', // <-- Default value is 'OK',
                btnOKClass: 'btn-warning', // <-- If you didn't specify it, dialog type will be used,
                callback: function (result) {
                    // result will be true if button was click, while it will be false if users close the dialog directly.
                    if (result) {
                        javascript: __doPostBack('ctl00$MainContent$gvEstacionamiento$ctl02$lnkDelete', '');
                        //__doPostBack('<%=upnlTotal.ClientID%>', '');
                    } else {
                        BootstrapDialog.closeAll();
                    }
                }
            });

        }


        </script>

</asp:Content>
