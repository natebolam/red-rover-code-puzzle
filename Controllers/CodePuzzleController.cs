using Microsoft.AspNetCore.Mvc;

namespace CodePuzzle.Controllers;

[ApiController]
[Route("[controller]")]
public class CodePuzzleControlller(ILogger<CodePuzzleControlller> logger) : ControllerBase
{
    private readonly ILogger<CodePuzzleControlller> _logger = logger;

    [HttpPost]
    public IActionResult FormatInput([FromBody] FormatRequest request)
    {
        _logger.LogInformation("Received format request: {Input}", request.Input);
        if (string.IsNullOrWhiteSpace(request.Input))
        {
            return BadRequest("Input string cannot be empty.");
        }

        Tree tree = Tree.FromString(request.Input);
        string res = tree.ToString(request.Sorted);
        _logger.LogInformation("Tree output: {Output}", res); 
       
        return Ok(res);
    }
}
