# Contributing

- Keep each change small enough to explain and check on its own.
- Run `dotnet build src/Pugna.API/Pugna.API.csproj` before opening a pull request.
- For Docker changes, run `docker compose config --quiet` and follow the [docker checks](docs/architecture.md#docker-checks)
- Update the [backend spec](docs/backend-spec.md) when a game rule changes. For a technical decision, add a numbered ADR with the context, the choice, and its tradeoffs
- Use Conventional Commits.
- In a pull request, explain what changed, why, and how you checked it.

When reporting a bug, include the steps to reproduce it and describe what you expected and what happened.