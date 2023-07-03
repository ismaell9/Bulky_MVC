var dataTable;
$(document).ready(function () {
    loadDataTable();
});
function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/product/getall'},
        "columns": [
            { data: 'title' , "width": "25%"},
            { data: 'isbn', "width": "15%" },
            { data: 'price', "width": "10%" },
            { data: 'author', "width": "15%" },
            { data: 'category.name', "width": "10%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                     <a href="/admin/product/upsert?id=${data}" class="btn btn-primary mx-2"> <i class="fa-solid fa-pen-to-square"></i>&nbsp; Edit</a>               
                     <a onClick=Delete('/admin/product/delete/${data}') class="btn btn-danger mx-2"> <i class="fa-solid fa-trash"></i>&nbsp; Delete</a>
                    </div>`
                },
                "width": "25%"
            }
        ]
    });
}

function Delete(url) {
    swal({
        title: "Are you sure?",
        text: "Once deleted, you will not be able to recover this Record!",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    })
        .then((willDelete) => {
            if (willDelete) {
            $.ajax({
                url: url,
                type: 'delete',
                success: function (data) {
                    dataTable.ajax.reload();
                    toastr.success(data.message);
                }
            })

            } else {
                swal("Delete Canceled!");
            }
        });
}
