namespace OrayaAct.Models
{
    public enum Rank
    {
        Instructor,
        AssistantProfessor,
        AssociateProfessor,
        Professor
    }

    public class Instructor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Rank Rank { get; set; }
        public Boolean IsTenured { get; set; }
        public DateOnly HiringDate { get; set; }

    }
}
