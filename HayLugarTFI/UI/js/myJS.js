$(document).ready(function () {
    //agregar una nueva columna con todo el texto 
    //contenido en las columnas de la grilla 
    // contains de Jquery es CaseSentive, por eso a minúscula
    $(".footable tr:has(td.filtro)").each(function () {
        var t = $(this).text().toLowerCase();
        $("<td class='indexColumn'></td>")
        .hide().text(t).appendTo(this);
    });
    //Agregar el comportamiento al texto (se selecciona por el ID) 
    $("#texto").keyup(function () {
        var s = $(this).val().toLowerCase().split(" ");
        $(".footable tr:hidden").show();
        $.each(s, function () {
            $(".footable tr:visible .indexColumn:not(:contains('"
            + this + "'))").parent().hide();
        });
    });
});