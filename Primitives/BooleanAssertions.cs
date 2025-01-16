using VerbytesAssertions.Exceptions;

namespace VerbytesAssertions.Primitives
{
    /// <summary>
    /// Contains assertion methods for validating boolean values.
    /// </summary>
    public class BooleanAssertions
    {
        private readonly bool? _subject;

        public BooleanAssertions(bool? value)
        {
            _subject = value;
        }

        /// <summary>
        /// Asserts that the boolean value is equal to the expected value.
        /// </summary>
        public BooleanAssertions Be(bool expected, string because = "", params object[] becauseArgs)
        {
            if (_subject != expected)
            {
                var reason = string.Format(because, becauseArgs);
                throw new AssertionException($"Expected boolean to be {expected}{reason}, but found {_subject}.");
            }

            return this;
        }

        /// <summary>
        /// Asserts that the boolean value is true.
        /// </summary>
        public BooleanAssertions BeTrue(string because = "", params object[] becauseArgs)
        {
            if (_subject != true)
            {
                var reason = string.Format(because, becauseArgs);
                throw new AssertionException($"Expected boolean to be true{reason}, but found {_subject}.");
            }

            return this;
        }

        /// <summary>
        /// Asserts that the boolean value is false.
        /// </summary>
        public BooleanAssertions BeFalse(string because = "", params object[] becauseArgs)
        {
            if (_subject != false)
            {
                var reason = string.Format(because, becauseArgs);
                throw new AssertionException($"Expected boolean to be false{reason}, but found {_subject}.");
            }

            return this;
        }

        /// <summary>
        /// Asserts that the boolean value is not equal to the unexpected value.
        /// </summary>
        public BooleanAssertions NotBe(bool unexpected, string because = "", params object[] becauseArgs)
        {
            if (_subject == unexpected)
            {
                var reason = string.Format(because, becauseArgs);
                throw new AssertionException($"Did not expect boolean to be {unexpected}{reason}, but it was.");
            }

            return this;
        }

        /// <summary>
        /// Asserts that the boolean value implies another boolean value.
        /// </summary>
        public BooleanAssertions Imply(bool consequent, string because = "", params object[] becauseArgs)
        {
            if (_subject == true && !consequent)
            {
                var reason = string.Format(because, becauseArgs);
                throw new AssertionException($"Expected {_subject} to imply {consequent}{reason}, but it did not.");
            }

            return this;
        }
    }
}
