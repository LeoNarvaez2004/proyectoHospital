window.onload = function () {
    listarCitas();
}

async function listarCitas() {
    pintar({
        url: "Citas/ListarCitas",
        cabeceras: ["ID Cita", "Paciente ID", "Medico ID", "Fecha", "Estado"],
        propiedades: ["idCita", "idPaciente", "idMedico", "fecha", "estado"],
        editar: true,
        eliminar: true,
        propiedadId: "idCita"
    });
}

async function guardar() {
    let form = document.getElementById("frmOperaciones");
    let frm = new FormData(form);
    confirmacion(undefined, undefined, function (resp) {
        fetchPost("Citas/guardarCita", "json", frm, function (res) {
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
        fetchGet("Citas/recuperarCitas/?id=" + id, "json", function (data) {
            setN("idCita", data.idCita);
            setN("idPaciente", data.idPaciente);
            setN("idMedico", data.idMedico);
            setN("fecha", data.fecha);
            setN("estado", data.estado);
        });
    }
    else {
        limpiarForm();
        setN("idCita", id);
    }

}

function Eliminar(id) {
    fetchGet("Citas/EliminarCita/?id=" + id, "json", function (data) {
        confirmacion(undefined, "¿Seguro desea eliminar?", function (resp) {
            limpiarForm();
            Exito();
        });
    });
}

function limpiarForm() {
    limpiarDatos("frmOperaciones");
    listarCitas();
}