using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;


namespace TestApp.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UsersController : ControllerBase
  {
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    public UsersController(IMapper mapper, IUserRepository userRepository)
    {
      this._mapper = mapper;
      this._userRepository = userRepository;
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {

      List<Users> userList = _userRepository.getUsers();
      return Ok(userList);
    }

    [HttpGet("{role}/{name}")]
    public async Task<IActionResult> Get([FromRoute] int role, [FromRoute] string name)
    {

      // Instantiate source object
      // (Get it from the database or whatever your code calls for)

      List<Users> userList = _userRepository.getUsers(role, name);
      return Ok(userList);
      // .... Do whatever you want after that!
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] string id)
    {
      Users user = _userRepository.getUser(id);
      return Ok(user);
    }
    [HttpPost]
    public async Task<IActionResult> AddUser([FromBody] Users user)
    {
     bool b= _userRepository.createUser(user);
      return Ok(b);
    }
  }
}
