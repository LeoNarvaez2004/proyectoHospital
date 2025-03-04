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

async function guardar() {
    let form = document.getElementById("frmOperaciones");
    let frm = new FormData(form);
    confirmacion(undefined, "¿Seguro desea actualizar?", function (resp) {
        fetchPost("Tratamientos/GuardarTratamiento", "json", frm, function (res) {
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
        fetchGet("Tratamientos/RecuperarTratamiento/?id=" + id, "json", function (data) {
            setN("id", data.id);
            setN("pacienteId", data.pacienteId);
            setN("descripcion", data.descripcion);
            setN("fecha", data.fecha);
            setN("costo", data.costo);

        });
    }
    else {
        limpiarForm();
        setN("id", id);
    }

}

function Eliminar(id) {
    fetchGet("Tratamientos/EliminarTratamiento/?id=" + id, "json", function (data) {
        confirmacion(undefined, "¿Seguro desea eliminar?", function (resp) {
            limpiarForm();
            Exito();
        });
    });
}

function limpiarForm() {
    limpiarDatos("frmOperaciones");
    listarTratamientos();
}