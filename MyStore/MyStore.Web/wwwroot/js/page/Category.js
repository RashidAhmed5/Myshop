var categoryVM;
$(function () {
    showAsteric();

    categoryVM = {
        dt: null,

        init: function () {
            dt = $('#tblproductCategory').DataTable({
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
                    "url": $("#getCategories").data('request-url'),
                    "type": "GET",
                    "datatype": "json",
                    "data": function (dtp) {
                        var searchValue = dtp.search.value;
                        return dtp;
                    }
                },

                "columns": [
                    { title: "Category Id", data: "id", searchable: false, sortable: false, visible: false },
                    { title: "Category Name", data: "name", searchable: false, sortable: false },
                    { title: "Description", data: "description", searchable: false, sortable: false },
                    {
                        title: "Actions", data: "id", searchable: false, sortable: false,
                        render: function (data, type, full, meta) {
                            var editUrl = $("#editCategory").data("request-url") + "?id=" + full.id;
                           
                            var edit = "showInPopup('" + editUrl + "', 'Update Product Category')";
                          
                            var action = "";
                                action = '<a onclick="' + edit + '" class="btn btn-info btn-action mr-1" data-toggle="tooltip" title="" data-original-title="Edit"><i class="fas fa-pencil-alt"></i></a>';
                          
                            return action;
                            //return '<a onclick="' + edit + '" class="btn btn-info btn-action mr-1" data-toggle="tooltip" title="" data-original-title="Edit"><i class="fas fa-pencil-alt"></i></a>' +
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
    categoryVM.init();



    $('#tblproductCategory').on("click", ".editCategory", function (event) {
        event.preventDefault();
        var url = $(this).attr("href");
        $.get(url, function (data) {
            $('#editCategoryContainer').html(data);
            $('#editContainerModal').modal('show');
        });
    });

   
});