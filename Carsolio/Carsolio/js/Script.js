$(document).ready(function () {
    $('#txtCodigo').keypress(function (e) {
        var code = (e.keyCode ? e.keyCode : e.which);
        if (code == 13) {
            var code = $('#txtCodigo').val();
            $.ajax({
                type: "POST",
                url: "AddProducts.aspx/Verficacion",
                data: '{codigo: "' + code + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: resultado,
                error: errores
            });

        }
        if ((event.keyCode < 48 || (event.keyCode > 57))) {
            event.returnValue = false;
            alert('Solo numero');
        }

    });
    ////Transaccion  Verificarrrrrr
    $('#txtCod').keypress(function (e) {
        var code = (e.keyCode ? e.keyCode : e.which);
        if (code == 13) {
            var code = $('#txtCod').val();
            $.ajax({
                type: "POST",
                url: "Trsaccion.aspx/Consultas",
                data: '{codigo: "' + code + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function resul(msg) {
                    alert(msg.d);
                },
                error: errores
            });

        }

    });
    ////////Modulos///////
    $('#txtModuleVer').keypress(function (e) {
        var code = (e.keyCode ? e.keyCode : e.which);
        if (code == 13) {
            var modulo = $('#txtModule').val();
            var modulever = $('#txtModuleVer').val();

            if (modulo === modulever) {
                $.ajax({
                    type: "POST",
                    url: "AddModulo.aspx/AddMod",
                    data: '{modulo: "' + modulo + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function resultado(msg) {
                        alert(msg.d);
                        var modulo = $('#txtModule').val('');
                        var modulever = $('#txtModuleVer').val('');
                    },
                    error: errores
                });
            }


        }

    });





    function resultado(msg) {

        if (msg.d != "") {
            alert(msg.d);
            $('#txtCodigo').val('');
        }
    }
    function errores(msg) {
        alert('Error: ' + msg.responseText);
    }

    /////////VERIFICAR QUE SOLO SE ESCRIBAN NUMEROS//////////


//    $('#txtCodigo').keypress(function (e) {
//        if ((event.keyCode < 48 || (event.keyCode > 57))) {
//            event.returnValue = false;
//            alert('Solo numero');
//        }
            
//    });

});