<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CalculoEnvio.aspx.cs" Inherits="UI.CalculoEnvio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script src='http://maps.googleapis.com/maps/api/js?v=3&sensor=false&amp;libraries=places&key=AIzaSyBCJHG-OM17NkmG9kteZWkaMY2mvbY34rQ'></script>


<%--     <script type="text/javascript">
        google.maps.event.addDomListener(window, 'load', function () {
            var places = new google.maps.places.Autocomplete(document.getElementById('FromTxtBx'));
            google.maps.event.addListener(places, 'place_changed', function () {
                var place = places.getPlace();
                var address = place.formatted_address;
                var latitude = place.geometry.location.lat();
                var longitude = place.geometry.location.lng();
                var mesg = "Address: " + address;
                mesg += "\nLatitude: " + latitude;
                mesg += "\nLongitude: " + longitude;
                alert(mesg);
            });
        });
    </script>

    <asp:TextBox runat="server" ID="FromTxtBx" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
--%>


        <script type="text/javascript">
        var source, destination;
        var directionsDisplay;

        var e = document.getElementById("ddlDespacho");

        var directionsService = new google.maps.DirectionsService();
        google.maps.event.addDomListener(window, 'load', function () {
            //new google.maps.places.SearchBox(document.getElementById('txtSource'));
            new google.maps.places.SearchBox(document.getElementById('txtDestination'));
            directionsDisplay = new google.maps.DirectionsRenderer({ 'draggable': true });
        });

        function GetRoute() {
            var mumbai = new google.maps.LatLng(-34.503450, -58.573760);
            var mapOptions = {
                zoom: 7,
                center: mumbai
            };
            map = new google.maps.Map(document.getElementById('dvMap'), mapOptions);
            directionsDisplay.setMap(map);
            directionsDisplay.setPanel(document.getElementById('dvPanel'));

            //*********DIRECTIONS AND ROUTE**********************//
            //source = document.getElementById("txtSource").value;

            var skillsSelect = document.getElementById("ddlDespacho");
            var selectedText = skillsSelect.options[skillsSelect.selectedIndex].text;
            source = selectedText;
            destination = document.getElementById("txtDestination").value;

            var request = {
                origin: source,
                destination: destination,
                travelMode: google.maps.TravelMode.DRIVING
            };
            directionsService.route(request, function (response, status) {
                if (status == google.maps.DirectionsStatus.OK) {
                    directionsDisplay.setDirections(response);
                }
            });

            //*********DISTANCE AND DURATION**********************//
            var service = new google.maps.DistanceMatrixService();
            service.getDistanceMatrix({
                origins: [source],
                destinations: [destination],
                travelMode: google.maps.TravelMode.DRIVING,
                unitSystem: google.maps.UnitSystem.METRIC,
                avoidHighways: false,
                avoidTolls: false
            }, function (response, status) {
                if (status == google.maps.DistanceMatrixStatus.OK && response.rows[0].elements[0].status != "ZERO_RESULTS") {
                    var distance = response.rows[0].elements[0].distance.text;
                    var duration = response.rows[0].elements[0].duration.text;
<%--                    var skillsSelect = document.getElementById("<%= ddlDespacho.%>");;
                    var selectedText = skillsSelect.options[skillsSelect.selectedIndex].text;--%>

                    //var precio = distance.substr(0, distance.length - 2);
                    var precio;
                    var fechaEntrega;
                    var diasestimados;

                    var skillsSelect = document.getElementById("ddlDespacho");
                    var selectedText = skillsSelect.options[skillsSelect.selectedIndex].value;


                    
                    switch (selectedText) {
                        case "0":
                            precio = 85; diasestimados = 3;
                            break;
                        case "1":
                            precio = 90; diasestimados = 4;
                            break;
                        case "2":
                            precio = 95; diasestimados = 4;
                            break;
                        case "3":
                            precio = 100; diasestimados = 5;
                            break;
                        case "4":
                            precio = 110; diasestimados = 6;
                            break;
                        default:
                            precio = 80; diasestimados = 2;
                    }

                    var today = new Date();
                    var dd = today.getDate();
                    var mm = today.getMonth() + 1; //January is 0!
                    var yyyy = today.getFullYear();

                    if (dd < 10) {
                        dd = '0' + dd
                    }

                    if (mm < 10) {
                        mm = '0' + mm
                    }

                    today = mm + '/' + dd + '/' + yyyy;


                    var someFormattedDate = dd + '/' + mm + '/' + yyyy;
                    fechaEntrega = someFormattedDate;

                    var pivotdistance = distance.substr(0, distance.length - 2);
                    var pivot2 = pivotdistance.toFixed;
                    var costoViaje =  pivot2 * precio;
                    var costoTotal = costoViaje.toFixed();

                    var dvDistance = document.getElementById("dvDistance");
                    dvDistance.innerHTML = "";
                    dvDistance.innerHTML += "Distancia: " + distance + "<br />";
                    //dvDistance.innerHTML += "Tiempo estimado: " + duration + "<br />";
                    dvDistance.innerHTML += "Precio del Km: $ " + precio + "<br />";
                    dvDistance.innerHTML += "Costo total: $ " + costoTotal + "<br />";
                    dvDistance.innerHTML += "Fecha estimada de entrega: " + fechaEntrega;


                } else {
                    alert("No es posible calcular la distancia para los lugadres indicados.");
                }
            });
        }
    </script>


    <table border="0" cellpadding="0" cellspacing="3">
        <tr>
            <td colspan="2">
                Seleccione el lugar de despacho:
<%--                <input type="text" id="txtSource" value="Bandra, Mumbai, India" style="width: 200px" />--%>
<%--                <asp:TextBox runat="server" placeholder="Origen" ID="txtSource" CssClass="form-control"  ClientIDMode="Static"></asp:TextBox>--%>
                                <asp:DropDownList ID="ddlDespacho" ClientIDMode="Static" CssClass="form-control" style="width:auto;" runat="server">
                                </asp:DropDownList> 

                &nbsp; Ingrese la dirección de envío:
                <asp:TextBox runat="server" placeholder="Destino" ID="txtDestination" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
<%--                <input type="text" id="txtDestination" value="Andheri, Mumbai, India" style="width: 200px" />--%>
                <br />
                    <input type="button" value="Calcular costo de envío" onclick="GetRoute()" style="width:auto; height: 38px;padding: 8px 12px;font-size: 14px;color: #888888;background-color: #ffffff;border: 1px solid #282828;" />
<%--                <asp:Button runat="server" ID="btnCalcular" ClientIDMode="Static" Text="Obtener Distancia" CssClass="btn btn-default" OnClientClick="GetRoute()" />--%>
                <hr />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <div id="dvDistance">
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <div id="dvMap" style="width: 500px; height: 500px">
                </div>
            </td>
            <td>
                <div id="dvPanel" style="width: 500px; height: 500px; color: #888888;">
                </div>
            </td>
        </tr>
    </table>
    <br />

</asp:Content>
