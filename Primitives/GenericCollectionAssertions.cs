
namespace VerbytesAssertions.Primitives
{
    /// <summary>
    /// Contains assertion methods for validating generic collections.
    /// </summary>
    public class GenericCollectionAssertions<T>
    {
        private readonly IEnumerable<T> _subject;

        public GenericCollectionAssertions(IEnumerable<T> subject)
        {
            _subject = subject ?? throw new ArgumentNullException(nameof(subject), "Collection cannot be null.");
        }

        /// <summary>
        /// Asserts that the collection contains the specified item.
        /// </summary>
        public GenericCollectionAssertions<T> Contain(T item, string because = "", params object[] becauseArgs)
        {
            if (!_subject.Contains(item))
            {
                var reason = string.Format(because, becauseArgs);
                throw new AssertionException($"Expected collection to contain {item}{reason}, but it did not.");
            }

            return this;
        }

        /// <summary>
        /// Asserts that the collection does not contain the specified item.
        /// </summary>
        public GenericCollectionAssertions<T> NotContain(T item, string because = "", params object[] becauseArgs)
        {
            if (_subject.Contains(item))
            {
                var reason = string.Format(because, becauseArgs);
                throw new AssertionException($"Did not expect collection to contain {item}{reason}, but it did.");
            }

            return this;
        }

        /// <summary>
        /// Asserts that the collection is empty.
        /// </summary>
        public GenericCollectionAssertions<T> BeEmpty(string because = "", params object[] becauseArgs)
        {
            if (_subject.Any())
            {
                var reason = string.Format(because, becauseArgs);
                throw new AssertionException($"Expected collection to be empty{reason}, but it contained {_subject.Count()} items.");
            }

            return this;
        }

        /// <summary>
        /// Asserts that the collection is not empty.
        /// </summary>
        public GenericCollectionAssertions<T> NotBeEmpty(string because = "", params object[] becauseArgs)
        {
            if (!_subject.Any())
            {
                var reason = string.Format(because, becauseArgs);
                throw new AssertionException($"Expected collection to not be empty{reason}, but it was.");
            }

            return this;
        }

        /// <summary>
        /// Asserts that the collection has the specified count.
        /// </summary>
        public GenericCollectionAssertions<T> HaveCount(int expectedCount, string because = "", params object[] becauseArgs)
        {
            var actualCount = _subject.Count();
            if (actualCount != expectedCount)
            {
                var reason = string.Format(because, becauseArgs);
                throw new AssertionException($"Expected collection to have {expectedCount} items{reason}, but found {actualCount}.");
            }

            return this;
        }

        /// <summary>
        /// Asserts that the collection contains all the expected items.
        /// </summary>
        public GenericCollectionAssertions<T> ContainAll(IEnumerable<T> expectedItems, string because = "", params object[] becauseArgs)
        {
            foreach (var item in expectedItems)
            {
                if (!_subject.Contains(item))
                {
                    var reason = string.Format(because, becauseArgs);
                    throw new AssertionException($"Expected collection to contain {item}{reason}, but it did not.");
                }
            }

            return this;
        }

        /// <summary>
        /// Asserts that the collection contains exactly the specified items, in the same order.
        /// </summary>
        public GenericCollectionAssertions<T> BeEquivalentTo(IEnumerable<T> expectedItems, string because = "", params object[] becauseArgs)
        {
            var subjectArray = _subject.ToArray();
            var expectedArray = expectedItems.ToArray();

            if (!subjectArray.SequenceEqual(expectedArray))
            {
                var reason = string.Format(because, becauseArgs);
                throw new AssertionException($"Expected collection to be equivalent to [{string.Join(", ", expectedArray)}]{reason}, but found [{string.Join(", ", subjectArray)}].");
            }

            return this;
        }
    }
}
