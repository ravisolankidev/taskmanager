using System.IO;
using System.Text.Json;
using TaskManager.Interfaces;
using TaskManager.Models;

namespace TaskManager.Services;

public class TaskService : ITaskService
{
    private readonly string _fileName;
    private List<TaskItem> _tasks = new List<TaskItem>();
    private int _nextId = 1;

    public TaskService(string Filename = "Tasks.json")
    {
        _fileName = Filename;
        LoadFromFile();
    }

    public void AddTask(string title, string? description)
    {
        var task = new TaskItem(_nextId++, title, description ?? string.Empty);
        _tasks.Add(task);

        SaveToFile();
    }

    public List<TaskItem> GetAllTasks(StatusFilter? filter = null)
    {
        List<TaskItem> filteredTasks = _tasks;

        var f = filter ?? StatusFilter.All;

        switch (f)
        {
            case StatusFilter.Completed:
                filteredTasks = _tasks.Where(t => t.IsCompleted).ToList();
                break;
            case StatusFilter.Incomplete:
                filteredTasks = _tasks.Where(t => !t.IsCompleted).ToList();
                break;
            default:
                break;
        }
        return filteredTasks;
    }

    public void CompleteTask(int id)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task != null)
        {
            task.IsCompleted = true;
            SaveToFile();
        }
    }

    public void UnMarkCompleteTask(int id)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task != null)
        {
            task.IsCompleted = false;
            SaveToFile();
        }
    }

    public void DeleteTask(int id)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task != null)
        {
            _tasks.Remove(task);
            SaveToFile();
        }
    }

    private void SaveToFile()
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(_tasks, options);

        File.WriteAllText(_fileName, jsonString);
    }

    private void LoadFromFile()
    {
        if (!File.Exists(_fileName))
        {
            return;
        }

        try
        {
            string jsonString = File.ReadAllText(_fileName);

            var deserializedTasks = JsonSerializer.Deserialize<List<TaskItem>>(jsonString);

            if (deserializedTasks != null)
            {
                _tasks = deserializedTasks;

                // Track the highest ID used so far so new items don't overwrite old IDs
                if (_tasks.Count > 0)
                {
                    _nextId = _tasks.Max(t => t.Id) + 1;
                }
            }
        }
        catch (JsonException)
        {
            // If the JSON file gets corrupted or edited incorrectly by hand
            Console.WriteLine("⚠️ Warning: Tasks.json file was corrupted. Starting with an empty list.");
            _tasks = new List<TaskItem>();
        }
    }
}
