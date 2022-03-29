using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using toro.Data.Entities;
using toro.Domain.Dto;
using toro.Domain.Interfaces;
using toro.WebApi.Controllers;
using Xunit;

namespace toro.Tests
{
    public class UserPositionControllerTest
    {
        private readonly UserPositionController userPositionController;
        private readonly Mock<IGetUserPosition> getUserPositionMock;

        public UserPositionControllerTest()
        {
            getUserPositionMock = new Mock<IGetUserPosition>();
            userPositionController = new UserPositionController(getUserPositionMock.Object);
        }

        private readonly UserPositionOutputDto userPositionMock = new()
        {
            CheckingAccountAmount = 100,
            Consolidated = 1000,
            Positions = new List<Investment>
            {
                new Investment()
                {
                    Amount = 9,
                    AverageCost = 90,
                    CurrentPrice = 100,
                    Result = 90,
                    Ticker = "OIBR3",
                    TotalCost = 900
                }
            }
        };

        [Fact]
        public void GetUserPosition_Success()
        {
            getUserPositionMock.Setup(m => m.GetUserPosition(It.IsAny<int>())).Returns(userPositionMock);

            var actionResult = userPositionController.GetUserPosition();

            var result = Assert.IsType<OkObjectResult>(actionResult);

            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);

            var jsonReturn = (Assert.IsAssignableFrom<UserPositionOutputDto>(result.Value));

            Assert.NotNull(jsonReturn);
            Assert.Equal(jsonReturn.Consolidated, userPositionMock.Consolidated);
            Assert.Equal(jsonReturn.CheckingAccountAmount, userPositionMock.CheckingAccountAmount);
            Assert.Equal(jsonReturn.Positions, userPositionMock.Positions);

            getUserPositionMock.Verify(m => m.GetUserPosition(It.IsAny<int>()), Times.Once);
            getUserPositionMock.VerifyNoOtherCalls();

        }

        [Fact]
        public void GetUserPosition_Success_Empty()
        {
            var actionResult = userPositionController.GetUserPosition();

            var result = Assert.IsType<OkObjectResult>(actionResult);

            Assert.Null(result.Value);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);

            getUserPositionMock.Verify(m => m.GetUserPosition(It.IsAny<int>()), Times.Once);
            getUserPositionMock.VerifyNoOtherCalls();
        }
    }
}
