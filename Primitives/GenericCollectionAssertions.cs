
using VerbytesAssertions.Executor;

namespace VerbytesAssertions.Primitives
{
    /// <summary>
    /// Contains assertion methods for validating generic collections.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    public class GenericCollectionAssertions<T>
    {
        private readonly IEnumerable<T> _subject;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericCollectionAssertions{T}"/> class.
        /// </summary>
        /// <param name="subject">The collection to perform assertions on.</param>
        public GenericCollectionAssertions(IEnumerable<T> subject)
        {
            _subject = subject ?? throw new ArgumentNullException(nameof(subject), "Collection cannot be null.");
        }

        /// <summary>
        /// Asserts that the collection contains the specified item.
        /// </summary>
        public void Contain(T item, string because = "", params object[] becauseArgs) =>
            AssertionExecutor.Execute(_subject.Contains(item), this)
                .WithErrorMessage("Expected collection to contain {0}{1}, but it did not.", item, FormatReason(because, becauseArgs))
                .GetResult();

        /// <summary>
        /// Asserts that the collection does not contain the specified item.
        /// </summary>
        public void NotContain(T item, string because = "", params object[] becauseArgs) =>
            AssertionExecutor.Execute(!_subject.Contains(item), this)
                .WithErrorMessage("Did not expect collection to contain {0}{1}, but it did.", item, FormatReason(because, becauseArgs))
                .GetResult();

        /// <summary>
        /// Asserts that the collection is empty.
        /// </summary>
        public void BeEmpty(string because = "", params object[] becauseArgs) =>
            AssertionExecutor.Execute(!_subject.Any(), this)
                .WithErrorMessage("Expected collection to be empty{0}, but it contained {1} items.", FormatReason(because, becauseArgs), _subject.Count())
                .GetResult();

        /// <summary>
        /// Asserts that the collection is not empty.
        /// </summary>
        public void NotBeEmpty(string because = "", params object[] becauseArgs) =>
            AssertionExecutor.Execute(_subject.Any(), this)
                .WithErrorMessage("Expected collection to not be empty{0}, but it was.", FormatReason(because, becauseArgs))
                .GetResult();

        /// <summary>
        /// Asserts that the collection has the specified count.
        /// </summary>
        public void HaveCount(int expectedCount, string because = "", params object[] becauseArgs) =>
            AssertionExecutor.Execute(_subject.Count() == expectedCount, this)
                .WithErrorMessage("Expected collection to have {0} items{1}, but found {2}.", expectedCount, FormatReason(because, becauseArgs), _subject.Count())
                .GetResult();

        /// <summary>
        /// Asserts that the collection contains all the expected items.
        /// </summary>
        public void ContainAll(IEnumerable<T> expectedItems, string because = "", params object[] becauseArgs) =>
            AssertionExecutor.Execute(expectedItems.All(item => _subject.Contains(item)), this)
                .WithErrorMessage("Expected collection to contain all items in [{0}]{1}, but it did not.", string.Join(", ", expectedItems), FormatReason(because, becauseArgs))
                .GetResult();

        /// <summary>
        /// Asserts that the collection contains exactly the specified items, in the same order.
        /// </summary>
        public void BeEquivalentTo(IEnumerable<T> expectedItems, string because = "", params object[] becauseArgs) =>
            AssertionExecutor.Execute(_subject.SequenceEqual(expectedItems), this)
                .WithErrorMessage("Expected collection to be equivalent to [{0}]{1}, but found [{2}].",
                    string.Join(", ", expectedItems),
                    FormatReason(because, becauseArgs),
                    string.Join(", ", _subject))
                .GetResult();

        /// <summary>
        /// Formats the reason string for assertions.
        /// </summary>
        private static string FormatReason(string because, object[] becauseArgs) =>
            string.IsNullOrEmpty(because) ? string.Empty : " " + string.Format(because, becauseArgs);
    }
}
