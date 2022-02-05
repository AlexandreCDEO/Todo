using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Entities;

namespace Todo.Tests.Entity;

[TestClass]
public class TodoTests
{
    [TestMethod]
    public void Dado_uma_nova_tarefa_a_propriedade_Done_deve_vir_false()
    {
        var todo = new TodoItem("Titulo da tarefa", DateTime.Now, "Usuario da tarefa");
        Assert.AreEqual(todo.Done, false);
    }
}