using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VerbytesAssertions.Exceptions;

namespace VerbytesAssertions.Primitives
{
    /// <summary>
    /// Contains assertion methods for validating DateTime values.
    /// </summary>
    public class DateTimeAssertions
    {
        private readonly DateTime? _subject;

        public DateTimeAssertions(DateTime? value)
        {
            _subject = value;
        }

        /// <summary>
        /// Asserts that the DateTime is exactly equal to the expected value.
        /// </summary>
        public DateTimeAssertions Be(DateTime expected, string because = "", params object[] becauseArgs)
        {
            if (_subject != expected)
            {
                var reason = string.Format(because, becauseArgs);
                throw new AssertionException($"Expected DateTime to be {expected}{reason}, but found {_subject}.");
            }

            return this;
        }

        /// <summary>
        /// Asserts that the DateTime is not equal to the unexpected value.
        /// </summary>
        public DateTimeAssertions NotBe(DateTime unexpected, string because = "", params object[] becauseArgs)
        {
            if (_subject == unexpected)
            {
                var reason = string.Format(because, becauseArgs);
                throw new AssertionException($"Did not expect DateTime to be {unexpected}{reason}, but it was.");
            }

            return this;
        }

        /// <summary>
        /// Asserts that the DateTime is before the expected value.
        /// </summary>
        public DateTimeAssertions BeBefore(DateTime expected, string because = "", params object[] becauseArgs)
        {
            if (_subject >= expected)
            {
                var reason = string.Format(because, becauseArgs);
                throw new AssertionException($"Expected DateTime to be before {expected}{reason}, but found {_subject}.");
            }

            return this;
        }

        /// <summary>
        /// Asserts that the DateTime is after the expected value.
        /// </summary>
        public DateTimeAssertions BeAfter(DateTime expected, string because = "", params object[] becauseArgs)
        {
            if (_subject <= expected)
            {
                var reason = string.Format(because, becauseArgs);
                throw new AssertionException($"Expected DateTime to be after {expected}{reason}, but found {_subject}.");
            }

            return this;
        }

        /// <summary>
        /// Asserts that the DateTime is within the specified range (inclusive).
        /// </summary>
        public DateTimeAssertions BeInRange(DateTime start, DateTime end, string because = "", params object[] becauseArgs)
        {
            if (_subject < start || _subject > end)
            {
                var reason = string.Format(because, becauseArgs);
                throw new AssertionException($"Expected DateTime to be between {start} and {end}{reason}, but found {_subject}.");
            }

            return this;
        }
    }
}
