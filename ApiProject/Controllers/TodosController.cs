using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TodoLibrary.Data;
using TodoLibrary.DataAccess;
using TodoLibrary.Models;

namespace ApiProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodosController : ControllerBase
{
    private readonly ITodoData _todoData;

    public TodosController(ITodoData todoData)
    {
        _todoData = todoData;
        
    }

    private int GetUserId()
    {
        var userIdString = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        return int.Parse(userIdString);
    }

    // GET: api/Todos
    [HttpGet]
    public async Task<ActionResult<List<TodoModel>>> Get()
    {
        var output = await _todoData.GetAllAssigned(GetUserId());

        return StatusCode(200,output);
    }

    // GET api/Todos/5
    [HttpGet("{todoId}")]
    public async Task<ActionResult<TodoModel>> Get(int todoId)
    {
        var output = await _todoData.GetOneAssigned(GetUserId(), todoId);

        return StatusCode(200, output);
    }

    // POST api/Todos
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] string task)
    {
        var output = await _todoData.CreateTodo(GetUserId(), task);

        return StatusCode(200,output);
    }

    // PUT api/Todos/5
    [HttpPut("{todoId}")]
    public async Task<IActionResult> Put(int todoId, [FromBody] string value)
    {
        await _todoData.UpdateTask(GetUserId(), todoId, value);

        return StatusCode(200);
    }

    // PUT api/Todos/5/Complete
    [HttpPut("{todoId}/Complete")]
    public async Task<IActionResult> Complete(int todoId)
    {
        await _todoData.CompleteTodo(GetUserId(), todoId);


        return StatusCode(200);
    }

    // DELETE api/Todos/5
    [HttpDelete("{todoId}")]
    public async Task<IActionResult> Delete(int todoId)
    {
        await _todoData.DeleteTodo(GetUserId(), todoId);


        return StatusCode(200);

    }
}
