using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VerbytesAssertions.Exceptions;

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
        public DateOnlyAssertions Be(DateOnly expected, string because = "", params object[] becauseArgs)
        {
            if (_subject != expected)
            {
                var reason = string.Format(because, becauseArgs);
                throw new AssertionException($"Expected DateOnly to be {expected}{reason}, but found {_subject}.");
            }

            return this;
        }

        /// <summary>
        /// Asserts that the DateOnly value is not equal to the unexpected value.
        /// </summary>
        /// <param name="unexpected">The unexpected DateOnly value.</param>
        /// <param name="because">The reason for the assertion failure, if any.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        public DateOnlyAssertions NotBe(DateOnly unexpected, string because = "", params object[] becauseArgs)
        {
            if (_subject == unexpected)
            {
                var reason = string.Format(because, becauseArgs);
                throw new AssertionException($"Did not expect DateOnly to be {unexpected}{reason}, but it was.");
            }

            return this;
        }

        /// <summary>
        /// Asserts that the DateOnly value is before the expected value.
        /// </summary>
        /// <param name="expected">The expected DateOnly value to compare against.</param>
        /// <param name="because">The reason for the assertion failure, if any.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        public DateOnlyAssertions BeBefore(DateOnly expected, string because = "", params object[] becauseArgs)
        {
            if (_subject >= expected)
            {
                var reason = string.Format(because, becauseArgs);
                throw new AssertionException($"Expected DateOnly to be before {expected}{reason}, but found {_subject}.");
            }

            return this;
        }

        /// <summary>
        /// Asserts that the DateOnly value is after the expected value.
        /// </summary>
        /// <param name="expected">The expected DateOnly value to compare against.</param>
        /// <param name="because">The reason for the assertion failure, if any.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        public DateOnlyAssertions BeAfter(DateOnly expected, string because = "", params object[] becauseArgs)
        {
            if (_subject <= expected)
            {
                var reason = string.Format(because, becauseArgs);
                throw new AssertionException($"Expected DateOnly to be after {expected}{reason}, but found {_subject}.");
            }

            return this;
        }

        /// <summary>
        /// Asserts that the DateOnly value is within the specified range (inclusive).
        /// </summary>
        /// <param name="start">The start of the range.</param>
        /// <param name="end">The end of the range.</param>
        /// <param name="because">The reason for the assertion failure, if any.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        public DateOnlyAssertions BeInRange(DateOnly start, DateOnly end, string because = "", params object[] becauseArgs)
        {
            if (_subject < start || _subject > end)
            {
                var reason = string.Format(because, becauseArgs);
                throw new AssertionException($"Expected DateOnly to be between {start} and {end}{reason}, but found {_subject}.");
            }

            return this;
        }
    }
}
