window.onload = function () {
    listarCitas();
}
async function listarCitas() {
    pintar({
        url: "Especialidades/ListarEspecialidades",
        cabeceras: ["ID Especialidad", "Nombre"],
        propiedades: ["id", "nombre"],
        editar: true,
        eliminar: true,
        propiedadId: "id"
    });
}