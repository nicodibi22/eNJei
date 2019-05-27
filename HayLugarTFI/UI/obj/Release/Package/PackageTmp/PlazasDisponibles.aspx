<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PlazasDisponibles.aspx.cs" Inherits="UI.PlazasDisponibles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

        <h2>Plazas disponibles</h2>

        <br />
        <asp:Button runat="server" ID="btnReservar" CssClass="btn btn-default" Text="Reservar Plaza" OnClick="btnReservar_Click"/>
        <br /><p></p>

                        <br/><%-- Datos de contacto--%>
                <div id="div_tabla21">
                        <table id="tabla21" style="width:100%;border: white 5px solid">
                            <tr>
                            <th style="text-align: left;">
                                <h4>Mapa.</h4><br />
                                <asp:Label ID="lblErrorMapa" runat="server" Visible="false" ForeColor="Red" Font-Bold="true" Text="No se ha podido cargar el mapa. Verifique su dirección"></asp:Label>
                                <div id="divShowMapa">
                                    <script src="https://maps.googleapis.com/maps/api/js?sensor=false&amp;libraries=places&key=AIzaSyBCJHG-OM17NkmG9kteZWkaMY2mvbY34rQ"
                                                        type="text/javascript">
                                    </script>
                                                <script type="text/javascript">
                                                    var markers = [
		                                            <asp:Repeater ID="rptMarkers" runat="server">
		                                            <ItemTemplate>
				                                                {
				                                                    "title": "Precio: $ " + '<%# Eval("descripcion") %>' + "\nDirección: "
                                                                        + '<%# Eval("calle") %>' + " " + '<%# Eval("altura") %>',
				                                                    "lat": '<%# Eval("latitud") %>',
				                                                    "lng": '<%# Eval("longitud") %>',
                                                                    "description": '<%# Eval("datosAdicionales") %>',
				                                                    "type": '<%# Eval("idTipoEstadia") %>'
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
                                                            zoom: 12,
                                                            mapTypeId: google.maps.MapTypeId.ROADMAP
                                                        };
                                                        var infoWindow = new google.maps.InfoWindow();
                                                        var map = new google.maps.Map(document.getElementById("dvMap"), mapOptions);
                                                        for (i = 0; i < markers.length; i++) {
                                                            var data = markers[i]
                                                            var myLatlng = new google.maps.LatLng(data.lat, data.lng);
                                                            var icon = "";
                                                            switch (data.type) {
                                                                case "1":
                                                                    icon = "red";
                                                                    break;
                                                                case "2":
                                                                    icon = "blue";
                                                                    break;
                                                                case "3":
                                                                    icon = "yellow";
                                                                    break;
                                                                case "4":
                                                                    icon = "green";
                                                                    break;
                                                            }
                                                            icon = "http://maps.google.com/mapfiles/ms/icons/" + icon + ".png";
                                                            var marker = new google.maps.Marker({
                                                                position: myLatlng,
                                                                map: map,
                                                                title: data.title,
                                                                animation: google.maps.Animation.DROP,
                                                                icon: new google.maps.MarkerImage(icon)
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
