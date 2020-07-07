<%@ Page Title="Administrar contraseña" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManagePassword.aspx.cs" Inherits="UI.Account.ManagePassword" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
        
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<script type="text/javascript">

    $(function () {
        $("#chkShowPassword").bind("click", function () {
            var txtPassword = $("[id*=txtNewPassword]");
            var txtPasswordConfirm = $("[id*=txtConfirmNewPassword]");
            if ($(this).is(":checked")) {
                txtPassword.after('<input onchange = "PasswordChanged(this);" id = "txt_' + txtPassword.attr("id") + '" type = "text" class="form-control" value = "' + txtPassword.val() + '" />');
                txtPassword.hide();
                txtPasswordConfirm.after('<input onchange = "PasswordChanged(this);" id = "txt_' + txtPasswordConfirm.attr("id") + '" type = "text" class="form-control" value = "' + txtPasswordConfirm.val() + '" />');
                txtPasswordConfirm.hide();
            } else {
                txtPassword.val(txtPassword.next().val());
                txtPassword.next().remove();
                txtPassword.show();
                txtPasswordConfirm.val(txtPasswordConfirm.next().val());
                txtPasswordConfirm.next().remove();
                txtPasswordConfirm.show();
            }
        });
    });
    function PasswordChanged(txt) {
        $(txt).prev().val($(txt).val());
    }


</script>

    
    <h2><%: Title %>.</h2>
    <div class="form-horizontal">
        <section id="passwordForm">
            <asp:PlaceHolder runat="server" ID="setPassword" Visible="false">
                <p>
                    No dispone de una contraseña local para este sitio. Agregue una contraseña
                        local para poder iniciar sesión sin necesidad de un inicio de sesión externo.
                </p>
                <div class="form-horizontal">
                    <h4>Formulario para establecer contraseña</h4>
                    <asp:ValidationSummary runat="server" ShowModelStateErrors="true" CssClass="text-danger" />
                    <hr />
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtPasswordOriginal" CssClass="col-md-2 control-label">Contraseña</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="txtPasswordOriginal" TextMode="Password" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPasswordOriginal"
                                CssClass="text-danger" ErrorMessage="El campo de contraseña es obligatorio."
                                Display="Dynamic" ValidationGroup="SetPassword" />
                            <asp:ModelErrorMessage runat="server" ModelStateKey="NewPassword" AssociatedControlID="txtPasswordOriginal"
                                CssClass="text-danger" SetFocusOnError="true" />
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtPasswordConfirm" CssClass="col-md-2 control-label">Confirmar contraseña</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="txtPasswordConfirm" TextMode="Password" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPasswordConfirm"
                                CssClass="text-danger" Display="Dynamic" ErrorMessage="El campo de confirmación de contraseña es obligatorio."
                                ValidationGroup="SetPassword" />
                            <asp:CompareValidator runat="server" ControlToCompare="txtPasswordOriginal" ControlToValidate="txtPasswordConfirm"
                                CssClass="text-danger" Display="Dynamic" ErrorMessage="La contraseña y la contraseña de confirmación no coinciden."
                                ValidationGroup="SetPassword" />

                        </div>
                    </div>
                    
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" Text="Establecer contraseña" ValidationGroup="SetPassword" OnClick="SetPassword_Click" CssClass="btn btn-default" />
                        </div>
                    </div>
                </div>
            </asp:PlaceHolder>

            <asp:PlaceHolder runat="server" ID="changePasswordHolder" Visible="false">
                <div class="form-horizontal">
                    <h4>Formulario para cambiar contraseña</h4>
                    <hr />
                    <asp:ValidationSummary runat="server" ShowModelStateErrors="true" CssClass="text-danger" />
                    <div class="form-group">
                        <asp:Label runat="server" ID="CurrentPasswordLabel" AssociatedControlID="CurrentPassword" CssClass="col-md-2 control-label">Contraseña actual</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="CurrentPassword" TextMode="Password" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="CurrentPassword"
                                CssClass="text-danger" ErrorMessage="El campo de contraseña actual es obligatorio."
                                ValidationGroup="ChangePassword" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" ID="NewPasswordLabel" AssociatedControlID="txtNewPassword" CssClass="col-md-2 control-label">Nueva contraseña</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="txtNewPassword" TextMode="Password" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNewPassword"
                                CssClass="text-danger" ErrorMessage="La contraseña nueva es obligatoria."
                                ValidationGroup="ChangePassword" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" ID="ConfirmNewPasswordLabel" AssociatedControlID="txtConfirmNewPassword" CssClass="col-md-2 control-label">Confirmar la nueva contraseña</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="txtConfirmNewPassword" TextMode="Password" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtConfirmNewPassword"
                                CssClass="text-danger" Display="Dynamic" ErrorMessage="La confirmación de la nueva contraseña es obligatoria."
                                ValidationGroup="ChangePassword" />
                            <asp:CompareValidator runat="server" ControlToCompare="txtNewPassword" ControlToValidate="txtConfirmNewPassword"
                                CssClass="text-danger" Display="Dynamic" ErrorMessage="La nueva contraseña y la contraseña de confirmación no coinciden."
                                ValidationGroup="ChangePassword"  />
                        </div>

                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                    <label for="chkShowPassword">
                    <input type="checkbox" id="chkShowPassword" />Mostrar contraseñas</label>
                            </div>
                        </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" Text="Cambiar contraseña" ValidationGroup="ChangePassword" OnClick="ChangePassword_Click" CssClass="btn btn-default" />
                        </div>
                    </div>
                </div>
            </asp:PlaceHolder>
        </section>
    </div>
</asp:Content>
