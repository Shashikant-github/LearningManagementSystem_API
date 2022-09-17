namespace UserAPI.Services
{
    public interface ITokenGeneratorService
    {
        string GenerateToken(int userID, string userName, bool userRole);
    }
}
