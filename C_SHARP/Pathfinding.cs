using OpenNPC_CSharp_ver;
using System;
using System.Collections.Generic;
using System.Linq;

public static class Pathfinding
{
	public static int Heuristic((int x, int y) a, (int x, int y) b)
	{
		return Math.Abs(a.x - b.x) + Math.Abs(a.y - b.y);
	}

	public static List<(int x, int y)> AStar(GridWorld world, (int x, int y) start, (int x, int y) goal)
	{
		var openSet = new List<(int x, int y)> { start };
		var cameFrom = new Dictionary<(int, int), (int, int)>();
		var gScore = new Dictionary<(int, int), int> { [start] = 0 };
		var fScore = new Dictionary<(int, int), int> { [start] = Heuristic(start, goal) };

		while (openSet.Count > 0)
		{
			var current = openSet.OrderBy(n => fScore.ContainsKey(n) ? fScore[n] : int.MaxValue).First();
			
			if (current == goal)
				return ReconstructPath(cameFrom, current);

			openSet.Remove(current);

			foreach (var neighbor in GetNeighbors(world, current))
			{
				int tentativeG = gScore[current] + 1;

				if (!gScore.ContainsKey(neighbor) || tentativeG < gScore[neighbor])
				{
					cameFrom[neighbor] = current;
					gScore[neighbor] = tentativeG;
					fScore[neighbor] = tentativeG + Heuristic(neighbor, goal);

					if (!openSet.Contains(neighbor))
						openSet.Add(neighbor);
				}
			}
		}
		return null;
	}

	private static List<(int x, int y)> GetNeighbors(GridWorld world, (int x, int y) node)
	{
		var dirs = new (int dx, int dy)[] { (1, 0), (-1, 0), (0, 1), (0, -1) };
		var neighbors = new List<(int x, int y)>();

		foreach (var (dx, dy) in dirs)
		{
			int nx = node.x + dx;
			int ny = node.y + dy;
			if (world.IsWalkable(nx, ny))
				neighbors.Add((nx, ny));
		}
		return neighbors;
	}

	private static List<(int x, int y)> ReconstructPath(Dictionary<(int, int), (int, int)> cameFrom, (int x, int y) current)
	{
		var totalPath = new List<(int, int)> { current };
		while (cameFrom.ContainsKey(current))
		{
			current = cameFrom[current];
			totalPath.Insert(0, current);
		}
		return totalPath;
	}
}