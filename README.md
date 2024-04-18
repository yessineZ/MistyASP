# MistyWeb

MistyWeb is a web application for managing games with built-in user authentication and authorization. It allows users to perform CRUD (Create, Read, Update, Delete) operations on game entities after registering and logging in. The application is built using ASP.NET Core MVC, Entity Framework Core for database operations, and ASP.NET Core Identity for user management.

## Features:
- **CRUD Operations**: Registered users can create, read, update, and delete game entities.
- **Image Upload**: Users can upload images for each game.
- **Validation**: Input validation ensures data integrity and prevents invalid data entry.
- **User Authentication**: Secure user authentication using ASP.NET Core Identity.
- **Responsive Design**: The application is responsive and works well on various devices and screen sizes.

## Technologies Used:
- ASP.NET Core MVC
- Entity Framework Core
- ASP.NET Core Identity
- Bootstrap
- C#
- HTML/CSS

## Design:
Here are some screenshots of the MistyWeb application:

![Screenshot 1](/screenshots/screenshot1.png)
![Screenshot 2](/screenshots/screenshot2.png)
...

## Usage:
1. Clone the repository: `git clone https://github.com/yourusername/MistyWeb.git`
2. Navigate to the project directory: `cd MistyWeb`
3. Restore dependencies: `dotnet restore`
4. Update database: `dotnet ef database update`
5. Run the application: `dotnet run`
6. Access the application in your web browser at [https://localhost:5001](https://localhost:5001)

Feel free to explore the code and contribute to the project by submitting pull requests!
