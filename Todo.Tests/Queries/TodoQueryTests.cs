using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Queries;
using Todo.Tests.Repositories;

namespace Todo.Tests.Queries;

[TestClass]
public class TodoQueryTests
{
    private IList<TodoItem> _items;

    public TodoQueryTests()
    {
        _items = new List<TodoItem>();
        _items.Add(new TodoItem("Titulo aqui",DateTime.Now,"Usuario01"));
        _items.Add(new TodoItem("Titulo aqui",DateTime.Now,"Usuario01"));
        _items.Add(new TodoItem("Titulo aqui",DateTime.Now,"Usuario01"));
        _items.Add(new TodoItem("Titulo aqui",DateTime.Now,"Usuario02"));
        _items.Add(new TodoItem("Titulo aqui",DateTime.Now,"Usuario02"));

    }
    
    [TestMethod]
    public void Dada_a_consulta_deve_retornar_tarefas_apenas_do_usuario_passado()
    {
        var result = _items.AsQueryable().Where(TodoQueries.GetAll("Usuario01"));
        Assert.AreEqual(result.Count(), 3);

    }
}