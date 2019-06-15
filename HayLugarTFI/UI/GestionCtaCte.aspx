<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionCtaCte.aspx.cs" Inherits="UI.GestionCtaCte" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

            <%-- GV- CSSyJS - INICIO --%>
        <link href="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/css/footable.min.css" rel="stylesheet" type="text/css" />
        <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
        <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/js/footable.min.js"></script>
        <script type="text/javascript">
            $(function () {
                $('[id*=gvCC]').footable();
            });
        </script>

            <script type="text/javascript">
                var prm = Sys.WebForms.PageRequestManager.getInstance();
                prm.add_endRequest(function () {
                    $(function () {
                        $('[id*=gvCC]').footable();
                    });
                });
        </script>
    <%-- GV- CSSyJS - FIN --%>

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
                    $('[id*=gvCC]').footable();
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
                            <h4>Gestión de Cuenta Corriente</h4>
                        <hr />
                        <br />
                        <asp:Button runat="server" ID="btnAgregar" CssClass="btn btn-default" Text="Agregar una cuenta" OnClick="btnAgregar_Click"/>
                        <br /><p></p>
                        <div>
                    <asp:GridView ID="gvCC" runat="server" AutoGenerateColumns="False" AllowPaging="true"
                        PageSize="50" Align="Center" CssClass="footable" OnPageIndexChanging="gvCC_PageIndexChanging" OnRowEditing="gvCC_RowEditing">
                    <Columns>

                        <asp:BoundField DataField="nroCuenta" HeaderText="Nro de cuenta" />

                        <asp:BoundField DataField="UserName" HeaderText="Titular" />

                        <asp:TemplateField  HeaderText = "Saldo Actual" ItemStyle-HorizontalAlign="Right">
                            <ItemTemplate>
                                <asp:Label ID="lblSaldoHoy" style="width: 45px;" Text='<%# String.Format("${0:n2}", Convert.ToDecimal( Eval("saldo"))) %>' runat="server" ></asp:Label>
                            </ItemTemplate>                    
                        </asp:TemplateField>                            

                        <asp:CommandField HeaderText="Modificar" EditText="Modificar" ShowEditButton="true" ShowCancelButton="false" />

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
							    <h4 id="titleProdAccion" runat="server">Modificar Cuenta Corriente</h4>
							    <hr />

                               <div class="form-group">
								    <asp:Label runat="server" ID="lblCUENTA" CssClass="col-md-2 control-label">Nro. Cuenta</asp:Label>
								    <div class="col-md-10">
									    <asp:TextBox runat="server" Enabled="false" ID="txtNroCuenta" size="80" CssClass="form-control" />
								    </div>
							    </div>

                               <div class="form-group">
								    <asp:Label runat="server" ID="lblTitular" CssClass="col-md-2 control-label">Titular</asp:Label>
								    <div class="col-md-10">
									    <asp:TextBox runat="server" Enabled="false" ID="txtTitular" size="80" CssClass="form-control" />
								    </div>
							    </div>

                               <div class="form-group">
								    <asp:Label runat="server" ID="lblUsuarios" CssClass="col-md-2 control-label">Usuario</asp:Label>
                                    <div class="col-md-10">
                                        <asp:DropDownList ID="ddlUsuarios" AutoPostBack="false" runat="server" CssClass="form-control">
                                        </asp:DropDownList> 
                                    </div>
							    </div>


                                <div class="form-group">
								    <asp:Label runat="server" ID="lblSaldoHoy" CssClass="col-md-2 control-label">Saldo $</asp:Label>
								    <div class="col-md-10">
									    <asp:TextBox runat="server" Enabled="false" ID="txtSaldoHoy" size="10" CssClass="form-control" Width="180px" />
								    </div>
							    </div>

                                <div class="form-group">
								    <asp:Label runat="server" ID="lblSaldoNuevo" CssClass="col-md-2 control-label">Nuevo Saldo $</asp:Label>
								    <div class="col-md-10">
									    
                                        <asp:TextBox ID="txtSaldoNuevo" ValidationGroup="ValCuentaCorriente" size="10"  required Type="number" placeholder="Ingresar un valor." runat="server" CssClass="form-control" Width="180px"></asp:TextBox>
								    </div>
							    </div>

                        <br /><br />                            
                        <div class="form-group">
				            <div class="col-md-10">
                                <asp:Button ID="btnCancelar" CssClass="btn btn-default" formnovalidate runat="server" Text=" : Cancelar : " OnClick="btnCancelar_Click" />
                                <asp:Button ID="btnConfirmar" CssClass="btn btn-default" ValidationGroup="ValCuentaCorriente" runat="server" Text=" : Confirmar :" OnClick="btnConfirmar_Click" />
                            </div>
                        </div>
                    </div>
                    </asp:Panel>
                </ContentTemplate>        
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnConfirmar" />
                    <asp:PostBackTrigger ControlID="btnCancelar" />

                </Triggers>        
            </asp:UpdatePanel>    
            </div>

</asp:Content>
