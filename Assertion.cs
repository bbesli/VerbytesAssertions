using Xunit.Sdk;

namespace VerbytesAssertions
{
    public class Assertion<T>
    {
        protected T Subject { get; }

        public Assertion(T subject)
        {
            Subject = subject;
        }

        protected void Fail(string message)
        {
            throw new XunitException(message);
        }
    }

}
