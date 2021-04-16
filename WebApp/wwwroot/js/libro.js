var dataTable;

$(document).ready(function () {
    cargarDataTable();
});

function cargarDataTable() {
    dataTable = $("#tblLibros").DataTable({
        "ajax": {
            "url": "/admin/libro/listar",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "nombre", "width": "15%" },
            { "data": "isbn", "width": "15%" },
            { "data": "autor", "width": "15%" },
            { "data": "precio", "width": "15%" },
            { "data": "categoria.nombre", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <div class="text-center">
                                <a href="/admin/libro/upsert?id=${data}" class='btn btn-sm btn-success text-white' style='cursor:pointer;'>
                                    <i class="fa fa-edit"></i>
                                </a>
                                &nbsp;
                                <a onclick="Borrar('/admin/libro/borrar?id=${data}')" class="btn btn-sm btn-danger text-white" style='cursor:pointer;'>
                                    <i class="fa fa-trash-alt"></i>
                                </a>
                            </div>
                           `;
                }
            }
        ],
        "language": {
            "lengthMenu": "Desplegando _MENU_ registros por página",
            "zeroRecords": "Lo sentimos, no se han encontrado registros.",
            "info": "Mostrando página _PAGE_ de _PAGES_",
            "infoEmpty": "No hay registros disponibles.",
            "infoFiltered": "(filtrado de _MAX_ registros.)",
            "loadingRecords": "Cargando...",
            "processing": "Procesando...",
            "search": "Filtrar:",
            "paginate": {
                "first": "Primero",
                "last": "Ultimo",
                "next": "Siguiente",
                "previous": "Anterior"
            }
        },
        "width": "100%"
    });
}

function Borrar(url) {
    swal({
        title: "¿Está seguro?",
        text: "Una vez borrado, no será posible recuperarlo.",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((result) => {
        if (result) {
            $.ajax({
                url: url,
                type: "DELETE",
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}