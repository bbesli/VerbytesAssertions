using VerbytesAssertions.Primitives;

namespace VerbytesAssertions.Extensions
{
    public static class BooleanAssertionExtensions
    {
        public static BooleanAssertions Should(this bool subject)
        {
            return new BooleanAssertions(subject);
        }

        public static BooleanAssertions Should(this bool? subject)
        {
            return new BooleanAssertions(subject);
        }
    }
}
