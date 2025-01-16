using VerbytesAssertions.Primitives;

namespace VerbytesAssertions.Extensions
{
    public static class GenericCollectionAssertionExtensions
    {
        public static GenericCollectionAssertions<T> Should<T>(this IEnumerable<T> subject)
        {
            return new GenericCollectionAssertions<T>(subject);
        }
    }
}
