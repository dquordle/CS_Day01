using System;
using System.Collections.Generic;

public enum Return
{
    Success,
    AlreadyDone,
    AlreadyWontDo
}
public class Task
{
    private string _Title;
    private string Summary;
    private DateTime? DueDate;
    private TaskType Type;
    private TaskPriority? Priority;
    // private TaskState? State;
    private List<Event> History;
    
    public Task(string title, TaskType type, string summary, DateTime? duedate, TaskPriority? priority)
    {
        _Title = title;
        Type = type;
        if (priority == null)
            Priority = TaskPriority.Normal;
        else
            Priority = priority;
        DueDate = duedate;
        Summary = summary;
        History = new List<Event>();
        Event created = new CreatedEvent();
        History.Add(created);
        // State = TaskState.New;
    }

    public string Title
    {
        get => _Title;
    }
    public override string ToString()
    {
        string ret;
        ret = "- ";
        ret += $"{_Title}\n[{Type}] [{GetState()}]\nPriority: {Priority}";
        if (DueDate != null)
        {
            ret += $", Due till {DueDate.ToString()}";
            ret = ret.Remove(ret.Length - 9);
        }
        if (Summary != null)
            ret += $"\n{Summary}";
        return ret;
    }

    private TaskState GetState()
    {
        return History[History.Count - 1].State;
    }
    public Return DoneEvent()
    {
        TaskState state = GetState();
        if (state == TaskState.New)
        {
            Event done = new TaskDoneEvent();
            History.Add(done);
            return Return.Success;
        }
        if (state == TaskState.Done)
            return Return.AlreadyDone;
        return Return.AlreadyWontDo;
    }
    public Return WontDoEvent()
    {
        TaskState state = GetState();
        if (state == TaskState.New)
        {
            Event wontdo = new TaskWontDoEvent();
            History.Add(wontdo);
            return Return.Success;
        }
        if (state == TaskState.Done)
            return Return.AlreadyDone;
        return Return.AlreadyWontDo;
    }
}
