namespace alone_mysql_dc_comics.Models
{
    public class Family
    {
        public int FamilyId { get; set; }
        public string FatherName { get; set; } = "unknown";
        public string MotherName { get; set; } = "unknown";
        public string Relationship { get; set; } 
        public string child { get; set; }
        public int CharacterId { get; set; }
        public Character Character { get; set; }
    }
}