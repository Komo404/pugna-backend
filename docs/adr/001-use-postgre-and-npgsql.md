# ADR 001
Date: 22/11/2026
Title: Decision of the DBMS and How to interact with it
Status: Accepted

## Context

Pugna needs to save rooms and match results. I want to learn how to design tables, write queries, and see what those queries do, and I need a DBMS and a way to interact with it

## Decision

Write SQL by hand and use Npgsql. PostgreSQL as I used it once and want to learn more about it. Keep schema changes in versioned SQL scripts and pass values from the API as query parameters.

## Tradeoffs

EF Core could map C# objects to tables and generate migrations. Starting with Npgsql means writing those queries, mapping the results, and deciding how to apply schema changes. It also lets me try the same queries in `psql` before calling them from the API. I may try EF Core after the SQL flow works.
