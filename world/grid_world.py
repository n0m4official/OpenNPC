class GridWorld:
    def __init__(self, width=10, height=10):
        self.width = width
        self.height = height
        self.npcs = []

    def add_npc(self, npc):
        self.npcs.append(npc)

    def update(self):
        for npc in self.npcs:
            npc.update()

    def render(self):
        grid = [['.' for _ in range(self.width)] for _ in range(self.height)]

        for npc in self.npcs:
            if 0 <= npc.x < self.width and 0 <= npc.y < self.height:
                grid[npc.y][npc.x] = npc.name[0].upper()
            
            for row in grid:
                print(' '.join(row))
            print()