# Simple Ticketing System API

This repository contains a **Simple Ticketing System API** built using **ASP.NET Core**, **C#**, and **Entity Framework Core**. The API provides essential ticket management functionalities, enabling users to create, manage, and resolve tickets efficiently.

## Features

- **Ticket Creation**: Users can submit new tickets with descriptions, status, and priority.
- **Ticket Management**: Update or delete existing tickets.
- **Ticket Assignment**: Assign tickets to specific users.
- **Status Updates**: Track progress via ticket statuses (Open, In Progress, Resolved).
- **Entity Framework Core Integration**: Efficient database handling with migrations.

## Technologies Used

- **ASP.NET Core**: For building the web API.
- **C#**: Main programming language.
- **Entity Framework Core**: ORM for database interactions.
- **SQL Server**: Database for storing tickets and users.

## Getting Started

### Prerequisites

Before running the project, ensure you have the following installed:

- **.NET SDK** (v6.0 or later)
- **SQL Server** (or any compatible SQL database)

### Installation

1. **Clone the repository**:
   ```bash
   git clone https://github.com/UcheTheo/SimpleTicketingAPI.git
   cd SimpleTicketingAPI
   ```

2. **Restore dependencies**:
   ```bash
   dotnet restore
   ```

3. **Set up the database**:
   - Update the connection string in `appsettings.json` to match your database setup.
   - Run migrations to set up the database schema:
     ```bash
     dotnet ef database update
     ```

4. **Run the application**:
   ```bash
   dotnet run
   ```

   The API will be available at `http://localhost:5000`.

### Endpoints

#### Tickets
- **GET** `/api/tickets`: Retrieve all tickets.
- **GET** `/api/tickets/{id}`: Retrieve a specific ticket by ID.
- **POST** `/api/tickets`: Create a new ticket.
- **PUT** `/api/tickets/{id}`: Update an existing ticket.
- **DELETE** `/api/tickets/{id}`: Delete a ticket.

#### Users
- **GET** `/api/users`: Retrieve all users.
- **POST** `/api/users`: Create a new user.

### Example Request

```http
POST /api/tickets
Content-Type: application/json

{
  "title": "Login Issue",
  "description": "User unable to login",
  "status": "Open",
  "priority": "High"
}
```

### Database Setup

- The API uses **Entity Framework Core** for data management. Run the following commands to handle migrations and database updates:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

## Project Structure

```bash
├── Controllers/         # API Controllers for Tickets and Users
├── Data/                # Database context and EF configurations
├── Models/              # Domain models (Ticket, User)
├── Repositories/        # Data access layer
├── Migrations/          # EF Core migrations
├── appsettings.json     # Configuration file
├── Program.cs           # Main application entry point
└── README.md            # Project documentation
```

## Contributing

Contributions are welcome! Please follow these steps:

1. Fork the repository.
2. Create a new feature branch.
3. Commit your changes.
4. Push to the branch and submit a pull request.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more information.
