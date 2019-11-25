<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Bitacora.aspx.cs" Inherits="UI.Bitacora" %>
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
                        <div id="divFiltros1" runat="server">
                        
                            <div class="row" >
                                <div class="col-md-2">
                                    <asp:Label ID="lblFechaDesde" runat="server" Text="Fecha Reserva Desde: "></asp:Label>
                                
                                    <asp:TextBox runat="server" ID="txtFechaDesde" type="date" CssClass="form-control" ></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <asp:Label ID="lblFechaHasta" runat="server" Text="Hasta: "></asp:Label>
                                    <asp:TextBox runat="server" ID="txtFechaHasta" type="date" CssClass="form-control" ></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <asp:Label ID="lblUsuario" runat="server" Text="Usuario: "></asp:Label>
                                    <asp:TextBox runat="server" ID="txtUsuario" CssClass="form-control" ></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <asp:Label ID="lblPerfil" runat="server" Text="Perfil: "></asp:Label>
                                    <asp:DropDownList runat="server" ID="ddlPerfil" CssClass="form-control" ></asp:DropDownList>
                                </div>
                                <div class="col-md-1">
                                    <asp:Label runat="server" ID="Label1" ForeColor="White" Text="......" Font-Bold="true"></asp:Label>
                                    <asp:Button runat="server" ID="btnFiltrar" OnClick="btnFiltrar_Click" Text="Filtrar" CssClass="btn btn-warning"/>
                                
                                </div>
                                <div class="col-md-1">
                                    <asp:Label runat="server" ID="Label4" ForeColor="White" Text="." Font-Bold="true"></asp:Label>
                                    <asp:Button runat="server" ID="btnLimpiarFiltros" OnClick="btnLimpiarFiltros_Click" Text="Limpiar Filtro" CssClass="btn btn-info"/>
                                
                                </div>
                                </div>
                            <br />
                            <div class="row" >
                                <div class="col-md-4">
                            <asp:Label runat="server" ID="lblErrorFiltro" ForeColor="Red" Font-Bold="true"></asp:Label>
                                    </div>
                                </div>
                        </div>

                        <br /><p></p>
                        
                        <div>
                    <asp:GridView ID="gvReservasPendientes" runat="server" AutoGenerateColumns="False" AllowPaging="true"
                        PageSize="50" CssClass="footable" Align="Center" OnRowCommand="gvReservasPendientes_RowCommand" OnRowEditing="gvReservasPendientes_RowEditing" OnPageIndexChanging="gvReservasPendientes_PageIndexChanging"  >
                        <Columns> 

                            <asp:BoundField DataField="idReserva" ItemStyle-HorizontalAlign="Center" HeaderText="Id Reserva" />
                            
                            <asp:BoundField DataField="fechaDesde" HeaderText="Fecha Desde" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="fechaHasta" HeaderText="Fecha Hasta" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="descEstacionamiento" DataFormatString="{0:F}" HeaderText="Tarifa" />

                            <asp:BoundField DataField="calle" HeaderText="Calle" />

                            <asp:BoundField DataField="altura" HeaderText="Altura" />                           

                            <asp:BoundField DataField="UserName" ItemStyle-CssClass="filtro" HeaderText="Reservado por" />

                            <asp:CommandField HeaderText="" EditText="Cancelar Reserva" ShowEditButton="true" ShowCancelButton="false"  />


                            <asp:TemplateField HeaderText = "Reserva">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkPagarReserva" CommandName="Pagar" CommandArgument='<%# Eval("idReserva")+","+Eval("descEstacionamiento")%>' Text="Pagar" runat="server" ></asp:LinkButton>
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

</asp:Content>
