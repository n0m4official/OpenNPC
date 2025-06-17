class GridWorld:
    def __init__(self, width=10, height=10):
        self.width = width
        self.height = height
        self.npcs = []

        self.tiles = [['.' for _ in range(width)] for _ in range(height)]

    def add_npc(self, npc):
        npc.world = self
        self.npcs.append(npc)

    def update(self):
        for npc in self.npcs:
            npc.update()

    def render(self):
        grid = [row[:] for row in self.tiles]

        for npc in self.npcs:
            if 0 <= npc.x < self.width and 0 <= npc.y < self.height:
                grid[npc.y][npc.x] = npc.name[0].upper()
            
            for row in grid:
                print(' '.join(row))
            print()

    def is_within_bounds(self, x, y):
        return 0 <= x < self.width and 0 <= y < self.height
    
    def add_obstacle(self, x, y):
        if self.is_within_bounds(x, y):
            self.tiles[y][x] = '#'

    def is_walkable(self, x, y):
        return self.is_within_bounds(x, y) and self.tiles[y][x] != '#'