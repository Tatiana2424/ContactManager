using ContactManager.DAL.Entities;
using CsvHelper.Configuration;
using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using ContactManager.DAL.Persistence;

namespace ContactManager.WebApi.Controllers;

[ApiController]
public class FileController : ControllerBase
{
    private readonly ContactManagerDbContext _context;

    public FileController(ContactManagerDbContext context)
    {
        _context = context;
    }
    [Route("api/file")]
    [HttpPost]
    public async Task<IActionResult> UploadFile(IFormFile formFile)
    {
        try
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                Delimiter = ";",
            };

            using var reader = new StreamReader(formFile.OpenReadStream());
            using var csv = new CsvReader(reader, config);

            var records = csv.GetRecords<ContactData>().ToList();

            foreach (var record in records)
            {
                _context.ContactData.Add(record);
                await _context.SaveChangesAsync();
            }

            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}
