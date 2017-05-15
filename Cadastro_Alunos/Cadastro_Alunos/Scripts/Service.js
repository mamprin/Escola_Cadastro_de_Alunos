app.service("crudAJService", function ($http) {

    // Obtem todos os alunos
    this.getAlunos = function () {
        return $http.get("Home/GetTodosAlunos");
    };

    // Obtem o aluno por ID
    this.getAluno = function (id_Aluno) {
        var response = $http({
            method: "post",
            url: "Home/GetAlunoPorID",
            params: {
                idAluno: JSON.stringify(id_Aluno)
            }
        });
        return response;
    };

    // Atualizar Aluno
    this.AtualizaAluno = function (aluno) {
        var response = $http({
            method: "post",
            url: "Home/AtualizaAluno",
            data: JSON.stringify(aluno),
            dataType: "json"
        });
        return response;
    };

    // Adicionar Aluno
    this.AdicionarAluno = function (aluno) {
        var response = $http({
            method: "post",
            url: "Home/AdicionarAluno",
            data: JSON.stringify(aluno),
            dataType: "json"
        });
        return response;
    };

    // Excluir Aluno
    this.ExcluirAluno = function (id_aluno) {
        var response = $http({
            method: "post",
            url: "Home/ExcluirAluno",
            params: {
                idAluno: JSON.stringify(id_aluno)
            }
        });
        return response;
    };




















});