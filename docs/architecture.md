# Architecture

There is one ASP.NET app with three .NET projects. The API and PostgreSQL run in Docker.

- `Pugna.API` handles HTTP and wires up the app in `Program.cs`
- `Pugna.Core` is where game models and rules go.
- `Pugna.Infra` is where code that uses PostgreSQL goes

## Why the Postgre?

The database willl store players, rooms, room members, and matches. Changes to the schema will go into SQL scripts kept in the repo. See the [SQL decision record](adr/001-use-postgre-and-npgsql.md)

## Docker checks

From the repo root:

```sh
docker compose up --build -d
curl -fsS http://127.0.0.1:8081/HelloWorld
docker compose exec db psql -U pugna -d pugna -c 'SELECT 1;'
```

OBS: Use `sudo` if the Docker commands returns an error.

A database client on your machine uses `127.0.0.1:5433`. Once the API connects to PostgreSQL, it will use `db:5432` inside Docker