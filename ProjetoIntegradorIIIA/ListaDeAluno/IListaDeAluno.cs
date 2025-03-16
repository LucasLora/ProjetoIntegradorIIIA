using ProjetoIntegradorIIIA.Models;

namespace ProjetoIntegradorIIIA.ListaDeAluno
{
    public interface IListaDeAluno
    {
        void IncluirNoInicio(Aluno aluno);
        void IncluirNoFim(Aluno aluno);
        void Ordenar();
        void RemoverDoInicio();
        void RemoverDoFim();
        int Tamanho();
        Aluno? GetByCodigo(int codigo);
    }
}