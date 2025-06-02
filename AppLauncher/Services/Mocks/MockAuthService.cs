using AppLauncher.Contracts;

namespace AppLauncher.Services
{

    public class MockAuthService : IAuthService
    {
        private bool isAuthenticated = false;

        public bool IsAuthenticated => isAuthenticated;

        public async Task<bool> LoginAsync(string username, string password)
        {
            await Task.Delay(500);

            if (username == "admin" && password == "admin")
            {
                isAuthenticated = true;
                return true;
            }

            isAuthenticated = false;
            return false;
        }

        public Task LogoutAsync()
        {
            isAuthenticated = false;
            return Task.CompletedTask;
        }
    }
}