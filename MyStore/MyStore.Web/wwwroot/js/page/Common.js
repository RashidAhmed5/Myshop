
var showLoader = true;


function redirectionsSuccess(url, search, section, message, type) {
    let concatUrl = url; //+ search + "?section=" + section + "&message=" + message + "&type=" + type;
    window.location = concatUrl;
}


/// need to add below in common

function showError(message) {
    $(".alert-warning").addClass('show');
    $(".alert-success").removeClass('show');
    $(".alert-warning > .alert-warning-msg").html(message);
    $(".alert-warning").scrollTop();
}

function showSuccess(msg) {
    //let msg = //success_messages[section][type];

    if (msg != null && msg.length > 0) {
        //msg = msg.replace("#data", message);
        $(".alert-success > .alert-success-msg").html(msg);
        $(".alert-warning").removeClass('show');
        $(".alert-warning").addClass('hide');
        $(".alert-success").addClass('show');
        $(".alert-warning").scrollTop();
    }
}

function hideMessage() {
    $(".alert-warning").removeClass('show');
    $(".alert-warning").addClass('hide');

    $(".alert-success").removeClass('show');
    $(".alert-success").addClass('hide');
}


$(".close-warning").on('click', function (e) {
    e.preventDefault();

    $(".alert-warning").addClass('hide');
    $(".alert-warning").removeClass('show');
});

$(".close-success").on('click', function (e) {
    e.preventDefault();

    $(".alert-success").addClass('hide');
    $(".alert-success").removeClass('show');
});

$(".close").click(function () {
    $(".alert-success").addClass('hide');
    $(".alert-success").removeClass('show');
    $(".alert-warning").addClass('hide');
    $(".alert-warning").removeClass('show');
});

$(".close").on('click', function (e) {
    e.preventDefault();

    $(".alert-success").addClass('hide');
    $(".alert-success").removeClass('show');
    $(".alert-warning").addClass('hide');
    $(".alert-warning").removeClass('show');

    $(".modal").hide();
});


function OnDateRangeChange() {

}


function addInlineLoaders(url, field) {
    const loaderUrl = {
        url: url.toLowerCase(),
        fieldname: field.toLowerCase()
    };
    let loaderInstance = inlineLoaderUrls.find(function (x) { return x.url == url });
    if (loaderInstance == null) {
        inlineLoaderUrls.push(loaderUrl);
    }
}

var inlineLoaderUrls = [];

$.ajaxSetup({
    beforeSend: function (xhr, settings) {
        var url = settings.url.toLowerCase();
        var loaderInstance = inlineLoaderUrls.find(function (x) { return url.indexOf(x.url) >= 0 });

        // find if any fields need loader
        if (loaderInstance != null && typeof loaderInstance != 'undefined') {
            $(loaderInstance.fieldname).parent().append("<div class='inlineloader'></div>");
        } // if the duplicate needs loader
        else if (settings.url.toLowerCase().indexOf("isduplicate") >= 0) {
            data = settings.data.split("&");
            arr = jQuery.grep(data,
                function (dataelement, index) {
                    return dataelement.indexOf("fieldname") == 0 ? dataelement : "";
                });

            if (arr.length > 0) {
                arr = arr[0];
                fieldname = arr.split("=")[1];
                $("#" + fieldname).parent().append("<div class='inlineloader'></div>");
            }
        } // default loader
        else if (showLoader) {
            $('.loader').show();
        }
    }
});

$(document).ajaxComplete(function (event, jqXHR, settings) {
    if ($.active <= 1) {
        $('.loader').hide();
    }
    $(".inlineloader").remove();
});


function DisableButtonClick(elementid, elementid_2){
    $(elementid).prop('disabled', true);
    $(elementid_2).prop('disabled', true);
}

function EnableButtonClick(elementid, elementid_2) {
    $(elementid).prop('disabled', false);
    $(elementid_2).prop('disabled', false);
}

function activeUrl() {

    var url = window.location.href;
 
    $("#navMenus li.active").removeClass("active");
    //var pgurl = window.location.href;
    $("#navMenus li a").each(function () {
        if (this.href == url) {
            $(this).parent().addClass("active");
        }
    });
  
    };
   