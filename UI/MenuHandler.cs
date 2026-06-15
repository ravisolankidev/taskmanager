using TaskManager.Interfaces;
using TaskManager.Models;

namespace TaskManager.UI;
public static class MenuHandler
{
    public static void HandleAddTask(ITaskService service)
    {
        Console.Write("Enter task title: ");
        string? title = Console.ReadLine();

        Console.Write("Enter task description (optional): ");
        string? description = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(title))
        {
            Console.WriteLine("❌ Title cannot be empty.\n");
            return;
        }

        service.AddTask(title, description ?? string.Empty);
        Console.WriteLine("✅ Task added successfully!\n");
    }

    public static void HandleViewTasks(ITaskService service)
    {
        var tasks = service.GetAllTasks();

        if (tasks.Count == 0)
        {
            Console.WriteLine("ℹ️ No tasks found.\n");
            return;
        }

        Console.WriteLine("--- Your Tasks ---");
        foreach (var task in tasks)
        {
            string status = task.IsCompleted ? "[X]" : "[ ]";
            Console.WriteLine($"{task.Id}. {status} {task.Title} - {task.Description}");
        }
        Console.WriteLine();
    }

    public static void HandleCompleteTask(ITaskService service)
    {
        Console.Write("Enter the ID of the task to complete: ");

        if (int.TryParse(Console.ReadLine(), out int taskId))
        {
            service.CompleteTask(taskId);
            Console.WriteLine($"✅ Task #{taskId} updated!\n");
        }
        else
        {
            Console.WriteLine("❌ Invalid ID format. Please enter a valid number.\n");
        }
    }

    public static void HandleViewCompletedTasks(ITaskService service)
    {
        var tasks = service.GetAllTasks(StatusFilter.Completed);

        if (tasks.Count == 0)
        {
            Console.WriteLine("ℹ️ No completed tasks found.\n");
            return;
        }

        Console.WriteLine("--- Completed Tasks ---");
        foreach (var task in tasks)
        {
            Console.WriteLine($"{task.Id}. [X] {task.Title} - {task.Description}");
        }
        Console.WriteLine();
    }
    public static void HandleViewIncompleteTasks(ITaskService service)
    {
        var tasks = service.GetAllTasks(StatusFilter.Incomplete);

        if (tasks.Count == 0)
        {
            Console.WriteLine("ℹ️ No incomplete tasks found.\n");
            return;
        }

        Console.WriteLine("--- Incomplete Tasks ---");
        foreach (var task in tasks)
        {
            Console.WriteLine($"{task.Id}. [ ] {task.Title} - {task.Description}");
        }
        Console.WriteLine();
    }

    public static void HandleUnMarkCompleteTask(ITaskService service)
    {
        Console.Write("Enter the ID of the task to unmark as complete: ");

        if (int.TryParse(Console.ReadLine(), out int taskId))
        {
            service.UnMarkCompleteTask(taskId);
            Console.WriteLine($"✅ Task #{taskId} updated!\n");
        }
        else
        {
            Console.WriteLine("❌ Invalid ID format. Please enter a valid number.\n");
        }
    }

    public static void HandleDeleteTask(ITaskService service)
    {
        Console.Write("Enter the ID of the task to delete: ");

        if (int.TryParse(Console.ReadLine(), out int taskId))
        {
            service.DeleteTask(taskId);
            Console.WriteLine($"✅ Task #{taskId} deleted!\n");
        }
        else
        {
            Console.WriteLine("❌ Invalid ID format. Please enter a valid number.\n");
        }
    }
}