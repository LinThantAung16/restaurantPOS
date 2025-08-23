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

    [HttpGet("Edit/{roleCode}")]
    public async Task<IActionResult> Edit(string roleCode)
    {
        return Ok(await bL_Role.Edit(roleCode));
    }
    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] roleCreateRequestModel req)
    {
        return Ok(await bL_Role.Create(req));
    }

    [HttpPost("Update")]
    public async Task<IActionResult> Update([FromBody] roleUpdateRequestModel req)
    {
        return Ok(await bL_Role.Update(req));
    }

    [HttpPost("Delete/{roleCode}")]
    public async Task<IActionResult> Delete(string roleCode)
    {
        return Ok(await bL_Role.Delete(roleCode));
    }
}

