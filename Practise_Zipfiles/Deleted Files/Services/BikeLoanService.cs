using LoanApp.Models;

namespace LoanApp.Services
{
    public class BikeLoanService : IBikeLoanService
    {
        public List<BikeLoanRequest> GetBikeLoan()
        { 
            return new List<BikeLoanRequest>();
            {
                new BikeLoanRequest()
                {
                    BikeName = "Honda",
                    BikePrice = 75000
                },
                new BikeLoanRequest()
                {
                    BikeName = "Hero",
                    BikePrice = 55000

                }
            
            };
            
        }


    }
    
}
