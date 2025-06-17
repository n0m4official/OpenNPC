import random

class WanderBehaviour:
    def tick(self, npc):
        directions = [
            (0, 0),      # Stay still
            (0, -1),     # Up
            (0, 1),      # Down
            (-1, 0),     # Left
            (1, 0)      # Right
        ]
        dx, dy = random.choice(directions)
        npc.move(dx, dy)