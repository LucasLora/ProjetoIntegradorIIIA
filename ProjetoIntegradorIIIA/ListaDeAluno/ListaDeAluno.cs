using ProjetoIntegradorIIIA.CustomLinkedList;
using ProjetoIntegradorIIIA.Exceptions;
using ProjetoIntegradorIIIA.Models;

namespace ProjetoIntegradorIIIA.ListaDeAluno
{
    public class ListaDeAluno : IListaDeAluno
    {
        private CustomLinkedList<Aluno> lista;

        public ListaDeAluno() => lista = new CustomLinkedList<Aluno>();

        public void IncluirNoInicio(Aluno aluno)
        {
            VerificaSeAlunoJaFoiIncluido(aluno);
            lista.AddFirst(aluno);
        }

        public void IncluirNoFim(Aluno aluno)
        {
            VerificaSeAlunoJaFoiIncluido(aluno);
            lista.AddLast(aluno);
        }

        private void VerificaSeAlunoJaFoiIncluido(Aluno aluno)
        {
            for (CustomLinkedListNode<Aluno> node = lista.First; node != null; node = node.Next)
            {
                if (node.Value.Equals(aluno))
                {
                    throw new AlunoJaExistenteException();
                }
            }
        }

        public void Ordenar() => lista.Sort((a, b) => string.Compare(a.Nome, b.Nome, StringComparison.OrdinalIgnoreCase));

        public void RemoverDoInicio() => lista.RemoveFirst();

        public void RemoverDoFim() => lista.RemoveLast();

        public int Tamanho() => lista.Count;

        public CustomLinkedListNode<Aluno> PrimeiroAluno() => lista.First;

        public Aluno? GetByCodigo(int codigo)
        {
            for (CustomLinkedListNode<Aluno> node = lista.First; node != null; node = node.Next)
            {
                if (node.Value.Codigo == codigo)
                    return node.Value;
            }

            return null;
        }

        public Aluno? Get(int pos)
        {
            if (pos < 0 || pos >= lista.Count)
                throw new IndexOutOfRangeException();

            int i = 0;
            for (CustomLinkedListNode<Aluno> node = lista.First; node != null; node = node.Next)
            {
                if (i == pos)
                    return node.Value;
                i++;
            }

            return null;
        }
    }
}
