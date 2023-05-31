using Microsoft.AspNetCore.Mvc;
using TodoApi.Repo;
using TodoApi.Models;

namespace TodoApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoControllers : ControllerBase
{
    private readonly TodoDbContext db;
    private readonly TodoRepo todoRepo;
    public TodoControllers(TodoDbContext _db)
    {
        db = _db;
        todoRepo = new TodoRepo(db);
    }

    [HttpGet("[action]")]
    public Response GetAll()
    {
        return todoRepo.GetAllTodo();
    }

    [HttpGet("[action]/{Id}")]
    public Response GetById(int Id)
    {
        return todoRepo.GetById(Id);
    }

    [HttpPost("[action]")]
    public Response Add(Todo dataTodo)
    {
        return todoRepo.Add(dataTodo);
    }

    [HttpPut("[action]/{Id}")]
    public Response Put(int Id,[FromBody] Todo dataTodo)
    {
        return todoRepo.Put(Id, dataTodo);
    }

    [HttpDelete("[action]/{Id}")]
    public Response Delete(int Id)
    {
        return todoRepo.Delete(Id);
    }
}