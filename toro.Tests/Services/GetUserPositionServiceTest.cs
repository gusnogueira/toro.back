using Moq;
using System.Collections.Generic;
using toro.Data.Entities;
using toro.Data.Interfaces;
using toro.Domain.Services;
using Xunit;

namespace toro.Tests
{
    public class GetUserPositionServiceTest
    {

        private readonly GetUserPositionService userPositionService;
        private readonly Mock<IInvestmentRepository> investmentRepositoryMock;
        private readonly Mock<IUserValuesRepository> userValuesRepositoryMock;

        public GetUserPositionServiceTest()
        {
            investmentRepositoryMock = new Mock<IInvestmentRepository>();
            userValuesRepositoryMock = new Mock<IUserValuesRepository>();
            userPositionService = new GetUserPositionService
                (
                    investmentRepository: investmentRepositoryMock.Object,
                    userValuesRepository: userValuesRepositoryMock.Object
                );
        }

        private readonly List<Investment> investmentsListMock = new()
        {
            new Investment()
            {
                Amount = 4,
                AverageCost = 90,
                CurrentPrice = 100,
                Result = 40,
                Ticker = "OIBR3",
                TotalCost = 400
            },
            new Investment()
            {
                Amount = 5,
                AverageCost = 90,
                CurrentPrice = 100,
                Result = 50,
                Ticker = "JHSF3",
                TotalCost = 500
            }
        };

        private readonly UserValues userValuesMock = new()
        {
            CheckingAccountAmount = 100,
            Consolidated = 1000
        };

        [Fact]
        public void GetUserPositionService_Success()
        {
            investmentRepositoryMock.Setup(m => m.GetUserInvestmentsByUserId(It.IsAny<int>())).Returns(investmentsListMock);
            userValuesRepositoryMock.Setup(m => m.GetUserValuesByUserId(It.IsAny<int>())).Returns(userValuesMock);

            var result = userPositionService.GetUserPosition(It.IsAny<int>());

            Assert.Equal(result.Consolidated, userValuesMock.Consolidated);
            Assert.Equal(result.CheckingAccountAmount, userValuesMock.CheckingAccountAmount);
            Assert.Equal(result.Positions, investmentsListMock);

            investmentRepositoryMock.Verify(m => m.GetUserInvestmentsByUserId(It.IsAny<int>()), Times.Once);
            userValuesRepositoryMock.Verify(m => m.GetUserValuesByUserId(It.IsAny<int>()), Times.Once);
            VerifyNoOtherCalls();
        }

        [Fact]
        public void GetUserPositionService_UserValues_and_Positions_Null()
        {
            var result = userPositionService.GetUserPosition(It.IsAny<int>());

            Assert.Null(result);
            investmentRepositoryMock.Verify(m => m.GetUserInvestmentsByUserId(It.IsAny<int>()), Times.Once);
            userValuesRepositoryMock.Verify(m => m.GetUserValuesByUserId(It.IsAny<int>()), Times.Once);
            VerifyNoOtherCalls();
        }

        [Fact]
        public void GetUserPositionService_Positions_Empty()
        {
            userValuesRepositoryMock.Setup(m => m.GetUserValuesByUserId(It.IsAny<int>())).Returns(userValuesMock);

            var result = userPositionService.GetUserPosition(It.IsAny<int>());

            Assert.Equal(result.Consolidated, userValuesMock.Consolidated);
            Assert.Equal(result.CheckingAccountAmount, userValuesMock.CheckingAccountAmount);
            Assert.Empty(result.Positions);
            
            investmentRepositoryMock.Verify(m => m.GetUserInvestmentsByUserId(It.IsAny<int>()), Times.Once);
            userValuesRepositoryMock.Verify(m => m.GetUserValuesByUserId(It.IsAny<int>()), Times.Once);
            VerifyNoOtherCalls();
        }

        [Fact]
        public void GetUserPositionService_UserValues_Null()
        {
            investmentRepositoryMock.Setup(m => m.GetUserInvestmentsByUserId(It.IsAny<int>())).Returns(investmentsListMock);

            var result = userPositionService.GetUserPosition(It.IsAny<int>());

            Assert.Null(result);

            investmentRepositoryMock.Verify(m => m.GetUserInvestmentsByUserId(It.IsAny<int>()), Times.Once);
            userValuesRepositoryMock.Verify(m => m.GetUserValuesByUserId(It.IsAny<int>()), Times.Once);
            VerifyNoOtherCalls();
        }

        private void VerifyNoOtherCalls()
        {
            investmentRepositoryMock.VerifyNoOtherCalls();
            userValuesRepositoryMock.VerifyNoOtherCalls();
        }

    }
}
