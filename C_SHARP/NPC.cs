using OpenNPC_CSharp_ver;
using System;

namespace OpenNPC_CSharp_ver
{
	public class NPC
	{
		public int Id { get; }
		public string Name { get; }
		public int X { get; set; }
		public int Y { get; set; }
		public GridWorld World { get; set; }
		public IBehaviour Behaviour { get; set; }

		public NPC(int id, string name, int x, int y)
		{
			Id = id;
			Name = name;
			X = x;
			Y = y;
		}

		public void SetBehaviour(IBehaviour behaviour)
		{
			Behaviour = behaviour;
		}

		public bool Move(int dx, int dy)
		{
			int newX = X + dx;
			int newY = Y + dy;

			if (World.IsWalkable(newX, newY))
			{
				X = newX;
				Y = newY;
				Console.WriteLine($"{Name} moved to ({X}, {Y})");
				return true;
			}
			else
			{
				Console.WriteLine($"{Name} cannot move to ({newX}, {newY}) — blocked or out of bounds.");
				return false;
			}
		}

		public void Update()
		{
			Behaviour?.Tick(this);
		}
	}
}