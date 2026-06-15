using TaskManager.Models;

namespace TaskManager.Interfaces;

public interface ITaskService
{
    void AddTask(string title, string description);
    List<Models.TaskItem> GetAllTasks(StatusFilter? StatusFilter = StatusFilter.All);
    void CompleteTask(int id);
    void UnMarkCompleteTask(int id);
    void DeleteTask(int id);
}
