using VerbytesAssertions.Primitives;

namespace VerbytesAssertions.Extensions
{
    public static class EnumAssertionExtensions
    {
        public static EnumAssertions<TEnum> Should<TEnum>(this TEnum subject)
            where TEnum : struct, Enum
        {
            return new EnumAssertions<TEnum>(subject);
        }
    }
}
