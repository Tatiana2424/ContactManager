using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.DAL.Entities;

public class FileCsv
{
    public string FileName { get; set; }
    public IFormFile FromFile { get; set; }
}
