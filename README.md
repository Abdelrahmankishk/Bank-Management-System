# 🏦 Bank Management System

A **C# console-based Bank Management System** built using **Entity Framework Core (EF Core)** and **SQL Server**. The application models the core banking data structure, including branches, managers, customers, bank accounts, joint account ownership, and financial transactions.

The system uses an **EF Core Code-First approach**, with Fluent API configurations, database migrations, and seeded data to establish and maintain the database schema. An interactive console interface allows users to register customers, open accounts, manage account ownership status, and view customers with their associated accounts.

## ✨ Project Highlights

- 🏦 Manage bank branches and their associated accounts
- 👔 Associate each branch with its manager
- 👥 Register individual and business customers
- 💳 Create bank accounts with automatically generated account numbers
- 🤝 Support joint accounts through a many-to-many customer-account relationship
- 🔗 Track account ownership type, ownership date, and status
- 📑 Model financial transactions and maintain account transaction records
- 🗄️ Use EF Core Code-First with SQL Server
- ⚙️ Configure entity relationships and constraints using the Fluent API
- 🔄 Manage database schema changes through EF Core migrations
- 🌱 Seed initial branches, managers, customers, accounts, ownership records
- 🧩 Separate entity models, database configuration, services, contracts, and console UI

## 🧭 System Overview

The application provides an interactive, menu-driven console interface for managing customer and account operations.

| **Option** | **Module**             | **Description**                                                                                      |
| ---------- | ---------------------- | ---------------------------------------------------------------------------------------------------- |
| `1`        | 👥 Customer Management | Register a new customer with personal or business details.                                           |
| `2`        | 💳 Account Management  | Open an account by selecting its type, branch, customer, and ownership role.                         |
| `3`        | 🔄 Account Status      | Change the status of an account ownership record between Active and Closed.                          |
| `4`        | 🔗 Account Ownership   | Remove an account association from a specific customer.                                              |
| `5`        | 📋 Customer Listing    | Display all customers alongside their accounts, ownership details, balances, and branch information. |
| `0`        | 🚪 Exit                | Exit the application.                                                                                |

The console interface validates menu selections and uses confirmation prompts for account status changes and ownership removal.

## 🏗️ Database Design and Relationships

The database follows the provided Entity Relationship Diagram (ERD) and represents the core entities of the banking system.

### 🧩 Main Entities

| **Entity**        | **Responsibility**                                                                                                               |
| ----------------- | -------------------------------------------------------------------------------------------------------------------------------- |
| `Branch`          | Stores branch information, including its unique code, name, address, and contact phone number.                                   |
| `Manager`         | Stores manager identification, name, email, phone number, and hire date.                                                         |
| `Customer`        | Represents individual customers and businesses, including their contact information, national ID, and date of birth.             |
| `Account`         | Stores account details, including the unique account number, account type, current balance, opening date, and associated branch. |
| `CustomerAccount` | Represents the relationship between customers and accounts, including ownership date, ownership type, and account status.        |
| `Transaction`     | Records transaction information, including transaction number, date, amount, type, note, and the affected account.               |

### 🔗 Entity Relationships

- **Branch–Manager (One-to-One):** Each branch is associated with one manager, and each manager belongs to one branch.
- **Branch–Account (One-to-Many):** A branch can manage multiple accounts, while each account belongs to one branch.
- **Customer–Account (Many-to-Many):** A customer can own multiple accounts, and an account can have multiple customers, supporting joint account ownership.
- **Account–Transaction (One-to-Many):** An account can have multiple transactions, with each transaction associated with a specific account.

The `CustomerAccount` entity acts as the junction entity for customer-account ownership. It stores the ownership date, ownership type (`PrimaryHolder` or `Co_Holder`), and ownership status (`Active` or `Closed`).

## 📜 Key Business Rules

The system implements the following rules across its data model and current console operations.

### 👥 Customer Management

- Each customer has a unique identification number generated by the database.
- National IDs must contain 14 digits and must be unique.
- Customers can be classified as individuals or businesses/organizations.
- Customer records include a name, national ID, date of birth, email, phone number, and address.

### 💳 Account Management

- Each account has a unique account number.
- Supported account types are Savings, Current, and Business.
- An account must belong to an existing branch.
- A customer must already be registered before being linked to an account.
- Account creation records the ownership type and ownership date.
- A single account can be shared by multiple customers.

### 🔗 Account Ownership

- Account ownership is represented by the `CustomerAccount` entity.
- Ownership records distinguish primary holders from co-holders.
- The status of a customer's relationship with an account can be changed between Active and Closed.
- Removing an account from a customer deletes the corresponding ownership record.
- If the removed ownership record was the account's last ownership link, the current implementation also deletes the account.

### 📑 Transaction Records

- Each transaction is associated with a specific account.
- Transaction records include the transaction date, amount, type, and an optional note.
- The database is designed to store transaction history for accounts.

The current console menu focuses on customer and account ownership operations. Interactive transaction creation and automatic balance updates are not currently exposed through the menu.

## ⚙️ Entity Framework Core Implementation

The project uses EF Core's Code-First workflow to define and maintain the database.

### Fluent API Configuration

Entity configurations are organized into dedicated classes implementing `IEntityTypeConfiguration<T>`. These configurations define table names, primary and alternate keys, property constraints, indexes, relationships, delete behaviors, and seeded records.

### Database Migrations

The `Migrations` folder contains the migration history used to create and evolve the database schema. When the application starts, `Program.cs` calls `Database.Migrate()` to apply pending migrations.

### Seeded Data

Initial data is configured for the following entities:

- Branches and managers
- Customers
- Accounts
- Customer-account ownership records
- Transactions

This provides a starting dataset for exploring the database and testing the available console operations.

## 🗂️ Project Structure

The project follows a single-project architecture with responsibilities separated into dedicated folders.

```text
Bank-Management-System/
│
├── Bank Management System.sln
│
└── Bank Management System/
    │
    ├── Configurations/
    │   ├── AccountConfiguration.cs
    │   ├── BranchConfiguration.cs
    │   ├── CustomersConfiguration.cs
    │   ├── ManagerConfiguration.cs
    │   └── TransactionConfiguration.cs
    │
    ├── Contracts/
    │   ├── IAccount.cs
    │   ├── IAccountDisplay.cs
    │   ├── IBranch.cs
    │   ├── ICustomer.cs
    │   ├── ICustomerAccount.cs
    │   ├── ICustomerAccountDisplay.cs
    │   └── ICustomerDisplay.cs
    │
    ├── Extentions/
    │   └── StringExtentions.cs
    │
    ├── Migrations/
    │   ├── [EF Core migration files]
    │   └── AppDbContextModelSnapshot.cs
    │
    ├── Models/
    │   ├── Enums/
    │   │   ├── AccountStatus.cs
    │   │   ├── AccountType.cs
    │   │   ├── CustomerType.cs
    │   │   ├── OwnershipType.cs
    │   │   └── TransactionType.cs
    │   │
    │   ├── Account.cs
    │   ├── Branch.cs
    │   ├── Customer.cs
    │   ├── CustomerAccount.cs
    │   ├── Manager.cs
    │   └── Transaction.cs
    │
    ├── Services/
    │   ├── AccountService.cs
    │   ├── BranchService.cs
    │   ├── CustomerAccountService.cs
    │   └── CustomerService.cs
    │
    ├── UI/
    │   ├── AccountUI.cs
    │   ├── CustomerAccountUI.cs
    │   ├── CustomerUI.cs
    │   └── MainMenu.cs
    │
    ├── files/
    │   ├── Bank Management System.docx
    │   ├── Bank System.drawio.png
    │   └── BankManagement-SQLServerSchema.png
    │
    ├── AppDbContext.cs
    ├── Program.cs
    └── Bank Management System.csproj
```

### 📁 Folder Responsibilities

| **Folder / File** | **Responsibility**                                                                                 |
| ----------------- | -------------------------------------------------------------------------------------------------- |
| `Models`          | Contains the database entity classes and enumerations.                                             |
| `Configurations`  | Defines entity mappings, relationships, constraints, and seed data.                                |
| `Migrations`      | Contains database schema changes generated by EF Core and the model snapshot.                      |
| `Contracts`       | Defines interfaces for services and console display operations.                                    |
| `Services`        | Implements customer, account, branch, and ownership-related operations.                            |
| `UI`              | Implements the interactive console interface and menu navigation.                                  |
| `Extentions`      | Contains reusable string validation extension methods.                                             |
| `AppDbContext.cs` | Configures the database connection, entity sets, model configuration, and ownership relationships. |
| `Program.cs`      | Initializes the database and wires together the services and console UI.                           |

## 🔄 Application Flow

```text
                  Program.cs
                      │
                      ▼
                  AppDbContext
                      │
                      ▼
              Apply EF Core Migrations
                      │
                      ▼
                  MainMenu
                      │
           ┌──────────┼──────────┐
           ▼          ▼          ▼
       Customer     Account    Ownership
          UI           UI          UI
           │          │          │
           └──────────┼──────────┘
                      ▼
                   Services
                      │
                      ▼
                 EF Core ORM
                      │
                      ▼
                 SQL Server
```

The UI collects user input and delegates operations to the relevant services. The services interact with `AppDbContext` to query or modify database records, while EF Core translates these operations into SQL Server commands.

## 🛠️ Technologies

- **C#**
- **.NET 8**
- **Entity Framework Core 8**
- **SQL Server**
- **EF Core Code-First**
- **Fluent API**
- **Database Migrations**
- **LINQ**
- **Console Application**

## 👨‍💻 Author

**Abdelrahman Kishk**

- GitHub: [@Abdelrahmankishk](https://github.com/Abdelrahmankishk)
