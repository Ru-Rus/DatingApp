using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{

    [Route("api/[controller]")] //localhost:6969/api/membbers
    [ApiController]
    public class MembersController(AppDBContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<AppUsers>>> GetMembers()
        {
            var members = await context.Users.ToListAsync();
            return members;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUsers>> GetMembers(string? id)
        {
            var member = await context.Users.FindAsync(id);

            if (member == null)
            {
                return NotFound();
            }
            else
            {
                return member;
            }
        }

    }
}