using OpenNPC_CSharp_ver;
using System;
using System.Collections.Generic;

namespace OpenNPC_CSharp_ver
{
	public class GridWorld
	{
		public int Width { get; }
		public int Height { get; }
		public HashSet<(int, int)> Obstacles { get; }
		public List<NPC> NPCs { get; }

		public GridWorld(int width = 25, int height = 25)
		{
			Width = width;
			Height = height;
			Obstacles = new HashSet<(int, int)>();
			NPCs = new List<NPC>();
		}

		public void AddNPC(NPC npc)
		{
			npc.World = this;
			NPCs.Add(npc);
		}

		public bool IsWithinBounds(int x, int y)
		{
			return x >= 0 && x < Width && y >= 0 && y < Height;
		}

		public bool IsObstacle(int x, int y)
		{
			return Obstacles.Contains((x, y));
		}

		public bool IsWalkable(int x, int y)
		{
			return IsWithinBounds(x, y) && !IsObstacle(x, y);
		}

		public void GenerateObstacles(int count)
		{
			var rnd = new Random();
			int attempts = 0;
            while (Obstacles.Count < count && attempts < count * 10)
            {
				int x = rnd.Next(0, Width);
				int y = rnd.Next(0, Height);

				if (!Obstacles.Contains((x, y)) && NPCs.TrueForAll(npc => npc.X != x || npc.Y != y))
				{
					AddObstacle(x, y);
				}
				++attempts;
            }
        }

		public void AddObstacle(int x, int y)
		{
			if (IsWithinBounds(x, y))
			{
				Obstacles.Add((x, y));
			}
		}

		public void Render()
		{
			for (int y = 0; y < Height; y++)
			{
				for (int x = 0; x < Width; x++)
				{
					bool hasNpc = false;
					foreach (var npc in NPCs)
					{
						if (npc.X == x && npc.Y == y)
						{
							Console.Write(npc.Name[0]);
							hasNpc = true;
							break;
						}
					}
					if (!hasNpc)
					{
						Console.Write(IsObstacle(x, y) ? "#" : ".");
					}
				}
				Console.WriteLine();
			}
		}

		public void Update()
		{
			foreach (var npc in NPCs)
			{
				npc.Update();
			}
		}

	}
}