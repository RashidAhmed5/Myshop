var tblVM;
$(function () {
    tblVM = {
        dt: null,

        init: function () {
            dt = $('#tblData').DataTable({
                "fixedHeader": true,
                "sDom": "Rlfrtip",
                "responsive": false,
                "autoWidth": false,
                "processing": true, // for show progress bar
                "serverSide": true, // for process server side
                "filter": true, // this is for disable filter (search box)
                "paging": true,
                "orderMulti": false, // for disable multiple column at once,
                "scrollX": true,
                "ajax": {
                    "url": $("#listUrl").data('request-url'),
                    "type": "GET",
                    "datatype": "json",
                    "data": function (dtp) {
                        var searchValue = dtp.search.value;
                        return dtp;
                    }
                },
                "columns": [
                    { title: "Id", data: "id", searchable: false, sortable: false, visible: false },
                    //{ title: "User Name", data: "userName", searchable: false, sortable: false },
                    { title: "Name", data: "name", searchable: false, sortable: false },
                    { title: "Email", data: "email", searchable: false, sortable: false },
                    { title: "Mobile No", data: "phoneNo", searchable: false, sortable: false },
                    //{ title: "Date Of Birth", data: "dob", searchable: false, sortable: false, },
                    //{ title: "Gender", data: "gender", searchable: false, sortable: false },
                    { title: "Designation", data: "designation", searchable: false, sortable: false },
                    { title: "Department", data: "department", searchable: false, sortable: false },
                    //{ title: "Employment Type", data: "employmentType", searchable: false, sortable: false },
                    //{ title: "Employee No", data: "employeeNo", searchable: false, sortable: false, },
                    //{ title: "UserType", data: "userType", searchable: false, sortable: false },
                    {
                        title: "IsActive", data: "isActive", searchable: false, sortable: false,
                        render: function (data, type, full, meta) {
                            var active = '<div class="badge badge-success">Active</div>';
                            if (full.isActive == 0)
                                active = '<div class="badge badge-danger">Not Active</div>';
                            return active;
                        }
                    },
                    {
                        title: "Actions", data: "id", searchable: false, sortable: false, width: "120px",
                        render: function (data, type, full, meta) {
                            var editUrl = $("#editUrl").data("request-url") + "?id=" + full.id;
                            var deleteUrl = $("#deleteUrl").data("request-url") + "?id=" + full.id;
                            var detailUrl = $("#detailUrl").data("request-url") + "?id=" + full.id;
                            var activateUrl = $("#activateUrl").data("request-url") + "?id=" + full.id + "&isactive=" + full.isActive;

                            var deleteUser = "showInPopup('" + deleteUrl + "', 'Delete Staff')";
                            var detail = "showInPopup('" + detailUrl + "', 'Staff Detail')";

                            var action = "";
                            if ($("#canEdit").val() == "true")
                                action = '<a onclick="' + detail + '"  class="btn btn-view btn-action trigger--fire-modal-1 mr-1" data-toggle="tooltip" data-original-title="Detail"><i class="fas fa-eye"></i></a><a href="' + editUrl + '" class="btn btn-info btn-action mr-1" data-toggle="tooltip" title="" data-original-title="Edit"><i class="fas fa-pencil-alt"></i></a>';
                            if ($("#canDelete").val() == "true")
                                action = action + '<a onclick="' + deleteUser + '"  class="btn btn-danger btn-action trigger--fire-modal-1" data-toggle="tooltip" data-original-title="Delete"><i class="fas fa-trash"></i></a>';

                            return action;

                            //return '<a onclick="' + detail + '"  class="btn btn-view btn-action trigger--fire-modal-1 mr-1" data-toggle="tooltip" data-original-title="Detail"><i class="fas fa-eye"></i></a>' +
                            //    '<a href="' + editUrl + '" class="btn btn-info btn-action mr-1" data-toggle="tooltip" title="" data-original-title="Edit"><i class="fas fa-pencil-alt"></i></a>' +
                            //    '<a onclick="' + deleteUser + '"  class="btn btn-danger btn-action trigger--fire-modal-1" data-toggle="tooltip" data-original-title="Delete"><i class="fas fa-trash"></i></a>';

                            ////return '<a href="' + activateUrl + '" class="btn btn-success btn-action mr-1" data-toggle="tooltip" title="" data-original-title="Activate"><i class="fas fa-eye"></i></a>' +
                            //    '<a onclick="' + detail + '"  class="btn btn-view btn-action trigger--fire-modal-1 mr-1" data-toggle="tooltip" data-original-title="Detail"><i class="fas fa-eye"></i></a>' +
                            //    '<a href="' + editUrl + '" class="btn btn-info btn-action mr-1" data-toggle="tooltip" title="" data-original-title="Edit"><i class="fas fa-pencil-alt"></i></a>' +
                            //    '<a onclick="' + deleteDept + '"  class="btn btn-danger btn-action trigger--fire-modal-1" data-toggle="tooltip" data-original-title="Delete"><i class="fas fa-trash"></i></a>';
                        }
                    }
                ],
                "lengthMenu": [[10, 25, 50, 100], [10, 25, 50, 100]],
            });
        },

        refresh: function () {
            dt.ajax.reload();
        }
    }
    // initialize the datatables
    tblVM.init();

    fillRolesDropdown();
}); // End of document ready

function tagRoles(element, event) {
    var result = document.getElementById('orgtags');
    while (result.firstChild) result.removeChild(result.firstChild);
    var values = [];
    for (var i = 0; i < element.options.length; i++) {
        if (element.options[i].selected) {
            var li = document.createElement('li');
            li.className = "label label-default tag tag-active";
            li.appendChild(document.createTextNode(element.options[i].text));
            result.appendChild(li);
        }
    }
    $("#AssignedRoles").val($("#assignedRoles").val());
}


function fillRolesDropdown() {

    $('#assignedRoles').multiselect('reload');
}