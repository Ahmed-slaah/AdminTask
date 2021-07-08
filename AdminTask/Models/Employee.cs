using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminTask.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [DataType(DataType.EmailAddress)]
        [MaxLength(50)]
        public string Email { get; set; }
        public Company company { get; set; }
    }
}
