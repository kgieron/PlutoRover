namespace PlutoRoverApp.Exceptions
{
    public class NotSupportedCommandException : Exception
    {
        public NotSupportedCommandException() : base("This interface supports only F or B or L or R commands")
        {

        }
    }
}
