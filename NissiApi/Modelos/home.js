$(document).ready(function () {
    debugger;
    var usuario = JSON.parse(localStorage.getItem("usuario"));

    $(".nombre-usuario").html((usuario.nombre + ' ' + usuario.apellido).toUpperCase());
    $("#rol-usuario").html(usuario.rol);
    $(".img-avatar").attr("src", "/assets/img/" + usuario.avatar);
});
