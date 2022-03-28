using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using toro.Data.Entities;
using toro.Data.Interfaces;
using toro.Domain.Dto;
using toro.Domain.Interfaces;

namespace toro.Domain.Services
{
    public class GetUserPositionService : IGetUserPosition
    {
        private readonly IInvestmentRepository _investmentRepository;
        private readonly IUserValuesRepository _userValuesRepository;

        public GetUserPositionService(IInvestmentRepository investmentRepository, IUserValuesRepository userValuesRepository) 
        {
            _investmentRepository = investmentRepository;
            _userValuesRepository = userValuesRepository;
        }

        public UserPositionOutputDto GetUserPosition(int userId)
        {
            var userValues = _userValuesRepository.GetUserValuesByUserId(userId);
            var userInvestments = _investmentRepository.GetUserInvestmentsByUserId(userId);

            return GetUserPositionOutput(userValues, userInvestments);
        }

        private static UserPositionOutputDto GetUserPositionOutput(UserValues userValues, IEnumerable<Investment> userInvestments)
        {
            return new UserPositionOutputDto()
            { 
                CheckingAccountAmount = userValues.CheckingAccountAmount,
                Consolidated = userValues.Consolidated,
                Positions = userInvestments
            };
        }
    }
}
