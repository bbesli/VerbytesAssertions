using System.Text.RegularExpressions;
using VerbytesAssertions.Exceptions;

namespace VerbytesAssertions.Primitives
{
    /// <summary>
    /// Contains a number of methods to assert that a <see cref="string"/> is in the expected state.
    /// </summary>
    public class StringAssertions
    {
        private readonly string _subject;

        public StringAssertions(string value)
        {
            _subject = value;
        }

        /// <summary>
        /// Asserts that a string is exactly the same as another string, including the casing and whitespace.
        /// </summary>
        public StringAssertions Be(string expected, string because = "", params object[] becauseArgs)
        {
            if (_subject != expected)
            {
                var reason = string.Format(because, becauseArgs);
                throw new AssertionException($"Expected string to be \"{expected}\"{reason}, but found \"{_subject}\".");
            }

            return this;
        }

        /// <summary>
        /// Asserts that a string is not the same as the specified string.
        /// </summary>
        public StringAssertions NotBe(string unexpected, string because = "", params object[] becauseArgs)
        {
            if (_subject == unexpected)
            {
                var reason = string.Format(because, becauseArgs);
                throw new AssertionException($"Did not expect string to be \"{unexpected}\"{reason}, but it was.");
            }

            return this;
        }

        /// <summary>
        /// Asserts that the string is one of the specified valid values.
        /// </summary>
        public StringAssertions BeOneOf(IEnumerable<string> validValues, string because = "", params object[] becauseArgs)
        {
            if (validValues == null || !validValues.Contains(_subject))
            {
                var reason = string.Format(because, becauseArgs);
                throw new AssertionException($"Expected string to be one of [{string.Join(", ", validValues)}]{reason}, but found \"{_subject}\".");
            }

            return this;
        }

        /// <summary>
        /// Asserts that a string contains the specified value.
        /// </summary>
        public StringAssertions Contain(string expected, string because = "", params object[] becauseArgs)
        {
            if (_subject == null || !_subject.Contains(expected))
            {
                var reason = string.Format(because, becauseArgs);
                throw new AssertionException($"Expected string \"{_subject}\" to contain \"{expected}\"{reason}, but it did not.");
            }

            return this;
        }

        /// <summary>
        /// Asserts that a string starts with the specified value.
        /// </summary>
        public StringAssertions StartWith(string expected, string because = "", params object[] becauseArgs)
        {
            if (_subject == null || !_subject.StartsWith(expected))
            {
                var reason = string.Format(because, becauseArgs);
                throw new AssertionException($"Expected string \"{_subject}\" to start with \"{expected}\"{reason}, but it did not.");
            }

            return this;
        }

        /// <summary>
        /// Asserts that a string ends with the specified value.
        /// </summary>
        public StringAssertions EndWith(string expected, string because = "", params object[] becauseArgs)
        {
            if (_subject == null || !_subject.EndsWith(expected))
            {
                var reason = string.Format(because, becauseArgs);
                throw new AssertionException($"Expected string \"{_subject}\" to end with \"{expected}\"{reason}, but it did not.");
            }

            return this;
        }

        /// <summary>
        /// Asserts that a string matches a regular expression.
        /// </summary>
        public StringAssertions MatchRegex(string pattern, string because = "", params object[] becauseArgs)
        {
            if (string.IsNullOrEmpty(pattern))
                throw new ArgumentNullException(nameof(pattern), "Regex pattern cannot be null or empty.");

            var regex = new Regex(pattern);
            if (_subject == null || !regex.IsMatch(_subject))
            {
                var reason = string.Format(because, becauseArgs);
                throw new AssertionException($"Expected string \"{_subject}\" to match regex \"{pattern}\"{reason}, but it did not.");
            }

            return this;
        }

        /// <summary>
        /// Asserts that a string is not null or empty.
        /// </summary>
        public StringAssertions NotBeNullOrEmpty(string because = "", params object[] becauseArgs)
        {
            if (string.IsNullOrEmpty(_subject))
            {
                var reason = string.Format(because, becauseArgs);
                throw new AssertionException($"Expected string not to be null or empty{reason}, but it was.");
            }

            return this;
        }

        /// <summary>
        /// Asserts that a string is null or empty.
        /// </summary>
        public StringAssertions BeNullOrEmpty(string because = "", params object[] becauseArgs)
        {
            if (!string.IsNullOrEmpty(_subject))
            {
                var reason = string.Format(because, becauseArgs);
                throw new AssertionException($"Expected string to be null or empty{reason}, but found \"{_subject}\".");
            }

            return this;
        }
    }
}
