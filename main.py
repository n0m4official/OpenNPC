from core.npc import NPC
from world.grid_world import GridWorld

world = GridWorld(width=10, height=10)

# Create NPCs
alice = NPC(npc_id=1, name="Alice", x=2, y=3)
bob = NPC(npc_id=2, name="Bob", x=5, y=5)

world.add_npc(alice)
world.add_npc(bob)

print("Initial World:")
world.render()

alice.move(1, 0)
bob.move(0, -1)

world.update()

print("After Moving:")
world.render()