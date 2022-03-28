using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using toro.Data.Entities;

namespace toro.Data.Interfaces
{
    public interface IUserValuesRepository
    {
        UserValues GetUserValuesByUserId(int userId);
    }
}
