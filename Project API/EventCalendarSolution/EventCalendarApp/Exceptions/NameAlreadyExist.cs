namespace EventCalendarApp.Exceptions
{
    public class NameAlreadyExist : Exception
    {
        string message;
        public NameAlreadyExist()
        {
            message = "This Name Already Exist ";
        }
        public override string Message => message;
    }
}
