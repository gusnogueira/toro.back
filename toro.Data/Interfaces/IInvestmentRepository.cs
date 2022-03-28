using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using toro.Data.Entities;

namespace toro.Data.Interfaces
{
    public interface IInvestmentRepository
    {
        IEnumerable<Investment> GetUserInvestmentsByUserId(int userId);
    }
}
