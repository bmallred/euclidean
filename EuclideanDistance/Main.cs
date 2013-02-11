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
			var points = new List<IEnumerable<double>>();
			IEnumerable<double> input;

			// Accumalate the intial data points needed before computation.
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

			// Retrieve the focal point to determine our distances.
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
					input = p;
					break;
				}
			}

			// Store all the distances.
			var distances = new List<double>();
			foreach (var p in points)
			{
				distances.Add(input.EuclideanDistance(p));
			}

			// Display both the closest and furthest data points from the focal point.
			Console.WriteLine();
			Console.WriteLine("Minimum distance: {0}", points[distances.IndexOf(distances.Min())].ToPoint());
			Console.WriteLine("Maximum distance: {0}", points[distances.IndexOf(distances.Max())].ToPoint());
		}
	}
}