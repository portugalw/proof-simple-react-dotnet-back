# Proof Simple React + .NET Backend

A simple full-stack proof of concept combining a **React frontend** with an **ASP.NET Core Web API backend**.
This project is intended as a technical demonstration of how to structure, run, and integrate a React application with a .NET backend.

---

## 📌 Project Overview

This repository contains a basic full-stack setup with:

* A **React** frontend application
* A **.NET (ASP.NET Core)** backend API

The goal is to demonstrate:

* Frontend and backend separation
* REST API communication
* Dependency management with **npm** and **NuGet**
* Local development setup

---

## 🛠 Tech Stack

### Backend

* ASP.NET Core Web API
* .NET SDK (6 / 7 / 8)
* NuGet (package manager)

### Frontend

* React
* Node.js
* npm or Yarn

### Other

* Git & GitHub

---

## 📦 Prerequisites

Make sure you have the following installed on your machine:

* **Git**
  [https://git-scm.com/](https://git-scm.com/)

* **Node.js (LTS recommended)**
  [https://nodejs.org/](https://nodejs.org/)

* **.NET SDK**
  [https://dotnet.microsoft.com/download](https://dotnet.microsoft.com/download)

Verify installations:

```bash
git --version
node --version
npm --version
dotnet --version
```

---

## 🚀 Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/portugalw/proof-simple-react-dotnet-back.git
cd proof-simple-react-dotnet-back
```

---

## ⚙️ Backend Setup (ASP.NET Core)

> Adjust folder names if your backend is in a different directory.

### 1. Navigate to the Backend Folder

```bash
cd backend
```

### 2. Restore NuGet Packages

```bash
dotnet restore
```

This command downloads all required NuGet dependencies defined in the `.csproj` file.

### 3. Build the Project

```bash
dotnet build
```

### 4. Run the API

```bash
dotnet run
```

The API will typically start at:

* `https://localhost:5001`
* or `http://localhost:5000`

---

## 📦 Frontend Setup (React)

### 1. Navigate to the Frontend Folder

```bash
cd frontend
```

### 2. Install Dependencies

```bash
npm install
# or
yarn install
```

### 3. Start the Development Server

```bash
npm start
# or
yarn start
```

The React application will be available at:

```
http://localhost:3000
```

---

## 🔄 Running the Full Application

Open **two terminals**:

### Terminal 1 – Backend

```bash
cd backend
dotnet run
```

### Terminal 2 – Frontend

```bash
cd frontend
npm start
```

---

## 📄 API Endpoints

Document your API endpoints here when implemented.

Example:

| Method | Endpoint      | Description       |
| -----: | ------------- | ----------------- |
|    GET | `/api/health` | Health check      |
|    GET | `/api/items`  | List items        |
|   POST | `/api/items`  | Create a new item |

---

## 🧪 Tests

### Backend Tests

```bash
dotnet test
```

### Frontend Tests

```bash
npm test
```

---

## 🤝 Contributing

Contributions are welcome!

1. Fork the repository
2. Create a new branch

   ```bash
   git checkout -b feature/my-feature
   ```
3. Commit your changes

   ```bash
   git commit -m "Add my feature"
   ```
4. Push to your branch

   ```bash
   git push origin feature/my-feature
   ```
5. Open a Pull Request

---

## 📄 License

This project is licensed under the **MIT License**.
See the `LICENSE` file for more information.

---

## 📬 Contact

Maintained by **Washington Portugal**
GitHub: [https://github.com/portugalw](https://github.com/portugalw)
