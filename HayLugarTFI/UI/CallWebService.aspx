<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CallWebService.aspx.cs" Inherits="UI.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Servicios</h2>

    <%-- GV- CSSyJS - INICIO --%>
        <link href="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/css/footable.min.css" rel="stylesheet" type="text/css" />
        <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
        <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/js/footable.min.js"></script>
        <script type="text/javascript">
        $(function () {
            $('[id*=gvZonas]').footable();
        });
        </script>

            <script type="text/javascript">
                var prm = Sys.WebForms.PageRequestManager.getInstance();
                prm.add_endRequest(function () {
                    $(function () {
                        $('[id*=gvZonas]').footable();
                    });
                });
        </script>
    <%-- GV- CSSyJS - FIN --%>

    <br/>
    <hr />
	<h4>Listado - Zonas.</h4>
	<hr />
    <asp:UpdatePanel ID="upPanel" runat="server">
        <ContentTemplate>
	        <div class="form-group">

                <asp:GridView ID="gvZonas" CssClass="footable"  runat="server" AutoGenerateColumns="False" AllowPaging="true"
                    PageSize="50" Align="Center" OnPageIndexChanging="gvZonas_PageIndexChanging">
                        <Columns> 
                            <asp:BoundField DataField="idZona" HeaderText="Código Zona" />

                            <asp:BoundField DataField="descripcion" HeaderText="Descripción" />

                        </Columns>
                    <PagerStyle CssClass="GridView" HorizontalAlign="Center" />
                    </asp:GridView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>
