using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using toro.Domain.Dto;

namespace toro.Domain.Interfaces
{
    public interface IGetUserPosition
    {
        UserPositionOutputDto GetUserPosition(int userId);
    }
}
