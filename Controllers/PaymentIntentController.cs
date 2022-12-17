using Microsoft.AspNetCore.Mvc;
using ChargeBee.Api;
using ChargeBee.Models;
using System.Reflection;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChargeBeeAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PaymentIntentController : ControllerBase
    {
        public PaymentIntentController()
        {
            ApiConfig.Configure("mycompany123-test", "test_z03y7MR7lqwQG67Q5Qdfhndw04cxi0v5");
        }
       
        [HttpGet]
        public PaymentIntent CreatePaymentIntent()
        {
            // we can take in the amount and currency
            EntityResult result = PaymentIntent.Create()
                // this amount is in cents
                                    .Amount(10000)
                                    .CurrencyCode("INR")
                                    .CustomerId("12345678")
                                    .Request();

            PaymentIntent paymentIntent = result.PaymentIntent;
         
            return paymentIntent;
        }

    }
}
