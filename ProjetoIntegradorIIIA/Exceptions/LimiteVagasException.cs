namespace ProjetoIntegradorIIIA.Exceptions
{
    public class LimiteVagasException : Exception
    {
        public LimiteVagasException() { }

        public LimiteVagasException(string message)
            : base(message) { }
    }
}
