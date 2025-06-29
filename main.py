import keyboard
import time

from core.npc import NPC
from world.grid_world import GridWorld
from core.seek_behaviour import SeekBehaviour

world = GridWorld(width=50, height=50)
world.generate_obstacles(20)

alice = NPC(npc_id=1, name="Alice", x=2, y=3)
bob = NPC(npc_id=2, name="Bob", x=5, y=5)

seek_alice = SeekBehaviour(goal_x=7, goal_y=2)
seek_bob = SeekBehaviour(goal_x=1, goal_y=2)

alice.set_behaviour(seek_alice)
bob.set_behaviour(seek_bob)

world.add_npc(alice)
world.add_npc(bob)

print("Press 'q' to quit.\n")

print("Initial World:")
world.render()

step = 1
while not keyboard.is_pressed('q'):
    print(f"\n--- Step {step + 1} ---")
    world.update()
    world.render()
    step += 1
    time.sleep(1.0)

print("\nSimulation Ended.")