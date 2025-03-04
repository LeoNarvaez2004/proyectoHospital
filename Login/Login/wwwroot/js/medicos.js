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