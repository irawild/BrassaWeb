var rowItemVenda = null;
var recipienteSelecionado = 0;
var recarregando = false;
var mascaraMoeda = "###.###.###.##0,00";

jQuery(function ($) {
    $("input.txtValorItem").mask(mascaraMoeda, { reverse: true });
    $("input.txtPrecoReceita").mask(mascaraMoeda, { reverse: true });
});

$(document).on("click", "#btnPagarMe", function(e){
    e.preventDefault();

   $.ajax({
        url: '/Degustador/FecharCarrinho',
        type: 'POST',
        data: { idVenda: $("#IdVenda").val() },
        success: function (result) {
            if (result.temErro) {
                swal("Oops!", "Alguma coisa deu errado!\n " + result.message, "erro");
                return;
            }
            pagarPagarMe(result);
        },
        error: function (err) {
            swal("Falha", JSON.stringify(err), "error");
        }
    })

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

function pagarPagarMe(venda)
{
      // inicia a instância do checkout
      var checkout = new PagarMeCheckout.Checkout({
        encryption_key: 'ek_test_Vvu09EtpH3vMdnqH8sAgFAtztOUMTo',
        success: function(data) {
            console.log(data);
        },
        error: function(err) {
            console.log(err);
        },
        close: function() {
            console.log('The modal has been closed.');
        }
      });

      // Obs.: é necessário passar os valores boolean como string
      checkout.open({
        amount: parseInt(venda.valorTotalAPagar),
        buttonText: 'Pagar',
        buttonClass: 'botao-pagamento',
        customerData: 'false',
        createToken: 'true',
        paymentMethods: 'credit_card',
        customer: {
          external_id: '#123456789',
          name: 'Fulano',
          type: 'individual',
          country: 'br',
          email: 'fulano@email.com',
          documents: [
            {
              type: 'cpf',
              number: '71404665560',
            },
          ],
          phone_numbers: ['+5511999998888', '+5511888889999'],
          birthday: '1985-01-01'
        }
      });

}

$(document).on("change select", "select.ddlRecipiente", function (e) {
    e.preventDefault();

    if (recarregando)
        return;

    contextItem = this;
    calcularPreco();

})

$(document).on("focus", "input.txtQuantidadeRecipiente", function (e) {
    e.preventDefault();

    rowItemVenda = $(contextItem).closest("div.itemVenda");
    var txtQuantidade = rowItemVenda.find("input.txtQuantidadeRecipiente");
    $(txtQuantidade).val('');

})

$(document).on("blur change", "input.txtQuantidadeRecipiente", function (e) {
    e.preventDefault();
    contextItem = this;

    if (recarregando)
        return;

    calcularPreco();
})

function calcularPreco() {

    rowItemVenda = $(contextItem).closest("div.itemVenda");
    var idItemVenda = rowItemVenda.find("input[type=hidden].IdItemVenda").val();
    var idRecipiente = rowItemVenda.find("select.ddlRecipiente").val();
    var quantidade = rowItemVenda.find("input.txtQuantidadeRecipiente").val();
    var precoCompleto = rowItemVenda.find("input.txtPrecoReceita").val();
    var idBrasseiro = $("#IdBrasseiro").val();

    var dto = {
        IdBrasseiro: idBrasseiro,
        IdItemVenda: idItemVenda,
        IdRecipiente: idRecipiente,
        QuantidadeVenda: quantidade,
        PrecoCompleto: precoCompleto
    }

    var dvRow = rowItemVenda.find("div.dvRowCarrinho");
    recipienteSelecionado = idRecipiente;
    recarregando = true;
    $(dvRow).load("/Recipiente/GetRowCarrinho", dto, function (data) {
        rowItemVenda.find("select.ddlRecipiente").val(recipienteSelecionado);
        recarregando = false;
    });
}
