namespace EventCalendarApp.Exceptions
{
    public class NocategoriesAvailableException : Exception
    {

        string message;
        public NocategoriesAvailableException()
        {
            message = "No catogery are available ";
        }
        public override string Message => message;
    }
}
