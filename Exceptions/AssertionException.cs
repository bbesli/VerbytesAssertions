namespace VerbytesAssertions.Exceptions
{
    /// <summary>
    /// Custom exception for assertion failures.
    /// </summary>
    public class AssertionException : Exception
    {
        public AssertionException(string message) : base(message) { }
    }
}
