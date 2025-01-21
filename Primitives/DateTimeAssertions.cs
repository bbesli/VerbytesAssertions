
using VerbytesAssertions.Executor;

namespace VerbytesAssertions.Primitives
{
    /// <summary>
    /// Provides assertion methods for validating <see cref="DateTime"/> values.
    /// </summary>
    public class DateTimeAssertions
    {
        private readonly DateTime? _subject;

        /// <summary>
        /// Initializes a new instance of the <see cref="DateTimeAssertions"/> class.
        /// </summary>
        /// <param name="value">The <see cref="DateTime"/> value to perform assertions on.</param>
        public DateTimeAssertions(DateTime? value)
        {
            _subject = value;
        }

        /// <summary>
        /// Asserts that the <see cref="DateTime"/> value is equal to the expected value.
        /// </summary>
        /// <param name="expected">The expected <see cref="DateTime"/> value.</param>
        /// <param name="because">The reason why the assertion should hold.</param>
        /// <param name="becauseArgs">Arguments to format into the reason message.</param>
        /// <exception cref="AssertionException">Thrown if the assertion fails.</exception>
        public void Be(DateTime expected, string because = "", params object[] becauseArgs) =>
            AssertionExecutor.Execute(_subject == expected, this)
                .WithErrorMessage("Expected DateTime to be {0}{1}, but found {2}.", expected, FormatBecause(because, becauseArgs), _subject)
                .GetResult();

        /// <summary>
        /// Asserts that the <see cref="DateTime"/> value is not equal to the specified value.
        /// </summary>
        /// <param name="unexpected">The <see cref="DateTime"/> value that the subject should not match.</param>
        /// <param name="because">The reason why the assertion should hold.</param>
        /// <param name="becauseArgs">Arguments to format into the reason message.</param>
        /// <exception cref="AssertionException">Thrown if the assertion fails.</exception>
        public void NotBe(DateTime unexpected, string because = "", params object[] becauseArgs) =>
            AssertionExecutor.Execute(_subject != unexpected, this)
                .WithErrorMessage("Did not expect DateTime to be {0}{1}, but it was.", unexpected, FormatBecause(because, becauseArgs))
                .GetResult();

        /// <summary>
        /// Asserts that the <see cref="DateTime"/> value is earlier than the specified value.
        /// </summary>
        /// <param name="expected">The <see cref="DateTime"/> value that the subject should be earlier than.</param>
        /// <param name="because">The reason why the assertion should hold.</param>
        /// <param name="becauseArgs">Arguments to format into the reason message.</param>
        /// <exception cref="AssertionException">Thrown if the assertion fails.</exception>
        public void BeBefore(DateTime expected, string because = "", params object[] becauseArgs) =>
            AssertionExecutor.Execute(_subject < expected, this)
                .WithErrorMessage("Expected DateTime to be before {0}{1}, but found {2}.", expected, FormatBecause(because, becauseArgs), _subject)
                .GetResult();

        /// <summary>
        /// Asserts that the <see cref="DateTime"/> value is later than the specified value.
        /// </summary>
        /// <param name="expected">The <see cref="DateTime"/> value that the subject should be later than.</param>
        /// <param name="because">The reason why the assertion should hold.</param>
        /// <param name="becauseArgs">Arguments to format into the reason message.</param>
        /// <exception cref="AssertionException">Thrown if the assertion fails.</exception>
        public void BeAfter(DateTime expected, string because = "", params object[] becauseArgs) =>
            AssertionExecutor.Execute(_subject > expected, this)
                .WithErrorMessage("Expected DateTime to be after {0}{1}, but found {2}.", expected, FormatBecause(because, becauseArgs), _subject)
                .GetResult();

        /// <summary>
        /// Asserts that the <see cref="DateTime"/> value falls within the specified range, inclusive.
        /// </summary>
        /// <param name="start">The start of the range.</param>
        /// <param name="end">The end of the range.</param>
        /// <param name="because">The reason why the assertion should hold.</param>
        /// <param name="becauseArgs">Arguments to format into the reason message.</param>
        /// <exception cref="AssertionException">Thrown if the assertion fails.</exception>
        public void BeInRange(DateTime start, DateTime end, string because = "", params object[] becauseArgs) =>
            AssertionExecutor.Execute(_subject >= start && _subject <= end, this)
                .WithErrorMessage("Expected DateTime to be between {0} and {1}{2}, but found {3}.", start, end, FormatBecause(because, becauseArgs), _subject)
                .GetResult();

        /// <summary>
        /// Formats the "because" message for inclusion in error messages.
        /// </summary>
        /// <param name="because">The reason string.</param>
        /// <param name="args">Arguments for formatting the reason.</param>
        /// <returns>The formatted "because" message.</returns>
        private static string FormatBecause(string because, params object[] args)
        {
            return string.IsNullOrEmpty(because) ? string.Empty : " " + string.Format(because, args);
        }
    }
}
