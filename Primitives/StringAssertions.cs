using System.Text.RegularExpressions;
using VerbytesAssertions.Executor;

namespace VerbytesAssertions.Primitives
{
    /// <summary>
    /// Contains a number of methods to assert that a <see cref="string"/> is in the expected state.
    /// </summary>
    public class StringAssertions
    {
        private readonly string _subject;

        /// <summary>
        /// Initializes a new instance of the <see cref="StringAssertions"/> class.
        /// </summary>
        /// <param name="value">The string value to assert against.</param>
        public StringAssertions(string value)
        {
            _subject = value;
        }

        /// <summary>
        /// Asserts that a string is exactly the same as another string, including the casing and whitespace.
        /// </summary>
        public void Be(string expected, string because = "", params object[] becauseArgs) =>
            AssertionExecutor.Execute(
                    _subject == expected,
                    this
                )
                .WithErrorMessage("Expected string to be \"{0}\"{1}, but found \"{2}\".", expected, FormatReason(because, becauseArgs), _subject)
                .GetResult();

        /// <summary>
        /// Asserts that a string is not the same as the specified string.
        /// </summary>
        public void NotBe(string unexpected, string because = "", params object[] becauseArgs) =>
            AssertionExecutor.Execute(
                    _subject != unexpected,
                    this
                )
                .WithErrorMessage("Did not expect string to be \"{0}\"{1}, but it was.", unexpected, FormatReason(because, becauseArgs))
                .GetResult();

        /// <summary>
        /// Asserts that the string is one of the specified valid values.
        /// </summary>
        public void BeOneOf(IEnumerable<string> validValues, string because = "", params object[] becauseArgs) =>
            AssertionExecutor.Execute(
                    validValues?.Contains(_subject) == true,
                    this
                )
                .WithErrorMessage("Expected string to be one of [{0}]{1}, but found \"{2}\".", string.Join(", ", validValues), FormatReason(because, becauseArgs), _subject)
                .GetResult();

        /// <summary>
        /// Asserts that the string is not one of the specified valid values.
        /// </summary>
        public void NotBeOneOf(IEnumerable<string> validValues, string because = "", params object[] becauseArgs) =>
            AssertionExecutor.Execute(
                    validValues?.Contains(_subject) == false,
                    this
                )
                .WithErrorMessage("Expected string not to be one of [{0}]{1}, but found \"{2}\".", string.Join(", ", validValues), FormatReason(because, becauseArgs), _subject)
                .GetResult();

        /// <summary>
        /// Asserts that a string contains the specified value.
        /// </summary>
        public void Contain(string expected, string because = "", params object[] becauseArgs) =>
            AssertionExecutor.Execute(
                    _subject?.Contains(expected) == true,
                    this
                )
                .WithErrorMessage("Expected string \"{0}\" to contain \"{1}\"{2}, but it did not.", _subject, expected, FormatReason(because, becauseArgs))
                .GetResult();

        /// <summary>
        /// Asserts that a string starts with the specified value.
        /// </summary>
        public void StartWith(string expected, string because = "", params object[] becauseArgs) =>
            AssertionExecutor.Execute(
                    _subject?.StartsWith(expected) == true,
                    this
                )
                .WithErrorMessage("Expected string \"{0}\" to start with \"{1}\"{2}, but it did not.", _subject, expected, FormatReason(because, becauseArgs))
                .GetResult();

        /// <summary>
        /// Asserts that a string ends with the specified value.
        /// </summary>
        public void EndWith(string expected, string because = "", params object[] becauseArgs) =>
            AssertionExecutor.Execute(
                    _subject?.EndsWith(expected) == true,
                    this
                )
                .WithErrorMessage("Expected string \"{0}\" to end with \"{1}\"{2}, but it did not.", _subject, expected, FormatReason(because, becauseArgs))
                .GetResult();

        /// <summary>
        /// Asserts that a string matches a regular expression.
        /// </summary>
        public void MatchRegex(string pattern, string because = "", params object[] becauseArgs)
        {
            if (string.IsNullOrEmpty(pattern))
                throw new ArgumentNullException(nameof(pattern), "Regex pattern cannot be null or empty.");

            var regex = new Regex(pattern);
            AssertionExecutor.Execute(
                    regex.IsMatch(_subject),
                    this
                )
                .WithErrorMessage("Expected string \"{0}\" to match regex \"{1}\"{2}, but it did not.", _subject, pattern, FormatReason(because, becauseArgs))
                .GetResult();
        }

        /// <summary>
        /// Asserts that a string is not null or empty.
        /// </summary>
        public void NotBeNullOrEmpty(string because = "", params object[] becauseArgs) =>
            AssertionExecutor.Execute(
                    !string.IsNullOrEmpty(_subject),
                    this
                )
                .WithErrorMessage("Expected string not to be null or empty{0}, but it was.", FormatReason(because, becauseArgs))
                .GetResult();

        /// <summary>
        /// Asserts that a string is null or empty.
        /// </summary>
        public void BeNullOrEmpty(string because = "", params object[] becauseArgs) =>
            AssertionExecutor.Execute(
                    string.IsNullOrEmpty(_subject),
                    this
                )
                .WithErrorMessage("Expected string to be null or empty{0}, but found \"{1}\".", FormatReason(because, becauseArgs), _subject)
                .GetResult();

        /// <summary>
        /// Formats the reason string for assertions.
        /// </summary>
        /// <param name="because">The reason for the assertion.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The formatted reason string.</returns>
        private static string FormatReason(string because, object[] becauseArgs) =>
            string.IsNullOrEmpty(because) ? string.Empty : " " + string.Format(because, becauseArgs);
    }
}
