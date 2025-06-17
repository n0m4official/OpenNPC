class NPC:
    def __init__(self, npc_id, name, x=0, y=0) :
        self.id = npc_id
        self.name = name
        self.x = x
        self.y = y
        self.behaviour = None
    
    def set_behaviour(self, behaviour) :
        self.behaviour = behaviour

    def move(self, dx, dy) :
        self.x += dx
        self.y += dy
        print(f"{self.name} moved to ({self.x}, {self.y})")

    def update(self) :
        if self.behaviour:
            self.behaviour.tick(self)
        else:
            print(f"{self.name} is idle at ({self.x}, {self.y})")

    def __repr__(self):
        return f"<NPC {self.name} at ({self.x}, {self.y})>"