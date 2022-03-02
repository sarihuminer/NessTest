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
  public class RolesController : ControllerBase
  {
    private readonly IMapper _mapper;
    private readonly IRoleRepository _roleRepository;
    public RolesController(IMapper mapper, IRoleRepository roleRepository)
    {
      this._mapper = mapper;
      this._roleRepository = roleRepository;
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
      List<Roles> roles = _roleRepository.getRoles();
      return Ok(roles);
    }
  }
    
}
