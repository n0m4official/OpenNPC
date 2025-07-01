import keyboard
import time

from core.npc import NPC
from world.grid_world import GridWorld
from core.seek_behaviour import SeekBehaviour
from utils.path_utils import PathUtils

def show_menu():
    print("\n=== OpenNPC Menu ===")
    print("1. Load path from file")
    print("2. Start random paths")
    print("3. Create custom path (record)")
    print("4. Quit")
    choice = input("Enter choice: ")
    return choice

def run_simulation(world, npcs):
    print("Simulation started. ")
    print("\nPress 'p' to pause/resume, 's' to save paths, 'q' to quit to menu.")
    step = 1
    paused = False

    while True:
        if keyboard.is_pressed('q'):
            print("\nSimulation ended. Returning to menu...")
            break

        if keyboard.is_pressed('p'):
            paused = not paused
            print("\nSimulation paused." if paused else "\nSimulation resumed.")
            time.sleep(0.5)

        if paused and keyboard.is_pressed('s'):
            for npc in npcs:
                if hasattr(npc.behaviour, 'path') and npc.behaviour.path:
                    filename = input(f"Enter filename to save {npc.name}'s path: ")
                    PathUtils.save_path_to_file(npc.behaviour.path, filename)
            time.sleep(1)

        if not paused:
            print(f"\n--- Step {step} ---")
            world.update()
            world.render()
            step += 1
            time.sleep(1)

while True:
    choice = show_menu()

    if choice == "1":
        filename = input("Enter path filename to load (e.g., alice_path.path): ")
        path = PathUtils.load_path_from_file(filename)

        world = GridWorld(width=25, height=25)
        world.generate_obstacles(30)

        alice = NPC(npc_id=1, name="Alice", x=path[0][0], y=path[0][1])
        seek = SeekBehaviour(goal_x=path[-1][0], goal_y=path[-1][1])
        seek.set_custom_path(path)
        alice.set_behaviour(seek)
        world.add_npc(alice)

        run_simulation(world, [alice])
    
    elif choice == "2":
        world = GridWorld(width=25, height=25)
        world.generate_obstacles(30)

        alice = NPC(npc_id=1, name="Alice", x=2, y=3)
        bob = NPC(npc_id=2, name="Bob", x=5, y=5)

        seek_alice = SeekBehaviour(goal_x=20, goal_y=20)
        seek_bob = SeekBehaviour(goal_x=1, goal_y=1)

        alice.set_behaviour(seek_alice)
        bob.set_behaviour(seek_bob)

        world.add_npc(alice)
        world.add_npc(bob)

        run_simulation(world, [alice, bob])
    
    elif choice == "3":
        custom_path = []
        print("Creating custom path. Use arrow keys to move. Press 's' to save, 'q' to stop.")

        world = GridWorld(width=25, height=25)
        alice = NPC(npc_id=1, name="Alice", x=12, y=12)
        world.add_npc(alice)

        custom_path.append((alice.x, alice.y))
        world.render()

        while True:
            if keyboard.is_pressed('up'):
                alice.move(0, -1)
                custom_path.append((alice.x, alice.y))
                time.sleep(0.2)
            elif keyboard.is_pressed('down'):
                alice.move(0, 1)
                custom_path.append((alice.x, alice.y))
                time.sleep(0.2)
            elif keyboard.is_pressed('left'):
                alice.move(-1, 0)
                custom_path.append((alice.x, alice.y))
                time.sleep(0.2)
            elif keyboard.is_pressed('right'):
                alice.move(1, 0)
                custom_path.append((alice.x, alice.y))
                time.sleep(0.2)

            world.render()

            if keyboard.is_pressed('s'):
                filename = input("Enter filename to save custom path: ")
                PathUtils.save_path_to_file(custom_path, filename)
                print("Path saved. Returning to menu.")
                time.sleep(1)
                break
            if keyboard.is_pressed('q'):
                print("Stopped recording. Returning to menu.")
                time.sleep(1)
                break

    elif choice == "4":
        print("Goodbye!")
        break
    else:
        print("Invalid choice. Please try again.")
