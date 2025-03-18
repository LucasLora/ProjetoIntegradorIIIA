using System.ComponentModel;

namespace ProjetoIntegradorIIIA.Enums
{
    public enum MenuOptionEnum
    {
        [Description("Sair")]
        Sair = 0,

        [Description("Cadastrar Aluno")]
        CadastrarAluno = 1,

        [Description("Cadastrar Turma")]
        CadastrarTurma = 2,

        [Description("Matricular Alunos em uma Turma")]
        MatricularAlunosEmUmaTurma = 3,

        [Description("Listar Todos os Alunos da Escola")]
        ListarTodosOsAlunosDaEscola = 4,

        [Description("Listar Todas as Turmas da Escola")]
        ListarTodasAsTurmasDaEscola = 5,

        [Description("Listar Alunos de uma Turma Específica")]
        ListarAlunosDeUmaTurmaEspecifica = 6,

        [Description("Contar Alunos Fora da Faixa Etária por Etapa de Ensino")]
        ContarAlunosForaDaFaixaEtariaPorEtapaDeEnsino = 7
    }
}
