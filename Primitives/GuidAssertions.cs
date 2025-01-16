using VerbytesAssertions.Exceptions;

namespace VerbytesAssertions.Primitives
{
    /// <summary>
    /// Contains assertion methods for validating GUID values.
    /// </summary>
    public class GuidAssertions
    {
        private readonly Guid _subject;

        public GuidAssertions(Guid subject)
        {
            _subject = subject;
        }

        /// <summary>
        /// Asserts that the GUID is equal to the expected GUID.
        /// </summary>
        public GuidAssertions Be(Guid expected, string because = "", params object[] becauseArgs)
        {
            if (_subject != expected)
            {
                var reason = string.Format(because, becauseArgs);
                throw new AssertionException($"Expected GUID to be {expected}{reason}, but found {_subject}.");
            }

            return this;
        }

        /// <summary>
        /// Asserts that the GUID, when converted to a string, is equal to the expected string representation.
        /// </summary>
        public GuidAssertions Be(string expected, string because = "", params object[] becauseArgs)
        {
            if (_subject.ToString() != expected)
            {
                var reason = string.Format(because, becauseArgs);
                throw new AssertionException($"Expected GUID string representation to be \"{expected}\"{reason}, but found \"{_subject}\".");
            }

            return this;
        }

        /// <summary>
        /// Asserts that the GUID is empty (all zeros).
        /// </summary>
        public GuidAssertions BeEmpty(string because = "", params object[] becauseArgs)
        {
            if (_subject != Guid.Empty)
            {
                var reason = string.Format(because, becauseArgs);
                throw new AssertionException($"Expected GUID to be empty (Guid.Empty){reason}, but found {_subject}.");
            }

            return this;
        }

        /// <summary>
        /// Asserts that the GUID is not equal to the unexpected GUID.
        /// </summary>
        public GuidAssertions NotBe(Guid unexpected, string because = "", params object[] becauseArgs)
        {
            if (_subject == unexpected)
            {
                var reason = string.Format(because, becauseArgs);
                throw new AssertionException($"Did not expect GUID to be {unexpected}{reason}, but it was.");
            }

            return this;
        }

        /// <summary>
        /// Asserts that the GUID is not empty (all zeros).
        /// </summary>
        public GuidAssertions NotBeEmpty(string because = "", params object[] becauseArgs)
        {
            if (_subject == Guid.Empty)
            {
                var reason = string.Format(because, becauseArgs);
                throw new AssertionException($"Expected GUID to not be empty (Guid.Empty){reason}, but it was.");
            }

            return this;
        }
    }
}
