using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [Route("api/[controller]")] //localhost:6969/api/membbers
    [ApiController]
    public class MembersController(AppDBContext context) : ControllerBase
    {
        [HttpGet]
        public ActionResult<IReadOnlyList<AppUsers>> GetMembers()
        {
            var members = context.Users.ToList();
            return members;
        }

        [HttpGet("{id}")]
        public ActionResult<AppUsers> GetMembers(string? id)
        {
            var member = context.Users.Find(id);

            if(member == null)
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