using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Handlers;
using Todo.Domain.Handlers.Contracts;
using Todo.Tests.Repositories;


namespace Todo.Tests.Handlers;

[TestClass]
public class UpdateTodohandlerTest
{
    private readonly CreateTodoCommand _command = new CreateTodoCommand("Titulo aqui", "Usuario aqui", DateTime.Now);
    private readonly IHandler<CreateTodoCommand> _handler = new TodoHandler(new FakeTodoRepository());

    public UpdateTodohandlerTest()
    {
        
    }
    
    [TestMethod]
    public void Dado_Um_novo_titulo_o_mesmo_deve_ser_atualizado()
    {
        var command = new UpdateTodoCommand();
    }
}