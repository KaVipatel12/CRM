namespace CRM_Api.Services.Interfaces
{
    public interface IUserContext
    {
        int? UserId { get; }
        bool IsAdmin { get; }
        bool IsSuperAdmin { get; }
    }
}
