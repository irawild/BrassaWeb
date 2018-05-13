// Write your JavaScript code.

var rolarParaCampo = function (alvo, tempo) {
    $('html, body').animate({
        scrollTop: alvo.offset().top - 30
    }, tempo, function () {

    });
}

$(document).ready(function () {
    $.ajax({
        url: '/Degustador/HaVendas',
        type: 'GET',
        success: function (result) {
            if (result == "yes")
            {
                $("#carrinho").removeAttr("hidden").show(100);
            }
        },
        error: function (err) {
            swal("Falha", JSON.stringify(err), "error");
        }
    })
})