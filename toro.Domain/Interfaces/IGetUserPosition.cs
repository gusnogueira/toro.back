using toro.Domain.Dto;

namespace toro.Domain.Interfaces
{
    public interface IGetUserPosition
    {
        UserPositionOutputDto GetUserPosition(int userId);
    }
}
