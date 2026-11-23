# Pugna Backend

![.NET 10](https://img.shields.io/badge/.NET-10-512BD4?logo=dotnet)
![PostgreSQL 17](https://img.shields.io/badge/PostgreSQL-17-4169E1?logo=postgresql&logoColor=white)
![Docker Compose](https://img.shields.io/badge/Docker-Compose-2496ED?logo=docker&logoColor=white)

An ASP.NET Core API for a small co-op browser game built with Three.js. I'm building it to learn how to write game rules, store match results and keep two players in sync

The API currently has 5 endpoints, Docker and Postgre through npgsql working

- Use the [backend spec](docs/backend-spec.md) to see what the game should do
- Use the [architecture guide](docs/architecture.md) to see where the code belongs.
- Use the [SQL decision record](docs/adr/001-use-postgre-and-npgsql.md) to see why I chose to start with SQL
- Use the [contributing guide](CONTRIBUTING.md) to check and submit changes.
