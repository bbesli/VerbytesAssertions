using VerbytesAssertions.Executor;

namespace VerbytesAssertions.Primitives
{
    /// <summary>
    /// Contains assertion methods for validating boolean values.
    /// </summary>
    public class BooleanAssertions
    {
        private readonly bool? _subject;
        public BooleanAssertions(bool? value)
        {
            _subject = value;
        }

        public BooleanAssertions Be(bool expected, string because = "", params object[] becauseArgs) => AssertionExecutor.Execute(_subject == expected, this)
                .WithErrorMessage("Expected boolean to be {0}{1}, but found {2}.", expected, FormatBecause(because, becauseArgs), _subject)
                .GetResult();

        public BooleanAssertions BeTrue(string because = "", params object[] becauseArgs) => AssertionExecutor.Execute(_subject == true, this)
                .WithErrorMessage("Expected boolean to be true{0}, but found {1}.", FormatBecause(because, becauseArgs), _subject)
                .GetResult();

        public BooleanAssertions BeFalse(string because = "", params object[] becauseArgs) => AssertionExecutor.Execute(_subject == false, this)
                .WithErrorMessage("Expected boolean to be false{0}, but found {1}.", FormatBecause(because, becauseArgs), _subject)
                .GetResult();

        public BooleanAssertions NotBe(bool unexpected, string because = "", params object[] becauseArgs) => AssertionExecutor.Execute(_subject != unexpected, this)
                .WithErrorMessage("Did not expect boolean to be {0}{1}, but it was.", unexpected, FormatBecause(because, becauseArgs))
                .GetResult();

        public BooleanAssertions Imply(bool consequent, string because = "", params object[] becauseArgs) => AssertionExecutor.Execute(!(_subject == true && !consequent), this)
                .WithErrorMessage("Expected {0} to imply {1}{2}, but it did not.", _subject, consequent, FormatBecause(because, becauseArgs))
                .GetResult();

        private static string FormatBecause(string because, params object[] args) => string.IsNullOrEmpty(because) ? string.Empty : " " + string.Format(because, args);

    }
}
