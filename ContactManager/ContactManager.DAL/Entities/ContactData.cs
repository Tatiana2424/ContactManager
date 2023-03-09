using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ContactManager.DAL.Entities;

public class ContactData
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Date of birth is required")]
    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }

    public bool Married { get; set; }

    [RegularExpression(@"^(\d{3}-\d{3}-\d{4})?$", ErrorMessage = "Invalid phone number")]
    public string Phone { get; set; }

    [Required(ErrorMessage = "Salary is required")]
    [Range(0, int.MaxValue, ErrorMessage = "Salary must be a positive value")]
    public decimal Salary { get; set; }


}
