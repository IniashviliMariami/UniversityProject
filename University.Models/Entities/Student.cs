using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Models.Entities
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(11)]
        [Column(TypeName = "CHAR(11)")]
        public string PersonalNumber { get; set; }

        [Required]
        [MaxLength(50)]
        [EmailAddress]
        [Column(TypeName = "VARCHAR(50)")]
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
    }


}
