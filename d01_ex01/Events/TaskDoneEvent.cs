public record TaskDoneEvent : Event
{
    public TaskDoneEvent()
    {
        State = TaskState.Done;
    }
}