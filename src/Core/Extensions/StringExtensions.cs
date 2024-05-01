// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="StringExtensions.cs" company="Bugail Consulting Ltd">
//      Copyright 2024 (c) Bugail Consulting Ltd. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace Kensington.Core.Extensions
{
    /// <summary>
    /// The string extensions.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Checks if a string has a numerical value.
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <returns>True if string is a number, False if not</returns>
        public static bool IsNumeric(this string value)
        {
            return int.TryParse(value, out _);
        }
    }
}