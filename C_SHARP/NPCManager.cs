using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OpenNPC_CSharp_ver
{
	internal class NPCManager
	{
		public GridWorld World { get; private set; }
		private readonly List<NPC> _npcs;

		public NPCManager(int width, int height) 
		{ 
			World = new GridWorld(width, height);
			_npcs = new List<NPC>();
		}

		public void AddNPC(NPC npc)
		{
			npc.World = World;
			_npcs.Add(npc);
			World.AddNPC(npc);
		}

		public void SetSeekBehaviour(NPC npc, int goalX,  int goalY)
		{
			var behaviour = new SeekBehaviour((goalX,  goalY));
			npc.SetBehaviour(behaviour);
		}

		public void SetCustomPath(NPC npc, List<(int x, int y)> path)
		{
			var behaviour = new SeekBehaviour();
			behaviour.SetCustomPath(path);
			npc.SetBehaviour(behaviour);
		}

		public void GenerateObstacles(int count)
		{
			World.GenerateObstacles(count);
		}
		
		public void UpdateAll()
		{
			World.Update();
		}

		public void Render()
		{
			World.Render();
		}

		public List<NPC> GetAllNPCs()
		{
			return new List<NPC>(_npcs);
		}

		public void ClearNPCs()
		{
			_npcs.Clear();
			World.NPCs.Clear();
		}
	}
}
