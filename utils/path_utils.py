class PathUtils:
    @staticmethod
    def save_path_to_file(path, filename):
        with open(filename, "w") as f:
            for x, y in path:
                f.write(f"{x},{y}\n")
        print(f"Path saved to {filename}")

    @staticmethod
    def load_path_from_file(filename):
        path = []
        with open(filename, "r") as f:
            for line in f:
                x_str, y_str = line.strip().split(",")
                path.append((int(x_str), int(y_str)))
        print(f"Path loaded from {filename}")
        return path