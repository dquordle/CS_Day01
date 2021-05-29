public record CreatedEvent : Event
{
    public CreatedEvent()
    {
        State = TaskState.New;
    }
}