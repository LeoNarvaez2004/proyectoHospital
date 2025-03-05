window.onload = function () {
    listarPacientes();
}
async function listarPacientes() {
    pintar({
        url: "Pacientes/ListarPacientes",
        cabeceras: ["ID Paciente", "Nombre", "Apellido", "Fecha de nacimiento", "Telefono", "email", "direccion"],
        propiedades: ["id", "nombre", "apellido", "fechaNacimiento", "telefono", "email", "direccion"],
        editar: true,
        eliminar: true,
        propiedadId: "id"
    });
}

async function guardar() {
    let form = document.getElementById("frmOperaciones");
    let frm = new FormData(form);
    confirmacion(undefined, undefined, function (resp) {
        fetchPost("Pacientes/GuardarPaciente", "json", frm, function (res) {
            if (res == 0) {
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
        fetchGet("Pacientes/RecuperarPaciente/?id=" + id, "json", function (data) {
            setN("id", data.id);
            setN("nombre", data.nombre);
            setN("apellido", data.apellido);
            setN("fechaNacimiento", data.fechaNacimiento);
            setN("telefono", data.telefono);
            setN("email", data.email);
            setN("direccion", data.direccion);

        });
    }
    else {
        limpiarForm();
        setN("id", id);
    }

}

function Eliminar(id) {
    fetchGet("Pacientes/EliminarPaciente/?id=" + id, "json", function (data) {
        confirmacion(undefined, "¿Seguro desea eliminar?", function (resp) {
            limpiarForm();
            Exito();
        });
    });
}

function limpiarForm() {
    limpiarDatos("frmOperaciones");
    listarPacientes();
}