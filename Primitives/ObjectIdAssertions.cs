using MongoDB.Bson;

namespace VerbytesAssertions.Primitives
{
    public class ObjectIdAssertions : Assertion<ObjectId>
    {
        public ObjectIdAssertions(ObjectId subject) : base(subject) { }

        public void BeEmpty()
        {
            if (Subject != ObjectId.Empty)
            {
                Fail($"Expected ObjectId to be empty, but found '{Subject}'.");
            }
        }

        public void NotBeEmpty()
        {
            if (Subject == ObjectId.Empty)
            {
                Fail("Expected ObjectId not to be empty, but it was.");
            }
        }

        public void BeEqualTo(ObjectId expected)
        {
            if (Subject != expected)
            {
                Fail($"Expected ObjectId to be '{expected}', but found '{Subject}'.");
            }
        }

        public void NotBeEqualTo(ObjectId expected)
        {
            if (Subject == expected)
            {
                Fail($"Expected ObjectId not to be '{expected}', but it was.");
            }
        }
    }

}
