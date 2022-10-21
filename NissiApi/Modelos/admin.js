var listaUsuarios = [];
var esEditar = false;
var idUsuario = 0;

$(document).ready(function () {

    var usuario = JSON.parse(localStorage.getItem("usuario"));

    $(".nombre-usuario").html((usuario.nombre + ' ' + usuario.apellido).toUpperCase());
    $("#rol-usuario").html(usuario.rol);
    $(".img-avatar").attr("src", "/assets/img/" + usuario.avatar);

    consultarUsuarios();

    $("#btn-addAdmin").click(function (e) {
        guardarUsuario();
    });

    $("#tabEditar").click(function (e) {
        limpiarFormulario();

        idUsuario = 0;
        esEditar = false;
    });

});

function consultarUsuarios() {

    GetDataService("Usuarios/ConsultarListaUsuarios", {}, function (e) {

        if (e.Usuario.length > 0) {

            listaUsuarios = e.Usuario;

            var info = '';

            $.each(e.Usuario, function (i, usuario) {

                let urlImage = "/assets/img/" + usuario.avatar;

                info += ' <div class="mdl-list__item mdl-list__item--two-line"> ' +
                    ' <span class="mdl-list__item-primary-content" style="height: 50px;"> ' +
                    ' <img src="' + urlImage + '" alt="avatar" style="height:50px;width:50px;"> ' +
                    ' <span>' + (i + 1) + ' ' + usuario.nombre + ' ' + usuario.apellido + '</span></br> ' +
                    ' <span class="mdl-list__item-sub-title" style="line-height: 0px;margin-left: 9%;">' + usuario.identificacion + '</span> ' +
                    ' </span> ' +
                    ' <a class="mdl-list__item-secondary-action" href="#!" onclick="editarUsuario(' + usuario.id_usuario + ');"><i class="zmdi zmdi-edit"></i></a> ' +
                    ' <a class="mdl-list__item-secondary-action" href="#!" style="margin-left: 10px;" onclick="eliminarUsuario(' + usuario.id_usuario + ');"><i class="zmdi zmdi-delete"></i></a> ' +
                    ' </div> ' +
                    ' <li class="full-width divider-menu-h"></li> ';
            });

            $("#div-list-user").html(info);
        } else {
            $("#div-list-user").html("");
        }
    });
}

function guardarUsuario() {

    if (isEmpty($("#DNIAdmin").val())) {
        alert("Debe ingresar la identificación");
        return;
    }
    if (isEmpty($("#NameAdmin").val())) {
        alert("Debe ingresar el nombre");
        return;
    }

    if (isEmpty($("#LastNameAdmin").val())) {
        alert("Debe ingresar el apellido");
        return;
    }
    if (isEmpty($("#phoneAdmin").val())) {
        alert("Debe ingresar el teléfono");
        return;
    }

    if (isEmpty($("#emailAdmin").val())) {
        alert("Debe ingresar el correo");
        return;
    }
    if (isEmpty($("#UserNameAdmin").val())) {
        alert("Debe ingresar el usuario");
        return;
    }
    if (isEmpty($("#passwordAdmin").val())) {
        alert("Debe ingresar la contraseña");
        return;
    }

    if (!$("#option-1").is(":checked") && !$("#option-2").is(":checked")) {
        alert("Debe seleccionar un avatar");
        return;
    }

    var data = {
        "nombre": $("#NameAdmin").val(),
        "usuario": $("#UserNameAdmin").val(),
        "contraseña": $("#passwordAdmin").val(),
        "id_rol": 1,
        "estado": true,
        "identificacion": $("#DNIAdmin").val(),
        "telefono": $("#phoneAdmin").val(),
        "email": $("#emailAdmin").val(),
        "apellido": $("#LastNameAdmin").val(),
        "avatar": $("#option-1").is(":checked") ? "avatar-male.png" : "avatar-female.png",
        "id_usuario": idUsuario
    };
    debugger;

    if (esEditar) {
        GetDataService("Usuarios/EditarUsuario", data, function (e) {

            if (e.resultado) {

                limpiarFormulario();

                consultarUsuarios();
                $("#tabEditar").removeClass("is-active");
                $("#tabNewAdmin").removeClass("is-active");

                $("#tabLista").addClass("is-active");
                $("#tabListAdmin").addClass("is-active");
            }
            else {
                alert("Ocurrió un error");
            }
        });

    } else {
        GetDataService("Usuarios/GuardarUsuario", data, function (e) {

            if (e.resultado) {

                limpiarFormulario();

                consultarUsuarios();
                $("#tabEditar").removeClass("is-active");
                $("#tabNewAdmin").removeClass("is-active");

                $("#tabLista").addClass("is-active");
                $("#tabListAdmin").addClass("is-active");
            }
            else {
                alert("Ocurrió un error");
            }
        });
    }

}


function editarUsuario(id) {
    idUsuario = id;
    esEditar = true;
    $("#tabEditar").addClass("is-active");
    $("#tabNewAdmin").addClass("is-active");

    $("#tabLista").removeClass("is-active");
    $("#tabListAdmin").removeClass("is-active");

    var usuario = listaUsuarios.filter(x => x.id_usuario === id);

    if (usuario[0] !== null) {

        usuario = usuario[0];

        limpiarFormulario();

        $("#NameAdmin").val(usuario.nombre);
        $("#UserNameAdmin").val(usuario.usuario);
        $("#passwordAdmin").val(usuario.contraseña);
        $("#DNIAdmin").val(usuario.identificacion);
        $("#phoneAdmin").val(usuario.telefono);
        $("#emailAdmin").val(usuario.email);
        $("#LastNameAdmin").val(usuario.apellido);

        if (usuario.avatar === "avatar-male.png") {
            $("#option-1").attr('checked', true);
            $("#option-1").trigger('click');
            $("#lbloption-1").addClass('is-checked');
            $("#lbloption-2").removeClass('is-checked');

        } else {
            $("#option-2").attr('checked', true);
            $("#option-2").trigger('click');
            $("#lbloption-2").addClass('is-checked');
            $("#lbloption-1").removeClass('is-checked');
        }
    }
}

function eliminarUsuario(id) {

    swal({
        title: '¿Esta seguro de eliminar el usuario?',
        type: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Si, eliminar',
        closeOnConfirm: true
    },
        function (isConfirm) {
            if (isConfirm) {
                var data = {
                    "id_usuario": id
                };

                GetDataService("Usuarios/EliminarUsuario", data, function (e) {

                    if (e.resultado) {
                        consultarUsuarios();
                        $("#tabEditar").removeClass("is-active");
                        $("#tabNewAdmin").removeClass("is-active");

                        $("#tabLista").addClass("is-active");
                        $("#tabListAdmin").addClass("is-active");
                    } else {
                        alert("Ocurrió un error");
                    }
                });
            }
        });
}

function limpiarFormulario() {
    $("#NameAdmin").val("");
    $("#UserNameAdmin").val("");
    $("#passwordAdmin").val("");
    $("#DNIAdmin").val("");
    $("#phoneAdmin").val("");
    $("#emailAdmin").val("");
    $("#LastNameAdmin").val("");

    $("#NameAdmin").focus();
    $("#UserNameAdmin").focus();
    $("#passwordAdmin").focus();
    $("#DNIAdmin").focus();
    $("#phoneAdmin").focus();
    $("#emailAdmin").focus();
    $("#LastNameAdmin").focus();

    $("#option-1").prop("checked", false);
    $("#option-2").prop("checked", false);
    $("#lbloption-1").removeClass('is-checked');
    $("#lbloption-2").removeClass('is-checked');

    $("#NameAdmin").focusout();
    $("#UserNameAdmin").focusout();
    $("#passwordAdmin").focusout();
    $("#DNIAdmin").focusout();
    $("#phoneAdmin").focusout();
    $("#emailAdmin").focusout();
    $("#LastNameAdmin").focusout();
}