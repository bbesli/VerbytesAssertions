using System.Globalization;
using System.Linq.Expressions;
using VerbytesAssertions.Executor;

namespace VerbytesAssertions.Primitives
{
    /// <summary>
    /// Contains assertion methods for validating enums.
    /// </summary>
    /// <typeparam name="TEnum">The enum type being asserted.</typeparam>
    public class EnumAssertions<TEnum>
        where TEnum : struct, Enum
    {
        private readonly TEnum? _subject;

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumAssertions{TEnum}"/> class.
        /// </summary>
        /// <param name="subject">The enum value to perform assertions on.</param>
        public EnumAssertions(TEnum subject) : this((TEnum?)subject) { }

        private EnumAssertions(TEnum? subject)
        {
            _subject = subject;
        }

        /// <summary>
        /// Asserts that the current enum is exactly equal to the expected value.
        /// </summary>
        public void Be(TEnum expected, string because = "", params object[] becauseArgs) =>
            AssertionExecutor.Execute(_subject.Equals(expected), this)
                .WithErrorMessage("Expected enum to be {0}{1}, but found {2}.", expected, FormatReason(because, becauseArgs), _subject)
                .GetResult();

        /// <summary>
        /// Asserts that the current enum is not equal to the unexpected value.
        /// </summary>
        public void NotBe(TEnum unexpected, string because = "", params object[] becauseArgs) =>
            AssertionExecutor.Execute(!_subject.Equals(unexpected), this)
                .WithErrorMessage("Did not expect enum to be {0}{1}, but it was.", unexpected, FormatReason(because, becauseArgs))
                .GetResult();

        /// <summary>
        /// Asserts that the current enum value is defined inside the enum type.
        /// </summary>
        public void BeDefined(string because = "", params object[] becauseArgs) =>
            AssertionExecutor.Execute(_subject is not null && Enum.IsDefined(typeof(TEnum), _subject), this)
                .WithErrorMessage("Expected enum to be defined in {0}{1}, but found {2}.", typeof(TEnum), FormatReason(because, becauseArgs), _subject)
                .GetResult();

        /// <summary>
        /// Asserts that the current enum value is not defined inside the enum type.
        /// </summary>
        public void NotBeDefined(string because = "", params object[] becauseArgs) =>
            AssertionExecutor.Execute(_subject is null || !Enum.IsDefined(typeof(TEnum), _subject), this)
                .WithErrorMessage("Did not expect enum to be defined in {0}{1}, but it was.", typeof(TEnum), FormatReason(because, becauseArgs))
                .GetResult();

        /// <summary>
        /// Asserts that the enum value is one of the valid values.
        /// </summary>
        public void BeOneOf(IEnumerable<TEnum> validValues, string because = "", params object[] becauseArgs) =>
            AssertionExecutor.Execute(validValues is not null && validValues.Contains(_subject.GetValueOrDefault()), this)
                .WithErrorMessage("Expected enum to be one of {0}{1}, but found {2}.", string.Join(", ", validValues), FormatReason(because, becauseArgs), _subject)
                .GetResult();

        /// <summary>
        /// Asserts that the enum has the specified flag.
        /// </summary>
        public void HaveFlag(TEnum expectedFlag, string because = "", params object[] becauseArgs) =>
            AssertionExecutor.Execute(_subject is not null && _subject.Value.HasFlag(expectedFlag), this)
                .WithErrorMessage("Expected enum to have flag {0}{1}, but found {2}.", expectedFlag, FormatReason(because, becauseArgs), _subject)
                .GetResult();

        /// <summary>
        /// Asserts that the enum does not have the specified flag.
        /// </summary>
        public void NotHaveFlag(TEnum unexpectedFlag, string because = "", params object[] becauseArgs) =>
            AssertionExecutor.Execute(_subject is null || !_subject.Value.HasFlag(unexpectedFlag), this)
                .WithErrorMessage("Did not expect enum to have flag {0}{1}, but it did.", unexpectedFlag, FormatReason(because, becauseArgs))
                .GetResult();

        /// <summary>
        /// Asserts that the enum value matches a given predicate.
        /// </summary>
        public void Match(Expression<Func<TEnum?, bool>> predicate, string because = "", params object[] becauseArgs)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate), "Predicate cannot be null.");

            AssertionExecutor.Execute(predicate.Compile()(_subject), this)
                .WithErrorMessage("Expected enum to match the given condition{0}, but it did not.", FormatReason(because, becauseArgs))
                .GetResult();
        }

        /// <summary>
        /// Asserts that the enum value has the same numeric value as the expected value.
        /// </summary>
        public void HaveValue(decimal expected, string because = "", params object[] becauseArgs) =>
            AssertionExecutor.Execute(_subject is not null && GetValue(_subject.Value) == expected, this)
                .WithErrorMessage("Expected enum to have value {0}{1}, but found {2}.", expected, FormatReason(because, becauseArgs), _subject)
                .GetResult();

        /// <summary>
        /// Asserts that the enum value does not have the same numeric value as the unexpected value.
        /// </summary>
        public void NotHaveValue(decimal unexpected, string because = "", params object[] becauseArgs) =>
            AssertionExecutor.Execute(_subject is null || GetValue(_subject.Value) != unexpected, this)
                .WithErrorMessage("Expected enum to not have value {0}{1}, but it did.", unexpected, FormatReason(because, becauseArgs))
                .GetResult();

        /// <summary>
        /// Gets the numeric value of an enum.
        /// </summary>
        private static decimal GetValue(TEnum @enum) =>
            Convert.ToDecimal(@enum, CultureInfo.InvariantCulture);

        /// <summary>
        /// Formats the reason string.
        /// </summary>
        private static string FormatReason(string because, object[] becauseArgs) =>
            string.IsNullOrEmpty(because) ? string.Empty : " " + string.Format(because, becauseArgs);
    }
}
