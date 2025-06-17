from core.npc import NPC
from world.grid_world import GridWorld
from core.behaviour_tree import WanderBehaviour

world = GridWorld(width=10, height=10)
world.add_obstacle(4, 4)
world.add_obstacle(2, 2)
world.add_obstacle(7, 1)

# Create NPCs
alice = NPC(npc_id=1, name="Alice", x=2, y=3)
bob = NPC(npc_id=2, name="Bob", x=5, y=5)

wander = WanderBehaviour()
alice.set_behaviour(wander)
bob.set_behaviour(wander)

world.add_npc(alice)
world.add_npc(bob)

for step in range(5):
    print(f"\n--- Step {step + 1} ---")

print("Initial World:")
world.render()

alice.move(1, 0)
bob.move(0, -1)

world.update()
print("After Moving:")
world.render()