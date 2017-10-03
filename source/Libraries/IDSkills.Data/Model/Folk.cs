using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace IDSkills.Data
{
    /// <summary>
    /// Represents a famous person
    /// </summary>
    /// <remarks>
    /// The provided table spec is below:
    /// CREATE TABLE[Folks]
    /// (
    ///    ID              int IDENTITY(1,1) PRIMARY KEY NOT NULL,
    ///    FirstName       varchar(30) NOT NULL,
    ///    LastName        varchar(30) NOT NULL,
    ///    BirthLocation   varchar(80) NOT NULL,
    ///    Bio             varchar(4096) NOT NULL
    /// )
    /// </remarks>
    [DataContract]
    public class Folk : IFolk
    {
        public Folk() { }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember(EmitDefaultValue = true, IsRequired = true)]
        public int ID { get; set; }

        [DataMember]
        [Required, MinLength(1), MaxLength(30)]
        public string FirstName { get; set; }

        [DataMember]
        [Required, MinLength(1), MaxLength(30)]
        public string LastName { get; set; }

        [DataMember]
        [MaxLength(80)]
        public string BirthLocation { get; set; }

        [DataMember]
        [MaxLength(4096)]
        public string Bio { get; set; }

        [DataMember(EmitDefaultValue = true, IsRequired = false)]
        public int? FolkFieldID { get; set; }

        [IgnoreDataMember]
        public FolkField FolkField { get; set; }
    }
}
