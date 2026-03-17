# Enterprise Backend System – Clean Architecture

## 📌 Project Overview
This repository contains a high-standard Web API built with **.NET Core**, demonstrating professional software engineering through **Clean Architecture**. The system handles task management with complex data relationships and secure authentication.

## 🏗️ Architecture Layers
The solution is divided into 4 distinct projects to ensure a separation of concerns:
* **clean.Core (Domain & Application):** Defines core entities (`User`, `UserProfile`, `Category`, `TaskItem`), repository interfaces, and business logic.
* **clean.Data (Infrastructure):** Implements data persistence using **Entity Framework Core** and **SQL Server**.
* **clean.API (Presentation):** Handles HTTP requests, JWT authentication, and custom middlewares like `ShabbatMiddleware`.
* **Mapping & DTOs:** Uses **AutoMapper** to transform Entities into Data Transfer Objects for secure API communication.

## 📊 Database Schema
* **User ↔ UserProfile:** 1:1 Relationship.
* **User ↔ TaskItem:** 1:N Relationship.
* **Category ↔ TaskItem:** 1:N Relationship.

## 🚀 Key Technologies
* **.NET Core Web API** & **C#**
* **Entity Framework Core** (Code-First)
* **AutoMapper** (DTO Pattern)
* **JWT Bearer** Authentication
* **Dependency Injection** & **Middlewares**

## 🛠️ Setup
1. Clone the repo.
2. Configure your connection string in `appsettings.json` or User Secrets.
3. Run `dotnet ef database update`.
4. Run the project and explore via **Swagger**.