using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminTask.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name{ get; set; }
        [DataType(DataType.Url)]
        [Required]
        public string Website { get; set; }
        [MaxLength(300)]
        public string Address { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
