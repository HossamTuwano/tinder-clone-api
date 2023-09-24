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

    [HttpPost]
    public async Task<IActionResult> Post(User user) {
        await _usersService.CreateAsync(user);

        return CreatedAtAction(nameof(Get), new {id = user.Id}, user);


    } 
}