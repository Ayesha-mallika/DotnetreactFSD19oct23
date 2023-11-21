namespace EventCalendarApp.Exceptions
{
    public class RemaindersAreNotAvailableException : Exception
    {
        string message;
        public RemaindersAreNotAvailableException()
        {
            message = "No Reminders are available ";
        }
        public override string Message => message;
    }
}
