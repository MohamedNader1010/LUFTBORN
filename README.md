# Luftborn API

Backend API for the Luftborn application, secured with Keycloak SSO. This service issues and validates JWT bearer tokens against a Keycloak realm; the Angular client will own the interactive login redirect in a later phase.

## Overview

- **Auth model:** JWT Bearer (not cookie/OIDC redirect) — the API validates tokens issued by Keycloak
- **Identity provider:** Keycloak, realm `LUFTBORN`
- **Client:** `luftborn-api`

## Prerequisites

- .NET SDK (matching the project's target framework)
- Docker & Docker Compose (for running Keycloak + Postgres locally)

## Local Setup

### 1. Start Keycloak

Keycloak runs via Docker Compose (Postgres + `quay.io/keycloak/keycloak:26.0.8`, `start-dev` mode):

```bash
docker-compose up -d
```

- Hostname: `localhost`
- Port: `8081`

### 2. Keycloak Realm Configuration

Realm: **LUFTBORN**
Client ID: **luftborn-api**

Key settings already configured:

- **Valid Redirect URIs:**
  - `http://localhost:5519/signin-oidc`
  - `https://localhost:44365/signin-oidc`
- **Valid Post-Logout Redirect URIs / Web Origins:**
  - `https://localhost:44365`
  - `http://localhost:5519`
- **Audience:** a standalone client scope `luftborn-audience` with an Audience mapper targeting `luftborn-api`, attached as a **Default** client scope
  - ⚠️ The mapper must be set to add the audience to the **access token**, not the ID token — this was the root cause of an earlier audience-mismatch failure.

### 3. API Configuration (`appsettings.json`)

The Keycloak section includes:

- `Authority`
- `ClientId`
- `ClientSecret`
- `MetadataAddress`
- `DefaultReturnUrl` → points to Swagger

### 4. Run the API

Application URLs:

- `https://localhost:7250`
- `http://localhost:5001`

```bash
dotnet run
```

Swagger UI will be available at the configured `DefaultReturnUrl`.

## Auth Flow

Verified end-to-end:

1. Request without a token → `401 Unauthorized`
2. Token issuance via password grant against Keycloak
3. `ValidateAudience = true` enforced
4. Request with a valid token → `200 OK`

## Roadmap

- [ ] Build the Angular SSO client (using `angular-auth-oidc-client` or `angular-oauth2-oidc`) against the same `LUFTBORN` realm and `luftborn-api` client

## Notes

- The Angular app will handle the login redirect flow; this API only validates bearer tokens.
