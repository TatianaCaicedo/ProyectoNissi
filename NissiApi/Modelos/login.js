$(document).ready(function (){

    $("#SingIn").click(function (e) {
        Login();
    });
});

function Login() {

    if (isEmpty($("#userName").val())) {
        alert("Debe ingresar el usuario");
        return;
    }
    if (isEmpty($("#pass").val())) {
        alert("Debe ingresar la contraseña");
        return;
    }

    var data = {
        "usuario": $("#userName").val(),
        "contraseña": $("#pass").val()
    };

    GetDataService("Usuarios/Login", data, function (e) {

        if (e.usuario != null) {

            localStorage.setItem("usuario", JSON.stringify(e.usuario));

            switch (e.usuario.id_rol) {
                case 1: //Admin
                    pasarVariables("home.html", "");
                    break;
            }
        }
        else {
            alert("Correo o Password no válidos");
            return;
        }
    });
}