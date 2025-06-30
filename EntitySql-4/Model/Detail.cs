namespace EntitySql_4.Model
{
    public class Detail
    {
        public int Id { get; set; } 
        public string Name { get; set; } 
        public string Description { get; set; }
        public string Place { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
