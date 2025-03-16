namespace ProjetoIntegradorIIIA.Models
{
    public class Aluno
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Endereco { get; set; }
        public DateTime DataNascimento { get; set; }

        public Aluno(int codigo, string nome, string cpf, string endereco, DateTime dataNascimento)
        {
            Codigo = codigo;
            Nome = nome;
            Cpf = cpf;
            Endereco = endereco;
            DataNascimento = dataNascimento;
        }
    }
}
