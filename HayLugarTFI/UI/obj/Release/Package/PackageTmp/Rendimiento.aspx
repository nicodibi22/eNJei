<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Rendimiento.aspx.cs" Inherits="UI.Rendimiento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

            <%-- GV- CSSyJS - INICIO --%>
        <link href="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/css/footable.min.css" rel="stylesheet" type="text/css" />
        <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
        <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/js/footable.min.js"></script>
        <script type="text/javascript">
            $(function () {
                $('[id*=gv_DatosCC]').footable();
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
                    $('[id*=gv_DatosCC]').footable();
                });
            });
        </script>

                			<asp:Panel ID="pnlTabcc" runat="server">
                <div id="div_tablacc">
                        <table id="tablacc" style="width:100%;border: white 5px solid">
                          <tr>
                            <th style="text-align: left;">
				                <hr />
				                <h4>Cobros</h4>
				                <hr />		
				                <div class="form-group">
					                <div class="col-md-10">
						                <asp:GridView ID="gv_DatosCocheras" CssClass="footable" runat="server" AutoGenerateColumns="false" OnRowDataBound="gv_DatosCocheras_RowDataBound" EmptyDataText="No hay cobros pendientes para acreditar.">
                                                    <Columns>
<%--                                                        <asp:BoundField DataField="valor" HeaderText="Banco" />--%>
                                                        <asp:BoundField DataField="UserName" HeaderText="Inquilino" />
                                                        <asp:BoundField DataField="fechaDesde" HeaderText="Fecha Desde" DataFormatString="{0:dd/MM/yyyy}" />
<%--                                                        <asp:BoundField DataField="saldo" HeaderText="Saldo Actual" />--%>
                                                        <asp:BoundField DataField="fechaHasta" HeaderText="Fecha Hasta" DataFormatString="{0:dd/MM/yyyy}"/>
                                                        <asp:BoundField DataField="horaDesde" HeaderText="Hora Desde" />
                                                        <asp:BoundField DataField="horaHasta" HeaderText="Hora Hasta" />
                                                        <asp:TemplateField HeaderText="Total">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTarifa" Text='<%# Eval("Importe", "{0:n2}")%>' runat="server" ></asp:Label>
                                                            </ItemTemplate> 
                                                            
                                                        </asp:TemplateField>
                                                    </Columns>
						                </asp:GridView><br />
				                        <div class="form-group">
					                        <div class="col-md-10">
						                        <asp:Button runat="server" ID="btnVerMovCC" Text="Acreditar en CC" OnClick="btnVerMovCC_Click" CssClass="btn btn-secondary" />
					                        </div>
				                        </div>
					                </div>
				                </div>	
			                </th>
                          </tr>
                        </table><br />
                </div>
			</asp:Panel>

</asp:Content>
