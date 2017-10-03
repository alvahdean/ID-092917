using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IDSkills.Data;
using System.ComponentModel.DataAnnotations;

namespace IDSkills.WebApp.Models.FamousFolks
{
    public class BioViewModel
    {
        public BioViewModel()
        {

        }

        public BioViewModel(Folk folk)
            :this()
        {
            if (folk == null)
                return;
            BioText = folk.Bio??"No biography provided";
            FieldOfExpertise = folk.FolkField?.Name??"Unspecified";
        }

        [Required]
        [Display(Name = "Biography")]
        public string BioText { get; set; }

        [Required]
        [Display(Name = "Field of Expertise")]
        public string FieldOfExpertise { get; set; }
    }
}
