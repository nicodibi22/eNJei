<%@ Page Title="Ingresar" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UI.Account.Login" Async="true" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<script type="text/javascript">
    $(function () {
        $("#chkShowPassword").bind("click", function () {
            var txtPassword = $("[id*=txtPassword]");
            if ($(this).is(":checked")) {
                txtPassword.after('<input onchange = "PasswordChanged(this);" id = "txt_' + txtPassword.attr("id") + '" type = "text" class="form-control" value = "' + txtPassword.val() + '" />');
                txtPassword.hide();
            } else {
                txtPassword.val(txtPassword.next().val());
                txtPassword.next().remove();
                txtPassword.show();
            }
        });
    });
    function PasswordChanged(txt) {
        $(txt).prev().val($(txt).val());
    }


</script>

    <div class="container">

    <h2> Ingresar </h2>

    <div class="row"> 
        <div class="col-md-8">
            <section id="loginForm">
                    <h4>Use su cuenta para ingresar.</h4>
                    <hr />
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Correo electrónico</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                                CssClass="text-danger" ErrorMessage="El campo de correo electrónico es obligatorio." />
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtPassword" CssClass="col-md-2 control-label">Contraseña</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="form-control" />
                            <asp:RequiredFieldValidator Display="Dynamic" runat="server" ControlToValidate="txtPassword" CssClass="text-danger" ErrorMessage="El campo contraseña es requerido." />
                        </div>
                        <label for="chkShowPassword">
                        <input type="checkbox" id="chkShowPassword" />Mostrar contraseña</label>
                    </div>


                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <div class="checkbox">
                                <asp:CheckBox runat="server" ID="RememberMe" />
                                <asp:Label runat="server" AssociatedControlID="RememberMe">¿Recordar cuenta?</asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" OnClick="LogIn" Text="Iniciar sesión" CssClass="btn btn-secondary" />
                            <asp:Button runat="server" OnClick="btnRegistrar_Click" Text="Registrarse" CausesValidation="false" CssClass="btn btn-secondary" />
                        </div>
                    </div>
            </section>
        </div>
    </div>
        </div>
</asp:Content>
