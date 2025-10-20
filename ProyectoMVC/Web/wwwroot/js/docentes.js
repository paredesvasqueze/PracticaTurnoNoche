// =======================
// DOCENTES AJAX (versión final)
// =======================

// --- Abrir el formulario en el modal ---
function abrirFormularioDocente(id = 0) {
    $.get(`/DocentesAjax/Form?id=${id}`, function (html) {
        $("#contenidoModalDocente").html(html);

        // Bootstrap 5 o 4 compatible
        if (typeof bootstrap !== 'undefined' && bootstrap.Modal) {
            const modal = new bootstrap.Modal(document.getElementById("modalDocente"));
            modal.show();
        } else {
            $("#modalDocente").modal("show");
        }
    }).fail(function () {
        alert("⚠️ Error al cargar el formulario del docente.");
    });
}


// --- Guardar o actualizar ---
function guardarDocente() {
    const docente = {
        IdDocente: parseInt($("#IdDocente").val()) || 0,
        IdColegio: parseInt($("#IdColegio").val()) || 0,
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
            if (resp.success) {
                cerrarModalDocente();
                alert(docente.IdDocente === 0 ? "✅ Docente agregado correctamente." : "✅ Docente actualizado correctamente.");
                recargarTablaDocentes(); // recarga parcial sin refrescar página
            } else {
                alert(resp.message || "❌ Error al guardar el docente.");
            }
        },
        error: function () {
            alert("⚠️ Error inesperado al guardar el docente.");
        }
    });
}


// --- Eliminar ---
function eliminarDocente(id) {
    if (!confirm("¿Desea eliminar este docente?")) return;

    $.post('/DocentesAjax/Eliminar', { id }, function (resp) {
        if (resp.success) {
            alert("🗑️ Docente eliminado correctamente.");
            recargarTablaDocentes();
        } else {
            alert(resp.message || "❌ Error al eliminar el docente.");
        }
    }).fail(function () {
        alert("⚠️ Error inesperado al eliminar el docente.");
    });
}


// --- Recargar tabla sin refrescar toda la página ---
function recargarTablaDocentes() {
    $.get('/DocentesAjax/Tabla', function (html) {
        $("#tablaDocentesBody").html(html);
    }).fail(function () {
        alert("⚠️ Error al recargar la lista de docentes.");
    });
}


// --- Cerrar modal ---
function cerrarModalDocente() {
    if (typeof bootstrap !== 'undefined' && bootstrap.Modal) {
        const modalEl = document.getElementById("modalDocente");
        const modal = bootstrap.Modal.getInstance(modalEl);
        if (modal) modal.hide();
    } else {
        $("#modalDocente").modal("hide");
    }
}
