using System;
using System.ComponentModel.DataAnnotations;

namespace Kutse.Models
{
    public class Holiday
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Название праздника")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Дата проведения")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}