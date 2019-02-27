function txtcontrolError(ctrl) {
    var x = ctrl.value.trim();
    var bolValida = true;

    if (x.length == 0) {
        ctrl.style.border = "1px solid Red";
        bolValida = false;
    }
    else {
        ctrl.style.border = "1px solid #ccc";
    }
    return bolValida;
}

function ddlcontrolError(ctrl) {
    var x = ctrl.selectedIndex;
    var bolValida = true;
    if (x < 1) {
        ctrl.style.border = "1px solid Red";
        bolValida = false;
    }
    else {
        ctrl.style.border = "1px solid #ccc";

    }
    return bolValida;
}

function txtcontrolAdvertencia(ctrl) {
    ctrl.style.border = "1px solid Red";
}

function txtcontrolReset(ctrl) {
    ctrl.style.border = "1px solid #ccc";
}

function isLetraNumero(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode

    var letra = false;
    if (charCode > 1 && charCode < 4) {
        letra = true;
    }
    if (charCode == 8) {
        letra = true;
    }
    if (charCode == 13) {
        letra = false;
    }
    if (charCode == 32) {
        letra = true;
    }
    if (charCode > 47 && charCode < 58) {
        letra = true;
    }
    if (charCode > 64 && charCode < 91) {
        letra = true;
    }
    if (charCode > 96 && charCode < 123) {
        letra = true;
    }


    return letra;

}

function isLetraNumeroBanco(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode

    var letra = false;
    if (charCode > 1 && charCode < 4) {
        letra = true;
    }
    if (charCode == 8) {
        letra = true;
    }
    if (charCode == 13) {
        letra = false;
    }
    if (charCode == 32) {
        letra = true;
    }
    if (charCode == 45) {
        letra = true;
    }
    if (charCode > 47 && charCode < 58) {
        letra = true;
    }
    if (charCode > 64 && charCode < 91) {
        letra = true;
    }
    if (charCode > 96 && charCode < 123) {
        letra = true;
    }



    return letra;

}

function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode

    var letra = true;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
        letra = false;
    }
    if (charCode == 13) {
        letra = false;
    }

    return letra;
}

function islockedKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode

    var letra = false;

    return letra;
}

function isDecimalKey(ctrl, evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    var FIND = "."
    var x = ctrl.value
    var y = x.indexOf(FIND)

    if (charCode == 46) {
        if (y != -1 || x.length == 0)
            return false;
    }
    if (charCode != 46 && (charCode < 48 || charCode > 57))
        return false;

    return true;
}

function validanumeroLostFocus(control) {
    var valor = true;
    var texto = control.value.trim();
    control.value = texto;

    var letras = "0123456789.";
    var n = 0;
    while (n < texto.length) {
        var x = texto.substring(n, n + 1)
        if (letras.indexOf(x) < 0) {
            valor = false;
        }
        n++;
    }


    if (texto.substring(0, 1) == ".") {
        valor = false;
    }

    if (texto.substring(n - 1, n) == ".") {
        valor = false;
    }


    if (!valor) {
        control.focus();
        alert("Número Incorrecto");
        control.value = "";
    }
}

function NoEspeciales(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode

    var letra = true;
    var letras = "*?´(),;:_|°=¿$#%&/{}[]+!<>~@";
    var tecla = String.fromCharCode(charCode);
    var n = letras.indexOf(tecla);
    if (n > -1) {
        letra = false;
    }

    return letra;

}

function NoEspecialesHtml(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode

    var letra = true;
    var letras = "<>";
    var tecla = String.fromCharCode(charCode);
    var n = letras.indexOf(tecla);
    if (n > -1) {
        letra = false;
    }

    return letra;

}

