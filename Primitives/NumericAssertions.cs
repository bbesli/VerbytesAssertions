using VerbytesAssertions.Executor;

namespace VerbytesAssertions.Primitives
{
    /// <summary>
    /// Contains assertion methods for validating numeric values.
    /// </summary>
    public class NumericAssertions
    {
        private readonly int _subject;

        /// <summary>
        /// Initializes a new instance of the <see cref="NumericAssertions"/> class.
        /// </summary>
        /// <param name="subject">The numeric value to assert against.</param>
        public NumericAssertions(int subject)
        {
            _subject = subject;
        }

        /// <summary>
        /// Asserts that the numeric value is greater than the specified value.
        /// </summary>
        /// <param name="value">The value to compare against.</param>
        /// <param name="because">The reason for the assertion failure, if any.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        public void BeGreaterThan(int value, string because = "", params object[] becauseArgs) =>
            AssertionExecutor.Execute(_subject > value, this)
                .WithErrorMessage("Expected {0} to be greater than {1}{2}, but it was not.", _subject, value, FormatReason(because, becauseArgs))
                .GetResult();

        /// <summary>
        /// Asserts that the numeric value is less than the specified value.
        /// </summary>
        /// <param name="value">The value to compare against.</param>
        /// <param name="because">The reason for the assertion failure, if any.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        public void BeLessThan(int value, string because = "", params object[] becauseArgs) =>
            AssertionExecutor.Execute(_subject < value, this)
                .WithErrorMessage("Expected {0} to be less than {1}{2}, but it was not.", _subject, value, FormatReason(because, becauseArgs))
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
