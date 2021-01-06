using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Edmund.API.Resources.EducationalStage
{
    public class SaveEducationalStageResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
