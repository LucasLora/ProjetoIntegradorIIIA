namespace ProjetoIntegradorIIIA.Models
{
    class Escola
    {
        public List<Turma> Turmas { get; private set; }
        public ListaDeAluno.ListaDeAluno Alunos { get; private set; }

        public Escola()
        {
            Turmas = new List<Turma>();
            Alunos = new ListaDeAluno.ListaDeAluno();
        }

        public void CadastrarTurma(Turma turma)
        {
            if (turma == null)
                throw new ArgumentNullException(nameof(turma), "Turma não pode ser nula.");

            Turmas.Add(turma);
        }

        public void CadastrarAluno(Aluno aluno)
        {
            if (aluno == null)
                throw new ArgumentNullException(nameof(aluno), "Aluno não pode ser nulo.");

            Alunos.IncluirNoFim(aluno);
        }

        /// <summary>
        /// Matricula um aluno em uma turma, validando que:
        /// - A turma exista.
        /// - O aluno exista (na lista de alunos da escola).
        /// - O aluno não esteja já matriculado na turma.
        /// - A turma ainda tenha vagas.
        /// </summary>
        /// <param name="codigoTurma">Código da turma</param>
        /// <param name="codigoAluno">Código do aluno</param>
        public void MatricularAluno(int codigoTurma, int codigoAluno)
        {
            Turma? turma = Turmas.FirstOrDefault(t => t.Codigo == codigoTurma);
            if (turma == null)
                throw new Exception("Turma não encontrada.");

            Aluno? aluno = Alunos.GetByCodigo(codigoAluno);
            if (aluno == null)
                throw new Exception("Aluno não encontrado.");

            if (turma.Alunos.GetByCodigo(codigoAluno) != null)
                throw new Exception("Aluno já matriculado nesta turma.");

            if (turma.QuantidadeMatriculados >= turma.LimiteVagas)
                throw new Exception("A turma já atingiu o limite de vagas.");

            turma.Alunos.IncluirNoFim(aluno);
        }

        public ListaDeAluno.ListaDeAluno ObterTodosOsAlunos()
        {
            return Alunos; 
        }

        public List<Turma> ObterTodasAsTurmas()
        {
            return Turmas.ToList(); 
        }
    }


}
