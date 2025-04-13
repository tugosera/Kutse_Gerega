﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace kutse_app.Models
{
    public class Guest
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Sisestage nimi!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Sisestage email!")]
        [RegularExpression(@".+\@.+\..+", ErrorMessage = "Valesti sisestatud email!")]

        public string Email { get; set; }
        [Required(ErrorMessage = "Sisestage telefoni number!")]
        [RegularExpression(@"\+372.+", ErrorMessage = "Numbri alguses peal olema +372")]

        public string Phone { get; set; }
        [Required(ErrorMessage = "Sisestage oma valik!")]

        public bool? WillAttend { get; set; }
    }
}