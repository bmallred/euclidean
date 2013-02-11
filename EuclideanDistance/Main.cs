using System;
using System.Collections.Generic;
using System.Linq;

namespace EuclideanDistance
{
	/// <summary>
	/// Main class.
	/// </summary>
	public class MainClass
	{
		/// <summary>
		/// The entry point of the program, where the program control starts and ends.
		/// </summary>
		/// <param name='args'>
		/// The command-line arguments.
		/// </param>
		public static void Main(string[] args)
		{
			// Accumalate the intial data points needed before computation.
			var points = InitialDataPoints();

			// Retrieve the focal point to determine our distances.
			var input = FocalPoint(points);

			// Store all the distances.
			var distances = points.Select(x => input.EuclideanDistance(x)).ToList();

			// Display both the closest and furthest data points from the focal point.
			Console.WriteLine();
			Console.WriteLine("Minimum distance: {0}", points.ElementAt(distances.IndexOf(distances.Min())).ToPoint());
			Console.WriteLine("Maximum distance: {0}", points.ElementAt(distances.IndexOf(distances.Max())).ToPoint());
		}

		/// <summary>
		/// Initials the data points.
		/// </summary>
		/// <returns>
		/// The data points.
		/// </returns>
		private static IEnumerable<IEnumerable<double>> InitialDataPoints()
		{
			var points = new List<IEnumerable<double>>();
			Console.WriteLine("Please enter the initial points");

			while (true)
			{
				Console.Write("Point [blank to stop]: ");
				var p = Console.ReadLine().ToPoint();

				if (p == null)
				{
					if (points.Count() > 0)
					{
						break;
					}
					else
					{
						Console.WriteLine("No points have been entered.");
					}
				}
				else if (points.Count() > 0 && p.Count() != points.First().Count())
				{
					Console.WriteLine("Dimensions do not match.");
				}
				else
				{
					points.Add(p);
				}
			}

			return points;
		}

		/// <summary>
		/// Focals the point.
		/// </summary>
		/// <returns>
		/// The point.
		/// </returns>
		/// <param name='points'>
		/// Points.
		/// </param>
		private static IEnumerable<double> FocalPoint(IEnumerable<IEnumerable<double>> points)
		{
			Console.WriteLine();
			Console.WriteLine("Please enter a focal point");

			while (true)
			{
				Console.Write("Point: ");
				var p = Console.ReadLine().ToPoint();

				if (p == null)
				{
					Console.WriteLine("Invalid input. Please try again.");
				}
				else if (p.Count() != points.First().Count())
				{
					Console.WriteLine("Dimensions do not match.");
				}
				else
				{
					return p;
				}
			}
		}
	}
}