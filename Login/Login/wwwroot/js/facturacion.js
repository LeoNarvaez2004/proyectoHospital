window.onload = function () {
    listarFacturacion();
}
async function listarFacturacion() {
    pintar({
        url: "Facturacion/ListarFacturaciones",
        cabeceras: ["ID Facturacion", "Id Paciente", "Monto", "Metodo Pago", "Fecha Pago"],
        propiedades: ["id", "pacienteId", "monto", "metodoPago", "fechaPago"],
        editar: true,
        eliminar: true,
        propiedadId: "id"
    });
}