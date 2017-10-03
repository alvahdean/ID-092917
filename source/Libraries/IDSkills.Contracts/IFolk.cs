namespace IDSkills.Data
{
    public interface IFolk
    {
        string Bio { get; set; }
        string BirthLocation { get; set; }
        string FirstName { get; set; }
        int ID { get; set; }
        string LastName { get; set; }
        //IFolkField FolkField { get; set; }
    }
}