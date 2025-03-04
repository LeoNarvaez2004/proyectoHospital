window.onload = function () {
    listarTratamientos();
}
async function listarTratamientos() {
    pintar({
        url: "Tratamientos/ListarTratamientos",
        cabeceras: ["ID Tratamiento", "Id Paciente", "Descripcion", "fecha", "costo"],
        propiedades: ["id", "pacienteId", "descripcion", "fecha", "costo"],
        editar: true,
        eliminar: true,
        propiedadId: "id"
    });
}