using System;
using System.Collections.Generic;
using System.Linq;

namespace EuclideanDistance
{
	/// <summary>
	/// String extensions.
	/// </summary>
	public static class StringExtensions
	{
		/// <summary>
		/// Tos the point.
		/// </summary>
		/// <returns>
		/// The point.
		/// </returns>
		/// <param name='input'>
		/// Input.
		/// </param>
		public static IEnumerable<double> ToPoint(this string input)
		{
			return string.IsNullOrWhiteSpace(input)
				? null
				: input.Split(new char[] { ',' }).Select(Double.Parse);
		}
	}
}