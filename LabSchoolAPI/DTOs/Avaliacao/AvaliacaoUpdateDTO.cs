namespace LabSchoolAPI.DTOs
{
    public class AvaliacaoUpdateDTO
    {
        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public string Materia { get; set; }

        public double PontuacaoMaxima { get; set; }

        public double Nota { get; set; }

        public DateTime DataRealizacao { get; set; }

        public int AvaliacaoId { get; set; }
        
        public int ProfessorId { get; set; }

        public int AlunoId { get; set; }
    }
}