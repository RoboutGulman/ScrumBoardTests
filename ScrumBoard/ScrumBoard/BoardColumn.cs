﻿using System;
using System.Collections.Generic;

namespace ScrumBoard
{
public class BoardColumn : IBoardColumn
{
    private string _columnName;
    private List<ITask> tasks;

    public string ColumnName => _columnName;
    public BoardColumn(string name)
    {
        _columnName = name;
        tasks = new List<ITask>();
    }

    public void ChangeName(string newName)
    {
        _columnName = newName;
    }

    public void AddTask(ITask task)
    {
        tasks.Add(task);
    }

    public ITask GetTask(string taskName)
    {
        return tasks.Find(x => x.Name == taskName);
    }

    public List<ITask> GetAllTasks()
    {
        return tasks;
    }
    public bool IsTaskExist(ITask task)
    {
        return tasks.Exists(x => x == task);
    }

    public void PrintTasks()
    {
        foreach (var task in tasks)
        {
            Console.Write(task.Name + ' ');
        }
    }
    public void DeleteTask(ITask task)
    {
        tasks.Remove(task);
    }

    public void Clear()
    {
        tasks.Clear();
    }
}
}
