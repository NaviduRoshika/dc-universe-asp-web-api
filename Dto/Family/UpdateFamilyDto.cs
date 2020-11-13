namespace alone_mysql_dc_comics.Dto.Family
{
    public class UpdateFamilyDto
    {
        public string FatherName { get; set; } = "nochange";
        public string MotherName { get; set; } = "nochange";
        public string Relationship { get; set; } = "nochange";
        public string child { get; set; } = "nochange";
        public int CharacterId { get; set; }
    }
}