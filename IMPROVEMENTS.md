# IMPROVEMENTS.md

> **Project:** OpenLibrary – ASP.NET Core Web API wrapper
> **Goal:** Raise code quality, reliability, performance, and DevOps maturity while keeping the project simple and maintainable.

---

## 1) Architecture & Structure

**Current (assumed):** Single ASP.NET Core Web API project calling the public Open Library API.

**Improvements**
- **Layering / Folders**
  - `OpenLibrary.Api` (controllers, filters, DI, middleware)
  - `OpenLibrary.Application` (interfaces, DTOs, validation)
  - `OpenLibrary.Infrastructure` (HTTP clients, caching, persistence if added later)
  - `OpenLibrary.Tests` (unit/integration tests)
- **HttpClientFactory** with named/typed clients for Open Library, enabling connection pooling and resilience.
- **Global exception handling** middleware returning **RFC 7807 ProblemDetails** consistently.
- **API Versioning** (e.g., `v1`, `v2`) to evolve without breaking clients.

**ASCII sketch**

## 2) API Design & Contracts
- Use **controller-based** or **minimal APIs** consistently (controller-based recommended here).
- Add **query parameters** for pagination (`page`, `pageSize`), filtering, and sorting where applicable.
- Provide **example responses** and **tags** in Swagger.

**ProblemDetails example**
```json
{
  "type": "https://httpstatuses.com/504",
  "title": "Gateway Timeout",
  "status": 504,
  "traceId": "00-5c9f...",
  "detail": "Open Library did not respond within 5s"
}

3) Validation

Use FluentValidation or data annotations for request DTOs.
Add a pipeline behavior/filter to return 400 with detailed validation errors.

4) Resilience & Performance
breaker.
Caching: In-memory cache for common queries; use cache keys based on request parameters. Configure TTL (e.g., 5–15 min) and cache invalidation strategy.
Async all the way; avoid blocking calls.
RateLimiter to shield upstream and our API (token bucket/sliding window).

5) Observability

Structured logging with Serilog (JSON sink for production).
Add Correlation/Trace Id middleware; log it and return in responses.
OpenTelemetry (optional): traces + metrics; export to Application Insights or OTLP.
Health checks: /health/ready (checks outbound Open Library), /health/live (basic).

6) Security & Compliance

HTTPS only;
Headers: Add security headers (X-Content-Type-Options, X-Frame-Options/DENY, X-XSS-Protection, Content-Security-Policy if applicable).
Authentication/Authorization (if needed): JWT Bearer with role-based policies.
Secrets: Use dotnet user-secrets for local; GitHub Actions secrets/Azure Key Vault for CI/CD.

7) Documentation

Keep README.md focused on quick start.
This IMPROVEMENTS.md as backlog/roadmap.
Swagger/OpenAPI with contact, license, and external docs links.

8) Testing Strategy

Unit tests: application services, mappers, validators.
Performance tests (optional): k6/Locust scenarios for key endpoints.
