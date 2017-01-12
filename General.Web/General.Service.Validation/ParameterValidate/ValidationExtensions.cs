using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace General.Service.Validation.ParameterValidate
{
    public static class ValidationExtensions
    {
        /// <summary>
        /// Check argument value.
        /// </summary>
        /// <param name="validation"></param>
        /// <param name="filterMethod"></param>
        /// <returns></returns>
        public static Validation Check(this Validation validation, Func<bool> filterMethod)
        {
            return Check<Exception>(validation, filterMethod, new Exception("Parameter InValid!"));
        }

        private static Validation Check<T>(this Validation validation, Func<bool> filterMethod, T exception)
            where T : Exception
        {
            if (filterMethod())
            {
                if (validation != null) { validation.IsValid = true; }
                return validation ?? new Validation() { IsValid = true };
            }
            else
            {
                throw exception;
            }
        }

        /// <summary>
        /// Argument should not be null.
        /// </summary>
        /// <param name="validation"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Validation NotNull(this Validation validation, Object obj)
        {
            return Check<ArgumentNullException>(
                validation,
                () => obj != null,
                new ArgumentNullException($"Parameter {obj} can't be null"));
        }

        /// <summary>
        /// Argument should be in range.
        /// </summary>
        /// <param name="validation"></param>
        /// <param name="value"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static Validation InRange(this Validation validation, double value, double min, double max)
        {
            return Check<ArgumentOutOfRangeException>(
                validation,
                () =>
                {
                    if (value >= min && value <= max)
                        return true;
                    else
                        return false;
                },
                new ArgumentOutOfRangeException($"Parameter should be between {min} and {max}"));
        }

        /// <summary>
        /// Argument should match pattern.
        /// </summary>
        /// <param name="validation"></param>
        /// <param name="input"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static Validation RegexMatch(this Validation validation, string input, string pattern)
        {
            return Check<ArgumentException>(
                validation,
                () => Regex.IsMatch(input, pattern),
                new ArgumentException($"Parameter should match format {pattern}"));
        }

        /// <summary>
        /// Email should match the pattern.
        /// </summary>
        /// <param name="validation"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public static Validation IsEmail(this Validation validation, string email)
        {
            return RegexMatch(validation, email, @"^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$");
        }
    }
}
