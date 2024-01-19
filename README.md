# Technical-Assignment_Mohammad_Salah (Ludo Game Demo)

## Overview

Welcome to the Unity Assignment Game Demo! In this project, I've successfully implemented the features outlined in the assignment prompt. Below, you'll find details about the project, how to run it, and additional information.
## Download Andriod Apk
The program shipped and build successfully on android , and you can download the program from this Apk [Android APK ](https://drive.google.com/file/d/1EWBFPu_7FcZNz8VfUFNnNWukNTt8oF0_/view?usp=sharing)

## Gameplay Video

For a quick overview of the gameplay, check out the [Gameplay Video](https://youtu.be/6fPx6Mk0K6Y) captured on my Android device.

## Features Implemented

### User Interface (UI):

- A clean and simple UI with a "Roll" button to simulate rolling a virtual die.
- A "Reset" button to return the game piece (chip) to its initial position.

### Ludo Board Game Layout:

- A Ludo board game layout featuring a single game piece (chip) initially placed on one of the starting positions.

### Die Roll Animation:

- Clicking the "Roll" button triggers a captivating die roll animation.
- The final number obtained from the die roll is displayed on the Die.

### Chip Movement:

- Tapping the chip moves it to the appropriate position based on the last die roll.

### Unity's Addressables System:

- Integration of Unity's Addressables system to load images of the die and chip, optimizing asset management.

## How to Run

To experience the Unity Assignment Game Demo:

1. **Unity Version:**
   - Ensure you have Unity version 2022.3.17f1 installed.

3. **Clone Repository:**
   - Clone the repository to your local machine using the following command:
     ```bash
     git clone https://github.com/moahammd20170642/Technical-Assignment_Mohammad_Salah.git
     ```

4. **Open in Unity:**
   - Open Unity Hub and add the cloned project by selecting the project folder.

5. **Run the Scene:**
   - Open the GameScene in the `Scenes` folder.
   - set portrait Aspect Ratio or use the simulator 
   - Press the play button in the Unity editor to run the scene.

6. **Enjoy the Demo:**
   - Interact with the UI buttons, roll the virtual die, and observe the chip's movement based on the die roll.

# AddressableManager Overview

The `AddressableManager` script is an essential component in this Unity project, facilitating the dynamic loading of addressable assets, specifically images. Its role is critical in scenarios where images need to be loaded at runtime, as outlined in the Unity assignment. Below is an overview of the key components and functionalities of this script:

## Key Components

- **References:**
  - `dieManager`: A reference to the `DieManager` script to assign the Die Images List after loading.
  - `chip`: A reference to the `SpriteRenderer` of the game piece (chip) to assign the Ship Image after loading.
  
- **Addressable Asset Settings:**
  - `playerImageAddress`: The address of the player image asset.
  - `DieImagesAdersses`: A list of addresses for die images.

- **Loading Images:**
  - In the `Start` method, the script initiates the loading process for both the player image and die images.
  - The `LoadImage` method asynchronously loads images using Unity's Addressables system.

- **Handling Loaded Images:**
  - Upon successful image loading, the `OnImageLoaded` method is called.
  - If the loaded image is the player image, it is assigned to the `chip` SpriteRenderer.
  - If the loaded image is a die image, it is added to the `DieImages` list in the `dieManager`.

- **Logging:**
  - Debug logs are provided to track the loading progress and to identify successful and failed image loads.

# DieManager Overview

The `DieManager` script is a crucial component in this Unity project, responsible for simulating the rolling of a die and updating the game state accordingly. It orchestrates the animation, randomness, and player movement associated with rolling a die. Below is an overview of the key components and functionalities of this script:

## Key Components

- **References:**
  - `AnimatedDie`: Reference to the animated die SpriteRenderer.
  - `PlayerController`: Reference to the `PlayerController` script for updating player (chip) movement.
  - `randomApiManager`: Reference to the `RandomApiManager` script for obtaining random numbers.
  - `DieImages`: List of die images filled from the `AddressableManager`.
  - `Die`: SpriteRenderer for the actual die.
  - `DiceAnimator`: Animator for animating the die.
  

- **Roll Method:**
  - Triggers the die to roll if the player is allowed to roll

- **RollTheDice Coroutine:**
  - Disables the actual die, fetches a random number from `RandomApiManager`, and triggers the animated die.
  - Enable the actual die and Updates the die with the obtained random image, triggers the die animation, and updates the player's waypoint index based on the roll.

- **Game State Update:**
  - Updates the `PlayerController` to move the player (chip) based on the obtained random number.


# PlayerController Overview

The `PlayerController` script is a vital component in this Unity project, responsible for managing the movement and interactions of the player (chip) on the game board. It responds to player taps, initiates movement, and ensures the player progresses through waypoints in a controlled manner. Below is an overview of the key components and functionalities of this script:

## Key Components

- **Waypoints:**
  - `waypoints`: An array of Transform objects representing the points on the board that the player must traverse.

- **Movement Settings:**
  - `moveSpeed`: The speed at which the player moves.
  - `target`: The current target position the player is moving towards.

- **Waypoint Index:**
  - `waypointIndex`: The current index indicating the player's progress on the waypoints.

- **Initialization:**
  - The script is initialized by calling `ResetPlayerPosition()`, ensuring the player starts from the initial position.

- **Reset Player Position:**
  - `ResetPlayerPosition()`: Resets the player's position to the starting waypoint, allowing for a clean start.

- **Player Tapping:**
  - `TapPlayer()`: Marks the player as tapped, allowing the die to roll again after the player finishes moving.

- **Update Method:**
  - `Update()`: Monitors player movement and checks for taps 
- **Check If Player Tapped:**
  - `checkIfPlayerTapped()`: Detects touch or mouse input to determine if the player has been tapped.

- **Movement Logic:**
  - `Move()`: Manages the player's movement towards the next waypoint, ensuring the player progresses through waypoints in sequence without crossing.

# UIManager Overview

The `UIManager` script is a key component in this Unity project, responsible for managing the visibility and behavior of UI elements, with a focus on the Roll Button. It dynamically adjusts the visibility of the Roll Button based on the game state, providing a seamless user experience. Below is an overview of the key components and functionalities of this script:

## Key Components

- **UI Elements:**
  - `RollButton`: A reference to the GameObject representing the Roll Button.

## Update Method

- **Update():**
  - Checks the game state to determine whether the Roll Button should be visible or hidden.

### Roll Button Visibility Logic

- **Roll Button Active:**
  - If the `DieManager` indicates that rolling is not allowed (`DieManager.allowedToRoll == false`) and the Roll Button is currently active, the Roll Button is set to inactive. This ensures the Roll Button is hidden when it's not allowed to roll.

- **Roll Button Inactive:**
  - If the `DieManager` indicates that rolling is allowed (`DieManager.allowedToRoll == true`) and the Roll Button is currently inactive, the Roll Button is set to active. This ensures the Roll Button is visible when it's allowed to roll.


# RandomApiManager Overview

The `RandomApiManager` script manages the interaction with an external API to fetch random numbers within a specified range. This component is crucial for obtaining random values, such as simulating the roll of a die in the Unity assignment.

### Key Components

- **API Request on Awake:**
  - The script initiates an API call on `Awake` to ensure the availability of a random number when `GetCurrentRandomNumber()` is later invoked.

- **API Request Method:**
  - Utilizes a coroutine, `GetRandomNumber()`, to send a request to the [csrng.net](https://csrng.net/csrng/csrng.php) API for a random number within a specified range.

- **Response Handling:**
  - Parses the JSON response from the API using the `Response` and `Parameter` classes to extract relevant information, such as the random number.

- **RequestNewRandomNumber Method:**
  - Invoked to trigger a new API request, refreshing the random number.

- **GetCurrentRandomNumber Method:**
  - Calls `RequestNewRandomNumber()` and returns the current random number. This ensures a fresh random number is obtained each time the method is called.

### API Endpoint
- The script communicates with the [csrng.net](https://csrng.net/csrng/csrng.php) API endpoint to generate random numbers. The API key, minimum, and maximum values are included in the request.


## API Documentation

To understand the random number generation API used in this project, refer to the [csrng.net API Documentation](https://csrng.net/documentation/csrng-pro/).

