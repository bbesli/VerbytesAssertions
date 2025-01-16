using VerbytesAssertions.Primitives;

namespace VerbytesAssertions.Extensions
{
    public static class GuidAssertionExtensions
    {
        public static GuidAssertions Should(this Guid subject)
        {
            return new GuidAssertions(subject);
        }
    }
}
