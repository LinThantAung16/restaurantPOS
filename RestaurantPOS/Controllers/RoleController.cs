using Microsoft.AspNetCore.Mvc;
using RestaurantPOS.Domain.Model.Role;

namespace RestaurantPOS.Controllers;
[Tags("Admin User")]
[Route("api/[controller]")]
[ApiController]

public class RoleController : ControllerBase
{
    private readonly BL_Role bL_Role;
    public RoleController(BL_Role bL_Role)
    {
        this.bL_Role = bL_Role;
    }
    [HttpGet("List")]
    public async Task<IActionResult> List()
    {
        var result = await bL_Role.List();
            return Ok(result.Data);
        

    }
}

