# Traffic Lights Simulation

## Overview

This Unity project simulates a traffic light sequence based on the UK traffic rules. It includes a 3D environment decorated with assets from the Unity Asset Store, automatic car movement, a third-person camera view using Cinemachine, and voice prompts managed through scripts and coroutines.

## Features

- Traffic light sequence based on UK light sequence.
- Automatic car movement with RigidBody and Collider components.
- Third-person camera view following the car using Cinemachine.
- Audio prompts for each step of the traffic light sequence that changes using a script.
- Use of coroutines to manage steps and timings.
- Canvas with texts to display the current step and information.

## Getting Started

### Prerequisites

- Unity 2021.3.22 (or later)
- Cinemachine.(if not included in your Unity version)
- Additional assets from the Unity Asset Store (refer to the Asset Store documentation for installation instructions)//TO DO

### Installation

1. Clone the repository to your local machine.<br>
   ``` git clone https://github.com/your-username/traffic-lights.git ```

2. Open the project in Unity.

3. Ensure that the necessary assets, including Cinemachine, are installed, imported and configured.

4. Run the scene to experience the traffic lights simulation.

## Structure //TODO

- **Assets**: Contains project assets, including 3D models, scripts, and textures.
- **Scripts**: All scripts controlling the traffic lights, car movement, camera, and voice prompts.
- **Scenes**: Main scene files for the project.


## Acknowledgments

- Unity Asset Store contributors for providing assets used in this project.
- [Unity Documentation](https://docs.unity3d.com/Manual/index.html) for reference. //TODO
- This project was developed as part of a virtual reality (VR) training program [The Interactive Digital Center (IDC)](https://eonreality.com/locations/ben-guerir-ma/#:~:text=in%20their%20sector.-,VR%20Innovation%20Academy,-COMPREHENSIVE%20CURRICULUM). The goal of the training was to apply and reinforce various Unity concepts, including 3D environment design, asset integration, scripting and UI integration with VR and AR functionality.
