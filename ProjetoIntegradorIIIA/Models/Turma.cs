using ProjetoIntegradorIIIA.Enums;
using ProjetoIntegradorIIIA.ListaDeAluno;

namespace ProjetoIntegradorIIIA.Models
{
    public class Turma
    {
        private static int ultimoCodigo = 0;
        public int Codigo { get; private set; }
        public EtapaEnsinoEnum EtapaEnsino { get; private set; }
        public byte Ano { get; private set; }
        public int LimiteVagas { get; private set; }
        public int QuantidadeMatriculados => Alunos.Tamanho();
        public IListaDeAluno Alunos { get; private set; }

        public Turma(EtapaEnsinoEnum etapaEnsino, byte ano, int limiteVagas, IListaDeAluno alunos)
        {
            Codigo = ++ultimoCodigo;
            EtapaEnsino = etapaEnsino;
            Ano = ano;
            LimiteVagas = limiteVagas;
            Alunos = alunos;
        }

        public override string ToString()
        {
            return $"Código: {Codigo}, Etapa: {EtapaEnsino.GetDescription()}, Ano: {Ano}, Vagas: {QuantidadeMatriculados}/{LimiteVagas}";
        }
    }
}

