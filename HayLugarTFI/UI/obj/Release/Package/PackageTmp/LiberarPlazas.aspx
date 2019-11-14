<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LiberarPlazas.aspx.cs" Inherits="UI.LiberarPlazas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Timer ID="Timer1" runat="server" Interval="1000">
                </asp:Timer>
        <asp:UpdatePanel ID="UpdatePanel1"
            runat="server">
            <ContentTemplate>
                <br />
                <div class="row" >
                    <div class="col-md-2">
                <asp:Label ID="lblFechaActual" Text="Fecha Actual" runat="server"
                    Font-Size="Large" ></asp:Label>
                   <asp:Label ID="lblTime" runat="server"
                    Font-Size="Large" ></asp:Label>
                <br />
                        </div>
                    </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="tIMER1" EventName="Tick"></asp:AsyncPostBackTrigger>
                <asp:PostBackTrigger ControlID="btnAjustarHora" />
            </Triggers>
        </asp:UpdatePanel>
    <br />
    <div class="row">
        <div class="col-md-2">        
            <asp:Label ID="lblAjustarFechaHora" Text="Ajustar a la fecha y hora: " runat="server"
                    Font-Size="Large" ></asp:Label>
        </div>
        <div class="col-md-2">
					<asp:TextBox runat="server" ID="txtFecha" type="date" required size="80" CssClass="form-control" />
            </div>
        <div class="col-md-2">
                   <asp:TextBox ID="txtHoraDesde" runat="server" type="time" required step="3600" size="80"  CssClass="form-control"></asp:TextBox>
                
	            </div>
        </div>
    <br /><p></p>
    <br />
    <div class="row" >
                    <div class="col-md-2">
    <asp:Button runat="server" ID="btnAjustarHora" CssClass="btn btn-secondary" Text="Ajustar Hora" OnClick="btnAjustarHora_Click"/>
                        </div>
        </div>
    <br /><p></p>

</asp:Content>
