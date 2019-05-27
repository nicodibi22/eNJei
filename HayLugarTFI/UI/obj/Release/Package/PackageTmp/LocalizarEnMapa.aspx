<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LocalizarEnMapa.aspx.cs" Inherits="UI.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Localizar en el mapa</h2>
    <h3>Ingresa la dirección del estacionamiento para localizarlo en el mapa.</h3>
                  <div id="div_tabla2">
                        <table id="tabla2" style="width:100%;border: white 5px solid">
                            <tr>
                            <th style="text-align: left;">
                                <hr />
                                <h4>Domicilio del estacionamiento.</h4>
				                <hr />		
				                <div class="form-group">
					                <asp:Label runat="server" ID="lblDomicilio" CssClass="col-md-2 control-label">Domicilio</asp:Label>
					                <div class="col-md-10">
						                <asp:TextBox runat="server" required ID="txtDomicilio" size="30" CssClass="form-control" />
					                </div>
				                </div>

				                <div class="form-group">
					                <asp:Label runat="server" ID="lblPisoDpto" CssClass="col-md-2 control-label">Piso-Dpto</asp:Label>
					                <div class="col-md-10">
						                <asp:TextBox runat="server" ID="txtPisoDpto" size="30" CssClass="form-control" />
					                </div>
				                </div>

				                <div class="form-group">
					                <asp:Label runat="server" ID="lblLocalidad" CssClass="col-md-2 control-label">Localidad</asp:Label>
					                <div class="col-md-10">
						                <asp:TextBox runat="server" required ID="txtLocalidad" size="30" CssClass="form-control" />
					                </div>
				                </div>
				
				                <div class="form-group">
					                <asp:Label runat="server" ID="lblProvincia" CssClass="col-md-2 control-label">Provincia</asp:Label>
					                <div class="col-md-10">
						                <asp:TextBox runat="server" required ID="txtProvincia" size="30" CssClass="form-control" />
					                </div>
				                </div>			

				                <div class="form-group">
					                <asp:Label runat="server" ID="Label1" CssClass="col-md-2 control-label"></asp:Label>
				                </div>			

                            </th>
                            </tr>
                        </table>

                    <br /><br />
                </div>

                        <br />
                <asp:Button ID="btnCargarMapa" CssClass="btn btn-default" runat="server" Text="Cargar Mapa" OnClick="btnCargarMapa_Click"  />
  

                        <br/><%-- Datos de contacto--%>
                <div id="div_tabla21">
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

<%--            </div>--%>



    <br />
  

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
