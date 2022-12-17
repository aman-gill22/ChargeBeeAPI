using ChargeBee.Api;
using ChargeBee.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ChargeBeeAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        public SubscriptionController()
        {
            ApiConfig.Configure("mycompany123-test", "test_z03y7MR7lqwQG67Q5Qdfhndw04cxi0v5");
        }

        [HttpPost]
        public Subscription CreateSubscription(string paymentIntentId)
        {
            EntityResult result = Subscription.CreateWithItems("12345678")
                                                .PaymentIntentId(paymentIntentId)
                                                .SubscriptionItemItemPriceId(0, "plan-2-INR-Daily")
                                                .SubscriptionItemBillingCycles(0, 2)
                                                .SubscriptionItemQuantity(0, 1)
                                                //.SubscriptionItemUnitPrice(1, 100)
                                                //.AutoCollection(ChargeBee.Models.Enums.AutoCollectionEnum.On)
                                                //.InvoiceImmediately(true)
                                                .Request();

            Subscription subscription = result.Subscription;
            Customer customer = result.Customer;
            Card card = result.Card;
            Invoice invoice = result.Invoice;
            List<UnbilledCharge> unbilledCharges = result.UnbilledCharges;

            return subscription;
        }
    }
}
