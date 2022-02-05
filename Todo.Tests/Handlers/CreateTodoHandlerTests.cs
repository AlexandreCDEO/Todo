using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Handlers;
using Todo.Tests.Repositories;

namespace Todo.Tests.Handlers;

[TestClass]
public class CreateTodoHandlerTests
{
    private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("Titulo da tarefa", "Usuario da tarefa", DateTime.Now);
    private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("", "", DateTime.Now);
    private readonly TodoHandler _handler = new TodoHandler(new FakeTodoRepository());

    [TestMethod]
    public void Dado_um_comando_invalido_a_tarefa_nao_deve_ser_criada()
    {
        var result = (GenericCommandResult)_handler.Handdle(_invalidCommand);
        Assert.AreEqual(result.Success, false);

    }
    
    [TestMethod]
    public void Dado_um_comando_valido_deve_criar_a_tarefa()
    {
        var result = (GenericCommandResult)_handler.Handdle(_validCommand);
        Assert.AreEqual(result.Success, true);

    }
}