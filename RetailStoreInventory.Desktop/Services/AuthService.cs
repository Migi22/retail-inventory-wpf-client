using System.Net.Http;
using System.Net.Http.Json;

namespace RetailStoreInventory.Desktop.Services
{
    public static class AuthService
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public static string Token { get; set; }
        public static string UserRole { get; set; }

        // Login Request method to authenticate user and get token
        public class LoginRequest
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        // Login Response class to hold token and role
        public class LoginResponse
        {
            public string Token { get; set; }
            public string Role { get; set; }
        }

        // Method to perform login and retrieve token
        public static async Task<LoginResponse> LoginAsync(string username, string password)
        {
            var request = new LoginRequest
            {
                Username = username,
                Password = password
            };

            Console.WriteLine($"Login attempt: {request.Username} / {request.Password}");

            var response = await _httpClient.PostAsJsonAsync("http://localhost:5082/api/auth/login", request);

            string raw = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Login API response: {response.StatusCode} - {raw}");

            // Handle response
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<LoginResponse>();
            }
            else
            {
                // Handle error response
                throw new Exception($"Login failed: Username or Password is incorrect. Status code {response.StatusCode}");
            }
        }

        // Attach token to HttpClient for authenticated requests
        public static void AttachToken()
        {
            if (!string.IsNullOrEmpty(Token))
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);
            }
        }
    }
}
