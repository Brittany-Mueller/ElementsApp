# Periodic Elements API

A RESTful API built with .NET 9 for managing periodic elements data. This project provides a complete CRUD interface for periodic elements with Swagger documentation.

## 🚀 Features

Full CRUD operations for periodic elements
Swagger/OpenAPI documentation
HTTP status code best practices
Logging implementation
In-memory data storage
REST client testing file included

## 📋 Prerequisites

.NET 9 SDK
Visual Studio 2024 or VS Code
REST Client extension (for .http file testing)

## 🛠️ Installation

1. Clone the repository:

2. Install dependencies:bash
cd ElementsAPI
dotnet restore
3. Run the application:bash
dotnet run
The API will be available at:
HTTP: http://localhost:5278
HTTPS: https://localhost:7278
Swagger UI: http://localhost:5278/swagger

## 📚 API Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | /periodicelements | Get all elements |
| GET | /periodicelements/{position} | Get element by position |
| POST | /periodicelements | Create new element |
| PUT | /periodicelements/{position} | Update existing element |
| DELETE | /periodicelements/{position} | Delete element |

## 📝 Example Request
json
POST /periodicelements
{
    "position": 11,
    "name": "Sodium",
    "weight": 22.9897,
    "symbol": "Na"
}
## 🔍 HTTP Status Codes

200: Successful request
201: Resource created
204: No content (successful deletion)
400: Bad request
404: Resource not found
409: Conflict (duplicate position)
500: Server error

## 🧪 Testing

The project includes an ElementsAPI.http file in the root directory for testing all endpoints. You can use this with the REST Client extension in VS Code or Visual Studio.

To run tests:
1. Open ElementsAPI.http
2. Click "Send Request" above any request
3. View response in the response pane

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (git checkout -b feature/amazing-feature)
3. Commit your changes (git commit -m 'Add amazing feature')
4. Push to the branch (git push origin feature/amazing-feature)
5. Open a Pull Request

## 📄 License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details.

## 🔨 Built With

[.NET 9](https://dotnet.microsoft.com/) - The web framework used
[Swagger/OpenAPI](https://swagger.io/) - API documentation
[REST Client](https://marketplace.visualstudio.com/items?itemName=humao.rest-client) - Testing tool

## ✍️ Authors

**Brittany Mueller**
