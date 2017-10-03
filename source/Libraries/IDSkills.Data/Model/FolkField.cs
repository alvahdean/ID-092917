using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace IDSkills.Data
{

    [DataContract]
    public class FolkField
    {
        public FolkField()
        {
            Folks = new List<Folk>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember(EmitDefaultValue = true, IsRequired = true)]
        public int ID { get; set; }

        [DataMember]
        [MaxLength(30)]
        public string Name { get; set; }

        [DataMember]
        public ICollection<Folk> Folks { get; set; }


    }
}
