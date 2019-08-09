<%@ Page Title="Registrarse" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="UI.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    
    <script type="text/javascript">
    $(function () {
        $("#chkShowPassword").bind("click", function () {
            var txtPassword = $("[id*=txtPassword]");
            var txtConfirmPassword = $("[id*=txtConfirmPassword]");
            if ($(this).is(":checked")) {
                txtPassword.after('<input onchange = "PasswordChanged(this);" id = "txt_' + txtPassword.attr("id") + '" type = "text" class="form-control" value = "' + txtPassword.val() + '" />');
                txtPassword.hide();
                txtConfirmPassword.after('<input onchange = "PasswordChanged(this);" id = "txt_' + txtConfirmPassword.attr("id") + '" type = "text" class="form-control" value = "' + txtConfirmPassword.val() + '" />');
                txtConfirmPassword.hide();
            } else {
                txtPassword.val(txtPassword.next().val());
                txtPassword.next().remove();
                txtPassword.show();
                txtConfirmPassword.val(txtConfirmPassword.next().val());
                txtConfirmPassword.next().remove();
                txtConfirmPassword.show();
            }
        });
    });
    function PasswordChanged(txt) {
        $(txt).prev().val($(txt).val());
    }


    </script>
    
    <div class="container">
    <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Crear una nueva cuenta</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Correo electrónico</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" pattern="[a-zA-Z0-9_]+([.][a-zA-Z0-9_]+)*@[a-zA-Z0-9_]+([.][a-zA-Z0-9_]+)*[.][a-zA-Z]{1,5}"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                    CssClass="text-danger" ErrorMessage="El campo de correo electrónico es obligatorio." />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" ID="lblRol" CssClass="col-md-2 control-label" >Soy</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="ddlRol" AutoPostBack="false" runat="server" CssClass="form-control" Width="270px">
                        <asp:ListItem  Selected="True" Text="Conductor" Value="2" />
                        <asp:ListItem Text="Propietario" Value="3" />
                        <asp:ListItem Text="Conductor y Propietario" Value="4" />
                </asp:DropDownList> 
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlRol"
                    CssClass="text-danger" ErrorMessage="El campo de contraseña es obligatorio." />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtPassword" CssClass="col-md-2 control-label">Contraseña</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPassword"
                    CssClass="text-danger" ErrorMessage="El campo de contraseña es obligatorio." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtConfirmPassword" CssClass="col-md-2 control-label">Confirmar contraseña</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtConfirmPassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="El campo de confirmación de contraseña es obligatorio." />
                <asp:CompareValidator runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="La contraseña y la contraseña de confirmación no coinciden." />
            </div>
        </div>
        <label for="chkShowPassword">
                        <input type="checkbox" id="chkShowPassword" />Mostrar contraseña</label>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="CreateUser_Click" Text="Registrarse" CssClass="btn btn-secondary" />
            </div>
        </div>
    </div>
                    <asp:Label runat="server" id="lblErrorMail"></asp:Label>

        </div>
</asp:Content>
