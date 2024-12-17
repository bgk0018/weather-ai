# Ask

I'm going to explain to you a project I want to implement. Please reformat this explanation such that an LLM will be able to accurately consume the instructions:

I want to build a web dashboard that can track local weather by zipcode. It should display graphs for temperature, humidity, and percipitation.

I want to use React 18 and dotnet core 8.0 for the front and backend respectively. I want to use github actions for the yaml build and release pipelines. I want to use terraform to host the application in Azure using Container Apps.

In the dotnet API I'd like to use Entity Framework Core 8, Mediatr, minimal API and swagger. Please also include the Sieve nuget package and have tha tapplied to all GET endpoints that support returning a collection.

I don't have an opinion on what database to use, please recommend one and add it.

Please generate a Dockerfile for the api and the ui. Please generate a docker compose file that will support working locally.

Please generate a seeding script and migration project for the database as well as we'll be handling database migration by entity framework.

# Results

# Weather Dashboard Project

## Project Overview
A web-based dashboard application for tracking local weather metrics by ZIP code, featuring graphical representations of:
- Temperature
- Humidity
- Precipitation

## Technical Stack

### Frontend
- React 18
- Data visualization libraries (recommended: Chart.js or Recharts)
- Docker containerization

### Backend
- .NET Core 8.0
- Entity Framework Core 8
- MediatR for CQRS pattern
- Minimal API architecture
- Swagger/OpenAPI documentation
- Sieve for collection filtering/sorting
- Docker containerization

### Database
PostgreSQL
- Optimal for time-series data
- Strong performance for analytical queries
- Excellent Azure integration
- Built-in support for geographic data

### Infrastructure
- Azure Container Apps for hosting
- Terraform for Infrastructure as Code
- GitHub Actions for CI/CD

## Project Structure

project/
├── src/
│ ├── WeatherDashboard.Api/ # Backend API project
│ ├── WeatherDashboard.Core/ # Core business logic
│ ├── WeatherDashboard.Data/ # Data access layer
│ └── WeatherDashboard.UI/ # React frontend
├── deploy/
│ ├── terraform/ # IaC configurations
│ └── pipelines/ # GitHub Actions workflows
└── docker/
├── Dockerfile.api # API container definition
├── Dockerfile.ui # UI container definition
└── docker-compose.yml # Local development setup

## Development Setup

### Prerequisites
- .NET 8.0 SDK
- Node.js 18+
- Docker Desktop
- Azure CLI
- Terraform CLI

### Database Migrations
- Located in `WeatherDashboard.Data/Migrations`
- Managed via Entity Framework Core
- Initial seed data provided in `WeatherDashboard.Data/Seeds`

### Local Development
1. Clone repository
2. Run `docker-compose up` in root directory
3. Access:
   - Frontend: http://localhost:3000
   - Backend API: http://localhost:5000
   - Swagger UI: http://localhost:5000/swagger

## Deployment
- Infrastructure provisioned via Terraform
- Automated deployments via GitHub Actions
- Database migrations run automatically during deployment

## API Features
- RESTful endpoints for weather data
- Collection endpoints support Sieve filtering
- Swagger documentation
- CQRS pattern with MediatR