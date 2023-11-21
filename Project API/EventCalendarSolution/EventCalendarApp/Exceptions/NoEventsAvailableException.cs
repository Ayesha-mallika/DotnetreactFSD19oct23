namespace EventCalendarApp.Exceptions
{
    public class NoEventsAvailableException : Exception
    {
        string message;
        public NoEventsAvailableException()
        {
            message = "No Event are available ";
        }
        public override string Message => message;
    }
}

