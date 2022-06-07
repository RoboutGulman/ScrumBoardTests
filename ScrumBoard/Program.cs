using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumBoard
{
internal class Program
{
    static void Main(string[] args)
    {
        Board board = new Board("задачи");
        board.AddColumn("сделать");
        Task task = new Task("починить телевизор", "не работает", 1);
        board.AddTask(task);
        board.AddColumn("уже сделано");
        Task task2 = new Task("написать письмо", "туда", 2);
        board.AddTask(task2);
        board.MoveTask("сделать", "уже сделано", task);
        board.PrintBoard();
    }
}
}
