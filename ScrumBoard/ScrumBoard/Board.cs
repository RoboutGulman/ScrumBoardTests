using System;
using System.Collections.Generic;

namespace ScrumBoard
{
public class Board : IScrumBoard
{
    public static readonly int MAX_COLUMN_AMOUNT = 10;
    private string _name;
    private List<IBoardColumn> columns;
    public string Name => _name;

    public Board(string name)
    {
        _name = name;
        columns = new List<IBoardColumn>();
    }

    public bool AddColumn(string columnName)
    {
        if (columns.Count >= MAX_COLUMN_AMOUNT)
        {

            return false;
        }
        IBoardColumn newColumn = new BoardColumn(columnName);
        columns.Add(newColumn);
        return true;
    }

    public List<IBoardColumn> GetBoardColumns()
    {
        return columns;
    }

    public bool AddTask(ITask task)
    {
        if (columns.Count == 0)
        {
            return false;
        }
        IBoardColumn column = columns[0];
        column.AddTask(task);
        return true;
    }

    public void PrintBoard()
    {
        Console.Write($"Board Name: '{_name}' \n");
        foreach (var column in columns)
        {
            Console.Write($"Column Name: '{column.ColumnName}'. Tasks: ");
            column.PrintTasks();
            Console.Write("\n");
        }
    }
    public int SearchColumnNumberByName(string name)
    {
        return columns.FindIndex(a => a.ColumnName == name);
    }

    public bool MoveTask(string nameColumnFrom, string nameColumnTo, ITask task)
    {
        int from = SearchColumnNumberByName(nameColumnFrom);
        int to = SearchColumnNumberByName(nameColumnTo);
        if (from < 0 || to < 0 || from == to)
        {
            return false;
        }
        if (!columns[from].IsTaskExist(task))
        {
            return false;
        }
        columns[from].DeleteTask(task);
        columns[to].AddTask(task);
        return true;
    }
}
}
