<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarPlaza.aspx.cs" Inherits="UI.ModificarPlaza" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    
            <%-- GV- CSSyJS - INICIO --%>
        <link href="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/css/footable.min.css" rel="stylesheet" type="text/css" />
        <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
        <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/js/footable.min.js"></script>

        <script type="text/javascript">
            $(function () {
                $('[id*=gvPlaza]').footable();
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
                    $('[id*=gvPlaza]').footable();
                });
            });
        </script>

        <div id="tabs-1">
            <br />
            <asp:UpdatePanel ID="upnlTotal" runat="server">
                <ContentTemplate>
                    <asp:Panel ID="pnlTab1" runat="server">
                        <br />
                        <hr />
                            <h4>Listado de plazas disponibles</h4>
                        <hr />
                        <br /><p></p>
                        <div>
                    <asp:GridView ID="gvPlaza" runat="server" AutoGenerateColumns="False" AllowPaging="true"
                        PageSize="50" CssClass="footable" Align="Center" OnPageIndexChanging="gvPlaza_PageIndexChanging" OnRowEditing="gvPlaza_RowEditing">
                        <Columns> 

                            <asp:BoundField DataField="idPlaza" ItemStyle-HorizontalAlign="Center" HeaderText="Identificador de la Plaza" />

<%--                            <asp:BoundField DataField="descEstacionamiento" HeaderText="Tarifa" />--%>
                            <asp:BoundField DataField="tipoAlquiler" HeaderText="Tipo Alquiler" />
                        <asp:TemplateField  HeaderText = "Tarifa" ItemStyle-HorizontalAlign="Right">
                            <ItemTemplate>
                                <asp:Label ID="lblTarifa" style="width: 45px;" Text='<%# String.Format("${0:n2}", Convert.ToDecimal( Eval("descripcion"))) %>' runat="server" ></asp:Label>
                            </ItemTemplate>                    
                        </asp:TemplateField>                            

                            <asp:BoundField DataField="calle" HeaderText="Calle" />

                            <asp:BoundField DataField="altura" HeaderText="Altura" />

                            <asp:BoundField DataField="datosAdicionales" HeaderText="Datos adicionales" />

                            <asp:BoundField DataField="descBarrio" HeaderText="Barrio" />
                            
                            <asp:TemplateField  HeaderText = "TipoEstadiaId" Visible="false" ItemStyle-HorizontalAlign="Right">
                            <ItemTemplate>
                                <asp:Label ID="lblTipoEstadiaId" style="width: 45px;" Text='<%#  Eval("idTipoEstadia") %>' runat="server" ></asp:Label>
                            </ItemTemplate>                    
                        </asp:TemplateField>                            
                            <asp:CommandField HeaderText="" EditText="Reservar" ShowEditButton="true" ShowCancelButton="false" />

                        </Columns>
                    <PagerStyle CssClass="GridView" HorizontalAlign="Center" />
                    </asp:GridView>
                        </div>
                        <br />
                        <asp:Label ID="lblMensajeError" runat="server"></asp:Label>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

    	<div id="tabs-2">
            <br />
            <asp:UpdatePanel ID="upnlTotal2" runat="server" >
                <ContentTemplate>
                    <asp:Panel ID="pnlTab2" Visible="false" runat="server">
                        <br />
                        <div class="form-horizontal">
							    <hr />
							    <h4 id="titleProdAccion" runat="server">Modificar Plaza</h4>
							    <hr />

							    <div class="form-group">
								    <asp:Label runat="server" ID="lblIdPlaza" CssClass="col-md-2 control-label">Identificador de la Plaza</asp:Label>
								    <div class="col-md-1">
									    <asp:TextBox runat="server" Enabled="false" ID="txtIdPlaza" size="10" CssClass="form-control" />
								    </div>
							    </div>

							    <div class="form-group">
								    <asp:Label runat="server" ID="lbldescEstacionamiento" CssClass="col-md-2 control-label">Estacionamiento</asp:Label>
								    <div class="col-md-10">
									    <asp:TextBox runat="server" Enabled="false" ID="txtdescEstacionamiento" size="80" CssClass="form-control" />
								    </div>
							    </div>

							    <div class="form-group">
								    <asp:Label runat="server" ID="lblCalle" CssClass="col-md-2 control-label">Calle</asp:Label>
								    <div class="col-md-10">
									    <asp:TextBox runat="server" Enabled="false" ID="txtCalle" size="80" CssClass="form-control" />
								    </div>
							    </div>

							    <div class="form-group">
								    <asp:Label runat="server" ID="lblAltura" CssClass="col-md-2 control-label">Altura</asp:Label>
								    <div class="col-md-2">
									    <asp:TextBox runat="server" Enabled="false" ID="txtAltura" size="10" CssClass="form-control" />
								    </div>
							    </div>


							    <div class="form-group">
								    <asp:Label runat="server" ID="lbldatosAdicionales" CssClass="col-md-2 control-label">Datos Adicionales</asp:Label>
								    <div class="col-md-10">
									    <asp:TextBox runat="server" Enabled="false" ID="txtdatosAdicionales" size="80" CssClass="form-control" />
								    </div>
							    </div>

							    <div class="form-group">
								    <asp:Label runat="server" ID="lbldescBarrio" CssClass="col-md-2 control-label">Barrio</asp:Label>
								    <div class="col-md-10">
									    <asp:TextBox runat="server" Enabled="false" ID="txtdescBarrio" size="80" CssClass="form-control" />
								    </div>
							    </div>
                                <div class="form-group">
                                    <asp:Label runat="server" ID="lblTipoAlquiler" CssClass="col-md-2 control-label">Tipo Alquiler</asp:Label>
								    <div class="col-md-2">
                                        <asp:DropDownList ID="ddlTipoAlquiler" Enabled="false" runat="server" CssClass="form-control" >
                                            <asp:ListItem Text="" Value=""></asp:ListItem>
                                            <asp:ListItem Text="Diario" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Hora" Value="2"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div id="divDiario" runat="server">
                                <div class="form-group">
								    <asp:Label runat="server" ID="lblFechaDesde" CssClass="col-md-2 control-label">Fecha Desde</asp:Label>
								    <div class="col-md-2">
									    <asp:TextBox runat="server" ID="txtFechaDesde" type="date" size="80" CssClass="form-control" />
								    </div>
							    </div>

                                <div class="form-group">
								    <asp:Label runat="server" ID="lblFechaHasta" CssClass="col-md-2 control-label">Fecha Hasta</asp:Label>
								    <div class="col-md-2">
									    <asp:TextBox runat="server" ID="txtFechaHasta" type="date" size="80" CssClass="form-control" />
								    </div>
							    </div>
                                    </div>
                            <div id="divHora" runat="server">
                                <div class="form-group">
								    <asp:Label runat="server" ID="lblFecha" CssClass="col-md-2 control-label">Fecha</asp:Label>
								    <div class="col-md-2">
									    <asp:TextBox runat="server" ID="txtFecha" type="date" size="80" CssClass="form-control" />
								    </div>
							    </div>
                            <div class="form-group" >
								    <asp:Label runat="server" ID="lblHoraDesde" CssClass="col-md-2 control-label">Hora Desde</asp:Label>
								    <div class="col-md-2">
									    <asp:TextBox ID="txtHoraDesde" runat="server" type="time" step="3600" size="80"  CssClass="form-control"></asp:TextBox>
								    </div>
							    </div>
                                <div class="form-group">
								    <asp:Label runat="server" ID="lblHoraHasta" CssClass="col-md-2 control-label">Hora Hasta</asp:Label>
								    <div class="col-md-2">
									    <asp:TextBox ID="txtHoraHasta" runat="server" type="time" step="3600" size="80" CssClass="form-control"></asp:TextBox>
								    </div>
							    </div>

                                </div>
                        </div>
                    </asp:Panel>
                </ContentTemplate>
                
            </asp:UpdatePanel>
             <div ID="divBotones" style="display:none">            
            <br /><br />
            <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>

                            <br /><br />
                            
                            <div class="form-group">
							    <div class="col-md-10">
                                    <asp:Button ID="btnCancelar" CssClass="btn btn-default" formnovalidate runat="server" Text=" : Cancelar : " OnClick="btnCancelar_Click" />
                                    <asp:Button ID="btnConfirmar" CssClass="btn btn-default" ValidationGroup="producto"  runat="server" Text=" : Confirmar :" OnClick="btnConfirmar_Click" />
                                </div>
                            </div>                        
                        <br />
                    </div>            
        </div>

</asp:Content>
