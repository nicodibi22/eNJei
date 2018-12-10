<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CtaCteHist.aspx.cs" Inherits="UI.CtaCteHist" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>:: Movimientos de la cuenta ::</title>
        <link href="Content/gridView.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
  
    <br />
        <h1 runat="server" id="h1PurchaseOrderDetail" align="center">Histórico de operaciones de su Cta. Cte.</h1>
    <br />
    <asp:GridView ID="gvHistCtaCte" CssClass="MyGridView"  BorderColor="WhiteSmoke" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" OnPageIndexChanging="gvHistCtaCte_PageIndexChanging">
        <Columns>
            
            <asp:TemplateField HeaderText = "Fecha de la operación" ItemStyle-HorizontalAlign="Right">
                <ItemTemplate>
                    <asp:Label ID="lblfechaOperacion"  runat="server" Text='<%# Eval("fechaOperacion", "{0:dd/MM/yyyy}")%>'></asp:Label>
                </ItemTemplate>                    
            </asp:TemplateField>

            <asp:TemplateField  HeaderText = "Monto de la operación" ItemStyle-HorizontalAlign="Right">
                <ItemTemplate>
                    <asp:Label ID="lblMondo" style="width: 45px;" Text='<%# String.Format("${0:n2}", Convert.ToDecimal( Eval("monto"))) %>' runat="server" ></asp:Label>
                </ItemTemplate>                    
            </asp:TemplateField>

            <asp:BoundField DataField="tipoOperacion" HeaderText="Tipo de operación" />

        </Columns>
    </asp:GridView>
    <br />
     <asp:Button runat="server" ID="btnClose" Text="::Cerrar::" OnClick="btnClose_Click" Width="100" Height="40" />
    <br />
    <asp:Label ID="lblNODATAFOUND" Font-Size="XX-Large" Font-Bold="false" ForeColor="OrangeRed" runat="server" 
                    Visible="false">No hay información para mostrar.</asp:Label>

    </div>
    </form>
    
</body>
</html>
