<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MisReservas.aspx.cs" Inherits="UI.MisReservas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%-- GV- CSSyJS - INICIO --%>
        <link href="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/css/footable.min.css" rel="stylesheet" type="text/css" />
        <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
        <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/js/footable.min.js"></script>
        <script type="text/javascript">
            $(function () {
                $('[id*=gvReservasPendientes]').footable();
            });
        </script>

            <script type="text/javascript">
                var prm = Sys.WebForms.PageRequestManager.getInstance();
                prm.add_endRequest(function () {
                    $(function () {
                        $('[id*=gvReservasPendientes]').footable();
                    });
                });
        </script>
    <%-- GV- CSSyJS - FIN --%>


        <script src="js/myJS.js" type="text/javascript"></script>
        <script type="text/javascript">
                var prm = Sys.WebForms.PageRequestManager.getInstance();
                prm.add_endRequest(function () {


                    //agregar una nueva columna con todo el texto 
                    //contenido en las columnas de la grilla 
                    // contains de Jquery es CaseSentive, por eso a minúscula
                    $(".footeable tr:has(td.filtro)").each(function () {
                        var t = $(this).text().toLowerCase();
                        $("<td class='indexColumn'></td>")
                        .hide().text(t).appendTo(this);
                    });
                    //Agregar el comportamiento al texto (se selecciona por el ID) 
                    $("#texto").keyup(function () {
                        var s = $(this).val().toLowerCase().split(" ");
                        $(".footeable tr:hidden").show();
                        $.each(s, function () {
                            $(".footeable tr:visible .indexColumn:not(:contains('"
                            + this + "'))").parent().hide();
                        });
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
                            <h4>Mis reservas pendientes de pago</h4>
                        <hr />
                        <br /><p></p>
                        <div>
                    <asp:GridView ID="gvReservasPendientes" runat="server" AutoGenerateColumns="False" AllowPaging="true"
                        PageSize="50" CssClass="footable" Align="Center" OnRowCommand="gvReservasPendientes_RowCommand" OnRowEditing="gvReservasPendientes_RowEditing" OnPageIndexChanging="gvReservasPendientes_PageIndexChanging"  >
                        <Columns> 

                            <asp:BoundField DataField="idPlaza" ItemStyle-HorizontalAlign="Center" HeaderText="Identificador de la Reserva" />

                            <asp:BoundField DataField="descEstacionamiento" HeaderText="Tarifa" />

                            <asp:BoundField DataField="calle" HeaderText="Calle" />

                            <asp:BoundField DataField="altura" HeaderText="Altura" />

                            <asp:BoundField DataField="datosAdicionales" HeaderText="Datos adicionales" />

                            <asp:BoundField DataField="descBarrio" HeaderText="Barrio" />

                            <asp:BoundField DataField="UserName" ItemStyle-CssClass="filtro" HeaderText="Reservado por" />

                            <asp:CommandField HeaderText="" EditText="Cancelar Reserva" ShowEditButton="true" ShowCancelButton="false" />


                            <asp:TemplateField HeaderText = "Reserva">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkPagarReserva" CommandName="Pagar" CommandArgument='<%# Eval("idPlaza")+","+Eval("descEstacionamiento")%>' Text="Pagar" runat="server" ></asp:LinkButton>
                                </ItemTemplate>                    
                            </asp:TemplateField>                            

                        </Columns>
                    <PagerStyle CssClass="GridView" HorizontalAlign="Center" />
                    </asp:GridView>
                        </div>
                        <br />

                        <br />
                        <hr />
                            <h4>Mis reservas pagas</h4>
                        <hr />
                        <br /><p></p>
                        <div>
                        <%--gvReserva: acá listo las reservas pagas--%>
                    <asp:GridView ID="gvReserva" runat="server" AutoGenerateColumns="False" AllowPaging="true"
                        PageSize="50" CssClass="footable" Align="Center" OnRowCommand="gvReserva_RowCommand" OnPageIndexChanging="gvReserva_PageIndexChanging" OnRowEditing="gvReserva_RowEditing">
                        <Columns> 

                            <asp:BoundField DataField="idPlaza" ItemStyle-HorizontalAlign="Center" HeaderText="Identificador de la Reserva" />

                            <asp:BoundField DataField="descEstacionamiento" HeaderText="Tarifa" />

                            <asp:BoundField DataField="calle" HeaderText="Calle" />

                            <asp:BoundField DataField="altura" HeaderText="Altura" />

                            <asp:BoundField DataField="datosAdicionales" HeaderText="Datos adicionales" />

                            <asp:BoundField DataField="descBarrio" HeaderText="Barrio" />

                            <asp:BoundField DataField="UserName" HeaderText="Reservado por" />
                            
                            <asp:TemplateField HeaderText = "Reserva">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkImprimirReserva" CommandName="ImprimirReserva" CommandArgument='<%# Eval("idPlaza")%>' Text="Descargar" runat="server" ></asp:LinkButton>
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
							    <h4 id="titleProdAccion" runat="server">Modificar Reserva</h4>
							    <hr />

							    <div class="form-group">
								    <asp:Label runat="server" ID="lblIdReserva" CssClass="col-md-2 control-label">Identificador de la Reserva</asp:Label>
								    <div class="col-md-10">
									    <asp:TextBox runat="server" Enabled="false" ID="txtIdReserva" size="10" CssClass="textAreaBoxInputs" />
								    </div>
							    </div>

							    <div class="form-group">
								    <asp:Label runat="server" ID="lbldescEstacionamiento" CssClass="col-md-2 control-label">Estacionamiento</asp:Label>
								    <div class="col-md-10">
									    <asp:TextBox runat="server" Enabled="false" ID="txtdescEstacionamiento" size="80" CssClass="textAreaBoxInputs" />
								    </div>
							    </div>

							    <div class="form-group">
								    <asp:Label runat="server" ID="lblCalle" CssClass="col-md-2 control-label">Calle</asp:Label>
								    <div class="col-md-10">
									    <asp:TextBox runat="server" Enabled="false" ID="txtCalle" size="80" CssClass="textAreaBoxInputs" />
								    </div>
							    </div>

							    <div class="form-group">
								    <asp:Label runat="server" ID="lblAltura" CssClass="col-md-2 control-label">Altura</asp:Label>
								    <div class="col-md-10">
									    <asp:TextBox runat="server" Enabled="false" ID="txtAltura" size="10" CssClass="textAreaBoxInputs" />
								    </div>
							    </div>


							    <div class="form-group">
								    <asp:Label runat="server" ID="lbldatosAdicionales" CssClass="col-md-2 control-label">Datos Adicionales</asp:Label>
								    <div class="col-md-10">
									    <asp:TextBox runat="server" Enabled="false" ID="txtdatosAdicionales" size="80" CssClass="textAreaBoxInputs" />
								    </div>
							    </div>

							    <div class="form-group">
								    <asp:Label runat="server" ID="lbldescBarrio" CssClass="col-md-2 control-label">Barrio</asp:Label>
								    <div class="col-md-10">
									    <asp:TextBox runat="server" Enabled="false" ID="txtdescBarrio" size="80" CssClass="textAreaBoxInputs" />
								    </div>
							    </div>

							    <div class="form-group">
								    <asp:Label runat="server" ID="lblUser" CssClass="col-md-2 control-label">Reservado por</asp:Label>
								    <div class="col-md-10">
									    <asp:TextBox runat="server" Enabled="false" ID="txtUser" size="80" CssClass="textAreaBoxInputs" />
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
