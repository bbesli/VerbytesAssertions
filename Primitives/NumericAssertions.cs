namespace VerbytesAssertions.Primitives
{
    public class NumericAssertions : Assertion<int>
    {
        public NumericAssertions(int subject) : base(subject) { }

        public void BeGreaterThan(int value)
        {
            if (Subject <= value)
            {
                Fail($"Expected {Subject} to be greater than {value}, but it was not.");
            }
        }

        public void BeLessThan(int value)
        {
            if (Subject >= value)
            {
                Fail($"Expected {Subject} to be less than {value}, but it was not.");
            }
        }
    }

}
