app.controller("mvcCRUDController", function ($scope, crudAJService) {

    $scope.divAluno = false;
    GetTodosAlunos();

    // Obtem todos os alunos
    function GetTodosAlunos() {
        var getDadosAluno = crudAJService.getAlunos();
        getDadosAluno.then(function (Aluno) {

            // Caso exista não exista dados na lista exibe mensagem
            if (Aluno.data.length == 0) {
                $scope.divVazio = true;
                $scope.divLista = false;
            } else {
                $scope.divVazio = false;
                $scope.divLista = true;

                // $scope recebe os itens retornados do banco 
                $scope.alunos = Aluno.data;
            }
        }, function () {
            alert("Erro ao tentar obter os dados dos Alunos.");
        });
    }

    // Editar dados do Aluno
    $scope.editarAluno = function (aluno) {
        var getDadosAluno = crudAJService.getAlunos(aluno.ID_ALUNO);

        getDadosAluno.then(function (_aluno) {

            // Recupera os dados informados
            $scope.aluno = aluno.data;
            $scope.ID_ALUNO = aluno.ID_ALUNO;
            $scope.NOME = aluno.NOME;
            $scope.ENDERECO = aluno.ENDERECO;
            $scope.NOME_MAE = aluno.NOME_MAE;
            $scope.SERIE = aluno.SERIE;

            // Define a ação
            $scope.Action = "Atualizar";
            $scope.divAluno = true;

        }, function () {
            alert("Erro ao tentar obter registros do Aluno.");
        });
    }

    // Atualiza ou Inclui o Aluno
    $scope.AdicionarAtualizarAluno = function () {

        var Aluno = {
            NOME: $scope.NOME,
            ENDERECO: $scope.ENDERECO,
            NOME_MAE: $scope.NOME_MAE,
            SERIE: $scope.SERIE
        };

        var getAlunoAction = $scope.Action;

        // Valida o tipo de ação a ser tomada
        if (getAlunoAction == "Atualizar") {
            Aluno.ID_ALUNO = $scope.ID_ALUNO;

            // Realiza o acesso a Controller
            var getDadosAluno = crudAJService.AtualizaAluno(Aluno);

            getDadosAluno.then(function (msg) {

                GetTodosAlunos();
                alert(msg.data);
                LimpaCampos();
                $scope.divAluno = false;


            }, function () {
                alert("Erro ao tentar editar os dados do Aluno.");
            });

        } else {
            var getDadosAluno = crudAJService.AdicionarAluno(Aluno);

            getDadosAluno.then(function (msg) {

                GetTodosAlunos();
                alert(msg.data);
                LimpaCampos();
                $scope.divAluno = false;
            }, function () {
                alert("Erro ao incluir o Aluno.");
            });
        }
    };

    // Define a div
    $scope.AdicionarAlunoDiv = function () {
        LimpaCampos();
        $scope.Action = "Adicionar";
        $scope.divAluno = true;
    }

    // Excluir dados do Aluno
    $scope.deletarAluno = function (aluno) {
        $scope.divAluno = false;
        var getDadosAluno = crudAJService.ExcluirAluno(aluno.ID_ALUNO);

        getDadosAluno.then(function (msg) {
            alert(msg.data);
            LimpaCampos();
            GetTodosAlunos();

        }, function () {
            alert("Erro ao tentar remover os dados do aluno.");
        });
    }

    // Limpar os campos
    function LimpaCampos() {
        $scope.ID_ALUNO = "";
        $scope.NOME = "";
        $scope.ENDERECO = "";
        $scope.NOME_MAE = "";
        $scope.SERIE = "";
    };

    $scope.Cancel = function () {
        $scope.divAluno = false;
    };

});