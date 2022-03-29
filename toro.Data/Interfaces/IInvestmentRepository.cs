using System.Collections.Generic;
using toro.Data.Entities;

namespace toro.Data.Interfaces
{
    public interface IInvestmentRepository
    {
        IEnumerable<Investment> GetUserInvestmentsByUserId(int userId);
    }
}
