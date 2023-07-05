var dataTable;
$(document).ready(function () {
    loadDataTable();
});
function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/user/getall' },
        "columns": [
            { data: 'name', "width": "25%" },
            { data: 'email', "width": "10%" },
            { data: 'phoneNumber', "width": "10%" },
            { data: 'company.name', "width": "10%" },
            { data: 'role', "width": "10%" },
            {
                data: { id : 'id', lockoutEnd:'lockoutEnd' },
                "render": function (data) {
                    var today = new Date().getTime();
                    var lockout = new Date(data.lockoutEnd).getTime();
                    if (lockout > today) {
                        return `<div class="text-center">
                            <a onclick=LockUnlock('${data.id}') class="btn btn-danger text-white" style="cursor: pointer; width=100px;" > 
                                <i class="fa-solid fa-lock"></i> Locked
                            </a>       

                            <a href="/admin/user/RoleManagment?userId=${data.id}" class="btn btn-danger text-white" style="cursor: pointer; width=100px;" > 
                               <i class="fa-solid fa-pen-to-square"></i> Permission
                            </a>  
                        </div>`
                    }
                    else {
                        return `<div class="text-center">
                            
                            <a onclick=LockUnlock('${data.id}') class="btn btn-success text-white" style="cursor: pointer; width=100px;" > 
                                <i class="fa-solid fa-unlock"></i> Unlocked
                            </a>  
                            <a href="/admin/user/RoleManagment?userId=${data.id}" class="btn btn-danger text-white" style="cursor: pointer; width=100px;" > 
                               <i class="fa-solid fa-pen-to-square"></i> Permission
                            </a>  
                        </div>`
                    }
                    
                },
                "width": "25%"
            }
        ]
    });
}
function LockUnlock(id) {
    $.ajax({
        type : "POST",
        url: '/Admin/User/LockUnlock',
        data: JSON.stringify(id),
        contentType: "application/json",
        success: function (data) {
            if (data.success) {
                toastr.success(data.message);
                dataTable.ajax.reload();
            }
        }
    })
}