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
        <asp:Image ImageAlign="Middle" Width="50%" Height="50%"  ImageUrl="http://www.haylugartfi.somee.com/images/logoHL.png" ID="im" runat="server" />
                        <br />
                        <hr />
                            <h4>HAY LUGAR! - Mi reserva</h4>
                        <hr />
                        <br /><p></p>
                    <asp:GridView ID="gvReserva" runat="server" AutoGenerateColumns="False" AllowPaging="true"
                        PageSize="50" CssClass="footable" Align="Center" Width="300px">
                        <Columns> 

                            <asp:BoundField DataField="idReserva" ItemStyle-HorizontalAlign="Center" HeaderText="Identificador de la Reserva" />

                            <asp:BoundField DataField="fechaDesde" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha Desde" />

                            <asp:BoundField DataField="fechaHasta" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha Hasta" />

                            <asp:BoundField DataField="horaDesde" HeaderText="Hora Desde" />

                            <asp:BoundField DataField="horaHasta" HeaderText="Hora Hasta" />


                            <asp:BoundField DataField="tarifa" DataFormatString="{0:F}" HeaderText="Tarifa" />

                            <asp:BoundField DataField="domicilio" HeaderText="Domicilio" />                            

                            
                            <asp:BoundField DataField="UserName" HeaderText="Reservado por" />
                            
                        </Columns>
                    <PagerStyle CssClass="GridView" HorizontalAlign="Center" />
                    </asp:GridView>

    </div>
    </form>
</body>
</html>
