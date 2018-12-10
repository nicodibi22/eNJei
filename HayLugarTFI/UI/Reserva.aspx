<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reserva.aspx.cs" Inherits="UI.Reserva" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Image ImageAlign="Middle" Width="50%" Height="50%"  ImageUrl="http://www.haylugar.somee.com/images/reserva.png" ID="im" runat="server" />
                        <br />
                        <hr />
                            <h4>HAY LUGAR! - Mi reserva</h4>
                        <hr />
                        <br /><p></p>
                    <asp:GridView ID="gvReserva" runat="server" AutoGenerateColumns="False" AllowPaging="true"
                        PageSize="50" CssClass="footable" Align="Center">
                        <Columns> 

                            <asp:BoundField DataField="idPlaza" ItemStyle-HorizontalAlign="Center" HeaderText="Identificador de la Reserva" />

                            <asp:BoundField DataField="descEstacionamiento" HeaderText="Estacionamiento" />

                            <asp:BoundField DataField="calle" HeaderText="Calle" />

                            <asp:BoundField DataField="altura" HeaderText="Altura" />

                            <asp:BoundField DataField="datosAdicionales" HeaderText="Datos adicionales" />

                            <asp:BoundField DataField="descBarrio" HeaderText="Barrio" />

                            <asp:BoundField DataField="UserName" HeaderText="Reservado por" />
                            
                        </Columns>
                    <PagerStyle CssClass="GridView" HorizontalAlign="Center" />
                    </asp:GridView>

    </div>
    </form>
</body>
</html>
