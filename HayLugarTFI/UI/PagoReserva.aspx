<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PagoReserva.aspx.cs" Inherits="UI.PagoReserva" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="css/jquery-ui.css" rel="stylesheet" />
    <script type="text/javascript"  src="js/jquery.min.js"></script>
    <script src="js/jquery-ui.js"></script>

        <script type="text/javascript">
            function ShowPopup(message) {
                $(function () {
                    $("#dialog").html(message);
                    $("#dialog").dialog({
                        title: " :: Aviso :: ",
                        buttons: {
                            Close: function () {
                                $(this).dialog('close');
                            }
                        },
                        modal: true
                    });
                });
            };


        </script>

<asp:Panel ID="panelTotal" runat="server">
    <asp:UpdatePanel ID="upPanTotal" runat="server">
        <ContentTemplate>

    <div id="container">
        <br /><br />


        <asp:Label ID="lblFP" runat="server" Text="Seleccione la forma de pago: "></asp:Label>
        <asp:DropDownList ID="ddlFormaPago" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlFormaPago_SelectedIndexChanged">
            <asp:ListItem Selected="True" Text="" Value="0" />
            <asp:ListItem Text="Tarjeta de crédito" Value="ddlTC" />
            <asp:ListItem Text="Cuenta Corriente" Value="ddlCC" />
        </asp:DropDownList>    <br /><br />

        <asp:Panel ID="panelCC" Visible="false" runat="server">
            <asp:Label ID="lblCuentaCorrienteNro" runat="server" Text="Nro Cuenta Corriente: "></asp:Label>
            <%--<asp:TextBox ID="txtCCnro" ValidationGroup="ValCuentaCorriente"  required Type="number" placeholder="Ingresar Nro CC." runat="server"></asp:TextBox>--%>
            <asp:Label ID="lblCCNro" runat="server" Font-Bold="true"></asp:Label>

            <asp:Label ID="lblSaldoDisponible" runat="server" Text="Saldo Disponible: $"></asp:Label>
            <asp:Label ID="lblTotalSaldo" runat="server" Font-Bold="true" ></asp:Label>

            <br />
            <br />

            <asp:Label runat="server" ID="lblSaldoInsuficiente" ForeColor="Red" Visible="false"
                Text="Su saldo en la Cuenta Corriente es insuficiente. El saldo restante de ${0} lo debe pagar con Tarjeta de Crédito" ></asp:Label>
            <br />
        </asp:Panel>
    
        <asp:Panel ID="panelTC" Visible="false" runat="server">
            <asp:Label ID="lblCards" runat="server" Text="Seleccione la tarjeta: "></asp:Label>
            <asp:RadioButtonList ID="rblCards" RepeatDirection="Horizontal" RepeatLayout="Table" runat="server">
                <asp:ListItem Selected="True" Text="Visa" Value="VISA"></asp:ListItem>
                <asp:ListItem Text="American Express" Value="AMEX"></asp:ListItem>
                <asp:ListItem Text="Mastercard" Value="MASTER"></asp:ListItem>
            </asp:RadioButtonList>
            <br />
            <asp:Label ID="lblNroTarjeta" runat="server" Text="Nro Tarjeta: "></asp:Label>
<%--            <asp:TextBox ID="txtNroTarjeta" MaxLength="16"  ValidationGroup="ValTarjetaCredito" required Type="number" placeholder="Ingresar Nro Tarjeta" runat="server"></asp:TextBox>
            <asp:Label ID="lblMarcaTarjObtenida" runat="server" class="log"></asp:Label>--%>
            <asp:TextBox ID="txtNroTarjeta" ValidationGroup="ValTarjetaCredito"  required Type="number" placeholder="Ingresar Nro Tarjeta" runat="server"></asp:TextBox><br />
<%--            <asp:Label ID="lblMarcaTarjObtenida" runat="server" class="log"></asp:Label><br />--%>
<%--            <input id="txtNroTarjeta" runat="server"> <label id="lblTipoTarjMarca" runat="server" class="log"> </label>--%>
            <asp:Label ID="lblFV" runat="server" Text="Fecha de vencimiento: Mes "></asp:Label>
            <asp:TextBox ID="txtMes" ValidationGroup="ValTarjetaCredito"  required style="width:50px;" min="1" max="12" Type="number" runat="server"></asp:TextBox>
            <asp:Label ID="lblFV2" runat="server" Text="  / Año "></asp:Label>
            <asp:TextBox ID="txtAnio" ValidationGroup="ValTarjetaCredito"  required style="width:70px;" min="2016" max="2030"  Type="number" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblCodSeg" runat="server" Text="Código de seguridad: "></asp:Label>
            <asp:TextBox ID="txtCodSeg"  ValidationGroup="ValTarjetaCredito"  required Type="number" style="width:70px;" min="100" max="9999" placeholder="Cod. Seg" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblCantCuotas" runat="server" Text="Cant cuotas: "></asp:Label>
            <asp:TextBox ID="txtCantCuotas" ValidationGroup="ValTarjetaCredito"  required min="1" max="12" Type="number" style="width:50px;" runat="server"></asp:TextBox><br />
            
        </asp:Panel>

             <asp:Panel ID="panelAviso" Visible="false" runat="server">
                <br />
                 <asp:Label ID="lblAvisoPago1" runat="server" Text="Usted va a pagar: $"></asp:Label>
                <asp:Label ID="lblAvisoPago2" runat="server"></asp:Label>
             </asp:Panel>

        <br />    <br />
        

    </div>
        
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnConfirmar" />
        </Triggers>
    </asp:UpdatePanel>
        <asp:Button ID="btnCancelar" CssClass="btn btn-default" formnovalidate OnClientClick="return confirm('Tu reserva quedará pendiente de pago por 7 días desde su registracion. Luego procederemos a cancelarla.')" runat="server" Text="Pagar en otro momento" OnClick="btnCancelar_Click"/>
        <asp:Button ID="btnConfirmar" CssClass="btn btn-default" OnClick="btnConfirmar_Click" ValidationGroup="ValCuentaCorriente"   runat="server" Text="Confirmar" />
</asp:Panel>

     <br /><br />       
    <asp:Label ID="lblPyEconfirmado" Visible="false" runat="server" Text="Hemos registrado tu pago."></asp:Label><br /><br />
    <asp:Label ID="lblErrorMensaje" Visible="false" runat="server" ForeColor="Red" Text=""></asp:Label><br /><br />
    <asp:Button ID="btnContinuar" CssClass="btn btn-default" Visible="false" OnClick="btnContinuar_Click"  runat="server" Text="Continuar" />
    <asp:Button ID="btnMisReservas" CssClass="btn btn-default" Visible="false"  OnClick="btnMisReservas_Click" runat="server" Text="Ir a mis reservas" />
    <br />

        <!-- Ventana modal -->
        <div id="dialog" style="display: none"></div>
    <br />

</asp:Content>
