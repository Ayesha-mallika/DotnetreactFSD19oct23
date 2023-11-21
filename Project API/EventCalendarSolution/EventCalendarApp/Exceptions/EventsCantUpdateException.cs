namespace EventCalendarApp.Exceptions
{
    public class EventsCantUpdateException : Exception
    {
        string message;
        public EventsCantUpdateException()
        {
            message = "No Events are updating";
        }
        public override string Message => message;
    }
}