using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using TodoLibrary.Data;
using TodoLibrary.DataAccess;
using TodoLibrary.Models;

namespace ApiProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodosController : ControllerBase
{
    private readonly ITodoData _todoData;
    private readonly ILogger<TodosController> _logger;

    public TodosController(ITodoData todoData, ILogger<TodosController> logger)
    {
        _todoData = todoData;
        _logger = logger;
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
        int userId = GetUserId();

        _logger.LogInformation("GET: {ApiPath} by {UserId}", "api/Todos", userId);
        try
        {
            var output = await _todoData.GetAllAssigned(userId);

            return StatusCode(200, output);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GET call to {ApiPath} by {UserId} has failed.", "api/Todos", userId);

            return StatusCode(400);
        }
    }

    // GET api/Todos/5
    [HttpGet("{todoId}")]
    public async Task<ActionResult<TodoModel>> Get(int todoId)
    {
        int userId = GetUserId();

        _logger.LogInformation("GET: {ApiPath} by {UserId}. Todo Id was {TodoId}", $"api/Todos/Id", userId, todoId);
        try
        {
            var output = await _todoData.GetOneAssigned(userId, todoId);

            return StatusCode(200, output);
        }
        catch (Exception ex)
        {

            _logger.LogError(ex, "GET call {ApiPath} by {UserId} has failed. Todo Id was {TodoId}", $"api/Todos/Id", userId, todoId);

            return StatusCode(400);
        }
    }

    // POST api/Todos
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] string task)
    {
        int userId = GetUserId();

        _logger.LogInformation("POST: {ApiPath} by {UserId}. Task: {Task}", $"api/Todos", userId, task);
        try
        {
            var output = await _todoData.CreateTodo(userId, task);

            return StatusCode(200, output);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "POST call {ApiPath} by {UserId} has failed. The value was {Task}", $"api/Todos", userId, task);

            return StatusCode(400);

        }
    }

    // PUT api/Todos/5
    [HttpPut("{todoId}")]
    public async Task<IActionResult> Put(int todoId, [FromBody] string task)
    {
        int userId = GetUserId();

        _logger.LogInformation("PUT: {ApiPath} by {UserId}. Todo Id was {TodoId}. Task: {Task}", $"api/Todos/Id", userId, todoId, task);
        try
        {
            await _todoData.UpdateTask(userId, todoId, task);

            return StatusCode(200);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "PUT call {ApiPath} by {UserId} has failed. Todo Id was {TodoId}. The value was {Task}", $"api/Todos/Id", userId, todoId, task);

            return StatusCode(400);

        }
    }

    // PUT api/Todos/5/Complete
    [HttpPut("{todoId}/Complete")]
    public async Task<IActionResult> Complete(int todoId)
    {
        int userId = GetUserId();

        _logger.LogInformation("PUT: {ApiPath} by {UserId}. Todo Id was {TodoId}", $"api/Todos/Id/Complete", userId, todoId);
        try
        {
            await _todoData.CompleteTodo(userId, todoId);

            return StatusCode(200);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "PUT call {ApiPath} by {UserId} has failed. Todo Id was {TodoId}", $"api/Todos/Id/Complete", userId, todoId);

            return StatusCode(400);
        }
    }

    // DELETE api/Todos/5
    [HttpDelete("{todoId}")]
    public async Task<IActionResult> Delete(int todoId)
    {
        int userId = GetUserId();


        try
        {
            await _todoData.DeleteTodo(userId, todoId);

            return StatusCode(200);
        }
        catch (Exception ex)
        {

            return StatusCode(400);
        }

    }
}
