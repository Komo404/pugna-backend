CREATE TABLE accounts (
    id uuid PRIMARY KEY,
    account_name text NOT NULL,
    display_name text NOT NULL,
    email varchar(255) NOT NULL UNIQUE,
    password_hash text NOT NULL
);
