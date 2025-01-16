using MongoDB.Bson;
using VerbytesAssertions.Others;
using VerbytesAssertions.Primitives;

namespace VerbytesAssertions.Extensions
{
    /// <summary>
    /// Provides extension methods to enable fluent assertion syntax using the `.Should()` method.
    /// </summary>
    public static class AssertionExtensions
    {
        /// <summary>
        /// Returns an instance of <see cref="BooleanAssertions"/> to assert a <see cref="bool"/> value.
        /// </summary>
        /// <param name="subject">The boolean value to assert.</param>
        /// <returns>An instance of <see cref="BooleanAssertions"/>.</returns>
        public static BooleanAssertions Should(this bool subject)
        {
            return new BooleanAssertions(subject);
        }

        /// <summary>
        /// Returns an instance of <see cref="BooleanAssertions"/> to assert a nullable <see cref="bool"/> value.
        /// </summary>
        /// <param name="subject">The nullable boolean value to assert.</param>
        /// <returns>An instance of <see cref="BooleanAssertions"/>.</returns>
        public static BooleanAssertions Should(this bool? subject)
        {
            return new BooleanAssertions(subject);
        }

        /// <summary>
        /// Returns an instance of <see cref="EnumAssertions{TEnum}"/> to assert an enumeration value.
        /// </summary>
        /// <typeparam name="TEnum">The enumeration type.</typeparam>
        /// <param name="subject">The enumeration value to assert.</param>
        /// <returns>An instance of <see cref="EnumAssertions{TEnum}"/>.</returns>
        public static EnumAssertions<TEnum> Should<TEnum>(this TEnum subject)
            where TEnum : struct, Enum
        {
            return new EnumAssertions<TEnum>(subject);
        }

        /// <summary>
        /// Returns an instance of <see cref="GenericCollectionAssertions{T}"/> to assert a collection.
        /// </summary>
        /// <typeparam name="T">The type of items in the collection.</typeparam>
        /// <param name="subject">The collection to assert.</param>
        /// <returns>An instance of <see cref="GenericCollectionAssertions{T}"/>.</returns>
        public static GenericCollectionAssertions<T> Should<T>(this IEnumerable<T> subject)
        {
            return new GenericCollectionAssertions<T>(subject);
        }

        /// <summary>
        /// Returns an instance of <see cref="GuidAssertions"/> to assert a <see cref="Guid"/> value.
        /// </summary>
        /// <param name="subject">The GUID value to assert.</param>
        /// <returns>An instance of <see cref="GuidAssertions"/>.</returns>
        public static GuidAssertions Should(this Guid subject)
        {
            return new GuidAssertions(subject);
        }

        /// <summary>
        /// Returns an instance of <see cref="ObjectAssertions"/> to assert an object.
        /// </summary>
        /// <param name="subject">The object to assert.</param>
        /// <returns>An instance of <see cref="ObjectAssertions"/>.</returns>
        public static ObjectAssertions Should(this object subject)
        {
            return new ObjectAssertions(subject);
        }

        /// <summary>
        /// Returns an instance of <see cref="ObjectIdAssertions"/> to assert an <see cref="ObjectId"/> value.
        /// </summary>
        /// <param name="subject">The ObjectId value to assert.</param>
        /// <returns>An instance of <see cref="ObjectIdAssertions"/>.</returns>
        public static ObjectIdAssertions Should(this ObjectId subject)
        {
            return new ObjectIdAssertions(subject);
        }

        /// <summary>
        /// Returns an instance of <see cref="StringAssertions"/> to assert a <see cref="string"/> value.
        /// </summary>
        /// <param name="subject">The string value to assert.</param>
        /// <returns>An instance of <see cref="StringAssertions"/>.</returns>
        public static StringAssertions Should(this string subject)
        {
            return new StringAssertions(subject);
        }

        /// <summary>
        /// Returns an instance of <see cref="DateTimeAssertions"/> to assert a <see cref="DateTime"/> value.
        /// </summary>
        /// <param name="subject">The DateTime value to assert.</param>
        /// <returns>An instance of <see cref="DateTimeAssertions"/>.</returns>
        public static DateTimeAssertions Should(this DateTime subject)
        {
            return new DateTimeAssertions(subject);
        }

        /// <summary>
        /// Returns an instance of <see cref="NullableAssertions{T}"/> to assert a nullable value.
        /// </summary>
        /// <typeparam name="T">The type of the nullable value.</typeparam>
        /// <param name="subject">The nullable value to assert.</param>
        /// <returns>An instance of <see cref="NullableAssertions{T}"/>.</returns>
        public static NullableAssertions<T> Should<T>(this T? subject) where T : struct
        {
            return new NullableAssertions<T>(subject);
        }

        /// <summary>
        /// Returns an instance of <see cref="DateOnlyAssertions"/> to assert a <see cref="DateOnly"/> value.
        /// </summary>
        /// <param name="subject">The DateOnly value to assert.</param>
        /// <returns>An instance of <see cref="DateOnlyAssertions"/>.</returns>
        public static DateOnlyAssertions Should(this DateOnly subject)
        {
            return new DateOnlyAssertions(subject);
        }
    }
}
