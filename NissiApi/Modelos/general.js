var URLServices = "https://localhost:44342/api/";

function CloseSession() {
    localStorage.removeItem("usuario");
    localStorage.removeItem("usuarioid");
    $(location).attr('href', "/Index.html");
}

function GetDataService(metodo, datos, respuesta) {
    $.ajax({
        type: 'GET',
        url: URLServices + metodo,
        data: { value: JSON.stringify(datos) },
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: respuesta,
        error: function (e) {
            console.log(e);
        }
    });
}

function isEmpty(str) {
    return (!str || 0 === str.length);
}

var waitingDialog = waitingDialog || (function ($) {
    'use strict';

    // Creating modal dialog's DOM
    var $dialog = $(
        '<div class="Loading modal fade" data-backdrop="static" data-keyboard="false" tabindex="-1" role="dialog" aria-hidden="true" style="padding-top:10%; overflow-y:visible;">' +
        '<div class="loader">' +
        '  <div class="circle one"></div>' +
        '  <div class="circle two"></div>' +
        '  <div class="circle three"></div>' +
        '</div>' +
        '</div></div></div>');


    return {
        /**
   * Opens our dialog
   * @param message Custom message
   * @param options Custom options:
   *       options.dialogSize - bootstrap postfix for dialog size, e.g. "sm", "m";
   *       options.progressType - bootstrap postfix for progress bar type, e.g. "success", "warning".
   */
        show: function (message, options) {
            // Assigning defaults
            if (typeof options === 'undefined') {
                options = {};
            }
            if (typeof message === 'undefined') {
                message = '';
            }
            var settings = $.extend({
                dialogSize: 'm',
                progressType: '',
                onHide: null // This callback runs after the dialog was hidden
            }, options);

            // Configuring dialog
            $dialog.find('.modal-dialog').attr('class', 'modal-dialog').addClass('modal-' + settings.dialogSize);
            $dialog.find('.progress-bar').attr('class', 'progress-bar');
            if (settings.progressType) {
                $dialog.find('.progress-bar').addClass('progress-bar-' + settings.progressType);
            }
            $dialog.find('h3').text(message);
            // Adding callbacks
            if (typeof settings.onHide === 'function') {

                $dialog.off('hidden.bs.modal').on('hidden.bs.modal', function (e) {
                    settings.onHide.call($dialog);
                });
            }
            // Opening dialog
            $dialog.modal();
        },
        /**
   * Closes dialog
   */
        hide: function () {
            $dialog.modal('hide');
            $(".modal-backdrop.fade").remove();
        }
    };

})(jQuery);

function pasarVariables(pagina, nombres) {
    pagina = "/Views/" + pagina + "?";
    nomVec = nombres === "" || nombres === null ? "" : nombres.split(",");

    if (nomVec !== "" || nomVec === null) {
        for (i = 0; i < nomVec.length; i++) {
            param = nomVec[i].split("=");
            pagina += param[0] + "=" + escape(param[1]) + "&";
        }
        pagina = pagina.substring(0, pagina.length - 1);
    }
    location.href = pagina;
}