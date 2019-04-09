using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stripe;
using System.Collections.Immutable;

namespace IdentityV2.Presentation.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        public ActionResult Index()
        {
            var stripePublishKey = ConfigurationManager.AppSettings["StripeApiPublishableKey"];
            ViewBag.StripePublishKey = stripePublishKey;
            return View();
        }




        public ActionResult Charge(string stripeEmail, string stripeToken)
        {
            /*
            var stripeClient = new Stripe.StripeClient(apiKey);
            var customers = new CustomerService();
            var charges = new ChargeService();

            var customer = customers.Create(new CustomerCreateOptions
            {
                Email = stripeEmail,
                SourceToken = stripeToken
            });
            if (customer == null) throw new ArgumentNullException(nameof(customer));

            var charge = charges.Create(new ChargeCreateOptions
            {
                Amount = 500,//charge in cents
                Description = "Sample Charge",
                Currency = "usd",
                CustomerId = customer.Id
            });
            */

            string apiKey = "sk_test_tpHTqL3sOQcasnzQxPfBGAkc00G37TbFJ7";
            var stripeClient = new Stripe.StripeClient(apiKey);

            dynamic response = stripeClient.CreateChargeWithToken(500, stripeToken, "GBP", stripeEmail);

            if (response.IsError == false && response.Paid)
            {
                // success
            }

            /*return View("Payment");*/
            // further application specific code goes here

            return View();
        }
    }
}