using VerbytesAssertions.Executor;

namespace VerbytesAssertions.Primitives
{
    /// <summary>
    /// Contains assertion methods for validating <see cref="DateOnly"/> values.
    /// </summary>
    public class DateOnlyAssertions
    {
        private readonly DateOnly? _subject;

        public DateOnlyAssertions(DateOnly? value)
        {
            _subject = value;
        }

        /// <summary>
        /// Asserts that the DateOnly value is exactly equal to the expected value.
        /// </summary>
        /// <param name="expected">The expected DateOnly value.</param>
        /// <param name="because">The reason for the assertion failure, if any.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        public void Be(DateOnly expected, string because = "", params object[] becauseArgs) =>
            AssertionExecutor.Execute(_subject == expected, this)
                .WithErrorMessage("Expected DateOnly to be {0}{1}, but found {2}.", expected, FormatBecause(because, becauseArgs), _subject)
                .GetResult();

        /// <summary>
        /// Asserts that the DateOnly value is not equal to the unexpected value.
        /// </summary>
        /// <param name="unexpected">The unexpected DateOnly value.</param>
        /// <param name="because">The reason for the assertion failure, if any.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        public void NotBe(DateOnly unexpected, string because = "", params object[] becauseArgs) =>
            AssertionExecutor.Execute(_subject != unexpected, this)
                .WithErrorMessage("Did not expect DateOnly to be {0}{1}, but it was.", unexpected, FormatBecause(because, becauseArgs))
                .GetResult();

        /// <summary>
        /// Asserts that the DateOnly value is before the expected value.
        /// </summary>
        /// <param name="expected">The expected DateOnly value to compare against.</param>
        /// <param name="because">The reason for the assertion failure, if any.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        public void BeBefore(DateOnly expected, string because = "", params object[] becauseArgs) =>
            AssertionExecutor.Execute(_subject < expected, this)
                .WithErrorMessage("Expected DateOnly to be before {0}{1}, but found {2}.", expected, FormatBecause(because, becauseArgs), _subject)
                .GetResult();

        /// <summary>
        /// Asserts that the DateOnly value is after the expected value.
        /// </summary>
        /// <param name="expected">The expected DateOnly value to compare against.</param>
        /// <param name="because">The reason for the assertion failure, if any.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        public void BeAfter(DateOnly expected, string because = "", params object[] becauseArgs) =>
            AssertionExecutor.Execute(_subject > expected, this)
                .WithErrorMessage("Expected DateOnly to be after {0}{1}, but found {2}.", expected, FormatBecause(because, becauseArgs), _subject)
                .GetResult();

        /// <summary>
        /// Asserts that the DateOnly value is within the specified range (inclusive).
        /// </summary>
        /// <param name="start">The start of the range.</param>
        /// <param name="end">The end of the range.</param>
        /// <param name="because">The reason for the assertion failure, if any.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        public void BeInRange(DateOnly start, DateOnly end, string because = "", params object[] becauseArgs) =>
            AssertionExecutor.Execute(_subject >= start && _subject <= end, this)
                .WithErrorMessage("Expected DateOnly to be between {0} and {1}{2}, but found {3}.", start, end, FormatBecause(because, becauseArgs), _subject)
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
