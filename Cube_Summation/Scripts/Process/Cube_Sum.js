var Casos_For_End = 0;
var Value_Operations = 0;
var Value_Cube = 0;
var arrayAsignation;

$("#contains_cases").ready(function () {
    $("#btnSend_Cases").attr("disabled", false);
    $("#txtNum_Cases").attr("disabled", false);
    $("#txtCubeOperations").attr("disabled", true);
    $("#btnCubeOperations").attr("disabled", true);
    $("#txtOperation").attr("disabled", true);
    $("#btnSendOperation").attr("disabled", true);
});

$(document).on("click", "#btnSend_Cases", function () {
    $.ajax({
        url: "/Home/getCases",
        type: "post",
        data: {
            Num_case: $("#txtNum_Cases").val()
        },
        dataType: "json",
        success: function (result) {
            if (result.IsSuccess) {
                Casos_For_End = result.Result;
                $("#contains_cases").show();
                $("#btnSend_Cases").attr("disabled", true);
                $("#txtNum_Cases").attr("disabled", true);
                $("#txtCubeOperations").attr("disabled", false);
                $("#btnCubeOperations").attr("disabled", false);
                $("#Console_Cube").append("Caso(s) total(es) de prueba: " + Casos_For_End + " <br />");
            } else {
                alert(result.Message);
            }
        },
        error: function () {
            alert("Falla presentada al comunicarse con el controlador");
        }
    });

});

$(document).on("click", "#btnCubeOperations", function () {
    $.ajax({
        url: "/Home/Cube_Operations",
        type: "post",
        data: {
            CubeOp: $("#txtCubeOperations").val()
        },
        dataType: "json",
        success: function (result) {
            if (result.IsSuccess) {
                Value_Operations = result.Value_Operations;
                Value_Cube = result.Value_Cube;
                arrayAsignation = [];
                $("#txtCubeOperations").attr("disabled", true);
                $("#btnCubeOperations").attr("disabled", true);
                $("#txtOperation").attr("disabled", false);
                $("#btnSendOperation").attr("disabled", false);
                $("#Console_Cube").append("Tamaño del cubo: " + Value_Cube + " <br />");
                $("#Console_Cube").append("Operaciones a realizar: " + Value_Operations + " <br />");
                $("#Console_Operations").html("");
                $("#Console_Operations").append("Debes realizar las operaciones de la siguiente forma... <br />");
                $("#Console_Operations").append("Asignación: x y z w <br />");
                $("#Console_Operations").append("Sumar: x1 y1 z1 x2 y2 z2 <br />");
                $("#Console_Operations").append("-------------------- <br />");
                $("#Console_Operations").append("Faltan " + Value_Operations + " operaciones por realizar <br />");
            } else {
                alert(result.Message);
            }
        },
        error: function () {
            alert("Falla presentada al comunicarse con el controlador");
        }
    });
});

$(document).on("click", "#btnSendOperation", function () {
    $.ajax({
        url: "/Home/For_Do_Operations",
        type: "post",
        data: {
            ValuesOperation: $("#txtOperation").val(),
            n: Value_Cube,
        },
        dataType: "json",
        success: function (result) {
            if (result.IsSuccess) {
                arrayAsignation.push(result.SaveRow);
                $("#Console_Operations").append("Operacion registrada con exito <br />");
                $("#Console_Operations").append("-------------------- <br />");
                Value_Operations = Value_Operations - 1;
                if (Value_Operations !== 0) {
                    $("#Console_Operations").append("Faltan " + Value_Operations + " operaciones por realizar <br />");
                    $("#txtOperation").text("");
                } else {
                    ViewCube();
                    Casos_For_End = Casos_For_End - 1;
                    if (Casos_For_End !== 0) {
                        $("#txtCubeOperations").attr("disabled", false);
                        $("#btnCubeOperations").attr("disabled", false);
                        $("#txtOperation").attr("disabled", true);
                        $("#btnSendOperation").attr("disabled", true);
                    } else {
                        $("#Console_Cube").append("!!! Proceso Finalizado!!! <br />");
                        $("#txtOperation").attr("disabled", true);
                        $("#btnSendOperation").attr("disabled", true);
                    }
                }
            } else {
                $("#Console_Operations").append("No es posible realizar operación porque: " + result.Message + " <br />");
            }
        },
        error: function () {
            alert("Falla presentada al comunicarse con el controlador");
        }
    });
});

function ViewCube() {
    $.ajax({
        url: "/Home/Process_Cube",
        type: "post",
        data: {
            Asignations: arrayAsignation,
            n: Value_Cube,
        },
        dataType: "json",
        success: function (result) {
            if (result.IsSuccess) {
                $("#Console_Cube").append("....... Resultados ....... <br />");
                $("#Console_Cube").append(result.CubeComplete + " <br />");
            } else {
                $("#Console_Operations").append("No es posible mostrar los resultados porque: " + result.Message + " <br />");
            }
        },
        error: function () {
            alert("Falla presentada al comunicarse con el controlador");
        }
    });
}