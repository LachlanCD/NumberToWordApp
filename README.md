# Number-to-Words Web Application

This is a web app that converts a numerical user input to a worded dollar and cents representation (e.g. "190.50" will become "one hundred and ninety dollars and fifty cents").

It consists of:
- ASP.NET Core 9 backend serving an API and static files.
- React 24 frontend for the user interface.
- A Dockerfile and Docker Compose for deployment.

## Overview

- REST API endpoint: `/api/convert`
- Frontend form to enter an amount and display the result.
- Unit & integration tests for backend.
- Dockerized for easy deployment.

## Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/) (or later)
- [Node.js](https://nodejs.org/) (for frontend development)
- [Docker](https://www.docker.com/) (for containerized deployment)

## Running the Application

run
```bash
docker compose up --build
```

This will make the app accessible at http://localhost:8080

## Running the Test Suite
```bash
cd backend
dotnet test
```

## API Usage
### POST `/api/convert`
#### Request Body
```json
{
"amount": "190.50"
}
```
#### Response
```json
{
"result": "one hundred and ninety dollars and fifty cents"
}
```

## Expansion
As this is a containerised application utilising a solution such as Azure, AWS or GCP for hosting would be ideal with their respective containerised deployment.
