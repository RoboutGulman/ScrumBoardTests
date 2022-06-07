namespace ScrumBoard
{
public interface ITask
{
    string Name { get; }

    void ChangeDescription(string newDescription);
    void ChangeName(string newName);
    void ChangePriority(int newPriority);
}
}
