namespace TaskManager.Models;

    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty
        ;
        public bool IsCompleted { get; set; } = false;

        public TaskItem(int id, string title, string description)
        {
            Id = id;
            Title = title;
            Description = description ?? string.Empty;
            IsCompleted = false;
        }
    }