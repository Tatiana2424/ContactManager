using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.BLL.DTO;

public class ContactDataDTO
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string DateOfBirth { get; set; }

    public string Married { get; set; }

    public string Phone { get; set; }

    public decimal Salary { get; set; }
}
