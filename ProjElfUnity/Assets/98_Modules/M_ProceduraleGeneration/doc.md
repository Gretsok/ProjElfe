# Procedurale Generation Module Documentation

Make procedurally generated dunjeon.

## Set Up

### Dunjeon Rooms

#### Dunjeon Room

A dunjeon is made of rooms. A room has can have a forward gate, a left gate and a right gate, but it must have a backward gate.
The first thing to do to create a dunjeon is to create all of the rooms that the dunjeon will need. It is important to not forget any arrangement(according to gates).

#### DunjeonRoomData

For each room, it will be needed to create a DunjeonRoomData stocking this room as a prefab and a list of entities to spawn inside the room. Also, check what gates this room contains. Specify a range of entities to spawn.

### DunjeonData

The DunjeonData will contains the list of DunjeonRoomData that may spawn in the dunjeon. You must also reference the DunjeonRoomData of the final room.
It also contains a range rooms on the right way and a range of rooms on the wrong way.
It contains a range of rooms between two intersections.

### DunjeonManager

Each dunjeon should have its own scene.  
In this scene, the first scene to do is to place the first room of the dunjeon. This room doesn't need a DunjeonRoomData and should only have a forward gate.
Then, you'll create a DunjeonManager, reference it the DunjeonData you want to use for this dunjeon, reference the first room. Also, you'll have to set up the initial position. Set these to something over 0 for x and y. Mention that this module cannot generate room at position below x = 0 or y = 0.  

### DunjeonGameMode

Create a gamemode inheriting from DunjeonGameMode. Put it inside your scene and reference it the DunjeonManager of your scene.  
