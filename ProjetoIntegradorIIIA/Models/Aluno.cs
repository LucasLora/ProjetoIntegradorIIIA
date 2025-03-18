namespace ProjetoIntegradorIIIA.Models
{
    public class Aluno
    {
        private static int ultimoCodigo = 0;
        public int Codigo { get; private set; }
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public string Endereco { get; private set; }
        public DateTime DataNascimento { get; private set; }

        public Aluno(string nome, string cpf, string endereco, DateTime dataNascimento)
        {
            Codigo = ++ultimoCodigo;
            Nome = nome;
            Cpf = cpf;
            Endereco = endereco;
            DataNascimento = dataNascimento;
        }

        public override string ToString()
        {
            int idade = CalcularIdade();
            return $"{Codigo} - {Nome} - {idade} anos";
        }

        private int CalcularIdade()
        {
            DateTime hoje = DateTime.Today;
            int idade = hoje.Year - DataNascimento.Year;
            if (DataNascimento > hoje.AddYears(-idade))
                idade--;
            return idade;
        }
    }
}
