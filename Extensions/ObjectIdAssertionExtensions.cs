using MongoDB.Bson;
using VerbytesAssertions.Primitives;

namespace VerbytesAssertions.Extensions
{
    public static class ObjectIdAssertionExtensions
    {
        public static ObjectIdAssertions Should(this ObjectId subject)
        {
            return new ObjectIdAssertions(subject);
        }
    }
}
