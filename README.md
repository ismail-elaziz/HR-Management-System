# HR Management System

A comprehensive Human Resources Management System built with ASP.NET Core MVC and Entity Framework Core.

## 📋 Overview

This HR Management System is a web application designed to manage employee and department information efficiently. It provides a user-friendly interface for performing CRUD operations on employees and departments.

## ✨ Features

- **Employee Management**
  - Add, edit, view, and delete employees
  - Store employee details including name, date of birth, salary, hire date, and national ID
  - Upload and manage employee profile images
  - Assign employees to departments

- **Department Management**
  - Create and manage departments
  - View department details
  - Edit and delete departments

- **Database Integration**
  - Uses SQL Server with Entity Framework Core
  - Automatic migrations support
  - Structured database schema with HR schema

## 🛠️ Technologies Used

- **Framework**: ASP.NET Core 8.0 MVC
- **ORM**: Entity Framework Core
- **Database**: SQL Server
- **Frontend**: 
  - Bootstrap (responsive design)
  - jQuery
  - jQuery Validation
- **Language**: C# 

## 📁 Project Structure

```
Projet_DotNetWeb/
├── Controllers/          # MVC Controllers
│   ├── EmployeController.cs
│   ├── DepartementController.cs
│   └── HomeController.cs
├── Models/              # Data models
│   ├── Employe.cs
│   ├── Departement.cs
│   └── ErrorViewModel.cs
├── Views/               # Razor views
│   ├── Employe/
│   ├── Departement/
│   ├── Home/
│   └── Shared/
├── Data/                # Database context
│   └── GestionDbContext.cs
├── Migrations/          # EF Core migrations
├── wwwroot/            # Static files (CSS, JS, Images)
└── Program.cs          # Application entry point
```

## 🚀 Getting Started

### Prerequisites

- .NET 8.0 SDK or later
- SQL Server (LocalDB, Express, or Full version)
- Visual Studio 2022 or Visual Studio Code

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/ismail-elaziz/HR-Management-System.git
   cd HR-Management-System/Projet_DotNetWeb
   ```

2. **Update Database Connection String**
   
   Edit `appsettings.json` and update the connection string:
   ```json
   {
     "ConnectionStrings": {
       "ConnectionDb": "Your-SQL-Server-Connection-String"
     }
   }
   ```

3. **Apply Database Migrations**
   ```bash
   dotnet ef database update
   ```

4. **Run the Application**
   ```bash
   dotnet run
   ```

5. **Access the Application**
   
   Open your browser and navigate to `https://localhost:5001` or the URL shown in the terminal.

## 💾 Database Schema

The application uses the following database structure under the **HR** schema:

### Employes Table
- `EmployeId` (Primary Key)
- `NomEmploye` (Last Name)
- `PrenomEmploye` (First Name)
- `UserImage` (Profile Image Path)
- `DateNaissance` (Date of Birth)
- `Salaire` (Salary)
- `DateEmbauche` (Hire Date)
- `NationalId` (National ID - 5 characters)
- `DepartementId` (Foreign Key)

### Departements Table
- `DepartementId` (Primary Key)
- `NomDepartement` (Department Name)

## 🔧 Configuration

### Adding Migrations

To create a new migration after model changes:
```bash
dotnet ef migrations add MigrationName
dotnet ef database update
```

### Development Environment

The application runs in Development mode by default. Configure environment-specific settings in:
- `appsettings.Development.json` - Development settings
- `appsettings.json` - Production settings

## 📸 Features Details

### Employee Image Upload
- Supports profile image uploads for employees
- Images are stored in `wwwroot/Images/`
- Automatic file handling and validation

### Data Validation
- Client-side and server-side validation
- Required field validation
- Format validation for dates and IDs
- Decimal precision for salary fields

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

1. Fork the project
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📝 License

This project is available for educational and personal use.

## 👤 Author

**Ismail El Aziz**
- GitHub: [@ismail-elaziz](https://github.com/ismail-elaziz)

## 🙏 Acknowledgments

- ASP.NET Core Team for the excellent framework
- Entity Framework Core for seamless database operations
- Bootstrap for responsive UI components

---

**Note**: Make sure to configure your database connection string before running the application.
