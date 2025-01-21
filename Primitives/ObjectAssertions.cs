
using VerbytesAssertions.Executor;

namespace VerbytesAssertions.Primitives
{
    /// <summary>
    /// Contains assertion methods for validating objects.
    /// </summary>
    public class ObjectAssertions
    {
        private readonly object _subject;

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectAssertions"/> class.
        /// </summary>
        /// <param name="value">The object to assert against.</param>
        public ObjectAssertions(object value)
        {
            _subject = value;
        }

        /// <summary>
        /// Asserts that the object is equal to the expected value using the default equality comparer.
        /// </summary>
        /// <typeparam name="TExpectation">The type of the expected object.</typeparam>
        /// <param name="expected">The expected value.</param>
        /// <param name="because">The reason for the assertion failure, if any.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        public void Be<TExpectation>(TExpectation expected, string because = "", params object[] becauseArgs) =>
            Be(expected, EqualityComparer<TExpectation>.Default, because, becauseArgs);

        /// <summary>
        /// Asserts that the object is equal to the expected value using the provided comparer.
        /// </summary>
        /// <typeparam name="TExpectation">The type of the expected object.</typeparam>
        /// <param name="expected">The expected value.</param>
        /// <param name="comparer">The equality comparer to use for comparison.</param>
        /// <param name="because">The reason for the assertion failure, if any.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        public void Be<TExpectation>(
            TExpectation expected,
            IEqualityComparer<TExpectation> comparer,
            string because = "",
            params object[] becauseArgs)
        {
            AssertionExecutor.Execute(
                    _subject is TExpectation actual && comparer.Equals(actual, expected),
                    this
                )
                .WithErrorMessage("Expected object to be {0}{1}, but found {2}.", expected, FormatReason(because, becauseArgs), _subject)
                .GetResult();
        }

        /// <summary>
        /// Asserts that the object is not equal to the unexpected value using the default equality comparer.
        /// </summary>
        /// <typeparam name="TExpectation">The type of the unexpected object.</typeparam>
        /// <param name="unexpected">The unexpected value.</param>
        /// <param name="because">The reason for the assertion failure, if any.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        public void NotBe<TExpectation>(TExpectation unexpected, string because = "", params object[] becauseArgs) =>
            NotBe(unexpected, EqualityComparer<TExpectation>.Default, because, becauseArgs);

        /// <summary>
        /// Asserts that the object is not equal to the unexpected value using the provided comparer.
        /// </summary>
        /// <typeparam name="TExpectation">The type of the unexpected object.</typeparam>
        /// <param name="unexpected">The unexpected value.</param>
        /// <param name="comparer">The equality comparer to use for comparison.</param>
        /// <param name="because">The reason for the assertion failure, if any.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        public void NotBe<TExpectation>(
            TExpectation unexpected,
            IEqualityComparer<TExpectation> comparer,
            string because = "",
            params object[] becauseArgs)
        {
            AssertionExecutor.Execute(
                    !(_subject is TExpectation actual && comparer.Equals(actual, unexpected)),
                    this
                )
                .WithErrorMessage("Did not expect object to be {0}{1}, but it was.", unexpected, FormatReason(because, becauseArgs))
                .GetResult();
        }

        /// <summary>
        /// Asserts that the object is not null.
        /// </summary>
        /// <param name="because">The reason for the assertion failure, if any.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        public void NotBeNull(string because = "", params object[] becauseArgs)
        {
            AssertionExecutor.Execute(
                    _subject != null,
                    this
                )
                .WithErrorMessage("Expected object not to be null{0}, but it was.", FormatReason(because, becauseArgs))
                .GetResult();
        }

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
