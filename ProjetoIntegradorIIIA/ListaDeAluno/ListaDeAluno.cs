using ProjetoIntegradorIIIA.CustomLinkedList;
using ProjetoIntegradorIIIA.Models;

namespace ProjetoIntegradorIIIA.ListaDeAluno
{
    public class ListaDeAluno
    {
        private CustomLinkedList<Aluno> lista;

        public ListaDeAluno() => lista = new CustomLinkedList<Aluno>();

        public void IncluirNoInicio(Aluno aluno) => lista.AddFirst(aluno);

        public void IncluirNoFim(Aluno aluno) => lista.AddLast(aluno);

        public void Ordenar() => lista.Sort((a, b) => string.Compare(a.Nome, b.Nome, StringComparison.OrdinalIgnoreCase));

        public void RemoverDoInicio() => lista.RemoveFirst();

        public void RemoverDoFim() => lista.RemoveLast();

        public int Tamanho() => lista.Count;

        public Aluno? GetByCodigo(int codigo)
        {
            for (CustomLinkedListNode<Aluno> node = lista.First; node != null; node = node.Next)
            {
                if (node.Value.Codigo == codigo)
                    return node.Value;
            }

            return null;
        }
    }
}
