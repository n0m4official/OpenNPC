import random

class GridWorld:
    def __init__(self, width=10, height=10):
        self.width = width
        self.height = height
        self.npcs = []
        self.obstacles = set()

        self.tiles = [["." for _ in range(self.width)] for _ in range(self.height)]

    def generate_obstacles(self, count):
        attempts = 0
        while len(self.obstacles) < count and attempts < count * 10:
            x = random.randint(0, self.width - 1)
            y = random.randint(0, self.height - 1)

            if (x, y) not in self.obstacles:
                if all(npc.x != x or npc.y != y for npc in self.npcs):
                    self.add_obstacle(x, y)

            attempts += 1

    def add_npc(self, npc):
        npc.world = self
        self.npcs.append(npc)

    def update(self):
        for npc in self.npcs:
            npc.update()

    def render(self):
        grid = [row[:] for row in self.tiles]

        for (x, y) in self.obstacles:
            if self.is_within_bounds(x, y):
                grid[y][x] = "#"

        for npc in self.npcs:
            if self.is_within_bounds(npc.x, npc.y):
                grid[npc.y][npc.x] = npc.name[0].upper()

        for row in grid:
            print(' '.join(row))
        print()

    def is_within_bounds(self, x, y):
        return 0 <= x < self.width and 0 <= y < self.height
    
    def add_obstacle(self, x, y):
        if self.is_within_bounds(x, y):
            self.obstacles.add((x, y))

    def is_obstacle(self, x, y):
        return (x, y) in self.obstacles

    def is_walkable(self, x, y):
        return self.is_within_bounds(x, y) and not self.is_obstacle(x, y)