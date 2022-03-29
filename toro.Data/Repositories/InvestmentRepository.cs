using System.Collections.Generic;
using toro.Data.Entities;
using toro.Data.Interfaces;

namespace toro.Data.Repositories
{
    public class InvestmentRepository : IInvestmentRepository
    {
        public InvestmentRepository() {}

        public IEnumerable<Investment> GetUserInvestmentsByUserId(int userId)
        {
            return new List<Investment>() 
            { 
                new Investment()
                {
                    Amount = 30,
                    AverageCost = 23.20,
                    CurrentPrice = 24.74,
                    Result = 46.2,
                    Ticker = "AZUL4",
                    TotalCost = 742.2
                },
                new Investment()
                {
                    Amount = 28,
                    AverageCost = 17.41,
                    CurrentPrice = 18.40,
                    Result = 27.72,
                    Ticker = "BBDC3",
                    TotalCost = 515.2
                },
                new Investment()
                {
                    Amount = 10,
                    AverageCost = 23.20,
                    CurrentPrice = 24.74,
                    Result = 15.40,
                    Ticker = "BEES3",
                    TotalCost = 247.40
                },
                new Investment()
                {
                    Amount = 50,
                    AverageCost = 14.88,
                    CurrentPrice = 13,
                    Result = -94,
                    Ticker = "USIM5",
                    TotalCost = 650
                },
                new Investment()
                {
                    Amount = 25,
                    AverageCost = 12,
                    CurrentPrice = 11,
                    Result = -25,
                    Ticker = "JHSF3F",
                    TotalCost = 275
                },
            };
        }
    }
}
