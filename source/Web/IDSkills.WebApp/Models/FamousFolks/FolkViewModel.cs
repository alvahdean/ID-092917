using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IDSkills.Data;
using System.ComponentModel.DataAnnotations;

namespace IDSkills.WebApp.Models.FamousFolks
{
    public class FolkViewModel
    {
        public FolkViewModel()
        {

        }

        public FolkViewModel(Folk folk)
            :this()
        {
            if (folk == null)
                return;
            ID = folk.ID;
            FirstName = folk.FirstName;
            LastName = folk.LastName;
            BirthLocation = folk.BirthLocation??"Unspecified";
            BioText = folk.Bio??"No biography provided";
            FieldOfExpertise = folk.FolkField?.Name??"Unspecified";
        }

        [Required]
        [Display(Name = "ID")]
        public int ID { get; set; }

        [Required, MinLength(1), MaxLength(30)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required, MinLength(1), MaxLength(30)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Name")]
        public string FullName { get { return $"{LastName}, {FirstName}"; } }

        [Display(Name="Birth Location")]
        public string BirthLocation { get; set; }

        [Display(Name = "Biography")]
        public string BioText { get; set; }

        [Display(Name = "Field of Expertise")]
        public string FieldOfExpertise { get; set; }
    }
}
