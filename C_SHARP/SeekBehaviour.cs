using OpenNPC_CSharp_ver;
using System;

namespace OpenNPC_CSharp_ver
{
	public class SeekBehaviour : IBehaviour
	{
		public Queue<(int, int)> Path { get; set; } = new Queue<(int, int)>();
		public Queue<(int, int)> PathQueue => new Queue<(int, int)>(Path);
		public (int x, int y) Goal { get; private set; }
		private Queue<(int x, int y)> path;

		public SeekBehaviour((int, int) goal)
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
					path.Clear();
				}
			}
		}

		public void SetCustomPath(List<(int, int)> path)
		{
			if (path != null && path.Count > 0)
			{
				Goal = path[^1];
				Path.Clear();
				foreach (var point in path)
				{
					Path.Enqueue(point);
				}
				Console.WriteLine($"Custom path set. Goal is now {Goal}");
			}
		}
	}
}