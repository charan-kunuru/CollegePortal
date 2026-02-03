# College Portal Application

A full-stack **College Management System** built using **ASP.NET Core** with a clean separation between UI and API layers.

---

## 📌 Project Overview

This project is designed to manage a college portal with role-based access for:

- Admin
- Teacher
- Student

It follows real-world enterprise architecture practices such as:
- MVC for UI
- Web API for backend
- JWT-based authentication
- Clean separation of concerns

---

## 🏗️ Solution Structure

```text
CollegePortal/
│
├── CollegePortal.UI/        # ASP.NET Core MVC (Frontend)
│   ├── Controllers
│   ├── Models
│   ├── Services
│   ├── Views
│   └── Program.cs
│
├── EmployeeAPI/             # ASP.NET Core Web API (Backend)
│   ├── Controllers
│   ├── Data
│   ├── DTOs
│   ├── Middlewares
│   ├── Migrations
│   └── Program.cs
│
├── CollegePortal.sln        # Solution file
├── .gitignore               # Git ignored files
└── README.md                # Project documentation
