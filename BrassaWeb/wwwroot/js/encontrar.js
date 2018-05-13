var rowBrasseiro = null;
var rowReceita = null;

$(document).on("change select", "#ddlEstado", function (e) {
    e.preventDefault();

    $("#dvListaCidades").load("/Endereco/GetListCidades?idEstado=" + $("#ddlEstado").val(), function (data, status, xhr) {
        if (xhr.status == 200) {
            $("#dvListaCidades").removeAttr('hidden').show(200);
        }
        else {
            alert("Ocorreu uma falha! " + status + " - " + xhr.statusCode() + "\n" + JSON.stringify(xhr.statusText) + "\n" + xhr.responseJSON);
        }
    });
})

$(document).on("click", "#btnLocalizar", function (e) {
    e.preventDefault();

    var idCidade = $("#ddlCidade").val();

    $("#dvBrasseiros").load("/Brasseiro/GetBrasseirosCidade?idCidade=" + idCidade, function (data, status, xhr) {
        console.log(xhr.status);
        $("#dvBrasseiros").removeAttr('hidden').show(200);
    })
})

$(document).on("click", "button.btnHistoricoBrasseiro", function (e) {
    e.preventDefault();

    rowBrasseiro = $(this).closest("tr.itemRow");
    var idBrasseiro = rowBrasseiro.find("input[type=hidden].IdBrasseiro").val();
    var nomeBrasseiro = rowBrasseiro.find("input[type=hidden].NomeBrasseiro").val();

    $("#dvEstoqueBrasseiro").load("/Brasseiro/GetEstoqueBrasseiro?idBrasseiro=" + idBrasseiro, function (data, status, xhr) {
        console.log(xhr.status);
        $("#dvPesquisa").hide(200);
        $("#dvBrasseiros").hide(200);
        $("#CabecalhoEstoqueBrasseiro").empty();
        $("#CabecalhoEstoqueBrasseiro").text("O que " + nomeBrasseiro + " tem?");
        $("#dvEstoqueBrasseiro").removeAttr('hidden').show(200);
    })
})

$(document).on("click", "#btnVoltarBrasseiros", function (e) {
    $("#dvBrasseiros").show(200);
    $("#dvPesquisa").show(200);
    $("#dvEstoqueBrasseiro").hide(200);
    $("#dvDetalheEstoqueBrasseiro").hide(200);
    rolarParaCampo(rowBrasseiro, 200);
})

$(document).on("click", "button.btnDegustarReceita", function (e) {
    e.preventDefault();

    rowReceita = $(this).closest("div.receitaBrasseiro");
    var idEstoque = rowReceita.find("input[type=hidden].IdEstoque").val();

    window.location("/Degustador/Carrinho?idEstoque=" + idEstoque);
})
