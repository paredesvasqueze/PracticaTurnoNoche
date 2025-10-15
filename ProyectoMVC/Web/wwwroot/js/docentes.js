function abrirFormularioDocente(id = 0) {
    $.get(`/DocentesAjax/Form?id=${id}`, function (html) {
        $("#contenidoModalDocente").html(html);
        $("#modalDocente").modal("show");
    });
}

function guardarDocente() {
    const docente = {
        IdDocente: parseInt($("#IdDocente").val()) || 0,
        IdColegio: parseInt($("#IdColegio").val()),
        Nombres: $("#Nombres").val(),
        Apellidos: $("#Apellidos").val(),
        DNI: $("#DNI").val(),
        Email: $("#Email").val(),
        Telefono: $("#Telefono").val(),
        Especialidad: $("#Especialidad").val(),
        FechaIngreso: $("#FechaIngreso").val(),
        Estado: $("#Estado").is(":checked")
    };

    $.ajax({
        url: '/DocentesAjax/Guardar',
        method: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(docente),
        success: function (resp) {
            if (resp.success) location.reload();
            else alert(resp.message);
        }
    });
}

function eliminarDocente(id) {
    if (!confirm("¿Desea eliminar este docente?")) return;

    $.post('/DocentesAjax/Eliminar', { id }, function (resp) {
        if (resp.success) location.reload();
        else alert(resp.message);
    });
}
