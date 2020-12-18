//Demo Site : https://codeseven.github.io/toastr/demo.html

toastr.options = {
    "closeButton": false,
    "debug": false,
    "newestOnTop": true,
    "progressBar": true,
    "positionClass": "toast-top-right",
    "preventDuplicates": false,
    "onclick": null,
    "showDuration": "300",
    "hideDuration": "1000",
    "timeOut": "5000",
    "extendedTimeOut": "1000",
    "showEasing": "swing",
    "hideEasing": "linear",
    "showMethod": "fadeIn",
    "hideMethod": "fadeOut"
}

function ShowSuccess(message, title) {
    if (message == null)
        message = "Success";
    toastr["success"](message, title);
}

function ShowError(message, title) {
    if (message == null)
        message = "Fail";
    toastr["error"](message, title);
}

function ShowInfo(message, title) {
    if (title == null)
        title = "Info";
    toastr["info"](message, title);
}

function ShowWarning(message, title) {
    if (title == null)
        title = "Warning";
    toastr["warning"](message, title);
}


