using ProjetoIntegradorIIIA.CustomLinkedList;
using ProjetoIntegradorIIIA.Enums;
using ProjetoIntegradorIIIA.ListaDeAluno;
using ProjetoIntegradorIIIA.Models;
using System.ComponentModel;

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
        Console.WriteLine("=== Cadastro de aluno ===");

        // Validação de Nome
        string nome;
        while (true)
        {
            Console.Write("Digite o nome do aluno: ");
            nome = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(nome))
                break;

            Console.WriteLine("O nome não pode estar vazio.");
        } 

        // Validação de cpf
        string cpf;
        while (true)
        {
            Console.Write("Digite o CPF do aluno (apenas números): ");
            cpf = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(cpf) && cpf.Length == 11 && cpf.All(char.IsDigit))
                break;

            Console.WriteLine("CPF inválido! Deve conter exatamente 11 números.");
        }


        // Validação de data do nascimento  
        DateTime dataNascimento;
        bool dataValida;
        do
        {
            dataValida = true;
            Console.Write("Digite a data de nascimento do aluno (dd/MM/yyyy): ");
            string stringData = Console.ReadLine();
            if (!DateTime.TryParse(stringData, out dataNascimento))
            {
                Console.WriteLine("Data inválida! Digite no formato correto (dd/MM/yyyy).");
                dataValida = false;
            }
            else
            {
                if (dataNascimento > DateTime.Now)
                {
                    Console.WriteLine("A data de nascimento não pode ser no futuro.");
                    dataValida = false;
                }
            }

        } while (!dataValida);

        // Validação de endereço
        string endereco;
        while (true)
        {
            Console.Write("Digite o endereço do aluno: ");
            endereco = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(endereco))
                break;

            Console.WriteLine("O endereço não pode estar vazio.");

        };

        // Criando o objeto Aluno com os valores validados
        Aluno novoAluno = new Aluno(nome, cpf, endereco, dataNascimento);
        try
        {
            // Cadastrando o aluno na escola
            escola.CadastrarAluno(novoAluno);
            Console.WriteLine("Aluno cadastrado com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao cadastrar o aluno: " + ex.Message);
        }
    }

    private static void CadastrarTurma()
    {
        Console.WriteLine("=== Cadastro de turma ===");

        // Exibe as opções de Etapa de Ensino com suas descrições
        Console.WriteLine("Selecione a Etapa de Ensino:");
        foreach (EtapaEnsinoEnum etapa in Enum.GetValues(typeof(EtapaEnsinoEnum)))
        {
            string descricao = EnumHelper.GetDescription(etapa);
            int valor = (int)etapa;
            Console.WriteLine($"{(int)etapa} - {descricao}");
        }

        // Validação da etapa de ensino
        EtapaEnsinoEnum etapaEnsino;
        while (true)
        {
            Console.Write("Digite o número correspondente à Etapa de Ensino: ");
            string stringEtapa = Console.ReadLine();
            if (int.TryParse(stringEtapa, out int opcao) && Enum.IsDefined(typeof(EtapaEnsinoEnum), opcao))
            {
                etapaEnsino = (EtapaEnsinoEnum)opcao;
                break;
            }
            Console.WriteLine("Opção inválida! Por favor, tente novamente.");
        }

        // Validação do ano da turma
        byte ano;
        while (true)
        {
            Console.Write("Digite o ano da turma (número inteiro positivo): ");
            string stringAno = Console.ReadLine();
            if (byte.TryParse(stringAno, out ano) && ano > 0)
            {
                break;
            }
            Console.WriteLine("Ano inválido! Deve ser um número inteiro positivo.");
        }

        // Validação do limite de vagas
        int limiteVagas;
        while (true)
        {
            Console.Write("Digite o limite de vagas (número inteiro positivo): ");
            string stringLimite = Console.ReadLine();
            if (int.TryParse(stringLimite, out limiteVagas) && limiteVagas > 0)
            {
                break;
            }
            Console.WriteLine("Limite de vagas inválido! Deve ser um número inteiro positivo.");
        }

        // Instancia a lista de alunos (supondo que exista uma implementação, como 'ListaDeAluno')
        IListaDeAluno alunos = new ListaDeAluno();
        try
        {
            // Cadastra a turma na escola
            escola.CadastrarTurma(new Turma(etapaEnsino, ano, limiteVagas, alunos));

            Console.WriteLine("Turma cadastrada com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao cadastrar a turma: " + ex.Message);
        }
    }

    private static void MatricularAlunosEmUmaTurma()
    {
        Console.WriteLine("=== Matrícula de aluno em turma ===");

        int codigoTurma;
        while (true)
        {
            Console.Write("Digite o código da turma: ");
            string stringCodigoTurma = Console.ReadLine();
            if (int.TryParse(stringCodigoTurma, out codigoTurma))
                break;
            Console.WriteLine("Código da turma inválido! Por favor, insira um número inteiro.");
        }

        int codigoAluno;
        while (true)
        {
            Console.Write("Digite o código do aluno: ");
            string stringCodigoAluno = Console.ReadLine();
            if (int.TryParse(stringCodigoAluno, out codigoAluno))
                break;
            Console.WriteLine("Código do aluno inválido! Por favor, insira um número inteiro.");
        }

        try
        {
            escola.MatricularAluno(codigoTurma, codigoAluno);
            Console.WriteLine("Aluno matriculado com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao matricular o aluno: " + ex.Message);
        }
    }

    private static void ListarTodosOsAlunosDaEscola()
    {
        Console.WriteLine("=== Listagem de Alunos da Escola ===");

        ListaDeAluno alunos = escola.ObterTodosOsAlunos(); // Chama o método da classe Escola

        if (alunos.Tamanho() == 0)
        {
            Console.WriteLine("Nenhum aluno cadastrado na escola.");
            return;
        }

        // Busca o primeiro aluno da lista
        CustomLinkedListNode<Aluno> nodo = alunos.PrimeiroAluno();
        CustomLinkedListNode<Aluno> head = nodo;

        // Lista Circular
        do
        {
            // Exibe as informações do aluno atual
            Aluno aluno = nodo.Value;
            Console.WriteLine($"Código: {aluno.Codigo} | Nome: {aluno.Nome} | CPF: {aluno.Cpf} | Data de Nascimento: {aluno.DataNascimento:dd/MM/yyyy}");

            // Avança para o próximo nó
            nodo = nodo.Next;

        } while (nodo != null && nodo != head);
    }

    private static void ListarTodasAsTurmasDaEscola()
    {
        Console.WriteLine("=== Listagem de Turmas da Escola ===");

        var turmas = escola.ObterTodasAsTurmas(); // Chama o método da classe Escola

        if (!turmas.Any())
        {
            Console.WriteLine("Nenhuma turma cadastrada na escola.");
            return;
        }

        foreach (var turma in turmas)
        {
            Console.WriteLine($"Código: {turma.Codigo} | Etapa de Ensino: {turma.EtapaEnsino} | Ano: {turma.Ano} | Vagas: {turma.LimiteVagas} | Matriculados: {turma.QuantidadeMatriculados}");
        }
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