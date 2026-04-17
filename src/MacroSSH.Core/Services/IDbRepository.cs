//interface contracta for database repository

namespace MacroSSH.Core.Repositories;

public interface IDbRepository
{
    Task<string> TestConnection();
}