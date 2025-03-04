window.onload = function () {
    listarCitas();
}

async function listarCitas() {
    pintar({
        url: "Citas/ListarCitas",
        cabeceras: ["ID Cita", "Paciente ID", "Medico ID", "Fecha", "Estado"],
        propiedades: ["idCita", "idPaciente", "idMedico", "fecha", "estado"],
        divContenedor: "divContenedor",
        editar: true,
        eliminar: true,
        propiedadId: "idCita"

    });
}