CREATE TABLE rooms (
    id integer GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    name text NOT NULL,
    description text NOT NULL DEFAULT '',
    capacity integer NOT NULL check (capacity > 0)
)