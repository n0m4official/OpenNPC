# OpenNPC

A lightweight, modular NPC simulation framework in Python.  
NPCs live on a grid-based world, execute simple behaviours like wandering, and are designed to be extensible with more complex AI and game systems.

---

## 🧠 Features

- 🧱 Grid-based world simulation (25x25 by default)
- 🤖 NPCs with position, identity, and behaviours
- 🔁 WanderBehaviour: NPCs move randomly or stay idle
- 🚧 Boundaries enforced — no wandering off the grid!
- 🧩 Easily extendable with new AI behaviours or world features

---

## 📁 Project Structure

```
OpenNPC/
├── core/
│ ├── npc.py # NPC class and behaviour support
│ ├── behaviour_tree.py # Behaviour base class (e.g. WanderBehaviour)
│ └── seek_behaviour.py # Goal selecting base class
│
├── pathfinding/
| └── pathfinding.py # Pathfinding base class
|
├── utils/
| └── path_utils.py # Path saving funtions for .path file format
|
├── world/
│ └── grid_world.py # GridWorld class handles simulation and rendering
│
├── main.py # Entry point for running the simulation
├── OpenNPC.exe # Simulation executable
├── SECURITY.md # Self Explanitory
├── License # Self Explanitory
└── README.md # You’re reading it!
```
---

## ▶️ Getting Started

### Requirements

- Python 3.8 or later

### Run the Simulation

```bash
OpenNPC.exe
```
The console will print the grid and NPC movements each simulation step.

Press and hold Q on your keyboard to end the simulation.

---

## 📦 Example Output
```
Press 'q' to quit.

Initial World:
. . . . # . . . . .
. . . # . # . . . .
. . . . . . # . . #
. . A # # . . . . .
. . . . . . . . . #
. . . . # B . # . .
# # . . . # . . . .
# . . . # . . . . .
# . . . . . . . # #
. . # . . . . # . .


--- Step 2 ---
Alice moved to (3, 2)
Bob moved to (4, 4)
. . . . # . . . . .
. . . # . # . . . .
. . . A . . # . . #
. . . # # . . . . .
. . . . B . . . . #
. . . . # . . # . .
# # . . . # . . . .
# . . . # . . . . .
# . . . . . . . # #
. . # . . . . # . .
```

---

## 🛠 Future Plans

- [x] 🧠 Smarter pathfinding behaviour (A*, BFS, etc.)
- [x] 🎯 Goal-driven behaviours (e.g. seek targets, avoid threats)
- [x] ⛓️ Obstacle and terrain support
- [x] 📜 Save/load state
- ~~🌐 Turn it into a minimal browser game (with Pygame or Godot later)~~

---

## 🤝 Contributing
This project is open to learning-focused and experimental contributions.
If you’re into AI, game logic, or systems design — come build with us!

- Fork the repo
- Submit a pull request
- Or just file an issue to brainstorm

No 3D engines or visual assets needed. Logic-first development all the way.

---

## 📄 License
This project is licensed under the MIT License.

Use it freely in personal, educational, or commercial projects.

---

## ⚠️ Disclaimer
This project is provided for educational and developmental purposes.

**The author (n0m4official) assumes no responsibility for how this code is used by others.**

Use at your own discretion.

---

