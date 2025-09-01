# 📚 LibraryWebApp

A full-stack application for managing a library, built with:
- ASP.NET Core 6 (Web API)
- Angular (Frontend)
- SQL Server (Database)

All services are containerized using Docker with separate `development` and `production` environments.

---

## 🏗️ Project Structure

```
├── LibraryWebApp/              # Backend (ASP.NET Core)
├── LibraryWebApp_Angular/      # Frontend (Angular)
├── docker-compose.yml          # Shared Docker settings
├── docker-compose.dev.yml      # Development overrides
├── docker-compose.prod.yml     # Production overrides
```

---

## 🚀 Quick Start

### 1. Create `.env` file

Use the provided `.env.example` as a template:

```bash
cp .env.example .env
```

Set your SQL Server admin password:

```env
SA_PASSWORD=Your_strong_Password123!
```

---

### 2. Start Development Environment

```bash
docker compose -f docker-compose.yml -f docker-compose.dev.yml up -d --build
```

📌 Access:
- Backend (API): [http://localhost:8080](http://localhost:8080)
- Frontend (Angular): [http://localhost:8081](http://localhost:8081)

---

### 3. Start Production Environment

```bash
docker compose -f docker-compose.yml -f docker-compose.prod.yml up -d --build
```

📌 Access:
- Backend (API): [http://localhost:4040](http://localhost:4040)
- Frontend (Angular): [http://localhost:4041](http://localhost:4041)

---

## 🧪 API Testing

When running in **development**, the following tools are available:
- **Swagger UI**: [http://localhost:8080/swagger](http://localhost:8080/swagger)
- **Health Check**: [http://localhost:8080/healthz](http://localhost:8080/healthz)

---

## 🛠️ Tech Stack

- Backend:
  - ASP.NET Core 6
  - Entity Framework Core
  - Swagger for API documentation
  - CORS configured via `appsettings`
- Frontend:
  - Angular CLI
  - Bootstrap
  - NGINX for static hosting
- Database:
  - SQL Server 2022 (Express)

---

## 📝 License

Open source & educational. Use it freely.
