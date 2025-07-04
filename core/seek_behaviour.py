import random
from pathfinding.pathfinding import a_star

class SeekBehaviour:
    def __init__(self, goal=None, max_failures=3):
        self.goal = goal
        self.path = []
        self.failure_count = 0
        self.max_failures = max_failures

    def tick(self, npc):
        if self.goal is None or self.failure_count >= self.max_failures:
            self.assign_new_goal(npc)
            self.failure_count = 0

        if not self.path:
            self.path = a_star(npc.world, (npc.x, npc.y), self.goal)
            if not self.path:
                print(f"{npc.name} cannot find path to {self.goal}. Incrementing failure count.")
                self.failure_count += 1
                return

            if self.path and self.path[0] == (npc.x, npc.y):
                self.path.pop(0)

        if self.path:
            next_x, next_y = self.path[0]
            dx = next_x - npc.x
            dy = next_y - npc.y
            moved = npc.move(dx, dy)
            print(f"{npc.name} attempts move to ({next_x}, {next_y}), result: {moved}")

            if moved:
                self.path.pop(0)
                if npc.x == self.goal[0] and npc.y == self.goal[1]:
                    print(f"{npc.name} reached goal {self.goal}. Picking new goal.")
                    self.assign_new_goal(npc)
            else:
                print(f"{npc.name} move blocked. Incrementing failure count.")
                self.failure_count += 1
                self.path = []

    def assign_new_goal(self, npc):
        attempts = 0
        while True:
            new_x = random.randint(0, npc.world.width - 1)
            new_y = random.randint(0, npc.world.height - 1)
            if not npc.world.is_obstacle(new_x, new_y):
                tentative_path = a_star(npc.world, (npc.x, npc.y), (new_x, new_y))
                if tentative_path:
                    self.goal = (new_x, new_y)
                    self.path = []
                    print(f"{npc.name} assigned new goal: {self.goal}")
                    break
            attempts += 1
            if attempts > 50:
                print(f"{npc.name} could not find a valid new goal after 50 attempts.")
                self.goal = None
                self.path = []
                break
      
    def set_custom_path(self, path):
        if path:
            self.goals = [path[-1]]
            self.current_goal_index = 0
            self.path = path
            self.goal = path[-1]
            self.failure_count = 0
            print(f"Custom path set. Goal is now {self.goal}.")
        else:
            self.goals = []
            self.path = []
            self.goal = None