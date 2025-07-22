# Design Decision Document

## Overview

This document outlines the chosen architecture and reasoning behind it for my "Number-to-Words" web app. This application consists of a backend constructed in ASP.NET Core 9 with a React 24 based frontend, containerised into a single Docker container for easy deployment.

## Chosen Approach

### Backend
- **ASP.NET Core 9**
  - Chosen because I have more experience using .NET than Java.
  - Allows for a clean separation of concerns throughout the project.
  - Support for serving APIs and static files.
  - It's a modern web framework.

### Frontend
- **React 24 with Vite**
  - Chosen due to familiarity with React for constructing interactive web pages.
  - Allows for clear separation between backend and frontend functionality.
  - Built assets are easily copied into `wwwroot` and served by the backend in production resulting in one outward facing endpoint.

### Deployment
- **Docker**
  - Ensures consistent environment across all deployments.
  - Bundles frontend and backend into a single container for simplicity.
  - Easily integrated into CI/CD pipelines.

## Alternatives Considered

### 1. Server-side rendered Razor Pages / Blazor
- **Why not chosen:**
  - Server-side rendered pages are great for quickly and efficiently constructing a UI for testing, however, I am a lot more comfortable constructing and maintaining UIs in React.
  - Originally this was the approach I made however, I chose to swap to due to the aforementioned familiarity.
  - Opting for the use of React pages also effectively separates concerns between the server and client, which while unnecessary for an application such as this, would allow for effective expansion in the future.

### 2. Separate Backend and Frontend Services
- **Why not chosen:**
  - More complex deployment & orchestration required (e.g., two containers, reverse proxy).
  - For a simple application such as this, serving the React build directly from ASP.NET is simpler and avoids CORS issues in production.

### 3. Java Backend
- **Why not chosen:**
  - Due to my personal unfamiliarity with the tech stack.


## Advantages of the Chosen Approach

These decisions have resulted in:
- Clean and maintainable architecture that can be extended in the future.
- Environment that can be effectively unit tested.
- An easy to run and deploy containerised environment.

## Future Extensions

- Host the application on a cloud provider such as Azure or AWS.
- Add authentication & authorization.
- Add a database for persistence.
- Implement dynamic scaling for the frontend and backend depending on user demand.
