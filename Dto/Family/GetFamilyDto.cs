namespace alone_mysql_dc_comics.Dto.Family
{
    public class GetFamilyDto
    {
        public string FatherName { get; set; } = "unknown";
        public string MotherName { get; set; } = "unknown";
        public string Relationship { get; set; } = "unknown";
        public string child { get; set; } = "unknown";
        public int CharacterId { get; set; }
    }
}