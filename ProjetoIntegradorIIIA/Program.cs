using ProjetoIntegradorIIIA.Enums;

internal class Program
{
    private static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== MENU PRINCIPAL ===");

            foreach (MenuOptionEnum option in Enum.GetValues(typeof(MenuOptionEnum)))
            {
                Console.WriteLine($"{(int)option} - {option.GetDescription()}");
            }

            Console.Write("Escolha uma opção: ");
            string? input = Console.ReadLine();

            if (!int.TryParse(input, out int menuOption))
            {
                Console.WriteLine("Por favor somente o número! Pressione qualquer tecla para tentar novamente.");
                Console.ReadKey();
                continue;
            }

            MenuOptionEnum escolha = (MenuOptionEnum)menuOption;

            switch (escolha)
            {
                case MenuOptionEnum.Sair:
                    Sair();
                    return;

                case MenuOptionEnum.CadastrarAluno:
                    CadastrarAluno();
                    break;

                case MenuOptionEnum.CadastrarTurma:
                    CadastrarTurma();
                    break;

                case MenuOptionEnum.MatricularAlunosEmUmaTurma:
                    MatricularAlunosEmUmaTurma();
                    break;

                case MenuOptionEnum.ListarTodosOsAlunosDaEscola:
                    ListarTodosOsAlunosDaEscola();
                    break;

                case MenuOptionEnum.ListarTodasAsTurmasDaEscola:
                    ListarTodasAsTurmasDaEscola();
                    break;

                case MenuOptionEnum.ListarAlunosDeUmaTurmaEspecifica:
                    ListarAlunosDeUmaTurmaEspecifica();
                    break;

                case MenuOptionEnum.ContarAlunosForaDaFaixaEtariaPorEtapaDeEnsino:
                    ContarAlunosForaDaFaixaEtariaPorEtapaDeEnsino();
                    break;

                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }

            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }

    private static void Sair()
    {
        Console.WriteLine("Saindo...");
    }

    private static void CadastrarAluno()
    {
        Console.WriteLine("Funcionalidade de cadastro de aluno.");
    }

    private static void CadastrarTurma()
    {
        Console.WriteLine("Funcionalidade de cadastro de turma.");
    }

    private static void MatricularAlunosEmUmaTurma()
    {
        Console.WriteLine("Funcionalidade de matrícula de aluno em turma.");
    }

    private static void ListarTodosOsAlunosDaEscola()
    {
        Console.WriteLine("Funcionalidade de listagem de todos os alunos.");
    }

    private static void ListarTodasAsTurmasDaEscola()
    {
        Console.WriteLine("Funcionalidade de listagem de todas as turmas.");
    }

    private static void ListarAlunosDeUmaTurmaEspecifica()
    {
        Console.WriteLine("Funcionalidade de listagem de alunos de uma turma específica.");
    }

    private static void ContarAlunosForaDaFaixaEtariaPorEtapaDeEnsino()
    {
        Console.WriteLine("Funcionalidade de contagem de alunos fora da faixa etária por etapa de ensino.");
    }
}