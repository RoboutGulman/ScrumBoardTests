namespace ScrumBoard
{
public interface IScrumBoard
{
    string Name { get; }

    bool AddColumn(string columnName);
    bool AddTask(ITask task);
    bool MoveTask(string nameColumnFrom, string nameColumnTo, ITask task);
    void PrintBoard();
    int SearchColumnNumberByName(string name);
}
}
