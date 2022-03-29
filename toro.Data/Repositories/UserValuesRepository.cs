using toro.Data.Entities;
using toro.Data.Interfaces;

namespace toro.Data.Repositories
{
    public class UserValuesRepository : IUserValuesRepository
    {
        public UserValuesRepository() {}

        public UserValues GetUserValuesByUserId(int userId)
        {
            return new UserValues()
            {
                CheckingAccountAmount = 100,
                Consolidated = 2529.80
            };
        }
    }
}
