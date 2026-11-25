# Backend Specification

This is the plan for the MVP

## A round

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

## System Roadmap

0. [x] Create Main ASP.NET Server
0.1 [x] Create CSProjs
0.2 [x] Connect References
0.3 [x] Add Docker
0.4 [x] Setup Postgre
0.5 [x] Setup npgSQL
1. [x] Create Initial Room System
1.1 [x] Create Main Endpoints
1.2 [x] Create Postgre connections
2. [ ] Create Authentication System
2.1 [ ] Define Player Model
2.2 [ ] Create Sign Up System
2.3 [ ] Create Sign In System
3. [ ] Improve Room System
4. [ ] Create Match system
4.5 [ ] Create websocket system
5. [ ] Create Chat system
6. [ ] Create Statistics System
7. [ ] Create Leaderboard System
8. [ ] Render Observability
9. [ ] Github Actions CI/CD