using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VerbytesAssertions.Executor;

namespace VerbytesAssertions.Others
{
    /// <summary>
    /// Contains assertion methods for validating nullable values.
    /// </summary>
    public class NullableAssertions<T> where T : struct
    {
        private readonly T? _subject;

        /// <summary>
        /// Initializes a new instance of the <see cref="NullableAssertions{T}"/> class.
        /// </summary>
        /// <param name="value">The nullable value to assert against.</param>
        public NullableAssertions(T? value)
        {
            _subject = value;
        }

        /// <summary>
        /// Asserts that the nullable value has a value.
        /// </summary>
        /// <param name="because">The reason for the assertion.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        public void HaveValue(string because = "", params object[] becauseArgs) =>
            AssertionExecutor.Execute(
                    _subject.HasValue,
                    this
                )
                .WithErrorMessage("Expected nullable to have a value{0}, but it was null.", FormatReason(because, becauseArgs))
                .GetResult();

        /// <summary>
        /// Asserts that the nullable value does not have a value (is null).
        /// </summary>
        /// <param name="because">The reason for the assertion.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        public void NotHaveValue(string because = "", params object[] becauseArgs) =>
            AssertionExecutor.Execute(
                    !_subject.HasValue,
                    this
                )
                .WithErrorMessage("Expected nullable to be null{0}, but it had a value.", FormatReason(because, becauseArgs))
                .GetResult();

        /// <summary>
        /// Asserts that the nullable value is equal to the expected value.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        /// <param name="because">The reason for the assertion.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        public void Be(T expected, string because = "", params object[] becauseArgs) =>
            AssertionExecutor.Execute(
                    _subject.HasValue && _subject.Value.Equals(expected),
                    this
                )
                .WithErrorMessage("Expected nullable to be {0}{1}, but found {2}.", expected, FormatReason(because, becauseArgs), _subject)
                .GetResult();

        /// <summary>
        /// Asserts that the nullable value is not equal to the unexpected value.
        /// </summary>
        /// <param name="unexpected">The unexpected value.</param>
        /// <param name="because">The reason for the assertion.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        public void NotBe(T unexpected, string because = "", params object[] becauseArgs) =>
            AssertionExecutor.Execute(
                    !_subject.HasValue || !_subject.Value.Equals(unexpected),
                    this
                )
                .WithErrorMessage("Did not expect nullable to be {0}{1}, but it was.", unexpected, FormatReason(because, becauseArgs))
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
