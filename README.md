## Tower Defense Case Study

A tower defense game where you **spawn random heroes**  on a grid and **merge** them **to boost** their stats, like in Codeway's very own **Rumble Rivals**.

![alt](https://drive.google.com/file/d/1PQdfITwOt2K7y0uhuAfAAfKM1lQDnA8M/view?usp=sharing)

### Basics
- Start with 60 Mana points
- As heroes are spawned, spawning another hero will require 10 Mana points more than before.
- Defeating enemies rewards Mana points
----
- Enemies come in waves. There are 16 hard-coded waves.
- Enemy spawn period is determined by the ongoing wave.

### Heroes
Heroes of the same type and same level can be merged. Which will spawn a random leveled up hero. With each promotion a hero will be buffed 10%.
- **Dwarf:** Throws axes, high damage, medium range, low fire rate.
- **Knight:** Throws daggers, medium damage, medium range, medium fire rate.
- **Archer:** Throws arrows, low damage, high range, medium fire rate.

### Enemies
If an enemy reaches at the end of the path it'll attack the princess. If princess is defeated it'll be game over.

- **Cyclops:** Slow, more health, deals more damage to princess.
- **Ghost:** Medium-paced, easier to defeat, deals less damage to princess.
- **Spider:** Fast, easiest to defeat, deals a little amount of damage to princess.
