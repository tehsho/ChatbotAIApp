// README.md
/*
# Chatbot AI Backend (ASP.NET Core 8)

## Description
This is a simplified backend for a chatbot application using ASP.NET Core 8. 
It supports user authentication, stores messages exchanged with the AI, and uses a simulated AI service.

## Features
- User login
- Message persistence
- Simulated AI response
- Clean architecture with SOLID principles

## Tech Stack
- ASP.NET Core 8
- C#
- SQL Server
- Swagger for API documentation

## How to Run
1. Clone the repository
2. Update `appsettings.json` with your SQL Server connection string
3. Run the project:
   ```bash
   dotnet run
   ```
4. Open Swagger UI at `https://localhost:<port>/swagger`

## API Endpoints
- `POST /api/auth/login` – Login and authenticate a user
- `POST /api/chat/ask` – Ask a question and get AI response

## Notes
- AI responses are simulated. Replace the mock logic in `ChatService.cs` with actual OpenAI API integration if needed.
*/
