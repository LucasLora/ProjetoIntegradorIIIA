using ProjetoIntegradorIIIA.Enums;
using ProjetoIntegradorIIIA.ListaDeAluno;

namespace ProjetoIntegradorIIIA.Models
{
    public class Turma
    {
        public int Codigo { get; set; }
        public EtapaEnsinoEnum EtapaEnsino { get; set; }
        public byte Ano { get; set; }
        public int LimiteVagas { get; set; }
        public int QuantidadeMatriculados => Alunos.Tamanho();
        public IListaDeAluno Alunos { get; set; }

        public Turma(int codigo, EtapaEnsinoEnum etapaEnsino, byte ano, int limiteVagas, IListaDeAluno listaDeAluno)
        {
            Codigo = codigo;
            EtapaEnsino = etapaEnsino;
            Ano = ano;
            LimiteVagas = limiteVagas;
            Alunos = listaDeAluno;
        }
    }
}

