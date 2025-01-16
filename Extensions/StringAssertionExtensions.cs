using VerbytesAssertions.Primitives;

namespace VerbytesAssertions.Extensions
{
    public static class StringAssertionExtensions
    {
        public static StringAssertions Should(this string subject)
        {
            return new StringAssertions(subject);
        }
    }
}
