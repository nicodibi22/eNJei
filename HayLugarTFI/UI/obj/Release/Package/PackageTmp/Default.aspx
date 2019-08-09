<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UI._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        
        .MessagePanel
        {
            
            width:55%;
            z-index:1000;
        }
    
    </style>
<div id="principal"  style="width: 60%; margin: 0px auto;"  >
<br />
<br />
    <h4>Bienvenidos a Hay Lugar!</h4>
    <p>En este momento hay:</p>
    <div class="MessagePanel">
    <asp:Panel runat="server" id="divHora" class="alert alert-primary" role="alert">
      <asp:Label runat="server" ID="lblPlazasHora" Text="{0} plazas disponibles por hora"></asp:Label>
    </asp:Panel>
    <asp:Panel  runat="server" id="divDiario" class="alert alert-primary" role="alert">
      <asp:Label runat="server" ID="lblPlazasDia" Text="{0} plazas disponibles por día"></asp:Label>
    </asp:Panel>
    </div>
    
<br />
<hr />
    <h2 style="text-align:center"  >Hay lugar!</h2>
    <br />
    <h3 style="width: 60%; margin: 0px auto;"  >TFI 2018 - Sandra Biondini</h3>

<hr />
<br />
</div>

</asp:Content>
