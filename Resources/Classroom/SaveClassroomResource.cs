﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Edmund.API.Resources.Classroom
{
    public class SaveClassroomResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
