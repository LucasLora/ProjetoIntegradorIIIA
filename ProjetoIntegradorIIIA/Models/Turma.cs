using ProjetoIntegradorIIIA.Enums;

namespace ProjetoIntegradorIIIA.Models
{
    public class Turma
    {
        public int Codigo { get; set; }
        public EtapaEnsinoEnum EtapaEnsino { get; set; }
        public byte Ano { get; set; }
        public int LimiteVagas { get; set; }
        public int QuantidadeMatriculados { get; set; }

        public Turma(int codigo, EtapaEnsinoEnum etapaEnsino, byte ano, int limiteVagas)
        {
            Codigo = codigo;
            EtapaEnsino = etapaEnsino;
            Ano = ano;
            LimiteVagas = limiteVagas;
            QuantidadeMatriculados = 0;
        }
    }
}

