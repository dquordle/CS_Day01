using System;

public class Task
{
    private string Title;
    private string Summary;
    private DateTime? DueDate;
    private TaskType Type;
    private TaskPriority? Priority;
    private TaskState? State;

    public Task(string title, string type, string summary, DateTime duedate, string priority)
    {
        Title = title;
        Type = set_type(type);
        if (string.IsNullOrEmpty(priority))
            Priority = TaskPriority.Normal;
        else
            Priority = set_priority(priority);
        DueDate = duedate;
        Summary = summary;
        State = TaskState.New;
    }

    private TaskType set_type(string type)
    {
        if (type == "Work")
            return TaskType.Work;
        if (type == "Personal")
            return TaskType.Personal;
        return TaskType.Study;
    }
    private TaskPriority set_priority(string priority)
    {
        if (priority == "Low")
            return TaskPriority.Low;
        if (priority == "Normal")
            return TaskPriority.Normal;
        return TaskPriority.High;
    }
}
