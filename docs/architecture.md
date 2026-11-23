# Architecture

There is one ASP.NET app with three .NET projects. The API and PostgreSQL run in Docker.

- `Pugna.API` handles HTTP and wires up the app in `Program.cs`
- `Pugna.Core` is where game models and rules go.
- `Pugna.Infra` is where code that uses PostgreSQL goes

## Why the Postgre?

The database willl store players, rooms, room members, and matches. Changes to the schema will go into SQL scripts kept in the repo. See the [SQL decision record](adr/001-use-postgre-and-npgsql.md)

## Docker checks

From the repo root:

Start the project using docker:
```sh
docker compose up --build -d
```

Create the first table:
```sh
docker compose exec -T db psql -U pugna -d pugna -v ON_ERROR_STOP=1 < db/001_create_rooms.sql
```

Create a Test room:
```sh
curl -X POST "127.0.0.1:8081/Room"      -H "Content-Type: application/json"      -d '{"name": "oi", "description": "descricao","capacity":"4"}'
```

Then check the response with
```sh
curl "127.0.0.1:8081/Room" 
```

OBS: Use `sudo` if the Docker commands returns an error.

A database client on your machine uses `127.0.0.1:5433`. Once the API connects to PostgreSQL, it will use `db:5432` inside Docker.

The same happens to the main API: It uses `127.0.0.1:8081` on your machine, but inside docker it uses `127.0.0.1:8080`.