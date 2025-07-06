using OpenNPC_CSharp_ver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.IO;

namespace OpenNPC_CSharp_ver
{
	class Program
	{
		static void Main()
		{
			while (true)
			{
				Console.Clear();
				Console.WriteLine("=== OpenNPC Menu ===");
				Console.WriteLine("1. Load path from file");
				Console.WriteLine("2. Start random paths");
				Console.WriteLine("3. Create custom path (record)");
				Console.WriteLine("4. Quit");
				Console.Write("Enter choice: ");

				string choice = Console.ReadLine();
				if (choice == "1")
				{
					LoadPathScenario();
				}
				else if (choice == "2")
				{
					StartRandomScenario();
				}
				else if (choice == "3") 
				{
					RecordPathScenario();
				}
				else if (choice == "4")
				{
					Console.WriteLine("Goodbye!");
					break;
				}
				else
				{
					Console.WriteLine("Invalid choice. Press any keu to continue...");
					Console.ReadKey();
				}
            }
		}

		static void RunSimulation(GridWorld world, List<NPC> npcs)
		{
			Console.WriteLine("Simelation started.");
			Console.WriteLine("Press 'P' to pause/resume, 'S' to save paths, 'Q' to quit to menu.");
			bool paused = false;
			int step = 1;

			while (true)
			{
				if (Console.KeyAvailable)
				{
					var key = Console.ReadKey(true).Key;
					if (key == ConsoleKey.Q)
					{
						Console.WriteLine("Returning to menu...");
						break;
					}
					if (key == ConsoleKey.P)
					{
						paused = !paused;
						Console.WriteLine(paused ? "Paused." : "Resumed.");
					}
					if (paused && key == ConsoleKey.S)
					{
						foreach (var npc in npcs)
						{
							if (npc.Behaviour is SeekBehaviour sb)
							{
								var filename = Console.ReadLine();
								PathUtils.SavePath(new List<(int, int)>(sb.PathQueue), filename);
							}
						}
					}
					if (!paused)
					{
						Console.Clear();
						Console.WriteLine($"--- Step {step} ---");
						world.Render();
						world.Update();
						step++;
					}
					Thread.Sleep(500);
				}
			}
		}
		static void LoadPathScenario()
		{
			Console.Write("Enter path filename to load (e.g., alice_path.path): ");
			var filename = Console.ReadLine();
			var path = PathUtils.LoadPath(filename);

			var world = new GridWorld(25, 25);
			world.GenerateObstacles(30);

			var alice = new NPC(1, "Alice", path[0].Item1, path[0].Item2);
			var seek = new SeekBehaviour(path[^1]);
			seek.SetCustomPath(path);

			alice.SetBehaviour(seek);
			world.AddNPC(alice);

			RunSimulation(world, new List<NPC> { alice });
		}

		static void StartRandomScenario()
		{
			var world = new GridWorld(25, 25);
			world.GenerateObstacles(30);

			var alice = new NPC(1, "Alice", 2, 3);
			var bob = new NPC(2, "Bob", 5, 5);
			var aliceSeek = new SeekBehaviour((15, 15));
			var bobSeek = new SeekBehaviour((2, 2));

			alice.Behaviour = aliceSeek;
			bob.Behaviour = bobSeek;

			world.AddNPC(alice);
			world.AddNPC(bob);

			RunSimulation(world, new List<NPC> { alice, bob });
		}

		static void RecordPathScenario()
		{
			var world = new GridWorld(25, 25);
			var alice = new NPC(1, "Alice", 12, 12);
			world.AddNPC(alice);

			var customPath = new List<(int, int)>();
			customPath.Add((alice.X, alice.Y));

			Console.WriteLine("Creating custom path.");
			Console.WriteLine("Use arrow keys to move.");
			Console.WriteLine("Press 'S' to save, 'Q' to stop.");

			while (true)
			{
				Console.Clear();
				world.Render();

				if (Console.KeyAvailable)
				{
					var key = Console.ReadKey(true).Key;
					if (key == ConsoleKey.UpArrow)
					{
						TryMove(alice, 0, -1, customPath);
					}
					else if (key == ConsoleKey.DownArrow)
					{
						TryMove(alice, 0, 1, customPath);
					}
					else if (key == ConsoleKey.LeftArrow)
					{
						TryMove(alice, -1, 0, customPath);
					}
					else if (key == ConsoleKey.RightArrow)
					{
						TryMove(alice, 1, 0, customPath);
					}
					else if (key == ConsoleKey.S)
					{
						Console.WriteLine("Enter filename to save custom path: ");
						var filename = Console.ReadLine();
						PathUtils.SavePath(customPath, filename);
						Console.WriteLine("Path saved. Returning to menu...");
						Thread.Sleep(1000);
						break;
					}
					else if (key == ConsoleKey.Q)
					{
						Console.WriteLine("Stopped recording.");
						Console.WriteLine("Returning to menu...");
						Thread.Sleep(1000);
						break;
					}
				}
				Thread.Sleep(1000);
			}
		}
		static void TryMove(NPC npc, int dx, int dy, List<(int, int)> path)
		{
			if (npc.Move(dx, dy))
			{
				path.Add((npc.X, npc.Y));
			}
		}
	}
}