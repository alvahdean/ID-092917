using System.Collections.Generic;

namespace IDSkills.Data
{
    public interface IFolkField
    {
        int ID { get; set; }
        string Name { get; set; }
        //ICollection<IFolk> Folks { get; set; }
    }
}