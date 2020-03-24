function Vald()
{

    if (!ValidateEmail(document.querySelector('#email').value))
    {
        alert("Ha digitado un correo electrónico inválido.")
        return false;
    }

    var fecha = document.querySelector("#fechaNacimiento").value;
    var today = new Date();
    if (new Date(fecha).getTime() >= today.getTime()) {
        alert("La fecha de nacimiento debe ser menor que la actual.");
        return false;
    }

    return true;
}

function ValidateEmail(mail) {
    if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(mail)) {
        return true;
    }
    else {
        return false;
    }
}