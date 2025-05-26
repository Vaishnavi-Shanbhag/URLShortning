# URL Shortener API (C# .NET 8)

A simple URL shortening service built with ASP.NET Core Web API, EF Core, and SQLite.

## Features

- Shorten any long URL into a 6-character short code
- Redirect short URLs to the original address
- Auto-generates `urls.db` using EF Core
- Built-in Swagger UI for testing

## Tech Stack

- ASP.NET Core 8 Web API
- Entity Framework Core
- SQLite (local DB)
- Swagger (OpenAPI)

## How to Run

1. Clone the repo:
   ```bash
   git clone https://github.com/<Vaishnavi-Shanbhag>/URLShortning.git
   cd URLShortning

2. Run EF cor Migrations 
	Add-Migration InitialCreate
	Update-Database

3. Press F5 to run and navigate to Swagger UI.

