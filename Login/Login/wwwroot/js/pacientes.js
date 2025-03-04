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