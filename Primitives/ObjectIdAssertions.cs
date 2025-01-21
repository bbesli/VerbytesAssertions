using MongoDB.Bson;
using VerbytesAssertions.Executor;

namespace VerbytesAssertions.Primitives
{
    /// <summary>
    /// Contains assertion methods for validating <see cref="ObjectId"/> values.
    /// </summary>
    public class ObjectIdAssertions
    {
        private readonly ObjectId _subject;

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectIdAssertions"/> class.
        /// </summary>
        /// <param name="subject">The ObjectId to assert against.</param>
        public ObjectIdAssertions(ObjectId subject)
        {
            _subject = subject;
        }

        /// <summary>
        /// Asserts that the ObjectId is empty.
        /// </summary>
        /// <param name="because">The reason for the assertion failure, if any.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        public void BeEmpty(string because = "", params object[] becauseArgs)
        {
            AssertionExecutor.Execute(
                    _subject == ObjectId.Empty,
                    this
                )
                .WithErrorMessage("Expected ObjectId to be empty{0}, but found '{1}'.", FormatReason(because, becauseArgs), _subject)
                .GetResult();
        }

        /// <summary>
        /// Asserts that the ObjectId is not empty.
        /// </summary>
        /// <param name="because">The reason for the assertion failure, if any.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        public void NotBeEmpty(string because = "", params object[] becauseArgs)
        {
            AssertionExecutor.Execute(
                    _subject != ObjectId.Empty,
                    this
                )
                .WithErrorMessage("Expected ObjectId not to be empty{0}, but it was.", FormatReason(because, becauseArgs))
                .GetResult();
        }

        /// <summary>
        /// Asserts that the ObjectId is equal to the expected value.
        /// </summary>
        /// <param name="expected">The expected ObjectId value.</param>
        /// <param name="because">The reason for the assertion failure, if any.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        public void BeEqualTo(ObjectId expected, string because = "", params object[] becauseArgs)
        {
            AssertionExecutor.Execute(
                    _subject == expected,
                    this
                )
                .WithErrorMessage("Expected ObjectId to be '{0}'{1}, but found '{2}'.", expected, FormatReason(because, becauseArgs), _subject)
                .GetResult();
        }

        /// <summary>
        /// Asserts that the ObjectId is not equal to the unexpected value.
        /// </summary>
        /// <param name="unexpected">The unexpected ObjectId value.</param>
        /// <param name="because">The reason for the assertion failure, if any.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        public void NotBeEqualTo(ObjectId unexpected, string because = "", params object[] becauseArgs)
        {
            AssertionExecutor.Execute(
                    _subject != unexpected,
                    this
                )
                .WithErrorMessage("Expected ObjectId not to be '{0}'{1}, but it was.", unexpected, FormatReason(because, becauseArgs))
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
