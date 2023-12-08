namespace EventCalendarApp.Exceptions
{
    public class NoUsersAvailableException: Exception
    {

        string message;
        public NoUsersAvailableException()
        {
            message = "No Events are updating";
        }
        public override string Message => message;
    }
}
