
using VerbytesAssertions.Executor;

namespace VerbytesAssertions.Primitives
{
    /// <summary>
    /// Contains assertion methods for validating GUID values.
    /// </summary>
    public class GuidAssertions
    {
        private readonly Guid _subject;

        /// <summary>
        /// Initializes a new instance of the <see cref="GuidAssertions"/> class.
        /// </summary>
        /// <param name="subject">The GUID to assert against.</param>
        public GuidAssertions(Guid subject)
        {
            _subject = subject;
        }

        /// <summary>
        /// Asserts that the GUID is equal to the expected GUID.
        /// </summary>
        /// <param name="expected">The expected GUID value.</param>
        /// <param name="because">A formatted explanation of why the assertion is needed.</param>
        /// <param name="becauseArgs">Zero or more objects to format into the explanation.</param>
        public void Be(Guid expected, string because = "", params object[] becauseArgs) =>
            AssertionExecutor.Execute(_subject == expected, this)
                .WithErrorMessage("Expected GUID to be {0}{1}, but found {2}.", expected, FormatReason(because, becauseArgs), _subject)
                .GetResult();

        /// <summary>
        /// Asserts that the GUID, when converted to a string, is equal to the expected string representation.
        /// </summary>
        /// <param name="expected">The expected string representation of the GUID.</param>
        /// <param name="because">A formatted explanation of why the assertion is needed.</param>
        /// <param name="becauseArgs">Zero or more objects to format into the explanation.</param>
        public void Be(string expected, string because = "", params object[] becauseArgs) =>
            AssertionExecutor.Execute(_subject.ToString() == expected, this)
                .WithErrorMessage("Expected GUID string representation to be \"{0}\"{1}, but found \"{2}\".", expected, FormatReason(because, becauseArgs), _subject)
                .GetResult();

        /// <summary>
        /// Asserts that the GUID is empty (all zeros).
        /// </summary>
        /// <param name="because">A formatted explanation of why the assertion is needed.</param>
        /// <param name="becauseArgs">Zero or more objects to format into the explanation.</param>
        public void BeEmpty(string because = "", params object[] becauseArgs) =>
            AssertionExecutor.Execute(_subject == Guid.Empty, this)
                .WithErrorMessage("Expected GUID to be empty (Guid.Empty){0}, but found {1}.", FormatReason(because, becauseArgs), _subject)
                .GetResult();

        /// <summary>
        /// Asserts that the GUID is not equal to the unexpected GUID.
        /// </summary>
        /// <param name="unexpected">The GUID value that is not expected.</param>
        /// <param name="because">A formatted explanation of why the assertion is needed.</param>
        /// <param name="becauseArgs">Zero or more objects to format into the explanation.</param>
        public void NotBe(Guid unexpected, string because = "", params object[] becauseArgs) =>
            AssertionExecutor.Execute(_subject != unexpected, this)
                .WithErrorMessage("Did not expect GUID to be {0}{1}, but it was.", unexpected, FormatReason(because, becauseArgs))
                .GetResult();

        /// <summary>
        /// Asserts that the GUID is not empty (all zeros).
        /// </summary>
        /// <param name="because">A formatted explanation of why the assertion is needed.</param>
        /// <param name="becauseArgs">Zero or more objects to format into the explanation.</param>
        public void NotBeEmpty(string because = "", params object[] becauseArgs) =>
            AssertionExecutor.Execute(_subject != Guid.Empty, this)
                .WithErrorMessage("Expected GUID to not be empty (Guid.Empty){0}, but it was.", FormatReason(because, becauseArgs))
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
