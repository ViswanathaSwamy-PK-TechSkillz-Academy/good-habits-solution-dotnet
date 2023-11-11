using GoodHabits.Persistence.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GoodHabits.UserService.Controllers;

[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly ILogger<UsersController> _logger;

    public UsersController(ILogger<UsersController> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [HttpGet()]
    public async Task<IActionResult> GetAsync()
    {
        return Ok(new List<User>()
        {
            new() { Id = 111, FirstName = "Roger", LastName = "Waters", Email = "rw@pf.com"},

            new() { Id = 222, FirstName = "Dave", LastName = "Gilmore", Email = "dg@pf.com"},

            new() { Id = 333, FirstName = "Nick", LastName = "Mason", Email = "nm@pf.com"}
        });
    }
}