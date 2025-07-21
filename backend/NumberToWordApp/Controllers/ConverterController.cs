using Microsoft.AspNetCore.Mvc;
using NumberToWordApp.Services;
using NumberToWordApp.Models;

namespace NumberToWordApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ConvertController : ControllerBase
{
    private readonly INumberToWordsConverter _converter;

    public ConvertController(INumberToWordsConverter converter)
    {
        _converter = converter;
    }

    [HttpPost]
    public IActionResult ConvertNumber([FromBody] ConvertRequest request)
    {
        if (!decimal.TryParse(request.Amount, out var parsedAmount))
        {
            return BadRequest(new ConvertResponse { Result = "Invalid entry, please enter a number." });
        }

        var result = _converter.Convert(parsedAmount);
        return Ok(new ConvertResponse { Result = result });
    }

}
