window.onload = function () {
    listarMedicos();
}
async function listarMedicos() {
    pintar({
        url: "Medicos/ListarMedicos",
        cabeceras: ["ID Medico", "Nombre", "Apellido", "Id Epecialidad", "Telefono", "email"],
        propiedades: ["id", "nombre", "apellido", "especialidadId", "telefono", "email"],
        editar: true,
        eliminar: true,
        propiedadId: "id"
    });
}

async function guardar() {
    let form = document.getElementById("frmOperaciones");
    let frm = new FormData(form);
    confirmacion(undefined, undefined, function (resp) {
        fetchPost("Medicos/GuardarMedico", "json", frm, function (res) {
            if (res == -1) {
                ErrorA();
                return;
            }
            limpiarForm();
            Exito();
        });

    });
}

function Editar(id) {
    if (id != 0) {
        fetchGet("Medicos/RecuperarMedico/?id=" + id, "json", function (data) {
            setN("id", data.id);
            setN("nombre", data.nombre);
            setN("apellido", data.apellido);
            setN("especialidadId", data.especialidadId);
            setN("telefono", data.telefono);
            setN("email", data.email);

        });
    }
    else {
        limpiarForm();
        setN("id", id);
    }

}

function Eliminar(id) {
    fetchGet("Medicos/EliminarMedico/?id=" + id, "json", function (data) {
        confirmacion(undefined, "¿Seguro desea eliminar?", function (resp) {
            if (data == -1) {
                ErrorA("No se puede eliminar, por dependencia con otras tablas");
                return;
            }
            limpiarForm();
            Exito();
        });
    });
}

function limpiarForm() {
    limpiarDatos("frmOperaciones");
    listarMedicos();
}