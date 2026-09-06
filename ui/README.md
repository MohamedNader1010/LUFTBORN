# Luftborn – Angular UI

Angular front-end for the Luftborn technical test, using SSO authentication via Keycloak against the Luftborn API.

## Project Structure

The app follows a `core / feature / shared / layout` structure:

```
src/app/
├── core/          # Singleton services, guards, interceptors, app-wide config
├── features/      # Feature modules/components (e.g. users)
├── shared/        # Reusable components, pipes, directives shared across features
├── layouts/       # Application shell layout(s)
```

### Layout

There is a single main layout component (`MainLayoutComponent`) that all pages inherit from. It contains:

- **Header**
- **Sidebar**
- **Backdrop** (for mobile/overlay sidebar behavior)

All routed pages render inside this shell.

### Interceptors

Four HTTP interceptors are registered under `core/`:

| Interceptor | Responsibility |
|---|---|
| **Logger** | Logs outgoing requests / incoming responses |
| **Loader** | Toggles a global loading indicator during in-flight requests |
| **Error** | Centralized HTTP error handling (e.g. toast notifications, redirects) |
| **Auth** | Attaches the access token to outgoing requests |

## Authentication

Authentication is handled via **SSO with Keycloak**, integrated against the same `LUFTBORN` realm and `luftborn-api` client used by the backend.

## Features

- Simple CRUD for the **Users** feature (list, create, edit).
- Route-level permission guards (`permissionGuard`) controlling access per action (e.g. `User.Get`, `User.Create`, `User.Update`).

## Styling

Styled with **Tailwind CSS**.

## Getting Started

```bash
npm install
ng serve
```

The app will be available at `http://localhost:4200` (or as configured).

## Backend

This UI expects the Luftborn API to be running and reachable, with Keycloak configured for the `LUFTBORN` realm. See the `backend/` folder in this repo for API setup.
