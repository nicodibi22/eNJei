<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="UI.Usuario" %>

<%@ Register TagPrefix="CuteWebUI" Namespace="CuteWebUI" Assembly="CuteWebUI.AjaxUploader" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

                <%-- GV- CSSyJS - INICIO --%>
        <link href="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/css/footable.min.css" rel="stylesheet" type="text/css" />
        <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
        <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/js/footable.min.js"></script>
        <script type="text/javascript">
            $(function () {
                $('[id*=gvUsuario]').footable();
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
                    $('[id*=gvUsuario]').footable();
                });
            });
        </script>


    <%--<script runat="server">
	void InsertMsg(string msg)
	{
		ListBoxEvents.Items.Insert(0, msg);
		ListBoxEvents.SelectedIndex = 0;
	}

	protected override void OnInit(EventArgs e)
	{
		base.OnInit(e);

		SubmitButton.Attributes["onclick"] = "return submitbutton_click()";
	}

	void ButtonPostBack_Click(object sender, EventArgs e)
	{
		InsertMsg("You clicked a PostBack Button.");
	}

	void SubmitButton_Click(object sender, EventArgs e)
	{

		InsertMsg("You clicked the Submit Button.");
		InsertMsg("You have uploaded " + uploadcount + "/" + UploadAttachments1.Items.Count + " files.");
	}

	int uploadcount = 0;

	void Uploader_FileUploaded(object sender, UploaderEventArgs args)
	{

		uploadcount++;

		InsertMsg("File uploaded! " + args.FileName + ", " + args.FileSize + " bytes.");

		//Copys the uploaded file to a new location.
		//args.CopyTo(path);
		//You can also open the uploaded file's data stream.
		//System.IO.Stream data = args.OpenStream();
	}

</script>--%>


        <div id="tabs-1">
            <br />
            <asp:UpdatePanel ID="upnlTotal" runat="server">
                <ContentTemplate>
                    <asp:Panel ID="pnlTab1" runat="server">
                        <br />
                        <hr />
                            <h4>Listado de Usuarios</h4>
                        <hr />
                        <br />
                        <asp:Button runat="server" ID="btnAgregar" CssClass="btn btn-default" Text="Agregar" OnClick="btnAgregar_Click"/>
                        <br /><p></p>
                        <br />
                        <asp:Button runat="server" ID="btnCargaMasiva" CssClass="btn btn-default" Text="Carga Masiva" OnClick="btnCargaMasiva_Click"/>
                        <br /><p></p>
                        <div>
                    <asp:GridView ID="gvUsuario" runat="server" AutoGenerateColumns="False" AllowPaging="true"
                        PageSize="50" CssClass="footable" Align="Center" OnRowDeleting="gvUsuario_RowDeleting" DataKeyNames="idUsr"  OnPageIndexChanging="gvUsuario_PageIndexChanging" OnRowEditing="gvUsuario_RowEditing">
                        <Columns> 

                            <asp:BoundField DataField="idUsr" ItemStyle-HorizontalAlign="Center" HeaderText="Identificador del Usuario" />
                            <asp:BoundField DataField="apellido" HeaderText="Apellido" />
                            <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="rol" HeaderText="Rol" />
                            <asp:BoundField DataField="tipoDoc" HeaderText="Tipo Documento" />
                            <asp:BoundField DataField="nroDoc" HeaderText="Nro. Documento" />
                            <asp:BoundField DataField="email" HeaderText="Email" />
                            <asp:BoundField DataField="telefono" HeaderText="Teléfono" />

                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblIdRol" Text='<% #Eval("idRol") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:CommandField HeaderText="Modificar" EditText="Modificar" ShowEditButton="true" ShowCancelButton="false"  />
                            

                        </Columns>
                    <PagerStyle CssClass="GridView" HorizontalAlign="Center" />
                    </asp:GridView>
                        </div>
                        <br />
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>

            

        </div>

    <%--<div class="content">
			<h2>Drag Drop File (HTML5 Only)</h2>
			<p>
				This sample shows you how to accept the files from drag&amp;drop.
			</p>
			<div id="DropPanel" style="border-style: dashed; border-width: 3px; border-color: gray; margin: 20px 0; padding: 50px 10px; text-align: center;">

				<p style="font-size: 25px;">
					Please drag and drop files into this panel
				</p>
				<p>
					Or:
				</p>
				<p>
					<button id="InsertButton">Browse Files (Max 1M)</button>
				</p>

			</div>

			<CuteWebUI:UploadAttachments runat="server" ManualStartUpload="true" ID="UploadAttachments1"
				InsertButtonID="InsertButton" QueuePanelID="QueuePanel" DropZoneID="DropPanel" OnFileUploaded="Uploader_FileUploaded">
				<ValidateOption MaxSizeKB="1024" />
			</CuteWebUI:UploadAttachments>
			<p id="QueuePanel">
			</p>
			<p>
				<asp:Button runat="server" ID="SubmitButton" Text="Submit" OnClick="SubmitButton_Click" />
			</p>
			<p>
				<asp:ListBox runat="server" ID="ListBoxEvents" />
			</p>
			<asp:Button ID="ButtonPostBack" Text="This is a PostBack button" runat="server" OnClick="ButtonPostBack_Click" />

			<script type="text/javascript">
			    var fileuploaded = false;
			    var submitbutton = document.getElementById('<%=SubmitButton.ClientID %>');
				function submitbutton_click() {
				    var uploadobj = document.getElementById('<%=Uploader1.ClientID %>');
				    if (fileuploaded)
				        return true;
				    if (uploadobj.getqueuecount() > 0) {
				        uploadobj.startupload();
				    }
				    else {
				        alert("Please browse files for uploading");
				    }
				    return false;
				}
				function CuteWebUI_AjaxUploader_OnPostback() {
				    fileuploaded = true;
				    submitbutton.click();
				    return false;
				}
			</script>

		</div>--%>

    	<div id="tabs-2">
            <br />
            <asp:UpdatePanel ID="upnlTotal2" runat="server" >
                <ContentTemplate>
                    <asp:Panel ID="pnlTab2" Visible="false" runat="server">
                        <br />
                        <div class="form-horizontal">
							    <hr />
							    <h4 id="titleProdAccion" runat="server">Modificar Usuario</h4>
							    <hr />

							    <div class="form-group">
								    <asp:Label runat="server" ID="lblUsuarioId" CssClass="col-md-2 control-label">Identificador del usuario</asp:Label>
								    <div class="col-md-10">
									    <asp:TextBox runat="server" Enabled="false" ID="txtUsuarioId" size="50" CssClass="textAreaBoxInputs" />
								    </div>
							    </div>

                                <div class="form-group">
								    <asp:Label runat="server" ID="lblApellido" CssClass="col-md-2 control-label">Apellido</asp:Label>
								    <div class="col-md-10">
									    <asp:TextBox runat="server" ID="txtApellido" ValidationGroup="producto"  CssClass="form-control" required size="50"  />
								    </div>
							    </div>
							    <div class="form-group">
								    <asp:Label runat="server" ID="lblNombre" CssClass="col-md-2 control-label">Nombre</asp:Label>
								    <div class="col-md-10">
									    <asp:TextBox runat="server" ID="txtNombre" ValidationGroup="producto"  CssClass="form-control" required size="50"  />
								    </div>
							    </div>
                                
                                <div class="form-group">
								    <asp:Label runat="server" ID="lblEmail" CssClass="col-md-2 control-label">Email</asp:Label>
								    <div class="col-md-10">
									    <asp:TextBox runat="server" ID="txtMail" ValidationGroup="producto"  CssClass="form-control" required size="50"  />
								    </div>
							    </div>

                            <div class="form-group">
            <asp:Label runat="server" ID="lblRol" CssClass="col-md-2 control-label" >Es</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="ddlRol" AutoPostBack="true" OnSelectedIndexChanged="ddlRol_SelectedIndexChanged" runat="server" CssClass="form-control" required Width="270px">
                    <asp:ListItem   Text="Administrador" Value="1" />
                    <asp:ListItem  Selected="True" Text="Conductor" Value="2" />
                        <asp:ListItem Text="Propietario" Value="3" />
                        <asp:ListItem Text="Conductor y Propietario" Value="4" />
                </asp:DropDownList> 
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlRol"
                    CssClass="text-danger" ErrorMessage="El campo Rol es obligatorio." />
            </div>
        </div>

                                <div class="form-group">
								    <asp:Label runat="server" ID="lblTipoDocumento" CssClass="col-md-2 control-label">Tipo Documento</asp:Label>
								    <div class="col-md-10">
									    <asp:DropDownList runat="server" ID="ddlTipoDocumento" ValidationGroup="producto"  CssClass="form-control" Width="200px" required   >
                                            <asp:ListItem Text="DNI" Value="DNI"></asp:ListItem>
                                            <asp:ListItem Text="CUIT" Value="CUIT" />
									    </asp:DropDownList>
								    </div>
							    </div>

                                <div class="form-group">
								    <asp:Label runat="server" ID="lblNumeroDocumento" CssClass="col-md-2 control-label">Nro. Documento</asp:Label>
								    <div class="col-md-10">
									    <asp:TextBox runat="server" ID="txtNroDocumento" ValidationGroup="producto"  CssClass="form-control" required size="8"  />
								    </div>
							    </div>

							    <div class="form-group">
								    <asp:Label runat="server" ID="lblDireccion" CssClass="col-md-2 control-label">Dirección</asp:Label>
								    <div class="col-md-10">
									    <asp:TextBox runat="server" ID="txtDireccion" ValidationGroup="producto" required size="200" CssClass="form-control" />
								    </div>
							    </div>

                            <div class="form-group">
								    <asp:Label runat="server" ID="lblTelefono" CssClass="col-md-2 control-label">Teléfono</asp:Label>
								    <div class="col-md-10">
									    <asp:TextBox runat="server" ID="txtTelefono" ValidationGroup="producto" size="15" CssClass="form-control" />
								    </div>
							    </div>

                            <div class="form-group">
								    <asp:Label runat="server" ID="lblCuil" CssClass="col-md-2 control-label">CUIL</asp:Label>
								    <div class="col-sm-3">

									    <asp:TextBox runat="server" ID="txtCuil" ValidationGroup="producto" size="15" numeric CssClass="form-control" />
                                    </div>
                                    <div class="col-xs-1">
                                        <asp:Button runat="server" ID="btnValidar" formnovalidate Text="Validar"  OnClick="btnValidar_Click" CssClass="form-control" />
                                        <asp:Label ID="lblValicionCuil"  runat="server"></asp:Label>
								    </div>
                                   <div class="col-md-5">
                                       </div>
                                   <div class="col-md-5">
                                       </div>
							    </div>

                            <div id="divConductor" runat="server" visible="false"> 
                                <div class="form-group">
								    <asp:Label runat="server" ID="lblMarca" CssClass="col-md-2 control-label">Marca</asp:Label>
								    <div class="col-md-10">
									    <asp:TextBox runat="server" ID="txtMarca" ValidationGroup="vehiculo"  CssClass="form-control" size="30"  />
								    </div>
							    </div>
                                <div class="form-group">
								    <asp:Label runat="server" ID="lblModelo" CssClass="col-md-2 control-label">Modelo</asp:Label>
								    <div class="col-md-10">
									    <asp:TextBox runat="server" ID="txtModelo" ValidationGroup="vehiculo"  CssClass="form-control" size="30"  />
								    </div>
							    </div>
                                <div class="form-group">
								    <asp:Label runat="server" ID="lblPatente" CssClass="col-md-2 control-label">Patente</asp:Label>
								    <div class="col-md-10">
									    <asp:TextBox runat="server" ID="txtPatente" ValidationGroup="vehiculo"  CssClass="form-control" size="10"  />
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
