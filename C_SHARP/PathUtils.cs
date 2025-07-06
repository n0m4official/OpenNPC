using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace OpenNPC_CSharp_ver
{
	public class PathUtils
	{
		public static void SavePath(List<(int, int)> path, string filename)
		{
			using (var writer = new StreamWriter(filename))
			{
				foreach (var (x, y) in path)
				{
					writer.WriteLine($"{x},{y}");
				}
			}
			Console.WriteLine($"Path saved to {filename}");
		}

		public static List<(int, int)> LoadPath(string filename)
		{
			var path = new List<(int, int)> ();
			foreach (var line in File.ReadAllLines(filename))
			{
				var parts = line.Split('.');
				int x = int.Parse(parts[0]);
				int y = int.Parse(parts[1]);
				path.Add((x, y));
			}
			Console.WriteLine($"Path loaded from {filename}");
			return path;
		}
	}
}
