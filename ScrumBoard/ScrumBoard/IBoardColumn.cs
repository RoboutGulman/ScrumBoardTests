using System.Collections.Generic;

namespace ScrumBoard
{
public interface IBoardColumn
{
    string ColumnName { get; }

    void AddTask(ITask task);
    void ChangeName(string newName);
    void Clear();
    void DeleteTask(ITask task);
    ITask GetTask(string taskName);
    bool IsTaskExist(ITask task);
    List<ITask> GetAllTasks();
    void PrintTasks();
}
}
