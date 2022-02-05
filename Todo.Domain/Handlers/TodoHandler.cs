using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers;

public class TodoHandler : Notifiable,
    IHandler<CreateTodoCommand>,
    IHandler<UpdateTodoCommand>,
    IHandler<MarkTodoAsDoneCommand>,
    IHandler<MarkTodoAsUnDoneCommand>
{
    private readonly ITodoRepository _repository;

    public TodoHandler(ITodoRepository repository)
    {
        _repository = repository;
    }
    public ICommandResult Handdle(CreateTodoCommand command)
    {
        //Fail Fast Validation
        command.Validate();
        if (command.Invalid)
            return new GenericCommandResult
            (
                false, 
                "Ops, parece que sua tarefa está inválida",
                command.Notifications
            );

        //Gerar TodoItem
        var todo = new TodoItem(command.Title, command.Date, command.User);
        
        //Salva no banco
        _repository.Create(todo);
        
        //Retorna o resultado
        return new GenericCommandResult(true, "Tarefa salva", todo);


    }

    public ICommandResult Handdle(UpdateTodoCommand command)
    {
        //Fail Fast Validation
        command.Validate();
        if (command.Invalid)
            return new GenericCommandResult(false, "Ops, parece que sua tarefa está inválida", command.Notifications);
        
        //Recupera o TodoItem
        TodoItem todo = _repository.GetById(command.Id, command.User);
        
        //Atualiza o TodoItem
        todo.UpdateTitle(command.Title);
        
        //Salva no banco
        _repository.Update(todo);
        
        //Retorna o resultado
        return new GenericCommandResult(true, "Tarefa salva", todo);

    }

    public ICommandResult Handdle(MarkTodoAsDoneCommand command)
    {
        //Fast Fail Validate
        command.Validate();
        if (command.Invalid)
            return new GenericCommandResult(false, "Ops, parece que sua tarefa está inválida", command.Notifications);
        
        //Recupera o TodoItem
        var todo = _repository.GetById(command.Id, command.User);
        
        //Marca como concluido
        todo.MarkAsDone();
        
        //Salva no banco
        _repository.Update(todo);
        
        //Retorna o resultado
        return new GenericCommandResult(true, "Tarefa salva", todo);

    }

    public ICommandResult Handdle(MarkTodoAsUnDoneCommand command)
    {
        //Fast Fail Validation
        command.Validate();
        if (command.Invalid)
            return new GenericCommandResult(false, "Ops, parece que sua tarefa está inválida", command.Notifications);
        
        //Recupera do banco
        var todo = _repository.GetById(command.Id, command.User);
        
        //marca como nao concluido
        todo.MarkAsUnDone();
        
        //Salva no banco
        _repository.Update(todo);
        
        //retorna o resultado
        return new GenericCommandResult(true, "Tarefa salva", todo);
    }
}