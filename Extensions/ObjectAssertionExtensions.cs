using VerbytesAssertions.Primitives;

namespace VerbytesAssertions.Extensions
{
    public static class ObjectAssertionExtensions
    {
        public static ObjectAssertions Should(this object subject)
        {
            return new ObjectAssertions(subject);
        }
    }
}
