using ApiProject.Models;
using Microsoft.AspNetCore.Mvc;
using TodoLibrary.Models;

namespace ApiProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodosController : ControllerBase
{
    // GET: api/Todos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ITodoModel>>> Get()
    {
        throw new NotImplementedException();
    }

    // GET api/Todos/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ITodoModel>> Get(int id)
    {
        throw new NotImplementedException();
    }

    // POST api/Todos
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] TodoApiModel value)
    {
        throw new NotImplementedException();

    }

    // PUT api/Todos/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] TodoApiModel value)
    {
        throw new NotImplementedException();

    }

    // PUT api/Todos/5/Complete
    [HttpPut("{id}/Complete")]
    public async Task<IActionResult> Complete(int id)
    {
        throw new NotImplementedException();

    }

    // DELETE api/Todos/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        throw new NotImplementedException();

    }
}
