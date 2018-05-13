
$(document).on("click", "#btnMeusPedidos", function(e) {
    e.preventDefault();

    $("#dvListaCarrinhos").load("/Degustador/ListarCarrinhos?idDegustador=" + $("#IdDegustador").val(), function(data){
        $("#dvListaCarrinhos").removeAttr('hidden').show(200);
    });

})

function fecharPedido()
{
   $.ajax({
        url: '/Degustador/MarcarVendaPaga',
        type: 'POST',
        data: { idVenda: $("#IdVenda").val() },
        success: function (result) {
            if (result.temErro) {
                swal("Oops!", "Alguma coisa deu errado!\n " + result.message, "erro");
                return;
            }
            swal("Obrigado!", "Nos vemos na próxima compra!", "success");
            location.assign("~/Home/Index")
        },
        error: function (err) {
            swal("Falha", JSON.stringify(err), "error");
        }
    })
}
