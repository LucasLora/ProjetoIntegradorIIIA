using System.ComponentModel;

namespace ProjetoIntegradorIIIA.Enums
{
    public enum EtapaEnsinoEnum
    {
        [Description("Educação Infantil")]
        Infantil = 0,

        [Description("Ensino Fundamental Anos Iniciais")]
        FundamentalAnosIniciais = 1,

        [Description("Ensino Fundamental Anos Finais")]
        FundamentalAnosFinais = 2,

        [Description("Ensino Médio")]
        Medio = 3,
    }
}
