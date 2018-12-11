<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MisDatosPersonales.aspx.cs" Inherits="UI.MisDatosPersonales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
                <%-- GV- CSSyJS - INICIO --%>
        <link href="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/css/footable.min.css" rel="stylesheet" type="text/css" />
        <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
        <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/js/footable.min.js"></script>
        <script type="text/javascript">
            $(function () {
                $('[id*=gvDatosPersonales]').footable();
            });
        </script>

            <script type="text/javascript">
                var prm = Sys.WebForms.PageRequestManager.getInstance();
                prm.add_endRequest(function () {
                    $(function () {
                        $('[id*=gvDatosPersonales]').footable();
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
                    $('[id*=gvDatosPersonales]').footable();
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
                            <h4>Datos personales</h4>
                        <hr />
                        <br />
                        <div>
                    <asp:GridView ID="gvDatosPersonales" runat="server" AutoGenerateColumns="False" AllowPaging="true"
                        PageSize="50" Align="Center" CssClass="footable" OnPageIndexChanging="gvDatosPersonales_PageIndexChanging" 
                        OnRowEditing="gvDatosPersonales_RowEditing">
                    <Columns>

                        <asp:BoundField DataField="aliasEmp" ItemStyle-CssClass="filtro" HeaderText="Titular" />
                        <asp:BoundField DataField="tipoDoc" HeaderText="Tipo Documento" />
                        <asp:BoundField DataField="nroDoc" HeaderText="Nro Documento" />
                        <asp:BoundField DataField="email" HeaderText="EMail" />
                        <asp:TemplateField HeaderText="Tipo Telefono">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#Eval("tipoTelefono")%>' ID="lblTipoTelefono"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="telefono" HeaderText="Nro Telefono" />


                        <asp:CommandField HeaderText="Modificar" EditText="Modificar" ShowEditButton="true" ShowCancelButton="false" />

                        <asp:TemplateField  Visible="false" HeaderText = "Id" ItemStyle-HorizontalAlign="Right">
                            <ItemTemplate>
                                <asp:Label ID="lblNroReg" Visible="false" style="width: 45px;" Text='<%#Eval("nroReg")%>' runat="server" ></asp:Label>
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

            <br />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Panel ID="pnl" runat="server">
                        <br />
                        <hr />
                            <h4>Vehículo</h4>
                        <hr />
                        <br />
                        <div>
                    <asp:GridView ID="gvVehiculo" runat="server" AutoGenerateColumns="False" AllowPaging="true"
                        PageSize="50" Align="Center" CssClass="footable" OnPageIndexChanging="gvVehiculo_PageIndexChanging" 
                        OnRowEditing="gvVehiculo_RowEditing">
                    <Columns>

                        <asp:BoundField DataField="marca" ItemStyle-CssClass="filtro" HeaderText="Marca" />
                        <asp:BoundField DataField="modelo" HeaderText="Modelo" />
                        <asp:BoundField DataField="patente" HeaderText="Patente" />
                        

                        <asp:CommandField HeaderText="Modificar" EditText="Modificar" ShowEditButton="true" ShowCancelButton="false" />

                        <asp:TemplateField  Visible="false" HeaderText = "Id" ItemStyle-HorizontalAlign="Right">
                            <ItemTemplate>
                                <asp:Label ID="lblNroReg" Visible="false" style="width: 45px;" Text='<%#Eval("nroReg")%>' runat="server" ></asp:Label>
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
							    <h4>Modificar datos personales</h4>
							    <hr />

							    <div class="form-group">
								    <asp:Label runat="server" Visible="false" ID="lblAliasEmp" CssClass="col-md-2 control-label">Nombre y Apellido</asp:Label>
								    <div class="col-md-10">
									    <asp:TextBox runat="server" Visible="false" ID="txtAliasEmp" size="80" CssClass="textAreaBoxInputs" />
								    </div>
							    </div>

				                <div class="form-group">
                                        <asp:Label runat="server" ID="lblTipoDocumento" CssClass="col-md-2 control-label">Tipo Documento</asp:Label>
					                <div class="col-md-10">
                                        <asp:DropDownList ID="ddlTipoDocumento" AutoPostBack="false" runat="server">
                                                <asp:ListItem  Selected="True" Text="DNI" Value="DNI" />
                                                <asp:ListItem Text="CUIT" Value="CUIT" />
                                        </asp:DropDownList> 
                                        </div>
				                </div>

                                <div class="form-group">
                                    <asp:Label runat="server" ID="lblNumeroDocumento" CssClass="col-md-2 control-label">Número Documento</asp:Label>
                                    <div class="col-md-10">
                                        <asp:TextBox runat="server" Type="number" ID="txtNumeroDocumento" size="30" CssClass="textAreaBoxInputs" />
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNumeroDocumento"
                                            CssClass="text-danger" ErrorMessage="El campo Num DNI es requerido." />
                                        <asp:CustomValidator runat="server" ID="cvNumDNI" ControlToValidate="txtNumeroDocumento" OnServerValidate="cvNumDNI_ServerValidate"
                                            CssClass="text-danger" ErrorMessage="Verificar CUIT"  ></asp:CustomValidator>
                                    </div>
                                </div>		

							    <div class="form-group">
								    <asp:Label runat="server" ID="lblEmail" CssClass="col-md-2 control-label">Email</asp:Label>
								    <div class="col-md-10">
									    <asp:TextBox runat="server" Enabled="false" ID="txtEmail" size="80" CssClass="textAreaBoxInputs" />
								    </div>
							    </div>

				                <div class="form-group">
                                        <asp:Label runat="server" ID="lblTipoTelefono" CssClass="col-md-2 control-label">Tipo Telefono</asp:Label>
					                <div class="col-md-10">
                                        <asp:DropDownList ID="ddltipotelefono" AutoPostBack="false" runat="server">
                                                <asp:ListItem  Selected="True" Text="MOVIL" Value="MOVIL" />
                                                <asp:ListItem Text="FIJO" Value="FIJO" />
                                        </asp:DropDownList> 
                                        </div>
				                </div>

							    <div class="form-group">
								    <asp:Label runat="server" ID="lblNroTelefono" CssClass="col-md-2 control-label">Nro Telefono</asp:Label>
								    <div class="col-md-10">
									    <asp:TextBox runat="server" Enabled="true" ID="txtNroTelefono" size="80" CssClass="textAreaBoxInputs" />
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
    <div id="tabs-3">
            <br />
            <asp:UpdatePanel ID="upVehiculo" runat="server" >
                <ContentTemplate>
                    <asp:Panel ID="pnlVehiculo" Visible="false" runat="server">
                        <br />
                        <div class="form-horizontal">
							    <hr />
							    <h4>Modificar vehiculo</h4>
							    <hr />

							    <div class="form-group">
								    <asp:Label runat="server" Visible="false" ID="Label1" CssClass="col-md-2 control-label">Marca</asp:Label>
								    <div class="col-md-10">
									    <asp:TextBox runat="server" Visible="false" ID="TextBox1" size="80" CssClass="textAreaBoxInputs" />
								    </div>
							    </div>

                                
							    <div class="form-group">
								    <asp:Label runat="server" ID="Label6" CssClass="col-md-2 control-label">Modelo</asp:Label>
								    <div class="col-md-10">
									    <asp:TextBox runat="server" Enabled="true" ID="TextBox4" size="80" CssClass="textAreaBoxInputs" />
								    </div>
							    </div>
                            <div class="form-group">
								    <asp:Label runat="server" ID="Label2" CssClass="col-md-2 control-label">Patente</asp:Label>
								    <div class="col-md-10">
									    <asp:TextBox runat="server" Enabled="true" ID="TextBox2" size="80" CssClass="textAreaBoxInputs" />
								    </div>
							    </div>
                        <br /><br />                            
                        <div class="form-group">
				            <div class="col-md-10">
                                <asp:Button ID="Button1" CssClass="btn btn-default" formnovalidate runat="server" Text=" : Cancelar : " OnClick="btnCancelar_Click" />
                                <asp:Button ID="Button2" CssClass="btn btn-default" ValidationGroup="ValCuentaCorriente" runat="server" Text=" : Confirmar :" OnClick="btnConfirmar_Click" />
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
