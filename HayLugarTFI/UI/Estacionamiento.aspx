<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Estacionamiento.aspx.cs" Inherits="UI.Estacionamiento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

            <%-- GV- CSSyJS - INICIO --%>
        <link href="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/css/footable.min.css" rel="stylesheet" type="text/css" />
        <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
        <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/js/footable.min.js"></script>
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
            <asp:UpdatePanel ID="upnlTotal" runat="server">
                <ContentTemplate>
                    <asp:Panel ID="pnlTab1" runat="server">
                        <br />
                        <hr />
                            <h4>Listado de Estacionamientos</h4>
                        <hr />
                        <br />
                        <asp:Button runat="server" ID="btnAgregar" CssClass="btn btn-default" Text="Agregar" OnClick="btnAgregar_Click"/>
                        <br /><p></p>
                        <br />
                        <asp:Button runat="server" ID="btnCargaMasiva" CssClass="btn btn-default" Text="Carga Masiva" OnClick="btnCargaMasiva_Click"/>
                        <br /><p></p>

                        <div>
                    <asp:GridView ID="gvEstacionamiento" runat="server" AutoGenerateColumns="False" AllowPaging="true"
                        PageSize="50" CssClass="footable" Align="Center" OnRowDeleting="gvEstacionamiento_RowDeleting" DataKeyNames="idEstacionamiento" OnPageIndexChanging="gvEstacionamiento_PageIndexChanging" OnRowEditing="gvEstacionamiento_RowEditing">
                        <Columns> 

                            <asp:BoundField DataField="idEstacionamiento" ItemStyle-HorizontalAlign="Center" HeaderText="Identificador del estacionamiento" />

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
							    <h4 id="titleProdAccion" runat="server">Modificar Estacionamiento</h4>
							    <hr />

							    <div class="form-group">
								    <asp:Label runat="server" ID="lblIdEstac" CssClass="col-md-2 control-label">Identificador del estacionamiento</asp:Label>
								    <div class="col-md-10">
									    <asp:TextBox runat="server" Enabled="false" ID="txtIdEstac" size="10" type="number" CssClass="textAreaBoxInputs" />
								    </div>
							    </div>

							    <div class="form-group">
								    <asp:Label runat="server" ID="lblDescripcion" CssClass="col-md-2 control-label">Tarifa</asp:Label>
								    <div class="col-md-10">
									    <asp:TextBox runat="server" ID="txtDescripcion" ValidationGroup="producto" required size="80" CssClass="textAreaBoxInputs" />
								    </div>
							    </div>

							    <div class="form-group">
								    <asp:Label runat="server" ID="lblCalle" CssClass="col-md-2 control-label">Calle</asp:Label>
								    <div class="col-md-10">
									    <asp:TextBox runat="server" ID="txtCalle" ValidationGroup="producto" required size="80" CssClass="textAreaBoxInputs" />
								    </div>
							    </div>


							    <div class="form-group">
								    <asp:Label runat="server" ID="lblAltura" CssClass="col-md-2 control-label">Altura</asp:Label>
								    <div class="col-md-10">
									    <asp:TextBox runat="server" ID="txtAltura" ValidationGroup="producto" required size="80" CssClass="textAreaBoxInputs" />
								    </div>
							    </div>
							    <div class="form-group">
								    <asp:Label runat="server" ID="lblDatosAdicionales" CssClass="col-md-2 control-label">Datos adicionales</asp:Label>
								    <div class="col-md-10">
									    <asp:TextBox runat="server" ID="txtDatosAdicionales" ValidationGroup="producto" required size="80" CssClass="textAreaBoxInputs" />
								    </div>
							    </div>

							    <div class="form-group">
								    <asp:Label runat="server" ID="lblIdBarrio" CssClass="col-md-2 control-label">Zona</asp:Label>
								    <div class="col-md-10">
<%--									    <asp:TextBox runat="server" ID="txtIdBarrio" ValidationGroup="producto" required size="80" CssClass="textAreaBoxInputs" />--%>
                                        <asp:DropDownList ID="ddlBarrios" AutoPostBack="false" runat="server">
                                        </asp:DropDownList> 
								    </div>
							    </div>

							    <div class="form-group">
								    <asp:Label runat="server" ID="lblLatitud" CssClass="col-md-2 control-label">Latitud</asp:Label>
								    <div class="col-md-10">
									    <asp:TextBox runat="server" ID="txtLatitud" ValidationGroup="producto" required size="80" CssClass="textAreaBoxInputs" />
								    </div>
							    </div>

							    <div class="form-group">
								    <asp:Label runat="server" ID="lblLongitud" CssClass="col-md-2 control-label">Longitud</asp:Label>
								    <div class="col-md-10">
									    <asp:TextBox runat="server" ID="txtLongitud" ValidationGroup="producto" required size="80" CssClass="textAreaBoxInputs" />
								    </div>
							    </div>
                <div id="div_tabla21" style="display:none" >
                    <hr />    
                    <table id="tabla21" style="width:100%;border: white 5px solid">
                            <tr>
                            <th style="text-align: left;">
                                <h4>Mapa.</h4><br />
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
                                                <div id="dvMap" style="width: 100%; height: 500px">
                                                </div>
                                    <asp:Label ID="lblErrorMapa" runat="server" Visible="false" ForeColor="Red" Font-Bold="true" Text="No se ha podido cargar el mapa. Verifique su dirección"></asp:Label>
                                </div>
			                </th>
                            </tr>
                        </table>
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
                                    <asp:Button ID="btnConfirmar" CssClass="btn btn-default" ValidationGroup="producto"  runat="server" Text=" : Confirmar :" OnClick="btnConfirmar_Click"/>
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

</asp:Content>
