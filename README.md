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