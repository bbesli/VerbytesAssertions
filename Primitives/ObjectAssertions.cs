using VerbytesAssertions.Exceptions;

namespace VerbytesAssertions.Primitives
{
    /// <summary>
    /// Contains assertion methods for validating objects.
    /// </summary>
    public class ObjectAssertions
    {
        private readonly object _subject;

        public ObjectAssertions(object value)
        {
            _subject = value;
        }

        /// <summary>
        /// Asserts that the object is equal to the expected value using the default equality comparer.
        /// </summary>
        public ObjectAssertions Be<TExpectation>(
            TExpectation expected,
            string because = "",
            params object[] becauseArgs)
        {
            return Be(expected, EqualityComparer<TExpectation>.Default, because, becauseArgs);
        }

        /// <summary>
        /// Asserts that the object is equal to the expected value using the provided comparer.
        /// </summary>
        public ObjectAssertions Be<TExpectation>(
            TExpectation expected,
            IEqualityComparer<TExpectation> comparer,
            string because = "",
            params object[] becauseArgs)
        {
            if (comparer == null)
                throw new ArgumentNullException(nameof(comparer), "Comparer cannot be null.");

            if (!(_subject is TExpectation actual) || !comparer.Equals(actual, expected))
            {
                var reason = string.Format(because, becauseArgs);
                throw new AssertionException($"Expected object to be {expected}{reason}, but found {_subject}.");
            }

            return this;
        }

        /// <summary>
        /// Asserts that the object is not equal to the unexpected value using the default equality comparer.
        /// </summary>
        public ObjectAssertions NotBe<TExpectation>(
            TExpectation unexpected,
            string because = "",
            params object[] becauseArgs)
        {
            return NotBe(unexpected, EqualityComparer<TExpectation>.Default, because, becauseArgs);
        }

        /// <summary>
        /// Asserts that the object is not equal to the unexpected value using the provided comparer.
        /// </summary>
        public ObjectAssertions NotBe<TExpectation>(
            TExpectation unexpected,
            IEqualityComparer<TExpectation> comparer,
            string because = "",
            params object[] becauseArgs)
        {
            if (comparer == null)
                throw new ArgumentNullException(nameof(comparer), "Comparer cannot be null.");

            if (_subject is TExpectation actual && comparer.Equals(actual, unexpected))
            {
                var reason = string.Format(because, becauseArgs);
                throw new AssertionException($"Did not expect object to be {unexpected}{reason}, but it was.");
            }

            return this;
        }
    }
}
