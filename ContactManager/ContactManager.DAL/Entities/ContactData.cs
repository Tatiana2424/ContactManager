using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CsvHelper.Configuration.Attributes;

namespace ContactManager.DAL.Entities;

public class ContactData
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Ignore]
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters")]
    [CsvHelper.Configuration.Attributes.Name("Name")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Date of birth is required")]
    [DataType(DataType.Date)]
    [CsvHelper.Configuration.Attributes.Name("DateOfBirth")]
    public DateTime DateOfBirth { get; set; }
    [CsvHelper.Configuration.Attributes.Name("IsMarried")]
    public bool Married { get; set; }

    [RegularExpression(@"^(\d{3}-\d{3}-\d{4})?$", ErrorMessage = "Invalid phone number")]
    [CsvHelper.Configuration.Attributes.Name("PhoneNumber")]
    public string Phone { get; set; }

    [Required(ErrorMessage = "Salary is required")]
    [Range(0, int.MaxValue, ErrorMessage = "Salary must be a positive value")]
    [CsvHelper.Configuration.Attributes.Name("Salary")]
    public decimal Salary { get; set; }


}
