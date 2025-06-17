import heapq

def a_star(grid_world, start, goal):
    width, height = grid_world.width, grid_world.height
    open_set = []
    