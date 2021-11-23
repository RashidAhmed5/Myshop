/**
 *
 * You can write your JS code here, DO NOT touch the default style file
 * because it will make it harder for you to update.
 *
 */

"use strict";

// Bootstrap Date Picker
if (jQuery().datepicker) {
    if ($(".datepicker").length) {
        $('.input-group.date').datepicker({
            format: 'dd/mm/yyyy',
            todayBtn: 'linked',
            todayHighlight: true,
            autoclose: true,
        });
    }
}

$(".mobilenumber").intlTelInput({
    //allowDropdown: true,
    //initialCountry: "ae",
    //placeholderNumberType: "MOBILE",
    //preferredCountries: ["ae", "pk"],
    //separateDialCode: false,
    utilsScript: "../lib/intl-tel-input/build/js/utils.js",
});
$(function () {
    $("body").delegate(".datepicker", "focusin", function () {
        $(this).datepicker({
            format: 'dd/mm/yyyy',
            todayBtn: 'linked',
            todayHighlight: true,
            autoclose: true,
        });
    });

    $("body").delegate(".datetimepicker", "focusin", function () {
        $(this).datetimepicker({
            format: "DD/MM/YYYY hh:mm A"
        });
    });

    $("body").delegate(".multiTagsInput", "click", function () {
        $(this).tagsinput('items');
    });
});

$(function () {
    $("#btnCreate").on("click", function () {
        var url = $(this).data("url");
        $.get(url, function (data) {
            $('#createContainer').html(data);
            $('#createModal').modal('show');
        });
    });

    $('#tblData').on("click", ".edit", function (event) {
        event.preventDefault();
        var url = $(this).attr("href");
        $.get(url, function (data) {
            $('#editContainer').html(data);
            $('#editModal').modal('show');
        });
    });

    $('#tblData').on("click", ".delete", function (event) {
        event.preventDefault();
        var url = $(this).attr("href");
        $.get(url, function (data) {
            $('#deleteContainer').html(data);
            $('#deleteModal').modal('show');
        });
    });
});

function showInPopup(url, title) {
    $.ajax({
        type: 'GET',
        url: url,
        success: function (res) {
            $('#form-modal .modal-body').html(res);
            $('#form-modal .modal-title').html(title);
            $('#form-modal').modal('show');
            // to make popup draggable
            //$('.modal-dialog').draggable({
            //    handle: ".modal-header"
            //});
        }
    })
}

function showAsteric() {
    $('input[type=text],input[type=radio],input[type=checkbox],textarea,select,input[type=email],input[type=number]').each(function () {
        var req = $(this).attr('data-val-required');
        var exclude = $(this).attr('data-exclude');
        if (undefined != req && undefined == exclude) {
            var label = $('label[for="' + $(this).attr('id') + '"]');
            var text = label.text();
            if (text.length > 0) {
                label.append('<span style="color:red"> *</span>');
            }
        }
    });

}

function ListWithSourceData(tableId, dtColumns, data) {

    $(tableId).DataTable({
        data: data,
        "columns": dtColumns,
        "responsive": true,
        'fixedheader': true,
        "fixedColumns": false,
        "scrollCollapse": true,
        "scrollX": true,
        "autoWidth": false,
        "stateSave": true,
        "processing": false,
        "serverSide": false,
        "searching": false,
        "paging": false,
        "destroy": true,
        "info": true,
        "ordering": false
    });

}

