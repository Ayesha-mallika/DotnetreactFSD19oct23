namespace EventCalendarApp.Exceptions
{
    public class EventsCantRemoveException : Exception
    {

        string message;
        public EventsCantRemoveException()
        {
            message = "No Event are available to remove";
        }
        public override string Message => message;
    }
}
