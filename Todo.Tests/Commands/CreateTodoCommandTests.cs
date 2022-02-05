using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;

namespace Todo.Tests.Commands;

[TestClass]
public class CreateTodoCommandTests
{
    private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("", "", DateTime.Now);
    private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("Titulo da tarefa", "Usuario da tarefa", DateTime.Now);

        
    [TestMethod]
    public void Dado_um_comando_valido()
    {
        _validCommand.Validate();
        Assert.AreEqual(_validCommand.Valid, true);
    }

    [TestMethod]
    public void Dado_um_comando_invalido()
    {
        _invalidCommand.Validate();
        Assert.AreEqual(_invalidCommand.Valid, false);    
    }
}