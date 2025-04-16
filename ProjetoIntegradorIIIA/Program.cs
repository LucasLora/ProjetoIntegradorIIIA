using ProjetoIntegradorIIIA.CustomLinkedList;
using ProjetoIntegradorIIIA.Enums;
using ProjetoIntegradorIIIA.Exceptions;
using ProjetoIntegradorIIIA.ListaDeAluno;
using ProjetoIntegradorIIIA.Models;

internal class Program
{
    private static Escola escola;

    private static void Main(string[] args)
    {
        escola = new Escola();

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
        Console.WriteLine("\n=== Cadastro de aluno ===");

        string? nome;
        while (true)
        {
            Console.Write("Digite o nome do aluno: ");
            nome = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(nome))
                break;

            Console.WriteLine("O nome não pode estar vazio.");
        }

        string? cpf;
        while (true)
        {
            Console.Write("Digite o CPF do aluno (apenas números): ");
            cpf = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(cpf) &&
                cpf.Length == 11 &&
                cpf.All(char.IsDigit))
                break;

            Console.WriteLine("CPF inválido! Deve conter exatamente 11 números.");
        }

        DateTime dataNascimento;
        while (true)
        {
            Console.Write("Digite a data de nascimento do aluno (dd/MM/yyyy): ");
            string? stringData = Console.ReadLine();

            if (DateTime.TryParseExact(stringData, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dataNascimento) &&
                dataNascimento <= DateTime.Now)
                break;

            Console.WriteLine("Data inválida! Certifique-se de usar o formato correto (dd/MM/yyyy) e que a data não seja no futuro.");
        }

        string? endereco;
        while (true)
        {
            Console.Write("Digite o endereço do aluno: ");
            endereco = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(endereco))
                break;

            Console.WriteLine("O endereço não pode estar vazio.");

        };

        Console.WriteLine();

        try
        {
            escola.CadastrarAluno(new Aluno(nome, cpf, endereco, dataNascimento));
            Console.WriteLine("Aluno cadastrado com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao cadastrar o aluno: " + ex.Message);
        }

        Console.WriteLine();
    }

    private static void CadastrarTurma()
    {
        Console.WriteLine("\n=== Cadastro de turma ===");

        Console.WriteLine("Selecione a Etapa de Ensino:");
        foreach (EtapaEnsinoEnum etapa in Enum.GetValues(typeof(EtapaEnsinoEnum)))
        {
            Console.WriteLine($"{(int)etapa} - {EnumHelper.GetDescription(etapa)}");
        }

        EtapaEnsinoEnum etapaEnsino;
        while (true)
        {
            Console.Write("Digite o número correspondente à Etapa de Ensino: ");
            if (int.TryParse(Console.ReadLine(), out int opcao) && Enum.IsDefined(typeof(EtapaEnsinoEnum), opcao))
            {
                etapaEnsino = (EtapaEnsinoEnum)opcao;
                break;
            }
            Console.WriteLine("Opção inválida! Por favor, tente novamente.");
        }

        byte ano;
        while (true)
        {
            Console.Write("Digite o ano da turma (número inteiro positivo): ");
            if (byte.TryParse(Console.ReadLine(), out ano) && ano > 0)
                break;

            Console.WriteLine("Ano inválido! Deve ser um número inteiro positivo.");
        }

        int limiteVagas;
        while (true)
        {
            Console.Write("Digite o limite de vagas (número inteiro positivo): ");
            if (int.TryParse(Console.ReadLine(), out limiteVagas) && limiteVagas > 0)
                break;

            Console.WriteLine("Limite de vagas inválido! Deve ser um número inteiro positivo.");
        }

        Console.WriteLine();

        try
        {
            escola.CadastrarTurma(new Turma(etapaEnsino, ano, limiteVagas, new ListaDeAluno()));
            Console.WriteLine("Turma cadastrada com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao cadastrar a turma: " + ex.Message);
        }

        Console.WriteLine();
    }

    private static void MatricularAlunosEmUmaTurma()
    {
        Console.WriteLine("\n=== Matrícula de aluno em turma ===");

        Console.WriteLine("\nTurmas cadastradas:");
        ListarTodasAsTurmasDaEscola();

        int codigoTurma;
        while (true)
        {
            Console.Write("Digite o código da turma: ");
            if (int.TryParse(Console.ReadLine(), out codigoTurma))
                break;

            Console.WriteLine("Código da turma inválido! Por favor, insira um número inteiro.");
        }

        Console.WriteLine("\nAlunos cadastrados:");
        ListarTodosOsAlunosDaEscola();

        int codigoAluno;
        while (true)
        {
            Console.Write("Digite o código do aluno: ");
            if (int.TryParse(Console.ReadLine(), out codigoAluno))
                break;

            Console.WriteLine("Código do aluno inválido! Por favor, insira um número inteiro.");
        }

        Console.WriteLine();

        try
        {
            escola.MatricularAluno(codigoTurma, codigoAluno);
            Console.WriteLine("Aluno matriculado com sucesso!");
        }
        catch (AlunoJaExistenteException)
        {
            Console.WriteLine("Aluno já matriculado nesta turma.");
        }
        catch (LimiteVagasException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao matricular o aluno: " + ex.Message);
        }

        Console.WriteLine();
    }

    private static void ListarTodosOsAlunosDaEscola()
    {
        Console.WriteLine("\n=== Listagem de Alunos da Escola ===");

        if (escola.Alunos.Tamanho() == 0)
        {
            Console.WriteLine("Nenhum aluno cadastrado na escola.");
        }
        else
        {
            Console.WriteLine(string.Join(Environment.NewLine, ObterAlunosFormatados(escola.Alunos.PrimeiroAluno())));
        }

        Console.WriteLine();
    }

    private static IEnumerable<string> ObterAlunosFormatados(CustomLinkedListNode<Aluno> initialNode)
    {
        for (CustomLinkedListNode<Aluno> node = initialNode; node != null; node = node.Next)
        {
            yield return node.value.ToString();
        }
    }

    private static void ListarTodasAsTurmasDaEscola()
    {
        Console.WriteLine("\n=== Listagem de Turmas da Escola ===");

        if (escola.Turmas.Count == 0)
        {
            Console.WriteLine("Nenhuma turma cadastrada na escola.");
        }
        else
        {
            Console.WriteLine(string.Join(Environment.NewLine, escola.Turmas.Select(x => x.ToString())));
        }

        Console.WriteLine();
    }

    private static void ListarAlunosDeUmaTurmaEspecifica()
    {
        Console.WriteLine("\n=== Listagem de Alunos de uma Turma Específica ===");

        Console.WriteLine("\nTurmas cadastradas:");
        ListarTodasAsTurmasDaEscola();

        int codigoTurma;
        while (true)
        {
            Console.Write("Digite o código da turma: ");
            if (int.TryParse(Console.ReadLine(), out codigoTurma))
                break;

            Console.WriteLine("Código da turma inválido! Por favor, insira um número inteiro.");
        }

        Turma? turma = escola.Turmas.FirstOrDefault(x => x.Codigo == codigoTurma);
        if (turma == null)
        {
            Console.WriteLine("\nTurma com o código informado não foi encontrada.");
        }
        else
        {
            if (turma.Alunos.Tamanho() == 0)
            {
                Console.WriteLine("\nNenhum aluno matriculado nesta turma.");
            }
            else
            {
                Console.WriteLine("\nAlunos matriculados na turma:");
                Console.WriteLine(string.Join(Environment.NewLine, ObterAlunosFormatados(turma.Alunos.PrimeiroAluno())));
            }
        }

        Console.WriteLine();
    }

    private static void ContarAlunosForaDaFaixaEtariaPorEtapaDeEnsino()
    {
        Console.WriteLine("\n=== Contagem de Alunos Fora da Faixa Etária ===");

        Console.WriteLine("Selecione a Etapa de Ensino para verificar a faixa etária:");
        foreach (EtapaEnsinoEnum etapa in Enum.GetValues(typeof(EtapaEnsinoEnum)))
        {
            Console.WriteLine($"{(int)etapa} - {EnumHelper.GetDescription(etapa)}");
        }

        EtapaEnsinoEnum etapaSelecionada;
        while (true)
        {
            Console.Write("Digite o número correspondente à Etapa de Ensino: ");
            if (int.TryParse(Console.ReadLine(), out int opcao) && Enum.IsDefined(typeof(EtapaEnsinoEnum), opcao))
            {
                etapaSelecionada = (EtapaEnsinoEnum)opcao;
                break;
            }
            Console.WriteLine("Opção inválida. Tente novamente.");
        }

        var (idadeMinima, idadeMaxima) = ObtemIdadesDaEtapaDeEnsino(etapaSelecionada);

        int totalForaFaixa = 0;
        foreach (var turma in escola.Turmas.Where(x => x.EtapaEnsino == etapaSelecionada))
        {
            for (CustomLinkedListNode<Aluno> node = turma.Alunos.PrimeiroAluno(); node != null; node = node.Next)
            {
                int idade = node.Value.CalcularIdade();
                if (idade < idadeMinima || idade > idadeMaxima)
                {
                    totalForaFaixa++;
                }
            }
        }

        Console.WriteLine($"\nTotal de alunos fora da faixa etária para {EnumHelper.GetDescription(etapaSelecionada)}: {totalForaFaixa}");
        Console.WriteLine();
    }

    private static (int idadeMinima, int idadeMaxima) ObtemIdadesDaEtapaDeEnsino(EtapaEnsinoEnum etapaSelecionada)
    {
        switch (etapaSelecionada)
        {
            case EtapaEnsinoEnum.Infantil:
                return (0, 5);
            case EtapaEnsinoEnum.FundamentalAnosIniciais:
                return (6, 11);
            case EtapaEnsinoEnum.FundamentalAnosFinais:
                return (11, 15);
            case EtapaEnsinoEnum.Medio:
                return (15, 18);
            default:
                return (0, int.MaxValue);
        }
    }
}