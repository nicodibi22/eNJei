<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reclamo.aspx.cs" Inherits="UI.Reclamo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

                <%-- GV- CSSyJS - INICIO --%>
        <link href="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/css/footable.min.css" rel="stylesheet" type="text/css" />
        <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
        <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/js/footable.min.js"></script>
        <script type="text/javascript">
            $(function () {
                $('[id*=gvReclamo]').footable();
            });
        </script>
    
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
                    $('[id*=gvReclamo]').footable();
                });
            });
        </script>


    <br />

        <div id="tabs-1">
            <br />
            <asp:UpdatePanel ID="upnlTotal" runat="server">
                <ContentTemplate>
                    <asp:Panel ID="pnlTab1" runat="server">
                        <br />
                        <hr />
                            <h4>Listado de Reclamos</h4>
                        <hr />
                        <br />
                        <asp:Button runat="server" ID="btnAgregar" CssClass="btn btn-default" Text="Agregar" OnClick="btnAgregar_Click"/>
                        <br /><p></p>
                        <br />

                        <div>
                    <asp:GridView ID="gvReclamo" runat="server" AutoGenerateColumns="False" AllowPaging="true"
                        PageSize="50" CssClass="footable" Align="Center" OnRowCommand="gvReclamo_RowCommand"
                        DataKeyNames="idReclamo" OnPageIndexChanging="gvReclamo_PageIndexChanging" OnRowDataBound="gvReclamo_RowDataBound" >
                        <Columns> 

                            <asp:BoundField DataField="idReclamo" ItemStyle-HorizontalAlign="Center" HeaderText="Id Reclamo" />
                            <asp:BoundField DataField="idReserva" ItemStyle-HorizontalAlign="Center" HeaderText="Id Reserva" />
                            
                            <asp:BoundField DataField="fechaDesde" ItemStyle-HorizontalAlign="Center" HeaderText="Fecha Desde" DataFormatString="{0:dd/MM/yyyy}"  />
                            <asp:BoundField DataField="fechaHasta" ItemStyle-HorizontalAlign="Center" HeaderText="Fecha Hasta" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="Estado" HeaderText="Estado" />
                            <asp:BoundField DataField="fechaReclamo" HeaderText="Fecha Reclamo" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="fechaCierre" HeaderText="Fecha Cierre" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:TemplateField HeaderText = "" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblPathImagen"   Text='<%# Eval("pathImagen") %>' runat="server" ></asp:Label>
                                </ItemTemplate>                    
                            </asp:TemplateField> 
                            <asp:TemplateField HeaderText = "">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkDescargar" CommandName="Descargar" CommandArgument='<%# Eval("pathImagen") %>' Text="Descargar" runat="server" ></asp:LinkButton>
                                </ItemTemplate>                    
                            </asp:TemplateField>   
                            <asp:TemplateField HeaderText = "">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkPagarReclamo" CommandName="Pagar" CommandArgument='<%# Eval("idReclamo")+ "," + Eval("idReserva")%>' Text="Pagar" runat="server" ></asp:LinkButton>
                                </ItemTemplate>                    
                            </asp:TemplateField>   
                            <asp:TemplateField HeaderText = "">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkRechazarReclamo" CommandName="Rechazar" CommandArgument='<%# Eval("idReclamo")+ "," + Eval("idReserva")%>' Text="Rechazar" runat="server" ></asp:LinkButton>
                                </ItemTemplate>                    
                            </asp:TemplateField>   

                            
                        </Columns>
                    <PagerStyle CssClass="GridView" HorizontalAlign="Center" />
                    </asp:GridView>
                        </div>
                        <br />
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
							    <h4 id="titleProdAccion" runat="server">Ver Reclamo</h4>
							    <hr />

							    <div class="form-group">
								    <asp:Label runat="server" ID="lblIdReclamo" CssClass="col-md-2 control-label">Identificador del Reclamo</asp:Label>
								    <div class="col-md-1">
									    <asp:TextBox runat="server" Enabled="false" ID="txtIdReclamo" size="10" type="number" CssClass="form-control" />
								    </div>
							    </div>
                                <div class="form-group">
								    <asp:Label runat="server" ID="lblReserva" CssClass="col-md-2 control-label">Reserva</asp:Label>
								    <div class="col-md-2">
<%--									    <asp:TextBox runat="server" ID="txtIdBarrio" ValidationGroup="producto" required size="80" CssClass="textAreaBoxInputs" />--%>
                                        <asp:DropDownList ID="ddlReserva" runat="server" CssClass="form-control">
                                        </asp:DropDownList> 
								    </div>
							    </div>
							    <div class="form-group">
								    <asp:Label runat="server" ID="lblPatenteInfractor" CssClass="col-md-2 control-label">Patente Infractor</asp:Label>
								    <div class="col-xs-1">
									    <asp:TextBox runat="server" ID="txtPatenteInfractor" ValidationGroup="producto" required size="80" CssClass="form-control" />
								    </div>
							    </div>
                                <div class="form-group">
								    <asp:Label runat="server" ID="lblImagenInfraccion" CssClass="col-md-2 control-label">Foto del infractor</asp:Label>
								    <div class="col-xs-1">
									    <asp:FileUpload ID="FileUpload1" runat="server" />
								    </div>
							    </div>
							

                        </div>
                        <div ID="divBotones" style="display:none">            
            <br /><br />
            <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>

                            <br /><br />
                            
                            <div class="form-group">
							    <div class="col-md-10">
                                    <asp:Button ID="btnCancelar" CssClass="btn btn-danger" formnovalidate runat="server" Text=" : Cancelar : " OnClick="btnCancelar_Click" />
                                    <asp:Button ID="btnConfirmar" CssClass="btn btn-success" ValidationGroup="producto"  runat="server" Text=" : Confirmar :" OnClick="btnConfirmar_Click"/>
                                </div>
                            </div>                        
                        <br />
                    </div>   
                    </asp:Panel>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID = "btnConfirmar" />
                </Triggers>
            </asp:UpdatePanel>
                      
        </div>



</asp:Content>
