var rowDegustadorSelecionada = null;
var rowEstoqueSelecionada = null;

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

$(document).on("click", "button.btnHistoricoBrasseiro", function (e) {
    e.preventDefault();

    rowDegustadorSelecionada = $(this).closest("tr.itemRow");
    var idBrasseiro = rowDegustadorSelecionada.find("input[type=hidden].IdBrasseiro").val();
    var nomeBrasseiro = rowDegustadorSelecionada.find("input[type=hidden].NomeBrasseiro").val();

    $("#dvEstoqueBrasseiro").load("/Brasseiro/GetEstoqueBrasseiro?idBrasseiro=" + idBrasseiro, function (data, status, xhr) {
        console.log(xhr.status);
        $("#dvBrasseiros").hide(200);
        $("#CabecalhoEstoqueBrasseiro").empty();
        $("#CabecalhoEstoqueBrasseiro").text("O que " + nomeBrasseiro + " tem?");
        $("#dvEstoqueBrasseiro").removeAttr('hidden').show(200);
    })

})

$(document).on("click", "button.btnItemEstoqueBrasseiro", function (e) {
    e.preventDefault();

    rowEstoqueSelecionada = $(this).closest("tr.itemEstoque");
    var idEstoque = rowEstoqueSelecionada.find("input[type=hidden].IdEstoque").val();

    $("#dvDetalheEstoqueBrasseiro").load("/Brasseiro/GetDetalheEstoque?idEstoque=" + idEstoque, function (data, status, xhr) {
        console.log(xhr.status);
        $("#dvDetalheEstoqueBrasseiro").removeClass("hidden").show(200);
        $("#dvBotaoOutrasReceitas").removeClass("hidden").show(200);
        rolarParaCampo($("#dvDetalheEstoqueBrasseiro"), 200);
    })

})

$(document).on("click", "#btnVoltarBrasseiros", function (e) {
    $("#dvBrasseiros").show(200);
    $("#dvEstoqueBrasseiro").hide(200);
    $("#dvDetalheEstoqueBrasseiro").hide(200);
    rolarParaCampo(rowDegustadorSelecionada, 200);
})

$(document).on("click", "#btnVoltarEstoques", function (e) {
    $("#dvDetalheEstoqueBrasseiro").hide(200);
    rolarParaCampo(rowEstoqueSelecionada, 200);
})

$(document).on("click", "#btnBrasseiros", function (e) {
    e.preventDefault();

    var idCidade = $("#IdCidade").val();

    $("#dvBrasseiros").load("/Brasseiro/GetBrasseirosCidade?idCidade=" + idCidade, function (data, status, xhr) {
        console.log(xhr.status);
        //$("#dvBrasseiros").removeClass("hidden").show(200);
        $("#dvBrasseiros").removeAttr('hidden').show(200);
        $("#dvCabecalho").hide(200);
    })
})

$(document).on("click", "#btnSalvarDegustador", function (e) {
    e.preventDefault();

    if (!$("#txtNome").val() || !$("#txtIdade").val()) {
        swal("Falta alguma coisa!", "Veja se não faltou nada!", "warning");
        return;
    }

    var degustador = {
        Id: 0,
        Nome: $("#txtNome").val(),
        Idade: $("#txtIdade").val(),
        Cidade: {
            Id: $("#ddlCidade").val()
        }
    }

    $.ajax({
        url: '/Degustador/Save',
        type: 'POST',
        data: { degustador: degustador },
        success: function (result) {
            if (result.temErro) {
                swal("Oops!", "Alguma coisa deu errado!\n " + result.message, "erro");
                return;
            }
            swal("Beleza!", "Opa, Beleza! Você já está registrador. Obrigado!", "success");
            location.assign("~/Degustador/Degustador");
        },
        //statusCode: {
        //    200: function (response) { },
        //    401: function (response) {
        //        swal("Acesso negado", "Para usar as funções desta aplicação é necessário se autenticar. Caso ainda não possua um conta, escolha a opção Criar conta no menu principal.", "warning");
        //    }
        //},
        error: function (err) {
            swal("Falha", JSON.stringify(err), "error");
        }
    })
})

$(document).on("click", "#btnVerOutras", function (e) {
    e.preventDefault();
    rolarParaCampo(rowEstoqueSelecionada, 200);
})