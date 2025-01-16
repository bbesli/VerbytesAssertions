using Xunit.Sdk;

namespace VerbytesAssertions.Primitives
{
    public class ExceptionAssertions
    {
        public static void Throw<TException>(Action action) where TException : Exception
        {
            try
            {
                action();
            }
            catch (TException)
            {
                return;
            }
            catch (Exception ex)
            {
                throw new XunitException(
                    $"Expected exception of type {typeof(TException).Name} but got {ex.GetType().Name}.");
            }

            throw new XunitException(
                $"Expected exception of type {typeof(TException).Name} but no exception was thrown.");
        }
    }

}
