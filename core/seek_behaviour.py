import random

from pathfinding.pathfinding import a_star

class SeekBehaviour:
    def __init__(self, goal_x, goal_y):
        self.goal = (goal_x, goal_y)
        self.path = []
    
    def tick(self, npc):
        if not self.path:
            self.path = a_star(npc.world, (npc.x, npc.y), self.goal)
            if not self.path:
                print(f"{npc.name} cannot find a path to {self.goal}.")
                return

            if self.path[0] == (npc.x, npc.y):
                self.path.pop(0)
        
        if self.path:
            next_x, next_y = self.path.pop(0)
            dx = next_x - npc.x
            dy = next_y - npc.y
            npc.move(dx, dy)

            if not self.path:
                new_x = random.randint(0, npc.world.width - 1)
                new_y = random.randint(0, npc.world.height - 1)
                while npc.world.is_obstacle(new_x, new_y):
                    new_x = random.randint(0, npc.world.width - 1)
                    new_y = random.randint(0, npc.world.height - 1)
                self.goal = (new_x, new_y)
                print(f"{npc.name} picked new goal: {self.goal}")