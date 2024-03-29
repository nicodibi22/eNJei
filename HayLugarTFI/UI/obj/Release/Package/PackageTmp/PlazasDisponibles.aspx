﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PlazasDisponibles.aspx.cs" Inherits="UI.PlazasDisponibles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />

        <br />
                        <hr />
                            <h4 >Plazas Disponibles</h4>
                        <hr />
                        <br />
                <div class="row" >
                    <div class="col-md-2">
                        <asp:Label ID="lblTipoAlquiler" Text="Tipo Alquiler" runat="server"></asp:Label>
                        <asp:DropDownList ID="ddlTipoAlquiler" runat="server" AutoPostBack="true"  CssClass="form-control" OnSelectedIndexChanged="ddlTipoAlquiler_SelectedIndexChanged" >
                            <asp:ListItem Text="" Value=""></asp:ListItem>
                            <asp:ListItem Text="Diario" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Hora" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div id="divDiario" runat="server" visible="false">
                        <div class="col-md-2">
                            <asp:Label ID="lblFechaDesde" Text="Fecha Desde" runat="server"></asp:Label>
                            <asp:TextBox ID="txtFechaDesde" runat="server" type="date" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <asp:Label ID="lblFechaHasta" Text="Fecha Hasta" runat="server"></asp:Label>
                            <asp:TextBox ID="txtFechaHasta" runat="server" type="date" CssClass="form-control"></asp:TextBox>
                        </div>
            
                    </div>
                    <div id="divHora" runat="server" visible="false">
                        <div class="col-md-2">
                            <asp:Label ID="lblFecha" Text="Fecha" runat="server"></asp:Label>
                            <asp:TextBox ID="txtFecha" runat="server" type="date" CssClass="form-control"></asp:TextBox>
                        </div>
            
                    </div>       
                    <div class="col-md-2">
                        <asp:Label ID="lblZona" Text="Zona" runat="server"></asp:Label>
                        <asp:DropDownList ID="ddlZona" runat="server" CssClass="form-control" DataValueField="idZona" DataTextField="descripcion"></asp:DropDownList>
                    </div>
                    <div class="col-md-1">
                        <asp:Label ID="lblNada" Text="......"  ForeColor="White" runat="server"></asp:Label>
                        <asp:Button runat="server" ID="btnFiltrar" CssClass="btn btn-warning" Text="Filtrar" OnClick="btnFiltrar_Click"/>
                    </div>
                    
                </div>
            
        
        
        
        
        <br />
        <div style="margin-left:15px">
            <asp:Button runat="server" ID="btnReservar" CssClass="btn btn-success" Text="Reservar Plaza" OnClick="btnReservar_Click" />
        </div>
        
        <br /><p></p>

                        <br/><%-- Datos de contacto--%>
                <div id="div_tabla21">
                        <table id="tabla21" style="width:100%;border: white 5px solid">
                            <tr>
                            <th style="text-align: left;">
                                <br />
                                <asp:Label ID="lblErrorMapa" runat="server" Visible="false" ForeColor="Red" Font-Bold="true" Text="No se ha podido cargar el mapa. Verifique su dirección"></asp:Label>
                                <span>
                                    <img src="http://maps.google.com/mapfiles/ms/icons/red.png" /> <asp:Label runat="server" ID="lblEstadiaDia" Text="Estadía Diaria"></asp:Label>
                                </span>
                                <span>
                                    <img src="http://maps.google.com/mapfiles/ms/icons/blue.png" /> <asp:Label runat="server" ID="Label1" Text="Estadía por Hora"></asp:Label>
                                </span>
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
                                                                        + '<%# Eval("calle") %>' + " " + '<%# Eval("altura") %>' + "\n" + '<%# Eval("SegmentosDisp") %>',
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
