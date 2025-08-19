namespace api.Exceptions
{
    public class DotEnvException : Exception
    {
        public DotEnvException(string variableName)
            : base($"Environment variable '{variableName}' is missing. Please set it in your .env file.")
        { }
    }
}
