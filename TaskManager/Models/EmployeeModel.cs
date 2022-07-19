using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Models
{
    [Table("Employee4")]
    public class EmployeeModel : EntityBase
    {

        [DisplayName("Imię")]
        [Required(ErrorMessage = "Pole Imię jest wymagane!")]
        [MaxLength(50)]
        public string Name { get; set; }

        [DisplayName("Nazwisko")]
        [Required(ErrorMessage = "Pole Nazwisko jest wymagane!")]
        [MaxLength(50)]
        public string Surname { get; set; }

        [DisplayName("Wiek")]
        public int Age { get; set; }

        [DisplayName("Stanowisko")]
        public string Position { get; set; }

        [DisplayName("Doświadczenie")]
        public int YearsOfExperience { get; set; }
        public bool Done { get; set; }


    }
}
