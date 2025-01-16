using System.Globalization;
using System.Linq.Expressions;

namespace VerbytesAssertions.Primitives
{
    /// <summary>
    /// Contains assertion methods for validating enums.
    /// </summary>
    public class EnumAssertions<TEnum>
        where TEnum : struct, Enum
    {
        private readonly TEnum? _subject;

        public EnumAssertions(TEnum subject) : this((TEnum?)subject) { }

        private EnumAssertions(TEnum? subject)
        {
            _subject = subject;
        }

        /// <summary>
        /// Asserts that the current enum is exactly equal to the expected value.
        /// </summary>
        public EnumAssertions<TEnum> Be(TEnum expected, string because = "", params object[] becauseArgs)
        {
            if (!_subject.Equals(expected))
            {
                var reason = FormatReason(because, becauseArgs);
                throw new AssertionException($"Expected enum to be {expected}{reason}, but found {_subject}.");
            }

            return this;
        }

        /// <summary>
        /// Asserts that the current enum is not equal to the unexpected value.
        /// </summary>
        public EnumAssertions<TEnum> NotBe(TEnum unexpected, string because = "", params object[] becauseArgs)
        {
            if (_subject.Equals(unexpected))
            {
                var reason = FormatReason(because, becauseArgs);
                throw new AssertionException($"Did not expect enum to be {unexpected}{reason}, but it was.");
            }

            return this;
        }

        /// <summary>
        /// Asserts that the current enum value is defined inside the enum type.
        /// </summary>
        public EnumAssertions<TEnum> BeDefined(string because = "", params object[] becauseArgs)
        {
            if (_subject is null || !Enum.IsDefined(typeof(TEnum), _subject))
            {
                var reason = FormatReason(because, becauseArgs);
                throw new AssertionException($"Expected enum to be defined in {typeof(TEnum)}{reason}, but found {_subject}.");
            }

            return this;
        }

        /// <summary>
        /// Asserts that the current enum value is not defined inside the enum type.
        /// </summary>
        public EnumAssertions<TEnum> NotBeDefined(string because = "", params object[] becauseArgs)
        {
            if (_subject is not null && Enum.IsDefined(typeof(TEnum), _subject))
            {
                var reason = FormatReason(because, becauseArgs);
                throw new AssertionException($"Did not expect enum to be defined in {typeof(TEnum)}{reason}, but it was.");
            }

            return this;
        }

        /// <summary>
        /// Asserts that the enum value is one of the valid values.
        /// </summary>
        public EnumAssertions<TEnum> BeOneOf(IEnumerable<TEnum> validValues, string because = "", params object[] becauseArgs)
        {
            if (validValues is null || !validValues.Contains(_subject.GetValueOrDefault()))
            {
                var reason = FormatReason(because, becauseArgs);
                throw new AssertionException($"Expected enum to be one of {string.Join(", ", validValues)}{reason}, but found {_subject}.");
            }

            return this;
        }

        /// <summary>
        /// Asserts that the enum has the specified flag.
        /// </summary>
        public EnumAssertions<TEnum> HaveFlag(TEnum expectedFlag, string because = "", params object[] becauseArgs)
        {
            if (_subject is null || !_subject.Value.HasFlag(expectedFlag))
            {
                var reason = FormatReason(because, becauseArgs);
                throw new AssertionException($"Expected enum to have flag {expectedFlag}{reason}, but found {_subject}.");
            }

            return this;
        }

        /// <summary>
        /// Asserts that the enum does not have the specified flag.
        /// </summary>
        public EnumAssertions<TEnum> NotHaveFlag(TEnum unexpectedFlag, string because = "", params object[] becauseArgs)
        {
            if (_subject is not null && _subject.Value.HasFlag(unexpectedFlag))
            {
                var reason = FormatReason(because, becauseArgs);
                throw new AssertionException($"Did not expect enum to have flag {unexpectedFlag}{reason}, but it did.");
            }

            return this;
        }

        /// <summary>
        /// Asserts that the enum value matches a given predicate.
        /// </summary>
        public EnumAssertions<TEnum> Match(Expression<Func<TEnum?, bool>> predicate, string because = "", params object[] becauseArgs)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate), "Predicate cannot be null.");

            if (!predicate.Compile()(_subject))
            {
                var reason = FormatReason(because, becauseArgs);
                throw new AssertionException($"Expected enum to match the given condition{reason}, but it did not.");
            }

            return this;
        }

        /// <summary>
        /// Asserts that the enum value has the same numeric value as the expected value.
        /// </summary>
        public EnumAssertions<TEnum> HaveValue(decimal expected, string because = "", params object[] becauseArgs)
        {
            if (_subject is null || GetValue(_subject.Value) != expected)
            {
                var reason = FormatReason(because, becauseArgs);
                throw new AssertionException($"Expected enum to have value {expected}{reason}, but found {_subject}.");
            }

            return this;
        }

        /// <summary>
        /// Asserts that the enum value does not have the same numeric value as the unexpected value.
        /// </summary>
        public EnumAssertions<TEnum> NotHaveValue(decimal unexpected, string because = "", params object[] becauseArgs)
        {
            if (_subject is not null && GetValue(_subject.Value) == unexpected)
            {
                var reason = FormatReason(because, becauseArgs);
                throw new AssertionException($"Expected enum to not have value {unexpected}{reason}, but it did.");
            }

            return this;
        }

        /// <summary>
        /// Gets the numeric value of an enum.
        /// </summary>
        private static decimal GetValue(TEnum @enum)
        {
            return Convert.ToDecimal(@enum, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Formats the reason string.
        /// </summary>
        private static string FormatReason(string because, object[] becauseArgs)
        {
            if (string.IsNullOrEmpty(because))
                return string.Empty;

            return " " + string.Format(because, becauseArgs);
        }
    }
}
