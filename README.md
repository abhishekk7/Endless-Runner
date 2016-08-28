# Samurai Run – Endless 3D Runner
##CG Final Project
---------

Made this game for Computer Graphics final project. 

##Game Play
-------

In Samurai Run, the player controls the Samurai, a warrior who has destroyed a sacred temple, unfortunately he did not realize that the temple was cursed and now the whole trail is being destroyed. As the game is an endless running game, there is no end to the trail; therefore, the player plays until the character falls off the trail or collides with the burning obstacles and burns alive.

The game starts off with the player running for his life and consistently increases the difficulty of the game by a rise in speed. The Samurai has an animation associated with it and hitting any obstacles or falling off the trail would result in its death. The setting is that the Samurai is running while the trail is on fire and burning down. Slowing down is not an option.


##Game Elements
----

1. Obstacles
  - The obstacles are made out of wooden boxes that are on fire.
  - These use the concept of Texture Mapping and follow the rules of physics.
2. Character
  - The Character is a Samurai Warrior who is running through the trail.
3. Environment
  - The Environment consists of the setting and the trail.
  - The setting is a dark night outside the temple. This can be toggled between day and night.
  - The trail is a wooden path, the only way out of the temple, but is falling down.
4. Fires
  - The obstacles are set on fire using particle system.
5. Scoring
  - The score has 2 parts, the distance run and the coins collected.
  - Each meter of distance is worth 1 point.
  - Each coin collected is worth 2 points each.
  - The total score is the sum of these points.
  - The current distance and number of coins collected are displayed on the screen at all times.
6. Coins
  - Coins are the added scoring opportunities
  - They are generated randomly on the trail.
7. Power ups:
  - Positive power ups: Doubles the value of coins collected for 5 seconds
8. Death of the Character
  - If the Character collides with an obstacle or falls off the bridge, he dies.
  - The final score is calculated and displayed to the player.

Main Character and Bridges taken from the Unity Asset store.
