using System;
using System.Collections.Generic;

namespace OpenNPC_CSharp_ver
{
	public class SeekBehaviour : IBehaviour
	{
		public (int x, int y) Goal { get; private set; }
		private Queue<(int x, int y)> path;
		public Queue<(int, int)> PathQueue => new Queue<(int, int)>(path);

		public SeekBehaviour()
		{
			Goal = (-1, -1);
			path = new Queue<(int, int)>();
		}

		public SeekBehaviour((int x, int y) goal)
		{
			Goal = goal;
			path = new Queue<(int, int)>();
		}

		public void Tick(NPC npc)
		{
			if (path.Count == 0)
			{
				var newPath = Pathfinding.AStar(npc.World, (npc.X, npc.Y), Goal);
				if (newPath != null && newPath.Count > 0)
				{
					path = new Queue<(int, int)>(newPath);
					// Remove current position if it matches first
					if (path.Peek() == (npc.X, npc.Y))
						path.Dequeue();
				}
				else
				{
					Console.WriteLine($"{npc.Name} cannot find a path to {Goal}.");
					return;
				}
			}

			if (path.Count > 0)
			{
				var next = path.Peek();
				int dx = next.x - npc.X;
				int dy = next.y - npc.Y;
				bool moved = npc.Move(dx, dy);

				if (moved)
				{
					path.Dequeue();
				}
				else
				{
					Console.WriteLine($"{npc.Name} blocked. Recalculating path...");
					path.Clear();
				}
			}
		}

		public void SetCustomPath(List<(int x, int y)> customPath)
		{
			if (customPath != null && customPath.Count > 0)
			{
				Goal = customPath[^1];
				path = new Queue<(int, int)>(customPath);
				Console.WriteLine($"Custom path set. Goal is now {Goal}");
			}
		}
	}
}
