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

      // Instantiate source object
      // (Get it from the database or whatever your code calls for)
      var users =  _userRepository.getProductOrdersForCustomer();

      List<Users> userList = _userRepository.getProductOrdersForCustomer();
      return Ok( userList);
      // .... Do whatever you want after that!
    }
  }
}