
# Tech Store

A full-stack e-commerce platform for a technology retail brand, designed to showcase modern frontend and backend development practices.

## Project Goal
The goal of Tech Store is to create a complete online shopping experience for tech products, combining a responsive storefront with a robust backend API and database-driven product management.

## Stack
- Frontend:React, Vite, JavaScript
- Routing: React Router
- Styling: SCSS
- Backend: ASP.NET Core Web API
- Database: PostgreSQL
- ORM: Entity Framework Core
- Authentication: JWT
- State management: React context

## Key Features
- Product catalog and detail pages
- Search and category filtering
- Shopping cart functionality
- Checkout process
- Admin panel for product and sales management
- Secure authentication with JWT tokens
- REST API communication between frontend and backend

## Architecture
The application follows a modern full-stack structure:
- Frontend handles user interaction and UI rendering
- Backend exposes REST endpoints for product, category, order, and authentication logic
- PostgreSQL stores application data
- EF Core manages database access and migrations

## Why This Project
This project was built to demonstrate:
- full-stack application development
- API integration
- database design and data handling
- responsive UI development
- authentication and authorization concepts
- e-commerce workflow implementation

## Project Status
In active development as a portfolio project focused on practical application of full-stack web development skills.

## Setup
### Frontend
```bash
cd mood/frontend
pnpm install
pnpm dev
#### Backend
```bash
cd mood/WebApi/WebApi
dotnet restore
dotnet run
Update PostgreSQL configuration in:
WebApi/WebApi/appsettings.Development.json