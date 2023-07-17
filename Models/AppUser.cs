﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace AppMVC01.Models
{
    public class AppUser : IdentityUser
    {
        [Column(TypeName = "nvarchar")]
        [StringLength(400)]
        public string HomeAdress { get; set; }

        // [Required]       
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }
    }
}

