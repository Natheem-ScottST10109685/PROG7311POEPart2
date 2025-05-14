Here’s a **README.md** file for my Prog7311POEPart2:

1. Download the zip file.
2. Extract the file into a folder or onto your desktop.
3. Open Folder via Visual Studio.
4. Run and debug the program.

```
# Agri-Energy Connect

Agri-Energy Connect is a web-based platform designed to support and streamline operations between Farmers and Employees in the agri-energy sector. The system enables product management, profile creation, collaboration, and training access through user-friendly dashboards.

## Features

### 🧑‍🌾 Farmer Features
- **Dashboard Access:** Farmers can view available training material, forums, and personal products.
- **Product Management:** Farmers can view their products with dates and categories.
- **Training Access:** Resources available to help with farming and energy knowledge.
- **Community Forums:** Platform for discussion and knowledge sharing.

### 👨‍💼 Employee Features
- **Employee Dashboard:** Employees can manage and filter farmer products.
- **Farmer Profile Registration:** Employees can register farmers (Farmers do not register themselves).
- **Farmer Filtering Tools:** Employees can view farmer products filtered by category.
- **Collaboration Tools:** Forum access and training materials to support farmers.

## Technologies Used

- **.NET Core MVC**
- **C#**
- **Entity Framework Core**
- **Microsoft SQL Server**
- **Bootstrap & Razor Views**
- **Azure Storage (if integrated)**
```

## Project Structure

ST10109685Prog7311/
│
├── Controllers/
│ ├── AccountController.cs
│ ├── DashboardController.cs
│ ├── EmployeeController.cs
│ ├── FarmerController.cs
│ └── HomeController.cs
│
├── Data/
│ └── UserDbContext.cs
│
├── Helpers/
│ └── PasswordHelper.cs
│
├── Models/
│ ├── ErrorViewModel.cs
│ ├── LoginViewModel.cs
│ ├── Product.cs
│ ├── RegisterModel.cs
│ └── UserModel.cs
│
├── Views/
│ ├── Account/
│ │ ├── Login.cshtml
│ │ └── Register.cshtml
│ │
│ ├── Dashboard/
│ │ ├── Collaboration.cshtml
│ │ ├── EmployeeDash.cshtml
│ │ ├── FarmerDash.cshtml
│ │ └── Training.cshtml
│ │
│ ├── Employee/
│ │ ├── AddFarmer.cshtml
│ │ └── ManageProducts.cshtml
│ │
│ ├── Farmer/
│ │ ├── EditProduct.cshtml
│ │ └── MyProducts.cshtml
│ │
│ ├── Home/
│ │ ├── Index.cshtml
│ │ └── Privacy.cshtml
│ │
│ └── Shared/
│ └── (Layout, partials, etc.)
│
├── wwwroot/
│ └── (CSS, JS, images)
│
└── README.md

```

## How to Run the Project

1. **Clone the Repository**
   ```bash
   git clone https://github.com/yourusername/agri-energy-connect.git
````

2. **Open the Solution in Visual Studio**

3. **Update Database Connection String**
   Edit `appsettings.json` with your SQL Server connection string.

4. **Apply Migrations**

   ```bash
   dotnet ef database update
   ```

5. **Run the Application**
   Press `F5` or use:

   ```bash
   dotnet run
   ```

## Usage Instructions

* **Login:** Roles are determined at registration.
* **Employees:** Can add Farmers via the "Add Farmer" form.
* **Farmers:** Will be added by Employees, and log in with provided credentials. OR can register themselves and select the Farmer Role.
* **Product Pages:** Accessible by roles with filtering options.

## Notes

* Only **Employees** can register **Farmers**.
* Farmers are restricted to their own data.
* Employee dashboards provide oversight and tools for managing multiple farmers.

## License

This project is for Marks.

Thank You chat for adding this.
![image](https://github.com/user-attachments/assets/87bf1a67-e867-445c-b8e7-6fa00a6c332a)
![image](https://github.com/user-attachments/assets/5df676ec-c780-4aa0-a498-33024be283fa)
![image](https://github.com/user-attachments/assets/327bbd3a-e2b7-4d15-b9e6-bcfee5048575)
![image](https://github.com/user-attachments/assets/15100396-1d9e-4119-8eca-29ae3e158df7)

