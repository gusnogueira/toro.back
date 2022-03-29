using toro.Data.Entities;

namespace toro.Data.Interfaces
{
    public interface IUserValuesRepository
    {
        UserValues GetUserValuesByUserId(int userId);
    }
}
