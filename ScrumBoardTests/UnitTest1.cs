using Xunit;
using ScrumBoard;

namespace ScrumBoardTests
{
public class ScrumBoardTests
{
    private string _boardTitle = "tasks";
    private string _columnName = "to do";
    private string _anotherColumnName = "work in progress";
    private string _taskName = "repair TV";
    private string _taskDesc = "smth wrong";
    private int _taskPriority = 1;

    [Fact]
    public void Board_has_title()
    {
        // Arrange
        Board board = new Board(_boardTitle);

        // Act

        // Assert
        Assert.Equal(board.Name, _boardTitle);
    }

    [Fact]
    public void Board_contains_columns()
    {
        // Arrange
        Board board = new Board(_boardTitle);

        // Act
        board.AddColumn(_columnName);

        // Assert
        Assert.Single(board.GetBoardColumns());
        Assert.Equal(_columnName, board.GetBoardColumns()[0].ColumnName);
    }

    [Fact]
    public void Columns_can_have_different_names()
    {
        // Arrange
        Board board = new Board(_boardTitle);

        // Act
        board.AddColumn(_columnName);
        board.AddColumn(_anotherColumnName);
        board.AddColumn(_columnName);

        // Assert
        Assert.Equal(3, board.GetBoardColumns().Count);
        Assert.Equal(_columnName, board.GetBoardColumns()[0].ColumnName);
        Assert.Equal(_anotherColumnName, board.GetBoardColumns()[1].ColumnName);
        Assert.Equal(_columnName, board.GetBoardColumns()[2].ColumnName);
    }
    [Fact]
    public void Number_of_columns_is_limited()
    {
        // Arrange
        Board board = new Board(_boardTitle);

        // Act
        bool isSuccesful = true;
        for (int i = 0; i < Board.MAX_COLUMN_AMOUNT + 1; i++)
        {
            isSuccesful = board.AddColumn(_columnName);
        }

        // Assert
        Assert.False(isSuccesful);
        Assert.Equal(Board.MAX_COLUMN_AMOUNT, board.GetBoardColumns().Count);
    }
    [Fact]
    public void Need_any_columns_to_add_task()
    {
        // Arrange
        Board board = new Board(_boardTitle);
        Task task = new Task(_taskName, _taskDesc, _taskPriority);

        // Act
        bool isSuccesful = board.AddTask(task);

        // Assert
        Assert.False(isSuccesful);
    }
    [Fact]
    public void Task_added_to_first_column()
    {
        // Arrange
        Board board = new Board(_boardTitle);
        board.AddColumn(_columnName);
        Task task = new Task(_taskName, _taskDesc, _taskPriority);

        // Act
        bool isSuccesful = board.AddTask(task);

        // Assert
        Assert.True(isSuccesful);
        Assert.Single(board.GetBoardColumns() [0].GetAllTasks());
        Assert.Equal(_taskName, board.GetBoardColumns() [0].GetAllTasks()[0].Name);
    }
    [Fact]
    public void Task_has_name_description_priority()
    {
        // Arrange
        Task task = new Task(_taskName, _taskDesc, _taskPriority);

        // Act

        // Assert
        Assert.Equal(task.Name, _taskName);
        Assert.Equal(task.description, _taskDesc);
        Assert.Equal(task.priority, _taskPriority);
    }
    [Fact]
    public void Task_can_be_moved_between_columns()
    {
        // Arrange
        Board board = new Board(_boardTitle);
        board.AddColumn(_columnName);
        board.AddColumn(_anotherColumnName);
        Task task = new Task(_taskName, _taskDesc, _taskPriority);
        board.AddTask(task);

        // Act
        board.MoveTask(_columnName, _anotherColumnName, task);

        // Assert
        Assert.Empty(board.GetBoardColumns() [0].GetAllTasks());
        Assert.Single(board.GetBoardColumns() [1].GetAllTasks());
        Assert.Equal(_taskName, board.GetBoardColumns() [1].GetAllTasks()[0].Name);
    }
    [Fact]
    public void Task_not_from_board_cant_be_moved()
    {
        // Arrange
        Board board = new Board(_boardTitle);
        board.AddColumn(_columnName);
        board.AddColumn(_anotherColumnName);
        Task task = new Task(_taskName, _taskDesc, _taskPriority);

        // Act
        bool isSucces = board.MoveTask(_columnName, _anotherColumnName, task);

        // Assert
        Assert.False(isSucces);
    }
    [Fact]
    public void Move_task_from_column_to_same_column()
    {
        // Arrange
        Board board = new Board(_boardTitle);
        board.AddColumn(_columnName);
        Task task = new Task(_taskName, _taskDesc, _taskPriority);
        board.AddTask(task);

        // Act
        bool isSucces = board.MoveTask(_columnName, _columnName, task);

        // Assert
        Assert.False(isSucces);
    }
}
}
