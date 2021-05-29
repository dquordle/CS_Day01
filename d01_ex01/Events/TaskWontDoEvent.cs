public record TaskWontDoEvent : Event
{
    public TaskWontDoEvent()
    {
        State = TaskState.WontDo;
    }
}