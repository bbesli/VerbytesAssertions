using System;

namespace VerbytesAssertions.Executor
{
    /// <summary>
    /// A utility class to execute assertion logic and handle error messages.
    /// </summary>
    public static class AssertionExecutor
    {
        private static bool _conditionMet;
        private static string _errorMessage = default!;

        /// <summary>
        /// Starts an assertion execution with the specified condition.
        /// </summary>
        /// <param name="condition">The condition that must be met.</param>
        /// <returns>The current instance of <see cref="AssertionExecutor"/>.</returns>
        public static AssertionExecutorCondition<T> Execute<T>(bool condition, T parent)
        {
            _conditionMet = condition;
            return new AssertionExecutorCondition<T>(condition, parent);
        }

        /// <summary>
        /// Represents a chainable stage where an error message can be added.
        /// </summary>
        public class AssertionExecutorCondition<T>
        {
            private readonly bool _condition;
            private readonly T _parent;

            public AssertionExecutorCondition(bool condition, T parent)
            {
                _condition = condition;
                _parent = parent;
            }

            /// <summary>
            /// Adds an error message to be used if the assertion fails.
            /// </summary>
            /// <param name="message">The error message format.</param>
            /// <param name="args">Arguments to format into the message.</param>
            /// <returns>The next chainable stage.</returns>
            public AssertionExecutorResult<T> WithErrorMessage(string message, params object[] args)
            {
                if (!_condition)
                {
                    _errorMessage = string.Format(message, args);
                }

                return new AssertionExecutorResult<T>(_condition, _parent);
            }
        }

        /// <summary>
        /// Represents the final stage of the assertion, which determines the result.
        /// </summary>
        public class AssertionExecutorResult<T>
        {
            private readonly bool _condition;
            private readonly T _parent;

            public AssertionExecutorResult(bool condition, T parent)
            {
                _condition = condition;
                _parent = parent;
            }

            /// <summary>
            /// Finalizes the assertion execution and throws an exception if the assertion fails.
            /// </summary>
            /// <returns>The parent assertion class for chaining.</returns>
            public T GetResult()
            {
                if (!_condition)
                {
                    throw new AssertionException(_errorMessage);
                }

                return _parent;
            }
        }
    }
}

