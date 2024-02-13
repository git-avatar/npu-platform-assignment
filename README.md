# Nice Part Usage - Social Platform

## Description

This project is developed as part of an assignment. It comprises three main services: authentication, NPU (Nice Part Usage), and scores. The platform allows users to create NPUs and provide scores for various creations.

## Models Relationship

- Each user can have multiple NPU creations (one-to-many relationship between User and NPU).
- Each NPU creation belongs to one user (many-to-one relationship between NPU and User).
- Each NPU creation can have multiple scores from different users (one-to-many relationship between NPU and Score).
- Each score is associated with one NPU creation and one user (many-to-one relationship between Score and NPU/User).

## Services

### 1. Authentication Service
- Responsible for user authentication and authorization.
- Manages user registration, login, roles, and token generation.

### 2. NPU Service
- Handles the creation, management, and retrieval of NPU creations.
- Allows users to upload images, element name and descriptions for their NPUs.

### 3. Score Service
- Facilitates the scoring functionality for NPUs where users can provide scores.
- Supports CRUD operations for scores and gives the average score per NPU.

## Technologies Used

- ASP.NET Core for building the backend services.
- Entity Framework Core for database management and ORM.
- JWT (JSON Web Tokens) for secure authentication and authorization.
- Azure Blob Storage for storing images uploaded by users.
- SQL Server for database storage.
- AutoMapper for object-to-object mapping.

## How to Run

1. Clone the repository to your local machine.
2. Navigate to each service's directory (auth, npu, score) and run `dotnet build` to build the project.
3. Configure the connection strings for the database and Azure Blob Storage (must have your own subscription) in the `appsettings.json`.
4. Run `dotnet run` to start each service.
5. Access the APIs using tools like Postman or Swagger UI.
6. You can use the frontend for the login and registration. 

## Contributor

- Aleksandar Penchikj


