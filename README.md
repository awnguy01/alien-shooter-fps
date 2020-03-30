# Alien Shooter FPS

## Genre

- FPS
- Space
- Horror

## Player Design

- Player is a transparent capsule with the main camera attached
- Arm models are attached to the player capsule and always visible in front of the camera
- A reticle is positioned in the middle of the screen on a canvas to aid in aiming
- By left clicking, the player can fire off orb projectiles that explode on collision
- Movement is WASD based

## Level Design

- The level is a square with a symmetrical design
  - Dividers in 4 corners section the space off into 4 equally sized rooms
- Light fixtures created with point lights hang on the ceiling of the level between the rooms to provide level lighting
- Purple light orbs are located in each room also functioning as another light source
- Ambient deep space noise loops in the background

## Enemy Design

- Enemies are 3D models of alien cephalopods
- Enemy AI uses a sphere collider to detect if the player is in range
  - If the player is in range, the enemy becomes aware of the player and starts to move towards the player
- On death, enemies spin vertically and make a screeching noise
