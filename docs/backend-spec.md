# Backend spec

This is the plan for the MVP

## A round

1. There must be a Room System (Create a room, Read the room informations, Update the room status and Delete the room)
1.1: A Code system to join the room
1.2: A "Ready" system to start the match
2. Each player activates a different terminal. Both win if they activate both terminals before time runs out. Start with a 60-second limit
3. The server saves the result and duration. If time runs out, both players lose. Canceled matches stay out of the stats and leaderboard.

## Rules to check

- If two players try to take the last spot at the same time, only one gets in.
- Only room members can send actions. Only the host can start the round.
- Repeating an activation or sending one after the round ends leaves the result unchanged.
- If a player reconnects during the round, they can get the current state. The clock keeps running.
- If two actions arrive near the end, the server decides and saves the result once.

For now, the server checks who sent the action, whether the round is active, how much time is left, and whether the action already happened. If activating a terminal later requires standing next to it, the server will also need to check the player's position.

## What to build first

1. Play a full round over HTTP in two tabs using temporary player IDs for development.
2. Save players and match results in PostgreSQL. Check what happens when two actions arrive at once.
3. Add sign-up and login, link results to accounts, and check who can act in each room.
4. Send live updates and let players catch up after reconnecting.
5. Add a profile with matches played, wins, losses, and best winning time. Start the leaderboard with the fastest winning pairs.
6. Run the demo on Render and add logs that help explain what went wrong during a match.

Still open: what happens if the host leaves, how to handle a server restart, and whether players need to see each other move.
