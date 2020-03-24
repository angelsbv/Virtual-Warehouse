int = document.querySelectorAll('.int');

int.forEach(t => {
    t.addEventListener('keyup', (e) => {
        for (i = 0; i < int.length; i++) {
            if (int[i].value < 1) {
                int[i].value = 1;
            }
        }
    });
});

function vald() {

    for (i = 0; i < int.length; i++) {
        if (int[i].value < 1) {
            int[i].value = 1;
        }
    }

    if (!ValidateEmail(document.querySelector('#email').value)) {
        alert("Ha digitado un correo electrónico inválido.")
        return false;
    }

    var fecha = document.querySelector("#fechaNacimiento").value;
    var today = new Date();
    if (new Date(fecha).getTime() >= today.getTime()) {
        alert("La fecha de nacimiento debe ser menor que la actual.");
        return false;
    }

    var cedula = document.querySelector('#cedula');
    cedula = parseInt(cedula.value);
    if (isNaN(cedula)) {
        alert("Error.\n\nLa cédula debe ser un número.");
        return false;
    }
    else if (cedula.toString().length != 11) {
        alert("La cédula debe tener 11 digitos.");
        return false;
    }

    return true;
}