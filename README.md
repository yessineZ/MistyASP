MistyWeb
MistyWeb is a web application for managing games with built-in user authentication and authorization. It allows users to perform CRUD (Create, Read, Update, Delete) operations on game entities after registering and logging in. The application is built using ASP.NET Core MVC, Entity Framework Core for database operations, and ASP.NET Core Identity for user management.

Features:
CRUD Operations: Registered users can create, read, update, and delete game entities.
Image Upload: Users can upload images for each game.
Validation: Input validation ensures data integrity and prevents invalid data entry.
User Authentication: Secure user authentication using ASP.NET Core Identity.
Role-based Authorization: Different user roles (e.g., admin, regular user) with access control to specific features.
Responsive Design: The application is responsive and works well on various devices and screen sizes.
Technologies Used:
ASP.NET Core MVC: Framework for building web applications.
Entity Framework Core: Object-Relational Mapping (ORM) framework for database operations.
ASP.NET Core Identity: Authentication and authorization framework for managing users.
Bootstrap: Front-end framework for designing responsive and mobile-first websites.
C#: Programming language used for server-side development.
HTML/CSS: Markup and styling languages for web development.
Usage:
Clone the repository: git clone https://github.com/yourusername/MistyWeb.git
Navigate to the project directory: cd MistyWeb
Restore dependencies: dotnet restore
Update database: dotnet ef database update
Run the application: dotnet run
Access the application in your web browser at https://localhost:5001
Feel free to explore the code and contribute to the project by submitting pull requests!
