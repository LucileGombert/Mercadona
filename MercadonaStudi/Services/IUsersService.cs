using MercadonaStudi.ViewModels;

namespace MercadonaStudi.Services
{
    public interface IUsersService
    {

        Task<StatusViewModel> LoginAsync(LoginViewModel model);
        Task LogoutAsync();
        Task<StatusViewModel> RegisterAsync(RegistrationViewModel model);
    }
}
