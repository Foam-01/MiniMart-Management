using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace TestConsole.Services
{
    public class SupabaseService
    {
        private readonly string _connectionString;

        public SupabaseService(IConfiguration config)
        {
            var rawConnectionString = config["DB_CONNECTION_STRING"]
                ?? Environment.GetEnvironmentVariable("DB_CONNECTION_STRING")
                ?? TryLoadFromDotEnv("DB_CONNECTION_STRING")
                ?? config["DATABASE_URL"]
                ?? Environment.GetEnvironmentVariable("DATABASE_URL")
                ?? TryLoadFromDotEnv("DATABASE_URL")
                ?? "Host=aws-0-ap-southeast-1.pooler.supabase.com;Port=6543;Database=postgres;Username=postgres.yafhubewsksmkwnektxj;Password=As0850505437;SSL Mode=Require;Trust Server Certificate=true";

            _connectionString = ConvertPostgresUriToConnectionString(rawConnectionString);
        }

        private static string ConvertPostgresUriToConnectionString(string uriString)
        {
            if (string.IsNullOrWhiteSpace(uriString)) return uriString;
            if (!uriString.StartsWith("postgresql://", StringComparison.OrdinalIgnoreCase) && 
                !uriString.StartsWith("postgres://", StringComparison.OrdinalIgnoreCase))
            {
                return uriString;
            }

            try
            {
                var uri = new Uri(uriString);
                var userInfo = uri.UserInfo.Split(':');
                var username = userInfo[0];
                var password = userInfo.Length > 1 ? Uri.UnescapeDataString(userInfo[1]) : "";
                var host = uri.Host;
                var port = uri.Port == -1 ? 5432 : uri.Port;
                var database = uri.AbsolutePath.TrimStart('/');

                return $"Host={host};Port={port};Database={database};Username={username};Password={password};SSL Mode=Require;Trust Server Certificate=true";
            }
            catch
            {
                return uriString;
            }
        }

        private static string? TryLoadFromDotEnv(string key)
        {
            try
            {
                var dir = Directory.GetCurrentDirectory();
                for (int i = 0; i < 5 && dir != null; i++)
                {
                    var path = Path.Combine(dir, ".env");
                    if (File.Exists(path))
                    {
                        var lines = File.ReadAllLines(path);
                        foreach (var line in lines)
                        {
                            var t = line.Split('=', 2);
                            if (t.Length == 2)
                            {
                                var k = t[0].Trim();
                                var v = t[1].Trim();
                                if (string.Equals(k, key, StringComparison.OrdinalIgnoreCase))
                                    return v;
                            }
                        }
                    }
                    var parent = Directory.GetParent(dir);
                    dir = parent?.FullName;
                }
            }
            catch { }
            return null;
        }

        public async Task<(bool Success, string Message, string? Detail)> TestConnectionAsync()
        {
            try
            {
                using var conn = new NpgsqlConnection(_connectionString);
                await conn.OpenAsync();

                using var cmd = new NpgsqlCommand("SELECT 1;", conn);
                await cmd.ExecuteScalarAsync();

                return (true, "Connected successfully to Supabase Database!", null);
            }
            catch (NpgsqlException ex)
            {
                var builder = new NpgsqlConnectionStringBuilder(_connectionString);
                var masked = $"Host={builder.Host};Port={builder.Port};Database={builder.Database};Username={builder.Username};Password=***";
                return (false, "PostgreSQL Connection Error", $"ErrorCode: {ex.SqlState}, Message: {ex.Message}, Connection Info: {masked}");
            }
            catch (Exception ex)
            {
                string masked;
                try
                {
                    var builder = new NpgsqlConnectionStringBuilder(_connectionString);
                    masked = $"Host={builder.Host};Port={builder.Port};Database={builder.Database};Username={builder.Username};Password=***";
                }
                catch
                {
                    masked = "Invalid Connection String format";
                }
                return (false, "Connection Failed", $"Error: {ex.Message}, Connection Info: {masked}");
            }
        }
    }
}
