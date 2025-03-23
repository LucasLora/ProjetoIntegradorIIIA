namespace ProjetoIntegradorIIIA.Exceptions
{
    public class AlunoJaExistenteException : Exception
    {
        public AlunoJaExistenteException() { }

        public AlunoJaExistenteException(string message)
            : base(message) { }
    }
}
