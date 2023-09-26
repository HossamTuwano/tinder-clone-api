using UserStoreApi.Models;
using UserStoreApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace UserStoreApi.Controllers;

[ApiController]
[Route("api/[controller]")]

public class UsersContoller : ControllerBase
{
    private readonly UsersService _usersService;

    public UsersContoller(UsersService usersService) => _usersService = usersService;

    [HttpGet]


    public async Task<List<User>> Get() => await _usersService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<User>> Get(string id)
    {
        var user = await _usersService.GetAsync(id);

        if (user is null)
        {
            return NotFound();
        }

        return user;
    }

    [HttpPost]
    public async Task<IActionResult> Post(User user) {
        await _usersService.CreateAsync(user);

        return CreatedAtAction(nameof(Get), new {id = user.Id}, user);


    } 


    //update controller
    
    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, User updatedUser)
    {
        var user = await _usersService.GetAsync(id);

        if (user is null)
        {
            return NotFound();
        }

        updatedUser.Id = user.Id;

        await _usersService.UpdateAsync(id, updatedUser);

        return NoContent();
    }
}