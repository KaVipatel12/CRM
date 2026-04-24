using CRM_Api.Models.Entities.Utilities;

namespace CRM_Api.Services.Interfaces
{
    public interface IPasswordManagerService
    {
        Task<IEnumerable<PasswordManager>> GetPasswordsAsync();
        Task<PasswordManager?> GetPasswordByIdAsync(int id);
        Task<PasswordManager> SavePasswordAsync(PasswordManager passwordManager);
        Task<bool> DeletePasswordAsync(int id);
        
        Task<bool> VerifyMasterPasswordAsync(string password);
        Task<bool> SetMasterPasswordAsync(string password);
        Task<bool> IsMasterPasswordSetAsync();
    }
}
