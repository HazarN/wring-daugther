namespace api.Exceptions
{
    public class DotEnvException : Exception
    {
        public DotEnvException(string variableName)
            : base($"{variableName} is(are) missing. Please set it in your .env file.")
        { }
    }
}
