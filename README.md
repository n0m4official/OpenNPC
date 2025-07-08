![OpenNPC-icon-min](https://github.com/user-attachments/assets/1d38f81d-da4d-464d-858d-ede10583e9a7)

# OpenNPC

A lightweight, modular NPC simulation framework in Python and C#.
NPCs live on a grid-based world, execute simple or advanced behaviors, and are designed to be easily extended or embedded in larger projects (including future game engine integration).

---

## 🌟 Features
- Grid-based world simulation (25x25 by default)
- NPCs with position, identity, and customizable behaviors
- WanderBehaviour — random idle movement
- SeekBehaviour — intelligent goal-seeking with A* pathfinding
- Obstacles and boundaries enforced
- Save/load paths for NPCs (custom path design)
- Modular design — easy to add new behaviors or integrate into other systems

---

## 💻 Versions
### 🐍 Python Version
- Pure Python 3.8+
- Console-based grid simulation
- Simple modular structure
- Supports .path files for saving and loading paths

### ⚙️ C# Version
- .NET Core or .NET 6+
- Console application (.exe build included)
- Cleaner class separation for potential game engine embedding (e.g., Unity, Godot C#)
- Extra NPC manager for controlling groups and simplifying scenario setup

---
## 📁 Project Structure

```
OpenNPC/
├── Python/
│   ├── core/
│   |   ├── npc.py # NPC class and behaviour support
│   |   ├── behaviour_tree.py # Behaviour base class (e.g. WanderBehaviour)
│   |   └── seek_behaviour.py
│   ├── world/
│   |   └── grid_world.py
│   ├── pathfinding/
|   |   └── pathfinding.py
│   ├── utils/
|   |   └── path_utils.py
│   └── main.py
│
├── CSharp/
│   ├── GridWorld.cs
│   ├── IBehaviour.cs
│   ├── NPC.cs
│   ├── SeekBehaviour.cs
│   ├── WanderBehaviour.cs
│   ├── Pathfinding.cs
│   ├── PathUtils.cs
│   ├── NPCManager.cs
│   └── Program.cs
│
├── OpenNPC.exe
├── OpenNPC_CSharp_ver.dll
├── SECURITY.md
├── LICENSE
└── README.md

```
---

## ▶️ Getting Started
### ✅ Python Version
#### Requirements:
- Python 3.8 or later

#### Run:
bash
```
python main.py
```
Use keys to control NPCs and watch the console grid update live.


### ✅ C# Version
#### Requirements:
.NET 6 SDK or later

#### Build & Run:
```
dotnet build
dotnet run
```
or run the pre-built OpenNPC.exe in CSharp/bin/Release.
---

## 💬 Example Output (Python & C#)
```
=== OpenNPC Menu ===
1. Load path from file
2. Start random paths
3. Create custom path (record)
4. Quit
Enter choice: 2

Simulation started.
Press 'P' to pause/resume, 'S' to save paths, 'Q' to quit to menu.

--- Step 1 ---
A . . . . #
. . . # . #
. . . . . #
. . B # . .
. . . . . .
```

---

## 🧭 Features Comparison

| Feature             | Python          | C#             |
| ------------------- | ---------------- | --------------- |
| Grid world          | ✔️               | ✔️              |
| Wander behavior     | ✔️               | ✔️              |
| Seek behavior       | ✔️               | ✔️              |
| Obstacles           | ✔️               | ✔️              |
| Save/load paths     | ✔️               | ✔️              |
| Embedded engine use | ❌               | ✔️*             |
| EXE build           | ✔️ (PyInstaller) | ✔️ (.NET build) |

*Still in development, there may be bugs. There is a risk of project loss due to unforseen problems, use with caution and be smart.

---

## 🔮 Future Roadmap
- ✅ Smarter pathfinding (A*)
- ✅ Save/load path system
- ✅ Support for multiple simultaneous NPCs
- ⬜️ Engine-agnostic plugin interfaces
- ⬜️ Visualization hooks for 2D or 3D worlds
- ⬜️ AI modules (avoidance, flocking, formations)

---

## 🤝 Contributing
We love curious minds! Whether you enjoy AI logic, simulation design, or game system architecture:

1. Fork the repo
2. Submit a pull request
3. Open an issue to discuss ideas

No 3D engines or visual assets needed. Logic-first development all the way.

---

## 📄 License
This project is licensed under the MIT License.

Use it freely in personal, educational, or commercial projects.

---

## ⚠️ Disclaimer
This framework is for learning and experimental purposes.
The authors assume no responsibility for misuse or unintended consequences.

---

## 💬 Questions? Ideas?
Open an issue or discussion.
