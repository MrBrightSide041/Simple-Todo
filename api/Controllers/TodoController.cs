using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Todo>>> GetAllTodo()
        {
            var todos = new List<Todo> {
                new Todo
                {
                    Description = "Buy Milk"

                }
            };
            return Ok(todos);
        }
    }
}