using System;
using System.Collections.Generic;
using System.Linq;

namespace EuclideanDistance
{
	/// <summary>
	/// Double extensions.
	/// </summary>
	public static class DoubleExtensions
	{
		/// <summary>
		/// Euclideans the distance.
		/// </summary>
		/// <returns>
		/// The distance.
		/// </returns>
		/// <param name='pointA'>
		/// Point a.
		/// </param>
		/// <param name='pointB'>
		/// Point b.
		/// </param>
		public static double EuclideanDistance(this IEnumerable<double> pointA, IEnumerable<double> pointB)
		{
			// Make sure the dimensions are the same.
			if (pointA.Count() != pointB.Count())
			{
				throw new ArgumentOutOfRangeException("Dimensions do not match");
			}

			// Iterate through each point and create the vector.
			var vectors = new List<double>();
			for (int i = 0; i < pointA.Count(); i++)
			{
				vectors.Add(Math.Pow((pointA.ElementAt(i) - pointB.ElementAt(i)), 2));
			}

			// Return the sqare root of the sum of vectors.
			return Math.Sqrt(vectors.Sum());
		}

		/// <summary>
		/// Tos the point.
		/// </summary>
		/// <returns>
		/// The point.
		/// </returns>
		/// <param name='point'>
		/// Point.
		/// </param>
		public static string ToPoint<T>(this IEnumerable<T> point)
		{
			return string.Format("({0})", string.Join(",", point));
		}
	}
}