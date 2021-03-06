using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Repositories;

namespace Todo.Api.Controllers;

[ApiController]
[Route("v1/todos")]
public class TodoController : ControllerBase
{
    [Route("")]
    [HttpGet]
    public IEnumerable<TodoItem> GetAll(
        [FromServices]ITodoRepository repository
    )
    {
        return repository.GetAll("usuarioAqui");
    }

    [Route("done")]
    [HttpGet]
    public IEnumerable<TodoItem> GetAllDone(
        [FromServices]ITodoRepository repository
    )
    {
        return repository.GetAllDone("usuarioAqui");
    }

    [Route("undone")]
    [HttpGet]
    public IEnumerable<TodoItem> GetAllUndone(
        [FromServices]ITodoRepository repository
    )
    {
        return repository.GetAllUndone("usuarioAqui");
    }

    [Route("done/today")]
    [HttpGet]
    public IEnumerable<TodoItem> GetAllDoneToday(
        [FromServices]ITodoRepository repository
    )
    {
        return repository.GetByPeriod(
            "usuarioAqui",
            DateTime.Now, 
            true
        );
    }

    [Route("undone/today")]
    [HttpGet]
    public IEnumerable<TodoItem> GetAllUndoneToday(
        [FromServices]ITodoRepository repository
    )
    {
        return repository.GetByPeriod(
            "usuarioAqui",
            DateTime.Now, 
            false
        );
    }

    
    [Route("undone/tomorrow")]
    [HttpGet]
    public IEnumerable<TodoItem> GetAllUndoneTomorrow(
        [FromServices]ITodoRepository repository
    )
    {
        return repository.GetByPeriod(
            "usuarioAqui",
            DateTime.Now.AddDays(1),
            false
        );
    }

    [Route("")]
    [HttpPost]
    public GenericCommandResult Create(
        [FromBody]CreateTodoCommand command,
        [FromServices]TodoHandler handler
    )
    {
        command.User = "usuarioAqui";
        return (GenericCommandResult) handler.Handdle(command);
    }

    [Route("")]
    [HttpPut]
    public GenericCommandResult Update(
        [FromBody]UpdateTodoCommand command,
        [FromServices]TodoHandler handler
    )
    {
        return (GenericCommandResult) handler.Handdle(command);
    }

    [Route("mark-as-done")]
    [HttpPut]
    public GenericCommandResult MarkAsDone(
        [FromBody]MarkTodoAsDoneCommand command,
        [FromServices]TodoHandler handler
    )
    {
        command.User = "usuarioAqui";
        return (GenericCommandResult)handler.Handdle(command);
    }
    
    
    [Route("mark-as-undone")]
    [HttpPut]
    public GenericCommandResult MarkAsUndone(
        [FromBody]MarkTodoAsUnDoneCommand command,
        [FromServices]TodoHandler handler
    )
    {
        command.User = "usuarioAqui";
        return (GenericCommandResult)handler.Handdle(command);
    }
    
    


}