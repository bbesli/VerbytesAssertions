using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerbytesAssertions.Others
{
    /// <summary>
    /// Contains assertion methods for validating nullable values.
    /// </summary>
    public class NullableAssertions<T> where T : struct
    {
        private readonly T? _subject;

        public NullableAssertions(T? value)
        {
            _subject = value;
        }

        /// <summary>
        /// Asserts that the nullable value is not null.
        /// </summary>
        public NullableAssertions<T> HaveValue(string because = "", params object[] becauseArgs)
        {
            if (!_subject.HasValue)
            {
                var reason = string.Format(because, becauseArgs);
                throw new AssertionException($"Expected nullable to have a value{reason}, but it was null.");
            }

            return this;
        }

        /// <summary>
        /// Asserts that the nullable value is null.
        /// </summary>
        public NullableAssertions<T> NotHaveValue(string because = "", params object[] becauseArgs)
        {
            if (_subject.HasValue)
            {
                var reason = string.Format(because, becauseArgs);
                throw new AssertionException($"Expected nullable to be null{reason}, but it had a value.");
            }

            return this;
        }

        /// <summary>
        /// Asserts that the nullable value is equal to the expected value.
        /// </summary>
        public NullableAssertions<T> Be(T expected, string because = "", params object[] becauseArgs)
        {
            if (!_subject.HasValue || !_subject.Value.Equals(expected))
            {
                var reason = string.Format(because, becauseArgs);
                throw new AssertionException($"Expected nullable to be {expected}{reason}, but found {_subject}.");
            }

            return this;
        }

        /// <summary>
        /// Asserts that the nullable value is not equal to the unexpected value.
        /// </summary>
        public NullableAssertions<T> NotBe(T unexpected, string because = "", params object[] becauseArgs)
        {
            if (_subject.HasValue && _subject.Value.Equals(unexpected))
            {
                var reason = string.Format(because, becauseArgs);
                throw new AssertionException($"Did not expect nullable to be {unexpected}{reason}, but it was.");
            }

            return this;
        }
    }
}
