import heapq

def heuristic(a, b):
    return abs(a[0] - b[0]) + abs(a[1] - b[1])

def reconstruct_path(came_from, current):
    path = [current]
    while current in came_from:
        current = came_from[current]
        path.append(current)
    path.reverse()
    return path

def a_star(grid_world, start, goal):
    width, height = grid_world.width, grid_world.height
    open_set = []
    heapq.heappush(open_set, (0, start))

    came_from = {}
    g_score = {start: 0}
    f_score = {start: heuristic(start, goal)}

    directions = [(-1, 0), (1, 0), (0, -1), (0, 1)]

    while open_set:
        _, current = heapq.heappop(open_set)

        if current == goal:
            return reconstruct_path(came_from, current)
        
        for dx, dy in directions:
            neighbour = (current[0] + dx, current[1] + dy)

            if not grid_world.is_within_bounds(*neighbour):
                continue

            tentative_g_score = g_score[current] + 1

            if neighbour not in g_score or tentative_g_score < g_score[neighbour]:
                came_from[neighbour] = current
                g_score[neighbour] = tentative_g_score
                f_score[neighbour] = tentative_g_score + heuristic(neighbour, goal)
                heapq.heappush(open_set, (f_score[neighbour], neighbour))

    return None