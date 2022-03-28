using System.Collections.Generic;
using toro.Data.Entities;

namespace toro.Domain.Dto
{
    public class UserPositionOutputDto
    {
        public decimal CheckingAccountAmount { get; set; }
        public IEnumerable<Investment> Positions { get; set; }
        public double Consolidated { get; set; }
    }
}
