# DotsAssignment

Controllers:

Move Player : WASD
Shoot: LMB

Optimization

The systems are made to efficiently handle only the enteties that need processing by targeting specific components. BurstCompile is used to speed up the code execution. I've also cached references to avoid unnecessary recalculations and followed a consistent naming pattern for better organization

Unity

In Unity, open the "MainScene" and enable the subscene if it is currently disabled.

The spawner will spawn objects above the player at a random X position within a specified range. I also adjusted the projectile movement so that its direction can be changed, allowing it to be used for enemy movement as well.

You can acces the build from the release tag in the repository.
