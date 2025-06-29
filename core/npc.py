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
        new_x = self.x + dx
        new_y = self.y + dy

        if hasattr(self, 'world') and self.world.is_walkable(new_x, new_y):
            self.x = new_x
            self.y = new_y
            print(f"{self.name} moved to ({self.x}, {self.y})")
            return True
        else:
            print(f"{self.name} cannot move to ({new_x}, {new_y}) — blocked or out of bounds.")
            return False

    def update(self) :
        if self.behaviour:
            self.behaviour.tick(self)
        else:
            print(f"{self.name} is idle at ({self.x}, {self.y})")

    def __repr__(self):
        return f"<NPC {self.name} at ({self.x}, {self.y})>"