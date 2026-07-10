# MiniMart-Management (Supabase example)

This project includes a simple `SupabaseService` and `SupabaseController` to demonstrate server-side access to Supabase REST (PostgREST).

## Setup

1. Copy `.env.example` to `.env` and fill in your Supabase values:

```
SUPABASE_URL=https://your-project.supabase.co
SUPABASE_PUBLISHABLE_KEY=sb_publishable_...
SUPABASE_SECRET_KEY=sb_secret_...
SUPABASE_JWKS_URL=https://your-project.supabase.co/auth/v1/.well-known/jwks.json
```

2. Run the app (the project is configured to load `.env` automatically):

```bash
dotnet run
```

3. Open Swagger UI:

```
http://localhost:5000/swagger
```

4. Test the Supabase endpoint (replace `{table}` with your table name):

```
GET /Supabase/{table}
```

Or use curl:

```bash
curl http://localhost:5000/Supabase/users
```

## Notes

- Use the `service_role` key for server-side operations. Keep it secret.
- If your tables use Row Level Security (RLS), ensure the service role or proper policies are used.
- `.env` is loaded at startup using `DotNetEnv` so you can keep secrets in the `.env` file during local development.

## Next steps

- Add CRUD endpoints or authentication verification using `SUPABASE_JWKS_URL`.
- Add logging and error handling improvements.
