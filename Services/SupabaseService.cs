using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace TestConsole.Services
{
    public class SupabaseService
    {
        private readonly HttpClient _http;
        private readonly string _url;

        public SupabaseService(IConfiguration config)
        {
            // Try IConfiguration first, then fallback to environment variables
            _url = config["SUPABASE_URL"]?.TrimEnd('/')
                   ?? Environment.GetEnvironmentVariable("SUPABASE_URL")?.TrimEnd('/')
                 ?? TryLoadFromDotEnv("SUPABASE_URL")?.TrimEnd('/')
                 ?? throw new InvalidOperationException("SUPABASE_URL not set");
            var key = config["SUPABASE_SECRET_KEY"]
                      ?? Environment.GetEnvironmentVariable("SUPABASE_SECRET_KEY")
                 ?? TryLoadFromDotEnv("SUPABASE_SECRET_KEY")
                 ?? throw new InvalidOperationException("SUPABASE_SECRET_KEY not set");

            _http = new HttpClient();
            _http.BaseAddress = new Uri(_url);
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", key);
            _http.DefaultRequestHeaders.Add("apikey", key);
            _http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
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

        public async Task<(bool Success, int StatusCode, string Body, JsonElement? Json)> GetTableAsync(string table)
        {
            var resp = await _http.GetAsync($"/rest/v1/{table}?select=*");
            var status = (int)resp.StatusCode;
            string body = string.Empty;
            JsonElement? json = null;
            try
            {
                body = await resp.Content.ReadAsStringAsync();
                if (resp.Content.Headers.ContentType?.MediaType == "application/json" && !string.IsNullOrWhiteSpace(body))
                {
                    using var doc = JsonDocument.Parse(body);
                    json = doc.RootElement.Clone();
                }
            }
            catch { }

            return (resp.IsSuccessStatusCode, status, body, json);
        }
    }
}
