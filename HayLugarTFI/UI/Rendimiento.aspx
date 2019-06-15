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

                			<asp:Panel ID="pnlTabcc" Visible="false" runat="server">
                <div id="div_tablacc">
                        <table id="tablacc" style="width:100%;border: white 5px solid">
                          <tr>
                            <th style="text-align: left;">
				                <hr />
				                <h4>Cuenta Corriente.</h4>
				                <hr />		
				                <div class="form-group">
					                <div class="col-md-10">
						                <asp:GridView ID="gv_DatosCC" CssClass="footable" runat="server" AutoGenerateColumns="false">
                                                    <Columns>
<%--                                                        <asp:BoundField DataField="valor" HeaderText="Banco" />--%>
                                                        <asp:BoundField DataField="nroCuenta" HeaderText="Nro. Cuenta" />
<%--                                                        <asp:BoundField DataField="saldo" HeaderText="Saldo Actual" />--%>
                                                        <asp:TemplateField  HeaderText = "Saldo Actual" ItemStyle-HorizontalAlign="Right">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSaldo" style="width: 45px;" Text='<%# String.Format("${0:n2}", Convert.ToDecimal( Eval("saldo"))) %>' runat="server" ></asp:Label>
                                                            </ItemTemplate>                    
                                                        </asp:TemplateField> 
                                                    </Columns>
						                </asp:GridView><br />
				                        <div class="form-group">
					                        <div class="col-md-10">
						                        <asp:Button runat="server" ID="btnVerMovCC" Text="Ver Movimientos" OnClick="btnVerMovCC_Click" CssClass="btn btn-default" />
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
